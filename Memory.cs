using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Buffers;

namespace ANYE_Balls
{
    public class Memory
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct MEMORY_BASIC_INFORMATION
        {
            public IntPtr BaseAddress;
            public IntPtr AllocationBase;
            public uint AllocationProtect;
            public IntPtr RegionSize;
            public uint State;
            public uint Protect;
            public uint Type;
        }

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out int lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize, out int lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll")]
        public static extern int VirtualQueryEx(IntPtr hProcess, IntPtr lpAddress, out MEMORY_BASIC_INFORMATION lpBuffer, int dwLength);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool IsWow64Process(IntPtr hProcess, out bool wow64Process);

        // 内存保护常量
        private const uint MEM_COMMIT = 0x1000;
        private const uint PAGE_NOACCESS = 0x01;
        private const uint PAGE_GUARD = 0x100;

        // ==================== 接口1：原有的精确匹配 ====================
        public static List<long> ScanPatternParallel(IntPtr hProcess, byte[] pattern, int pLen)
        {
            bool[] mask = new bool[pLen];
            for (int i = 0; i < pLen; i++) mask[i] = true; // 全部设为精确匹配

            long bgadd = 0x00000000;
            long endadd = GetMaxAddress(hProcess);
            return ScanPatternInRangeMask(hProcess, pattern, mask, bgadd, endadd);
        }

        // ==================== 接口2：字符串模式 + 通配符支持 ====================
        public static List<long> ScanPatternParallel(IntPtr hProcess, string patternString)
        {
            byte?[] patternNullable = ParsePatternString(patternString);
            if (patternNullable == null || patternNullable.Length == 0)
                return new List<long>();

            byte[] patternBytes = new byte[patternNullable.Length];
            bool[] mask = new bool[patternNullable.Length];
            for (int i = 0; i < patternNullable.Length; i++)
            {
                if (patternNullable[i].HasValue)
                {
                    patternBytes[i] = patternNullable[i].Value;
                    mask[i] = true;
                }
                else
                {
                    patternBytes[i] = 0;
                    mask[i] = false;
                }
            }

            long bgadd = 0x00000000;
            long endadd = GetMaxAddress(hProcess);
            return ScanPatternInRangeMask(hProcess, patternBytes, mask, bgadd, endadd);
        }


        private static List<long> ScanPatternInRangeMask(IntPtr hProcess, byte[] pattern, bool[] mask, long startAddress, long endAddress)
        {

            ConcurrentBag<long> foundAddresses = new ConcurrentBag<long>();
            const int MEM_SIZE = 4 * 1024 * 1024;
            // 优化 1：限制最大并发线程数，腾出足够的核心让游戏和系统保持流畅
            int MAX_THREADS = Math.Max(2, Environment.ProcessorCount / 2);
            SemaphoreSlim semaphore = new SemaphoreSlim(MAX_THREADS);
            int pLen = pattern.Length;

            long currentAddress = startAddress;
            List<Task> tasks = new List<Task>();

            try
            {
                while (currentAddress < endAddress)
                {
                    VirtualQueryEx(hProcess, (IntPtr)currentAddress, out MEMORY_BASIC_INFORMATION mbi, Marshal.SizeOf(typeof(MEMORY_BASIC_INFORMATION)));

                    long regionSize = mbi.RegionSize.ToInt64();
                    if (regionSize <= 0) break;


                    bool isCommit = mbi.State == MEM_COMMIT;
                    // 优化 2：只扫描可读写内存 (PAGE_READWRITE = 0x04) 以及可执行可读写内存 (PAGE_EXECUTE_READWRITE = 0x40)
                    bool isWritable = (mbi.Protect == 0x04 || mbi.Protect == 0x40);

                    if (!isCommit || !isWritable)
                    {
                        currentAddress += regionSize;
                        continue;
                    }

                    long regionStart = (long)mbi.BaseAddress;
                    long regionEnd = regionStart + regionSize;

                    if (regionStart < startAddress) regionStart = startAddress;
                    if (regionEnd > endAddress) regionEnd = endAddress;

                    long regionStartCopy = regionStart;
                    long regionEndCopy = regionEnd;

                    tasks.Add(Task.Run(async () =>
                    {
                        await semaphore.WaitAsync();


                        byte[] localMem = ArrayPool<byte>.Shared.Rent(MEM_SIZE);
                        try
                        {
                            long memIndex = regionStartCopy;
                            while (memIndex < regionEndCopy)
                            {
                                int bufferSize = (int)Math.Min(MEM_SIZE, regionEndCopy - memIndex);

                                if (ReadProcessMemory(hProcess, (IntPtr)memIndex, localMem, bufferSize, out int bytesRead) && bytesRead > 0)
                                {

                                    List<int> offsets = SundaySearchMaskUnsafe(localMem, bytesRead, pattern, mask, pLen);
                                    foreach (int offset in offsets)
                                    {
                                        foundAddresses.Add(memIndex + offset);
                                    }
                                }

                                if (bytesRead == MEM_SIZE && (memIndex + MEM_SIZE) < regionEndCopy)
                                {
                                    memIndex += MEM_SIZE - (pLen - 1);
                                }
                                else
                                {
                                    memIndex += bytesRead == 0 ? bufferSize : bytesRead;
                                }
                            }
                        }
                        finally
                        {
                            ArrayPool<byte>.Shared.Return(localMem); // 归还内存池
                            semaphore.Release();
                        }
                    }));

                    currentAddress = regionEnd;
                }

                Task.WaitAll(tasks.ToArray());
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception occurred in mask scan: " + ex.Message);
            }
            // 优化：去掉了极其致命的 GC.Collect()

            return foundAddresses.ToList();
        }

        // ==================== unsafe 指针 Sunday 比对引擎 ====================

        private static unsafe List<int> SundaySearchMaskUnsafe(byte[] target, int targetLen, byte[] pattern, bool[] mask, int pLen)
        {
            List<int> indexes = new List<int>();
            if (targetLen < pLen) return indexes;

            int defaultShift = pLen + 1;
            for (int i = 0; i < pLen; i++)
            {
                if (!mask[i])
                {
                    int s = pLen - i;
                    if (s < defaultShift) defaultShift = s;
                }
            }

            int[] shift = new int[256];
            for (int i = 0; i < 256; i++) shift[i] = defaultShift;
            for (int i = 0; i < pLen; i++)
            {
                if (mask[i])
                {
                    int s = pLen - i;
                    if (s < shift[pattern[i]])
                    {
                        shift[pattern[i]] = s;
                    }
                }
            }

            fixed (byte* pTarget = target)
            fixed (byte* pPattern = pattern)
            fixed (bool* pMask = mask)
            {
                int index = 0;
                int limit = targetLen - pLen;

                while (index <= limit)
                {
                    int j = 0;
                    while (j < pLen)
                    {
                        if (pMask[j] && pTarget[index + j] != pPattern[j])
                            break;
                        j++;
                    }

                    if (j == pLen)
                    {
                        indexes.Add(index);
                    }

                    if (index + pLen >= targetLen)
                        break;

                    index += shift[pTarget[index + pLen]];
                }
            }
            return indexes;
        }

        // ==================== 辅助工具函数 ====================
        private static byte?[] ParsePatternString(string pattern)
        {
            if (string.IsNullOrWhiteSpace(pattern)) return null;

            string[] parts = pattern.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            List<byte?> result = new List<byte?>(parts.Length);

            foreach (string part in parts)
            {
                string upper = part.ToUpper();
                if (upper == "??" || upper == "?")
                {
                    result.Add(null);
                }
                else if (upper.Length == 2 &&
                         ((upper[0] >= '0' && upper[0] <= '9') || (upper[0] >= 'A' && upper[0] <= 'F')) &&
                         ((upper[1] >= '0' && upper[1] <= '9') || (upper[1] >= 'A' && upper[1] <= 'F')))
                {
                    result.Add(Convert.ToByte(upper, 16));
                }
                else
                {
                    throw new ArgumentException($"Invalid pattern token: {part}");
                }
            }
            return result.ToArray();
        }

        private static long GetMaxAddress(IntPtr hProcess)
        {
            if (Environment.Is64BitOperatingSystem)
            {
                if (IsWow64Process(hProcess, out bool isWow64) && isWow64)
                    return 0xFFFFFFFF;      // 32位进程
                else
                    return 0x7FFFFFFFFFFF;  // 64位进程
            }
            else
            {
                return 0xFFFFFFFF;
            }
        }
    }
}
using SharpAdbClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ANYE_Balls
{
    public partial class pifugongneng : Form
    {
        public static string adbPath = "";
        string xmlpath = "/storage/emulated/0/Android/data/com.ztgame.bob/files/vercache2022/android/ver.xml";
        string localpath = @"C:\ver.xml";

        public pifugongneng()
        {
            InitializeComponent();
        }

        private void pifugongneng_Load(object sender, EventArgs e)
        {
        }

        // ========== 通用方法：按前缀查找文件 ==========
        /// <summary>
        /// 在设备指定目录下查找第一个以 prefix 开头的文件，返回完整路径
        /// </summary>
        private string FindFirstFileByPrefix(string adbDir, int port, string directory, string prefix)
        {
            // 构造查找命令，如：shell ls "/path/prefix*"
            string searchPattern = $"{directory.TrimEnd('/')}/{prefix}*";
            string lsArgs = $"-s 127.0.0.1:{port} shell ls \"{searchPattern}\"";
            string output = RunAdbCommand(adbDir, lsArgs);

            if (string.IsNullOrWhiteSpace(output))
                throw new Exception($"未找到以 {prefix} 开头的文件，目录：{directory}");

            string[] lines = output.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            string filename = lines[0].Trim();

            // 如果 ls 只返回了文件名，补全为绝对路径
            if (!filename.StartsWith("/"))
                filename = directory.TrimEnd('/') + "/" + filename;

            return filename;
        }

        //去皮功能核心代码，分三步走：连接模拟器 -> 获取 root 权限（如果需要） -> chmod 000 目标文件
        private void buttonSet000_Click(object sender, EventArgs e)
        {
            string adbDir = null;      // adb.exe 所在目录
            int port = 16384;
            string processName = "MuMuPlayer";

            // 确定模拟器类型 -> 进程名/端口
            if (MainForm.choose == "MuMu模拟器")
                processName = "MuMuPlayer";
            else if (MainForm.choose == "雷电模拟器5" || MainForm.choose == "雷电模拟器9")
            {
                processName = "dnplayer";
                port = 5555;
            }

            // ----- 方式1：从正在运行的模拟器进程目录找 -----
            Process[] processes = Process.GetProcessesByName(processName);
            if (processes.Length > 0)
            {
                try
                {
                    string procDir = Path.GetDirectoryName(processes[0].MainModule.FileName);
                    if (Directory.Exists(procDir) && File.Exists(Path.Combine(procDir, "adb.exe")))
                        adbDir = procDir;
                }
                catch { }
            }

            // ----- 方式2：尝试几个常见安装路径 -----
            if (string.IsNullOrEmpty(adbDir))
            {
                string[] possiblePaths =
                {
            @"D:\Program Files\Netease\MuMu Player 12\nx_main",
            @"C:\Program Files\Netease\MuMu Player 12\nx_main",
            @"D:\MuMuPlayer-12.0\nx_main",
            @"C:\MuMuPlayer-12.0\nx_main",
            @"D:\leidian\LDPlayer9",
            @"C:\leidian\LDPlayer9",
            @"D:\Program Files\ldplayer9",
            // 这里可以添加你自己的安装路径
        };

                foreach (var dir in possiblePaths)
                {
                    if (Directory.Exists(dir) && File.Exists(Path.Combine(dir, "adb.exe")))
                    {
                        adbDir = dir;
                        break;
                    }
                }
            }

            // ----- 方式3（最终保底）：释放 Resources 中的 adb.exe -----
            if (string.IsNullOrEmpty(adbDir))
            {
                try
                {
                    // 从资源中取出 adb.exe 的字节数组
                    byte[] adbBytes = Properties.Resources.adb;   // 注意：属性名要与 Resources.Designer.cs 中一致
                    string tempDir = Path.Combine(Path.GetTempPath(), "ANYE_adb_temp");
                    Directory.CreateDirectory(tempDir);
                    string adbExe = Path.Combine(tempDir, "adb.exe");
                    File.WriteAllBytes(adbExe, adbBytes);
                    adbDir = tempDir;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("释放内置 adb.exe 失败，请检查资源文件中是否包含 adb.exe。\n错误信息：" + ex.Message);
                    return;
                }
            }

            // 最后确认一下 adb.exe 确实存在
            if (string.IsNullOrEmpty(adbDir) || !File.Exists(Path.Combine(adbDir, "adb.exe")))
            {
                MessageBox.Show("无法找到任何可用的 adb.exe，操作终止。");
                return;
            }

            try
            {
                // 1. 连接到模拟器
                RunAdbCommand(adbDir, $"connect 127.0.0.1:{port}");

                // 2. 获取 root（某些设备需要）
                RunAdbCommand(adbDir, $"-s 127.0.0.1:{port} root");

                // 3. 动态查找目标文件（以前缀 shopconfig.unity3d_u_ 匹配）
                string basePath = "/storage/emulated/0/Android/data/com.ztgame.bob/files/vercache2022/android/common/data";
                string targetFile = FindFirstFileByPrefix(adbDir, port, basePath, "shopconfig.unity3d_u_");

                // 4. 设置权限为 000
                string chmodCmd = $"shell chmod 000 \"{targetFile}\"";
                RunAdbCommand(adbDir, $"-s 127.0.0.1:{port} {chmodCmd}");
                RunAdbCommand(adbDir, "kill-server");

                MessageBox.Show("去皮成功！\n请大退游戏后生效",
                                "去皮成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                try { RunAdbCommand(adbDir, "kill-server"); } catch { }
                MessageBox.Show("执行失败，错误原因：\n", "请使用默认模拟器");
            }
        }

        // ========== 新增：恢复皮肤（将活动配置文件权限改为660） ==========
        private void buttonSet660_Click(object sender, EventArgs e)
        {
            string adbDir = null;      // adb.exe 所在目录
            int port = 16384;
            string processName = "MuMuPlayer";

            // 确定模拟器类型 -> 进程名/端口
            if (MainForm.choose == "MuMu模拟器")
                processName = "MuMuPlayer";
            else if (MainForm.choose == "雷电模拟器5" || MainForm.choose == "雷电模拟器9")
            {
                processName = "dnplayer";
                port = 5555;
            }

            // ----- 方式1：从正在运行的模拟器进程目录找 -----
            Process[] processes = Process.GetProcessesByName(processName);
            if (processes.Length > 0)
            {
                try
                {
                    string procDir = Path.GetDirectoryName(processes[0].MainModule.FileName);
                    if (Directory.Exists(procDir) && File.Exists(Path.Combine(procDir, "adb.exe")))
                        adbDir = procDir;
                }
                catch { }
            }

            // ----- 方式2：尝试几个常见安装路径 -----
            if (string.IsNullOrEmpty(adbDir))
            {
                string[] possiblePaths =
                {
            @"D:\Program Files\Netease\MuMu Player 12\nx_main",
            @"C:\Program Files\Netease\MuMu Player 12\nx_main",
            @"D:\MuMuPlayer-12.0\nx_main",
            @"C:\MuMuPlayer-12.0\nx_main",
            @"D:\leidian\LDPlayer9",
            @"C:\leidian\LDPlayer9",
            @"D:\Program Files\ldplayer9",
        };

                foreach (var dir in possiblePaths)
                {
                    if (Directory.Exists(dir) && File.Exists(Path.Combine(dir, "adb.exe")))
                    {
                        adbDir = dir;
                        break;
                    }
                }
            }

            // ----- 方式3（最终保底）：释放 Resources 中的 adb.exe -----
            if (string.IsNullOrEmpty(adbDir))
            {
                try
                {
                    byte[] adbBytes = Properties.Resources.adb;   // 注意资源名，可能是 adb 或 adb_exe
                    string tempDir = Path.Combine(Path.GetTempPath(), "ANYE_adb_temp");
                    Directory.CreateDirectory(tempDir);
                    string adbExe = Path.Combine(tempDir, "adb.exe");
                    File.WriteAllBytes(adbExe, adbBytes);
                    adbDir = tempDir;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("释放内置 adb.exe 失败，请检查资源文件中是否包含 adb.exe。\n错误信息：" + ex.Message);
                    return;
                }
            }

            // 最终确认 adb.exe 存在
            if (string.IsNullOrEmpty(adbDir) || !File.Exists(Path.Combine(adbDir, "adb.exe")))
            {
                MessageBox.Show("无法找到任何可用的 adb.exe，操作终止。");
                return;
            }

            try
            {
                // 1. 连接模拟器
                RunAdbCommand(adbDir, $"connect 127.0.0.1:{port}");

                // 2. 获取 root（某些设备需要）
                RunAdbCommand(adbDir, $"-s 127.0.0.1:{port} root");

                // 3. 动态查找目标文件（以前缀 shopconfig.unity3d_u_ 匹配）
                string basePath = "/storage/emulated/0/Android/data/com.ztgame.bob/files/vercache2022/android/common/data";
                string targetFile = FindFirstFileByPrefix(adbDir, port, basePath, "shopconfig.unity3d_u_");

                // 4. 设置权限为 660
                string chmodCmd = $"shell chmod 660 \"{targetFile}\"";
                RunAdbCommand(adbDir, $"-s 127.0.0.1:{port} {chmodCmd}");

                // 5. 关闭 adb server，释放进程
                RunAdbCommand(adbDir, "kill-server");

                MessageBox.Show("恢复皮肤成功！\n请大退游戏后生效",
                                "恢复皮肤成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // 即使出错也尝试关闭 server
                try { RunAdbCommand(adbDir, "kill-server"); } catch { }

                MessageBox.Show("执行失败，错误原因：\n", "请使用默认模拟器");
            }
        }

        // ========== 新增：去活动（将活动配置文件权限改为000） ==========
        private void button1quhuodong_Click(object sender, EventArgs e)
        {
            string adbDir = null;      // adb.exe 所在目录
            int port = 16384;
            string processName = "MuMuPlayer";

            // 确定模拟器类型 -> 进程名/端口
            if (MainForm.choose == "MuMu模拟器")
                processName = "MuMuPlayer";
            else if (MainForm.choose == "雷电模拟器5" || MainForm.choose == "雷电模拟器9")
            {
                processName = "dnplayer";
                port = 5555;
            }

            // ----- 方式1：从正在运行的模拟器进程目录找 -----
            Process[] processes = Process.GetProcessesByName(processName);
            if (processes.Length > 0)
            {
                try
                {
                    string procDir = Path.GetDirectoryName(processes[0].MainModule.FileName);
                    if (Directory.Exists(procDir) && File.Exists(Path.Combine(procDir, "adb.exe")))
                        adbDir = procDir;
                }
                catch { }
            }

            // ----- 方式2：尝试几个常见安装路径 -----
            if (string.IsNullOrEmpty(adbDir))
            {
                string[] possiblePaths =
                {
            @"D:\Program Files\Netease\MuMu Player 12\nx_main",
            @"C:\Program Files\Netease\MuMu Player 12\nx_main",
            @"D:\MuMuPlayer-12.0\nx_main",
            @"C:\MuMuPlayer-12.0\nx_main",
            @"D:\leidian\LDPlayer9",
            @"C:\leidian\LDPlayer9",
            @"D:\Program Files\ldplayer9",
        };

                foreach (var dir in possiblePaths)
                {
                    if (Directory.Exists(dir) && File.Exists(Path.Combine(dir, "adb.exe")))
                    {
                        adbDir = dir;
                        break;
                    }
                }
            }

            // ----- 方式3（最终保底）：释放 Resources 中的 adb.exe -----
            if (string.IsNullOrEmpty(adbDir))
            {
                try
                {
                    byte[] adbBytes = Properties.Resources.adb;   // 注意资源名，可能是 adb 或 adb_exe
                    string tempDir = Path.Combine(Path.GetTempPath(), "ANYE_adb_temp");
                    Directory.CreateDirectory(tempDir);
                    string adbExe = Path.Combine(tempDir, "adb.exe");
                    File.WriteAllBytes(adbExe, adbBytes);
                    adbDir = tempDir;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("释放内置 adb.exe 失败，请检查资源文件中是否包含 adb.exe。\n错误信息：" + ex.Message);
                    return;
                }
            }

            // 最终确认 adb.exe 存在
            if (string.IsNullOrEmpty(adbDir) || !File.Exists(Path.Combine(adbDir, "adb.exe")))
            {
                MessageBox.Show("无法找到任何可用的 adb.exe，操作终止。");
                return;
            }

            try
            {
                // 1. 连接模拟器
                RunAdbCommand(adbDir, $"connect 127.0.0.1:{port}");

                // 2. 获取 root（某些设备需要）
                RunAdbCommand(adbDir, $"-s 127.0.0.1:{port} root");

                // 3. 动态查找活动配置文件（以前缀 activityconfig.unity3d_u_ 匹配）
                string basePath = "/storage/emulated/0/Android/data/com.ztgame.bob/files/vercache2022/android/common/data";
                string targetFile = FindFirstFileByPrefix(adbDir, port, basePath, "activityconfig.unity3d_u_");

                // 4. 设置权限为 000
                string chmodCmd = $"shell chmod 000 \"{targetFile}\"";
                RunAdbCommand(adbDir, $"-s 127.0.0.1:{port} {chmodCmd}");

                // 5. 关闭 adb server，释放进程
                RunAdbCommand(adbDir, "kill-server");

                MessageBox.Show("去活动成功！\n请大退游戏后生效",
                                "去活动成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // 即使出错也尝试关闭 server
                try { RunAdbCommand(adbDir, "kill-server"); } catch { }

                MessageBox.Show("执行失败，错误原因：\n", "请使用默认模拟器");
            }
        }

        // ========== 新增：恢复活动（将活动配置文件权限改为660） ==========
        private void button1huifuhuodong_Click(object sender, EventArgs e)
        {
            string adbDir = null;      // adb.exe 所在目录
            int port = 16384;
            string processName = "MuMuPlayer";

            // 确定模拟器类型 -> 进程名/端口
            if (MainForm.choose == "MuMu模拟器")
                processName = "MuMuPlayer";
            else if (MainForm.choose == "雷电模拟器5" || MainForm.choose == "雷电模拟器9")
            {
                processName = "dnplayer";
                port = 5555;
            }

            // ----- 方式1：从正在运行的模拟器进程目录找 -----
            Process[] processes = Process.GetProcessesByName(processName);
            if (processes.Length > 0)
            {
                try
                {
                    string procDir = Path.GetDirectoryName(processes[0].MainModule.FileName);
                    if (Directory.Exists(procDir) && File.Exists(Path.Combine(procDir, "adb.exe")))
                        adbDir = procDir;
                }
                catch { }
            }

            // ----- 方式2：尝试几个常见安装路径 -----
            if (string.IsNullOrEmpty(adbDir))
            {
                string[] possiblePaths =
                {
            @"D:\Program Files\Netease\MuMu Player 12\nx_main",
            @"C:\Program Files\Netease\MuMu Player 12\nx_main",
            @"D:\MuMuPlayer-12.0\nx_main",
            @"C:\MuMuPlayer-12.0\nx_main",
            @"D:\leidian\LDPlayer9",
            @"C:\leidian\LDPlayer9",
            @"D:\Program Files\ldplayer9",
        };

                foreach (var dir in possiblePaths)
                {
                    if (Directory.Exists(dir) && File.Exists(Path.Combine(dir, "adb.exe")))
                    {
                        adbDir = dir;
                        break;
                    }
                }
            }

            // ----- 方式3（最终保底）：释放 Resources 中的 adb.exe -----
            if (string.IsNullOrEmpty(adbDir))
            {
                try
                {
                    byte[] adbBytes = Properties.Resources.adb;   // 注意资源名，可能是 adb 或 adb_exe
                    string tempDir = Path.Combine(Path.GetTempPath(), "ANYE_adb_temp");
                    Directory.CreateDirectory(tempDir);
                    string adbExe = Path.Combine(tempDir, "adb.exe");
                    File.WriteAllBytes(adbExe, adbBytes);
                    adbDir = tempDir;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("释放内置 adb.exe 失败，请检查资源文件中是否包含 adb.exe。\n错误信息：" + ex.Message);
                    return;
                }
            }

            // 最终确认 adb.exe 存在
            if (string.IsNullOrEmpty(adbDir) || !File.Exists(Path.Combine(adbDir, "adb.exe")))
            {
                MessageBox.Show("无法找到任何可用的 adb.exe，操作终止。");
                return;
            }

            try
            {
                // 1. 连接模拟器
                RunAdbCommand(adbDir, $"connect 127.0.0.1:{port}");

                // 2. 获取 root（某些设备需要）
                RunAdbCommand(adbDir, $"-s 127.0.0.1:{port} root");

                // 3. 动态查找活动配置文件（以前缀 activityconfig.unity3d_u_ 匹配）
                string basePath = "/storage/emulated/0/Android/data/com.ztgame.bob/files/vercache2022/android/common/data";
                string targetFile = FindFirstFileByPrefix(adbDir, port, basePath, "activityconfig.unity3d_u_");

                // 4. 设置权限为 660
                string chmodCmd = $"shell chmod 660 \"{targetFile}\"";
                RunAdbCommand(adbDir, $"-s 127.0.0.1:{port} {chmodCmd}");

                // 5. 关闭 adb server，释放进程
                RunAdbCommand(adbDir, "kill-server");

                MessageBox.Show("恢复活动成功！\n请大退游戏后生效",
                                "恢复活动成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // 即使出错也尝试关闭 server
                try { RunAdbCommand(adbDir, "kill-server"); } catch { }

                MessageBox.Show("执行失败，错误原因：\n", "请使用默认模拟器");
            }
        }


        // ========== 新增辅助方法：直接执行 adb 命令 ==========
        private string RunAdbCommand(string adbPath, string arguments)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = Path.Combine(adbPath, "adb.exe"),
                Arguments = arguments,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };
            using (Process p = Process.Start(psi))
            {
                string output = p.StandardOutput.ReadToEnd();
                string error = p.StandardError.ReadToEnd();
                p.WaitForExit();
                if (!string.IsNullOrEmpty(error))
                    Debug.WriteLine($"ADB Error: {error}");
                return output;
            }
        }
    }
}
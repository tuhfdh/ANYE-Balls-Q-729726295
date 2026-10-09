using System.IO;
using System.Reflection;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Reflection;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using Vanara.PInvoke;
using static ANYE_Balls.API;
using static ANYE_Balls.Struct;

namespace ANYE_Balls
{
    public partial class fuzhugongneng : Form
    {
        public static fuzhugongneng fuzhugongnengInstance;
                                                                                        
        

        private static Form trackNotificationForm;
        private static Form rankNotificationForm;
        private static System.Windows.Forms.Timer rankNotificationTimer;
        static bool thkq = false;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out Struct.POINT lpPoint);

        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int vKey);

        [DllImport("user32.dll")]
        private static extern short GetKeyState(int nVirtKey);

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

        [DllImport("user32.dll")]
        static extern uint MapVirtualKeyW(uint uCode, uint uMapType);

        [DllImport("kernel32.dll")]
        static extern bool ReadProcessMemory(IntPtr hProcess, long lpBaseAddress, byte[] lpBuffer, uint dwSize, out int lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        static extern bool WriteProcessMemory(IntPtr hProcess, long lpBaseAddress, byte[] lpBuffer, uint nSize, out int lpNumberOfBytesWritten);


        [DllImport("user32.dll")]
        static extern bool GetWindowRect(IntPtr hWnd, out Struct.RECT lpRect);

        static Struct.RECT mnqRect;
        private const int WH_MOUSE_LL = 14;
        private const int WM_MOUSEMOVE = 0x0200;
        private const int VK_RBUTTON = 0x02;
        private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const uint MOUSEEVENTF_LEFTUP = 0x0004;
        private const uint KEYEVENTF_KEYUP = 0x0002;
        delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);
        IntPtr g_hook;
        private BackgroundWorker hookWorker;
        private readonly object lockObj = new object();
        static object lockObj2 = new object();
        public static float youjiankongqiu;
        public static long tiji;

        private static Struct.POINT mp1, mp2;
        private static bool state;
        private static int yuzhi = 90;

        private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);
        private static LowLevelMouseProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        static double length;
        static double unitX;
        static double unitY;

        public static byte[] aiFeature = { 0x01, 0x03, 0x05, 0x07, 0x09, 0x10, 0xAA, 0xBB, 0xCC, 0xDD };
        public static byte[] viewFeature = { 0x00, 0x00, 0x48, 0x44, 0xFF, 0xFF, 0xFF, 0xFF };
        public static byte[] zsFeature = { 0x00, 0x80, 0x3B, 0x44, 0x00, 0x00, 0x80, 0x3F, 0x00, 0x00, 0x80, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x3F };
        public static byte[] rankPattern = { 0x80, 0x3F, 0xEC, 0xEB, 0x6B, 0x3F, 0xED, 0xEC, 0x6C, 0x3E, 0x00, 0x00, 0x80, 0x3F };

        public static bool isElfInjected = false;
        public static long addr_ai_base = 0;
        public static long addr_view_range_feature = 0;
        public static long zszuobiao = 0;
        public static int targetUid = 0;

        public static byte aiLockKey;
        public static byte aiTrackKey;
        public static byte mouseRankKey;

        public static bool isAiLockingActive = false;
        public static bool isAiTrackingActive = false;
        public static bool isLocking = false;
        public static bool isAiTracking = false;

        public struct TargetData
        {
            public float x;
            public float y;
            public float radius;
            public float dir_x;
            public float dir_y;
        }

        public struct DrawTargetInfo
        {
            public float x;
            public float y;
            public float radius;
            public int rank;
        }

        public struct DrawState
        {
            public float self_x;
            public float self_y;
            public float view_range;
            public float syzhi;
            public DrawTargetInfo directTarget;
            public List<DrawTargetInfo> allEntities;
            public ANYE_Balls.Struct.RECT emulatorRect;
            public bool isForeground;
            public int offset_y;
        }

        private static Form huizhiOverlayForm;
        private static Thread drawingThread;
        private static bool isDrawingActive = false;
        private static DrawState currentDrawState = new DrawState { allEntities = new List<DrawTargetInfo>() };
        private static readonly object drawLock = new object();

        private static Thread autoMatchMonitorThread;
        private static bool isAutoMatchMonitorActive = false;

        public fuzhugongneng()
        {
            InitializeComponent();
        }


        private void ShowTrackNotification()
        {
            if (trackNotificationForm == null || trackNotificationForm.IsDisposed)
            {
                trackNotificationForm = new Form();
                trackNotificationForm.FormBorderStyle = FormBorderStyle.None;
                trackNotificationForm.BackColor = Color.Black;
                trackNotificationForm.Opacity = 0.5;
                trackNotificationForm.StartPosition = FormStartPosition.Manual;
                trackNotificationForm.TopMost = true;
                trackNotificationForm.ShowInTaskbar = false;
                trackNotificationForm.ControlBox = false;

                int screenWidth = Screen.PrimaryScreen.Bounds.Width;
                int screenHeight = Screen.PrimaryScreen.Bounds.Height;
                trackNotificationForm.Size = new Size(300, 100);
                trackNotificationForm.Location = new Point((int)(screenWidth * 0.1), (int)(screenHeight * 0.7)); // Positioned above Sync notification

                Label label = new Label();
                label.Text = "AI大炮追踪已开启";
                label.Font = new Font("微软雅黑", 20, FontStyle.Bold);
                label.ForeColor = Color.FromArgb(90, 250, 90);
                label.Dock = DockStyle.Fill;
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.BackColor = Color.Transparent;
                trackNotificationForm.Controls.Add(label);
            }

            if (!trackNotificationForm.Visible)
            {
                trackNotificationForm.Show();
            }
        }

        private void HideTrackNotification()
        {
            if (trackNotificationForm != null && !trackNotificationForm.IsDisposed && trackNotificationForm.Visible)
            {
                trackNotificationForm.Hide();
            }
        }

        private void InvokeShowTrackNotification()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)ShowTrackNotification);
            }
            else
            {
                ShowTrackNotification();
            }
        }

        private void InvokeHideTrackNotification()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)HideTrackNotification);
            }
            else
            {
                HideTrackNotification();
            }
        }

        private void ShowRankNotification(int rank)
        {
            if (rankNotificationForm == null || rankNotificationForm.IsDisposed)
            {
                rankNotificationForm = new Form();
                rankNotificationForm.FormBorderStyle = FormBorderStyle.None;
                rankNotificationForm.BackColor = Color.Black;
                rankNotificationForm.Opacity = 0.5;
                rankNotificationForm.StartPosition = FormStartPosition.Manual;
                rankNotificationForm.TopMost = true;
                rankNotificationForm.ShowInTaskbar = false;
                rankNotificationForm.ControlBox = false;

                int screenWidth = Screen.PrimaryScreen.Bounds.Width;
                int screenHeight = Screen.PrimaryScreen.Bounds.Height;
                rankNotificationForm.Size = new Size(350, 100);
                rankNotificationForm.Location = new Point((int)(screenWidth * 0.1), (int)(screenHeight * 0.6)); // Positioned above Track notification

                Label label = new Label();
                label.Name = "rankLabel";
                label.Font = new Font("微软雅黑", 20, FontStyle.Bold);
                label.ForeColor = Color.FromArgb(90, 190, 250);
                label.Dock = DockStyle.Fill;
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.BackColor = Color.Transparent;
                rankNotificationForm.Controls.Add(label);
            }

            Control[] labels = rankNotificationForm.Controls.Find("rankLabel", true);
            if (labels.Length > 0 && labels[0] is Label lbl)
            {
                lbl.Text = $"已获取鼠标队友排名: {rank}";
            }

            if (!rankNotificationForm.Visible)
            {
                rankNotificationForm.Show();
            }

            if (rankNotificationTimer == null)
            {
                rankNotificationTimer = new System.Windows.Forms.Timer();
                rankNotificationTimer.Interval = 1000;
                rankNotificationTimer.Tick += (s, e) =>
                {
                    rankNotificationTimer.Stop();
                    if (rankNotificationForm != null && !rankNotificationForm.IsDisposed)
                    {
                        rankNotificationForm.Hide();
                    }
                };
            }
            else
            {
                rankNotificationTimer.Stop();
            }
            rankNotificationTimer.Start();
        }

        private void InvokeShowRankNotification(int rank)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() => ShowRankNotification(rank)));
            }
            else
            {
                ShowRankNotification(rank);
            }
        }

        private static IntPtr SetHook(LowLevelMouseProc proc)
        {
            return SetWindowsHookEx(WH_MOUSE_LL, proc, GetModuleHandle(null), 0);
        }

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (API.GetForegroundWindow() == API.FindWindow(MainForm.lp, null) && MainForm.shifouzhanju == true)
            {
                if (nCode >= 0 && wParam.ToInt32() == WM_MOUSEMOVE && state)
                {
                    unsafe
                    {
                        MSLLHOOKSTRUCT* pMouseStruct = (MSLLHOOKSTRUCT*)lParam;
                        mp2.X = pMouseStruct->pt.X;
                        mp2.Y = pMouseStruct->pt.Y;
                        int deltaX = mp2.X - mp1.X;
                        int deltaY = mp2.Y - mp1.Y;
                        int distanceSquared = deltaX * deltaX + deltaY * deltaY;
                        if (distanceSquared > yuzhi * yuzhi)
                        {
                            double length = Math.Sqrt(distanceSquared);
                            double unitX = deltaX / length;
                            double unitY = deltaY / length;

                            mp2.X = mp1.X + (int)(unitX * Math.Sqrt(yuzhi * yuzhi));
                            mp2.Y = mp1.Y + (int)(unitY * Math.Sqrt(yuzhi * yuzhi));
                            SetCursorPos(mp2.X, mp2.Y);

                            return (IntPtr)1;
                        }
                    }
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        private void checkboxsuoqiu_CheckedChanged(object sender, bool value)
        {
            if (checkboxsuoqiu.Checked)
            {
                neicunheqiu.suoqiuflag = true;
                Json.writejson("suoqiu", "true");
            }
            else
            {
                neicunheqiu.suoqiuflag = false;
                Json.writejson("suoqiu", "false");
            }
        }

        private void checkboxkongqiu_CheckedChanged(object sender, bool value)
        {
            if (checkboxkongqiu.Checked)
            {
                Json.writejson("kongqiukq", "true");
                _hookID = SetHook(_proc);
                if (!thkq)
                {
                    thkq = true;
                    new Thread(() =>
                    {
                        while (true)
                        {
                            if (checkboxkongqiu.Checked && MainForm.shifouzhanju == true)
                            {
                                API.GetWindowRect(MainForm.hWnd, out mnqRect);
                                try
                                {
                                    yuzhi = int.Parse(textboxkongqiu.Text);
                                    yuzhi = (int)(yuzhi * ((float)(mnqRect.right - mnqRect.left) / 1920 * MainForm.ygdx / 1.6));
                                }
                                catch
                                {
                                    yuzhi = 100;
                                    yuzhi = (int)(yuzhi * ((float)(mnqRect.right - mnqRect.left) / 1920 * MainForm.ygdx / 1.6));
                                }
                                if ((GetAsyncKeyState(VK_RBUTTON) & 0x8000) != 0)
                                {
                                    mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                                    state = true;
                                    GetCursorPos(out mp1);

                                    while ((GetAsyncKeyState(VK_RBUTTON) & 0x8000) != 0)
                                    {
                                        Thread.Sleep(5);
                                    }
                                    mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                                    state = false;
                                }
                            }
                            Thread.Sleep(1);
                        }
                    }).Start();
                }
            }
            else
            {
                Json.writejson("kongqiukq", "false");
                UnhookWindowsHookEx(_hookID);
            }
        }

        static float readzhitiji(long adr)
        {
            int bytesread;
            IntPtr hProcess = MainForm.hProcess;
            byte[] data = new byte[4];
            ReadProcessMemory(hProcess, adr, data, 4u, out bytesread);
            return BitConverter.ToSingle(data, 0);
        }

        void tmyg()
        {
            List<long> addressygtm = Memory.ScanPatternParallel(MainForm.hProcess, MainForm.ygtmaob, MainForm.ygtmaob.Length);
            if (addressygtm.Count > 0)
            {
                foreach (long addr in addressygtm)
                {
                    long ygtmadr = addr + 20;
                    int byteswrite;
                    float value = 0.0f;
                    WriteProcessMemory(MainForm.hProcess, ygtmadr, BitConverter.GetBytes(value), 4u, out byteswrite);
                }
            }
        }

        private void textboxkongqiu_TextChanged(object sender, EventArgs e)
        {
            try { yuzhi = int.Parse(textboxkongqiu.Text); }
            catch { yuzhi = 100; }
            Json.writejson("youjiankongqiu", textboxkongqiu.Text);
        }

        private void textboxkongqiu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        public static int GetVirtualKeyCode(string keyString)
        {
            if (int.TryParse(keyString, out int keyCode)) return char.Parse(keyString);
            if (keyString == "Shift") return 0x10;
            if (keyString == "Ctrl") return 0x11;
            if (keyString == "Alt") return 0x12;
            if (keyString == "鼠标右键") return 0x02;
            if (keyString == "空格") return 0x20;
            if (keyString == "无" || keyString == "禁用") return 0x00;
            Keys key;
            if (Enum.TryParse(keyString, out key)) return (int)key;
            return 0;
        }

        private void textboxAiSplitCount_TextChanged(object sender, EventArgs e)
        {
            Json.writejson("aiSplitCount", textboxAiSplitCount.Text);
        }

        private void textboxAiSplitDelay_TextChanged(object sender, EventArgs e)
        {
            Json.writejson("aiSplitDelay", textboxAiSplitDelay.Text);
        }

        private void textboxNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void fuzhugongneng_Load(object sender, EventArgs e)
        {
            fuzhugongnengInstance = this;
                        if (Json.checkjson("youjiankongqiu")) textboxkongqiu.Text = Json.readjson("youjiankongqiu");
            else textboxkongqiu.Text = "100";

            if (Json.checkjson("kongqiukq") && Json.readjson("kongqiukq") == "true") checkboxkongqiu.Checked = true;
            if (Json.checkjson("suoqiu") && Json.readjson("suoqiu") == "true") checkboxsuoqiu.Checked = true;

            comboBoxtsuoqiu.SelectedItem = Json.checkjson("suoqiujian") ? Json.readjson("suoqiujian") : "A";
            comboMouseRank.SelectedItem = Json.checkjson("mouseRankKey") ? Json.readjson("mouseRankKey") : "无";
            comboAiLock.SelectedItem = Json.checkjson("aiLockKeyStr") ? Json.readjson("aiLockKeyStr") : "F";
            comboAiTrack.SelectedItem = Json.checkjson("aiTrackKeyStr") ? Json.readjson("aiTrackKeyStr") : "G";

            textboxAiSplitCount.Text = Json.checkjson("aiSplitCount") ? Json.readjson("aiSplitCount") : "30";
            textboxAiSplitDelay.Text = Json.checkjson("aiSplitDelay") ? Json.readjson("aiSplitDelay") : "0";


            aiLockKey = (byte)GetVirtualKeyCode(comboAiLock.SelectedItem?.ToString() ?? "F");
            aiTrackKey = (byte)GetVirtualKeyCode(comboAiTrack.SelectedItem?.ToString() ?? "G");
            mouseRankKey = (byte)GetVirtualKeyCode(comboMouseRank.SelectedItem?.ToString() ?? "无");

            if (Json.checkjson("ygtm") && Json.readjson("ygtm") == "true") checkboxygtm.Checked = true;

            bool syczj = true;
            new Thread(() =>
            {
                while (true)
                {
                    if (checkboxygtm.Checked)
                    {
                        if (MainForm.shifouzhanju == true && syczj == false) new Thread(tmyg).Start();
                        syczj = MainForm.shifouzhanju;
                    }

                    Thread.Sleep(10);
                }
            }).Start();


            new Thread(AiKeyMonitorLoop).Start();


        }

        private void comboBoxtsuoqiu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxtsuoqiu.SelectedItem != null) neicunheqiu.suoqiujian = GetVirtualKeyCode(comboBoxtsuoqiu.SelectedItem.ToString());
            Json.writejson("suoqiujian", comboBoxtsuoqiu.SelectedItem.ToString());
        }

        private void checkboxygtm_CheckedChanged(object sender, bool value)
        {
            if (value) { new Thread(tmyg).Start(); Json.writejson("ygtm", "true"); }
            else Json.writejson("ygtm", "false");
        }

        private void AiLog(string msg)
        {
            if (Application.OpenForms["MainForm"] is MainForm mainForm)
            {
                if (mainForm.InvokeRequired)
                {
                    mainForm.Invoke(new Action(() => mainForm.tishi.Text += msg));
                }
                else
                {
                    mainForm.tishi.Text += msg;
                }
            }
        }


        private void buttonInitElf_Click(object sender, EventArgs e)
        {
            buttonInitElf.Loading = true;
            new Thread(InitElfAndSearch).Start();
        }

        private void InitElfAndSearch()
        {
            try
            {
                if (!isElfInjected)
                {
                    AiLog("正在推送ELF到模拟器...\r\n");
                    Invoke(new Action(() => labelAiStatus.Text = "状态：正在释放资源并注入环境..."));

                    string tempDir = Path.Combine(Path.GetTempPath());
                    if (!Directory.Exists(tempDir)) Directory.CreateDirectory(tempDir);

                    string adbPath = Path.Combine(tempDir, "adb.exe");
                    string adbApi = Path.Combine(tempDir, "AdbWinApi.dll");
                    string adbUsbApi = Path.Combine(tempDir, "AdbWinUsbApi.dll");
                    string localElfPath = Path.Combine(tempDir, "mxelf");

                    File.WriteAllBytes(adbPath, Properties.Resources.adb);
                    File.WriteAllBytes(adbApi, Properties.Resources.AdbWinApi);
                    File.WriteAllBytes(adbUsbApi, Properties.Resources.AdbWinUsbApi);
                    File.WriteAllBytes(localElfPath, Properties.Resources.mxelf);

                    string remoteElfPath = "/data/local/tmp/mxelf";
                    string devicePort = MainForm.choose == "MuMu模拟器" ? "7555" : "5555";
                    string device = $"127.0.0.1:{devicePort}";

                    if (File.Exists(adbPath) && File.Exists(localElfPath))
                    {
                        string[] cmds = {
                            $"\"{adbPath}\" connect {device}",
                            $"\"{adbPath}\" -s {device} root",
                            $"\"{adbPath}\" -s {device} push \"{localElfPath}\" \"{remoteElfPath}\"",
                            $"\"{adbPath}\" -s {device} shell chmod 777 \"{remoteElfPath}\"",
                            $"\"{adbPath}\" -s {device} shell \"cd /data/local/tmp && ./mxelf\""
                        };
                        string joinedCmds = string.Join(" && ", cmds);

                        ProcessStartInfo psi = new ProcessStartInfo
                        {
                            FileName = "cmd.exe",
                            Arguments = $"/c chcp 65001 > nul && {joinedCmds}",
                            WindowStyle = ProcessWindowStyle.Hidden,
                            CreateNoWindow = true,
                            UseShellExecute = false
                        };
                        Process.Start(psi);
                        isElfInjected = true;
                    }
                    else
                    {
                        AiLog(" AI 搜索失败\r\n");
                        Invoke(new Action(() => { buttonInitElf.Loading = false; labelAiStatus.Text = "状态： AI 搜索失败"; }));
                        return;
                    }
                }

                Invoke(new Action(() => labelAiStatus.Text = "状态：正在搜索 AI 基址..."));
                AiLog("开始扫描 AI 共享内存与视图特征...\r\n");

                int maxRetries = 5;
                for (int i = 0; i < maxRetries; i++)
                {
                    if (i > 0) Thread.Sleep(1000);

                    List<long> aiList = Memory.ScanPatternParallel(MainForm.hProcess, aiFeature, aiFeature.Length);
                    if (aiList.Count > 0)
                    {
                        foreach (long addr in aiList)
                        {
                            long check_addr = addr - 10;
                            byte[] val1 = new byte[4];
                            int br;
                            API.ReadProcessMemory(MainForm.hProcess, check_addr, val1, 4u, out br);
                            Thread.Sleep(100);
                            byte[] val2 = new byte[4];
                            API.ReadProcessMemory(MainForm.hProcess, check_addr, val2, 4u, out br);

                            if (BitConverter.ToInt32(val1, 0) != BitConverter.ToInt32(val2, 0))
                            {
                                addr_ai_base = addr + 10;
                                AiLog("AI 基址搜索成功\r\n");
                                break;
                            }
                        }

                        if (addr_ai_base != 0)
                        {
                            byte[] zeroBytes = new byte[aiFeature.Length];
                            int bytesWritten;
                            foreach (long addr in aiList)
                            {
                                try
                                {
                                    API.WriteProcessMemory(MainForm.hProcess, addr, zeroBytes, (uint)zeroBytes.Length, out bytesWritten);
                                }
                                catch { }
                            }
                        }
                    }

                    if (addr_ai_base != 0) break;
                    else if (i < maxRetries - 1) AiLog($"等待 1 秒后进行第 {i + 2} 次重试...\r\n");
                }

                if (addr_ai_base == 0) AiLog(" AI 特征搜索失败\r\n");

                List<long> viewList = Memory.ScanPatternParallel(MainForm.hProcess, viewFeature, viewFeature.Length);
                if (viewList.Count > 0)
                {
                    foreach (long addr in viewList)
                    {
                        long candidate = addr - 0x8;
                        byte[] valBuf = new byte[4];
                        int br;
                        API.ReadProcessMemory(MainForm.hProcess, candidate, valBuf, 4u, out br);
                        if (BitConverter.ToSingle(valBuf, 0) != 0)
                        {
                            addr_view_range_feature = candidate;
                            break;
                        }
                    }
                }

                List<long> zsList = Memory.ScanPatternParallel(MainForm.hProcess, zsFeature, zsFeature.Length);
                if (zsList.Count > 0)
                {
                    zszuobiao = zsList[0] - 0x8;
                    AiLog("自身坐标搜索成功\r\n");
                }
                else AiLog("自身坐标搜索失败\r\n");

                if (addr_ai_base != 0 && zszuobiao != 0)
                {
                    AiLog("AI 基址全部搜索成功\r\n");
                    Invoke(new Action(() => labelAiStatus.Text = "状态：AI搜索成功"));
                }
                else
                {
                    AiLog("AI 基址搜索失败，请重试\r\n");
                    Invoke(new Action(() => labelAiStatus.Text = "状态：AI搜索失败"));
                }
            }
            catch (Exception ex)
            {
                AiLog($"初始化异常：搜索失败，请手动结束adb.exe进程\r\n");
            }
            finally
            {
                Invoke(new Action(() => buttonInitElf.Loading = false));
            }
        }

        private void comboAiLock_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboAiLock.SelectedItem != null)
            {
                aiLockKey = (byte)GetVirtualKeyCode(comboAiLock.SelectedItem.ToString());
                Json.writejson("aiLockKeyStr", comboAiLock.SelectedItem.ToString());
            }
        }

        private void comboAiTrack_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboAiTrack.SelectedItem != null)
            {
                aiTrackKey = (byte)GetVirtualKeyCode(comboAiTrack.SelectedItem.ToString());
                Json.writejson("aiTrackKeyStr", comboAiTrack.SelectedItem.ToString());
            }
        }

        private void comboMouseRank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboMouseRank.SelectedItem != null)
            {
                mouseRankKey = (byte)GetVirtualKeyCode(comboMouseRank.SelectedItem.ToString());
                Json.writejson("mouseRankKey", comboMouseRank.SelectedItem.ToString());
            }
        }

        private void checkboxAiLock_CheckedChanged(object sender, bool value)
        {
            isAiLockingActive = checkboxAiLock.Checked;
        }

        private void checkboxAiTrack_CheckedChanged(object sender, bool value)
        {
            isAiTrackingActive = checkboxAiTrack.Checked;
            if (!isAiTrackingActive && isAiTracking)
            {
                isAiTracking = false;
                InvokeHideTrackNotification();
            }
        }

        private void textboxTargetUid_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textboxTargetUid.Text, out int result))
            {
                targetUid = result;
                UpdateElfTargetRank(targetUid);
            }
        }

        private void UpdateElfTargetRank(int rank)
        {
            if (MainForm.hProcess != IntPtr.Zero && addr_ai_base != 0)
            {
                int bytesWrite;
                API.WriteProcessMemory(MainForm.hProcess, addr_ai_base, BitConverter.GetBytes(rank), 4u, out bytesWrite);
            }
        }

        private void StartAutoMatchMonitor()
        {
            if (!isAutoMatchMonitorActive)
            {
                isAutoMatchMonitorActive = true;
                autoMatchMonitorThread = new Thread(AutoMatchMonitorLoop);
                autoMatchMonitorThread.IsBackground = true;
                autoMatchMonitorThread.Start();
            }
        }

        private void StopAutoMatchMonitor()
        {
            isAutoMatchMonitorActive = false;
        }

        private static void AutoMatchMonitorLoop()
        {
            int zero_cnt = 0;
            bool ended = false;
            bool in_game = false;

            while (isAutoMatchMonitorActive)
            {
                if (MainForm.hProcess == IntPtr.Zero)
                {
                    Thread.Sleep(1000);
                    continue;
                }

                if (MainForm.qjdizhi == 0)
                {
                    List<long> qjList = Memory.ScanPatternParallel(MainForm.hProcess, MainForm.quanjuaob1, MainForm.quanjuaob1.Length);
                    if (qjList.Count > 0)
                    {
                        MainForm.qjdizhi = qjList[0];
                    }
                    else
                    {
                        Thread.Sleep(1000);
                        continue;
                    }
                }

                try
                {
                    long djpdAddress = MainForm.qjdizhi + 0x5C;
                    byte[] buffer = new byte[4];
                    int bytesRead;
                    API.ReadProcessMemory(MainForm.hProcess, djpdAddress, buffer, 4u, out bytesRead);
                    
                    if (bytesRead == 4)
                    {
                        int value = BitConverter.ToInt32(buffer, 0);
                        if (value == 0)
                        {
                            zero_cnt++;
                            if (zero_cnt >= 3)
                            {
                                if (in_game && !ended)
                                {
                                    ended = true;
                                    in_game = false;
                                }
                            }
                        }
                        else
                        {
                            zero_cnt = 0;
                            if (!in_game)
                            {
                                in_game = true;
                            }
                            if (ended)
                            {
                                ended = false;
                                Thread.Sleep(200);
                                FindAndApplyNearestBallRank();
                            }
                        }
                    }
                }
                catch { }

                Thread.Sleep(500);
            }
        }

        private static void FindAndApplyNearestBallRank()
        {
            if (MainForm.hProcess == IntPtr.Zero || zszuobiao == 0 || addr_ai_base == 0)
                return;

            try
            {
                byte[] zsBuffer = new byte[8];
                int bytesRead;
                API.ReadProcessMemory(MainForm.hProcess, zszuobiao, zsBuffer, 8u, out bytesRead);
                if (bytesRead < 8) return;
                float self_x = Math.Abs(BitConverter.ToSingle(zsBuffer, 0));
                float self_y = Math.Abs(BitConverter.ToSingle(zsBuffer, 4));

                long current_addr = addr_ai_base + 24;
                int struct_size = 16;
                int max_entities = 2560;
                byte[] largeBuffer = new byte[max_entities * struct_size];
                int totalBytesRead;
                API.ReadProcessMemory(MainForm.hProcess, current_addr, largeBuffer, (uint)largeBuffer.Length, out totalBytesRead);

                int nearest_rank = -1;
                double min_distance = double.MaxValue;

                for (int i = 0; i < max_entities; i++)
                {
                    int offset = i * struct_size;
                    if (offset + struct_size > totalBytesRead) break;
                    if (largeBuffer[offset] == 0xEE && largeBuffer[offset + 1] == 0xFF && largeBuffer[offset + 2] == 0xEE && largeBuffer[offset + 3] == 0xFF) break;

                    int rank = BitConverter.ToInt32(largeBuffer, offset);
                    float tx = BitConverter.ToSingle(largeBuffer, offset + 4);
                    float ty = BitConverter.ToSingle(largeBuffer, offset + 8);
                    float tr = BitConverter.ToSingle(largeBuffer, offset + 12);

                    if (tr > 0)
                    {
                        float calc_y = (float)(ty / 6.6 / (tx + 33.0) - 88.0);
                        double distance = Math.Sqrt(Math.Pow(tx - self_x, 2) + Math.Pow(calc_y - self_y, 2));
                        
                        if (distance > 0.8 && distance < min_distance)
                        {
                            min_distance = distance;
                            nearest_rank = rank;
                        }
                    }
                }

                if (nearest_rank != -1)
                {
                    targetUid = nearest_rank;
                    if (fuzhugongnengInstance != null)
                    {
                        fuzhugongnengInstance.UpdateElfTargetRank(nearest_rank);
                        if (fuzhugongnengInstance.IsHandleCreated)
                        {
                            fuzhugongnengInstance.Invoke(new Action(() => {
                                fuzhugongnengInstance.textboxTargetUid.Text = nearest_rank.ToString();
                            }));
                        }
                    }
                }
            }
            catch { }
        }

        private void ShowHuizhiOverlay()
        {
            if (huizhiOverlayForm == null || huizhiOverlayForm.IsDisposed)
            {
                huizhiOverlayForm = new HuizhiForm();
                huizhiOverlayForm.FormBorderStyle = FormBorderStyle.None;
                huizhiOverlayForm.BackColor = Color.Snow;
                huizhiOverlayForm.TransparencyKey = Color.Snow;
                huizhiOverlayForm.TopMost = true;
                huizhiOverlayForm.ShowInTaskbar = false;
                huizhiOverlayForm.StartPosition = FormStartPosition.Manual;
                huizhiOverlayForm.Bounds = Screen.PrimaryScreen.Bounds;

                // Make the form click-through (WS_EX_TRANSPARENT | WS_EX_LAYERED)
                int exStyle = GetWindowLong(huizhiOverlayForm.Handle, -20); // GWL_EXSTYLE
                SetWindowLong(huizhiOverlayForm.Handle, -20, exStyle | 0x80000 | 0x20); // WS_EX_LAYERED | WS_EX_TRANSPARENT
                
                huizhiOverlayForm.Paint += HuizhiOverlayForm_Paint;
            }

            if (!huizhiOverlayForm.Visible)
            {
                huizhiOverlayForm.Show();
            }

            if (!isDrawingActive)
            {
                isDrawingActive = true;
                drawingThread = new Thread(DrawingLoop);
                drawingThread.IsBackground = true;
                drawingThread.Start();
            }
        }

        private void HideHuizhiOverlay()
        {
            isDrawingActive = false;
            if (huizhiOverlayForm != null && !huizhiOverlayForm.IsDisposed && huizhiOverlayForm.Visible)
            {
                if (huizhiOverlayForm.InvokeRequired)
                {
                    huizhiOverlayForm.Invoke(new Action(() => huizhiOverlayForm.Hide()));
                }
                else
                {
                    huizhiOverlayForm.Hide();
                }
            }
        }

        private static void DrawingLoop()
        {
            while (isDrawingActive)
            {
                try
                {
                    IntPtr fgWnd = GetForegroundWindow();
                    IntPtr emuWnd = FindWindow(MainForm.lp, null);
                    bool isForeground = (fgWnd == emuWnd || (huizhiOverlayForm != null && fgWnd == huizhiOverlayForm.Handle));

                    if (isForeground && addr_ai_base != 0 && zszuobiao != 0 && MainForm.shiye != 0)
                    {
                        DrawState newState = new DrawState();
                        newState.isForeground = true;
                        newState.allEntities = new List<DrawTargetInfo>();

                        byte[] zsBuffer = new byte[8];
                        int bytesRead;
                        API.ReadProcessMemory(MainForm.hProcess, zszuobiao, zsBuffer, 8u, out bytesRead);
                        newState.self_x = BitConverter.ToSingle(zsBuffer, 0);
                        newState.self_y = BitConverter.ToSingle(zsBuffer, 4);

                        byte[] syBuffer = new byte[4];
                        API.ReadProcessMemory(MainForm.hProcess, MainForm.shiye, syBuffer, 4u, out bytesRead);
                        float sy_val = BitConverter.ToSingle(syBuffer, 0);
                        newState.syzhi = sy_val > 0 ? (float)Math.Sqrt(sy_val) : 1.0f;

                        newState.view_range = 1.0f;
                        if (addr_view_range_feature != 0)
                        {
                            byte[] vrBuffer = new byte[4];
                            API.ReadProcessMemory(MainForm.hProcess, addr_view_range_feature, vrBuffer, 4u, out bytesRead);
                            float vr_val = BitConverter.ToSingle(vrBuffer, 0);
                            if (vr_val > 0.1f) newState.view_range = vr_val;
                        }

                        TargetData directTarget = GetDirectTargetData();
                        if (directTarget.radius > 0)
                        {
                            newState.directTarget = new DrawTargetInfo
                            {
                                x = directTarget.x,
                                y = directTarget.y,
                                radius = directTarget.radius,
                                rank = targetUid
                            };
                        }

                        long current_addr = addr_ai_base + 24;
                        int struct_size = 16;
                        int max_entities = 2560;
                        byte[] largeBuffer = new byte[max_entities * struct_size];
                        int totalBytesRead;
                        API.ReadProcessMemory(MainForm.hProcess, current_addr, largeBuffer, (uint)largeBuffer.Length, out totalBytesRead);

                        for (int i = 0; i < max_entities; i++)
                        {
                            int offset = i * struct_size;
                            if (offset + struct_size > totalBytesRead) break;
                            if (largeBuffer[offset] == 0xEE && largeBuffer[offset + 1] == 0xFF && largeBuffer[offset + 2] == 0xEE && largeBuffer[offset + 3] == 0xFF) break;

                            int rank = BitConverter.ToInt32(largeBuffer, offset);
                            float tx = BitConverter.ToSingle(largeBuffer, offset + 4);
                            float ty = BitConverter.ToSingle(largeBuffer, offset + 8);
                            float tr = BitConverter.ToSingle(largeBuffer, offset + 12);

                            if (tr > 0)
                            {
                                newState.allEntities.Add(new DrawTargetInfo { x = tx, y = ty, radius = tr, rank = rank });

                                if (directTarget.radius > 0 && Math.Abs(tx - directTarget.x) < 0.01f && Math.Abs(ty - directTarget.y) < 0.01f && Math.Abs(tr - directTarget.radius) < 0.01f)
                                {
                                    newState.directTarget.rank = rank;
                                }
                            }
                        }

                        GetWindowRect(emuWnd, out newState.emulatorRect);

                        int offset_y = 0;
                        if (fuzhugongnengInstance != null && fuzhugongnengInstance.IsHandleCreated)
                        {
                            try
                            {
                                fuzhugongnengInstance.Invoke(new Action(() => {
                                    int.TryParse(fuzhugongnengInstance.uiTextBox1huizhigaodupianyi.Text, out offset_y);
                                }));
                            }
                            catch { }
                        }
                        newState.offset_y = offset_y;

                        lock (drawLock)
                        {
                            currentDrawState = newState;
                        }

                        if (huizhiOverlayForm != null)
                        {
                            if (!huizhiOverlayForm.Visible)
                            {
                                huizhiOverlayForm.Invoke(new Action(() => huizhiOverlayForm.Show()));
                            }
                            huizhiOverlayForm.Invalidate();
                        }
                    }
                    else
                    {
                        if (huizhiOverlayForm != null && huizhiOverlayForm.Visible)
                        {
                            huizhiOverlayForm.Invoke(new Action(() => huizhiOverlayForm.Hide()));
                        }
                    }
                }
                catch { }

                Thread.Sleep(2);
            }
        }

        private static void HuizhiOverlayForm_Paint(object sender, PaintEventArgs e)
        {
            DrawState state;
            lock (drawLock)
            {
                state = currentDrawState;
            }

            if (!state.isForeground) return;

            int emuWidth = state.emulatorRect.right - state.emulatorRect.left;
            int emuHeight = state.emulatorRect.bottom - state.emulatorRect.top;
            if (emuWidth <= 0 || emuHeight <= 0) return;

            int center_x = state.emulatorRect.left + emuWidth / 2;
            int center_y = state.emulatorRect.top + emuHeight / 2 + state.offset_y;
            int screen_radius = (emuHeight / 2) - state.offset_y;
            float scale = (float)screen_radius / state.view_range;

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Color colorTargetOutline = Color.FromArgb(200, 255, 0, 0);
            Color colorTargetText = Color.FromArgb(200, 0, 0, 255);
            Color colorCenterDot = Color.FromArgb(200, 0, 255, 0);
            Color colorAllRanks = Color.FromArgb(200, 255, 0, 0);

            using (Brush brushCenter = new SolidBrush(colorCenterDot))
            {
                g.FillEllipse(brushCenter, center_x - 3, center_y - 3, 6, 6);
            }

            if (state.directTarget.radius > 0)
            {
                float tx = state.directTarget.x;
                float ty = state.directTarget.y;
                float tr = state.directTarget.radius;

                float calc_y = (float)(ty / 6.6 / (tx + 33) - 88);
                float dx = tx + state.self_x;
                float dy = calc_y + state.self_y;

                float sx = center_x + (dx * scale);
                float sy = center_y - (dy * scale);

                float target_radius_px = tr * scale;

                using (Pen penTarget = new Pen(colorTargetOutline, 2f))
                {
                    g.DrawEllipse(penTarget, sx - target_radius_px, sy - target_radius_px, target_radius_px * 2, target_radius_px * 2);
                }

                using (Pen penCross = new Pen(Color.FromArgb(220, 0, 255, 0), 2f))
                {
                    float cross_len = target_radius_px * 0.8f;
                    g.DrawLine(penCross, sx - cross_len, sy, sx + cross_len, sy);
                    g.DrawLine(penCross, sx, sy - cross_len, sx, sy + cross_len);
                }

                using (Font font = new Font("Arial", 20f, FontStyle.Bold))
                using (Brush brushText = new SolidBrush(colorTargetText))
                {
                    string text = state.directTarget.rank.ToString();
                    SizeF size = g.MeasureString(text, font);
                    g.DrawString(text, font, brushText, sx - size.Width / 2, sy - size.Height / 2);
                }
            }

            using (Font font = new Font("Arial", 20f, FontStyle.Bold))
            using (Brush brushText = new SolidBrush(colorAllRanks))
            {
                foreach (var entity in state.allEntities)
                {
                    if (state.directTarget.radius > 0 &&
                        Math.Abs(entity.x - state.directTarget.x) < 0.01f &&
                        Math.Abs(entity.y - state.directTarget.y) < 0.01f &&
                        Math.Abs(entity.radius - state.directTarget.radius) < 0.01f)
                    {
                        continue;
                    }

                    float tx = entity.x;
                    float ty = entity.y;

                    float calc_y = (float)(ty / 6.6 / (tx + 33) - 88);
                    float dx = tx + state.self_x;
                    float dy = calc_y + state.self_y;

                    float sx = center_x + (dx * scale);
                    float sy = center_y - (dy * scale);

                    string text = entity.rank.ToString();
                    SizeF size = g.MeasureString(text, font);
                    g.DrawString(text, font, brushText, sx - size.Width / 2, sy - size.Height / 2);
                }
            }
        }

        public static TargetData GetDirectTargetData()
        {
            TargetData data = new TargetData { radius = -1f };
            if (addr_ai_base == 0) return data;

            byte[] buffer = new byte[20];
            int bytesRead;
            API.ReadProcessMemory(MainForm.hProcess, addr_ai_base + 4, buffer, 20u, out bytesRead);

            if (bytesRead == 20)
            {
                data.x = BitConverter.ToSingle(buffer, 0);
                data.y = BitConverter.ToSingle(buffer, 4);
                data.radius = BitConverter.ToSingle(buffer, 8);
                data.dir_x = BitConverter.ToSingle(buffer, 12);
                data.dir_y = BitConverter.ToSingle(buffer, 16);
            }
            return data;
        }

        private void AiKeyMonitorLoop()
        {
            bool lockPressedLast = false;
            bool trackPressedLast = false;
            bool mouseRankPressedLast = false;

            while (true)
            {
                if (API.GetForegroundWindow() == API.FindWindow(MainForm.lp, null) && MainForm.shifouzhanju == true)
                {
                    if (isAiLockingActive)
                    {
                        bool isLockDown = (GetAsyncKeyState(aiLockKey) & 0x8000) != 0;
                        if (isLockDown && !lockPressedLast)
                        {
                            StartAiLocking();
                        }
                        else if (!isLockDown && lockPressedLast)
                        {
                            StopAiLocking();
                        }
                        lockPressedLast = isLockDown;
                    }


                    if (isAiTrackingActive)
                    {
                        bool isTrackDown = (GetAsyncKeyState(aiTrackKey) & 0x8000) != 0;
                        if (isTrackDown && !trackPressedLast)
                        {
                            if (!isAiTracking)
                            {
                                isAiTracking = true;
                                new Thread(AiTrackingLoop).Start();
                                AiLog("AI大炮追踪已开启\r\n");
                                InvokeShowTrackNotification();
                            }
                            else
                            {
                                isAiTracking = false;
                                AiLog("AI大炮追踪已停止\r\n");
                                InvokeHideTrackNotification();
                            }
                        }
                        trackPressedLast = isTrackDown;
                    }


                    if (mouseRankKey != 0)
                    {
                        bool isMouseRankDown = (GetAsyncKeyState(mouseRankKey) & 0x8000) != 0;
                        if (isMouseRankDown && !mouseRankPressedLast)
                        {
                            FindRankUnderMouse();
                        }
                        mouseRankPressedLast = isMouseRankDown;
                    }
                }
                Thread.Sleep(1);//修改的地方要么0-10
            }
        }

        //suoqiu        
        // =========================================================================
        private void StartAiLocking()
        {
            if (!isLocking)
            {
                isLocking = true;

                string tuqiuKeyStr = Json.checkjson("tuqiujian") ? Json.readjson("tuqiujian") : "A";
                byte tuqiuKey = (byte)GetVirtualKeyCode(tuqiuKeyStr);

                uint scancode = MapVirtualKeyW(tuqiuKey, 0);
                keybd_event(tuqiuKey, (byte)scancode, 0, 0);

                new Thread(CalculateDirectionLoop).Start();
            }
        }

        private void StopAiLocking()
        {
            if (isLocking)
            {
                isLocking = false;

                string tuqiuKeyStr = Json.checkjson("tuqiujian") ? Json.readjson("tuqiujian") : "A";
                byte tuqiuKey = (byte)GetVirtualKeyCode(tuqiuKeyStr);

                uint scancode = MapVirtualKeyW(tuqiuKey, 0);
                keybd_event(tuqiuKey, (byte)scancode, KEYEVENTF_KEYUP, 0);
            }
        }

        private void CalculateDirectionLoop()
        {
            while (isLocking)
            {
                if (addr_ai_base != 0 && zszuobiao != 0 && MainForm.yaoganadr != 0)
                {
                    try
                    {
                        TargetData target = GetDirectTargetData();

                        byte[] zsBuffer = new byte[8];
                        int bytesRead;
                        API.ReadProcessMemory(MainForm.hProcess, zszuobiao, zsBuffer, 8u, out bytesRead);
                        float self_x = BitConverter.ToSingle(zsBuffer, 0);
                        float self_y = BitConverter.ToSingle(zsBuffer, 4);

                        byte[] syBuffer = new byte[4];
                        API.ReadProcessMemory(MainForm.hProcess, MainForm.shiye, syBuffer, 4u, out bytesRead);
                        float sy_val = BitConverter.ToSingle(syBuffer, 0);
                        float syzhi = sy_val > 0 ? (float)Math.Sqrt(sy_val) : 1.0f;

                        float view_range = 1.0f;
                        if (addr_view_range_feature != 0)
                        {
                            byte[] vrBuffer = new byte[4];
                            API.ReadProcessMemory(MainForm.hProcess, addr_view_range_feature, vrBuffer, 4u, out bytesRead);
                            float vr_val = BitConverter.ToSingle(vrBuffer, 0);
                            if (vr_val > 0.1f) view_range = vr_val;
                        }

                        if (target.radius > 0)
                        {
                            float target_x = target.x;
                            float target_y = target.y;
                            float dir_x = target.dir_x;
                            float dir_y = target.dir_y;

                            if (Math.Abs(dir_x) > 50.0f || Math.Abs(dir_y) > 50.0f)
                            {
                                target_x = dir_x;
                                target_y = dir_y;
                            }
                            else
                            {
                                target_y = (float)(target_y / 6.6 / (target_x + 33) - 88);
                                if (isAiTracking)
                                {
                                    float lead_factor = 18.0f;
                                    target_x += dir_x * lead_factor;
                                    target_y += dir_y * lead_factor;
                                }
                            }

                            float delta_x = target_x + self_x;
                            float delta_y = target_y + self_y;
                            float final_x = delta_x / view_range * syzhi;
                            float final_y = delta_y / view_range * syzhi;

                            int bytesWrite;
                            API.WriteProcessMemory(MainForm.hProcess, MainForm.yaoganadr, BitConverter.GetBytes(final_x), 4u, out bytesWrite);
                            API.WriteProcessMemory(MainForm.hProcess, MainForm.yaoganadr + 4, BitConverter.GetBytes(final_y), 4u, out bytesWrite);
                        }
                    }
                    catch { }
                }
                Thread.Sleep(1);
            }
        }
        // dapao                    
        private void AiTrackingLoop()
        {
            float prev_rad = -1.0f;
            int invalidCount = 0;

            while (isAiTracking)
            {
                if (addr_ai_base == 0)
                {
                    Thread.Sleep(100);
                    continue;
                }

                try
                {
                    TargetData target = GetDirectTargetData();

                    if (target.radius > 0)
                    {
                        invalidCount = 0;
                        float curr_rad = target.radius;
                        if (prev_rad == -1.0f)
                        {
                            prev_rad = curr_rad;
                        }
                        else
                        {
                            if (prev_rad > 0.1f)
                            {
                                float ratio = curr_rad / prev_rad;
                                float kr = prev_rad - curr_rad;

                                if (ratio < 0.95f || kr > 1f)//0.95f的我改成0.97
                                {
                                    bool wasLocking = isLocking;
                                    if (!isLocking) StartAiLocking();

                                    Thread.Sleep(1);//要么0-10

                                    int splitCount = 30;
                                    int splitDelay = 0;
                                    try { splitCount = int.Parse(textboxAiSplitCount.Text); } catch { }
                                    try { splitDelay = int.Parse(textboxAiSplitDelay.Text); } catch { }

                                    string fsKeyStr = Json.checkjson("fenshenjian") ? Json.readjson("fenshenjian") : "空格";
                                    byte splitKey = (byte)GetVirtualKeyCode(fsKeyStr);
                                    uint scancode = MapVirtualKeyW(splitKey, 0);

                                    for (int i = 0; i < splitCount; i++)
                                    {
                                        keybd_event(splitKey, (byte)scancode, 0, 0);
                                        Thread.Sleep(5);
                                        keybd_event(splitKey, (byte)scancode, KEYEVENTF_KEYUP, 0);

                                        if (i < splitCount - 1)
                                        {
                                            Thread.Sleep(splitDelay);
                                        }
                                    }

                                    if (!wasLocking) StopAiLocking();

                                    isAiTracking = false;
                                    AiLog($"已触发AI大炮\r\n");
                                    InvokeHideTrackNotification();
                                    break;
                                }
                            }
                            prev_rad = curr_rad;
                        }
                    }
                    else
                    {
                        invalidCount++;
                        if (invalidCount > 15)
                        {
                            prev_rad = -1.0f;
                        }
                    }
                }
                catch { }

                Thread.Sleep(1);
            }
        }


        //sbpm
        // =========================================================================
        private void FindRankUnderMouse()
        {
            try
            {
                if (MainForm.hProcess == IntPtr.Zero || zszuobiao == 0 || MainForm.shiye == 0 || addr_ai_base == 0)
                    return;
                Struct.RECT rect = new Struct.RECT();
                bool windowFound = false;
                IntPtr hwnd = API.FindWindow(MainForm.lp, null);
                if (hwnd != IntPtr.Zero)
                {
                    GetWindowRect(hwnd, out rect);
                    windowFound = true;
                }

                if (!windowFound) return;
                Struct.POINT pt;
                if (!GetCursorPos(out pt)) return;

                int mx = pt.X;
                int my = pt.Y;

                if (mx < rect.left || mx > rect.right || my < rect.top || my > rect.bottom) return;
                int w = rect.right - rect.left;
                int h = rect.bottom - rect.top;

                int offset_y_val = 0;
                try
                {
                    if (Json.checkjson("offset_y"))
                    {
                        offset_y_val = int.Parse(Json.readjson("offset_y"));
                    }
                }
                catch { }

                int center_x = rect.left + w / 2;
                int center_y = rect.top + h / 2 + offset_y_val;
                int screen_radius = (h / 2) - offset_y_val;

                byte[] zsBuffer = new byte[8];
                int bytesRead;
                API.ReadProcessMemory(MainForm.hProcess, zszuobiao, zsBuffer, 8u, out bytesRead);
                float self_x = BitConverter.ToSingle(zsBuffer, 0);
                float self_y = BitConverter.ToSingle(zsBuffer, 4);
                float view_range = 1.0f;
                if (addr_view_range_feature != 0)
                {
                    byte[] vrBuffer = new byte[4];
                    API.ReadProcessMemory(MainForm.hProcess, addr_view_range_feature, vrBuffer, 4u, out bytesRead);
                    float vr_val = BitConverter.ToSingle(vrBuffer, 0);
                    if (vr_val > 0.1f) view_range = vr_val;
                }
                float scale = (float)screen_radius / view_range;
                long current_addr = addr_ai_base + 24;
                int struct_size = 16;
                int max_entities = 2560;
                byte[] largeBuffer = new byte[max_entities * struct_size];
                int totalBytesRead;
                API.ReadProcessMemory(MainForm.hProcess, current_addr, largeBuffer, (uint)largeBuffer.Length, out totalBytesRead);

                int foundRank = -1;
                double min_dist_sq = double.MaxValue;

                for (int i = 0; i < max_entities; i++)
                {
                    int offset = i * struct_size;
                    if (offset + struct_size > totalBytesRead) break;
                    if (largeBuffer[offset] == 0xEE && largeBuffer[offset + 1] == 0xFF && largeBuffer[offset + 2] == 0xEE && largeBuffer[offset + 3] == 0xFF) break;

                    int rank = BitConverter.ToInt32(largeBuffer, offset);
                    float tx = BitConverter.ToSingle(largeBuffer, offset + 4);
                    float ty = BitConverter.ToSingle(largeBuffer, offset + 8);
                    float tr = BitConverter.ToSingle(largeBuffer, offset + 12);

                    if (tr > 0)
                    {
                        float calc_y = (float)(ty / 6.6 / (tx + 33) - 88);
                        float dx = tx + self_x;
                        float dy = calc_y + self_y;

                        float sx = center_x + (dx * scale);
                        float sy = center_y - (dy * scale);

                        double dist_sq = Math.Pow(sx - mx, 2) + Math.Pow(sy - my, 2);
                        float radius_px = tr * scale;
                        if (radius_px < 5) radius_px = 5;

                        if (dist_sq < (radius_px * radius_px))
                        {
                            if (dist_sq < min_dist_sq)
                            {
                                min_dist_sq = dist_sq;
                                foundRank = rank;
                            }
                        }
                    }
                }

                if (foundRank != -1)
                {
                    targetUid = foundRank;
                    UpdateElfTargetRank(foundRank);

                    if (this.IsHandleCreated)
                    {
                        Invoke(new Action(() => textboxTargetUid.Text = foundRank.ToString()));
                    }
                    AiLog($"已成功获取并锁定鼠标位置队友排名: {foundRank}\r\n");
                    InvokeShowRankNotification(foundRank);
                }
            }
            catch (Exception ex)
            {
                AiLog($"获取鼠标排名失败: {ex.Message}\r\n");
            }
        }

        
    }

    public class HuizhiForm : Form
    {
        public HuizhiForm()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
        }
    }
}

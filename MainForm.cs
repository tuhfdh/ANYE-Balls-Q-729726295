using AntdUI;//修改好的
using Newtonsoft.Json.Linq;
using System.CodeDom;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;
using Vanara.PInvoke;
using static ReaLTaiizor.Manager.MaterialSkinManager;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using static ANYE_Balls.API;
using System;
using Sunny.UI;
using System.Net.Sockets;
using System.Net;
using System.Globalization;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http; // 新增：用于热更新下载

namespace ANYE_Balls
{
    public partial class MainForm : Form
    {
        public const string CurrentAppVersion = "6.0.5";//必须修改版本号
        public static bool gy = false;


        //特征码
        //
        //
        public static byte[] quanjuaob1 = { 0xD8, 0x00, 0x00, 0x00, 0x63, 0x04, 0x00, 0x00 };//D8 00 00 00 63 04 00 00
        public static byte[] biansuaob = { 0x00, 0x00, 0x80, 0x3F, 0xAB, 0xAA, 0xAA, 0x3E, 0x8F, 0xC2, 0xF5 };//00 00 80 3F AB AA AA 3E 8F C2 F5
        //public static byte[] nianheaob = { 0x2B, 0x87, 0x16, 0x3F, 0x8F, 0x02, 0x01, 0x00, 0x04, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00 };
        //public static byte[] nianheaob = { 0x80, 0x3F, 0xCD, 0xCC, 0xCC, 0x3E, 0xCD, 0xCC, 0xFC, 0x40, 0xCD, 0xCC, 0xFC, 0x40, 0x00, 0x00, 0x80, 0x3F };////粘合1   
        public static byte[] nianheaob = { 0x02, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xB0, 0x00, 0x02, 0x00, 0x02, 0x00, 0x03, 0x00 };//02 00 00 00 04 00 00 00 00 00 00 00 B0 00 02 00 02 00 03 00
        public static byte[] tuqiuaob = { 0xA6, 0x00, 0x03, 0x00, 0x03, 0x00, 0x04, 0x00, 0x7B, 0x02, 0x02, 0x00, 0x38, 0x04, 0x03, 0x00,
    0x30, 0x01, 0x02, 0x00, 0x02, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
    0x05, 0x00, 0x03, 0x00, 0x01, 0x00, 0x00, 0x00, 0x2F, 0x01, 0x02, 0x00, 0x05 };
        public static byte[] yaoganyanchiaob = { 0x0A, 0xD7, 0xA3, 0x3C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x48, 0x42 };//0A D7 A3 3C 00 00 00 00 00 00 48 42
        public static byte[] yaoganjiexianaob = { 0x36, 0x00, 0x04, 0x00, 0x04, 0x00, 0x00, 0x00, 0x16, 0x00, 0x05, 0x00, 0x0A, 0xD7, 0x23, 0x3C };//36 00 04 00 04 00 00 00 16 00 05 00 0A D7 23 3C      2C 00 04 00 04 00 00 00 0C 00 05 00 0A D7 23 3C              
        public static byte[] yaoganhuitanaob = { 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x20, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x01, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x80, 0x3F, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x40 }; //01 00 00 00 00 00 00 00 20 00 00 00 00 00 01 01 00 00 01 00 00 00 80 3F 00 00 00 00 00 00 80 40
        public static byte[] ncdxaob = { 0x26, 0x00, 0x00, 0x00, 0x28, 0x00, 0x00, 0x00, 0x16, 0x00, 0x0F, 0x00, 0x00, 0x00, 0xF0, 0x3F, 0x38, 0x01, 0x0D, 0x00, 0x27, 0x00, 0x00, 0x00, 0x26, 0x00, 0x00, 0x00, 0x29, 0x00 };
        public static byte[] yaogan10000aob = { 0x88, 0x56, 0x64, 0x20, 0xAF, 0xD5, 0x08 };//已修改成21亿遥感  88 56 64 20 AF D5 08
        public static byte[] ygtmaob = { 0x61, 0x0B, 0x36, 0x3C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };//摇杆透明 61 0B 36 3C 00 00 00 00 00 00 00 00 00 00 00 00
        public static byte[] ycghaob = { 0x00, 0x00, 0x80, 0x3F, 0x9D, 0x02, 0x03, 0x00, 0x08, 0x00, 0x00, 0x00 };//隐藏光环
        public static byte[] fsjsaob = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x48, 0xAF, 0xBC, 0x9A };//00 00 00 00 00 48 AF BC 9A
        public static byte[] fenshenjiexianaob = { 0xC2, 0xF5, 0x3D, 0x0D, 0x00, 0x04, 0x00, 0x06, 0x00, 0x00 };//C2 F5 3D 0D 00 04 00 06 00 00  
        public static byte[] dljdaob = { 0x10, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x0C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x0C };//10 00 00 00 00 00 00 00 80 0C 00 00 00 00 00 00 80 0C -122
        public static byte[] zhuyechapaiaob = { 0xA0, 0x40, 0xFF, 0xC9, 0x9A, 0x3B }; //A0 40 FF C9 9A 3B
        public static string neicuntuqiuaoPattern = "CD CC 4C 3D B0 00 03 00 03 00 04 00 89 02 02 00 ?? 04 03 00 9F 02 02 00 06";//sm
        public static byte[] guotanchuangaob = { 0xCB, 0x6B, 0xAB, 0x3B, 0xF1, 0x45, 0x9D, 0x1F, 0xAB, 0x58, 0xFA, 0xAC, 0x93, 0x03, 0xE3, 0x4B, 0x55, 0xFA, 0x30, 0x20, 0xF6, 0x6D, 0x76, 0xAD, 0x91, 0x76, 0xCC, 0x88, 0x25, 0x4C, 0x02, 0xF5, 0xFC, 0xD7, 0xE5, 0x4F, 0xD7, 0xCB, 0x2A, 0xC5 };//CB 6B AB 3B F1 45 9D 1F AB 58 FA AC 93 03 E3 4B 55 FA 30 20 F6 6D 76 AD 91 76 CC 88 25 4C 02 F5 FC D7 E5 4F D7 CB 2A C5
        //public static byte[] leidianneicuntuqiuao = { 0xCD, 0xCC, 0x4C, 0x3D, 0xB0, 0x00, 0x03, 0x00, 0x03, 0x00, 0x04, 0x00, 0x89, 0x02, 0x02, 0x00, 0xF0, 0x02, 0x03, 0x00, 0x9D, 0x02, 0x02, 0x00, 0x06 };//CD CC 4C 3D B0 00 03 00 03 00 04 00 89 02 02 00 F0 02 03 00 9D 02 02 00 06                                                                                                                                                                                                                                                                            //
        public static string leidianneicuntuqiuaoPattern = "CD CC 4C 3D B0 00 03 00 03 00 04 00 89 02 02 00 F0 02 03 00 9D 02 02 00 06";                                                                                   //
        public static string yaoganxiangyinsuduaob = "38 00 00 00 ?? 00 25 00 00 00 00 00 00 00 00 00";
        //AI相关特征码
        public static byte[] aiFeature = { 0x01, 0x03, 0x05, 0x07, 0x09, 0x10, 0xAA, 0xBB, 0xCC, 0xDD };
        // 视图特征：00 00 48 44 FF FF FF FF
        public static byte[] viewFeature = { 0x00, 0x00, 0x48, 0x44, 0xFF, 0xFF, 0xFF, 0xFF };
        // 自身坐标特征 (这个比较长，按之前 Python 的解析截取前 16 位匹配，或者根据你 C# 实际需要)
        public static byte[] zsFeature = { 0x00, 0x80, 0x3B, 0x44, 0x00, 0x00, 0x80, 0x3F, 0x00, 0x00, 0x80, 0x3F, 0x00, 0x00, 0x00, 0x00 };

        // 记录 ADB 注入与基址
        public static bool isElfInjected = false;  // 防止重复推包
        public static long addr_ai_base;           // AI共享内存首地址
        public static long addr_view_range_feature;// 视图特征地址
        public static long zszuobiao;              // 自身坐标首地址
        public static long ygfangxiang;            // 摇杆方向指向 (就是 yaoganadr)

        // 用户设置的 AI 锁定与追踪按键 (可以在界面加载时绑定)
        public static byte suoqiujian;
        public static byte zhuizongjian;


        //全局内存地址变量 
        public static long fsjs;
        public static long ycgh;
        public static long juneiqupi;
        public static long kaishi;
        public static long jieshu;
        public static long shiye;
        public static long nianhe;
        public static long tuqiu;
        public static long yaoganyanchi;
        public static long yaoganrongcha;
        public static long yaoganjiexian;
        public static long biansu;
        public static long yaogan10000;
        public static long yaoganxiangyinsudu;
        public static long yaoganjiasu;
        public static long yaoganhuitan;
        public static long nichengdaxiao;
        public static long yaoganadr;
        public static long nctqadr;
        public static long tiji;
        public static float ygdx;
        public static long yaoganjiexian1;
        public static long chaojiyaogan;
        public static long chaojijiefenshen;
        public static long chaojijietuqiu;
        public static long fenshenjiexian;
        public static long zhuyechapai;
        public static long neicuntuqiu;
        public static long guotanchuang;
        public static long tqdld;//单连点
        public static long qjdizhi;
        //
        public static float duiyouX, duiyouY;

        public static long yaoganchuoadr;
        public static long ncygjsx;
        public static long ncygjsy;
        public static long xmin;
        public static long xmax;
        public static long ymin;
        public static long ymax;
        public static long selfsize;
        public static long shiyefanwei;
        public static float suodingX, suodingY;
        public static bool xiuZhength;
        public static long zhanjuzhi;
        public static long ncyaoganadr;


        //Json文件路径
        public static string filePath = @"C:\anyedata.json";

        //全局变量
        public static IntPtr pid;
        public static IntPtr hProcess;
        public static string choose = "";
        public static string ck = "";
        public static string lp = "";
        public static IntPtr hWnd;
        public static IntPtr hWndmsg;
        public static bool chushihuaflag = false;
        public static float DPI;
        public static bool shifouzhanju;
        public static string daoqishijian;
        public static string account;

        //子窗口对象
        List<Form> cks = new List<Form>();
        // 初始化按钮拆分相关标记
        private static bool baseAddrsFound = false;
        private static bool biansuAddrFound = false;


        private void ScaleFonts(Control.ControlCollection controls, float scalingFactor)
        {
            foreach (Control control in controls)
            {


                if (control is UITextBox)
                {
                    control.Font = new Font(control.Font.FontFamily, control.Font.Size * (1.0f / scalingFactor) * scalingFactor, control.Font.Style);
                }
                else
                {
                    control.Font = new Font(control.Font.FontFamily, control.Font.Size * (1.0f / scalingFactor), control.Font.Style);
                }
                // 递归处理子控件
                if (control.Controls.Count > 0)
                {
                    ScaleFonts(control.Controls, scalingFactor);
                }
            }
        }
        public MainForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            cks.Add(new neicungongneng());
            cks.Add(new fuzhugongneng());
            cks.Add(new ncsanjiao1());
            cks.Add(new ncsanjiao2());
            cks.Add(new ncsifencehe());
            cks.Add(new nczhongfencehe());
            cks.Add(new nchouyangcehe());
            cks.Add(new ncbanxuan());
            cks.Add(new ncxuanzhuan());
            cks.Add(new ncsheshou());
            cks.Add(new heipingkadian());
            cks.Add(new honggongneng());
            cks.Add(new pifugongneng());
            
            Control.CheckForIllegalCrossThreadCalls = false;
            buttondiyibu.Enabled = false;
            buttonshiyeneicung.Enabled = false;
            buttonyaoganfenshen.Enabled = false;
            this.AutoScaleMode = AutoScaleMode.Dpi;
            // 获取当前显示器的 DPI
            float dpi = GetDpiForCurrentWindow();
            // 计算缩放百分比
            float scalingFactor = dpi / 96.0f;
            DPI = scalingFactor;
            ScaleFonts(this.Controls, scalingFactor);

        }

        private void windowBar1_Click(object sender, EventArgs e)
        {

        }
        private void jihuo()
        {
            foreach (Form form in cks)
            {
                form.Show();
            }
            foreach (Form form in cks)
            {
                form.Hide();
            }
            foreach (Form form in cks)
            {
                form.AutoScaleMode = AutoScaleMode.None;
                form.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                ScaleFonts(form.Controls, DPI);

            }
        }


        public float GetDpiForCurrentWindow()
        {
            // 检查操作系统版本
            if (Environment.OSVersion.Version.Major >= 10)
            {
                // 使用 GetDpiForWindow 获取 DPI
                return GetDpiForWindow(this.Handle);
            }
            else
            {
                // 使用 GetDeviceCaps 获取 DPI
                using (Graphics graphics = this.CreateGraphics())
                {
                    IntPtr hdc = graphics.GetHdc();
                    int dpi = GetDeviceCaps(hdc, 88); // 88 是 LOGPIXELSX
                    graphics.ReleaseHdc(hdc);
                    return dpi;
                }
            }
        }



        public static int GetVirtualKeyCode(string keyString)
        {
            if (int.TryParse(keyString, out int keyCode))
            {
                return char.Parse(keyString);
            }
            if (keyString == "空格")
            {
                return 0x20;
            }
            Keys key;
            if (Enum.TryParse(keyString, out key))
            {
                return (int)key;
            }
            else
            {
                return 0;
            }
        }


        // 注意这里修改为了 async void
        private async void MainForm_Load(object sender, EventArgs e)
        {

            ////添加东西
            //QQVerificationLogin verificationForm = new QQVerificationLogin();
            //if (verificationForm.ShowDialog() != DialogResult.OK)
            //{
            //    MessageBox.Show("您必须加入1104647901才能使用本软件！");
            //    Application.Exit();
            //    return;
            //}


            //判断是否存在配置，不存在配置文件则创建一个新的Json配置文件
            if (!File.Exists(MainForm.filePath))
            {
                using (FileStream fs = File.Create(MainForm.filePath)) { }
                string jsonf = File.ReadAllText(MainForm.filePath);
                JObject root = new JObject();
                jsonf = root.ToString();
                File.WriteAllText(MainForm.filePath, jsonf);
            }
            //读取配置

            if (!Json.checkjson("ismoniqi"))
            {
                moniqi.SelectedItem = "MuMu模拟器";
            }
            else
            {
                moniqi.SelectedItem = Json.readjson("ismoniqi");
            }
            if (!Json.checkjson("tuqiujian"))
            {
                comboBoxtuqiu.SelectedItem = "A";
            }
            else
            {
                comboBoxtuqiu.SelectedItem = Json.readjson("tuqiujian");
            }
            if (!Json.checkjson("fenshenjian"))
            {
                comboBoxfenshen.SelectedItem = "A";
            }
            else
            {
                comboBoxfenshen.SelectedItem = Json.readjson("fenshenjian");
            }
            if (!Json.checkjson("yaogandaxiao"))
            {
                textBoxyaogandaxiao.Text = "1.6";
                try
                {
                    ygdx = float.Parse(textBoxyaogandaxiao.Text);
                }
                catch (Exception ex)
                {
                    ygdx = 1.6f;
                }
            }
            else
            {
                textBoxyaogandaxiao.Text = Json.readjson("yaogandaxiao");
                try
                {
                    ygdx = float.Parse(textBoxyaogandaxiao.Text);
                }
                catch (Exception ex)
                {
                    ygdx = 1.6f;
                }
            }
            if (!Json.checkjson("qjyc"))
            {
                comboBoxhqyc.SelectedItem = "技战室延迟[稳定]";
            }
            else
            {
                comboBoxhqyc.SelectedItem = Json.readjson("qjyc");
            }
            //展开树-基本功能
            treeView.Items[0].Expand = true;
            //添加所有窗口至容器
            Addck();
            //激活容器中所有窗口
            jihuo();
            //显示内存功能窗口
            Showck(cks[0]);


        }
        // =================== 新增拆分初始化按钮逻辑 ===================
        private void EnsureBaseAddresses()
        {
            if (baseAddrsFound) return;
            List<long> addresssy = Memory.ScanPatternParallel(hProcess, quanjuaob1, quanjuaob1.Length);
            if (addresssy.Count > 0)
            {
                foreach (long addr in addresssy)
                {
                    if (choose == "MuMu模拟器")
                    {
                        shiye = addr + 0x440;
                        tuqiu = addr + 0xAC;
                        yaoganjiasu = addr + 0xA8;
                        yaoganadr = addr + 0x44;
                        //nctqadr = addr;// + 0xC4;
                        tiji = addr + 0x3BC;
                    }
                    else if (choose == "雷电模拟器5")
                    {
                        shiye = addr + 0x31C;
                        tuqiu = addr + 0x98;
                        yaoganjiasu = addr + 0x49;
                        yaoganadr = addr + 0x38;
                        //nctqadr = addr + 0xA8;
                        tiji = addr + 0x2A8;
                    }
                    else if (choose == "雷电模拟器9")
                    {
                        shiye = addr + 0x31C;
                        tuqiu = addr + 0x98;
                        yaoganjiasu = addr + 0x49;
                        yaoganadr = addr + 0x38;
                        //nctqadr = addr + 0xA8;
                        tiji = addr + 0x2A8;
                    }
                }
                baseAddrsFound = true;
                ncyaoganadr = yaoganadr;
            }
        }

        private void FindGlobalSpeedAddress()
        {
            if (biansuAddrFound) return;
            List<long> addressqjbs = Memory.ScanPatternParallel(hProcess, biansuaob, biansuaob.Length);
            if (addressqjbs.Count > 0)
            {
                foreach (long addr in addressqjbs)
                {
                    biansu = addr;
                }
                yaoganyanchi = biansu - 0xB4;
                biansuAddrFound = true;
            }
        }

        private void buttonshiyeneicung_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                buttonshiyeneicung.Loading = true;
                buttonshiyeneicung.Text = "初始化中";
                tishi.Text += "[视野/内存初始化开始...]\r\n";

                EnsureBaseAddresses();
                if (shiye != 0)
                {
                    tishi.Text += "视野搜索成功\r\n";
                    Thread.Sleep(100);
                    tishi.Text += "吐球双连点搜索成功\r\n";
                    buttonchushihua.Enabled = true;
                    int bytesRead;
                    byte[] data = new byte[sizeof(float)];
                    ReadProcessMemory(hProcess, shiye + 4, data, sizeof(float), out bytesRead);
                    if (Application.OpenForms["neicungongneng"] is neicungongneng ncck)
                    {
                        if (Json.checkjson("shiye"))
                            ncck.textBoxshiyezhi.Text = Json.readjson("shiye");
                        else
                            ncck.textBoxshiyezhi.Text = BitConverter.ToSingle(data, 0).ToString("0.00");
                        if (!neicungongneng.shiyethstatu)
                        {
                            new Thread(ncck.shiyethread).Start();
                            neicungongneng.shiyethstatu = true;
                        }
                        ncck.checkboxtuqiu.Checked = true;
                        if (!neicungongneng.tuqiuthstatu)
                        {
                            new Thread(ncck.tuqiuthread).Start();
                            neicungongneng.tuqiuthstatu = true;
                        }
                    }
                }
                else
                {
                    tishi.Text += "视野/吐球搜索失败\r\n";
                }

                // 粘合
                List<long> addressnh = Memory.ScanPatternParallel(hProcess, nianheaob, nianheaob.Length);
                if (addressnh.Count > 0)
                {
                    foreach (long addr in addressnh) nianhe = addr - 0x8;
                    tishi.Text += "粘合搜索成功\r\n";
                    int bytesRead;
                    byte[] data = new byte[sizeof(float)];
                    ReadProcessMemory(hProcess, nianhe, data, sizeof(float), out bytesRead);
                    if (Application.OpenForms["neicungongneng"] is neicungongneng ncck)
                        ncck.textboxnianhe.Text = Json.checkjson("nianhe") ? Json.readjson("nianhe") : BitConverter.ToSingle(data, 0).ToString("0.000");
                }
                else tishi.Text += "粘合搜索失败\r\n";

                // 昵称大小
                List<long> addressncdx = Memory.ScanPatternParallel(hProcess, ncdxaob, ncdxaob.Length);
                if (addressncdx.Count > 0)
                {
                    nichengdaxiao = addressncdx[0] + 0xC;
                    tishi.Text += "昵称大小搜索成功\r\n";
                    int bytesRead;
                    byte[] data = new byte[sizeof(float)];
                    ReadProcessMemory(hProcess, nichengdaxiao, data, sizeof(float), out bytesRead);
                    if (Application.OpenForms["neicungongneng"] is neicungongneng ncck)
                        ncck.textboxnichengdaxiao.Text = Json.checkjson("nichengdaxiao") ? Json.readjson("nichengdaxiao") : BitConverter.ToSingle(data, 0).ToString("0.000");
                }
                else tishi.Text += "昵称大小搜索失败\r\n";

                // 全局变速
                FindGlobalSpeedAddress();
                if (biansu != 0)
                {
                    tishi.Text += "全局变速搜索成功\r\n";
                    int bytesRead;
                    byte[] data = new byte[sizeof(float)];
                    ReadProcessMemory(hProcess, biansu, data, sizeof(float), out bytesRead);
                    if (Application.OpenForms["neicungongneng"] is neicungongneng ncck)
                    {
                        if (Json.checkjson("biansu"))
                            ncck.textboxbiansu.Text = Json.readjson("biansu");
                        else
                            ncck.textboxbiansu.Text = BitConverter.ToSingle(data, 0).ToString("0.0");
                        if (!neicungongneng.quanjubiansuthstatu)
                        {
                            new Thread(ncck.quanjubiansuthread).Start();
                            neicungongneng.quanjubiansuthstatu = true;
                        }
                    }
                }
                else tishi.Text += "全局变速搜索失败\r\n";

                buttonshiyeneicung.Text = "初始化视野/内存";
                buttonshiyeneicung.Loading = false;
                tishi.Text += "[视野/内存初始化完成]\r\n";
            }).Start();
        }

        private void buttonyaoganfenshen_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                buttonyaoganfenshen.Loading = true;
                buttonyaoganfenshen.Text = "初始化中";
                tishi.Text += "[摇杆/分身初始化开始...]\r\n";

                // ========== 合并优化：只扫描一次 quanjuaob1 ==========
                List<long> baseAddresses = Memory.ScanPatternParallel(hProcess, quanjuaob1, quanjuaob1.Length);
                bool baseFound = (baseAddresses.Count > 0);
                long baseAddr = baseFound ? baseAddresses[0] : 0;
                // ===================================================

                // 1. 摇杆优化加速（仅当未获取时才设置）
                if (yaoganjiasu == 0 && baseFound)
                {
                    if (choose == "MuMu模拟器")
                        yaoganjiasu = baseAddr + 0xA8;
                    else if (choose == "雷电模拟器5" || choose == "雷电模拟器9")
                        yaoganjiasu = baseAddr + 0x4;
                }
                if (yaoganjiasu != 0)
                {
                    if (Application.OpenForms["neicungongneng"] is neicungongneng ncck)
                    {
                        ncck.checkboxygyh.Checked = true;
                        if (!neicungongneng.yaoganjiasuthstatu)
                        {
                            new Thread(ncck.ygjiasu).Start();
                            neicungongneng.yaoganjiasuthstatu = true;
                        }
                        tishi.Text += "遥杆优化加速搜索成功\r\n";
                    }
                }
                else tishi.Text += "遥杆优化加速搜索失败\r\n";

                // 2. 21亿摇杆（使用独立特征码，无需合并）
                List<long> addressyg10000 = Memory.ScanPatternParallel(hProcess, yaogan10000aob, yaogan10000aob.Length);
                if (addressyg10000.Count > 0)
                {
                    foreach (long addr in addressyg10000)
                    {
                        if (choose == "MuMu模拟器") yaogan10000 = addr - 0x51;
                        else yaogan10000 = addr - 0x44;
                    }
                    tishi.Text += "21亿摇杆搜索成功\r\n";
                    if (Application.OpenForms["neicungongneng"] is neicungongneng ncck)
                    {
                        ncck.checkboxyaogan10000.Checked = true;
                        if (!neicungongneng.yaogan10000thstatu)
                        {
                            new Thread(ncck.yg10000).Start();
                            neicungongneng.yaogan10000thstatu = true;
                        }
                    }
                }
                else tishi.Text += "21亿摇杆搜索失败\r\n";

                // 3. 响应值（使用独立特征码，无需合并）
                List<long> addressygxysd = Memory.ScanPatternParallel(hProcess, yaoganxiangyinsuduaob);
                if (addressygxysd.Count > 0)
                {
                    foreach (long addr in addressygxysd)
                    {
                        if (choose == "MuMu模拟器") yaoganxiangyinsudu = addr - 0x18;
                        else if (choose == "雷电模拟器5" || choose == "雷电模拟器9") yaoganxiangyinsudu = addr - 0x20;
                    }
                    tishi.Text += "响应值搜索成功\r\n";
                    if (Application.OpenForms["neicungongneng"] is neicungongneng ncck)
                    {
                        ncck.checkboxxiangyin21yi.Checked = true;
                        if (!neicungongneng.yaoganxiangyinthstatu)
                        {
                            new Thread(ncck.ygxiangyin).Start();
                            neicungongneng.yaoganxiangyinthstatu = true;
                        }
                    }
                }
                else tishi.Text += "响应值搜索失败\r\n";

                // 4. 全局变速（摇杆延迟）使用独立特征码
                FindGlobalSpeedAddress();
                if (biansu != 0)
                {
                    tishi.Text += "摇杆延迟搜索成功\r\n";
                    if (Application.OpenForms["neicungongneng"] is neicungongneng ncck)
                    {
                        ncck.checkboxygyc.Checked = true;
                        int byteswrite;
                        float value = 0.0001f;
                        WriteProcessMemory(hProcess, yaoganyanchi, BitConverter.GetBytes(value), sizeof(float), out byteswrite);
                    }
                }
                else tishi.Text += "摇杆延迟搜索失败\r\n";

                // 4. 遥杆/分身解限（独立特征码）
                List<long> addressygjx = Memory.ScanPatternParallel(hProcess, yaoganjiexianaob, yaoganjiexianaob.Length);
                if (addressygjx.Count > 0)
                {
                    foreach (long addr in addressygjx)
                    {
                        yaoganjiexian = addr - 0x24;
                        yaoganjiexian1 = addr + 0xC;
                    }
                    tishi.Text += "遥杆/分身解限搜索成功\r\n";
                    if (Application.OpenForms["neicungongneng"] is neicungongneng ncck)
                    {
                        ncck.checkboxygjx.Checked = true;
                        int byteswrite;
                        float value = 0.0f;
                        WriteProcessMemory(hProcess, yaoganjiexian, BitConverter.GetBytes(value), sizeof(float), out byteswrite);
                        WriteProcessMemory(hProcess, yaoganjiexian1, BitConverter.GetBytes(value), sizeof(float), out byteswrite);
                    }
                }
                else tishi.Text += "遥杆/分身解限搜索失败\r\n";

                // 5. 分身加速（独立特征码）
                List<long> addressfsjs = Memory.ScanPatternParallel(hProcess, fsjsaob, fsjsaob.Length);
                if (addressfsjs.Count > 0)
                {
                    foreach (long addr in addressfsjs) fsjs = addr + 9;
                    tishi.Text += "分身加速搜索成功\r\n";
                    if (Application.OpenForms["neicungongneng"] is neicungongneng ncck)
                    {
                        ncck.checkboxfsjs.Checked = true;
                        if (!neicungongneng.fenshenjiasuhstatu)
                            neicungongneng.fenshenjiasuhstatu = true;
                    }
                }
                else tishi.Text += "分身加速搜索失败\r\n";

                // 6. 超级解分身/吐球（复用 baseAddresses）
                if (baseFound)
                {
                    if (choose == "MuMu模拟器")
                    {
                        chaojijiefenshen = baseAddr + 0x9C;
                        chaojijietuqiu = baseAddr + 0x8C;
                    }
                    else // 雷电模拟器
                    {
                        chaojijiefenshen = baseAddr + 0x90;
                        chaojijietuqiu = baseAddr + 0xA0;
                    }
                    tishi.Text += "解阻尼分身/吐球搜索成功\r\n";
                    if (Application.OpenForms["neicungongneng"] is neicungongneng ncck)
                    {
                        ncck.checkboxjzntqfs.Checked = true;
                        if (!neicungongneng.chaojijiefenshen)
                        {
                            new Thread(ncck.chaojijiefenshen1).Start();
                            neicungongneng.chaojijiefenshen = true;
                        }
                    }
                }
                else tishi.Text += "解阻尼分身/吐球搜索失败\r\n";

                // 7. 分身解限1（独立特征码）
                List<long> addressfenshenjiexian = Memory.ScanPatternParallel(hProcess, fenshenjiexianaob, fenshenjiexianaob.Length);
                if (addressfenshenjiexian.Count > 0)
                {
                    fenshenjiexian = addressfenshenjiexian[0] - 0x01;
                    tishi.Text += "分身解限1搜索成功\r\n";
                    if (Application.OpenForms["neicungongneng"] is neicungongneng ncck)
                    {
                        ncck.checkboxfenshenjiexian2.Checked = true;
                        if (!neicungongneng.fenshenjiexian)
                            neicungongneng.fenshenjiexian = true;
                    }
                }
                else tishi.Text += "分身解限1搜索失败\r\n";

                // 8. 遥杆回弹/容差（独立特征码）
                List<long> addressyght = Memory.ScanPatternParallel(hProcess, yaoganhuitanaob, yaoganhuitanaob.Length);
                if (addressyght.Count > 0)
                {
                    for (int i = 0; i < addressyght.Count; i++)
                        yaoganhuitan = addressyght[i] + 0x28;
                    yaoganrongcha = yaoganhuitan - 0x04;
                    tishi.Text += "遥杆回弹搜索成功\r\n";
                    Thread.Sleep(100);
                    tishi.Text += "遥杆容差搜索成功\r\n";
                    int bytesRead;
                    int byteswrite;
                    byte[] data = new byte[sizeof(float)];
                    float defaultYgrc = 0f;
                    float defaultYght = 20f;
                    WriteProcessMemory(hProcess, yaoganrongcha, BitConverter.GetBytes(defaultYgrc), sizeof(float), out byteswrite);
                    WriteProcessMemory(hProcess, yaoganhuitan, BitConverter.GetBytes(defaultYght), sizeof(float), out byteswrite);
                    Json.writejson("yaoganrongcha", "0");
                    Json.writejson("yaoganhuitan", "10");
                    if (Application.OpenForms["neicungongneng"] is neicungongneng ncck)
                    {
                        ncck.textboxygrc.Text = "0";
                        ncck.textboxyght.Text = "20";
                    }
                }
                else
                {
                    tishi.Text += "遥杆回弹搜索失败\r\n";
                    Thread.Sleep(100);
                    tishi.Text += "遥杆容差搜索失败\r\n";
                }

                // 9. 超级摇杆（复用 baseAddresses）
                if (baseFound)
                {
                    if (choose == "MuMu模拟器")
                        chaojiyaogan = baseAddr + 0x88;
                    else // 雷电模拟器
                        chaojiyaogan = baseAddr + 0x74;
                    tishi.Text += "超级摇杆搜索成功\r\n";
                    int bytesRead;
                    byte[] data = new byte[sizeof(float)];
                    ReadProcessMemory(hProcess, chaojiyaogan, data, sizeof(float), out bytesRead);
                    if (Application.OpenForms["neicungongneng"] is neicungongneng ncck)
                        ncck.textboxchaojiyaogan.Text = Json.checkjson("chaojiyaogan") ? Json.readjson("chaojiyaogan") : BitConverter.ToSingle(data, 0).ToString("0.00");
                }
                else tishi.Text += "超级摇杆搜索失败\r\n";

                buttonyaoganfenshen.Text = "初始化摇杆/分身";
                buttonyaoganfenshen.Loading = false;
                tishi.Text += "[摇杆/分身初始化完成]\r\n";
            }).Start();
        }



        private void Addck()
        {
            foreach (Form form in cks)
            {
                form.TopLevel = false;
                panel.Controls.Add(form);
            }
        }
        private void Showck(Form form)
        {
            new Thread(shows).Start(form);
        }
        void shows(object obj)
        {
            Form form = (Form)obj;
            foreach (var forms in cks)
            {
                if (forms.Name == form.Name)
                {
                    forms.Show();
                }
                else
                {
                    if (forms.Name != this.Name)
                    {
                        forms.Hide();
                    }
                }
            }
        }
        private void treeView_NodeMouseClick(object sender, AntdUI.TreeItem item, Rectangle rect)
        {

            switch (item.Text)
            {
                case "内存功能":
                    panel.Height = 889;
                    Showck(new neicungongneng());
                    break;
                case "辅助功能":
                    panel.Height = 889; // 603 + 286 = 889
                    Showck(new fuzhugongneng());
                    break;
                case "内存三角-模式1":
                    Showck(new ncsanjiao1());
                    break;
                case "内存三角-模式2":
                    Showck(new ncsanjiao2());
                    break;
                case "内存四分侧合":
                    Showck(new ncsifencehe());
                    break;
                case "内存中分侧合":
                    Showck(new nczhongfencehe());
                    break;
                case "内存后仰侧合":
                    Showck(new nchouyangcehe());
                    break;
                case "内存半旋":
                    Showck(new ncbanxuan());
                    break;
                case "内存旋转":
                    Showck(new ncxuanzhuan());
                    break;
                case "内存蛇手":
                    Showck(new ncsheshou());
                    break;
                case "黑屏图色":
                    Showck(new heipingkadian());
                    break;
                case "宏功能":
                    Showck(new honggongneng());
                    break;
                case "皮肤功能":
                    Showck(new pifugongneng());
                    break;

            }
        }

        private void buttonhuoqujincheng_Click(object sender, EventArgs e)
        {
            Process[] processes;
            //赋值选择的全局模拟器
            try
            {
                choose = (string)moniqi.SelectedItem;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                processes = null;
            }

            //获取进程、窗口名、窗口句柄、窗口类名
            if (choose == "MuMu模拟器")
            {
                processes = Process.GetProcessesByName("MuMuVMMHeadless");
                if (processes == null || processes.Length == 0)
                {
                    processes = Process.GetProcessesByName("MuMuNxDevice");
                }
                ck = "MuMu模拟器12";
                lp = "Qt5156QWindowIcon";
                IntPtr h1, h2;
                h1 = FindWindowEx((IntPtr)null, (IntPtr)null, "Qt5156QWindowIcon", null);
                h2 = FindWindowEx(h1, (IntPtr)null, "Qt5156QWindowIcon", null);
                hWnd = FindWindowEx(h2, (IntPtr)null, "nemuwin", null);
                hWndmsg = h2;
            }
            else if (choose == "雷电模拟器5")
            {
                processes = Process.GetProcessesByName("LdVBoxHeadless");
                ck = "雷电模拟器";
                lp = "LDPlayerMainFrame";
                IntPtr h1, h2;
                h1 = FindWindowEx((IntPtr)null, (IntPtr)null, "LDPlayerMainFrame", null);
                h2 = FindWindowEx(h1, (IntPtr)null, "RenderWindow", null);
                hWnd = FindWindowEx(h2, (IntPtr)null, "subWin", null);
            }
            else if (choose == "雷电模拟器9")
            {
                processes = Process.GetProcessesByName("Ld9BoxHeadless");
                ck = "雷电模拟器";
                lp = "LDPlayerMainFrame";
                IntPtr h1, h2;
                h1 = FindWindowEx((IntPtr)null, (IntPtr)null, "LDPlayerMainFrame", null);
                h2 = FindWindowEx(h1, (IntPtr)null, "RenderWindow", null);
                hWnd = FindWindowEx(h2, (IntPtr)null, "subWin", null);
            }
            else
            {
                processes = null;
            }
            if (processes != null)
            {
                if (processes.Length > 0)
                {
                    foreach (Process process in processes)
                    {
                        pid = (IntPtr)process.Id;
                    }
                    hProcess = OpenProcess(Struct.ProcessAccessFlags.All, false, pid);
                    buttondiyibu.Enabled = true;
                    buttonshiyeneicung.Enabled = true;
                    buttonyaoganfenshen.Enabled = true;
                }
                else
                {
                    MessageBox.Show("未找到" + choose + "的进程");
                }
            }
            else
            {
                MessageBox.Show("未找到" + choose + "的进程");
            }

            List<long> addressguotanchuang = Memory.ScanPatternParallel(hProcess, guotanchuangaob, guotanchuangaob.Length);

            if (addressguotanchuang.Count > 0)
            {
                byte[] zeros = new byte[guotanchuangaob.Length];

                foreach (long addr in addressguotanchuang)
                {

                    if ((choose == "MuMu模拟器" || choose == "雷电模拟器5" || choose == "雷电模拟器9")
                        && (addr & 0xFF) == 0xEC)
                    {
                        guotanchuang = addr;

                        uint oldProtect;
                        VirtualProtectEx(hProcess, (IntPtr)addr, (uint)zeros.Length, PAGE_EXECUTE_READWRITE, out oldProtect);

                        int bytesWritten;
                        WriteProcessMemory(hProcess, addr, zeros, (uint)zeros.Length, out bytesWritten);

                        VirtualProtectEx(hProcess, (IntPtr)addr, (uint)zeros.Length, oldProtect, out _);
                    }
                }
                tishi.Text += "游戏主界面环境初始化搜索成功\r\n";
            }
            else
            {
                tishi.Text += "游戏主界面初始化环境搜索失败\r\n";
            }
        }

        private void buttondiyibu_Click(object sender, EventArgs e)
        {
            new Thread(diyibu).Start();


        }







        void diyibu()
        {
            buttondiyibu.Loading = true;
            buttondiyibu.Text = "搜索中";
            tishi.Text += "[全部搜索中...]\r\n";
            buttondiyibu.Enabled = false;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<long> addresssy = Memory.ScanPatternParallel(hProcess, quanjuaob1, quanjuaob1.Length);

            if (addresssy.Count > 0)
            {

                foreach (long addr in addresssy)
                {
                    if (choose == "MuMu模拟器")
                    {
                        shiye = addr + 0x440;
                        tuqiu = addr + 0xAC;
                        yaoganjiasu = addr + 0xA8;
                        yaoganadr = addr + 0x44;
                        //nctqadr = addr + 0xC4;//
                        tiji = addr + 0x3CC;
                        //
                        ncygjsx = addr + 0x68;
                        ncygjsy = addr + 0x6C;
                        xmin = addr + 0x434;//第3个 
                        xmax = addr + 0x438;//第4个
                        ymin = addr + 0x430;//第2个
                        ymax = addr + 0x42C;//第1个
                        selfsize = addr + 0x43C;
                        zhanjuzhi = addr + 0x4E4;
                        yaoganchuoadr = addr + 0x5C;

                    }
                    else if (choose == "雷电模拟器5")
                    {
                        shiye = addr + 0x31C;
                        tuqiu = addr + 0x98;
                        yaoganjiasu = addr + 0x49;
                        yaoganadr = addr + 0x38;
                        //nctqadr = addr + 0xA8;
                        tiji = addr + 0x2A8;
                        //
                        ncygjsx = addr + 0x5C;
                        ncygjsy = addr + 0x60;
                        //xmin = addr + 0x2F4;//第3个
                        //xmax = addr + 0x2F8;//第4个
                        //ymin = addr + 0x2F0;//第2个
                        //ymax = addr + 0x2EC;//第1个
                        selfsize = addr + 0x2FC;
                    }
                    else if (choose == "雷电模拟器9")
                    {
                        shiye = addr + 0x31C;
                        tuqiu = addr + 0x98;
                        yaoganjiasu = addr + 0x49;
                        yaoganadr = addr + 0x38;
                        //nctqadr = addr + 0xA8;
                        tiji = addr + 0x2A8;
                        //
                        ncygjsx = addr + 0x5C;
                        ncygjsy = addr + 0x60;
                        //xmin = addr + 0x2F4;//第3个
                        //xmax = addr + 0x2F8;//第4个
                        //ymin = addr + 0x2F0;//第2个
                        //ymax = addr + 0x2EC;//第1个
                        selfsize = addr + 0x2FC;
                    }
                    ncyaoganadr = yaoganadr;
                    tishi.Text += "视野搜索成功\r\n";
                    Thread.Sleep(300);
                    tishi.Text += "吐球双连点搜索成功\r\n";
                    Thread.Sleep(300);
                    tishi.Text += "遥杆优化加速搜索成功\r\n";
                    buttonchushihua.Enabled = true;
                    int bytesRead;
                    byte[] data = new byte[sizeof(float)];
                    ReadProcessMemory(MainForm.hProcess, MainForm.shiye + 4, data, sizeof(float), out bytesRead);
                    if (Json.checkjson("shiye"))
                    {
                        if (Application.OpenForms["neicungongneng"] is neicungongneng ncck1)
                        {
                            ncck1.textBoxshiyezhi.Text = Json.readjson("shiye");
                            if (!neicungongneng.shiyethstatu)
                            {
                                new Thread(ncck1.shiyethread).Start();
                                neicungongneng.shiyethstatu = true;
                            }
                        }
                    }
                    else
                    {
                        if (Application.OpenForms["neicungongneng"] is neicungongneng ncck1)
                        {
                            ncck1.textBoxshiyezhi.Text = BitConverter.ToSingle(data, 0).ToString("0.00");
                            if (!neicungongneng.shiyethstatu)
                            {
                                new Thread(ncck1.shiyethread).Start();
                                neicungongneng.shiyethstatu = true;
                            }
                        }
                    }
                    if (Application.OpenForms["neicungongneng"] is neicungongneng ncck2)
                    {
                        ncck2.checkboxtuqiu.Checked = true;
                        if (!neicungongneng.tuqiuthstatu)
                        {
                            new Thread(ncck2.tuqiuthread).Start();
                            neicungongneng.tuqiuthstatu = true;
                        }

                        ncck2.checkboxygyh.Checked = true;
                        if (!neicungongneng.yaoganjiasuthstatu)
                        {
                            new Thread(ncck2.ygjiasu).Start();
                            neicungongneng.yaoganjiasuthstatu = true;
                        }
                    }


                }
            }
            else
            {
                tishi.Text += "视野搜索失败\r\n";
                Thread.Sleep(300);
                tishi.Text += "吐球双连点搜索失败\r\n";
                Thread.Sleep(300);
                tishi.Text += "遥杆优化加速搜索失败\r\n";
            }

            // 新增：视野范围特征码扫描
            List<long> addressshiye2 = Memory.ScanPatternParallel(hProcess, "00 80 3B C4 ?? ?? ?? ?? ?? ?? ?? ?? 00 00 48 44");
            if (addressshiye2.Count > 0)
            {
                foreach (long addr in addressshiye2)
                {
                    shiyefanwei = addr + 0x4;
                }
                tishi.Text += "绑码视野搜索成功\r\n";
            }
            else
            {
                tishi.Text += "绑码视野搜索失败\r\n";
            }


            List<long> addressnh = Memory.ScanPatternParallel(hProcess, nianheaob, nianheaob.Length);


            if (addressnh.Count > 0)
            {
                foreach (long addr in addressnh)
                {
                    nianhe = addr - 0x8;
                }
                tishi.Text += "粘合搜索成功\r\n";

                int bytesRead;
                byte[] data = new byte[sizeof(float)];
                ReadProcessMemory(MainForm.hProcess, MainForm.nianhe, data, sizeof(float), out bytesRead);
                if (Json.checkjson("nianhe"))
                {
                    if (Application.OpenForms["neicungongneng"] is neicungongneng ncck1)
                    {
                        ncck1.textboxnianhe.Text = Json.readjson("nianhe");
                    }
                }
                else
                {
                    if (Application.OpenForms["neicungongneng"] is neicungongneng ncck1)
                    {
                        ncck1.textboxnianhe.Text = BitConverter.ToSingle(data, 0).ToString("0.000");
                    }
                }
            }
            else
            {
                tishi.Text += "粘合搜索失败\r\n";
            }


            List<long> addressncdx = Memory.ScanPatternParallel(hProcess, ncdxaob, ncdxaob.Length);//address ygjx


            if (addressncdx.Count > 0)
            {
                foreach (long addr in addressncdx)
                {
                    nichengdaxiao = addr + 0xC;
                }
                tishi.Text += "昵称大小搜索成功\r\n";
                int bytesRead;
                byte[] data = new byte[sizeof(float)];
                ReadProcessMemory(MainForm.hProcess, MainForm.nichengdaxiao, data, sizeof(float), out bytesRead);
                if (Json.checkjson("nichengdaxiao"))
                {
                    if (Application.OpenForms["neicungongneng"] is neicungongneng ncck1)
                    {
                        ncck1.textboxnichengdaxiao.Text = Json.readjson("nichengdaxiao");
                    }
                }
                else
                {
                    if (Application.OpenForms["neicungongneng"] is neicungongneng ncck1)
                    {
                        ncck1.textboxnichengdaxiao.Text = BitConverter.ToSingle(data, 0).ToString("0.000");
                    }
                }
            }
            else
            {
                tishi.Text += "昵称大小搜索失败\r\n";
            }

            //--------------------------------基本内存/视野功能---------------------------------//


            List<long> addressyg10000 = Memory.ScanPatternParallel(hProcess, yaogan10000aob, yaogan10000aob.Length);

            if (addressyg10000.Count > 0)
            {
                foreach (long addr in addressyg10000)
                {
                    if (choose == "MuMu模拟器")
                    {
                        yaogan10000 = addr - 0x51;
                    }
                    else if (choose == "雷电模拟器5" || choose == "雷电模拟器9")
                    {
                        yaogan10000 = addr - 0x41;
                    }
                }
                tishi.Text += "摇杆值搜索成功\r\n";
                if (Application.OpenForms["neicungongneng"] is neicungongneng ncck1)
                {
                    ncck1.checkboxyaogan10000.Checked = true;
                    if (!neicungongneng.yaogan10000thstatu)
                    {
                        new Thread(ncck1.yg10000).Start();
                        neicungongneng.yaogan10000thstatu = true;
                    }
                }

            }
            else
            {
                tishi.Text += "摇杆值搜索失败\r\n";
            }

            List<long> addressygxysd = Memory.ScanPatternParallel(hProcess, yaoganxiangyinsuduaob);

            if (addressygxysd.Count > 0)
            {
                foreach (long addr in addressygxysd)
                {
                    if (choose == "MuMu模拟器")
                    {
                        yaoganxiangyinsudu = addr - 0x18;
                    }
                    else if (choose == "雷电模拟器5" || choose == "雷电模拟器9")
                    {
                        yaoganxiangyinsudu = addr - 0x20;
                    }
                }
                tishi.Text += "响应值搜索成功\r\n";
                if (Application.OpenForms["neicungongneng"] is neicungongneng ncck1)
                {
                    ncck1.checkboxxiangyin21yi.Checked = true;
                    if (!neicungongneng.yaoganxiangyinthstatu)
                    {
                        new Thread(ncck1.ygxiangyin).Start();
                        neicungongneng.yaoganxiangyinthstatu = true;
                    }
                }
            }
            else
            {
                tishi.Text += "响应值搜索失败\r\n";
            }

            List<long> addressqjbs = Memory.ScanPatternParallel(hProcess, biansuaob, biansuaob.Length);

            if (addressqjbs.Count > 0)
            {
                foreach (long addr in addressqjbs)
                {
                    biansu = addr;
                }
                yaoganyanchi = biansu - 0xB4;
                tishi.Text += "全局变速搜索成功\r\n";
                Thread.Sleep(300);
                tishi.Text += "摇杆延迟搜索成功\r\n";
                int bytesRead;
                byte[] data = new byte[sizeof(float)];
                ReadProcessMemory(MainForm.hProcess, MainForm.biansu, data, sizeof(float), out bytesRead);
                if (Json.checkjson("biansu"))
                {
                    if (Application.OpenForms["neicungongneng"] is neicungongneng ncck1)
                    {
                        ncck1.textboxbiansu.Text = Json.readjson("biansu");
                        if (!neicungongneng.quanjubiansuthstatu)
                        {
                            new Thread(ncck1.quanjubiansuthread).Start();
                            neicungongneng.quanjubiansuthstatu = true;
                        }
                    }
                }
                else
                {
                    if (Application.OpenForms["neicungongneng"] is neicungongneng ncck1)
                    {
                        ncck1.textboxbiansu.Text = BitConverter.ToSingle(data, 0).ToString("0.0");
                        if (!neicungongneng.quanjubiansuthstatu)
                        {
                            new Thread(ncck1.quanjubiansuthread).Start();
                            neicungongneng.quanjubiansuthstatu = true;
                        }
                    }
                }
                if (Application.OpenForms["neicungongneng"] is neicungongneng ncck2)
                {
                    ncck2.checkboxygyc.Checked = true;
                    int byteswrite;
                    float value = 0.0005f;
                    WriteProcessMemory(MainForm.hProcess, MainForm.yaoganyanchi, BitConverter.GetBytes(value), sizeof(float), out byteswrite);
                }

            }
            else
            {
                tishi.Text += "全局变速搜索失败\r\n";
                Thread.Sleep(300);
                tishi.Text += "摇杆延迟搜索失败\r\n";
            }

            List<long> addressygjx = Memory.ScanPatternParallel(hProcess, yaoganjiexianaob, yaoganjiexianaob.Length);

            if (addressygjx.Count > 0)
            {
                foreach (long addr in addressygjx)
                {
                    yaoganjiexian = addr - 0x24;
                    yaoganjiexian1 = addr + 0xC;
                }
                tishi.Text += "遥杆/分身解限搜索成功\r\n";
                if (Application.OpenForms["neicungongneng"] is neicungongneng ncck1)
                {
                    ncck1.checkboxygjx.Checked = true;
                    int byteswrite;
                    float value = 0.0f;
                    WriteProcessMemory(MainForm.hProcess, MainForm.yaoganjiexian, BitConverter.GetBytes(value), sizeof(float), out byteswrite);
                    WriteProcessMemory(MainForm.hProcess, MainForm.yaoganjiexian1, BitConverter.GetBytes(value), sizeof(float), out byteswrite);
                }

            }
            else
            {
                tishi.Text += "遥杆/分身解限搜索失败\r\n";
            }

            List<long> addressyght = Memory.ScanPatternParallel(hProcess, yaoganhuitanaob, yaoganhuitanaob.Length);


            if (addressyght.Count > 0)
            {
                for (int i = 0; i < addressyght.Count; i++)
                {
                    yaoganhuitan = addressyght[i] + 0x28;
                }
                yaoganrongcha = yaoganhuitan - 0x04;
                tishi.Text += "遥杆回弹搜索成功\r\n";
                Thread.Sleep(300);
                tishi.Text += "遥杆容差搜索成功\r\n";
                int bytesRead;
                int byteswrite;
                byte[] data = new byte[sizeof(float)];
                float defaultYgrc = 0f;
                float defaultYght = 20f;
                WriteProcessMemory(MainForm.hProcess, MainForm.yaoganrongcha, BitConverter.GetBytes(defaultYgrc), sizeof(float), out byteswrite);
                WriteProcessMemory(MainForm.hProcess, MainForm.yaoganhuitan, BitConverter.GetBytes(defaultYght), sizeof(float), out byteswrite);
                Json.writejson("yaoganrongcha", "0");
                Json.writejson("yaoganhuitan", "10");
                if (Application.OpenForms["neicungongneng"] is neicungongneng ncck1)
                {
                    ncck1.textboxygrc.Text = "0";
                    ncck1.textboxyght.Text = "10";
                }
            }
            else
            {
                tishi.Text += "遥杆回弹搜索失败\r\n";
                Thread.Sleep(300);
                tishi.Text += "遥杆容差搜索失败\r\n";
            }





            // 超级摇杆
            List<long> addresschaojiyaogan = Memory.ScanPatternParallel(hProcess, quanjuaob1, quanjuaob1.Length);

            if (addresschaojiyaogan.Count > 0)
            {
                foreach (long addr in addresschaojiyaogan)
                {
                    if (choose == "MuMu模拟器")
                    {
                        chaojiyaogan = addr + 0x88;
                    }
                    else if (choose == "雷电模拟器5" || choose == "雷电模拟器9")
                    {
                        chaojiyaogan = addr + 0x74;
                    }
                }

                tishi.Text += "超级摇杆搜索成功\r\n";

                int bytesRead;
                byte[] data = new byte[sizeof(float)];
                ReadProcessMemory(MainForm.hProcess, MainForm.chaojiyaogan, data, sizeof(float), out bytesRead);

                if (Json.checkjson("chaojiyaogan"))
                {
                    if (Application.OpenForms["neicungongneng"] is neicungongneng ncck1)
                    {
                        ncck1.textboxchaojiyaogan.Text = Json.readjson("chaojiyaogan");
                    }
                }
                else
                {
                    if (Application.OpenForms["neicungongneng"] is neicungongneng ncck1)
                    {
                        ncck1.textboxchaojiyaogan.Text = BitConverter.ToSingle(data, 0).ToString("0.00");
                    }
                }
            }
            else
            {
                tishi.Text += "超级摇杆搜索失败\r\n";
            }

            //超级解分身解吐球限速
            List<long> addresschaojijiefenshen = Memory.ScanPatternParallel(hProcess, quanjuaob1, quanjuaob1.Length);

            if (addresschaojijiefenshen.Count > 0)
            {
                foreach (long addr in addresschaojijiefenshen)
                {
                    if (choose == "MuMu模拟器")
                    {
                        chaojijiefenshen = addr + 0x9C;
                        chaojijietuqiu = addr + 0x8C;

                    }
                    else if (choose == "雷电模拟器5" || choose == "雷电模拟器9")
                    {
                        chaojijiefenshen = addr + 0x90;
                        chaojijietuqiu = addr + 0xA0;
                    }
                }
                tishi.Text += "解阻尼分身/吐球搜索成功\r\n";
                if (Application.OpenForms["neicungongneng"] is neicungongneng ncck1)
                {
                    ncck1.checkboxjzntqfs.Checked = true;
                    if (!neicungongneng.chaojijiefenshen)
                    {
                        new Thread(ncck1.chaojijiefenshen1).Start();
                        neicungongneng.chaojijiefenshen = true;
                    }
                }

            }
            else
            {
                tishi.Text += "解阻尼分身/吐球搜索失败\r\n";
            }

            //解分身限速1
            List<long> addressfenshenjiexian = Memory.ScanPatternParallel(hProcess, fenshenjiexianaob, fenshenjiexianaob.Length);

            if (addressfenshenjiexian.Count > 0)
            {
                foreach (long addr in addressfenshenjiexian)
                {
                    if (choose == "MuMu模拟器")
                    {
                        fenshenjiexian = addr - 0x01;
                    }
                    else if (choose == "雷电模拟器5" || choose == "雷电模拟器9")
                    {
                        fenshenjiexian = addr - 0x01;
                    }
                }
                tishi.Text += "分身解限1搜索成功\r\n";
                if (Application.OpenForms["neicungongneng"] is neicungongneng ncck1)
                {
                    ncck1.checkboxfenshenjiexian2.Checked = true;
                    if (!neicungongneng.fenshenjiexian)
                    {

                        neicungongneng.fenshenjiexian = true;
                    }
                }
            }
            else
            {
                tishi.Text += "分身解限1搜索失败\r\n";
            }

            //分身加速
            List<long> addressfsjs = Memory.ScanPatternParallel(hProcess, fsjsaob, fsjsaob.Length);

            if (addressfsjs.Count > 0)
            {
                foreach (long addr in addressfsjs)
                {
                    if (choose == "MuMu模拟器")
                    {
                        fsjs = addr + 9;
                    }
                    else if (choose == "雷电模拟器5" || choose == "雷电模拟器9")
                    {
                        fsjs = addr + 1;
                    }
                }
                tishi.Text += "分身加速搜索成功\r\n";
                if (Application.OpenForms["neicungongneng"] is neicungongneng ncck1)
                {
                    ncck1.checkboxfsjs.Checked = true;
                    if (!neicungongneng.fenshenjiasuhstatu)
                    {

                        neicungongneng.fenshenjiasuhstatu = true;
                    }
                }
            }
            else
            {
                tishi.Text += "分身加速搜索失败\r\n";
            }


            //局内去皮
            List<long> addressycgh = Memory.ScanPatternParallel(hProcess, ycghaob, ycghaob.Length);

            if (addressycgh.Count > 0)
            {
                foreach (long addr in addressycgh)
                {
                    ycgh = addr - 0x00;
                }
                tishi.Text += "局内去皮搜索成功\r\n";
                int bytesRead;
                byte[] data = new byte[sizeof(float)];
                ReadProcessMemory(MainForm.hProcess, MainForm.ycgh, data, sizeof(float), out bytesRead);
                if (Json.checkjson("ycgh"))
                {
                    if (Application.OpenForms["neicungongneng"] is neicungongneng ncck1)
                    {

                    }
                }
                else
                {
                    if (Application.OpenForms["neicungongneng"] is neicungongneng ncck1)
                    {

                    }
                }
            }
            else
            {
                tishi.Text += "局内去皮搜索失败\r\n";
            }

            //主页查排名
            List<long> addresszhuyechapai = Memory.ScanPatternParallel(hProcess, zhuyechapaiaob, zhuyechapaiaob.Length);

            if (addresszhuyechapai.Count > 0)
            {
                foreach (long addr in addresszhuyechapai)
                {
                    zhuyechapai = addr;
                }
                tishi.Text += "主页查排名搜索成功\r\n";

                // 基址 - - 0x3E2，读取4字节DEC整数
                long targetAddress = zhuyechapai - 0x3E2;
                int bytesRead;
                byte[] data = new byte[sizeof(int)];
                ReadProcessMemory(MainForm.hProcess, targetAddress, data, sizeof(int), out bytesRead);

                if (Json.checkjson("zhuyechapai"))
                {
                    if (Application.OpenForms["neicungongneng"] is neicungongneng ncck1)
                    {
                        ncck1.txtzhuyechapai.Text = Json.readjson("zhuyechapai");
                    }
                }
                else
                {
                    if (Application.OpenForms["neicungongneng"] is neicungongneng ncck1)
                    {
                        ncck1.txtzhuyechapai.Text = BitConverter.ToInt32(data, 0).ToString();
                    }
                }

                // 启动实时监控线程
                if (!neicungongneng.zhuyechapaithstatu)
                {
                    new Thread(() =>
                    {
                        neicungongneng.zhuyechapaithstatu = true;
                        while (true)
                        {
                            long addr = MainForm.zhuyechapai - 0x3E2;
                            int br;
                            byte[] dt = new byte[sizeof(int)];
                            ReadProcessMemory(MainForm.hProcess, addr, dt, sizeof(int), out br);
                            int currentValue = BitConverter.ToInt32(dt, 0);

                            if (Application.OpenForms["neicungongneng"] is neicungongneng ncck1)
                            {
                                ncck1.txtzhuyechapai.Text = currentValue.ToString();
                            }

                            Thread.Sleep(100);
                        }
                    }).Start();
                }
            }
            else
            {
                tishi.Text += "主页查排名搜索失败\r\n";
            }


            stopwatch.Stop();
            string elapsedTime = String.Format("{0} s {1} ms", (stopwatch.Elapsed - new TimeSpan(0)).Seconds, (stopwatch.Elapsed - new TimeSpan()).Milliseconds);
            tishi.Text += $"[全部搜索完成...总共用时:{elapsedTime}]\r\n";
            buttondiyibu.Text = "全部搜索";
            buttondiyibu.Loading = false;
            buttondiyibu.Enabled = true;
        }


        private void tishi_TextChanged(object sender, EventArgs e)
        {
            tishi.SelectionStart = tishi.Text.Length;
            tishi.ScrollToCaret();
        }
        void heqiuchushihua()
        {
            //quanjufenshenjian = (byte)GetVirtualKeyCode(comboBoxfenshen.SelectedItem.ToString());
            //honggongneng.handlew = hWnd;
            try
            {
                ygdx = float.Parse(textBoxyaogandaxiao.Text);
            }
            catch (Exception ex)
            {
                ygdx = 1.6f;
                textBoxyaogandaxiao.Text = "1.6";
            }
            buttonchushihua.Enabled = false;
        }



        private void MainForm_Resize(object sender, EventArgs e)
        {
            double bili = this.ClientSize.Width / 1284;
            Debug.WriteLine(bili);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            try
            {
                Process[] processes = Process.GetProcessesByName("System32.dll");
                foreach (Process process in processes)
                {
                    process.Kill();
                    process.WaitForExit();
                }
            }
            catch (Exception ex)
            {

            }
            Process currentProcess = Process.GetCurrentProcess();
            currentProcess.Kill();

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Process[] processes = Process.GetProcessesByName("System32.dll");
                foreach (Process process in processes)
                {
                    process.Kill();
                    process.WaitForExit();
                }
            }
            catch (Exception ex)
            {

            }
            Process currentProcess = Process.GetCurrentProcess();
            currentProcess.Kill();
        }

        private void buttonchushihua_Click(object sender, EventArgs e)
        {
            if (comboBoxfenshen.SelectedItem != null && comboBoxtuqiu.SelectedItem != null)
            {
                bool neiCunYaoGanZhuangTai = true;
                if (neiCunYaoGanZhuangTai)
                {
                    if (Application.OpenForms["neicungongneng"] is neicungongneng ncck)
                    {
                        if (!neicungongneng.yaoganjiasuthstatu)
                        {
                            new Thread(ncck.ygjiasu).Start();
                            neicungongneng.yaoganjiasuthstatu = true;
                        }
                    }
                    neicunheqiu.fenshenjian = (byte)GetVirtualKeyCode(comboBoxfenshen.SelectedItem.ToString());
                    neicunheqiu.tuqiujian = (byte)GetVirtualKeyCode(comboBoxtuqiu.SelectedItem.ToString());
                    neicunheqiu.yaoganadr = yaoganadr;
                    ncyaoganadr = yaoganadr;
                    heqiuchushihua();
                    if (!chushihuaflag)
                    {
                        new Thread(neicunheqiu.ncheqiu).Start();
                        
                        chushihuaflag = true;
                    }
                    tishi.Text += "合球初始化成功\r\n";
                }
                else
                {
                    heqiuchushihua();
                    if (!chushihuaflag)
                    {
                        chushihuaflag = true;
                    }
                    tishi.Text += "内存合球初始化失败，请勿使用内存合球!\r\n";
                    //锁定内存合球启用键
                }
            }
            else
            {
                MessageBox.Show("初始化失败，请设置吐球键和分身键！");
            }
        }

        private void windowBar_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void comboBoxhqyc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Json.writejson("qjyc", comboBoxhqyc.SelectedItem.ToString());
            if (comboBoxhqyc.SelectedItem.ToString() == "实战通用延迟-慢速[稳定]")
            {
                if (Application.OpenForms["ncsanjiao1"] is ncsanjiao1 ncsj)
                {
                    ncsj.datagridviewncsj1.Rows[0].Cells[1].Value = 30;
                    ncsj.datagridviewncsj1.Rows[1].Cells[1].Value = 55;
                    ncsj.datagridviewncsj1.Rows[2].Cells[1].Value = 30;
                    ncsj.datagridviewncsj1.Rows[3].Cells[1].Value = 55;
                    ncsj.datagridviewncsj1.Rows[4].Cells[1].Value = 30;
                    ncsj.datagridviewncsj1.Rows[5].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncsanjiao2"] is ncsanjiao2 ncsj2)
                {
                    ncsj2.datagridviewncsj2.Rows[0].Cells[1].Value = 30;
                    ncsj2.datagridviewncsj2.Rows[1].Cells[1].Value = 55;
                    ncsj2.datagridviewncsj2.Rows[2].Cells[1].Value = 30;
                    ncsj2.datagridviewncsj2.Rows[3].Cells[1].Value = 55;
                    ncsj2.datagridviewncsj2.Rows[4].Cells[1].Value = 30;
                    ncsj2.datagridviewncsj2.Rows[5].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncsifencehe"] is ncsifencehe ncsfch)
                {
                    ncsfch.datagridviewncsfch.Rows[0].Cells[1].Value = 55;
                    ncsfch.datagridviewncsfch.Rows[1].Cells[1].Value = 55;
                    ncsfch.datagridviewncsfch.Rows[2].Cells[1].Value = 30;
                    ncsfch.datagridviewncsfch.Rows[3].Cells[1].Value = 20;
                }
                if (Application.OpenForms["nczhongfencehe"] is nczhongfencehe nczfch)
                {
                    nczfch.datagridviewnczfch.Rows[0].Cells[1].Value = 55;
                    nczfch.datagridviewnczfch.Rows[1].Cells[1].Value = 30;
                    nczfch.datagridviewnczfch.Rows[2].Cells[1].Value = 55;
                    nczfch.datagridviewnczfch.Rows[3].Cells[1].Value = 30;
                    nczfch.datagridviewnczfch.Rows[4].Cells[1].Value = 20;
                }
                if (Application.OpenForms["nchouyangcehe"] is nchouyangcehe nchych)
                {
                    nchych.datagridviewnchych.Rows[0].Cells[1].Value = 55;
                    nchych.datagridviewnchych.Rows[1].Cells[1].Value = 30;
                    nchych.datagridviewnchych.Rows[2].Cells[1].Value = 55;
                    nchych.datagridviewnchych.Rows[3].Cells[1].Value = 30;
                    nchych.datagridviewnchych.Rows[4].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncbanxuan"] is ncbanxuan ncbx)
                {
                    ncbx.datagridviewncbx.Rows[0].Cells[1].Value = 30;
                    ncbx.datagridviewncbx.Rows[1].Cells[1].Value = 55;
                    ncbx.datagridviewncbx.Rows[2].Cells[1].Value = 30;
                    ncbx.datagridviewncbx.Rows[3].Cells[1].Value = 55;
                    ncbx.datagridviewncbx.Rows[4].Cells[1].Value = 30;
                    ncbx.datagridviewncbx.Rows[5].Cells[1].Value = 55;
                    ncbx.datagridviewncbx.Rows[6].Cells[1].Value = 30;
                    ncbx.datagridviewncbx.Rows[7].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncxuanzhuan"] is ncxuanzhuan ncxz)
                {
                    ncxz.datagridviewncxz.Rows[0].Cells[1].Value = 30;
                    ncxz.datagridviewncxz.Rows[1].Cells[1].Value = 55;
                    ncxz.datagridviewncxz.Rows[2].Cells[1].Value = 30;
                    ncxz.datagridviewncxz.Rows[3].Cells[1].Value = 55;
                    ncxz.datagridviewncxz.Rows[4].Cells[1].Value = 30;
                    ncxz.datagridviewncxz.Rows[5].Cells[1].Value = 55;
                    ncxz.datagridviewncxz.Rows[6].Cells[1].Value = 30;
                    ncxz.datagridviewncxz.Rows[7].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncsheshou"] is ncsheshou ncss)
                {
                    ncss.datagridviewncss.Rows[0].Cells[1].Value = 30;
                    ncss.datagridviewncss.Rows[1].Cells[1].Value = 55;
                    ncss.datagridviewncss.Rows[2].Cells[1].Value = 30;
                    ncss.datagridviewncss.Rows[3].Cells[1].Value = 55;
                    ncss.datagridviewncss.Rows[4].Cells[1].Value = 30;
                    ncss.datagridviewncss.Rows[5].Cells[1].Value = 55;
                    ncss.datagridviewncss.Rows[6].Cells[1].Value = 30;
                    ncss.datagridviewncss.Rows[7].Cells[1].Value = 20;
                }
            }
            if (comboBoxhqyc.SelectedItem.ToString() == "实战通用延迟-快速[激进]")
            {
                if (Application.OpenForms["ncsanjiao1"] is ncsanjiao1 ncsj)
                {
                    ncsj.datagridviewncsj1.Rows[0].Cells[1].Value = 20;
                    ncsj.datagridviewncsj1.Rows[1].Cells[1].Value = 45;
                    ncsj.datagridviewncsj1.Rows[2].Cells[1].Value = 20;
                    ncsj.datagridviewncsj1.Rows[3].Cells[1].Value = 45;
                    ncsj.datagridviewncsj1.Rows[4].Cells[1].Value = 20;
                    ncsj.datagridviewncsj1.Rows[5].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncsanjiao2"] is ncsanjiao2 ncsj2)
                {
                    ncsj2.datagridviewncsj2.Rows[0].Cells[1].Value = 20;
                    ncsj2.datagridviewncsj2.Rows[1].Cells[1].Value = 45;
                    ncsj2.datagridviewncsj2.Rows[2].Cells[1].Value = 20;
                    ncsj2.datagridviewncsj2.Rows[3].Cells[1].Value = 45;
                    ncsj2.datagridviewncsj2.Rows[4].Cells[1].Value = 20;
                    ncsj2.datagridviewncsj2.Rows[5].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncsifencehe"] is ncsifencehe ncsfch)
                {
                    ncsfch.datagridviewncsfch.Rows[0].Cells[1].Value = 45;
                    ncsfch.datagridviewncsfch.Rows[1].Cells[1].Value = 45;
                    ncsfch.datagridviewncsfch.Rows[2].Cells[1].Value = 20;
                    ncsfch.datagridviewncsfch.Rows[3].Cells[1].Value = 20;
                }
                if (Application.OpenForms["nczhongfencehe"] is nczhongfencehe nczfch)
                {
                    nczfch.datagridviewnczfch.Rows[0].Cells[1].Value = 45;
                    nczfch.datagridviewnczfch.Rows[1].Cells[1].Value = 20;
                    nczfch.datagridviewnczfch.Rows[2].Cells[1].Value = 45;
                    nczfch.datagridviewnczfch.Rows[3].Cells[1].Value = 20;
                    nczfch.datagridviewnczfch.Rows[4].Cells[1].Value = 20;
                }
                if (Application.OpenForms["nchouyangcehe"] is nchouyangcehe nchych)
                {
                    nchych.datagridviewnchych.Rows[0].Cells[1].Value = 45;
                    nchych.datagridviewnchych.Rows[1].Cells[1].Value = 20;
                    nchych.datagridviewnchych.Rows[2].Cells[1].Value = 45;
                    nchych.datagridviewnchych.Rows[3].Cells[1].Value = 20;
                    nchych.datagridviewnchych.Rows[4].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncbanxuan"] is ncbanxuan ncbx)
                {
                    ncbx.datagridviewncbx.Rows[0].Cells[1].Value = 25;
                    ncbx.datagridviewncbx.Rows[1].Cells[1].Value = 55;
                    ncbx.datagridviewncbx.Rows[2].Cells[1].Value = 25;
                    ncbx.datagridviewncbx.Rows[3].Cells[1].Value = 55;
                    ncbx.datagridviewncbx.Rows[4].Cells[1].Value = 25;
                    ncbx.datagridviewncbx.Rows[5].Cells[1].Value = 55;
                    ncbx.datagridviewncbx.Rows[6].Cells[1].Value = 25;
                    ncbx.datagridviewncbx.Rows[7].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncxuanzhuan"] is ncxuanzhuan ncxz)
                {
                    ncxz.datagridviewncxz.Rows[0].Cells[1].Value = 25;
                    ncxz.datagridviewncxz.Rows[1].Cells[1].Value = 55;
                    ncxz.datagridviewncxz.Rows[2].Cells[1].Value = 25;
                    ncxz.datagridviewncxz.Rows[3].Cells[1].Value = 55;
                    ncxz.datagridviewncxz.Rows[4].Cells[1].Value = 25;
                    ncxz.datagridviewncxz.Rows[5].Cells[1].Value = 55;
                    ncxz.datagridviewncxz.Rows[6].Cells[1].Value = 25;
                    ncxz.datagridviewncxz.Rows[7].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncsheshou"] is ncsheshou ncss)
                {
                    ncss.datagridviewncss.Rows[0].Cells[1].Value = 25;
                    ncss.datagridviewncss.Rows[1].Cells[1].Value = 55;
                    ncss.datagridviewncss.Rows[2].Cells[1].Value = 25;
                    ncss.datagridviewncss.Rows[3].Cells[1].Value = 55;
                    ncss.datagridviewncss.Rows[4].Cells[1].Value = 25;
                    ncss.datagridviewncss.Rows[5].Cells[1].Value = 55;
                    ncss.datagridviewncss.Rows[6].Cells[1].Value = 25;
                    ncss.datagridviewncss.Rows[7].Cells[1].Value = 20;
                }
            }
            if (comboBoxhqyc.SelectedItem.ToString() == "技战室延迟[稳定]")
            {
                if (Application.OpenForms["ncsanjiao1"] is ncsanjiao1 ncsj)
                {
                    ncsj.datagridviewncsj1.Rows[0].Cells[1].Value = 50;
                    ncsj.datagridviewncsj1.Rows[1].Cells[1].Value = 10;
                    ncsj.datagridviewncsj1.Rows[2].Cells[1].Value = 50;
                    ncsj.datagridviewncsj1.Rows[3].Cells[1].Value = 10;
                    ncsj.datagridviewncsj1.Rows[4].Cells[1].Value = 50;
                    ncsj.datagridviewncsj1.Rows[5].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncsanjiao2"] is ncsanjiao2 ncsj2)
                {
                    ncsj2.datagridviewncsj2.Rows[0].Cells[1].Value = 50;
                    ncsj2.datagridviewncsj2.Rows[1].Cells[1].Value = 10;
                    ncsj2.datagridviewncsj2.Rows[2].Cells[1].Value = 50;
                    ncsj2.datagridviewncsj2.Rows[3].Cells[1].Value = 10;
                    ncsj2.datagridviewncsj2.Rows[4].Cells[1].Value = 50;
                    ncsj2.datagridviewncsj2.Rows[5].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncsifencehe"] is ncsifencehe ncsfch)
                {
                    ncsfch.datagridviewncsfch.Rows[0].Cells[1].Value = 10;
                    ncsfch.datagridviewncsfch.Rows[1].Cells[1].Value = 10;
                    ncsfch.datagridviewncsfch.Rows[2].Cells[1].Value = 50;
                    ncsfch.datagridviewncsfch.Rows[3].Cells[1].Value = 20;
                }
                if (Application.OpenForms["nczhongfencehe"] is nczhongfencehe nczfch)
                {
                    nczfch.datagridviewnczfch.Rows[0].Cells[1].Value = 10;
                    nczfch.datagridviewnczfch.Rows[1].Cells[1].Value = 50;
                    nczfch.datagridviewnczfch.Rows[2].Cells[1].Value = 10;
                    nczfch.datagridviewnczfch.Rows[3].Cells[1].Value = 50;
                    nczfch.datagridviewnczfch.Rows[4].Cells[1].Value = 20;
                }
                if (Application.OpenForms["nchouyangcehe"] is nchouyangcehe nchych)
                {
                    nchych.datagridviewnchych.Rows[0].Cells[1].Value = 10;
                    nchych.datagridviewnchych.Rows[1].Cells[1].Value = 50;
                    nchych.datagridviewnchych.Rows[2].Cells[1].Value = 10;
                    nchych.datagridviewnchych.Rows[3].Cells[1].Value = 50;
                    nchych.datagridviewnchych.Rows[4].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncbanxuan"] is ncbanxuan ncbx)
                {
                    ncbx.datagridviewncbx.Rows[0].Cells[1].Value = 50;
                    ncbx.datagridviewncbx.Rows[1].Cells[1].Value = 10;
                    ncbx.datagridviewncbx.Rows[2].Cells[1].Value = 50;
                    ncbx.datagridviewncbx.Rows[3].Cells[1].Value = 10;
                    ncbx.datagridviewncbx.Rows[4].Cells[1].Value = 50;
                    ncbx.datagridviewncbx.Rows[5].Cells[1].Value = 10;
                    ncbx.datagridviewncbx.Rows[6].Cells[1].Value = 50;
                    ncbx.datagridviewncbx.Rows[7].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncxuanzhuan"] is ncxuanzhuan ncxz)
                {
                    ncxz.datagridviewncxz.Rows[0].Cells[1].Value = 50;
                    ncxz.datagridviewncxz.Rows[1].Cells[1].Value = 10;
                    ncxz.datagridviewncxz.Rows[2].Cells[1].Value = 50;
                    ncxz.datagridviewncxz.Rows[3].Cells[1].Value = 10;
                    ncxz.datagridviewncxz.Rows[4].Cells[1].Value = 50;
                    ncxz.datagridviewncxz.Rows[5].Cells[1].Value = 10;
                    ncxz.datagridviewncxz.Rows[6].Cells[1].Value = 50;
                    ncxz.datagridviewncxz.Rows[7].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncsheshou"] is ncsheshou ncss)
                {
                    ncss.datagridviewncss.Rows[0].Cells[1].Value = 50;
                    ncss.datagridviewncss.Rows[1].Cells[1].Value = 10;
                    ncss.datagridviewncss.Rows[2].Cells[1].Value = 50;
                    ncss.datagridviewncss.Rows[3].Cells[1].Value = 10;
                    ncss.datagridviewncss.Rows[4].Cells[1].Value = 50;
                    ncss.datagridviewncss.Rows[5].Cells[1].Value = 10;
                    ncss.datagridviewncss.Rows[6].Cells[1].Value = 50;
                    ncss.datagridviewncss.Rows[7].Cells[1].Value = 20;
                }
            }
            if (comboBoxhqyc.SelectedItem.ToString() == "自建房通用延迟-慢速[稳定]")
            {
                if (Application.OpenForms["ncsanjiao1"] is ncsanjiao1 ncsj)
                {
                    ncsj.datagridviewncsj1.Rows[0].Cells[1].Value = 50;
                    ncsj.datagridviewncsj1.Rows[1].Cells[1].Value = 20;
                    ncsj.datagridviewncsj1.Rows[2].Cells[1].Value = 50;
                    ncsj.datagridviewncsj1.Rows[3].Cells[1].Value = 20;
                    ncsj.datagridviewncsj1.Rows[4].Cells[1].Value = 50;
                    ncsj.datagridviewncsj1.Rows[5].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncsanjiao2"] is ncsanjiao2 ncsj2)
                {
                    ncsj2.datagridviewncsj2.Rows[0].Cells[1].Value = 50;
                    ncsj2.datagridviewncsj2.Rows[1].Cells[1].Value = 20;
                    ncsj2.datagridviewncsj2.Rows[2].Cells[1].Value = 50;
                    ncsj2.datagridviewncsj2.Rows[3].Cells[1].Value = 20;
                    ncsj2.datagridviewncsj2.Rows[4].Cells[1].Value = 50;
                    ncsj2.datagridviewncsj2.Rows[5].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncsifencehe"] is ncsifencehe ncsfch)
                {
                    ncsfch.datagridviewncsfch.Rows[0].Cells[1].Value = 20;
                    ncsfch.datagridviewncsfch.Rows[1].Cells[1].Value = 20;
                    ncsfch.datagridviewncsfch.Rows[2].Cells[1].Value = 50;
                    ncsfch.datagridviewncsfch.Rows[3].Cells[1].Value = 20;
                }
                if (Application.OpenForms["nczhongfencehe"] is nczhongfencehe nczfch)
                {
                    nczfch.datagridviewnczfch.Rows[0].Cells[1].Value = 20;
                    nczfch.datagridviewnczfch.Rows[1].Cells[1].Value = 50;
                    nczfch.datagridviewnczfch.Rows[2].Cells[1].Value = 20;
                    nczfch.datagridviewnczfch.Rows[3].Cells[1].Value = 50;
                    nczfch.datagridviewnczfch.Rows[4].Cells[1].Value = 20;
                }
                if (Application.OpenForms["nchouyangcehe"] is nchouyangcehe nchych)
                {
                    nchych.datagridviewnchych.Rows[0].Cells[1].Value = 20;
                    nchych.datagridviewnchych.Rows[1].Cells[1].Value = 50;
                    nchych.datagridviewnchych.Rows[2].Cells[1].Value = 20;
                    nchych.datagridviewnchych.Rows[3].Cells[1].Value = 50;
                    nchych.datagridviewnchych.Rows[4].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncbanxuan"] is ncbanxuan ncbx)
                {
                    ncbx.datagridviewncbx.Rows[0].Cells[1].Value = 50;
                    ncbx.datagridviewncbx.Rows[1].Cells[1].Value = 20;
                    ncbx.datagridviewncbx.Rows[2].Cells[1].Value = 50;
                    ncbx.datagridviewncbx.Rows[3].Cells[1].Value = 20;
                    ncbx.datagridviewncbx.Rows[4].Cells[1].Value = 50;
                    ncbx.datagridviewncbx.Rows[5].Cells[1].Value = 20;
                    ncbx.datagridviewncbx.Rows[6].Cells[1].Value = 50;
                    ncbx.datagridviewncbx.Rows[7].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncxuanzhuan"] is ncxuanzhuan ncxz)
                {
                    ncxz.datagridviewncxz.Rows[0].Cells[1].Value = 50;
                    ncxz.datagridviewncxz.Rows[1].Cells[1].Value = 20;
                    ncxz.datagridviewncxz.Rows[2].Cells[1].Value = 50;
                    ncxz.datagridviewncxz.Rows[3].Cells[1].Value = 20;
                    ncxz.datagridviewncxz.Rows[4].Cells[1].Value = 50;
                    ncxz.datagridviewncxz.Rows[5].Cells[1].Value = 20;
                    ncxz.datagridviewncxz.Rows[6].Cells[1].Value = 50;
                    ncxz.datagridviewncxz.Rows[7].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncsheshou"] is ncsheshou ncss)
                {
                    ncss.datagridviewncss.Rows[0].Cells[1].Value = 50;
                    ncss.datagridviewncss.Rows[1].Cells[1].Value = 20;
                    ncss.datagridviewncss.Rows[2].Cells[1].Value = 50;
                    ncss.datagridviewncss.Rows[3].Cells[1].Value = 20;
                    ncss.datagridviewncss.Rows[4].Cells[1].Value = 50;
                    ncss.datagridviewncss.Rows[5].Cells[1].Value = 20;
                    ncss.datagridviewncss.Rows[6].Cells[1].Value = 50;
                    ncss.datagridviewncss.Rows[7].Cells[1].Value = 20;
                }
            }
            if (comboBoxhqyc.SelectedItem.ToString() == "自建房通用延迟-快速[激进]")
            {
                if (Application.OpenForms["ncsanjiao1"] is ncsanjiao1 ncsj)
                {
                    ncsj.datagridviewncsj1.Rows[0].Cells[1].Value = 30;
                    ncsj.datagridviewncsj1.Rows[1].Cells[1].Value = 15;
                    ncsj.datagridviewncsj1.Rows[2].Cells[1].Value = 30;
                    ncsj.datagridviewncsj1.Rows[3].Cells[1].Value = 15;
                    ncsj.datagridviewncsj1.Rows[4].Cells[1].Value = 30;
                    ncsj.datagridviewncsj1.Rows[5].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncsanjiao2"] is ncsanjiao2 ncsj2)
                {
                    ncsj2.datagridviewncsj2.Rows[0].Cells[1].Value = 30;
                    ncsj2.datagridviewncsj2.Rows[1].Cells[1].Value = 15;
                    ncsj2.datagridviewncsj2.Rows[2].Cells[1].Value = 30;
                    ncsj2.datagridviewncsj2.Rows[3].Cells[1].Value = 15;
                    ncsj2.datagridviewncsj2.Rows[4].Cells[1].Value = 30;
                    ncsj2.datagridviewncsj2.Rows[5].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncsifencehe"] is ncsifencehe ncsfch)
                {
                    ncsfch.datagridviewncsfch.Rows[0].Cells[1].Value = 15;
                    ncsfch.datagridviewncsfch.Rows[1].Cells[1].Value = 15;
                    ncsfch.datagridviewncsfch.Rows[2].Cells[1].Value = 30;
                    ncsfch.datagridviewncsfch.Rows[3].Cells[1].Value = 20;
                }
                if (Application.OpenForms["nczhongfencehe"] is nczhongfencehe nczfch)
                {
                    nczfch.datagridviewnczfch.Rows[0].Cells[1].Value = 15;
                    nczfch.datagridviewnczfch.Rows[1].Cells[1].Value = 30;
                    nczfch.datagridviewnczfch.Rows[2].Cells[1].Value = 15;
                    nczfch.datagridviewnczfch.Rows[3].Cells[1].Value = 30;
                    nczfch.datagridviewnczfch.Rows[4].Cells[1].Value = 20;
                }
                if (Application.OpenForms["nchouyangcehe"] is nchouyangcehe nchych)
                {
                    nchych.datagridviewnchych.Rows[0].Cells[1].Value = 15;
                    nchych.datagridviewnchych.Rows[1].Cells[1].Value = 30;
                    nchych.datagridviewnchych.Rows[2].Cells[1].Value = 15;
                    nchych.datagridviewnchych.Rows[3].Cells[1].Value = 30;
                    nchych.datagridviewnchych.Rows[4].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncbanxuan"] is ncbanxuan ncbx)
                {
                    ncbx.datagridviewncbx.Rows[0].Cells[1].Value = 30;
                    ncbx.datagridviewncbx.Rows[1].Cells[1].Value = 15;
                    ncbx.datagridviewncbx.Rows[2].Cells[1].Value = 30;
                    ncbx.datagridviewncbx.Rows[3].Cells[1].Value = 15;
                    ncbx.datagridviewncbx.Rows[4].Cells[1].Value = 30;
                    ncbx.datagridviewncbx.Rows[5].Cells[1].Value = 15;
                    ncbx.datagridviewncbx.Rows[6].Cells[1].Value = 30;
                    ncbx.datagridviewncbx.Rows[7].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncxuanzhuan"] is ncxuanzhuan ncxz)
                {
                    ncxz.datagridviewncxz.Rows[0].Cells[1].Value = 30;
                    ncxz.datagridviewncxz.Rows[1].Cells[1].Value = 15;
                    ncxz.datagridviewncxz.Rows[2].Cells[1].Value = 30;
                    ncxz.datagridviewncxz.Rows[3].Cells[1].Value = 15;
                    ncxz.datagridviewncxz.Rows[4].Cells[1].Value = 30;
                    ncxz.datagridviewncxz.Rows[5].Cells[1].Value = 15;
                    ncxz.datagridviewncxz.Rows[6].Cells[1].Value = 30;
                    ncxz.datagridviewncxz.Rows[7].Cells[1].Value = 20;
                }
                if (Application.OpenForms["ncsheshou"] is ncsheshou ncss)
                {
                    ncss.datagridviewncss.Rows[0].Cells[1].Value = 30;
                    ncss.datagridviewncss.Rows[1].Cells[1].Value = 15;
                    ncss.datagridviewncss.Rows[2].Cells[1].Value = 30;
                    ncss.datagridviewncss.Rows[3].Cells[1].Value = 15;
                    ncss.datagridviewncss.Rows[4].Cells[1].Value = 30;
                    ncss.datagridviewncss.Rows[5].Cells[1].Value = 15;
                    ncss.datagridviewncss.Rows[6].Cells[1].Value = 30;
                    ncss.datagridviewncss.Rows[7].Cells[1].Value = 20;
                }
            }
        }

        private void textBoxyaogandaxiao_TextChanged(object sender, EventArgs e)
        {
            Json.writejson("yaogandaxiao", textBoxyaogandaxiao.Text);
            try
            {
                ygdx = float.Parse(textBoxyaogandaxiao.Text);
            }
            catch (Exception ex)
            {
                ygdx = 1.6f;
            }
        }

        private void textBoxyaogandaxiao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }

        private void comboBoxfenshen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxfenshen.SelectedItem != null)
            {
                neicunheqiu.fenshenjian = (byte)GetVirtualKeyCode(comboBoxfenshen.SelectedItem.ToString());
                //quanjufenshenjian = (byte)GetVirtualKeyCode(comboBoxfenshen.SelectedItem.ToString());
            }
            Json.writejson("fenshenjian", comboBoxfenshen.SelectedItem.ToString());
        }

        private void comboBoxtuqiu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxtuqiu.SelectedItem != null)
            {
                neicunheqiu.tuqiujian = (byte)GetVirtualKeyCode(comboBoxtuqiu.SelectedItem.ToString());
            }
            Json.writejson("tuqiujian", comboBoxtuqiu.SelectedItem.ToString());
        }

        private void buttondaorupz_Click(object sender, EventArgs e)
        {
            DialogResult rs = openFileDialog1.ShowDialog();
            if (rs == DialogResult.OK)
            {
                MainForm.filePath = openFileDialog1.FileName;
            }
            daorupeizhi();
        }

        private void buttondaochupz_Click(object sender, EventArgs e)
        {
            DialogResult rs = saveFileDialog1.ShowDialog();
            if (rs == DialogResult.OK)
            {
                if (!File.Exists(saveFileDialog1.FileName))
                {
                    try
                    {
                        using (FileStream fs = File.Create(saveFileDialog1.FileName)) { }
                        ;
                        File.WriteAllBytes(saveFileDialog1.FileName, File.ReadAllBytes(MainForm.filePath));
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }

        void daorupeizhi()
        {
            if (Application.OpenForms["neicungongneng"] is neicungongneng ncck)
            {
                if (Json.checkjson("gunlunzuixiaozhi"))
                {
                    ncck.textboxshiyemin.Text = Json.readjson("gunlunzuixiaozhi");
                }
                else
                {
                    ncck.textboxshiyemin.Text = "1.0";
                }
                if (Json.checkjson("gunlunzuidazhi"))
                {
                    ncck.textboxshiyemax.Text = Json.readjson("gunlunzuidazhi");
                }
                else
                {
                    ncck.textboxshiyemax.Text = "10.0";
                }
                if (Json.checkjson("buchang"))
                {
                    ncck.textboxshiyebuchang.Text = Json.readjson("buchang");
                }
                else
                {
                    ncck.textboxshiyebuchang.Text = "0.5";
                }
            }
            if (Application.OpenForms["ncbanxuan"] is ncbanxuan ncbx)
            {
                if (!Json.checkjson("ncbanxuanjian"))
                {
                    ncbx.comboboxncbanxuan.SelectedItem = "A";
                }
                else
                {
                    ncbx.comboboxncbanxuan.SelectedItem = Json.readjson("ncbanxuanjian");
                }
                if (!Json.checkjson("ncbxjcfd1"))
                {
                    ncbx.textboxncbxjcfd1.Text = "100";
                }
                else
                {
                    ncbx.textboxncbxjcfd1.Text = Json.readjson("ncbxjcfd1");
                }
                if (!Json.checkjson("ncbxjcfd2"))
                {
                    ncbx.textboxncbxjcfd2.Text = "100";
                }
                else
                {
                    ncbx.textboxncbxjcfd2.Text = Json.readjson("ncbxjcfd2");
                }
                if (!Json.checkjson("ncbxjcfd3"))
                {
                    ncbx.textboxncbxjcfd3.Text = "120";
                }
                else
                {
                    ncbx.textboxncbxjcfd3.Text = Json.readjson("ncbxjcfd3");
                }
                if (!Json.checkjson("ncbxjcfd4"))
                {
                    ncbx.textboxncbxjcfd4.Text = "120";
                }
                else
                {
                    ncbx.textboxncbxjcfd4.Text = Json.readjson("ncbxjcfd4");
                }
                if (!Json.checkjson("ncbxjd1"))
                {
                    ncbx.textboxncbxjd1.Text = "5";
                }
                else
                {
                    ncbx.textboxncbxjd1.Text = Json.readjson("ncbxjd1");
                }
                if (!Json.checkjson("ncbxjd2"))
                {
                    ncbx.textboxncbxjd2.Text = "20";
                }
                else
                {
                    ncbx.textboxncbxjd2.Text = Json.readjson("ncbxjd2");
                }
                if (!Json.checkjson("ncbxjd3"))
                {
                    ncbx.textboxncbxjd3.Text = "25";
                }
                else
                {
                    ncbx.textboxncbxjd3.Text = Json.readjson("ncbxjd3");
                }
                if (!Json.checkjson("ncbxjd4"))
                {
                    ncbx.textboxncbxjd4.Text = "25";
                }
                else
                {
                    ncbx.textboxncbxjd4.Text = Json.readjson("ncbxjd4");
                }
                if (!Json.checkjson("ncbxyc1"))
                {
                    ncbx.datagridviewncbx.Rows.Add("第一次拖动鼠标", 50);
                    ncbx.datagridviewncbx.Rows.Add("分身", 10);
                    ncbx.datagridviewncbx.Rows.Add("第二次拖动鼠标", 50);
                    ncbx.datagridviewncbx.Rows.Add("分身", 10);
                    ncbx.datagridviewncbx.Rows.Add("第三次拖动鼠标", 50);
                    ncbx.datagridviewncbx.Rows.Add("分身", 10);
                    ncbx.datagridviewncbx.Rows.Add("第四次拖动鼠标", 50);
                    ncbx.datagridviewncbx.Rows.Add("最后分身延迟", 20);
                }
                else
                {
                    ncbx.datagridviewncbx.Rows.Add("第一次拖动鼠标", Json.readjson("ncbxyc1"));
                    ncbx.datagridviewncbx.Rows.Add("分身", Json.readjson("ncbxyc2"));
                    ncbx.datagridviewncbx.Rows.Add("第二次拖动鼠标", Json.readjson("ncbxyc3"));
                    ncbx.datagridviewncbx.Rows.Add("分身", Json.readjson("ncbxyc4"));
                    ncbx.datagridviewncbx.Rows.Add("第三次拖动鼠标", Json.readjson("ncbxyc5"));
                    ncbx.datagridviewncbx.Rows.Add("分身", Json.readjson("ncbxyc6"));
                    ncbx.datagridviewncbx.Rows.Add("第四次拖动鼠标", Json.readjson("ncbxyc7"));
                    ncbx.datagridviewncbx.Rows.Add("最后分身延迟", Json.readjson("ncbxyc8"));
                }
                neicunheqiu.ncbanxuanjian = MainForm.GetVirtualKeyCode(ncbx.comboboxncbanxuan.SelectedItem.ToString());
                try
                {
                    neicunheqiu.ncbxjcfd1 = Convert.ToInt32(ncbx.textboxncbxjcfd1.Text);
                    neicunheqiu.ncbxjcfd2 = Convert.ToInt32(ncbx.textboxncbxjcfd2.Text);
                    neicunheqiu.ncbxjcfd3 = Convert.ToInt32(ncbx.textboxncbxjcfd3.Text);
                    neicunheqiu.ncbxjcfd4 = Convert.ToInt32(ncbx.textboxncbxjcfd4.Text);
                    neicunheqiu.ncbxjd1 = Convert.ToInt32(ncbx.textboxncbxjd1.Text);
                    neicunheqiu.ncbxjd2 = Convert.ToInt32(ncbx.textboxncbxjd2.Text);
                    neicunheqiu.ncbxjd3 = Convert.ToInt32(ncbx.textboxncbxjd3.Text);
                    neicunheqiu.ncbxjd4 = Convert.ToInt32(ncbx.textboxncbxjd4.Text);
                    neicunheqiu.ncbxyc1 = int.Parse(ncbx.datagridviewncbx.Rows[0].Cells[1].Value.ToString());
                    neicunheqiu.ncbxyc2 = int.Parse(ncbx.datagridviewncbx.Rows[1].Cells[1].Value.ToString());
                    neicunheqiu.ncbxyc3 = int.Parse(ncbx.datagridviewncbx.Rows[2].Cells[1].Value.ToString());
                    neicunheqiu.ncbxyc4 = int.Parse(ncbx.datagridviewncbx.Rows[3].Cells[1].Value.ToString());
                    neicunheqiu.ncbxyc5 = int.Parse(ncbx.datagridviewncbx.Rows[4].Cells[1].Value.ToString());
                    neicunheqiu.ncbxyc6 = int.Parse(ncbx.datagridviewncbx.Rows[5].Cells[1].Value.ToString());
                    neicunheqiu.ncbxyc7 = int.Parse(ncbx.datagridviewncbx.Rows[6].Cells[1].Value.ToString());
                    neicunheqiu.ncbxyc8 = int.Parse(ncbx.datagridviewncbx.Rows[7].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                if (Json.checkjson("ncbanxuan"))
                {
                    if (Json.readjson("ncbanxuan") == "true")
                    {
                        ncbx.checkboxncbanxuan.Checked = true;
                    }
                }
            }
            if (Application.OpenForms["ncxuanzhuan"] is ncxuanzhuan ncxz)
            {
                if (!Json.checkjson("ncxuanzhuanjian"))
                {
                    ncxz.comboboxncxuanzhuan.SelectedItem = "A";
                }
                else
                {
                    ncxz.comboboxncxuanzhuan.SelectedItem = Json.readjson("ncxuanzhuanjian");
                }
                if (!Json.checkjson("ncxzjcfd1"))
                {
                    ncxz.textboxncxzjcfd1.Text = "90";
                }
                else
                {
                    ncxz.textboxncxzjcfd1.Text = Json.readjson("ncxzjcfd1");
                }
                if (!Json.checkjson("ncxzjcfd2"))
                {
                    ncxz.textboxncxzjcfd2.Text = "85";
                }
                else
                {
                    ncxz.textboxncxzjcfd2.Text = Json.readjson("ncxzjcfd2");
                }
                if (!Json.checkjson("ncxzjcfd3"))
                {
                    ncxz.textboxncxzjcfd3.Text = "75";
                }
                else
                {
                    ncxz.textboxncxzjcfd3.Text = Json.readjson("ncxzjcfd3");
                }
                if (!Json.checkjson("ncxzjcfd4"))
                {
                    ncxz.textboxncxzjcfd4.Text = "70";
                }
                else
                {
                    ncxz.textboxncxzjcfd4.Text = Json.readjson("ncxzjcfd4");
                }
                if (!Json.checkjson("ncxzjd1"))
                {
                    ncxz.textboxncxzjd1.Text = "20";
                }
                else
                {
                    ncxz.textboxncxzjd1.Text = Json.readjson("ncxzjd1");
                }
                if (!Json.checkjson("ncxzjd2"))
                {
                    ncxz.textboxncxzjd2.Text = "25";
                }
                else
                {
                    ncxz.textboxncxzjd2.Text = Json.readjson("ncxzjd2");
                }
                if (!Json.checkjson("ncxzjd3"))
                {
                    ncxz.textboxncxzjd3.Text = "25";
                }
                else
                {
                    ncxz.textboxncxzjd3.Text = Json.readjson("ncxzjd3");
                }
                if (!Json.checkjson("ncxzjd4"))
                {
                    ncxz.textboxncxzjd4.Text = "40";
                }
                else
                {
                    ncxz.textboxncxzjd4.Text = Json.readjson("ncxzjd4");
                }
                if (!Json.checkjson("ncxzyc1"))
                {
                    ncxz.datagridviewncxz.Rows.Add("第一次拖动鼠标", 50);
                    ncxz.datagridviewncxz.Rows.Add("分身", 10);
                    ncxz.datagridviewncxz.Rows.Add("第二次拖动鼠标", 50);
                    ncxz.datagridviewncxz.Rows.Add("分身", 10);
                    ncxz.datagridviewncxz.Rows.Add("第三次拖动鼠标", 50);
                    ncxz.datagridviewncxz.Rows.Add("分身", 10);
                    ncxz.datagridviewncxz.Rows.Add("第四次拖动鼠标", 50);
                    ncxz.datagridviewncxz.Rows.Add("最后分身延迟", 20);
                }
                else
                {
                    ncxz.datagridviewncxz.Rows.Add("第一次拖动鼠标", Json.readjson("ncxzyc1"));
                    ncxz.datagridviewncxz.Rows.Add("分身", Json.readjson("ncxzyc2"));
                    ncxz.datagridviewncxz.Rows.Add("第二次拖动鼠标", Json.readjson("ncxzyc3"));
                    ncxz.datagridviewncxz.Rows.Add("分身", Json.readjson("ncxzyc4"));
                    ncxz.datagridviewncxz.Rows.Add("第三次拖动鼠标", Json.readjson("ncxzyc5"));
                    ncxz.datagridviewncxz.Rows.Add("分身", Json.readjson("ncxzyc6"));
                    ncxz.datagridviewncxz.Rows.Add("第四次拖动鼠标", Json.readjson("ncxzyc7"));
                    ncxz.datagridviewncxz.Rows.Add("最后分身延迟", Json.readjson("ncxzyc8"));
                }
                neicunheqiu.ncxuanzhuanjian = MainForm.GetVirtualKeyCode(ncxz.comboboxncxuanzhuan.SelectedItem.ToString());
                try
                {
                    neicunheqiu.ncxzjcfd1 = Convert.ToInt32(ncxz.textboxncxzjcfd1.Text);
                    neicunheqiu.ncxzjcfd2 = Convert.ToInt32(ncxz.textboxncxzjcfd2.Text);
                    neicunheqiu.ncxzjcfd3 = Convert.ToInt32(ncxz.textboxncxzjcfd3.Text);
                    neicunheqiu.ncxzjcfd4 = Convert.ToInt32(ncxz.textboxncxzjcfd4.Text);
                    neicunheqiu.ncxzjd1 = Convert.ToInt32(ncxz.textboxncxzjd1.Text);
                    neicunheqiu.ncxzjd2 = Convert.ToInt32(ncxz.textboxncxzjd2.Text);
                    neicunheqiu.ncxzjd3 = Convert.ToInt32(ncxz.textboxncxzjd3.Text);
                    neicunheqiu.ncxzjd4 = Convert.ToInt32(ncxz.textboxncxzjd4.Text);
                    neicunheqiu.ncxzyc1 = int.Parse(ncxz.datagridviewncxz.Rows[0].Cells[1].Value.ToString());
                    neicunheqiu.ncxzyc2 = int.Parse(ncxz.datagridviewncxz.Rows[1].Cells[1].Value.ToString());
                    neicunheqiu.ncxzyc3 = int.Parse(ncxz.datagridviewncxz.Rows[2].Cells[1].Value.ToString());
                    neicunheqiu.ncxzyc4 = int.Parse(ncxz.datagridviewncxz.Rows[3].Cells[1].Value.ToString());
                    neicunheqiu.ncxzyc5 = int.Parse(ncxz.datagridviewncxz.Rows[4].Cells[1].Value.ToString());
                    neicunheqiu.ncxzyc6 = int.Parse(ncxz.datagridviewncxz.Rows[5].Cells[1].Value.ToString());
                    neicunheqiu.ncxzyc7 = int.Parse(ncxz.datagridviewncxz.Rows[6].Cells[1].Value.ToString());
                    neicunheqiu.ncxzyc8 = int.Parse(ncxz.datagridviewncxz.Rows[7].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                if (Json.checkjson("ncxuanzhuan"))
                {
                    if (Json.readjson("ncxuanzhuan") == "true")
                    {
                        ncxz.checkboxncxuanzhuan.Checked = true;
                    }
                }
            }
            if (Application.OpenForms["ncsheshou"] is ncsheshou ncss)
            {
                if (!Json.checkjson("ncsheshoujian"))
                {
                    ncss.comboboxncsheshou.SelectedItem = "A";
                }
                else
                {
                    ncss.comboboxncsheshou.SelectedItem = Json.readjson("ncsheshoujian");
                }
                if (!Json.checkjson("ncssjcfd1"))
                {
                    ncss.textboxncssjcfd1.Text = "135";
                }
                else
                {
                    ncss.textboxncssjcfd1.Text = Json.readjson("ncssjcfd1");
                }
                if (!Json.checkjson("ncssjcfd2"))
                {
                    ncss.textboxncssjcfd2.Text = "135";
                }
                else
                {
                    ncss.textboxncssjcfd2.Text = Json.readjson("ncssjcfd2");
                }
                if (!Json.checkjson("ncssjcfd3"))
                {
                    ncss.textboxncssjcfd3.Text = "100";
                }
                else
                {
                    ncss.textboxncssjcfd3.Text = Json.readjson("ncssjcfd3");
                }
                if (!Json.checkjson("ncssjcfd4"))
                {
                    ncss.textboxncssjcfd4.Text = "150";
                }
                else
                {
                    ncss.textboxncssjcfd4.Text = Json.readjson("ncssjcfd4");
                }
                if (!Json.checkjson("ncssjd1"))
                {
                    ncss.textboxncssjd1.Text = "0";
                }
                else
                {
                    ncss.textboxncssjd1.Text = Json.readjson("ncssjd1");
                }
                if (!Json.checkjson("ncssjd2"))
                {
                    ncss.textboxncssjd2.Text = "60";
                }
                else
                {
                    ncss.textboxncssjd2.Text = Json.readjson("ncssjd2");
                }
                if (!Json.checkjson("ncssjd3"))
                {
                    ncss.textboxncssjd3.Text = "-50";
                }
                else
                {
                    ncss.textboxncssjd3.Text = Json.readjson("ncssjd3");
                }
                if (!Json.checkjson("ncssjd4"))
                {
                    ncss.textboxncssjd4.Text = "0";
                }
                else
                {
                    ncss.textboxncssjd4.Text = Json.readjson("ncssjd4");
                }
                if (!Json.checkjson("ncssyc1"))
                {
                    ncss.datagridviewncss.Rows.Add("第一次拖动鼠标", 50);
                    ncss.datagridviewncss.Rows.Add("分身", 10);
                    ncss.datagridviewncss.Rows.Add("第二次拖动鼠标", 50);
                    ncss.datagridviewncss.Rows.Add("分身", 10);
                    ncss.datagridviewncss.Rows.Add("第三次拖动鼠标", 50);
                    ncss.datagridviewncss.Rows.Add("分身", 10);
                    ncss.datagridviewncss.Rows.Add("第四次拖动鼠标", 50);
                    ncss.datagridviewncss.Rows.Add("最后分身延迟", 20);
                }
                else
                {
                    ncss.datagridviewncss.Rows.Add("第一次拖动鼠标", Json.readjson("ncssyc1"));
                    ncss.datagridviewncss.Rows.Add("分身", Json.readjson("ncssyc2"));
                    ncss.datagridviewncss.Rows.Add("第二次拖动鼠标", Json.readjson("ncssyc3"));
                    ncss.datagridviewncss.Rows.Add("分身", Json.readjson("ncssyc4"));
                    ncss.datagridviewncss.Rows.Add("第三次拖动鼠标", Json.readjson("ncssyc5"));
                    ncss.datagridviewncss.Rows.Add("分身", Json.readjson("ncssyc6"));
                    ncss.datagridviewncss.Rows.Add("第四次拖动鼠标", Json.readjson("ncssyc7"));
                    ncss.datagridviewncss.Rows.Add("最后分身延迟", Json.readjson("ncssyc8"));
                }
                neicunheqiu.ncsheshoujian = MainForm.GetVirtualKeyCode(ncss.comboboxncsheshou.SelectedItem.ToString());
                try
                {
                    neicunheqiu.ncssjcfd1 = Convert.ToInt32(ncss.textboxncssjcfd1.Text);
                    neicunheqiu.ncssjcfd2 = Convert.ToInt32(ncss.textboxncssjcfd2.Text);
                    neicunheqiu.ncssjcfd3 = Convert.ToInt32(ncss.textboxncssjcfd3.Text);
                    neicunheqiu.ncssjcfd4 = Convert.ToInt32(ncss.textboxncssjcfd4.Text);
                    neicunheqiu.ncssjd1 = Convert.ToInt32(ncss.textboxncssjd1.Text);
                    neicunheqiu.ncssjd2 = Convert.ToInt32(ncss.textboxncssjd2.Text);
                    neicunheqiu.ncssjd3 = Convert.ToInt32(ncss.textboxncssjd3.Text);
                    neicunheqiu.ncssjd4 = Convert.ToInt32(ncss.textboxncssjd4.Text);
                    neicunheqiu.ncssyc1 = int.Parse(ncss.datagridviewncss.Rows[0].Cells[1].Value.ToString());
                    neicunheqiu.ncssyc2 = int.Parse(ncss.datagridviewncss.Rows[1].Cells[1].Value.ToString());
                    neicunheqiu.ncssyc3 = int.Parse(ncss.datagridviewncss.Rows[2].Cells[1].Value.ToString());
                    neicunheqiu.ncssyc4 = int.Parse(ncss.datagridviewncss.Rows[3].Cells[1].Value.ToString());
                    neicunheqiu.ncssyc5 = int.Parse(ncss.datagridviewncss.Rows[4].Cells[1].Value.ToString());
                    neicunheqiu.ncssyc6 = int.Parse(ncss.datagridviewncss.Rows[5].Cells[1].Value.ToString());
                    neicunheqiu.ncssyc7 = int.Parse(ncss.datagridviewncss.Rows[6].Cells[1].Value.ToString());
                    neicunheqiu.ncssyc8 = int.Parse(ncss.datagridviewncss.Rows[7].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                if (Json.checkjson("ncsheshou"))
                {
                    if (Json.readjson("ncsheshou") == "true")
                    {
                        ncss.checkboxncsheshou.Checked = true;
                    }
                }
            }
            if (Application.OpenForms["ncsanjiao1"] is ncsanjiao1 ncsj1)
            {
                if (!Json.checkjson("ncsanjiaojian"))
                {
                    ncsj1.comboboxncsanjiao1.SelectedItem = "A";
                }
                else
                {
                    ncsj1.comboboxncsanjiao1.SelectedItem = Json.readjson("ncsanjiaojian");
                }
                if (!Json.checkjson("ncsjjcfd"))
                {
                    ncsj1.textboxncsj1jcfd.Text = "100";
                }
                else
                {
                    ncsj1.textboxncsj1jcfd.Text = Json.readjson("ncsjjcfd");
                }
                if (!Json.checkjson("ncsjjd"))
                {
                    ncsj1.textboxncsj1jd.Text = "180";
                }
                else
                {
                    ncsj1.textboxncsj1jd.Text = Json.readjson("ncsjjd");
                }
                if (!Json.checkjson("ncsjyc1"))
                {
                    ncsj1.datagridviewncsj1.Rows.Add("第一次拖动鼠标", 50);
                    ncsj1.datagridviewncsj1.Rows.Add("分身", 10);
                    ncsj1.datagridviewncsj1.Rows.Add("第二次拖动鼠标", 50);
                    ncsj1.datagridviewncsj1.Rows.Add("分身", 10);
                    ncsj1.datagridviewncsj1.Rows.Add("第三次拖动鼠标", 50);
                    ncsj1.datagridviewncsj1.Rows.Add("最后分身延迟", 20);
                }
                else
                {
                    ncsj1.datagridviewncsj1.Rows.Add("第一次拖动鼠标", Json.readjson("ncsjyc1"));
                    ncsj1.datagridviewncsj1.Rows.Add("分身", Json.readjson("ncsjyc2"));
                    ncsj1.datagridviewncsj1.Rows.Add("第二次拖动鼠标", Json.readjson("ncsjyc3"));
                    ncsj1.datagridviewncsj1.Rows.Add("分身", Json.readjson("ncsjyc4"));
                    ncsj1.datagridviewncsj1.Rows.Add("第三次拖动鼠标", Json.readjson("ncsjyc5"));
                    ncsj1.datagridviewncsj1.Rows.Add("最后分身延迟", Json.readjson("ncsjyc6"));
                }
                try
                {
                    neicunheqiu.ncsanjiaojcfd = Convert.ToInt32(ncsj1.textboxncsj1jcfd.Text);
                    neicunheqiu.ncsanjiaojd = Convert.ToInt32(ncsj1.textboxncsj1jd.Text);
                    neicunheqiu.ncsanjiaojian = MainForm.GetVirtualKeyCode(ncsj1.comboboxncsanjiao1.SelectedItem.ToString());
                }
                catch
                {

                }
                try
                {
                    neicunheqiu.ncsjyc1 = int.Parse(ncsj1.datagridviewncsj1.Rows[0].Cells[1].Value.ToString());
                    neicunheqiu.ncsjyc2 = int.Parse(ncsj1.datagridviewncsj1.Rows[1].Cells[1].Value.ToString());
                    neicunheqiu.ncsjyc3 = int.Parse(ncsj1.datagridviewncsj1.Rows[2].Cells[1].Value.ToString());
                    neicunheqiu.ncsjyc4 = int.Parse(ncsj1.datagridviewncsj1.Rows[3].Cells[1].Value.ToString());
                    neicunheqiu.ncsjyc5 = int.Parse(ncsj1.datagridviewncsj1.Rows[4].Cells[1].Value.ToString());
                    neicunheqiu.ncsjyc6 = int.Parse(ncsj1.datagridviewncsj1.Rows[5].Cells[1].Value.ToString());

                }
                catch
                {

                }

                if (Json.checkjson("ncsanjiao"))
                {
                    if (Json.readjson("ncsanjiao") == "true")
                    {
                        ncsj1.checkboxncsanjiao1.Checked = true;
                    }
                }
                if (Json.checkjson("ncsanjiaojiantou"))
                {
                    if (Json.readjson("ncsanjiaojiantou") == "true")
                    {
                        ncsj1.checkboxncsanjiao1.Checked = true;
                    }
                }
            }
            if (Application.OpenForms["ncsanjiao2"] is ncsanjiao2 ncsj2)
            {
                if (!Json.checkjson("ncsanjiao2jian"))
                {
                    ncsj2.comboboxncsanjiao2.SelectedItem = "A";
                }
                else
                {
                    ncsj2.comboboxncsanjiao2.SelectedItem = Json.readjson("ncsanjiao2jian");
                }
                if (!Json.checkjson("ncsj2jcfd"))
                {
                    ncsj2.textboxncsj2jcfd.Text = "100";
                }
                else
                {
                    ncsj2.textboxncsj2jcfd.Text = Json.readjson("ncsj2jcfd");
                }
                if (!Json.checkjson("ncsj2jd"))
                {
                    ncsj2.textboxncsj2jd.Text = "160";
                }
                else
                {
                    ncsj2.textboxncsj2jd.Text = Json.readjson("ncsj2jd");
                }
                if (!Json.checkjson("ncsj2yc1"))
                {
                    ncsj2.datagridviewncsj2.Rows.Add("第一次拖动鼠标", 50);
                    ncsj2.datagridviewncsj2.Rows.Add("分身", 10);
                    ncsj2.datagridviewncsj2.Rows.Add("第二次拖动鼠标", 50);
                    ncsj2.datagridviewncsj2.Rows.Add("分身", 10);
                    ncsj2.datagridviewncsj2.Rows.Add("第三次拖动鼠标", 50);
                    ncsj2.datagridviewncsj2.Rows.Add("最后分身延迟", 20);
                }
                else
                {
                    ncsj2.datagridviewncsj2.Rows.Add("第一次拖动鼠标", Json.readjson("ncsj2yc1"));
                    ncsj2.datagridviewncsj2.Rows.Add("分身", Json.readjson("ncsj2yc2"));
                    ncsj2.datagridviewncsj2.Rows.Add("第二次拖动鼠标", Json.readjson("ncsj2yc3"));
                    ncsj2.datagridviewncsj2.Rows.Add("分身", Json.readjson("ncsj2yc4"));
                    ncsj2.datagridviewncsj2.Rows.Add("第三次拖动鼠标", Json.readjson("ncsj2yc5"));
                    ncsj2.datagridviewncsj2.Rows.Add("最后分身延迟", Json.readjson("ncsj2yc6"));
                }
                try
                {
                    neicunheqiu.ncsanjiao2jcfd = Convert.ToInt32(ncsj2.textboxncsj2jcfd.Text);
                    neicunheqiu.ncsanjiao2jd = Convert.ToInt32(ncsj2.textboxncsj2jd.Text);
                    neicunheqiu.ncsanjiao2jian = MainForm.GetVirtualKeyCode(ncsj2.comboboxncsanjiao2.SelectedItem.ToString());
                }
                catch
                {

                }
                try
                {
                    neicunheqiu.ncsj2yc1 = int.Parse(ncsj2.datagridviewncsj2.Rows[0].Cells[1].Value.ToString());
                    neicunheqiu.ncsj2yc2 = int.Parse(ncsj2.datagridviewncsj2.Rows[1].Cells[1].Value.ToString());
                    neicunheqiu.ncsj2yc3 = int.Parse(ncsj2.datagridviewncsj2.Rows[2].Cells[1].Value.ToString());
                    neicunheqiu.ncsj2yc4 = int.Parse(ncsj2.datagridviewncsj2.Rows[3].Cells[1].Value.ToString());
                    neicunheqiu.ncsj2yc5 = int.Parse(ncsj2.datagridviewncsj2.Rows[4].Cells[1].Value.ToString());
                    neicunheqiu.ncsj2yc6 = int.Parse(ncsj2.datagridviewncsj2.Rows[5].Cells[1].Value.ToString());

                }
                catch
                {

                }

                if (Json.checkjson("ncsanjiao2"))
                {
                    if (Json.readjson("ncsanjiao2") == "true")
                    {
                        ncsj2.checkboxncsanjiao2.Checked = true;
                    }
                }
                if (Json.checkjson("ncsanjiao2jiantou"))
                {
                    if (Json.readjson("ncsanjiao2jiantou") == "true")
                    {
                        ncsj2.checkboxncsanjiao2.Checked = true;
                    }
                }
            }
            if (Application.OpenForms["ncsifencehe"] is ncsifencehe ncsfch)
            {
                if (!Json.checkjson("ncsifencehejian"))
                {
                    ncsfch.comboboxncsifencehe.SelectedItem = "A";
                }
                else
                {
                    ncsfch.comboboxncsifencehe.SelectedItem = Json.readjson("ncsifencehejian");
                }
                if (!Json.checkjson("ncsfchjcfd"))
                {
                    ncsfch.textboxncsfchjcfd.Text = "100";
                }
                else
                {
                    ncsfch.textboxncsfchjcfd.Text = Json.readjson("ncsfchjcfd");
                }
                if (!Json.checkjson("ncsfchyc1"))
                {
                    ncsfch.datagridviewncsfch.Rows.Add("分身", 10);
                    ncsfch.datagridviewncsfch.Rows.Add("分身", 10);
                    ncsfch.datagridviewncsfch.Rows.Add("第一次拖动鼠标", 50);
                    ncsfch.datagridviewncsfch.Rows.Add("最后分身延迟", 20);
                }
                else
                {
                    ncsfch.datagridviewncsfch.Rows.Add("分身", Json.readjson("ncsfchyc1"));
                    ncsfch.datagridviewncsfch.Rows.Add("分身", Json.readjson("ncsfchyc2"));
                    ncsfch.datagridviewncsfch.Rows.Add("第一次拖动鼠标", Json.readjson("ncsfchyc3"));
                    ncsfch.datagridviewncsfch.Rows.Add("最后分身延迟", Json.readjson("ncsfchyc4"));
                }
                neicunheqiu.ncsifencehejian = MainForm.GetVirtualKeyCode(ncsfch.comboboxncsifencehe.SelectedItem.ToString());
                try
                {
                    neicunheqiu.ncsifencehejcfd = Convert.ToInt32(ncsfch.textboxncsfchjcfd.Text);
                    neicunheqiu.ncsfchyc1 = int.Parse(ncsfch.datagridviewncsfch.Rows[0].Cells[1].Value.ToString());
                    neicunheqiu.ncsfchyc2 = int.Parse(ncsfch.datagridviewncsfch.Rows[1].Cells[1].Value.ToString());
                    neicunheqiu.ncsfchyc3 = int.Parse(ncsfch.datagridviewncsfch.Rows[2].Cells[1].Value.ToString());
                    neicunheqiu.ncsfchyc4 = int.Parse(ncsfch.datagridviewncsfch.Rows[3].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                if (Json.checkjson("ncsifencehe"))
                {
                    if (Json.readjson("ncsifencehe") == "true")
                    {
                        ncsfch.checkboxncsifencehe.Checked = true;
                    }
                }
            }
            if (Application.OpenForms["nczhongfencehe"] is nczhongfencehe nczfch)
            {
                if (!Json.checkjson("ncyuandijian"))
                {
                    nczfch.comboboxnczhongfencehe.SelectedItem = "A";
                }
                else
                {
                    nczfch.comboboxnczhongfencehe.SelectedItem = Json.readjson("ncyuandijian");
                }
                if (!Json.checkjson("ncydjcfd"))
                {
                    nczfch.textboxnczfchjcfd.Text = "100";
                }
                else
                {
                    nczfch.textboxnczfchjcfd.Text = Json.readjson("ncydjcfd");
                }
                if (!Json.checkjson("ncydhqyc1"))
                {
                    nczfch.datagridviewnczfch.Rows.Add("分身", 10);
                    nczfch.datagridviewnczfch.Rows.Add("第二次拖动鼠标", 50);
                    nczfch.datagridviewnczfch.Rows.Add("分身", 10);
                    nczfch.datagridviewnczfch.Rows.Add("第三次拖动鼠标", 50);
                    nczfch.datagridviewnczfch.Rows.Add("最后分身延迟", 20);
                }
                else
                {
                    nczfch.datagridviewnczfch.Rows.Add("分身", Json.readjson("ncydhqyc1"));
                    nczfch.datagridviewnczfch.Rows.Add("第二次拖动鼠标", Json.readjson("ncydhqyc2"));
                    nczfch.datagridviewnczfch.Rows.Add("分身", Json.readjson("ncydhqyc3"));
                    nczfch.datagridviewnczfch.Rows.Add("第三次拖动鼠标", Json.readjson("ncydhqyc4"));
                    nczfch.datagridviewnczfch.Rows.Add("最后分身延迟", Json.readjson("ncydhqyc5"));
                }
                neicunheqiu.ncyuandiheqiujian = MainForm.GetVirtualKeyCode(nczfch.comboboxnczhongfencehe.SelectedItem.ToString());
                try
                {
                    neicunheqiu.ncyuandiheqiujcfd = Convert.ToInt32(nczfch.textboxnczfchjcfd.Text);
                    neicunheqiu.ncydhqyc1 = int.Parse(nczfch.datagridviewnczfch.Rows[0].Cells[1].Value.ToString());
                    neicunheqiu.ncydhqyc2 = int.Parse(nczfch.datagridviewnczfch.Rows[1].Cells[1].Value.ToString());
                    neicunheqiu.ncydhqyc3 = int.Parse(nczfch.datagridviewnczfch.Rows[2].Cells[1].Value.ToString());
                    neicunheqiu.ncydhqyc4 = int.Parse(nczfch.datagridviewnczfch.Rows[3].Cells[1].Value.ToString());
                    neicunheqiu.ncydhqyc5 = int.Parse(nczfch.datagridviewnczfch.Rows[4].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                if (Json.checkjson("ncyuandi"))
                {
                    if (Json.readjson("ncyuandi") == "true")
                    {
                        nczfch.checkboxnczhongfencehe.Checked = true;
                    }
                }
            }
            if (Application.OpenForms["nchouyangcehe"] is nchouyangcehe nchych)
            {
                if (!Json.checkjson("nchouyangjian"))
                {
                    nchych.comboboxnchouyangcehe.SelectedItem = "A";
                }
                else
                {
                    nchych.comboboxnchouyangcehe.SelectedItem = Json.readjson("nchouyangjian");
                }
                if (!Json.checkjson("nchyjcfd"))
                {
                    nchych.textboxnchychjcfd.Text = "120";
                }
                else
                {
                    nchych.textboxnchychjcfd.Text = Json.readjson("nchyjcfd");
                }
                if (!Json.checkjson("nchyjd"))
                {
                    nchych.textboxnchychjd.Text = "40";
                }
                else
                {
                    nchych.textboxnchychjd.Text = Json.readjson("nchyjd");
                }

                if (!Json.checkjson("nchyyc1"))
                {
                    nchych.datagridviewnchych.Rows.Add("分身", 10);
                    nchych.datagridviewnchych.Rows.Add("第一次拖动鼠标", 50);
                    nchych.datagridviewnchych.Rows.Add("分身", 10);
                    nchych.datagridviewnchych.Rows.Add("第二次拖动鼠标", 50);
                    nchych.datagridviewnchych.Rows.Add("最后分身延迟", 20);
                }
                else
                {
                    nchych.datagridviewnchych.Rows.Add("分身", Json.readjson("nchyyc1"));
                    nchych.datagridviewnchych.Rows.Add("第一次拖动鼠标", Json.readjson("nchyyc2"));
                    nchych.datagridviewnchych.Rows.Add("分身", Json.readjson("nchyyc3"));
                    nchych.datagridviewnchych.Rows.Add("第二次拖动鼠标", Json.readjson("nchyyc4"));
                    nchych.datagridviewnchych.Rows.Add("最后分身延迟", Json.readjson("nchyyc5"));
                }
                neicunheqiu.nchouyangjian = MainForm.GetVirtualKeyCode(nchych.comboboxnchouyangcehe.SelectedItem.ToString());
                try
                {
                    neicunheqiu.nchouyangjcfd = Convert.ToInt32(nchych.textboxnchychjcfd.Text);
                    neicunheqiu.nchouyangjd = Convert.ToInt32(nchych.textboxnchychjd.Text);
                    neicunheqiu.nchyyc1 = int.Parse(nchych.datagridviewnchych.Rows[0].Cells[1].Value.ToString());
                    neicunheqiu.nchyyc2 = int.Parse(nchych.datagridviewnchych.Rows[1].Cells[1].Value.ToString());
                    neicunheqiu.nchyyc3 = int.Parse(nchych.datagridviewnchych.Rows[2].Cells[1].Value.ToString());
                    neicunheqiu.nchyyc4 = int.Parse(nchych.datagridviewnchych.Rows[3].Cells[1].Value.ToString());
                    neicunheqiu.nchyyc5 = int.Parse(nchych.datagridviewnchych.Rows[4].Cells[1].Value.ToString());
                }
                catch (Exception ex)
                {

                }
                if (Json.checkjson("nchouyang"))
                {
                    if (Json.readjson("nchouyang") == "true")
                    {
                        nchych.checkboxnchouyangcehe.Checked = true;
                    }
                }
            }
            if (Application.OpenForms["fuzhugongneng"] is fuzhugongneng fzgn)
            {
                if (Json.checkjson("youjiankongqiu"))
                {
                    fzgn.textboxkongqiu.Text = Json.readjson("youjiankongqiu");
                }
                else
                {
                    fzgn.textboxkongqiu.Text = "100";
                }
                if (Json.checkjson("kongqiukq"))
                {
                    if (Json.readjson("kongqiukq") == "true")
                    {
                        fzgn.checkboxkongqiu.Checked = true;
                    }
                }
                if (Json.checkjson("suoqiu"))
                {
                    if (Json.readjson("suoqiu") == "true")
                    {
                        fzgn.checkboxsuoqiu.Checked = true;
                    }
                }
                if (!Json.checkjson("suoqiujian"))
                {
                    fzgn.comboBoxtsuoqiu.SelectedItem = "A";
                }
                else
                {
                    fzgn.comboBoxtsuoqiu.SelectedItem = Json.readjson("suoqiujian");
                }
            }
            if (Application.OpenForms["honggongneng"] is honggongneng hgn)
            {
                if (Json.checkjson("erfenhong"))
                {
                    if (Json.readjson("erfenhong") == "true")
                    {
                        hgn.checkBoxerfenhong.Checked = true;
                    }
                    else
                    {
                        hgn.checkBoxerfenhong.Checked = false;
                    }
                }
                if (Json.checkjson("sifenhong"))
                {
                    if (Json.readjson("sifenhong") == "true")
                    {
                        hgn.checkBoxsifenhong.Checked = true;
                    }
                    else
                    {
                        hgn.checkBoxsifenhong.Checked = false;
                    }
                }
                if (Json.checkjson("bafenhong"))
                {
                    if (Json.readjson("befenhong") == "true")
                    {
                        hgn.checkBoxbafenhong.Checked = true;
                    }
                    else
                    {
                        hgn.checkBoxbafenhong.Checked = false;
                    }
                }
                if (Json.checkjson("gangganhong"))
                {
                    if (Json.readjson("gangganhong") == "true")
                    {
                        hgn.checkBoxgangganhong.Checked = true;
                    }
                    else
                    {
                        hgn.checkBoxgangganhong.Checked = false;
                    }
                }
                if (Json.checkjson("shiliufenhong"))
                {
                    if (Json.readjson("shiliufenhong") == "true")
                    {
                        hgn.checkBoxshiliufenhong.Checked = true;
                    }
                    else
                    {
                        hgn.checkBoxshiliufenhong.Checked = false;
                    }
                }
                if (Json.checkjson("yuandihong"))
                {
                    if (Json.readjson("yuandihong") == "true")
                    {
                        hgn.checkBoxyuandihong.Checked = true;
                    }
                    else
                    {
                        hgn.checkBoxyuandihong.Checked = false;
                    }
                }
                if (Json.checkjson("changanhong1"))
                {
                    if (Json.readjson("changanhong1") == "true")
                    {
                        hgn.checkBoxchanganhong1.Checked = true;
                    }
                    else
                    {
                        hgn.checkBoxchanganhong1.Checked = false;
                    }
                }
                if (Json.checkjson("changanhong2"))
                {
                    if (Json.readjson("changanhong2") == "true")
                    {
                        hgn.checkBoxchanganhong2.Checked = true;
                    }
                    else
                    {
                        hgn.checkBoxchanganhong2.Checked = false;
                    }
                }
                if (Json.checkjson("lianjihong1"))
                {
                    if (Json.readjson("lianjihong1") == "true")
                    {
                        hgn.checkBoxlianjihong1.Checked = true;
                    }
                    else
                    {
                        hgn.checkBoxlianjihong1.Checked = false;
                    }
                }
                if (Json.checkjson("lianjihong2"))
                {
                    if (Json.readjson("lianjihong2") == "true")
                    {
                        hgn.checkBoxlianjihong2.Checked = true;
                    }
                    else
                    {
                        hgn.checkBoxlianjihong2.Checked = false;
                    }
                }
                if (Json.checkjson("erfenhongjian"))
                {
                    hgn.comboBoxerfenhong.SelectedItem = Json.readjson("erfenhongjian");
                }
                else
                {
                    hgn.comboBoxerfenhong.SelectedItem = "A";
                }
                if (Json.checkjson("sifenhongjian"))
                {
                    hgn.comboBoxsifenhong.SelectedItem = Json.readjson("sifenhongjian");
                }
                else
                {
                    hgn.comboBoxsifenhong.SelectedItem = "A";
                }
                if (Json.checkjson("bafenhongjian"))
                {
                    hgn.comboBoxbafenhong.SelectedItem = Json.readjson("bafenhongjian");
                }
                else
                {
                    hgn.comboBoxbafenhong.SelectedItem = "A";
                }
                if (Json.checkjson("shiliufenhongjian"))
                {
                    hgn.comboBoxshiliufenhong.SelectedItem = Json.readjson("shiliufenhongjian");
                }
                else
                {
                    hgn.comboBoxshiliufenhong.SelectedItem = "A";
                }
                if (Json.checkjson("gangganhongjian"))
                {
                    hgn.comboBoxgangganhong.SelectedItem = Json.readjson("gangganhongjian");
                }
                else
                {
                    hgn.comboBoxgangganhong.SelectedItem = "A";
                }
                if (Json.checkjson("yuandihongjian"))
                {
                    hgn.comboBoxyuandihong.SelectedItem = Json.readjson("yuandihongjian");
                }
                else
                {
                    hgn.comboBoxyuandihong.SelectedItem = "A";
                }
                if (Json.checkjson("changanhong1jian"))
                {
                    hgn.comboBoxchanganhong1.SelectedItem = Json.readjson("changanhong1jian");
                }
                else
                {
                    hgn.comboBoxchanganhong1.SelectedItem = "A";
                }
                if (Json.checkjson("changanhongmnj1"))
                {
                    hgn.comboBoxchanganhongmnj1.SelectedItem = Json.readjson("changanhongmnj1");
                }
                else
                {
                    hgn.comboBoxchanganhongmnj1.SelectedItem = "A";
                }
                if (Json.checkjson("changanhong2jian"))
                {
                    hgn.comboBoxchanganhong2.SelectedItem = Json.readjson("changanhong2jian");
                }
                else
                {
                    hgn.comboBoxchanganhong2.SelectedItem = "A";
                }
                if (Json.checkjson("changanhongmnj2"))
                {
                    hgn.comboBoxchanganhongmnj2.SelectedItem = Json.readjson("changanhongmnj2");
                }
                else
                {
                    hgn.comboBoxchanganhongmnj2.SelectedItem = "A";
                }
                if (Json.checkjson("lianjihong1jian"))
                {
                    hgn.comboBoxlianjihong1.SelectedItem = Json.readjson("lianjihong1jian");
                }
                else
                {
                    hgn.comboBoxlianjihong1.SelectedItem = "A";
                }
                if (Json.checkjson("lianjihongmnj1"))
                {
                    hgn.comboBoxlianjihongmnj1.SelectedItem = Json.readjson("lianjihongmnj1");
                }
                else
                {
                    hgn.comboBoxlianjihongmnj1.SelectedItem = "A";
                }
                if (Json.checkjson("lianjihong2jian"))
                {
                    hgn.comboBoxlianjihong2.SelectedItem = Json.readjson("lianjihong2jian");
                }
                else
                {
                    hgn.comboBoxlianjihong2.SelectedItem = "A";
                }
                if (Json.checkjson("lianjihongmnj2"))
                {
                    hgn.comboBoxlianjihongmnj2.SelectedItem = Json.readjson("lianjihongmnj2");
                }
                else
                {
                    hgn.comboBoxlianjihongmnj2.SelectedItem = "A";
                }
                if (Json.checkjson("erfenhongwait"))
                {
                    hgn.textboxerfenhong.Text = Json.readjson("erfenhongwait");
                    try
                    {
                        honggongneng.erfenhongwait = int.Parse(hgn.textboxerfenhong.Text);
                    }
                    catch (Exception ex)
                    {
                        honggongneng.erfenhongwait = 0;
                    }
                }
                else
                {
                    honggongneng.erfenhongwait = 0;
                    hgn.textboxerfenhong.Text = "0";
                }
                if (Json.checkjson("sifenhongwait"))
                {
                    hgn.textboxsifenhong.Text = Json.readjson("sifenhongwait");
                    try
                    {
                        honggongneng.sifenhongwait = int.Parse(hgn.textboxsifenhong.Text);
                    }
                    catch (Exception ex)
                    {
                        honggongneng.sifenhongwait = 50;
                    }
                }
                else
                {
                    honggongneng.sifenhongwait = 50;
                    hgn.textboxsifenhong.Text = "50";
                }
                if (Json.checkjson("bafenhongwait"))
                {
                    hgn.textboxbafenhong.Text = Json.readjson("bafenhongwait");
                    try
                    {
                        honggongneng.bafenhongwait = int.Parse(hgn.textboxbafenhong.Text);
                    }
                    catch (Exception ex)
                    {
                        honggongneng.bafenhongwait = 50;
                    }
                }
                else
                {
                    honggongneng.bafenhongwait = 50;
                    hgn.textboxbafenhong.Text = "50";
                }
                if (Json.checkjson("shiliufenhongwait"))
                {
                    hgn.textboxshiliufenhong.Text = Json.readjson("shiliufenhongwait");
                    try
                    {
                        honggongneng.shiliufenhongwait = int.Parse(hgn.textboxshiliufenhong.Text);
                    }
                    catch (Exception ex)
                    {
                        honggongneng.shiliufenhongwait = 50;
                    }
                }
                else
                {
                    honggongneng.shiliufenhongwait = 50;
                    hgn.textboxshiliufenhong.Text = "50";
                }
                if (Json.checkjson("gangganhongwait"))
                {
                    hgn.textboxgangganhong.Text = Json.readjson("gangganhongwait");
                    try
                    {
                        honggongneng.gangganhongwait = int.Parse(hgn.textboxgangganhong.Text);
                    }
                    catch (Exception ex)
                    {
                        honggongneng.gangganhongwait = 50;
                    }
                }
                else
                {
                    honggongneng.gangganhongwait = 50;
                    hgn.textboxgangganhong.Text = "50";
                }
                if (Json.checkjson("yuandihongwait"))
                {
                    hgn.textboxyuandihong.Text = Json.readjson("yuandihongwait");
                    try
                    {
                        honggongneng.yuandihongwait = int.Parse(hgn.textboxyuandihong.Text);
                    }
                    catch (Exception ex)
                    {
                        honggongneng.yuandihongwait = 50;
                    }
                }
                else
                {
                    honggongneng.yuandihongwait = 50;
                    hgn.textboxyuandihong.Text = "50";
                }
                if (Json.checkjson("changanhong1wait"))
                {
                    hgn.textboxchanganhong1.Text = Json.readjson("changanhong1wait");
                    try
                    {
                        honggongneng.changanhong1wait = int.Parse(hgn.textboxchanganhong1.Text);
                    }
                    catch (Exception ex)
                    {
                        honggongneng.changanhong1wait = 50;
                    }
                }
                else
                {
                    honggongneng.changanhong1wait = 50;
                    hgn.textboxchanganhong1.Text = "50";
                }
                if (Json.checkjson("changanhong2wait"))
                {
                    hgn.textboxchanganhong2.Text = Json.readjson("changanhong2wait");
                    try
                    {
                        honggongneng.changanhong2wait = int.Parse(hgn.textboxchanganhong2.Text);
                    }
                    catch (Exception ex)
                    {
                        honggongneng.changanhong2wait = 50;
                    }
                }
                else
                {
                    honggongneng.changanhong2wait = 50;
                    hgn.textboxchanganhong2.Text = "50";
                }
                if (Json.checkjson("lianjihong1wait"))
                {
                    hgn.textboxlianjihong1.Text = Json.readjson("lianjihong1wait");
                    try
                    {
                        honggongneng.lianjihong1wait = int.Parse(hgn.textboxlianjihong1.Text);
                    }
                    catch (Exception ex)
                    {
                        honggongneng.lianjihong1wait = 50;
                    }
                }
                else
                {
                    honggongneng.lianjihong1wait = 50;
                    hgn.textboxlianjihong1.Text = "50";
                }
                if (Json.checkjson("lianjihong2wait"))
                {
                    hgn.textboxlianjihong2.Text = Json.readjson("lianjihong2wait");
                    try
                    {
                        honggongneng.lianjihong2wait = int.Parse(hgn.textboxlianjihong2.Text);
                    }
                    catch (Exception ex)
                    {
                        honggongneng.lianjihong2wait = 50;
                    }
                }
                else
                {
                    honggongneng.lianjihong2wait = 50;
                    hgn.textboxlianjihong2.Text = "50";
                    
                }
            }
            if (Application.OpenForms["heipingkadian"] is heipingkadian hpkd)
            {
                if (Json.checkjson("heipingkjj"))
                {
                    hpkd.comboBoxheipingkjj.SelectedItem = Json.readjson("heipingkjj");
                }
                else
                {
                    hpkd.comboBoxheipingkjj.SelectedItem = "A";
                }
                if (Json.checkjson("hpfscs"))
                {
                    hpkd.textboxhpfscs.Text = Json.readjson("hpfscs");
                }
                else
                {
                    hpkd.textboxhpfscs.Text = "1";
                }
                if (Json.checkjson("hpcsbl"))
                {
                    hpkd.textboxhpcsbl.Text = Json.readjson("hpcsbl");
                }
                else
                {
                    hpkd.textboxhpcsbl.Text = "0.5";
                }
                if (Json.checkjson("hpfsyc"))
                {
                    hpkd.textboxhpfsyc.Text = Json.readjson("hpfsyc");
                }
                else
                {
                    hpkd.textboxhpfsyc.Text = "50";
                }
                if (Json.checkjson("hptzbc"))
                {
                    hpkd.textboxhpglbc.Text = Json.readjson("hptzbc");
                }
                else
                {
                    hpkd.textboxhpglbc.Text = "10";
                }
            }
        }

        private void moniqi_SelectedIndexChanged(object sender, EventArgs e)
        {
            Json.writejson("ismoniqi", moniqi.SelectedItem.ToString());
        }

        private void uiTextBox2_TextChanged(object sender, EventArgs e)
        {
            kaishi = int.Parse(uiTextBox2.Text);
        }

        private void uiTextBox3_TextChanged(object sender, EventArgs e)
        {
            jieshu = int.Parse(uiTextBox3.Text);
        }

        private void label3_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void panel_Click(object sender, EventArgs e) { }


        // ==========================================
        // ★ 热更新核心逻辑（动态读取服务器真实文件名 + 独立进度窗）
        // ==========================================
        // ==========================================
        // ★ 热更新核心逻辑（保留老版本，新版本自动放入桌面 ANYE Balls 文件夹）
        // ==========================================


       
    }
}

using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ANYE_Balls.API;
using static ANYE_Balls.Struct;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace ANYE_Balls
{
    public partial class neicungongneng : Form
    {
        //全局变量
        public static float gunlun;
        public const int WH_MOUSE_LL = 14;
        public const int WM_MOUSEWHEEL = 0x020A;
        public static IntPtr hookID;
        public LowLevelMouseProc mouseProc;

        //线程标识
        public static bool tuqiuthstatu = false;
        public static bool shiyethstatu = false;
        public static bool yaogan10000thstatu = false;
        public static bool yaoganxiangyinthstatu = false;
        public static bool yaoganjiasuthstatu = false;
        public static bool quanjubiansuthstatu = false;
        public static bool juneiqupi = false;
        public static bool fenshenjiasuhstatu = false;
        public static bool chaojijiefenshen = false;
        public static bool chaojijietuqiu = false;
        public static bool fenshenjiexian = false;
        public static bool zhuyechapaithstatu = false;
        public static bool neicuntuqiu = false;
        public static bool tqdljthstatu = false;


        internal bool isUserEditing = false;   // 标记用户是否正在手动编辑

        // 统一开关别名映射
        public AntdUI.Checkbox checkboxfsjs => checkboxygyh;
        public AntdUI.Checkbox checkboxfenshenjiexian2 => checkboxygyh;
        public AntdUI.Checkbox checkboxygyc => checkboxygyh;
        public AntdUI.Checkbox checkboxjzntqfs => checkboxygyh;
        public AntdUI.Checkbox checkboxygjx => checkboxygyh;


        //隐藏光环
        public static byte YCGH;
        static int GetVirtualKeyCode(string keyString)
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

        public neicungongneng()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void uiGroupBox2_Click(object sender, EventArgs e)
        {
        }

        private void neicungongneng_Load(object sender, EventArgs e)
        {
            if (Json.checkjson("gunlunzuixiaozhi"))
            {
                textboxshiyemin.Text = Json.readjson("gunlunzuixiaozhi");
            }
            else
            {
                textboxshiyemin.Text = "1.0";
            }
            if (Json.checkjson("gunlunzuidazhi"))
            {
                textboxshiyemax.Text = Json.readjson("gunlunzuidazhi");
            }
            else
            {
                textboxshiyemax.Text = "10.0";
            }
            if (Json.checkjson("buchang"))
            {
                textboxshiyebuchang.Text = Json.readjson("buchang");
            }
            else
            {
                textboxshiyebuchang.Text = "0.5";
            }
            checkboxgunlun.Checked = true;
            if (Json.checkjson("ycghrj"))
            {
                comboBoxycgh.SelectedItem = Json.readjson("ycghrj");
            }
            else
            {
                comboBoxycgh.SelectedItem = "禁用";
            }

            if (!yaogan10000thstatu)
            {
                new Thread(yg10000).Start();
                yaogan10000thstatu = true;
            }

            new Thread(() =>
            {
                bool keyPressed = false;

                while (true)
                {
                    if (API.GetForegroundWindow() == API.FindWindow(MainForm.lp, null) && MainForm.shifouzhanju)
                    {
                        bool isKeyDown = (GetAsyncKeyState(YCGH) & 0x8000) != 0;

                        if (isKeyDown && !keyPressed)
                        {
                            keyPressed = true;
                            if (checkboxycgh.InvokeRequired)
                            {
                                checkboxycgh.Invoke((MethodInvoker)delegate
                                {
                                    checkboxycgh.Checked = !checkboxycgh.Checked;

                                    if (checkboxycgh.Checked)
                                    {
                                        comboBoxycgh.KeyDown += comboBoxycgh_KeyDownHandler;
                                    }
                                    else
                                    {
                                        comboBoxycgh.KeyDown -= comboBoxycgh_KeyDownHandler;
                                    }
                                });
                            }
                            else
                            {
                                checkboxycgh.Checked = !checkboxycgh.Checked;

                                if (checkboxycgh.Checked)
                                {
                                    comboBoxycgh.KeyDown += comboBoxycgh_KeyDownHandler;
                                }
                                else
                                {
                                    comboBoxycgh.KeyDown -= comboBoxycgh_KeyDownHandler;
                                }
                            }
                            Thread.Sleep(200);
                        }
                        else if (!isKeyDown && keyPressed)
                        {
                            keyPressed = false;
                        }
                    }

                    Thread.Sleep(10);
                }
            }).Start();
        }


        private void comboBoxycgh_KeyDownHandler(object sender, KeyEventArgs e)
        {
            if (checkboxycgh.Checked)
            {
                int byteswrite;
                float valuesgts = 0f;
                API.WriteProcessMemory(MainForm.hProcess, MainForm.ycgh, BitConverter.GetBytes(valuesgts), sizeof(float), out byteswrite);
            }
            else
            {
                int byteswrite;
                float valuesgts = 1f;
                API.WriteProcessMemory(MainForm.hProcess, MainForm.ycgh, BitConverter.GetBytes(valuesgts), sizeof(float), out byteswrite);
            }
        }



        public void shiyethread()
        {
            while (true)
            {
                int byteswrite;
                float value;
                try
                {
                    value = float.Parse(textBoxshiyezhi.Text);
                    //Debug.WriteLine(value);
                    gunlun = value;
                }
                catch (FormatException)
                {
                    value = 1.0f;
                }
                WriteProcessMemory(MainForm.hProcess, (MainForm.shiye), BitConverter.GetBytes(value), sizeof(float), out byteswrite);
                //WriteProcessMemory(MainForm.hProcess, (MainForm.shiye + 4), BitConverter.GetBytes(value), sizeof(float), out byteswrite);
                Thread.Sleep(10);
            }
        }

        void tishi(string str)
        {
            if (Application.OpenForms["MainForm"] is MainForm mainForm)
            {
                mainForm.tishi.Text += str;
            }
        }

        public void tuqiuthread()
        {
            while (true)
            {
                if (checkboxtuqiu.Checked)
                {
                    int byteswrite;
                    float value = 0;
                    API.WriteProcessMemory(MainForm.hProcess, (MainForm.tuqiu), BitConverter.GetBytes(value), sizeof(float), out byteswrite);
                    //API.WriteProcessMemory(MainForm.hProcess, (MainForm.tuqiu + 8), BitConverter.GetBytes(value), sizeof(float), out byteswrite);//修改地方
                }
                Thread.Sleep(1);
            }
        }


        public void yg10000()
        {
            while (true)
            {
                int byteswrite;
                int value = 0;
                if (checkboxyaogan10000.Checked)
                {
                    value = 2147483647;
                }
                else if (checkboxyaogan100002.Checked)
                {
                    value = 10000;
                }

                if (value != 0)
                {
                    API.WriteProcessMemory(MainForm.hProcess, MainForm.yaogan10000,
                        BitConverter.GetBytes(value), sizeof(float), out byteswrite);
                }
                Thread.Sleep(1);
            }
        }

        public void ygxiangyin()
        {
            while (true)
            {
                int byteswrite;
                int value = 0;
                if (checkboxxiangyin21yi.Checked)
                {
                    value = 2147483647;
                }
                else if (checkboxxiangyin10000.Checked)
                {
                    value = 10000;
                }

                if (value != 0)
                {
                    API.WriteProcessMemory(MainForm.hProcess, MainForm.yaoganxiangyinsudu,
                        BitConverter.GetBytes(value), sizeof(float), out byteswrite);
                }
                Thread.Sleep(1);
            }
        }

        //超级解分身
        public void chaojijiefenshen1()
        {
            while (true)
            {
                if (checkboxjzntqfs.Checked)
                {
                    int byteswrite;
                    float value = 0f;
                    API.WriteProcessMemory(MainForm.hProcess, MainForm.chaojijiefenshen,
                        BitConverter.GetBytes(value), sizeof(float), out byteswrite);
                    API.WriteProcessMemory(MainForm.hProcess, MainForm.chaojijietuqiu,
                        BitConverter.GetBytes(value), sizeof(float), out byteswrite);
                }
                Thread.Sleep(1);
            }
        }

        public void ygjiasu()
        {
            while (true)
            {
                byte[] data = new byte[sizeof(float)];
                int a;
                float zhuangtai;
                ReadProcessMemory(MainForm.hProcess, MainForm.yaoganjiasu, data, sizeof(float), out a);
                try
                {
                    zhuangtai = BitConverter.ToSingle(data, 0);
                    Debug.WriteLine(zhuangtai);
                }
                catch
                {
                    zhuangtai = 0;
                }
                if (zhuangtai == 0)
                {
                    MainForm.shifouzhanju = true;
                }
                else
                {
                    MainForm.shifouzhanju = true;
                }
                if (checkboxygyh.Checked && zhuangtai != 0)
                {
                    int byteswrite;
                    float value = 100000000;
                    WriteProcessMemory(MainForm.hProcess, MainForm.yaoganjiasu, BitConverter.GetBytes(value), sizeof(float), out byteswrite);
                }
                Thread.Sleep(1);
            }
        }

        public void quanjubiansuthread()
        {
            while (true)
            {
                int byteswrite;
                float value;
                try
                {
                    value = float.Parse(textboxbiansu.Text);
                }
                catch (Exception ex)
                {
                    value = 1.0f;
                }
                WriteProcessMemory(MainForm.hProcess, MainForm.biansu, BitConverter.GetBytes(value), sizeof(float), out byteswrite);
                Thread.Sleep(1);
            }
        }

        //主页查排名
        private void txtzhuyechapai_TextChanged(object sender, EventArgs e)
        {
            int byteswrite;
            int value;
            try
            {
                value = int.Parse(txtzhuyechapai.Text);
            }
            catch (FormatException)
            {
                value = 0;
            }
            long targetAddress = MainForm.zhuyechapai - 0x3E2;
            WriteProcessMemory(MainForm.hProcess, targetAddress, BitConverter.GetBytes(value), sizeof(int), out byteswrite);
            Json.writejson("zhuyechapai", txtzhuyechapai.Text);
        }

        private void textBoxshiyezhi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void textboxshiyemin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void textboxshiyemax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void textboxshiyebuchang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void textboxnianhe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void textboxbiansu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void textboxnichengdaxiao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void uiTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void uiTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void textBoxshiyezhi_TextChanged(object sender, EventArgs e)
        {
            int byteswrite;
            float value;
            try
            {
                value = float.Parse(textBoxshiyezhi.Text);
                gunlun = value;
            }
            catch (FormatException)
            {
                value = 1.0f;
            }
            API.WriteProcessMemory(MainForm.hProcess, (MainForm.shiye), BitConverter.GetBytes(value), sizeof(float), out byteswrite);
            API.WriteProcessMemory(MainForm.hProcess, (MainForm.shiye + 4), BitConverter.GetBytes(value), sizeof(float), out byteswrite);
            Json.writejson("shiye", textBoxshiyezhi.Text);
        }

        private void checkboxgunlun_CheckedChanged(object sender, bool value)
        {
            if (checkboxgunlun.Checked)
            {
                mouseProc = HookCallback;
                hookID = SetHook(mouseProc);
            }
            else
            {
                UnhookWindowsHookEx(hookID);
            }
            Json.writejson("gunlun", value ? "true" : "false");
        }

        private IntPtr SetHook(LowLevelMouseProc proc)
        {
            using (var curProcess = Process.GetCurrentProcess())
            using (var curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_MOUSE_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (GetForegroundWindow() == FindWindow(MainForm.lp, null))
            {
                if (nCode >= 0 && wParam == (IntPtr)WM_MOUSEWHEEL)
                {
                    MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                    IntPtr windowHandle = API.WindowFromPoint(hookStruct.pt);
                    int delta = (short)((hookStruct.mouseData >> 16) & 0xffff);
                    try
                    {
                        if (delta > 0)
                        {
                            if (gunlun < float.Parse(textboxshiyemax.Text))
                            {
                                int byteswrite;
                                gunlun = gunlun + float.Parse(textboxshiyebuchang.Text);
                                API.WriteProcessMemory(MainForm.hProcess, (MainForm.shiye), BitConverter.GetBytes(gunlun), sizeof(float), out byteswrite);
                                API.WriteProcessMemory(MainForm.hProcess, (MainForm.shiye + 4), BitConverter.GetBytes(gunlun), sizeof(float), out byteswrite);
                                textBoxshiyezhi.Text = gunlun.ToString("0.0");
                                return new IntPtr(1);
                            }
                            else
                            {
                                int byteswrite;
                                gunlun = float.Parse(textboxshiyemax.Text);
                                API.WriteProcessMemory(MainForm.hProcess, (MainForm.shiye), BitConverter.GetBytes(gunlun), sizeof(float), out byteswrite);
                                API.WriteProcessMemory(MainForm.hProcess, (MainForm.shiye + 4), BitConverter.GetBytes(gunlun), sizeof(float), out byteswrite);
                                textBoxshiyezhi.Text = gunlun.ToString("0.0");
                                return new IntPtr(1);
                            }
                        }
                        else
                        {
                            if (gunlun > float.Parse(textboxshiyemin.Text))
                            {
                                int byteswrite;
                                gunlun = gunlun - float.Parse(textboxshiyebuchang.Text);
                                API.WriteProcessMemory(MainForm.hProcess, (MainForm.shiye), BitConverter.GetBytes(gunlun), sizeof(float), out byteswrite);
                                API.WriteProcessMemory(MainForm.hProcess, (MainForm.shiye + 4), BitConverter.GetBytes(gunlun), sizeof(float), out byteswrite);
                                textBoxshiyezhi.Text = gunlun.ToString("0.0");
                                return new IntPtr(1);
                            }
                            else
                            {
                                int byteswrite;
                                gunlun = float.Parse(textboxshiyemin.Text);
                                API.WriteProcessMemory(MainForm.hProcess, (MainForm.shiye), BitConverter.GetBytes(gunlun), sizeof(float), out byteswrite);
                                API.WriteProcessMemory(MainForm.hProcess, (MainForm.shiye + 4), BitConverter.GetBytes(gunlun), sizeof(float), out byteswrite);
                                textBoxshiyezhi.Text = gunlun.ToString("0.0");
                                return new IntPtr(1);
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            return CallNextHookEx(hookID, nCode, wParam, lParam);
        }

        private void textboxnianhe_TextChanged(object sender, EventArgs e)
        {
            int byteswrite;
            float value;
            try
            {
                value = float.Parse(textboxnianhe.Text);
            }
            catch (FormatException)
            {
                value = 0.588f;
            }
            WriteProcessMemory(MainForm.hProcess, MainForm.nianhe, BitConverter.GetBytes(value), sizeof(float), out byteswrite);
            Json.writejson("nianhe", textboxnianhe.Text);
        }

        private void textboxnichengdaxiao_TextChanged(object sender, EventArgs e)
        {
            int byteswrite;
            float value;
            try
            {
                value = float.Parse(textboxnichengdaxiao.Text);
            }
            catch (FormatException)
            {
                value = 1.875f;
            }
            WriteProcessMemory(MainForm.hProcess, MainForm.nichengdaxiao, BitConverter.GetBytes(value), sizeof(float), out byteswrite);
            Json.writejson("nichengdaxiao", textboxnichengdaxiao.Text);
        }



        //

        private void textboxygrc_TextChanged(object sender, EventArgs e)
        {
            int byteswrite;
            float value = 0;
            try
            {
                value = float.Parse(textboxygrc.Text);
            }
            catch (FormatException)
            {
                value = 1.0f;
            }
            WriteProcessMemory(MainForm.hProcess, MainForm.yaoganrongcha, BitConverter.GetBytes(value), sizeof(float), out byteswrite);
            Json.writejson("yaoganrongcha", textboxygrc.Text);
        }

        private void textboxyght_TextChanged(object sender, EventArgs e)
        {
            int byteswrite;
            float value = 0;
            try
            {
                value = float.Parse(textboxyght.Text);
            }
            catch (FormatException)
            {
                value = 40f;
            }
            WriteProcessMemory(MainForm.hProcess, MainForm.yaoganhuitan, BitConverter.GetBytes(value), sizeof(float), out byteswrite);
            Json.writejson("yaoganhuitan", textboxyght.Text);
        }

        private void textboxshiyemin_TextChanged(object sender, EventArgs e)
        {
            Json.writejson("gunlunzuixiaozhi", textboxshiyemin.Text);
        }

        private void textboxshiyemax_TextChanged(object sender, EventArgs e)
        {
            Json.writejson("gunlunzuidazhi", textboxshiyemax.Text);
        }

        private void textboxshiyebuchang_TextChanged(object sender, EventArgs e)
        {
            Json.writejson("buchang", textboxshiyebuchang.Text);
        }

        private void textboxbiansu_TextChanged(object sender, EventArgs e)
        {
            int byteswrite;
            float value;
            try
            {
                value = float.Parse(textboxbiansu.Text);
            }
            catch (FormatException)
            {
                value = 1.0f;
            }
            WriteProcessMemory(MainForm.hProcess, MainForm.biansu, BitConverter.GetBytes(value), sizeof(float), out byteswrite);
            Json.writejson("biansu", textboxbiansu.Text);
        }

        private void checkboxygyh_CheckedChanged(object sender, bool value)
        {
            int byteswrite;

            // 1. 分身加速 (fsjs)
            float valuefsjs = value ? 0f : 0.244964391f;
            API.WriteProcessMemory(MainForm.hProcess, MainForm.fsjs, BitConverter.GetBytes(valuefsjs), sizeof(float), out byteswrite);

            // 2. 解遥杆延迟 (ygyc)
            float valueygyc = value ? 0.0005f : 0.02f;
            API.WriteProcessMemory(MainForm.hProcess, MainForm.yaoganyanchi, BitConverter.GetBytes(valueygyc), sizeof(float), out byteswrite);

            // 3. 遥杆/分身解限 (ygjx)
            float valueygjx = value ? 0.0f : 0.789f;
            API.WriteProcessMemory(MainForm.hProcess, MainForm.yaoganjiexian, BitConverter.GetBytes(valueygjx), sizeof(float), out byteswrite);

            // 4. 分身解限1 (fenshenjiexian2)
            float valuefsjx2 = value ? 0f : 0.12f;
            API.WriteProcessMemory(MainForm.hProcess, MainForm.fenshenjiexian, BitConverter.GetBytes(valuefsjx2), sizeof(float), out byteswrite);

            // 说明：
            // - 遥杆优化 (ygyh) 由后台线程 ygjiasu 循环检测 checkboxygyh.Checked 并写入。
            // - 解分身/吐球 (jzntqfs) 由后台线程 chaojijiefenshen1 循环检测 checkboxjzntqfs.Checked 并写入。
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void checkbox2_CheckedChanged(object sender, bool value)
        {
        }

        private void chkjnqp_CheckedChanged(object sender, bool value)
        {
            if (checkboxycgh.Checked)
            {
                int byteswrite;
                float valuesgts = 0f;
                API.WriteProcessMemory(MainForm.hProcess, MainForm.ycgh, BitConverter.GetBytes(valuesgts), sizeof(float), out byteswrite);
            }
            else
            {
                int byteswrite;
                float valuesgts = 1f;
                API.WriteProcessMemory(MainForm.hProcess, MainForm.ycgh, BitConverter.GetBytes(valuesgts), sizeof(float), out byteswrite);
            }
            Json.writejson("ycgh", value ? "true" : "false");
        }

        private void label16_Click(object sender, EventArgs e)
        {
        }

        private void uiTextBox1_TextChanged(object sender, EventArgs e)
        {
            int byteswrite;
            float value;
            try
            {
                value = float.Parse(textboxchaojiyaogan.Text);
            }
            catch (FormatException)
            {
                value = 0.00f;
            }
            WriteProcessMemory(MainForm.hProcess, MainForm.chaojiyaogan, BitConverter.GetBytes(value), sizeof(float), out byteswrite);
            Json.writejson("chaojiyaogan", textboxchaojiyaogan.Text);
        }

        private void comboBoxycgh_SelectedIndexChanged(object sender, EventArgs e)
        {
            YCGH = (byte)GetVirtualKeyCode(comboBoxycgh.SelectedItem.ToString());
            Json.writejson("ycghrj", comboBoxycgh.SelectedItem.ToString());
        }

        private void checkboxtuqiu_CheckedChanged(object sender, bool value)
        {
            if (value)
            {
                checkboxneichuntuqiu.Checked = false;
                checkboxdlj.Checked = false; // 增加互斥：取消单连点截断
            }
        }


        private void checkboxneichuntuqiu_CheckedChanged(object sender, bool value)
        {
            // 互斥逻辑
            if (value)
            {
                checkboxtuqiu.Checked = false;
                checkboxdlj.Checked = false; // 增加互斥：取消单连点截断
            }

            // 地址有效时写入
            if (MainForm.neicuntuqiu != 0)
            {
                float writeValue = value ? -1000000000f : 0.05000000075f;
                byte[] buffer = BitConverter.GetBytes(writeValue);
                int bytesWritten;
                Memory.WriteProcessMemory(MainForm.hProcess, (IntPtr)MainForm.neicuntuqiu, buffer, sizeof(float), out bytesWritten);
            }
        }


        private void checkboxyaogan10000_CheckedChanged_1(object sender, bool value)
        {
            if (value)
            {
                checkboxyaogan100002.Checked = false;
            }
        }

        private async void fuzhi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtzhuyechapai.Text) ||
                txtzhuyechapai.Text == "0" ||
                txtzhuyechapai.Text == "请先初始化")
            {
                tishi("主页查排名无有效数据，复制失败\r\n");
                return;
            }

            fuzhi.Enabled = false;
            bool ok = false;
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    Clipboard.SetText(txtzhuyechapai.Text);
                    ok = true;
                    tishi("主页查排名已复制到剪贴板\r\n");
                    break;
                }
                catch
                {
                    await Task.Delay(50);
                }
            }

            if (!ok)
                tishi("主页查排名复制失败\r\n");

            fuzhi.Enabled = true;
        }
        private void checkboxyaogan100002_CheckedChanged(object sender, bool value)
        {
            if (value)
            {
                checkboxyaogan10000.Checked = false;
            }
        }

        private void checkboxxiangyin21yi_CheckedChanged(object sender, bool value)
        {
            if (value)
            {
                checkboxxiangyin10000.Checked = false;
            }
        }

        private void checkboxxiangyin10000_CheckedChanged(object sender, bool value)
        {
            if (value)
            {
                checkboxxiangyin21yi.Checked = false;
            }
        }


        private void buttonneichuntuqiu_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                buttonneichuntuqiu.Loading = true;
                string targetPattern = "";
                if (MainForm.choose == "MuMu模拟器")
                {
                    targetPattern = MainForm.neicuntuqiuaoPattern;
                }
                else if (MainForm.choose == "雷电模拟器5" || MainForm.choose == "雷电模拟器9")
                {
                    targetPattern = MainForm.leidianneicuntuqiuaoPattern;
                }
                else
                {
                    tishi("未知的模拟器类型，无法搜索\r\n");
                    buttonneichuntuqiu.Loading = false;
                    return; 
                }


                List<long> addresstq = Memory.ScanPatternParallel(MainForm.hProcess, targetPattern);

                if (addresstq.Count > 0)
                {
                    foreach (long addr in addresstq)
                    {

                        MainForm.neicuntuqiu = addr;

                        tishi("CALL吐球搜索成功\r\n");

                        checkboxneichuntuqiu.Checked = true;

                        if (!tuqiuthstatu)
                        {
                            new Thread(tuqiuthread).Start();
                            tuqiuthstatu = true;
                        }
                    }
                }
                else
                {
                    tishi("CALL吐球搜索失败 请前往实战吐球后搜索\r\n");
                }

                buttonneichuntuqiu.Loading = false;

            }).Start();
        }

        // ==========================================
        //         单连点截断 
        // ==========================================

        private bool isDljAutoLoop = false; 
        private void SearchDljAddress()
        {
            if (buttontqdlj.InvokeRequired)
                Invoke(new Action(() => buttontqdlj.Loading = true));
            else
                buttontqdlj.Loading = true;

            List<long> addresstq = Memory.ScanPatternParallel(MainForm.hProcess, MainForm.dljdaob, MainForm.dljdaob.Length);

            if (addresstq.Count > 0)
            {
                foreach (long addr in addresstq)
                {
                    if (MainForm.choose == "MuMu模拟器")
                    {
                        MainForm.tqdld = addr - 0x122;
                    }
                    else if (MainForm.choose == "雷电模拟器5" || MainForm.choose == "雷电模拟器9")
                    {
                        MainForm.tqdld = addr - 0xE6;
                    }

                    Invoke(new Action(() => tishi("吐球单连点单独搜索成功，正在持续截断...\r\n")));
                    break; 
                }
            }
            else
            {
                Invoke(new Action(() => tishi("吐球单连点单独搜索失败，请确保在对局中。\r\n")));
            }

            if (buttontqdlj.InvokeRequired)
                Invoke(new Action(() => buttontqdlj.Loading = false));
            else
                buttontqdlj.Loading = false;
        }

        private void buttontqdlj_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                SearchDljAddress();
                if (MainForm.tqdld != 0)
                {
                    Invoke(new Action(() => checkboxdlj.Checked = true));
                }
            }).Start();
        }

        private async void checkboxdlj_CheckedChanged(object sender, bool value)
        {
            
            if (value)
            {
                checkboxtuqiu.Checked = false;
                checkboxneichuntuqiu.Checked = false;
            }

            if (value)
            {
                isDljAutoLoop = true;
                await Task.Run(() => AutoDljEngine()); 
            }
            else
            {
                isDljAutoLoop = false; 
            }
        }

        private void AutoDljEngine()
        {
            int zeroCount = 0;
            bool inMatch = false;
            int loopCounter = 0;

            while (isDljAutoLoop)
            {
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
                long djpdAddress = MainForm.qjdizhi + 0x5C;
                if (loopCounter % 200 == 0)
                {
                    byte[] buffer = new byte[4];
                    int bytesRead;
                    API.ReadProcessMemory(MainForm.hProcess, djpdAddress, buffer, 4, out bytesRead);
                    int djpdValue = BitConverter.ToInt32(buffer, 0);

                    if (djpdValue == 0)
                    {
                        zeroCount++;
                        if (zeroCount >= 3)
                        {
                            if (inMatch)
                            {
                                inMatch = false;
                                MainForm.tqdld = 0;   
                            }
                        }
                    }
                    else
                    {
                        zeroCount = 0;
                        if (!inMatch)
                        {
                            inMatch = true;
                            SearchDljAddress();
                        }
                    }
                }

                if (inMatch && MainForm.tqdld != 0)
                {
                    float val = 0f;
                    int bytesWrite;
                    API.WriteProcessMemory(MainForm.hProcess, MainForm.tqdld, BitConverter.GetBytes(val), sizeof(float), out bytesWrite);

                    Thread.Sleep(1); 
                    loopCounter += 1;
                }
                else
                {
                    Thread.Sleep(50);
                    loopCounter += 50;
                }
            }
        }
    }
}

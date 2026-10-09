namespace ANYE_Balls
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            AntdUI.TreeItem treeItem1 = new AntdUI.TreeItem();
            AntdUI.TreeItem treeItem2 = new AntdUI.TreeItem();
            AntdUI.TreeItem treeItem3 = new AntdUI.TreeItem();
            AntdUI.TreeItem treeItem13 = new AntdUI.TreeItem();
            AntdUI.TreeItem treeItem14 = new AntdUI.TreeItem();
            AntdUI.TreeItem treeItem15 = new AntdUI.TreeItem();
            AntdUI.TreeItem treeItem16 = new AntdUI.TreeItem();
            AntdUI.TreeItem treeItem17 = new AntdUI.TreeItem();
            AntdUI.TreeItem treeItem18 = new AntdUI.TreeItem();
            AntdUI.TreeItem treeItem19 = new AntdUI.TreeItem();
            AntdUI.TreeItem treeItem20 = new AntdUI.TreeItem();
            AntdUI.TreeItem treeItem21 = new AntdUI.TreeItem();
            AntdUI.TreeItem treeItem22 = new AntdUI.TreeItem();
            AntdUI.TreeItem treeItem23 = new AntdUI.TreeItem();
            AntdUI.TreeItem treeItem24 = new AntdUI.TreeItem();
            AntdUI.TreeItem treeItem25 = new AntdUI.TreeItem();
            AntdUI.TreeItem treeItem26 = new AntdUI.TreeItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            treeView = new AntdUI.Tree();
            panel = new AntdUI.Panel();
            moniqi = new Sunny.UI.UIComboBox();
            buttonhuoqujincheng = new AntdUI.Button();
            buttondiyibu = new AntdUI.Button();
            label1 = new AntdUI.Label();
            label2 = new AntdUI.Label();
            comboBoxtuqiu = new Sunny.UI.UIComboBox();
            comboBoxfenshen = new Sunny.UI.UIComboBox();
            label3 = new AntdUI.Label();
            textBoxyaogandaxiao = new Sunny.UI.UITextBox();
            buttonchushihua = new AntdUI.Button();
            comboBoxhqyc = new Sunny.UI.UIComboBox();
            label4 = new AntdUI.Label();
            buttondaochupz = new AntdUI.Button();
            buttondaorupz = new AntdUI.Button();
            uiGroupBox2 = new Sunny.UI.UIGroupBox();
            tishi = new Sunny.UI.UITextBox();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            uiTextBox2 = new Sunny.UI.UITextBox();
            uiTextBox3 = new Sunny.UI.UITextBox();
            uiTextBox4 = new Sunny.UI.UITextBox();
            uiTextBox5 = new Sunny.UI.UITextBox();
            uiTextBox6 = new Sunny.UI.UITextBox();
            label6 = new AntdUI.Label();
            label7 = new AntdUI.Label();
            label8 = new AntdUI.Label();
            label9 = new AntdUI.Label();
            label10 = new AntdUI.Label();
            label11 = new AntdUI.Label();
            uiTextBox7 = new Sunny.UI.UITextBox();
            label12 = new AntdUI.Label();
            windowBar = new AntdUI.WindowBar();
            buttonshiyeneicung = new AntdUI.Button();
            buttonyaoganfenshen = new AntdUI.Button();
            uiGroupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // treeView
            // 
            treeView.BackColor = SystemColors.InactiveBorder;
            treeView.BackgroundImageLayout = ImageLayout.None;
            treeView.BackHover = Color.Azure;
            treeView.Badge = "";
            treeView.BadgeOffsetX = 0;
            treeView.BadgeOffsetY = 0;
            treeView.BadgeSize = 1E-05F;
            treeView.BlockNode = true;
            treeView.CausesValidation = false;
            treeView.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            treeView.ForeActive = SystemColors.ActiveCaption;
            treeView.ForeColor = SystemColors.ActiveCaptionText;
            treeView.ImeMode = ImeMode.Off;
            treeItem1.PARENTITEM = null;
            treeItem2.PARENTITEM = treeItem1;
            treeItem2.Select = true;
            treeItem2.Text = "内存功能";
            treeItem3.PARENTITEM = treeItem1;
            treeItem3.Text = "辅助功能";
            treeItem1.Sub.AddRange(new AntdUI.TreeItem[] { treeItem2, treeItem3 });
            treeItem1.Text = "基本功能";
            treeItem13.PARENTITEM = null;
            treeItem14.PARENTITEM = treeItem13;
            treeItem14.Text = "内存三角-模式1";
            treeItem15.PARENTITEM = treeItem13;
            treeItem15.Text = "内存三角-模式2";
            treeItem16.PARENTITEM = treeItem13;
            treeItem16.Text = "内存四分侧合";
            treeItem17.PARENTITEM = treeItem13;
            treeItem17.Text = "内存中分侧合";
            treeItem18.PARENTITEM = treeItem13;
            treeItem18.Text = "内存后仰侧合";
            treeItem19.PARENTITEM = treeItem13;
            treeItem19.Text = "内存半旋";
            treeItem20.PARENTITEM = treeItem13;
            treeItem20.Text = "内存旋转";
            treeItem21.PARENTITEM = treeItem13;
            treeItem21.Text = "内存蛇手";
            treeItem13.Sub.AddRange(new AntdUI.TreeItem[] { treeItem14, treeItem15, treeItem16, treeItem17, treeItem18, treeItem19, treeItem20, treeItem21 });
            treeItem13.Text = "内存合球";
            treeItem22.PARENTITEM = null;
            treeItem22.Text = "宏功能";
            treeItem23.PARENTITEM = null;
            treeItem24.PARENTITEM = treeItem23;
            treeItem24.Text = "黑屏图色";
            treeItem23.Sub.AddRange(new AntdUI.TreeItem[] { treeItem24 });
            treeItem23.Text = "卡点功能";
            treeItem25.PARENTITEM = null;
            treeItem25.Text = "皮肤功能";
            treeItem26.PARENTITEM = null;
            treeItem26.Text = "其他功能";
            treeView.Items.AddRange(new AntdUI.TreeItem[] { treeItem1, treeItem13, treeItem22, treeItem23, treeItem25, treeItem26 });
            treeView.Location = new Point(0, 251);
            treeView.Margin = new Padding(3, 1, 3, 1);
            treeView.Name = "treeView";
            treeView.Radius = 50;
            treeView.Round = true;
            treeView.Size = new Size(204, 625);
            treeView.TabIndex = 1;
            treeView.Text = "tree1";
            treeView.NodeMouseClick += treeView_NodeMouseClick;
            // 
            // panel
            // 
            panel.Back = SystemColors.InactiveBorder;
            panel.BackColor = SystemColors.InactiveBorder;
            panel.BadgeMode = true;
            panel.Location = new Point(212, 52);
            panel.Name = "panel";
            panel.Radius = 0;
            panel.Size = new Size(779, 889);
            panel.TabIndex = 2;
            panel.Text = "panel1";
            panel.Click += panel_Click;
            // 
            // moniqi
            // 
            moniqi.DataSource = null;
            moniqi.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            moniqi.DropDownWidth = 200;
            moniqi.FillColor = Color.White;
            moniqi.FillColorGradient = true;
            moniqi.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point);
            moniqi.ItemHeight = 40;
            moniqi.ItemHoverColor = Color.FromArgb(155, 200, 255);
            moniqi.Items.AddRange(new object[] { "MuMu模拟器", "雷电模拟器5", "雷电模拟器9" });
            moniqi.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            moniqi.Location = new Point(1007, 770);
            moniqi.Margin = new Padding(0);
            moniqi.MinimumSize = new Size(63, 0);
            moniqi.Name = "moniqi";
            moniqi.Padding = new Padding(0, 0, 30, 10);
            moniqi.Radius = 0;
            moniqi.RectColor = Color.DimGray;
            moniqi.ScrollBarBackColor = Color.FromArgb(245, 251, 241);
            moniqi.ScrollBarColor = Color.FromArgb(192, 255, 192);
            moniqi.ScrollBarStyleInherited = false;
            moniqi.Size = new Size(260, 51);
            moniqi.SymbolSize = 24;
            moniqi.TabIndex = 3;
            moniqi.Text = "选择当前模拟器进程";
            moniqi.TextAlignment = ContentAlignment.MiddleLeft;
            moniqi.Watermark = "";
            moniqi.SelectedIndexChanged += moniqi_SelectedIndexChanged;
            // 
            // buttonhuoqujincheng
            // 
            buttonhuoqujincheng.BackActive = Color.AliceBlue;
            buttonhuoqujincheng.BackHover = Color.Aquamarine;
            buttonhuoqujincheng.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            buttonhuoqujincheng.Location = new Point(997, 571);
            buttonhuoqujincheng.Name = "buttonhuoqujincheng";
            buttonhuoqujincheng.Radius = 0;
            buttonhuoqujincheng.Size = new Size(270, 59);
            buttonhuoqujincheng.TabIndex = 4;
            buttonhuoqujincheng.Text = "首次初始化_游戏大厅\r\n";
            buttonhuoqujincheng.Click += buttonhuoqujincheng_Click;
            // 
            // buttondiyibu
            // 
            buttondiyibu.BackHover = Color.Aquamarine;
            buttondiyibu.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            buttondiyibu.Location = new Point(1000, 700);
            buttondiyibu.Name = "buttondiyibu";
            buttondiyibu.Radius = 0;
            buttondiyibu.Size = new Size(270, 59);
            buttondiyibu.TabIndex = 5;
            buttondiyibu.Text = "二次初始化数据";
            buttondiyibu.Click += buttondiyibu_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Microsoft YaHei UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(1007, 52);
            label1.Name = "label1";
            label1.Size = new Size(106, 44);
            label1.TabIndex = 6;
            label1.Text = "吐球键";
            // 
            // label2
            // 
            label2.Font = new Font("Microsoft YaHei UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(1007, 102);
            label2.Name = "label2";
            label2.Size = new Size(106, 44);
            label2.TabIndex = 7;
            label2.Text = "分身键";
            // 
            // comboBoxtuqiu
            // 
            comboBoxtuqiu.BackColor = Color.Gray;
            comboBoxtuqiu.DataSource = null;
            comboBoxtuqiu.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            comboBoxtuqiu.DropDownWidth = 97;
            comboBoxtuqiu.FillColor = Color.White;
            comboBoxtuqiu.FillColor2 = Color.White;
            comboBoxtuqiu.FillColorGradient = true;
            comboBoxtuqiu.Font = new Font("Microsoft YaHei UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            comboBoxtuqiu.ItemHeight = 40;
            comboBoxtuqiu.ItemHoverColor = Color.White;
            comboBoxtuqiu.ItemRectColor = Color.White;
            comboBoxtuqiu.Items.AddRange(new object[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "空格", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "Shift", "Ctrl", "Alt", "鼠标右键", "无" });
            comboBoxtuqiu.ItemSelectBackColor = Color.White;
            comboBoxtuqiu.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            comboBoxtuqiu.Location = new Point(1142, 52);
            comboBoxtuqiu.Margin = new Padding(0);
            comboBoxtuqiu.MinimumSize = new Size(63, 0);
            comboBoxtuqiu.Name = "comboBoxtuqiu";
            comboBoxtuqiu.Padding = new Padding(0, 0, 30, 10);
            comboBoxtuqiu.Radius = 8;
            comboBoxtuqiu.RectColor = Color.Silver;
            comboBoxtuqiu.RectDisableColor = Color.White;
            comboBoxtuqiu.ScrollBarBackColor = Color.FromArgb(245, 251, 241);
            comboBoxtuqiu.ScrollBarColor = Color.Silver;
            comboBoxtuqiu.ScrollBarStyleInherited = false;
            comboBoxtuqiu.Size = new Size(125, 44);
            comboBoxtuqiu.SymbolSize = 24;
            comboBoxtuqiu.TabIndex = 4;
            comboBoxtuqiu.TextAlignment = ContentAlignment.MiddleLeft;
            comboBoxtuqiu.Watermark = "";
            comboBoxtuqiu.SelectedIndexChanged += comboBoxtuqiu_SelectedIndexChanged;
            // 
            // comboBoxfenshen
            // 
            comboBoxfenshen.DataSource = null;
            comboBoxfenshen.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            comboBoxfenshen.DropDownWidth = 97;
            comboBoxfenshen.FillColor = Color.White;
            comboBoxfenshen.FillColor2 = Color.White;
            comboBoxfenshen.FillColorGradient = true;
            comboBoxfenshen.Font = new Font("Microsoft YaHei UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            comboBoxfenshen.ItemHeight = 40;
            comboBoxfenshen.ItemHoverColor = Color.White;
            comboBoxfenshen.ItemRectColor = Color.White;
            comboBoxfenshen.Items.AddRange(new object[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "空格", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "Shift", "Ctrl", "Alt", "鼠标右键", "无" });
            comboBoxfenshen.ItemSelectBackColor = Color.White;
            comboBoxfenshen.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            comboBoxfenshen.Location = new Point(1142, 103);
            comboBoxfenshen.Margin = new Padding(0);
            comboBoxfenshen.MinimumSize = new Size(63, 0);
            comboBoxfenshen.Name = "comboBoxfenshen";
            comboBoxfenshen.Padding = new Padding(0, 0, 30, 10);
            comboBoxfenshen.RectColor = Color.Silver;
            comboBoxfenshen.RectDisableColor = Color.White;
            comboBoxfenshen.ScrollBarBackColor = Color.FromArgb(245, 251, 241);
            comboBoxfenshen.ScrollBarColor = Color.FromArgb(110, 190, 40);
            comboBoxfenshen.ScrollBarStyleInherited = false;
            comboBoxfenshen.Size = new Size(125, 44);
            comboBoxfenshen.SymbolSize = 24;
            comboBoxfenshen.TabIndex = 5;
            comboBoxfenshen.TextAlignment = ContentAlignment.MiddleLeft;
            comboBoxfenshen.Watermark = "";
            comboBoxfenshen.SelectedIndexChanged += comboBoxfenshen_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.Font = new Font("Microsoft YaHei UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(1000, 152);
            label3.Name = "label3";
            label3.Size = new Size(138, 44);
            label3.TabIndex = 8;
            label3.Text = "遥杆大小";
            label3.Click += label3_Click;
            // 
            // textBoxyaogandaxiao
            // 
            textBoxyaogandaxiao.ButtonFillColor = Color.White;
            textBoxyaogandaxiao.ButtonFillHoverColor = Color.White;
            textBoxyaogandaxiao.ButtonRectColor = Color.White;
            textBoxyaogandaxiao.ButtonRectHoverColor = Color.White;
            textBoxyaogandaxiao.ButtonRectPressColor = Color.White;
            textBoxyaogandaxiao.ButtonStyleInherited = false;
            textBoxyaogandaxiao.DoubleValue = 1.6D;
            textBoxyaogandaxiao.Font = new Font("Microsoft YaHei UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxyaogandaxiao.Location = new Point(1142, 152);
            textBoxyaogandaxiao.Margin = new Padding(4, 5, 4, 5);
            textBoxyaogandaxiao.MaxLength = 4;
            textBoxyaogandaxiao.MinimumSize = new Size(1, 16);
            textBoxyaogandaxiao.Name = "textBoxyaogandaxiao";
            textBoxyaogandaxiao.Padding = new Padding(5);
            textBoxyaogandaxiao.RectColor = Color.Silver;
            textBoxyaogandaxiao.ShowText = false;
            textBoxyaogandaxiao.Size = new Size(125, 43);
            textBoxyaogandaxiao.TabIndex = 9;
            textBoxyaogandaxiao.Text = "1.60";
            textBoxyaogandaxiao.TextAlignment = ContentAlignment.MiddleCenter;
            textBoxyaogandaxiao.Watermark = "";
            textBoxyaogandaxiao.TextChanged += textBoxyaogandaxiao_TextChanged;
            textBoxyaogandaxiao.KeyPress += textBoxyaogandaxiao_KeyPress;
            // 
            // buttonchushihua
            // 
            buttonchushihua.BackActive = Color.AliceBlue;
            buttonchushihua.BackHover = Color.Aquamarine;
            buttonchushihua.Font = new Font("微软雅黑", 12.75F, FontStyle.Regular, GraphicsUnit.Point);
            buttonchushihua.Location = new Point(0, 186);
            buttonchushihua.Name = "buttonchushihua";
            buttonchushihua.Radius = 0;
            buttonchushihua.Size = new Size(192, 62);
            buttonchushihua.TabIndex = 11;
            buttonchushihua.Text = "合球初始化";
            buttonchushihua.Click += buttonchushihua_Click;
            // 
            // comboBoxhqyc
            // 
            comboBoxhqyc.BackColor = SystemColors.ControlLightLight;
            comboBoxhqyc.DataSource = null;
            comboBoxhqyc.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            comboBoxhqyc.DropDownWidth = 200;
            comboBoxhqyc.FillColor = Color.White;
            comboBoxhqyc.FillColorGradient = true;
            comboBoxhqyc.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxhqyc.ItemHeight = 40;
            comboBoxhqyc.ItemHoverColor = Color.FromArgb(155, 200, 255);
            comboBoxhqyc.Items.AddRange(new object[] { "实战通用延迟-慢速[稳定]", "实战通用延迟-快速[激进]", "技战室延迟[稳定]", "自建房通用延迟-慢速[稳定]", "自建房通用延迟-快速[激进]" });
            comboBoxhqyc.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            comboBoxhqyc.Location = new Point(0, 127);
            comboBoxhqyc.Margin = new Padding(0);
            comboBoxhqyc.MinimumSize = new Size(63, 0);
            comboBoxhqyc.Name = "comboBoxhqyc";
            comboBoxhqyc.Padding = new Padding(0, 0, 30, 10);
            comboBoxhqyc.RectColor = Color.Silver;
            comboBoxhqyc.RectDisableColor = Color.Silver;
            comboBoxhqyc.ScrollBarBackColor = Color.FromArgb(245, 251, 241);
            comboBoxhqyc.ScrollBarColor = Color.FromArgb(110, 190, 40);
            comboBoxhqyc.ScrollBarStyleInherited = false;
            comboBoxhqyc.Size = new Size(192, 42);
            comboBoxhqyc.SymbolSize = 24;
            comboBoxhqyc.TabIndex = 47;
            comboBoxhqyc.Text = "技战室延迟[稳定]";
            comboBoxhqyc.TextAlignment = ContentAlignment.MiddleCenter;
            comboBoxhqyc.Watermark = "";
            comboBoxhqyc.SelectedIndexChanged += comboBoxhqyc_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(44, 95);
            label4.Name = "label4";
            label4.Size = new Size(138, 24);
            label4.TabIndex = 46;
            label4.Text = "合球全局延迟";
            label4.Click += label4_Click;
            // 
            // buttondaochupz
            // 
            buttondaochupz.Font = new Font("微軟正黑體", 10F, FontStyle.Regular, GraphicsUnit.Point);
            buttondaochupz.Location = new Point(106, 46);
            buttondaochupz.Name = "buttondaochupz";
            buttondaochupz.Radius = 0;
            buttondaochupz.Size = new Size(103, 40);
            buttondaochupz.TabIndex = 20;
            buttondaochupz.Text = "导出配置";
            buttondaochupz.Click += buttondaochupz_Click;
            // 
            // buttondaorupz
            // 
            buttondaorupz.Font = new Font("微軟正黑體", 10F, FontStyle.Regular, GraphicsUnit.Point);
            buttondaorupz.Location = new Point(0, 46);
            buttondaorupz.Name = "buttondaorupz";
            buttondaorupz.Radius = 0;
            buttondaorupz.Size = new Size(100, 40);
            buttondaorupz.TabIndex = 19;
            buttondaorupz.Text = "导入配置";
            buttondaorupz.Click += buttondaorupz_Click;
            // 
            // uiGroupBox2
            // 
            uiGroupBox2.Controls.Add(tishi);
            uiGroupBox2.FillColor = SystemColors.InactiveBorder;
            uiGroupBox2.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            uiGroupBox2.Location = new Point(1000, 205);
            uiGroupBox2.Margin = new Padding(4, 5, 4, 5);
            uiGroupBox2.MinimumSize = new Size(1, 1);
            uiGroupBox2.Name = "uiGroupBox2";
            uiGroupBox2.Padding = new Padding(0, 32, 0, 0);
            uiGroupBox2.Radius = 20;
            uiGroupBox2.RectColor = SystemColors.WindowText;
            uiGroupBox2.Size = new Size(271, 363);
            uiGroupBox2.TabIndex = 51;
            uiGroupBox2.Text = "日志：";
            uiGroupBox2.TextAlignment = ContentAlignment.MiddleLeft;
            // 
            // tishi
            // 
            tishi.FillColor2 = Color.White;
            tishi.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            tishi.ForeColor = Color.Black;
            tishi.Location = new Point(4, 29);
            tishi.Margin = new Padding(4, 5, 4, 5);
            tishi.MinimumSize = new Size(1, 16);
            tishi.Multiline = true;
            tishi.Name = "tishi";
            tishi.Padding = new Padding(5);
            tishi.Radius = 10;
            tishi.ReadOnly = true;
            tishi.ScrollBarColor = Color.Silver;
            tishi.ScrollBarStyleInherited = false;
            tishi.ShowScrollBar = true;
            tishi.ShowText = false;
            tishi.Size = new Size(263, 329);
            tishi.TabIndex = 50;
            tishi.TextAlignment = ContentAlignment.TopLeft;
            tishi.Watermark = "";
            tishi.TextChanged += tishi_TextChanged;
            // 
            // openFileDialog1
            // 
            openFileDialog1.Filter = "ANYE Balls|*.json";
            openFileDialog1.Title = "选择ANYE Balls配置文件";
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.DefaultExt = "json";
            saveFileDialog1.Filter = "ANYE Balls|*.json";
            saveFileDialog1.Title = "选择ANYE Balls配置文件保存路径";
            // 
            // uiTextBox2
            // 
            uiTextBox2.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            uiTextBox2.Location = new Point(1116, 408);
            uiTextBox2.Margin = new Padding(4, 5, 4, 5);
            uiTextBox2.MaxLength = 1000;
            uiTextBox2.MinimumSize = new Size(1, 16);
            uiTextBox2.Name = "uiTextBox2";
            uiTextBox2.Padding = new Padding(5);
            uiTextBox2.ShowText = false;
            uiTextBox2.Size = new Size(132, 31);
            uiTextBox2.TabIndex = 53;
            uiTextBox2.Text = "0";
            uiTextBox2.TextAlignment = ContentAlignment.MiddleCenter;
            uiTextBox2.Visible = false;
            uiTextBox2.Watermark = "";
            uiTextBox2.TextChanged += uiTextBox2_TextChanged;
            // 
            // uiTextBox3
            // 
            uiTextBox3.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            uiTextBox3.Location = new Point(1116, 439);
            uiTextBox3.Margin = new Padding(4, 5, 4, 5);
            uiTextBox3.MaxLength = 1000;
            uiTextBox3.MinimumSize = new Size(1, 16);
            uiTextBox3.Name = "uiTextBox3";
            uiTextBox3.Padding = new Padding(5);
            uiTextBox3.ShowText = false;
            uiTextBox3.Size = new Size(132, 31);
            uiTextBox3.TabIndex = 54;
            uiTextBox3.Text = "0";
            uiTextBox3.TextAlignment = ContentAlignment.MiddleCenter;
            uiTextBox3.Visible = false;
            uiTextBox3.Watermark = "";
            // 
            // uiTextBox4
            // 
            uiTextBox4.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            uiTextBox4.Location = new Point(1116, 470);
            uiTextBox4.Margin = new Padding(4, 5, 4, 5);
            uiTextBox4.MaxLength = 1000;
            uiTextBox4.MinimumSize = new Size(1, 16);
            uiTextBox4.Name = "uiTextBox4";
            uiTextBox4.Padding = new Padding(5);
            uiTextBox4.ShowText = false;
            uiTextBox4.Size = new Size(132, 31);
            uiTextBox4.TabIndex = 55;
            uiTextBox4.Text = "0";
            uiTextBox4.TextAlignment = ContentAlignment.MiddleCenter;
            uiTextBox4.Visible = false;
            uiTextBox4.Watermark = "";
            // 
            // uiTextBox5
            // 
            uiTextBox5.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            uiTextBox5.Location = new Point(1116, 501);
            uiTextBox5.Margin = new Padding(4, 5, 4, 5);
            uiTextBox5.MaxLength = 1000;
            uiTextBox5.MinimumSize = new Size(1, 16);
            uiTextBox5.Name = "uiTextBox5";
            uiTextBox5.Padding = new Padding(5);
            uiTextBox5.ShowText = false;
            uiTextBox5.Size = new Size(132, 31);
            uiTextBox5.TabIndex = 56;
            uiTextBox5.Text = "0";
            uiTextBox5.TextAlignment = ContentAlignment.MiddleCenter;
            uiTextBox5.Visible = false;
            uiTextBox5.Watermark = "";
            // 
            // uiTextBox6
            // 
            uiTextBox6.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            uiTextBox6.Location = new Point(1116, 532);
            uiTextBox6.Margin = new Padding(4, 5, 4, 5);
            uiTextBox6.MaxLength = 1000;
            uiTextBox6.MinimumSize = new Size(1, 16);
            uiTextBox6.Name = "uiTextBox6";
            uiTextBox6.Padding = new Padding(5);
            uiTextBox6.ShowText = false;
            uiTextBox6.Size = new Size(132, 31);
            uiTextBox6.TabIndex = 57;
            uiTextBox6.Text = "0";
            uiTextBox6.TextAlignment = ContentAlignment.MiddleCenter;
            uiTextBox6.Visible = false;
            uiTextBox6.Watermark = "";
            // 
            // label6
            // 
            label6.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(1039, 402);
            label6.Name = "label6";
            label6.Size = new Size(56, 37);
            label6.TabIndex = 58;
            label6.Text = "全局";
            label6.Visible = false;
            // 
            // label7
            // 
            label7.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(1039, 433);
            label7.Name = "label7";
            label7.Size = new Size(74, 44);
            label7.TabIndex = 59;
            label7.Text = "粘合";
            label7.Visible = false;
            // 
            // label8
            // 
            label8.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(1039, 465);
            label8.Name = "label8";
            label8.Size = new Size(74, 44);
            label8.TabIndex = 60;
            label8.Text = "";
            // 
            // label9
            // 
            label9.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(1039, 463);
            label9.Name = "label9";
            label9.Size = new Size(74, 44);
            label9.TabIndex = 61;
            label9.Text = "遥杆";
            label9.Visible = false;
            // 
            // label10
            // 
            label10.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(1039, 494);
            label10.Name = "label10";
            label10.Size = new Size(74, 44);
            label10.TabIndex = 62;
            label10.Text = "变速";
            label10.Visible = false;
            // 
            // label11
            // 
            label11.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(1039, 525);
            label11.Name = "label11";
            label11.Size = new Size(74, 44);
            label11.TabIndex = 63;
            label11.Text = "回弹";
            label11.Visible = false;
            // 
            // uiTextBox7
            // 
            uiTextBox7.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            uiTextBox7.Location = new Point(1116, 563);
            uiTextBox7.Margin = new Padding(4, 5, 4, 5);
            uiTextBox7.MaxLength = 1000;
            uiTextBox7.MinimumSize = new Size(1, 16);
            uiTextBox7.Name = "uiTextBox7";
            uiTextBox7.Padding = new Padding(5);
            uiTextBox7.ShowText = false;
            uiTextBox7.Size = new Size(132, 31);
            uiTextBox7.TabIndex = 64;
            uiTextBox7.Text = "0";
            uiTextBox7.TextAlignment = ContentAlignment.MiddleCenter;
            uiTextBox7.Visible = false;
            uiTextBox7.Watermark = "";
            // 
            // label12
            // 
            label12.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(1039, 557);
            label12.Name = "label12";
            label12.Size = new Size(74, 44);
            label12.TabIndex = 65;
            label12.Text = "昵称";
            label12.Visible = false;
            // 
            // windowBar
            // 
            windowBar.BackColor = SystemColors.ButtonFace;
            windowBar.Font = new Font("Microsoft JhengHei UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            windowBar.ForeColor = SystemColors.ControlText;
            windowBar.Icon = (Image)resources.GetObject("windowBar.Icon");
            windowBar.Location = new Point(0, 0);
            windowBar.MaximizeBox = false;
            windowBar.Mode = AntdUI.TAMode.Light;
            windowBar.Name = "windowBar";
            windowBar.RightToLeft = RightToLeft.No;
            windowBar.Size = new Size(1281, 46);
            windowBar.SubText = "";
            windowBar.TabIndex = 66;
            windowBar.Text = "子阳";
            windowBar.UseLeft = 5;
            // 
            // buttonshiyeneicung
            // 
            buttonshiyeneicung.BackHover = Color.Aquamarine;
            buttonshiyeneicung.Font = new Font("微软雅黑", 10F, FontStyle.Regular, GraphicsUnit.Point);
            buttonshiyeneicung.Location = new Point(1000, 635);
            buttonshiyeneicung.Name = "buttonshiyeneicung";
            buttonshiyeneicung.Radius = 0;
            buttonshiyeneicung.Size = new Size(130, 59);
            buttonshiyeneicung.TabIndex = 6;
            buttonshiyeneicung.Text = "初始化视野/内存";
            buttonshiyeneicung.Click += buttonshiyeneicung_Click;
            // 
            // buttonyaoganfenshen
            // 
            buttonyaoganfenshen.BackHover = Color.Aquamarine;
            buttonyaoganfenshen.Font = new Font("微软雅黑", 10F, FontStyle.Regular, GraphicsUnit.Point);
            buttonyaoganfenshen.Location = new Point(1137, 635);
            buttonyaoganfenshen.Name = "buttonyaoganfenshen";
            buttonyaoganfenshen.Radius = 0;
            buttonyaoganfenshen.Size = new Size(130, 59);
            buttonyaoganfenshen.TabIndex = 7;
            buttonyaoganfenshen.Text = "初始化摇杆/分身";
            buttonyaoganfenshen.Click += buttonyaoganfenshen_Click;
            // 
            // MainForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = SystemColors.InactiveBorder;
            ClientSize = new Size(1284, 957);
            Controls.Add(buttonyaoganfenshen);
            Controls.Add(buttonshiyeneicung);
            Controls.Add(comboBoxhqyc);
            Controls.Add(buttonchushihua);
            Controls.Add(windowBar);
            Controls.Add(buttondaorupz);
            Controls.Add(buttondiyibu);
            Controls.Add(buttondaochupz);
            Controls.Add(moniqi);
            Controls.Add(label4);
            Controls.Add(buttonhuoqujincheng);
            Controls.Add(comboBoxfenshen);
            Controls.Add(uiGroupBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label12);
            Controls.Add(label1);
            Controls.Add(uiTextBox7);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(uiTextBox6);
            Controls.Add(uiTextBox5);
            Controls.Add(uiTextBox4);
            Controls.Add(uiTextBox3);
            Controls.Add(uiTextBox2);
            Controls.Add(textBoxyaogandaxiao);
            Controls.Add(comboBoxtuqiu);
            Controls.Add(panel);
            Controls.Add(treeView);
            Controls.Add(label6);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            Text = "MainForm";
            FormClosing += MainForm_FormClosing;
            FormClosed += MainForm_FormClosed;
            Load += MainForm_Load;
            Resize += MainForm_Resize;
            uiGroupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private AntdUI.Tree treeView;
        private AntdUI.Panel panel;
        private Sunny.UI.UIComboBox moniqi;
        private AntdUI.Button buttonhuoqujincheng;
        private AntdUI.Button buttondiyibu;
        private AntdUI.Label label1;
        private AntdUI.Label label2;
        private AntdUI.Label label3;
        private Sunny.UI.UITextBox textBoxyaogandaxiao;
        private AntdUI.Button buttonchushihua;

        private AntdUI.Button buttondaochupz;
        private AntdUI.Button buttondaorupz;
        private AntdUI.Label label4;
        private Sunny.UI.UIComboBox comboBoxhqyc;
        private Sunny.UI.UIGroupBox uiGroupBox2;
        public Sunny.UI.UITextBox tishi;
        public Sunny.UI.UIComboBox comboBoxtuqiu;
        public Sunny.UI.UIComboBox comboBoxfenshen;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private Sunny.UI.UITextBox uiTextBox2;
        private Sunny.UI.UITextBox uiTextBox3;
        private Sunny.UI.UITextBox uiTextBox4;
        private Sunny.UI.UITextBox uiTextBox5;
        private Sunny.UI.UITextBox uiTextBox6;
        private AntdUI.Label label6;
        private AntdUI.Label label7;
        private AntdUI.Label label8;
        private AntdUI.Label label9;
        private AntdUI.Label label10;
        private AntdUI.Label label11;
        private Sunny.UI.UITextBox uiTextBox7;
        private AntdUI.Label label12;
        private AntdUI.WindowBar windowBar;
        private AntdUI.Button buttonshiyeneicung;
        private AntdUI.Button buttonyaoganfenshen;
    }
}
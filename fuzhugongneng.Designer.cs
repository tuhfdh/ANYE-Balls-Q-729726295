namespace ANYE_Balls
{
    partial class fuzhugongneng
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            uiGroupBox1 = new Sunny.UI.UIGroupBox();
            checkboxygtm = new AntdUI.Checkbox();
            label10 = new AntdUI.Label();
            checkboxkongqiu = new AntdUI.Checkbox();
            textboxkongqiu = new Sunny.UI.UITextBox();
            label7 = new AntdUI.Label();
            comboBoxtsuoqiu = new Sunny.UI.UIComboBox();
            checkboxsuoqiu = new AntdUI.Checkbox();
            label12 = new AntdUI.Label();
            uiGroupBox2 = new Sunny.UI.UIGroupBox();
            uiTextBox1huizhigaodupianyi = new Sunny.UI.UITextBox();
            label8 = new AntdUI.Label();
            checkboxtuxianghuizhi = new AntdUI.Checkbox();
            buttonInitElf = new AntdUI.Button();
            comboAiLock = new Sunny.UI.UIComboBox();
            textboxAiSplitDelay = new Sunny.UI.UITextBox();
            checkboxAiLock = new AntdUI.Checkbox();
            comboAiTrack = new Sunny.UI.UIComboBox();
            checkboxAiTrack = new AntdUI.Checkbox();
            textboxTargetUid = new Sunny.UI.UITextBox();
            comboMouseRank = new Sunny.UI.UIComboBox();
            textboxAiSplitCount = new Sunny.UI.UITextBox();
            labelAiSplitDelay = new AntdUI.Label();
            labelAiStatus = new AntdUI.Label();
            labelMouseRank = new AntdUI.Label();
            labelTargetUid = new AntdUI.Label();
            labelAiSplitCount = new AntdUI.Label();
            labelAiTrack = new AntdUI.Label();
            label9 = new AntdUI.Label();
            labelAiLock = new AntdUI.Label();
            label11 = new AntdUI.Label();
            checkbox1zidonghuoqupaiming = new AntdUI.Checkbox();
            uiGroupBox1.SuspendLayout();
            uiGroupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // uiGroupBox1
            // 
            uiGroupBox1.Controls.Add(checkboxygtm);
            uiGroupBox1.Controls.Add(label10);
            uiGroupBox1.Controls.Add(checkboxkongqiu);
            uiGroupBox1.Controls.Add(textboxkongqiu);
            uiGroupBox1.Controls.Add(label7);
            uiGroupBox1.Controls.Add(comboBoxtsuoqiu);
            uiGroupBox1.Controls.Add(checkboxsuoqiu);
            uiGroupBox1.Controls.Add(label12);
            uiGroupBox1.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            uiGroupBox1.Location = new Point(14, 5);
            uiGroupBox1.Margin = new Padding(4, 5, 4, 5);
            uiGroupBox1.MinimumSize = new Size(1, 1);
            uiGroupBox1.Name = "uiGroupBox1";
            uiGroupBox1.Padding = new Padding(0, 32, 0, 0);
            uiGroupBox1.Radius = 20;
            uiGroupBox1.RectColor = SystemColors.ActiveBorder;
            uiGroupBox1.Size = new Size(753, 165);
            uiGroupBox1.TabIndex = 27;
            uiGroupBox1.Text = "辅助功能";
            uiGroupBox1.TextAlignment = ContentAlignment.MiddleLeft;
            // 
            // checkboxygtm
            // 
            checkboxygtm.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            checkboxygtm.Location = new Point(129, 126);
            checkboxygtm.Name = "checkboxygtm";
            checkboxygtm.Size = new Size(90, 23);
            checkboxygtm.TabIndex = 57;
            checkboxygtm.Text = "启用";
            checkboxygtm.CheckedChanged += checkboxygtm_CheckedChanged;
            // 
            // label10
            // 
            label10.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(15, 125);
            label10.Name = "label10";
            label10.Size = new Size(120, 23);
            label10.TabIndex = 56;
            label10.Text = "遥杆全透明";
            // 
            // checkboxkongqiu
            // 
            checkboxkongqiu.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            checkboxkongqiu.Location = new Point(282, 89);
            checkboxkongqiu.Name = "checkboxkongqiu";
            checkboxkongqiu.Size = new Size(135, 23);
            checkboxkongqiu.TabIndex = 18;
            checkboxkongqiu.Text = "启用";
            checkboxkongqiu.CheckedChanged += checkboxkongqiu_CheckedChanged;
            // 
            // textboxkongqiu
            // 
            textboxkongqiu.Font = new Font("Microsoft YaHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textboxkongqiu.Location = new Point(198, 84);
            textboxkongqiu.Margin = new Padding(4, 5, 4, 5);
            textboxkongqiu.MaxLength = 3;
            textboxkongqiu.MinimumSize = new Size(1, 16);
            textboxkongqiu.Name = "textboxkongqiu";
            textboxkongqiu.Padding = new Padding(5);
            textboxkongqiu.RectColor = Color.FromArgb(255, 255, 192);
            textboxkongqiu.ShowText = false;
            textboxkongqiu.Size = new Size(77, 30);
            textboxkongqiu.TabIndex = 17;
            textboxkongqiu.Text = "0";
            textboxkongqiu.TextAlignment = ContentAlignment.MiddleCenter;
            textboxkongqiu.Watermark = "";
            textboxkongqiu.TextChanged += textboxkongqiu_TextChanged;
            textboxkongqiu.KeyPress += textboxNumber_KeyPress;
            // 
            // label7
            // 
            label7.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(17, 88);
            label7.Name = "label7";
            label7.Size = new Size(184, 23);
            label7.TabIndex = 16;
            label7.Text = "鼠标右键交叉控球";
            // 
            // comboBoxtsuoqiu
            // 
            comboBoxtsuoqiu.DataSource = null;
            comboBoxtsuoqiu.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            comboBoxtsuoqiu.DropDownWidth = 70;
            comboBoxtsuoqiu.FillColor = Color.White;
            comboBoxtsuoqiu.FillColorGradient = true;
            comboBoxtsuoqiu.Font = new Font("Microsoft YaHei UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            comboBoxtsuoqiu.ItemHeight = 40;
            comboBoxtsuoqiu.ItemHoverColor = Color.FromArgb(155, 200, 255);
            comboBoxtsuoqiu.Items.AddRange(new object[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "空格", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "Shift", "Ctrl", "Alt", "鼠标右键", "无" });
            comboBoxtsuoqiu.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            comboBoxtsuoqiu.Location = new Point(175, 40);
            comboBoxtsuoqiu.Margin = new Padding(0);
            comboBoxtsuoqiu.MaxDropDownItems = 30;
            comboBoxtsuoqiu.MinimumSize = new Size(63, 0);
            comboBoxtsuoqiu.Name = "comboBoxtsuoqiu";
            comboBoxtsuoqiu.Padding = new Padding(0, 0, 30, 10);
            comboBoxtsuoqiu.ScrollBarBackColor = Color.FromArgb(245, 251, 241);
            comboBoxtsuoqiu.ScrollBarColor = Color.FromArgb(110, 190, 40);
            comboBoxtsuoqiu.ScrollBarStyleInherited = false;
            comboBoxtsuoqiu.Size = new Size(70, 31);
            comboBoxtsuoqiu.SymbolSize = 24;
            comboBoxtsuoqiu.TabIndex = 15;
            comboBoxtsuoqiu.Text = "A";
            comboBoxtsuoqiu.TextAlignment = ContentAlignment.MiddleLeft;
            comboBoxtsuoqiu.Watermark = "";
            comboBoxtsuoqiu.SelectedIndexChanged += comboBoxtsuoqiu_SelectedIndexChanged;
            // 
            // checkboxsuoqiu
            // 
            checkboxsuoqiu.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            checkboxsuoqiu.Location = new Point(250, 44);
            checkboxsuoqiu.Name = "checkboxsuoqiu";
            checkboxsuoqiu.Size = new Size(135, 23);
            checkboxsuoqiu.TabIndex = 12;
            checkboxsuoqiu.Text = "启用";
            checkboxsuoqiu.CheckedChanged += checkboxsuoqiu_CheckedChanged;
            // 
            // label12
            // 
            label12.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(14, 44);
            label12.Name = "label12";
            label12.Size = new Size(161, 23);
            label12.TabIndex = 0;
            label12.Text = "锁球单独快捷键";
            // 
            // uiGroupBox2
            // 
            uiGroupBox2.Controls.Add(uiTextBox1huizhigaodupianyi);
            uiGroupBox2.Controls.Add(label8);
            uiGroupBox2.Controls.Add(checkboxtuxianghuizhi);
            uiGroupBox2.Controls.Add(buttonInitElf);
            uiGroupBox2.Controls.Add(comboAiLock);
            uiGroupBox2.Controls.Add(textboxAiSplitDelay);
            uiGroupBox2.Controls.Add(checkboxAiLock);
            uiGroupBox2.Controls.Add(comboAiTrack);
            uiGroupBox2.Controls.Add(checkboxAiTrack);
            uiGroupBox2.Controls.Add(textboxTargetUid);
            uiGroupBox2.Controls.Add(comboMouseRank);
            uiGroupBox2.Controls.Add(textboxAiSplitCount);
            uiGroupBox2.Controls.Add(labelAiSplitDelay);
            uiGroupBox2.Controls.Add(labelAiStatus);
            uiGroupBox2.Controls.Add(labelMouseRank);
            uiGroupBox2.Controls.Add(labelTargetUid);
            uiGroupBox2.Controls.Add(labelAiSplitCount);
            uiGroupBox2.Controls.Add(labelAiTrack);
            uiGroupBox2.Controls.Add(label9);
            uiGroupBox2.Controls.Add(labelAiLock);
            uiGroupBox2.Controls.Add(label11);
            uiGroupBox2.Controls.Add(checkbox1zidonghuoqupaiming);
            uiGroupBox2.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            uiGroupBox2.Location = new Point(14, 165);
            uiGroupBox2.Margin = new Padding(4, 5, 4, 5);
            uiGroupBox2.MinimumSize = new Size(1, 1);
            uiGroupBox2.Name = "uiGroupBox2";
            uiGroupBox2.Padding = new Padding(0, 32, 0, 0);
            uiGroupBox2.Radius = 20;
            uiGroupBox2.RectColor = SystemColors.ActiveBorder;
            uiGroupBox2.Size = new Size(753, 233);
            uiGroupBox2.TabIndex = 29;
            uiGroupBox2.Text = "ELF交互/AI功能";
            uiGroupBox2.TextAlignment = ContentAlignment.MiddleLeft;
            // 
            // uiTextBox1huizhigaodupianyi
            // 
            uiTextBox1huizhigaodupianyi.Font = new Font("Microsoft YaHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            uiTextBox1huizhigaodupianyi.Location = new Point(646, 184);
            uiTextBox1huizhigaodupianyi.Margin = new Padding(4, 5, 4, 5);
            uiTextBox1huizhigaodupianyi.MinimumSize = new Size(1, 16);
            uiTextBox1huizhigaodupianyi.Name = "uiTextBox1huizhigaodupianyi";
            uiTextBox1huizhigaodupianyi.Padding = new Padding(5);
            uiTextBox1huizhigaodupianyi.ShowText = false;
            uiTextBox1huizhigaodupianyi.Size = new Size(95, 31);
            uiTextBox1huizhigaodupianyi.TabIndex = 18;
            uiTextBox1huizhigaodupianyi.Text = "0";
            uiTextBox1huizhigaodupianyi.TextAlignment = ContentAlignment.MiddleCenter;
            uiTextBox1huizhigaodupianyi.Watermark = "";
            // 
            // label8
            // 
            label8.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(501, 144);
            label8.Name = "label8";
            label8.Size = new Size(166, 23);
            label8.TabIndex = 17;
            label8.Text = "绘制目标与排名";
            // 
            // checkboxtuxianghuizhi
            // 
            checkboxtuxianghuizhi.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            checkboxtuxianghuizhi.Location = new Point(660, 144);
            checkboxtuxianghuizhi.Name = "checkboxtuxianghuizhi";
            checkboxtuxianghuizhi.Size = new Size(90, 23);
            checkboxtuxianghuizhi.TabIndex = 16;
            checkboxtuxianghuizhi.Text = "启用";
            // 
            // buttonInitElf
            // 
            buttonInitElf.Font = new Font("Microsoft YaHei UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            buttonInitElf.Location = new Point(10, 40);
            buttonInitElf.Name = "buttonInitElf";
            buttonInitElf.Size = new Size(214, 35);
            buttonInitElf.TabIndex = 1;
            buttonInitElf.Text = "注入ELF与搜索环境";
            buttonInitElf.Type = AntdUI.TTypeMini.Primary;
            buttonInitElf.Click += buttonInitElf_Click;
            // 
            // comboAiLock
            // 
            comboAiLock.DataSource = null;
            comboAiLock.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            comboAiLock.FillColor = Color.White;
            comboAiLock.Font = new Font("Microsoft YaHei UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            comboAiLock.ItemHoverColor = Color.FromArgb(155, 200, 255);
            comboAiLock.Items.AddRange(new object[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "空格", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "Shift", "Ctrl", "Alt", "鼠标右键", "无" });
            comboAiLock.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            comboAiLock.Location = new Point(400, 90);
            comboAiLock.Margin = new Padding(4, 5, 4, 5);
            comboAiLock.MinimumSize = new Size(63, 0);
            comboAiLock.Name = "comboAiLock";
            comboAiLock.Padding = new Padding(0, 0, 30, 10);
            comboAiLock.Size = new Size(83, 31);
            comboAiLock.SymbolSize = 24;
            comboAiLock.TabIndex = 3;
            comboAiLock.Text = "A";
            comboAiLock.TextAlignment = ContentAlignment.MiddleLeft;
            comboAiLock.Watermark = "";
            comboAiLock.SelectedIndexChanged += comboAiLock_SelectedIndexChanged;
            // 
            // textboxAiSplitDelay
            // 
            textboxAiSplitDelay.Font = new Font("Microsoft YaHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textboxAiSplitDelay.Location = new Point(371, 142);
            textboxAiSplitDelay.Margin = new Padding(4, 5, 4, 5);
            textboxAiSplitDelay.MinimumSize = new Size(1, 16);
            textboxAiSplitDelay.Name = "textboxAiSplitDelay";
            textboxAiSplitDelay.Padding = new Padding(5);
            textboxAiSplitDelay.ShowText = false;
            textboxAiSplitDelay.Size = new Size(95, 31);
            textboxAiSplitDelay.TabIndex = 15;
            textboxAiSplitDelay.Text = "0";
            textboxAiSplitDelay.TextAlignment = ContentAlignment.MiddleCenter;
            textboxAiSplitDelay.Watermark = "";
            textboxAiSplitDelay.TextChanged += textboxAiSplitDelay_TextChanged;
            textboxAiSplitDelay.KeyPress += textboxNumber_KeyPress;
            // 
            // checkboxAiLock
            // 
            checkboxAiLock.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            checkboxAiLock.Location = new Point(479, 94);
            checkboxAiLock.Name = "checkboxAiLock";
            checkboxAiLock.Size = new Size(90, 23);
            checkboxAiLock.TabIndex = 4;
            checkboxAiLock.Text = "启用";
            checkboxAiLock.CheckedChanged += checkboxAiLock_CheckedChanged;
            // 
            // comboAiTrack
            // 
            comboAiTrack.DataSource = null;
            comboAiTrack.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            comboAiTrack.FillColor = Color.White;
            comboAiTrack.Font = new Font("Microsoft YaHei UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            comboAiTrack.ItemHoverColor = Color.FromArgb(155, 200, 255);
            comboAiTrack.Items.AddRange(new object[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "空格", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "Shift", "Ctrl", "Alt", "鼠标右键", "无" });
            comboAiTrack.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            comboAiTrack.Location = new Point(123, 90);
            comboAiTrack.Margin = new Padding(4, 5, 4, 5);
            comboAiTrack.MinimumSize = new Size(63, 0);
            comboAiTrack.Name = "comboAiTrack";
            comboAiTrack.Padding = new Padding(0, 0, 30, 10);
            comboAiTrack.Size = new Size(95, 31);
            comboAiTrack.SymbolSize = 24;
            comboAiTrack.TabIndex = 6;
            comboAiTrack.Text = "A";
            comboAiTrack.TextAlignment = ContentAlignment.MiddleLeft;
            comboAiTrack.Watermark = "";
            comboAiTrack.SelectedIndexChanged += comboAiTrack_SelectedIndexChanged;
            // 
            // checkboxAiTrack
            // 
            checkboxAiTrack.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            checkboxAiTrack.Location = new Point(211, 94);
            checkboxAiTrack.Name = "checkboxAiTrack";
            checkboxAiTrack.Size = new Size(90, 23);
            checkboxAiTrack.TabIndex = 7;
            checkboxAiTrack.Text = "启用";
            checkboxAiTrack.CheckedChanged += checkboxAiTrack_CheckedChanged;
            // 
            // textboxTargetUid
            // 
            textboxTargetUid.Font = new Font("Microsoft YaHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textboxTargetUid.Location = new Point(312, 44);
            textboxTargetUid.Margin = new Padding(4, 5, 4, 5);
            textboxTargetUid.MinimumSize = new Size(1, 16);
            textboxTargetUid.Name = "textboxTargetUid";
            textboxTargetUid.Padding = new Padding(5);
            textboxTargetUid.ShowText = false;
            textboxTargetUid.Size = new Size(219, 31);
            textboxTargetUid.TabIndex = 9;
            textboxTargetUid.Text = "请填入/鼠标/自动排名";
            textboxTargetUid.TextAlignment = ContentAlignment.MiddleCenter;
            textboxTargetUid.Watermark = "";
            textboxTargetUid.TextChanged += textboxTargetUid_TextChanged;
            textboxTargetUid.KeyPress += textboxNumber_KeyPress;
            // 
            // comboMouseRank
            // 
            comboMouseRank.DataSource = null;
            comboMouseRank.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            comboMouseRank.FillColor = Color.White;
            comboMouseRank.Font = new Font("Microsoft YaHei UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            comboMouseRank.ItemHoverColor = Color.FromArgb(155, 200, 255);
            comboMouseRank.Items.AddRange(new object[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "空格", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "Shift", "Ctrl", "Alt", "鼠标右键", "无" });
            comboMouseRank.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            comboMouseRank.Location = new Point(671, 44);
            comboMouseRank.Margin = new Padding(4, 5, 4, 5);
            comboMouseRank.MinimumSize = new Size(63, 0);
            comboMouseRank.Name = "comboMouseRank";
            comboMouseRank.Padding = new Padding(0, 0, 30, 10);
            comboMouseRank.Size = new Size(70, 31);
            comboMouseRank.SymbolSize = 24;
            comboMouseRank.TabIndex = 11;
            comboMouseRank.Text = "无";
            comboMouseRank.TextAlignment = ContentAlignment.MiddleLeft;
            comboMouseRank.Watermark = "";
            comboMouseRank.SelectedIndexChanged += comboMouseRank_SelectedIndexChanged;
            // 
            // textboxAiSplitCount
            // 
            textboxAiSplitCount.DoubleValue = 30D;
            textboxAiSplitCount.Font = new Font("Microsoft YaHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            textboxAiSplitCount.IntValue = 30;
            textboxAiSplitCount.Location = new Point(123, 140);
            textboxAiSplitCount.Margin = new Padding(4, 5, 4, 5);
            textboxAiSplitCount.MinimumSize = new Size(1, 16);
            textboxAiSplitCount.Name = "textboxAiSplitCount";
            textboxAiSplitCount.Padding = new Padding(5);
            textboxAiSplitCount.ShowText = false;
            textboxAiSplitCount.Size = new Size(95, 31);
            textboxAiSplitCount.TabIndex = 13;
            textboxAiSplitCount.Text = "30";
            textboxAiSplitCount.TextAlignment = ContentAlignment.MiddleCenter;
            textboxAiSplitCount.Watermark = "";
            textboxAiSplitCount.TextChanged += textboxAiSplitCount_TextChanged;
            textboxAiSplitCount.KeyPress += textboxNumber_KeyPress;
            // 
            // labelAiSplitDelay
            // 
            labelAiSplitDelay.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            labelAiSplitDelay.Location = new Point(227, 146);
            labelAiSplitDelay.Name = "labelAiSplitDelay";
            labelAiSplitDelay.Size = new Size(140, 23);
            labelAiSplitDelay.TabIndex = 14;
            labelAiSplitDelay.Text = "分身延迟(ms)";
            // 
            // labelAiStatus
            // 
            labelAiStatus.Font = new Font("Microsoft JhengHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelAiStatus.ForeColor = Color.DimGray;
            labelAiStatus.Location = new Point(10, 190);
            labelAiStatus.Name = "labelAiStatus";
            labelAiStatus.Size = new Size(470, 23);
            labelAiStatus.TabIndex = 11;
            labelAiStatus.Text = "状态：等待注入ELF与搜索基址...";
            // 
            // labelMouseRank
            // 
            labelMouseRank.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            labelMouseRank.Location = new Point(534, 48);
            labelMouseRank.Name = "labelMouseRank";
            labelMouseRank.Size = new Size(138, 23);
            labelMouseRank.TabIndex = 10;
            labelMouseRank.Text = "获取鼠标排名键";
            // 
            // labelTargetUid
            // 
            labelTargetUid.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            labelTargetUid.Location = new Point(221, 48);
            labelTargetUid.Name = "labelTargetUid";
            labelTargetUid.Size = new Size(95, 23);
            labelTargetUid.TabIndex = 8;
            labelTargetUid.Text = "队友排名";
            // 
            // labelAiSplitCount
            // 
            labelAiSplitCount.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            labelAiSplitCount.Location = new Point(10, 144);
            labelAiSplitCount.Name = "labelAiSplitCount";
            labelAiSplitCount.Size = new Size(130, 23);
            labelAiSplitCount.TabIndex = 12;
            labelAiSplitCount.Text = "大炮分身次数";
            // 
            // labelAiTrack
            // 
            labelAiTrack.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            labelAiTrack.Location = new Point(10, 94);
            labelAiTrack.Name = "labelAiTrack";
            labelAiTrack.Size = new Size(130, 23);
            labelAiTrack.TabIndex = 5;
            labelAiTrack.Text = "大炮追踪键";
            // 
            // label9
            // 
            label9.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(501, 184);
            label9.Name = "label9";
            label9.Size = new Size(144, 31);
            label9.TabIndex = 19;
            label9.Text = "绘制高度偏移";
            // 
            // labelAiLock
            // 
            labelAiLock.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            labelAiLock.Location = new Point(306, 94);
            labelAiLock.Name = "labelAiLock";
            labelAiLock.Size = new Size(95, 23);
            labelAiLock.TabIndex = 2;
            labelAiLock.Text = "AI锁球键";
            // 
            // label11
            // 
            label11.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(573, 96);
            label11.Name = "label11";
            label11.Size = new Size(94, 23);
            label11.TabIndex = 21;
            label11.Text = "自动获取";
            // 
            // checkbox1zidonghuoqupaiming
            // 
            checkbox1zidonghuoqupaiming.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            checkbox1zidonghuoqupaiming.Location = new Point(660, 96);
            checkbox1zidonghuoqupaiming.Name = "checkbox1zidonghuoqupaiming";
            checkbox1zidonghuoqupaiming.Size = new Size(90, 23);
            checkbox1zidonghuoqupaiming.TabIndex = 20;
            checkbox1zidonghuoqupaiming.Text = "启用";
            // 
            // fuzhugongneng
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = SystemColors.InactiveBorder;
            ClientSize = new Size(788, 815);
            Controls.Add(uiGroupBox1);
            Controls.Add(uiGroupBox2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "fuzhugongneng";
            Text = "fuzhugongneng";
            Load += fuzhugongneng_Load;
            uiGroupBox1.ResumeLayout(false);
            uiGroupBox2.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        public Sunny.UI.UIGroupBox uiGroupBox1;
        public Sunny.UI.UIComboBox comboBoxtsuoqiu;
        public AntdUI.Checkbox checkboxsuoqiu;
        public AntdUI.Label label12;
        public AntdUI.Label label7;
        public AntdUI.Checkbox checkboxkongqiu;
        public Sunny.UI.UITextBox textboxkongqiu;
        public AntdUI.Checkbox checkboxygtm;
        public AntdUI.Label label10;
        public Sunny.UI.UIGroupBox uiGroupBox2;

        public AntdUI.Button buttonInitElf;
        public AntdUI.Label labelAiLock;
        public Sunny.UI.UIComboBox comboAiLock;
        public AntdUI.Checkbox checkboxAiLock;
        public AntdUI.Label labelAiTrack;
        public Sunny.UI.UIComboBox comboAiTrack;
        public AntdUI.Checkbox checkboxAiTrack;
        public AntdUI.Label labelTargetUid;
        public Sunny.UI.UITextBox textboxTargetUid;

        public AntdUI.Label labelMouseRank;
        public Sunny.UI.UIComboBox comboMouseRank;

        public AntdUI.Label labelAiSplitCount;
        public Sunny.UI.UITextBox textboxAiSplitCount;
        public AntdUI.Label labelAiSplitDelay;
        public Sunny.UI.UITextBox textboxAiSplitDelay;

        public AntdUI.Label labelAiStatus;

        public AntdUI.Label label8;
        public AntdUI.Checkbox checkboxtuxianghuizhi;
        public Sunny.UI.UITextBox uiTextBox1huizhigaodupianyi;
        public AntdUI.Label label9;
        public AntdUI.Label label11;
        public AntdUI.Checkbox checkbox1zidonghuoqupaiming;
    }
}

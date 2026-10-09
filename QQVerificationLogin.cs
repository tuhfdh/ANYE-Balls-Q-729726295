using System;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ANYE_Balls
{
    public partial class QQVerificationLogin : Form
    {
        private WebBrowser webBrowser1;
        private Button btnJoinGroup;
        private bool verificationStarted = false;

        // 新增：需要验证的两个群号
        private readonly string[] targetGroupNumbers = new string[] { "729726295" };

        //private const string ServerIp = "42.194.241.120";
        //private const int ServerPort = 32408;

        public QQVerificationLogin()
        {
            //if (!CheckServerConnection())
            //{
            //    MessageBox.Show("服务器已关闭或更新，进群获取新版本。Q群：1079499976",
            //        "服务器不可用",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Error);
            //    Environment.Exit(0);
            //}

            SetWebBrowserVersion();
            InitializeComponent();
        }

        private void SetWebBrowserVersion()
        {
            var appName = System.IO.Path.GetFileNameWithoutExtension(
                System.Reflection.Assembly.GetExecutingAssembly().Location);

            using (var key = Registry.CurrentUser.CreateSubKey(
                @"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION",
                RegistryKeyPermissionCheck.ReadWriteSubTree))
            {
                key.SetValue(appName, 11001, RegistryValueKind.DWord);
            }
        }

        private void InitializeComponent()
        {
            webBrowser1 = new WebBrowser();
            btnJoinGroup = new Button();
            SuspendLayout();
            // 
            // webBrowser1
            // 
            webBrowser1.Dock = DockStyle.Fill;
            webBrowser1.Location = new Point(0, 0);
            webBrowser1.MinimumSize = new Size(18, 21);
            webBrowser1.Name = "webBrowser1";
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser1.Size = new Size(700, 478);
            webBrowser1.TabIndex = 0;
            // 
            // btnJoinGroup
            // 
            btnJoinGroup.Dock = DockStyle.Bottom;
            btnJoinGroup.Location = new Point(0, 431);
            btnJoinGroup.Name = "btnJoinGroup";
            btnJoinGroup.Size = new Size(700, 47);
            btnJoinGroup.TabIndex = 1;
            btnJoinGroup.Text = "加入QQ群";
            btnJoinGroup.UseVisualStyleBackColor = true;
            btnJoinGroup.Click += BtnJoinGroup_Click;
            // 
            // QQVerificationLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 478);
            Controls.Add(btnJoinGroup);
            Controls.Add(webBrowser1);
            Name = "QQVerificationLogin";
            Text = "QQ群验证";
            Load += QQVerificationLogin_Load;
            ResumeLayout(false);
        }

        private void BtnJoinGroup_Click(object sender, EventArgs e)
        {
            string url = "http://qm.qq.com/cgi-bin/qm/qr?_wv=1027&k=L9y9FCHYrFuVVrH88bDiowbUBY-GEdjC&authKey=DYgBFfXWSAiW99YlclxkEc7VQoyv%2B61owIJ%2BGMO%2FF8iAPGdqii6cvNgoJ5m2BxyP&noverify=0&group_code=729726295";
            try
            {
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"无法打开浏览器: {ex.Message}");
            }
        }

        private void QQVerificationLogin_Load(object sender, EventArgs e)
        {
            try
            {
                string loginUrl = "https://xui.ptlogin2.qq.com/cgi-bin/xlogin?pt_disable_pwd=1&appid=715030901&daid=73&hide_close_icon=1&pt_no_auth=1&s_url=https%3A%2F%2Fqun.qq.com%2Fmember.html";
                webBrowser1.Navigate(loginUrl);

                webBrowser1.DocumentCompleted += WebBrowser1_DocumentCompleted;
                webBrowser1.Navigated += WebBrowser1_Navigated;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"初始化登录页面失败: {ex.Message}");
                Application.Exit();
            }
        }

        private void WebBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (e.Url.ToString().StartsWith("https://qun.qq.com"))
            {
                StartVerification();
            }
        }

        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser1.Url.ToString().StartsWith("https://qun.qq.com"))
            {
                StartVerification();
            }
        }

        private void StartVerification()
        {
            if (verificationStarted) return;
            verificationStarted = true;

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer
            {
                Interval = 3000
            };
            timer.Tick += (s, args) =>
            {
                timer.Stop();
                PerformVerification();
            };
            timer.Start();
        }

        // 辅助方法：检查文本是否包含任意一个群号
        private bool ContainsAnyGroupNumber(string text)
        {
            foreach (string group in targetGroupNumbers)
            {
                if (text.Contains(group))
                    return true;
            }
            return false;
        }

        private void PerformVerification()
        {
            try
            {
                string html = webBrowser1.Document?.Body?.InnerHtml ?? "";
                if (ContainsAnyGroupNumber(html))
                {
                    MessageBox.Show("验证成功，欢迎使用！");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }

                // HTML中未找到，再检查标题和URL
                if (CheckAlternativeLocations())
                {
                    MessageBox.Show("验证成功，欢迎使用！");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }

                // 两个群号都未找到
                string groups = string.Join(" 729726295", targetGroupNumbers);
                MessageBox.Show($"请加入QQ群 {groups} 后再尝试登录！");
                this.DialogResult = DialogResult.Cancel;
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"验证过程中出现错误: {ex.Message}");
                Application.Exit();
            }
        }

        private bool CheckAlternativeLocations()
        {
            try
            {
                string pageTitle = webBrowser1.Document?.Title ?? "";
                string pageUrl = webBrowser1.Url?.ToString() ?? "";
                // 同时检查标题和URL中是否包含任意群号
                return ContainsAnyGroupNumber(pageTitle) || ContainsAnyGroupNumber(pageUrl);
            }
            catch
            {
                return false;
            }
        }
    }
}
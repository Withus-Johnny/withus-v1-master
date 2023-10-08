using Client.Features.Logger;
using Client.Networks;
using System.IO;
using System.Security.Cryptography;
using System;
using System.Windows.Forms;
using WithusUI.Forms;
using C = ClientPackets;
using System.Diagnostics;

namespace Client.Forms
{
    public partial class LoginForm : WithusForm
    {
        private Stopwatch _stopwatch;

        public LoginForm()
        {
            _stopwatch = Stopwatch.StartNew();

            this.Icon = Properties.Resources.Icon_Withus;
            InitializeComponent();

            this.Text = "위더스 - 로그인";
            this.StartPosition = FormStartPosition.CenterScreen;

            this.Load += LoginForm_Load;
            this.Shown += LoginForm_Shown;

            this.FormClosing += LoginForm_FormClosing;
        }

        private void LoginForm_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = pictureBox1;
        }

        private void SendClientVersion()
        {
            Program.Logger.Enqueue(LogType.System, "버전체크", "버전 체크 시작");

            C.ClientVersion p = new C.ClientVersion();
            try
            {
                byte[] sum;
                using (MD5 md5 = MD5.Create())
                using (FileStream stream = File.OpenRead(Application.ExecutablePath))
                    sum = md5.ComputeHash(stream);

                p.VersionHash = sum;
                Program.Logger.Enqueue(LogType.Information, "클라이언트 버전", string.Join(" ", p.VersionHash));

                Program.Logger.Enqueue(LogType.System, "버전체크", "버전 전송");
                Network.Enqueue(p);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Program.Logger.Enqueue(LogType.Error, "버전 체크 오류 발생", ex.Message);
            }
        }


        #region Control Events
        private void InterfaceTimer_Tick(object sender, EventArgs e)
        {
            if (Network.Connected)
            {
                _stopwatch.Reset();
                _stopwatch.Stop();
                _stopwatch = null;

                SendClientVersion();
                InterfaceTimer.Stop();
            }
            else
            {
                if (_stopwatch.Elapsed.Seconds > 10)
                {
                    Program.Logger.Enqueue(LogType.Error, "버전 체크 오류 발생", "서버 연결에 실패했습니다.");
                    MessageBox.Show("클라이언트 버전 체크 실패", "시스템");
                    InterfaceTimer.Stop();
                }
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            SubscribeToDragEventsForPanels(this);
        }

        private void wButton_EXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnsubscribeFromDragEventsForPanels(this);
        }
        #endregion

        private void wLinkLabel_Register_Click(object sender, EventArgs e)
        {
            Program.Logger.Enqueue(LogType.System, "회원가입", "회원가입 가능 여부 검사 시작");
            Network.Enqueue(new C.SignUpCheck());
        }
    }
}

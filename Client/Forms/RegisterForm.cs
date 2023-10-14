using Client.Features.Logger;
using Client.Networks;
using ClientPackets;
using Newtonsoft.Json;
using Shared.Helpers;
using System;
using System.Windows.Forms;
using WithusUI.Forms;
using C = ClientPackets;

namespace Client.Forms
{
    public partial class RegisterForm : WithusForm
    {
        private bool _isEmailValid = false;
        private bool _isPhoneValid = false;

        public RegisterForm()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
        }

        #region Functions

        #endregion

        #region Control Events

        private void RegisterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.Logger.Enqueue(LogType.System, "회원가입", "회원가입 폼이 종료 됨");
            Program.RegisterForm = null;
        }

        private void wButton_Close_Click(object sender, EventArgs e)
        {
            Program.LoginForm.BeginInvoke(new Action(() =>
            {
                Program.LoginForm.Opacity = 1;
            }));
            this.Close();
        }

        private void wTextBox_InputEmail_TextChangedEvent(object sender, EventArgs e)
        {
            if (EmailValidator.IsValidEmail(wTextBox_InputEmail.Texts))
            {
                _isEmailValid = true;
            }
            else
            {
                _isEmailValid = false;
            }
        }

        private void wButton_Submit_Click(object sender, EventArgs e)
        {
            Program.Logger.Enqueue(LogType.System, "회원가입 요청", "회원가입 요청 시작");

            if (!_isEmailValid)
            {
                Program.Logger.Enqueue(LogType.System, "유효성 검사 실패", "이메일 형식 오류");
                MessageBox.Show("유효한 이메일 주소를 입력해 주세요.", "시스템");
                return;
            }

            if (wTextBox_InputPassword.Texts != wTextBox_ConfirmPassword.Texts)
            {
                Program.Logger.Enqueue(LogType.System, "유효성 검사 실패", "비밀번호 재확인 실패");
                MessageBox.Show("비밀번호 및 재확인을 진행해 주세요.", "시스템");
                return;
            }

            if (wTextBox_InputUserName.Texts.Length < 2)
            {
                Program.Logger.Enqueue(LogType.System, "유효성 검사 실패", "고객명 형식 오류");
                MessageBox.Show("두 글자 이상의 성함을 입력해 주세요.", "시스템");
                return;
            }

            if (!_isPhoneValid)
            {
                Program.Logger.Enqueue(LogType.System, "유효성 검사 실패", "핸드폰 번호 형식 오류");
                MessageBox.Show("유효한 핸드폰 번호를 입력해 주세요.", "시스템");
                return;
            }

            this.Enabled = false;

            SignUp signUpPacketStruct = new SignUp
            {
                UserEmail = wTextBox_InputEmail.Texts,
                HashedPassword = PasswordHasher.HashPassword(wTextBox_InputPassword.Texts),
                UserName = wTextBox_InputUserName.Texts,
                UserPhone = wTextBox_InputUserPhone.Texts
            };

            Program.Logger.Enqueue(LogType.Information, "회원가입 요청",
                                   JsonConvert.SerializeObject(signUpPacketStruct, Formatting.Indented));

            Network.Enqueue(signUpPacketStruct);
        }

        private void wTextBox_InputUserPhone_TextChangedEvent(object sender, EventArgs e)
        {
            if (wTextBox_InputUserPhone.Texts.Length == 11)
            {

                if (Int32.TryParse(wTextBox_InputUserPhone.Texts.Substring(0, 3), out int identifyingNumber))
                {
                    if (identifyingNumber == 010)
                    {
                        if (Int32.TryParse(wTextBox_InputUserPhone.Texts, out int convertedNumber))
                        {
                            _isPhoneValid = true;
                            return;
                        }
                    }
                }
            }

            _isPhoneValid = false;
        }

        private void wTextBox_InputUserPhone_KeyDownEvent(object sender, KeyEventArgs e)
        {
            bool isDigitKey = (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) ||
                              (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9);
            bool isBackspaceOrDelete = e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete;
            bool isUtilKeys = e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Home || e.KeyCode == Keys.End;


            int currentLength = wTextBox_InputUserPhone.Texts.Length;
            int limitLength = 11;

            if (!isDigitKey && !isBackspaceOrDelete && !isUtilKeys)
            {
                e.SuppressKeyPress = true;
                return;
            }

            if (currentLength >= limitLength)
            {
                if (isDigitKey)
                {
                    e.SuppressKeyPress = true;
                    return;
                }
            }
        }
        #endregion
    }
}

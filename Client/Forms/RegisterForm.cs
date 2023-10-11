using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WithusUI.Forms;

namespace Client.Forms
{
    public partial class RegisterForm : WithusForm
    {
        public RegisterForm()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
        }

        private void RegisterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
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
    }
}

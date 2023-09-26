using System;
using System.Windows.Forms;

namespace Client.Forms
{
    public partial class LoginForm : Form
    {
        public bool UpdateShowInTaskbar
        {
            get => this.ShowInTaskbar;
            set => this.BeginInvoke(new Action(() =>
            {
                this.ShowInTaskbar = value;
            }));
        }

        public double UpdateOpacity
        {
            get => this.Opacity;
            set => this.BeginInvoke(new Action(() =>
            {
                this.Opacity = value;
            }));
        }

        public bool UpdateEnable
        {
            get => this.Enabled;
            set => this.BeginInvoke(new Action(() =>
            {
                this.Enabled = value;
            }));
        }
        public LoginForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}

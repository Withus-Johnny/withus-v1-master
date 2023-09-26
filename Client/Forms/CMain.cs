using Client.Features.Logger;
using System;
using System.Windows.Forms;

namespace Client.Forms
{
    public partial class CMain : Form
    {
        private ILogger _logger;

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

        public CMain()
        {
            InitializeComponent();
            _logger = Program.Logger;

            this.ShowInTaskbar = false;
            this.Opacity = 0;
            this.Enabled = false;
        }

        private void CMain_Load(object sender, EventArgs e)
        {

        }
    }
}
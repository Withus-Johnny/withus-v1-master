using Client.Features.Logger;
using System;
using System.Windows.Forms;

namespace Client.Forms
{
    public partial class CMain : Form
    {
        private readonly ILogger _logger;

        public CMain()
        {
            InitializeComponent();
            _logger = Program.Logger;
        }

        private void CMain_Load(object sender, EventArgs e)
        {

        }
    }
}
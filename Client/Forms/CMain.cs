using Client.Features.Logger;
using Newtonsoft.Json;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace Client.Forms
{
    public partial class CMain : Form
    {
        private ILogger _logger;

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
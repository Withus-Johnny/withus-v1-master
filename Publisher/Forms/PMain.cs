using System;
using System.Windows.Forms;

namespace Publisher.Forms
{
    public partial class PMain : Form
    {
        public PMain()
        {
            InitializeComponent();
            this.Text = $"{Application.ProductName} {Application.ProductVersion}";
        }

        private void PMain_Load(object sender, EventArgs e)
        {
            Validator.IsValid(Settings.TargetPath);
        }

        private void menuItem_Config_Click(object sender, EventArgs e)
        {
            SettingForm settingForm = new SettingForm();
            settingForm.FormClosed += (o1, e1) => {
                settingForm = null;
            };
            settingForm.ShowDialog();
        }

        private void menuItem_Close_Click(object sender, EventArgs e)
        {
            // TODO: FREE
            Application.Exit();
        }
    }
}

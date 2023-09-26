using System.Windows.Forms;
using WithusUI.Forms;

namespace Client.Forms
{
    public partial class LoginForm : WithusForm
    {
        public LoginForm()
        {
            InitializeComponent();

            this.Text = "위더스 - 로그인";
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}

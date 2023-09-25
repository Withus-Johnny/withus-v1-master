using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace Publisher.Forms
{
	public partial class SettingForm : Form
	{
		private bool _IsLoaded = false;

		public SettingForm()
		{
			MessageQueue.Instance.Enqueue("설정 초기화 시작");
			InitializeComponent();
			this.FormClosing += (o1, e1) =>
			{
				MessageQueue.Instance.Enqueue("설정 종료");
			};
		}

		private void SettingForm_Load(object sender, EventArgs e)
		{
			textBox_TargetPath.Text = Settings.TargetPath;

			textBox_Host.Text = Settings.Host;
			textBox_UserName.Text = Settings.UserName;
			textBox_Password.Text = Settings.UserPassword;

			PopulateTreeView(Settings.TargetPath, treeView1.Nodes);
			_IsLoaded = true;
		}

		private void PopulateTreeView(string dirPath, TreeNodeCollection parentNodes)
		{
			if (!Directory.Exists(dirPath))
			{
				return;
			}

			var rootDirectory = new DirectoryInfo(dirPath);

			var rootNode = new TreeNode(rootDirectory.Name);

			parentNodes.Add(rootNode);

			try
			{
				foreach (var file in rootDirectory.GetFiles())
				{
					rootNode.Nodes.Add(new TreeNode(file.Name));
				}

				foreach (var subDir in rootDirectory.GetDirectories())
				{
					PopulateTreeView(subDir.FullName, rootNode.Nodes);
				}
				treeView1.ExpandAll();
			}
			catch
			{
				treeView1.Nodes.Clear();
				this.Close();
			};
		}

		private void textBox_TargetPath_TextChanged(object sender, EventArgs e)
		{
			if (!_IsLoaded) return;

			if (textBox_TargetPath.Text.ToUpper() == @"C:\")
			{
				textBox_TargetPath.Text = @"C:\Debug\Client\";
            }

			treeView1.Nodes.Clear();
			PopulateTreeView(textBox_TargetPath.Text, treeView1.Nodes);
		}

		private void button_Save_Click(object sender, EventArgs e)
		{
			if (Validator.IsValid(textBox_TargetPath.Text))
			{
				Settings.TargetPath = textBox_TargetPath.Text;

				Settings.Host = textBox_Host.Text;
				Settings.UserName = textBox_UserName.Text;
				Settings.UserPassword = textBox_Password.Text;

				MessageQueue.Instance.Enqueue("설정 저장");
				Settings.Save();
				this.Close();
			}
			else
			{
				MessageBox.Show("유효성 검사에 실패하여 저장 할 수 없습니다.", "시스템");
			}
		}

		private void button_Close_Click(object sender, EventArgs e)
		{
			this.Close();
		}

        private void textBox_TargetPath_Leave(object sender, EventArgs e)
        {
            if (!textBox_TargetPath.Text.EndsWith("\\"))
			{
                textBox_TargetPath.Text += "\\";
            }
        }

        private void textBox_Host_Leave(object sender, EventArgs e)
        {			
			if (!textBox_Host.Text.ToUpper().Contains(@"FTP:\\"))
			{
				if (IPAddress.TryParse(textBox_Host.Text, out IPAddress convertedHost))
				{
					textBox_Host.Text = $@"ftp://{textBox_Host.Text}/";
                }
			}
        }
    }
}

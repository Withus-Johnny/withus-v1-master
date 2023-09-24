using Publisher.Controllers;
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
			settingForm.FormClosed += (o1, e1) =>
			{
				settingForm = null;
			};
			settingForm.ShowDialog();
		}

		private void menuItem_Close_Click(object sender, EventArgs e)
		{
			// TODO: FREE
			Application.Exit();
		}

		private void menuItem_Publishing_Click(object sender, EventArgs e)
		{
			FTPController.Instance.Initialize();
		}

		private void InterfaceTimer_Tick(object sender, EventArgs e)
		{
			if (MessageQueue.Instance.IsDataEmpty()) return;

			if (!MessageQueue.Instance.Dequeue(out string message)) return;

			richTextBox1.AppendText(message);
		}

		public void UpdateProgressBar1(int value)
		{
			this.Invoke(new Action(() =>
			{
				progressBar1.Value = value;
			}));
		}

		public void UpdateProgressBar2(int value)
		{
			this.Invoke(new Action(() =>
			{
				progressBar2.Value = value;
			}));
		}

		public string FileNameLabelText
		{
			get
			{
				return label_FileName.Text;
			}
			set
			{
				this?.Invoke(new Action(() =>
				{
					label_FileName.Text = value;
				}));
			}
		}

		public string SpeedLabelText
		{
			get { return statusLabel_Speed.Text; }
			set
			{
				if (this.InvokeRequired)
				{
					this.Invoke(new Action(() => statusLabel_Speed.Text = value));
				}
				else
				{
					statusLabel_Speed.Text = value;
				}
			}
		}

		public string RemainingCount
		{
			get
			{
				return statusLabel_RemainingCount.Text;
			}
			set
			{
				this?.Invoke(new Action(() =>
				{
					statusLabel_RemainingCount.Text = value;
				}));
			}
		}
	}
}

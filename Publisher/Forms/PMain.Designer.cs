namespace Publisher.Forms
{
    partial class PMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.프로그램ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItem_Config = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItem_Close = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.panel_Container = new System.Windows.Forms.Panel();
			this.menuItem_Publishing = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.progressBar2 = new System.Windows.Forms.ProgressBar();
			this.label1 = new System.Windows.Forms.Label();
			this.label_FileName = new System.Windows.Forms.Label();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.statusLabel_All = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
			this.statusLabel_RemainingCount = new System.Windows.Forms.ToolStripStatusLabel();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.InterfaceTimer = new System.Windows.Forms.Timer(this.components);
			this.statusLabel_Speed = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.panel_Container.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.프로그램ToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(657, 35);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// 프로그램ToolStripMenuItem
			// 
			this.프로그램ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Config,
            this.toolStripMenuItem1,
            this.menuItem_Publishing,
            this.toolStripMenuItem2,
            this.menuItem_Close});
			this.프로그램ToolStripMenuItem.Name = "프로그램ToolStripMenuItem";
			this.프로그램ToolStripMenuItem.Size = new System.Drawing.Size(100, 29);
			this.프로그램ToolStripMenuItem.Text = "프로그램";
			// 
			// menuItem_Config
			// 
			this.menuItem_Config.Name = "menuItem_Config";
			this.menuItem_Config.Size = new System.Drawing.Size(270, 34);
			this.menuItem_Config.Text = "설정";
			this.menuItem_Config.Click += new System.EventHandler(this.menuItem_Config_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(267, 6);
			// 
			// menuItem_Close
			// 
			this.menuItem_Close.Name = "menuItem_Close";
			this.menuItem_Close.Size = new System.Drawing.Size(270, 34);
			this.menuItem_Close.Text = "프로그램 종료";
			this.menuItem_Close.Click += new System.EventHandler(this.menuItem_Close_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.statusLabel_All,
            this.toolStripStatusLabel4,
            this.statusLabel_RemainingCount,
            this.toolStripStatusLabel1,
            this.statusLabel_Speed});
			this.statusStrip1.Location = new System.Drawing.Point(0, 420);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 20, 0);
			this.statusStrip1.Size = new System.Drawing.Size(657, 32);
			this.statusStrip1.SizingGrip = false;
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// panel_Container
			// 
			this.panel_Container.Controls.Add(this.richTextBox1);
			this.panel_Container.Controls.Add(this.label_FileName);
			this.panel_Container.Controls.Add(this.label1);
			this.panel_Container.Controls.Add(this.progressBar2);
			this.panel_Container.Controls.Add(this.progressBar1);
			this.panel_Container.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel_Container.Location = new System.Drawing.Point(0, 35);
			this.panel_Container.Name = "panel_Container";
			this.panel_Container.Size = new System.Drawing.Size(657, 385);
			this.panel_Container.TabIndex = 2;
			// 
			// menuItem_Publishing
			// 
			this.menuItem_Publishing.Enabled = false;
			this.menuItem_Publishing.Name = "menuItem_Publishing";
			this.menuItem_Publishing.Size = new System.Drawing.Size(270, 34);
			this.menuItem_Publishing.Text = "배포 시작";
			this.menuItem_Publishing.Click += new System.EventHandler(this.menuItem_Publishing_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(267, 6);
			// 
			// progressBar1
			// 
			this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar1.Location = new System.Drawing.Point(24, 55);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(606, 40);
			this.progressBar1.TabIndex = 0;
			// 
			// progressBar2
			// 
			this.progressBar2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar2.Location = new System.Drawing.Point(24, 116);
			this.progressBar2.Name = "progressBar2";
			this.progressBar2.Size = new System.Drawing.Size(606, 40);
			this.progressBar2.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(21, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 18);
			this.label1.TabIndex = 2;
			this.label1.Text = "파일명:";
			// 
			// label_FileName
			// 
			this.label_FileName.AutoSize = true;
			this.label_FileName.Location = new System.Drawing.Point(95, 22);
			this.label_FileName.Name = "label_FileName";
			this.label_FileName.Size = new System.Drawing.Size(17, 18);
			this.label_FileName.TabIndex = 3;
			this.label_FileName.Text = "-";
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(293, 25);
			this.toolStripStatusLabel2.Spring = true;
			// 
			// statusLabel_All
			// 
			this.statusLabel_All.Name = "statusLabel_All";
			this.statusLabel_All.Size = new System.Drawing.Size(19, 25);
			this.statusLabel_All.Text = "-";
			// 
			// toolStripStatusLabel3
			// 
			this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
			this.toolStripStatusLabel3.Size = new System.Drawing.Size(94, 25);
			this.toolStripStatusLabel3.Text = "전체 파일:";
			// 
			// statusLabel_RemainingCount
			// 
			this.statusLabel_RemainingCount.Name = "statusLabel_RemainingCount";
			this.statusLabel_RemainingCount.Size = new System.Drawing.Size(19, 25);
			this.statusLabel_RemainingCount.Text = "-";
			// 
			// richTextBox1
			// 
			this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBox1.Location = new System.Drawing.Point(24, 177);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ReadOnly = true;
			this.richTextBox1.Size = new System.Drawing.Size(606, 192);
			this.richTextBox1.TabIndex = 4;
			this.richTextBox1.Text = "";
			// 
			// InterfaceTimer
			// 
			this.InterfaceTimer.Enabled = true;
			this.InterfaceTimer.Interval = 50;
			this.InterfaceTimer.Tick += new System.EventHandler(this.InterfaceTimer_Tick);
			// 
			// statusLabel_Speed
			// 
			this.statusLabel_Speed.Name = "statusLabel_Speed";
			this.statusLabel_Speed.Size = new System.Drawing.Size(19, 25);
			this.statusLabel_Speed.Text = "-";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(52, 25);
			this.toolStripStatusLabel1.Text = "속도:";
			// 
			// toolStripStatusLabel4
			// 
			this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
			this.toolStripStatusLabel4.Size = new System.Drawing.Size(94, 25);
			this.toolStripStatusLabel4.Text = "남은 파일:";
			// 
			// PMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(657, 452);
			this.ControlBox = false;
			this.Controls.Add(this.panel_Container);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "PMain";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "PMain";
			this.Load += new System.EventHandler(this.PMain_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.panel_Container.ResumeLayout(false);
			this.panel_Container.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 프로그램ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItem_Config;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuItem_Close;
        private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.Panel panel_Container;
		private System.Windows.Forms.Label label_FileName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ProgressBar progressBar2;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.Timer InterfaceTimer;
		public System.Windows.Forms.ToolStripStatusLabel statusLabel_RemainingCount;
		public System.Windows.Forms.ToolStripStatusLabel statusLabel_All;
		public System.Windows.Forms.ToolStripMenuItem menuItem_Publishing;
		private System.Windows.Forms.ToolStripStatusLabel statusLabel_Speed;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
	}
}
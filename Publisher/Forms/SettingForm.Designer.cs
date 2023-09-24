namespace Publisher.Forms
{
    partial class SettingForm
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
			this.panel_Container = new System.Windows.Forms.Panel();
			this.panel_PathTreeContainer = new System.Windows.Forms.Panel();
			this.panel_PathTree = new System.Windows.Forms.Panel();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.panel_PathInfo = new System.Windows.Forms.Panel();
			this.textBox_TargetPath = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.button_Close = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.button_Save = new System.Windows.Forms.Button();
			this.textBox_Host = new System.Windows.Forms.TextBox();
			this.textBox_Password = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox_UserName = new System.Windows.Forms.TextBox();
			this.panel_Container.SuspendLayout();
			this.panel_PathTreeContainer.SuspendLayout();
			this.panel_PathTree.SuspendLayout();
			this.panel_PathInfo.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel_Container
			// 
			this.panel_Container.Controls.Add(this.panel_PathTreeContainer);
			this.panel_Container.Controls.Add(this.panel1);
			this.panel_Container.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel_Container.Location = new System.Drawing.Point(0, 0);
			this.panel_Container.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.panel_Container.Name = "panel_Container";
			this.panel_Container.Size = new System.Drawing.Size(801, 382);
			this.panel_Container.TabIndex = 0;
			// 
			// panel_PathTreeContainer
			// 
			this.panel_PathTreeContainer.Controls.Add(this.panel_PathTree);
			this.panel_PathTreeContainer.Controls.Add(this.panel_PathInfo);
			this.panel_PathTreeContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel_PathTreeContainer.Location = new System.Drawing.Point(0, 0);
			this.panel_PathTreeContainer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.panel_PathTreeContainer.Name = "panel_PathTreeContainer";
			this.panel_PathTreeContainer.Size = new System.Drawing.Size(424, 382);
			this.panel_PathTreeContainer.TabIndex = 6;
			// 
			// panel_PathTree
			// 
			this.panel_PathTree.Controls.Add(this.treeView1);
			this.panel_PathTree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel_PathTree.Location = new System.Drawing.Point(0, 81);
			this.panel_PathTree.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.panel_PathTree.Name = "panel_PathTree";
			this.panel_PathTree.Size = new System.Drawing.Size(424, 301);
			this.panel_PathTree.TabIndex = 3;
			// 
			// treeView1
			// 
			this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.treeView1.Location = new System.Drawing.Point(6, 8);
			this.treeView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(412, 285);
			this.treeView1.TabIndex = 0;
			// 
			// panel_PathInfo
			// 
			this.panel_PathInfo.Controls.Add(this.textBox_TargetPath);
			this.panel_PathInfo.Controls.Add(this.label4);
			this.panel_PathInfo.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel_PathInfo.Location = new System.Drawing.Point(0, 0);
			this.panel_PathInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.panel_PathInfo.Name = "panel_PathInfo";
			this.panel_PathInfo.Size = new System.Drawing.Size(424, 81);
			this.panel_PathInfo.TabIndex = 2;
			// 
			// textBox_TargetPath
			// 
			this.textBox_TargetPath.Location = new System.Drawing.Point(17, 36);
			this.textBox_TargetPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.textBox_TargetPath.Name = "textBox_TargetPath";
			this.textBox_TargetPath.Size = new System.Drawing.Size(387, 28);
			this.textBox_TargetPath.TabIndex = 1;
			this.textBox_TargetPath.TextChanged += new System.EventHandler(this.textBox_TargetPath_TextChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(17, 14);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(59, 18);
			this.label4.TabIndex = 0;
			this.label4.Text = "- 대상";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.button_Close);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.button_Save);
			this.panel1.Controls.Add(this.textBox_Host);
			this.panel1.Controls.Add(this.textBox_Password);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.textBox_UserName);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel1.Location = new System.Drawing.Point(424, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(377, 382);
			this.panel1.TabIndex = 5;
			// 
			// button_Close
			// 
			this.button_Close.Location = new System.Drawing.Point(23, 320);
			this.button_Close.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.button_Close.Name = "button_Close";
			this.button_Close.Size = new System.Drawing.Size(333, 42);
			this.button_Close.TabIndex = 4;
			this.button_Close.Text = "닫기";
			this.button_Close.UseVisualStyleBackColor = true;
			this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(27, 42);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "- 호스트";
			// 
			// button_Save
			// 
			this.button_Save.Location = new System.Drawing.Point(23, 268);
			this.button_Save.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.button_Save.Name = "button_Save";
			this.button_Save.Size = new System.Drawing.Size(333, 42);
			this.button_Save.TabIndex = 3;
			this.button_Save.Text = "저장";
			this.button_Save.UseVisualStyleBackColor = true;
			this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
			// 
			// textBox_Host
			// 
			this.textBox_Host.Location = new System.Drawing.Point(23, 64);
			this.textBox_Host.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.textBox_Host.MaxLength = 15;
			this.textBox_Host.Name = "textBox_Host";
			this.textBox_Host.Size = new System.Drawing.Size(331, 28);
			this.textBox_Host.TabIndex = 0;
			this.textBox_Host.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBox_Password
			// 
			this.textBox_Password.Location = new System.Drawing.Point(23, 201);
			this.textBox_Password.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.textBox_Password.MaxLength = 255;
			this.textBox_Password.Name = "textBox_Password";
			this.textBox_Password.PasswordChar = '*';
			this.textBox_Password.Size = new System.Drawing.Size(331, 28);
			this.textBox_Password.TabIndex = 2;
			this.textBox_Password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(26, 108);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(95, 18);
			this.label2.TabIndex = 0;
			this.label2.Text = "- 사용자명";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(26, 178);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(95, 18);
			this.label3.TabIndex = 0;
			this.label3.Text = "- 비밀번호";
			// 
			// textBox_UserName
			// 
			this.textBox_UserName.Location = new System.Drawing.Point(23, 130);
			this.textBox_UserName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.textBox_UserName.MaxLength = 30;
			this.textBox_UserName.Name = "textBox_UserName";
			this.textBox_UserName.Size = new System.Drawing.Size(331, 28);
			this.textBox_UserName.TabIndex = 1;
			this.textBox_UserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// SettingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(801, 382);
			this.ControlBox = false;
			this.Controls.Add(this.panel_Container);
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "SettingForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "설정";
			this.Load += new System.EventHandler(this.SettingForm_Load);
			this.panel_Container.ResumeLayout(false);
			this.panel_PathTreeContainer.ResumeLayout(false);
			this.panel_PathTree.ResumeLayout(false);
			this.panel_PathInfo.ResumeLayout(false);
			this.panel_PathInfo.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Container;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Host;
        private System.Windows.Forms.TextBox textBox_UserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Panel panel_PathTreeContainer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_TargetPath;
        private System.Windows.Forms.Panel panel_PathInfo;
        private System.Windows.Forms.Panel panel_PathTree;
        private System.Windows.Forms.TreeView treeView1;
    }
}
﻿namespace Client.Forms
{
    partial class LoginForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
			this.panel_Container = new System.Windows.Forms.Panel();
			this.wTextBox1 = new WithusUI.Controls.TextBoxs.WTextBox();
			this.wTextBox2 = new WithusUI.Controls.TextBoxs.WTextBox();
			this.wButton_EXIT = new WithusUI.Controls.Buttons.WButton();
			this.wButton_Login = new WithusUI.Controls.Buttons.WButton();
			this.InterfaceTimer = new System.Windows.Forms.Timer(this.components);
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.panel_Caption = new System.Windows.Forms.Panel();
			this.panel_Container.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// panel_Container
			// 
			this.panel_Container.Controls.Add(this.pictureBox1);
			this.panel_Container.Controls.Add(this.wTextBox1);
			this.panel_Container.Controls.Add(this.wTextBox2);
			this.panel_Container.Controls.Add(this.wButton_EXIT);
			this.panel_Container.Controls.Add(this.wButton_Login);
			this.panel_Container.Controls.Add(this.panel_Caption);
			this.panel_Container.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel_Container.Location = new System.Drawing.Point(7, 8);
			this.panel_Container.Margin = new System.Windows.Forms.Padding(4);
			this.panel_Container.Name = "panel_Container";
			this.panel_Container.Size = new System.Drawing.Size(482, 901);
			this.panel_Container.TabIndex = 0;
			// 
			// wTextBox1
			// 
			this.wTextBox1.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.wTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(35)))), ((int)(((byte)(44)))));
			this.wTextBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(90)))), ((int)(((byte)(117)))));
			this.wTextBox1.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
			this.wTextBox1.BorderRadius = 6;
			this.wTextBox1.BorderSize = 1;
			this.wTextBox1.Font = new System.Drawing.Font("굴림", 11F);
			this.wTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(139)))));
			this.wTextBox1.Location = new System.Drawing.Point(17, 370);
			this.wTextBox1.Multiline = false;
			this.wTextBox1.Name = "wTextBox1";
			this.wTextBox1.Padding = new System.Windows.Forms.Padding(14, 7, 10, 7);
			this.wTextBox1.PasswordChar = false;
			this.wTextBox1.PlaceholderText = "이메일 주소";
			this.wTextBox1.Size = new System.Drawing.Size(444, 40);
			this.wTextBox1.TabIndex = 2;
			this.wTextBox1.Texts = "";
			this.wTextBox1.UnderlinedStyle = false;
			// 
			// wTextBox2
			// 
			this.wTextBox2.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.wTextBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(35)))), ((int)(((byte)(44)))));
			this.wTextBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(90)))), ((int)(((byte)(117)))));
			this.wTextBox2.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
			this.wTextBox2.BorderRadius = 6;
			this.wTextBox2.BorderSize = 1;
			this.wTextBox2.Font = new System.Drawing.Font("굴림", 11F);
			this.wTextBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(139)))));
			this.wTextBox2.Location = new System.Drawing.Point(17, 439);
			this.wTextBox2.Multiline = false;
			this.wTextBox2.Name = "wTextBox2";
			this.wTextBox2.Padding = new System.Windows.Forms.Padding(14, 7, 10, 7);
			this.wTextBox2.PasswordChar = true;
			this.wTextBox2.PlaceholderText = "비밀번호";
			this.wTextBox2.Size = new System.Drawing.Size(444, 40);
			this.wTextBox2.TabIndex = 3;
			this.wTextBox2.Texts = "";
			this.wTextBox2.UnderlinedStyle = false;
			// 
			// wButton_EXIT
			// 
			this.wButton_EXIT.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(46)))), ((int)(((byte)(51)))));
			this.wButton_EXIT.ActiveBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(118)))), ((int)(((byte)(129)))));
			this.wButton_EXIT.ActiveForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
			this.wButton_EXIT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
			this.wButton_EXIT.BorderRadius = 5;
			this.wButton_EXIT.BorderSize = 0;
			this.wButton_EXIT.Cursor = System.Windows.Forms.Cursors.Hand;
			this.wButton_EXIT.DefaultBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
			this.wButton_EXIT.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(59)))), ((int)(((byte)(66)))));
			this.wButton_EXIT.DefaultFontForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
			this.wButton_EXIT.FlatAppearance.BorderSize = 0;
			this.wButton_EXIT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.wButton_EXIT.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
			this.wButton_EXIT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
			this.wButton_EXIT.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(54)))), ((int)(((byte)(61)))));
			this.wButton_EXIT.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(158)))));
			this.wButton_EXIT.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
			this.wButton_EXIT.Location = new System.Drawing.Point(17, 824);
			this.wButton_EXIT.Margin = new System.Windows.Forms.Padding(4);
			this.wButton_EXIT.Name = "wButton_EXIT";
			this.wButton_EXIT.Size = new System.Drawing.Size(444, 48);
			this.wButton_EXIT.TabIndex = 5;
			this.wButton_EXIT.TabStop = false;
			this.wButton_EXIT.Text = "프로그램 종료";
			this.wButton_EXIT.UseVisualStyleBackColor = false;
			this.wButton_EXIT.Click += new System.EventHandler(this.wButton_EXIT_Click);
			// 
			// wButton_Login
			// 
			this.wButton_Login.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(93)))), ((int)(((byte)(137)))));
			this.wButton_Login.ActiveBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(93)))), ((int)(((byte)(137)))));
			this.wButton_Login.ActiveForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
			this.wButton_Login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(95)))), ((int)(((byte)(139)))));
			this.wButton_Login.BorderRadius = 6;
			this.wButton_Login.BorderSize = 2;
			this.wButton_Login.Cursor = System.Windows.Forms.Cursors.Hand;
			this.wButton_Login.DefaultBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(95)))), ((int)(((byte)(139)))));
			this.wButton_Login.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(95)))), ((int)(((byte)(139)))));
			this.wButton_Login.DefaultFontForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
			this.wButton_Login.FlatAppearance.BorderSize = 0;
			this.wButton_Login.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(46)))), ((int)(((byte)(51)))));
			this.wButton_Login.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(54)))), ((int)(((byte)(61)))));
			this.wButton_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.wButton_Login.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
			this.wButton_Login.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
			this.wButton_Login.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(120)))), ((int)(((byte)(190)))));
			this.wButton_Login.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(120)))), ((int)(((byte)(190)))));
			this.wButton_Login.HoverForeColor = System.Drawing.Color.White;
			this.wButton_Login.Location = new System.Drawing.Point(17, 561);
			this.wButton_Login.Margin = new System.Windows.Forms.Padding(4);
			this.wButton_Login.Name = "wButton_Login";
			this.wButton_Login.Size = new System.Drawing.Size(444, 53);
			this.wButton_Login.TabIndex = 4;
			this.wButton_Login.Text = "로그인";
			this.wButton_Login.UseVisualStyleBackColor = false;
			// 
			// InterfaceTimer
			// 
			this.InterfaceTimer.Enabled = true;
			this.InterfaceTimer.Interval = 1;
			this.InterfaceTimer.Tick += new System.EventHandler(this.InterfaceTimer_Tick);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(0, 47);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(482, 256);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 3;
			this.pictureBox1.TabStop = false;
			// 
			// panel_Caption
			// 
			this.panel_Caption.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel_Caption.Location = new System.Drawing.Point(0, 0);
			this.panel_Caption.Name = "panel_Caption";
			this.panel_Caption.Size = new System.Drawing.Size(482, 47);
			this.panel_Caption.TabIndex = 1;
			// 
			// LoginForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(496, 917);
			this.Controls.Add(this.panel_Container);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "LoginForm";
			this.Padding = new System.Windows.Forms.Padding(7, 8, 7, 8);
			this.Text = "LoginForm";
			this.panel_Container.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Container;
        private System.Windows.Forms.Timer InterfaceTimer;
        private WithusUI.Controls.Buttons.WButton wButton_Login;
        private WithusUI.Controls.Buttons.WButton wButton_EXIT;
		private WithusUI.Controls.TextBoxs.WTextBox wTextBox2;
		private WithusUI.Controls.TextBoxs.WTextBox wTextBox1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Panel panel_Caption;
	}
}
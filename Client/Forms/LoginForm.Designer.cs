namespace Client.Forms
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
            this.panel_Container = new System.Windows.Forms.Panel();
            this.wButton_EXIT = new WithusUI.Controls.Buttons.WButton();
            this.wButton_Login = new WithusUI.Controls.Buttons.WButton();
            this.InterfaceTimer = new System.Windows.Forms.Timer(this.components);
            this.panel_Container.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Container
            // 
            this.panel_Container.Controls.Add(this.wButton_EXIT);
            this.panel_Container.Controls.Add(this.wButton_Login);
            this.panel_Container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Container.Location = new System.Drawing.Point(5, 5);
            this.panel_Container.Name = "panel_Container";
            this.panel_Container.Size = new System.Drawing.Size(790, 440);
            this.panel_Container.TabIndex = 0;
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
            this.wButton_EXIT.Location = new System.Drawing.Point(610, 389);
            this.wButton_EXIT.Name = "wButton_EXIT";
            this.wButton_EXIT.Size = new System.Drawing.Size(161, 32);
            this.wButton_EXIT.TabIndex = 1;
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
            this.wButton_Login.Location = new System.Drawing.Point(268, 299);
            this.wButton_Login.Name = "wButton_Login";
            this.wButton_Login.Size = new System.Drawing.Size(250, 40);
            this.wButton_Login.TabIndex = 0;
            this.wButton_Login.Text = "로그인";
            this.wButton_Login.UseVisualStyleBackColor = false;
            // 
            // InterfaceTimer
            // 
            this.InterfaceTimer.Enabled = true;
            this.InterfaceTimer.Interval = 1;
            this.InterfaceTimer.Tick += new System.EventHandler(this.InterfaceTimer_Tick);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel_Container);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.Text = "LoginForm";
            this.panel_Container.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Container;
        private System.Windows.Forms.Timer InterfaceTimer;
        private WithusUI.Controls.Buttons.WButton wButton_Login;
        private WithusUI.Controls.Buttons.WButton wButton_EXIT;
    }
}
namespace Client.Forms
{
    partial class RegisterForm
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
            this.wButton1 = new WithusUI.Controls.Buttons.WButton();
            this.SuspendLayout();
            // 
            // wButton1
            // 
            this.wButton1.ActiveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(46)))), ((int)(((byte)(51)))));
            this.wButton1.ActiveBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(118)))), ((int)(((byte)(129)))));
            this.wButton1.ActiveForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.wButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.wButton1.BorderRadius = 20;
            this.wButton1.BorderSize = 2;
            this.wButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.wButton1.DefaultBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.wButton1.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(59)))), ((int)(((byte)(66)))));
            this.wButton1.DefaultFontForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.wButton1.FlatAppearance.BorderSize = 0;
            this.wButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wButton1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            this.wButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.wButton1.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(54)))), ((int)(((byte)(61)))));
            this.wButton1.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(148)))), ((int)(((byte)(158)))));
            this.wButton1.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(209)))), ((int)(((byte)(217)))));
            this.wButton1.IsShowFocusCues = false;
            this.wButton1.Location = new System.Drawing.Point(628, 392);
            this.wButton1.Name = "wButton1";
            this.wButton1.Size = new System.Drawing.Size(150, 40);
            this.wButton1.TabIndex = 0;
            this.wButton1.Text = "wButton1";
            this.wButton1.UseVisualStyleBackColor = false;
            this.wButton1.Click += new System.EventHandler(this.wButton1_Click);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.wButton1);
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RegisterForm_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private WithusUI.Controls.Buttons.WButton wButton1;
    }
}
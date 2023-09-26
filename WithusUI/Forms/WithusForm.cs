using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using WithusUI.Configs;

namespace WithusUI.Forms
{
    public partial class WithusForm : Form
    {
        #region 보더 스트럭쳐
        public new Rectangle Top()
        {
            return new Rectangle(0, 0, this.ClientSize.Width, _borderSize);
        }

        public new Rectangle Left()
        {
            return new Rectangle(0, 0, _borderSize, this.ClientSize.Height);
        }

        public new Rectangle Bottom()
        {
            return new Rectangle(0, this.ClientSize.Height - _borderSize, this.ClientSize.Width, _borderSize);
        }

        public new Rectangle Right()
        {
            return new Rectangle(this.ClientSize.Width - _borderSize, 0, _borderSize, this.ClientSize.Height);
        }

        public Rectangle TopLeft()
        {
            return new Rectangle(0, 0, _borderSize, _borderSize);
        }

        public Rectangle TopRight()
        {
            return new Rectangle(this.ClientSize.Width - _borderSize, 0, _borderSize, _borderSize);
        }

        public Rectangle BottomLeft()
        {
            return new Rectangle(0, this.ClientSize.Height - _borderSize, _borderSize, _borderSize);
        }

        public Rectangle BottomRight()
        {
            return new Rectangle(this.ClientSize.Width - _borderSize, this.ClientSize.Height - _borderSize, _borderSize, _borderSize);
        }
        #endregion

        private int _borderSize = 1;
        private Color _formBackGroundColor = Colors.FormBackGroundColor;
        private Color _formBorderColor = Colors.FormBorderColor;
        private bool _visible = false;
        [Category("커스텀 속성")]
        public bool FormVisible
        {
            get { return _visible; }
            set
            {
                if (InvokeRequired)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        _visible = value;
                        this.ShowInTaskbar = value;
                        this.Enabled = value;
                        if (value)
                            this.Opacity = 1;
                        else
                            this.Opacity = 0;
                        this.Invalidate();
                    }));
                }
                else
                {
                    _visible = value;
                    this.ShowInTaskbar = value;
                    this.Enabled = value;
                    if (value)
                        this.Opacity = 1;
                    else
                        this.Opacity = 0;
                    this.Invalidate();
                }
            }
        }

        [Category("커스텀 속성")]
        public int BorderSize
        {
            get { return _borderSize; }
            set
            {
                _borderSize = value;
                this.Invalidate();
            }
        }

        [Category("커스텀 속성")]
        public Color BorderColor
        {
            get { return _formBorderColor; }
            set
            {
                _formBorderColor = value;
                this.Invalidate();
            }
        }

        [Category("커스텀 속성")]
        public Color FormBackGroundColor
        {
            get { return _formBackGroundColor; }
            set
            {
                _formBackGroundColor = value;
                this.BackColor = FormBackGroundColor;
                this.Invalidate();
            }
        }

        public WithusForm()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.UpdateStyles();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = _formBackGroundColor;

            this.FormVisible = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(_formBorderColor))
            {
                e.Graphics.FillRectangle(b, Top());
                e.Graphics.FillRectangle(b, Left());
                e.Graphics.FillRectangle(b, Right());
                e.Graphics.FillRectangle(b, Bottom());
            }

            base.OnPaint(e);
        }
    }
}

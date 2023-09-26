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

        private bool _isDragging = false;
        private Point _dragStartPoint;

        private int LOOKUPCOUNT = 0;

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
            this.Padding = new Padding(5);
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

        public void SubscribeToDragEventsForPanels(Control container)
        {
            foreach (Control control in container.Controls)
            {
                if (control.GetType() == typeof(Panel) || control.GetType() == typeof(PictureBox))
                {
                    if (control.Tag == null || control.Tag.Equals("Subscribed"))
                    {
                        control.MouseDown += Panel_MouseDown;
                        control.MouseMove += Panel_MouseMove;
                        control.MouseUp += Panel_MouseUp;

                        control.Tag = "Subscribed";
                        LOOKUPCOUNT++;

                        if (control.HasChildren)
                        {
                            SubscribeToDragEventsForPanels(control);
                        }
                    }
                }
            }
        }

        public void UnsubscribeFromDragEventsForPanels(Control container)
        {
            foreach (Control control in container.Controls)
            {
                if (control.Tag != null)
                {
                    if (control.Tag.Equals("Subscribed"))
                    {
                        control.MouseDown -= Panel_MouseDown;
                        control.MouseMove -= Panel_MouseMove;
                        control.MouseUp -= Panel_MouseUp;

                        control.Tag = null;
                        LOOKUPCOUNT--;
                        Console.WriteLine("남은 이벤트 : " + LOOKUPCOUNT);

                        if (control.HasChildren)
                        {
                            UnsubscribeFromDragEventsForPanels(control);
                        }
                    }
                }
            }
        }

        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = true;
                _dragStartPoint = e.Location;
            }
        }

        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                this.Location = new Point(currentScreenPos.X - _dragStartPoint.X, currentScreenPos.Y - _dragStartPoint.Y);
            }
        }

        private void Panel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = false;
            }
        }
    }
}

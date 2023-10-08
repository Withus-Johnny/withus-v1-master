using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using WithusUI.Configs;

namespace WithusUI.Controls.Buttons
{
    public class WButton : Button
    {
        private int _borderSize = 2;
        private int _borderRadius = 20;

        // Default State
        private Color _backGroundColor = Colors.WButtonBackGroundColor;
        private Color _defaultBorderColor = Colors.WButtonDefaultBorderColor;
        private Color _defaultForeColor = Colors.WButtonDefaultForeColor;

        // Hover State
        private Color _hoverBackGroundColor = Colors.WButtonHoverBackGroundColor;
        private Color _hoverBorderColor = Colors.WButtonHoverBorderColor;
        private Color _hoverForeColor = Colors.WButtonHoverForeColor;

        // Active State
        private Color _activeBackGroundColor = Colors.WButtonActiveBackGroundColor;
        private Color _activeBorderColor = Colors.WButtonActiveBorderColor;
        private Color _activeForeColor = Colors.WButtonActiveForeColor;

        private ButtonState _buttonState = ButtonState.Normal;

        private Color _backColor;
        private Color _borderColor;
        private Color _foreColor;

        private bool _showFocusCues = false;

        #region Properties
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
        public int BorderRadius
        {
            get { return _borderRadius; }
            set
            {
                _borderRadius = value;
                this.Invalidate();
            }
        }

        [Category("커스텀 속성")]
        public Color DefaultBackGroundColor
        {
            get { return _backGroundColor; }
            set
            {
                _backGroundColor = value;
                this.BackColor = value;
                this.Invalidate();
            }
        }

        [Category("커스텀 속성")]
        public Color DefaultBorderColor
        {
            get { return _defaultBorderColor; }
            set
            {
                _defaultBorderColor = value;
                _borderColor = value;
                this.Invalidate();
            }
        }

        [Category("커스텀 속성")]
        public Color DefaultFontForeColor
        {
            get { return _defaultForeColor; }
            set
            {
                _defaultForeColor = value;
                this.ForeColor = value;
                this.Invalidate();
            }
        }

        [Category("커스텀 속성")]
        public Color HoverBorderColor
        {
            get { return _hoverBorderColor; }
            set
            {
                _hoverBorderColor = value;
                this.Invalidate();
            }
        }

        [Category("커스텀 속성")]
        public Color HoverBackColor
        {
            get { return _hoverBackGroundColor; }
            set
            {
                _hoverBackGroundColor = value;
                this.Invalidate();
            }
        }

        [Category("커스텀 속성")]
        public Color HoverForeColor
        {
            get { return _hoverForeColor; }
            set
            {
                _hoverForeColor = value;
                this.Invalidate();
            }
        }

        [Category("커스텀 속성")]
        public Color ActiveBackColor
        {
            get { return _activeBackGroundColor; }
            set
            {
                _activeBackGroundColor = value;
                this.Invalidate();
            }
        }

        [Category("커스텀 속성")]
        public Color ActiveBorderColor
        {
            get { return _activeBorderColor; }
            set
            {
                _activeBorderColor = value;
                this.Invalidate();
            }
        }

        [Category("커스텀 속성")]
        public Color ActiveForeColor
        {
            get { return _activeForeColor; }
            set
            {
                _activeForeColor = value;
                this.Invalidate();
            }
        }

        [Category("커스텀 속성")]
        public bool IsShowFocusCues
        {
            get { return _showFocusCues; }
            set
            {
                _showFocusCues = value;
                this.Invalidate();
            }
        }


        #endregion

        public WButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;

            this.Size = new Size(150, 40);

            this.BackColor = _backGroundColor;
            _backColor = _backGroundColor;

            this.ForeColor = _defaultForeColor;
            _foreColor = _defaultForeColor;

            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Resize += new EventHandler(Button_Resize);

            _borderColor = _defaultBorderColor;
            this.Cursor = Cursors.Hand;
        }

        #region Functions
        private GraphicsPath GetFigurePath(Rectangle rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void SetButtonState(ButtonState buttonState)
        {
            if (_buttonState != buttonState)
            {
                _buttonState = buttonState;

                switch (buttonState)
                {
                    case ButtonState.Normal:
                        _backColor = _backGroundColor;
                        _borderColor = _defaultBorderColor;
                        _foreColor = _defaultForeColor;
                        break;
                    case ButtonState.Hover:
                        _backColor = _hoverBackGroundColor;
                        _borderColor = _hoverBorderColor;
                        _foreColor = _hoverForeColor;
                        break;
                    case ButtonState.Pressed:
                        _backColor = _activeBackGroundColor;
                        _borderColor = _activeBorderColor;
                        _foreColor = _activeForeColor;
                        break;
                }

                this.FlatAppearance.MouseDownBackColor = _activeBackGroundColor;
                this.FlatAppearance.MouseOverBackColor = _hoverBackGroundColor;
                this.BackColor = _backColor;
                this.ForeColor = _foreColor;
                Invalidate();
            }
        }
        #endregion

        #region Events
        private void Button_Resize(object sender, EventArgs e)
        {
            if (_borderRadius > this.Height)
                _borderRadius = this.Height;
        }
        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        #endregion

        #region Override
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            Rectangle rectSurface = this.ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -_borderSize, -_borderSize);
            int smoothSize = 2;
            if (_borderSize > 0)
                smoothSize = _borderSize;

            if (_borderRadius > 2)
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, _borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, _borderRadius - _borderSize))
                using (Pen penSurface = new Pen(this.Parent.BackColor, smoothSize))
                using (Pen penBorder = new Pen(_borderColor, _borderSize))
                {
                    pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                    this.Region = new Region(pathSurface);

                    pevent.Graphics.DrawPath(penSurface, pathSurface);

                    if (_borderSize >= 1)
                        pevent.Graphics.DrawPath(penBorder, pathBorder);
                }
            }
            else
            {
                pevent.Graphics.SmoothingMode = SmoothingMode.None;
                this.Region = new Region(rectSurface);

                if (_borderSize >= 1)
                {
                    using (Pen penBorder = new Pen(_borderColor, _borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                    }
                }
            }
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.Button == MouseButtons.Left)
            {
                if (ClientRectangle.Contains(e.Location))
                    SetButtonState(ButtonState.Pressed);
                else
                {
                    SetButtonState(ButtonState.Hover);
                }
            }
            else
            {
                _borderColor = _hoverBorderColor;
                SetButtonState(ButtonState.Hover);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (!ClientRectangle.Contains(e.Location))
                return;

            SetButtonState(ButtonState.Pressed);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            SetButtonState(ButtonState.Normal);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            SetButtonState(ButtonState.Normal);
        }

        protected override void OnMouseCaptureChanged(EventArgs e)
        {
            base.OnMouseCaptureChanged(e);

            var location = Cursor.Position;

            if (!ClientRectangle.Contains(location))
                SetButtonState(ButtonState.Normal);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            var location = Cursor.Position;

            if (!ClientRectangle.Contains(location))
                SetButtonState(ButtonState.Normal);
            else
                SetButtonState(ButtonState.Hover);
        }

        protected override bool ShowFocusCues
        {
            get
            {
                return _showFocusCues;
            }
        }
        #endregion
    }
}

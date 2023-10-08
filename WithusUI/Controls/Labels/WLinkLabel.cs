using System;
using System.Drawing;
using System.Windows.Forms;
using WithusUI.Configs;

namespace WithusUI.Controls.Labels
{
    public class WLinkLabel : Label
    {
        private bool _isHover;
        private bool _isActive;

        public WLinkLabel()
        {
            this.ForeColor = Colors.WLinkLabelForeColor;
            this.Cursor = Cursors.Hand;

            this.MouseDown += WLinkLabel_MouseDown;
            this.MouseUp += WLinkLabel_MouseUp;
            this.MouseLeave += WLinkLabel_MouseLeave;
        }

        private void WLinkLabel_MouseLeave(object sender, EventArgs e)
        {
            if (_isHover)
            {
                _isHover = false;
                _isActive = false;
                this.ForeColor = Colors.WLinkLabelForeColor;
            }
        }

        private void WLinkLabel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.ForeColor = Colors.WLinkLabelForeColor;
            }
        }

        private void WLinkLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isActive = true;
                this.ForeColor = Colors.WLinkLabelActiveColor;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (e.Button == MouseButtons.None)
            {
                if (this.ClientRectangle.Contains(e.Location))
                {
                    if (!_isHover && !_isActive)
                    {
                        _isHover = true;
                        this.ForeColor = Colors.WLinkLabelHoverForeColor;
                    }
                }
            }
        }
    }
}

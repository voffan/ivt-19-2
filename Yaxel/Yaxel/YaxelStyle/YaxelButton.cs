using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yaxel.YaxelStyle
{
    public class YaxelButton : Control, IButtonControl
    {
        private Color bgColor = ColorTranslator.FromHtml("#FFA755");

        private StringFormat SF = new StringFormat();

        private bool mouseEntered = false;
        private bool mousePressed = false;

        private DialogResult dialogResult;
        public DialogResult DialogResult { get => dialogResult; set => dialogResult = value; }

        public YaxelButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            DoubleBuffered = true;

            Size = new Size(250, 50);
            Font = new Font("Arial", 16F, FontStyle.Regular);
            ForeColor = Color.White;

            SF.Alignment = StringAlignment.Center;
            SF.LineAlignment = StringAlignment.Center;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.HighQuality;

            graphics.Clear(Parent.BackColor);

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);

            graphics.DrawRectangle(new Pen(bgColor), rect);
            graphics.FillRectangle(new SolidBrush(bgColor), rect);

            if (mouseEntered)
            {
                graphics.DrawRectangle(new Pen(Color.FromArgb(30, Color.White)), rect);
                graphics.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.White)), rect);
            }

            if (mousePressed)
            {
                graphics.DrawRectangle(new Pen(Color.FromArgb(60, Color.Black)), rect);
                graphics.FillRectangle(new SolidBrush(Color.FromArgb(60, Color.Black)), rect);
            }

            graphics.DrawString(Text, Font, new SolidBrush(ForeColor), rect, SF);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            mouseEntered = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            mouseEntered = false;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            mousePressed = true;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            mousePressed = false;
            Invalidate();
        }

        public void NotifyDefault(bool value) { }

        public void PerformClick() 
        { 
            EventArgs e = new EventArgs();
            this.OnClick(e);
        }
    }
}

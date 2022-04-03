using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Yaxel.YaxelStyle
{
    public partial class YaxelForm : Component
    {
        #region -- Свойства --

        private Form Form = null;
        public Form ThisForm
        {
            get => Form;
            set
            {
                Form = value;
                Init();
            }
        }

        #endregion
        #region -- Поля --

        private Color headerColor = ColorTranslator.FromHtml("#FFA755");
        private Color btnCloseColor = ColorTranslator.FromHtml("#FF4D4D");
        private Color btnMinColor = ColorTranslator.FromHtml("#C9CDD0");

        private int headerHeight = 36;
        private int btnWidth = 42;
        private int btnHeight = 35;

        private Font headerTextFont = new Font("Arial", 16F, FontStyle.Regular);
        private StringFormat SF = new StringFormat();

        private bool MousePressed = false;
        private Point clickPosition;
        private Point moveStartPosition;

        private bool btnCloseHovered = false;
        private bool btnMinHovered = false;

        private Rectangle rectHeader;
        private Rectangle rectBtnClose;
        private Rectangle rectBtnMin;

        #endregion
        public YaxelForm()
        {
            InitializeComponent();
        }

        public YaxelForm(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private void Init()
        {                    
            if (Form != null)
            {
                Form.FormBorderStyle = FormBorderStyle.None;
                Form.StartPosition = FormStartPosition.CenterScreen;

                Form.Width = 1280;
                Form.Height = 720;

                SF.Alignment = StringAlignment.Center;
                SF.LineAlignment = StringAlignment.Center;

                SetDoubleBuffered(Form);

                Form.Paint += Form_Paint;
                Form.MouseDown += Form_MouseDown;
                Form.MouseUp += Form_MouseUp;
                Form.MouseMove += Form_MouseMove;
                Form.MouseLeave += Form_MouseLeave;
            }
        }

        #region -- Методы формы --

        private void Form_MouseLeave(object sender, EventArgs e)
        {
            btnCloseHovered = false;
            btnMinHovered = false;
            Form.Invalidate();
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (MousePressed)
            {
                Size frmOffset = new Size(Point.Subtract(Cursor.Position, new Size(clickPosition)));
                Form.Location = Point.Add(moveStartPosition, frmOffset);
            }
            
            if (rectBtnClose.Contains(e.Location))
            {
                if (btnCloseHovered == false)
                {
                    btnCloseHovered = true;
                    Form.Invalidate();
                }
            }
            else
            {
                if (btnCloseHovered == true)
                {
                    btnCloseHovered = false;
                    Form.Invalidate();
                }
            }

            if (rectBtnMin.Contains(e.Location))
            {
                if (btnMinHovered == false)
                {
                    btnMinHovered = true;
                    Form.Invalidate();
                }
            }
            else
            {
                if (btnMinHovered == true)
                {
                    btnMinHovered = false;
                    Form.Invalidate();
                }
            }
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MousePressed = false;

                if (rectBtnClose.Contains(e.Location))
                    Form.Close();

                if (rectBtnMin.Contains(e.Location) && Form.MinimizeBox == true)
                    Form.WindowState = FormWindowState.Minimized;
            }
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Location.Y <= headerHeight && !rectBtnClose.Contains(e.Location) && !rectBtnMin.Contains(e.Location))
            {
                MousePressed = true;
                clickPosition = Cursor.Position;
                moveStartPosition = Form.Location;
            }
        }

        private void Form_Paint(object sender, PaintEventArgs e)
        {
            DrawStyle(e.Graphics);
        }

        #endregion

        private void DrawStyle(Graphics graphics)
        {
            graphics.SmoothingMode = SmoothingMode.HighQuality;

            #region -- Config --

            rectHeader = new Rectangle(0, 0, Form.Width - 1, headerHeight);
            Rectangle rectBorder = new Rectangle(0, 0, Form.Width - 1, Form.Height - 1);

            rectBtnClose = new Rectangle(rectHeader.Width - btnWidth - 1, rectHeader.Y + 1, btnWidth, btnHeight);

            rectBtnMin = new Rectangle(rectHeader.Width - btnWidth * 2 - 1, rectHeader.Y + 1, btnWidth, btnHeight);

            #endregion
            #region -- Drawing

            graphics.DrawRectangle(new Pen(headerColor), rectHeader);
            graphics.FillRectangle(new SolidBrush(headerColor), rectHeader);

            graphics.DrawRectangle(new Pen(Color.Gray), rectBorder);

            graphics.DrawString(Form.Text, headerTextFont, new SolidBrush(Color.White), rectHeader, SF);

            graphics.DrawRectangle(new Pen(btnCloseHovered ? btnCloseColor : headerColor), rectBtnClose);
            graphics.FillRectangle(new SolidBrush(btnCloseHovered ? btnCloseColor : headerColor), rectBtnClose);

            graphics.DrawRectangle(new Pen(btnMinHovered ? btnMinColor : headerColor), rectBtnMin);
            graphics.FillRectangle(new SolidBrush(btnMinHovered ? btnMinColor : headerColor), rectBtnMin);

            graphics.DrawLine(new Pen(Color.White, 2f),
                rectBtnClose.X + (btnWidth / 2f - 10),
                rectBtnClose.Y + (btnHeight / 2f - 10),
                rectBtnClose.X + (btnWidth / 2f + 10),
                rectBtnClose.Y + (btnHeight / 2f + 10));
            graphics.DrawLine(new Pen(Color.White, 2f),
                rectBtnClose.X + (btnWidth / 2f + 10),
                rectBtnClose.Y + (btnHeight / 2f - 10),
                rectBtnClose.X + (btnWidth / 2f - 10),
                rectBtnClose.Y + (btnHeight / 2f + 10));

            graphics.DrawLine(new Pen(Color.White, 2f),
                rectBtnMin.X + (btnWidth / 2f + 10),
                rectBtnMin.Y + (btnHeight / 2f),
                rectBtnMin.X + (btnWidth / 2f - 10),
                rectBtnMin.Y + (btnHeight / 2f));

            #endregion
        }

        private static void SetDoubleBuffered(Control c)
        {
            if (SystemInformation.TerminalServerSession)
                return;

            System.Reflection.PropertyInfo pDoubleBuffered =
                  typeof(Control).GetProperty(
                        "DoubleBuffered",
                        System.Reflection.BindingFlags.NonPublic |
                        System.Reflection.BindingFlags.Instance);

            pDoubleBuffered.SetValue(c, true, null);
        }
    }
}

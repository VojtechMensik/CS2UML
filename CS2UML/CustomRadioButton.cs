using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace CS2UML
{
    internal class CustomRadioButton : RadioButton
    {
        private Color checkedColor = Color.DarkGray;
        private Color unCheckedColor = Color.Gray;
        [Category("CheckColor")]
        public Color CheckedColor { get => checkedColor; set { checkedColor = value; Invalidate(); }}
        [Category("CheckColor")]
        public Color UnCheckedColor { get => unCheckedColor; set { unCheckedColor = value; Invalidate(); } }
        public CustomRadioButton()
        {
            MinimumSize = new Size(0, 21);
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics graphics = pevent.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            float rbBorderSize = 18F;
            float rbCheckSize = 12F;
            RectangleF rectRbBorder = new RectangleF()
            {
                X = 0.5F,
                Y = (Height - rbBorderSize) / 2,
                Width = rbBorderSize,
                Height = rbBorderSize
            };
            RectangleF rectRbCheck = new RectangleF()
            {
                X = rectRbBorder.X + ((rectRbBorder.Width - rbCheckSize) / 2),
                Y = (Height - rbCheckSize) / 2,
                Width = rbCheckSize,
                Height = rbCheckSize
            };

            using (Pen penBorder=new Pen(checkedColor,1.6F))
            using(SolidBrush brushRbCheck = new SolidBrush(checkedColor))
            using(SolidBrush brushText = new SolidBrush(ForeColor))
            {
                graphics.Clear(BackColor);
                if(Checked)
                {
                    graphics.DrawEllipse(penBorder,rectRbBorder);
                    graphics.FillEllipse(brushRbCheck,rectRbCheck);
                }
                else
                {
                    penBorder.Color = unCheckedColor;
                    graphics.DrawEllipse(penBorder,rectRbBorder);
                }
                graphics.DrawString(Text,Font, brushText, rbBorderSize+8,
                    (Height-TextRenderer.MeasureText(Text,Font).Height)/2);
                if (Image != null)
                {
                    int imgX = (int)(pevent.Graphics.MeasureString(Text, Font)).Width + Image.Width/2 + 5,
                        imgY = (Height - Image.Height) / 2;
                    graphics.DrawImage(Image, new Rectangle(imgX, imgY, Image.Width, Image.Height));
                }
            }
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            int imgWidth = 0;
            if (Image != null)
            {
                imgWidth = Image.Width;
            }
            Width = TextRenderer.MeasureText (Text,Font).Width + imgWidth + 35;
        }
    }
}

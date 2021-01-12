using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace SalesFeedBackInfrasturcture.Commond
{
    public static class IconFontAwesome
    {
        static PrivateFontCollection privateFonts = new PrivateFontCollection();
        static FontFamily fontAwesome;

        /// <summary>
        /// 获取IconFontAwesome字体样式
        /// </summary>
        public static FontFamily FontAwesome
        {
            get
            {
                if (fontAwesome == null)
                {
                    byte[] f = Properties.Resources.iconfont;
                    unsafe
                    {
                        fixed (byte* pFontData = f)
                        {
                            privateFonts.AddMemoryFont((IntPtr)pFontData, f.Length);
                        }
                    }
                    fontAwesome = privateFonts.Families[0];
                }
                return fontAwesome;
            }
        }

        /// <summary>
        /// 将IconFont转图片
        /// </summary>
        /// <param name="iconFont"></param>
        /// <returns></returns>
        public static Bitmap ToImage(IconFont iconFont)
        {
            if (iconFont == null || iconFont.Icon == IconFontChars._None)
            {
                return null;
            }

            Graphics g;
            Bitmap srcBitmap = new Bitmap(1, 1);
            StringFormat format = new StringFormat(StringFormatFlags.NoWrap);
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;

            Rectangle rect = Rectangle.Empty;

            //字号五倍放大
            int fontSize = iconFont.IconSize.Width * 5;
            if (iconFont.IconSize.Width < iconFont.IconSize.Height)
            {
                fontSize = iconFont.IconSize.Height * 5;
            }

            string text = ((char)iconFont.Icon).ToString();
            Font font = new System.Drawing.Font(FontAwesome, fontSize, System
                .Drawing.FontStyle.Regular, GraphicsUnit.Point);

            //计算原始图标
            if (rect == Rectangle.Empty)
            {
                g = Graphics.FromImage(srcBitmap);
                //计算绘制文字所需的区域大小（根据宽度计算长度），重新创建矩形区域绘图
                SizeF sizef = g.MeasureString(text, font, PointF.Empty, format);

                int width = (int)(sizef.Width + 1);
                int height = (int)(sizef.Height + 1);
                rect = new Rectangle(0, 0, width, height);
                srcBitmap.Dispose();
                g.Dispose();

                srcBitmap = new Bitmap(width, height);
            }
            g = Graphics.FromImage(srcBitmap);
            SetGraphics(g);
            //绘制原始图标(不用solidbrush)
            LinearGradientBrush iconBrush = new LinearGradientBrush(
                rect, iconFont.ForeColor, iconFont.ForeColor, 0f, true);
            //直接画出来的字符，会带空白部分，所以要把空白裁剪掉
            g.DrawString(text, font, iconBrush, rect, format);
            //重新计算位图尺寸和裁剪坐标
            FixBitmapArgs args = GetBitmapSizeP(srcBitmap, iconFont.ForeColor);
            //不带空白部分的位图，为原始输出位图
            Bitmap bmpOut1 = new Bitmap(args.Size.Width, args.Size.Height);
            Graphics g4 = Graphics.FromImage(bmpOut1);
            SetGraphics(g4);
            //裁剪有效图标区域，去掉空白部分
            g4.DrawImage(srcBitmap, new Rectangle(0, 0, args.Size.Width, args.Size.Height),
                new Rectangle(args.MinPoint.X, args.MinPoint.Y, args.Size.Width, args.Size.Height), GraphicsUnit.Pixel);
            //图标的尺寸
            Size imgSize = new Size();
            int w = iconFont.IconSize.Width - (iconFont.Padding.Left + iconFont.Padding.Right);
            if (w < 0)
            {
                w = 1;
            }
            int h = iconFont.IconSize.Height - (iconFont.Padding.Top + iconFont.Padding.Bottom);
            if (h < 0)
            {
                h = 1;
            }
            imgSize.Width = w;
            imgSize.Height = h;
            //压缩图标到指定尺寸
            Bitmap resultBitmap1 = ImageConverter.ResizeImage(bmpOut1, imgSize);

            //输出
            Bitmap outputImg = new Bitmap(iconFont.IconSize.Width, iconFont.IconSize.Height);
            Graphics g5 = Graphics.FromImage(outputImg);
            SetGraphics(g5);
            //画图标背景
            g5.FillRectangle(new SolidBrush(iconFont.BackColor), new RectangleF(0, 0, iconFont.IconSize.Width, iconFont.IconSize.Height));
            //图标
            g5.DrawImage(resultBitmap1, new PointF(iconFont.Padding.Left, iconFont.Padding.Top));
            //释放资源
            format.Dispose();
            iconBrush.Dispose();
            srcBitmap.Dispose();
            bmpOut1.Dispose();
            resultBitmap1.Dispose();
            g.Dispose();
            g4.Dispose();
            return outputImg;
        }

        /// <summary>
        /// 从原始图标Bitmap中提取有效图标的尺寸和最小最大坐标
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="selectorColor"></param>
        /// <returns></returns>
        private static FixBitmapArgs GetBitmapSizeP(Bitmap bitmap, Color selectorColor)
        {
            Size size = Size.Empty;
            Point minPoint = Point.Empty;
            Point maxPoint = Point.Empty;
            int minPointX = 100000000;
            int maxPointX = 0;
            int minPointY = 100000000;
            int maxPointY = 0;

            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color color = bitmap.GetPixel(x, y);
                    if (color.R == selectorColor.R && color.G == selectorColor.G && color.B == selectorColor.B)
                    {
                        if (x < minPointX)
                        {
                            minPointX = x;
                        }
                        if (x > maxPointX)
                        {
                            maxPointX = x;
                        }
                        if (y < minPointY)
                        {
                            minPointY = y;
                        }
                        if (y > maxPointY)
                        {
                            maxPointY = y;
                        }
                    }
                }
            }
            size = new Size(maxPointX - minPointX, maxPointY - minPointY);
            minPoint = new Point(minPointX, minPointY);
            maxPoint = new Point(maxPointX, maxPointY);
            return new FixBitmapArgs { Size = size, MinPoint = minPoint, MaxPoint = maxPoint };
        }

        /// <summary>
        /// 设置Graphics属性
        /// </summary>
        /// <param name="g"></param>
        private static void SetGraphics(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;  //使绘图质量最高，即消除锯齿
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
        }
    }

    internal class FixBitmapArgs
    {
        public Size Size { get; set; }
        public Point MinPoint { get; set; }
        public Point MaxPoint { get; set; }
    }
}

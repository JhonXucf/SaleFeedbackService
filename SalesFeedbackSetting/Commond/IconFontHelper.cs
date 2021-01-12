using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;

namespace SalesFeedBackInfrasturcture.Commond
{
    public class IconFontHelper
    {
        /// <summary>
        /// 默认字体图标
        /// </summary>
        private IconFontChars _Icon = IconFontChars._None;
        /// <summary>
        /// 默认字体图标尺寸
        /// </summary>
        private Size _IconSize = new Size(24, 24);
        /// <summary>
        /// 默认字体图标前颜色
        /// </summary>
        private Color _ForeColor = Color.FromArgb(51, 51, 51);//#333333
        /// <summary>
        /// 默认字体图标背景色
        /// </summary>
        private Color _BackColor = Color.Transparent;
        /// <summary>
        /// 默认 图标到边缘的距离
        /// </summary>
        private Padding _Padding = new Padding(0);

        public IconFontChars Icon { get { return _Icon; } set { _Icon = value; } }
        public Size IconSize { get { return _IconSize; } set { _IconSize = value; } }
        public Color ForeColor { get { return _ForeColor; } set { _ForeColor = value; } }
        public Color BackColor { get { return _BackColor; } set { _BackColor = value; } }
        public Padding Padding { get { return _Padding; } set { _Padding = value; } }

        /// <summary>
        /// 用于表格中的状态 YES
        /// </summary>
        public static Bitmap StatusYes
        {
            get
            {
                return IconFontAwesome.ToImage(new IconFont
                {
                    Icon = IconFontChars.DG_对勾1,
                    Padding = new Padding(6),
                    ForeColor = Color.Green
                });
            }
        }

        /// <summary>
        /// 用于表格中的状态 NO
        /// </summary>
        public static Bitmap StatusNo
        {
            get
            {
                return IconFontAwesome.ToImage(new IconFont
                {
                    Icon = IconFontChars.GB_关闭1,
                    Padding = new Padding(6)
                });
            }
        }

        /// <summary>
        /// 默认图标
        /// </summary>
        /// <param name="iconFontChars"></param>
        /// <returns></returns>
        public static Bitmap Default(IconFontChars iconFontChars)
        {
            return Default(iconFontChars, new Padding(0), BaseStyle.ToolBarIconColor);
        }

        /// <summary>
        /// 默认图标
        /// </summary>
        /// <param name="iconFontChars"></param>
        /// <param name="padding"></param>
        /// <returns></returns>
        public static Bitmap Default(IconFontChars iconFontChars, Padding padding)
        {
            return Default(iconFontChars, padding, BaseStyle.ToolBarIconColor);
        }

        /// <summary>
        /// 默认图标
        /// </summary>
        /// <param name="iconFontChars"></param>
        /// <param name="padding"></param>
        /// <param name="foreColor"></param>
        /// <returns></returns>
        public static Bitmap Default(IconFontChars iconFontChars, Padding padding, Color foreColor)
        {
            return IconFontAwesome.ToImage(new IconFont
            {
                ForeColor = foreColor,
                Icon = iconFontChars,
                Padding = padding
            });
        }
    }
}

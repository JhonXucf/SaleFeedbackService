using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppSettingsHelper.CustomControls
{
    public static class ControlHelper
    {
        /// <summary>
        /// 获取当前控件的空余位置并返回
        /// </summary>
        /// <param name="mainControl"></param>
        /// <returns></returns>
        public static Point SetControlLocation(this Control mainControl, int startX, int startY, int offset)
        {
            if (mainControl == null)
            {
                throw new ArgumentNullException("mainControl", "Argument is Null");
            }
            var p = new Point(startX, startY);
            if (mainControl.Controls.Count == 0)
            {
                return p;
            }
            //取出最后一个控件
            Control item = mainControl.Controls[mainControl.Controls.Count - 1];
            if (item.Location.X + item.Width * 2 + offset > mainControl.Width)
            {
                p.Y = item.Location.Y + item.Height + offset;
            }
            else
            {
                p.Y = item.Location.Y;
                p.X = item.Location.X + item.Width + offset;
            }
            return p;
        }
        /// <summary>
        /// 将控件内控件重新排序
        /// </summary>
        /// <param name="mainControl"></param>
        /// <returns></returns>
        public static void UpdateControlLocation(this Control mainControl, int startX, int startY, int offset)
        {
            if (mainControl == null)
            {
                throw new ArgumentNullException("mainControl", "Argument is Null");
            }
            if (mainControl.Controls.Count == 0)
            {
                return;
            }
            Control conLast = mainControl.Controls[0];
            conLast.Location = new Point(startX, startY);
            foreach (Control item in mainControl.Controls)
            {
                if (conLast == item) continue;
                if (conLast.Location.X + conLast.Width * 2 + offset > mainControl.Width)
                {
                    item.Location = new Point(startX, conLast.Location.Y + conLast.Height + offset);
                }
                else
                {
                    item.Location = new Point(conLast.Location.X + conLast.Width + offset, conLast.Location.Y);
                }
                conLast = item;
            }
        }
        public static Bitmap GetBitmap(this String key)
        {
            int val = AppCommondHelper.IconFontAwesome.TypeDict[key];
            return AppCommondHelper.IconFontAwesome.GetImage(val);
        }
    }
}

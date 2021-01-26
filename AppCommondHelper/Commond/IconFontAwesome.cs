﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;

namespace AppCommondHelper
{
    /// <summary>
    /// IconFontAwesome static helper object,default icon size is 32,no border,backcolor is Color.Transparent,forecolor is Color.Black,border color is Color.Gray.
    /// </summary>
    /// <example>
    /// defalut:
    /// Bitmap bmp = IconFontAwesome.GetImage(0xf188);
    /// Icon ico = IconFontAwesome.GetIcon(0xf188);
    /// custom:
    /// IconFontAwesome.IconSize = 128;//change icon size
    /// IconFontAwesome.ForeColer = Color.Purple;//change icon forecolor
    /// Bitmap bmp = IconFontAwesome.GetImage(0xf188);
    /// Icon ico = IconFontAwesome.GetIcon(0xf188);
    /// </example>
    public class IconFontAwesome
    {
        #region Fileds
        /// <summary>
        /// IconFontAwesome Name
        /// </summary>
        private static readonly string FontAwesomeName = "fontawesome-webfont.ttf";
        /// <summary>
        /// IconFontAwesome Location
        /// </summary>
        private static readonly string FontAwesomeLocation = "font\\";
        /// <summary>
        /// FontCollection object
        /// </summary>
        private static readonly PrivateFontCollection FontCollection = new PrivateFontCollection();

        /// <summary>
        /// IconFontAwesome Version
        /// </summary>
        public static readonly string FontAwesomeVersion = "4.7.0";
        /// <summary>
        /// icon image size
        /// </summary>
        public static int IconSize { get; set; }
        /// <summary>
        /// border visible
        /// </summary>
        public static bool BorderVisible { get; set; }
        /// <summary>
        /// icon image backcolor
        /// </summary>
        public static Color BackColer { get; set; }
        /// <summary>
        /// icon image forecolor
        /// </summary>
        public static Color ForeColer { get; set; }
        /// <summary>
        /// icon image border color
        /// </summary>
        public static Color BorderColer { get; set; }

        #endregion

        #region //static ctor

        /// <summary>
        /// static ctor
        /// </summary>
        static IconFontAwesome()
        {
            IconSize = 128;
            BorderVisible = false;
            BackColer = Color.Transparent;
            ForeColer = Color.Black;
            BorderColer = Color.Gray;
            string path = AppDomain.CurrentDomain.BaseDirectory + FontAwesomeLocation + FontAwesomeName;
            if (File.Exists(path))
            {
                FontCollection.AddFontFile(path);
            }
            else
            {
                throw new FileNotFoundException("IconFontAwesome font file not found", path);
            }
        }

        #endregion

        #region //get IconFontAwesome icon

        /// <summary>
        /// get IconFontAwesome icon
        /// </summary>
        /// <param name="iconText">IconFontAwesome icon hex code</param>
        /// <returns></returns>
        public static Icon GetIcon(int iconText)
        {
            Bitmap bmp = GetImage(iconText);
            if (bmp != null)
            {
                return ToIcon(bmp, IconSize);
            }
            return null;
        }

        #endregion

        #region //get IconFontAwesome image

        /// <summary>
        /// get IconFontAwesome image
        /// </summary>
        /// <param name="iconText">IconFontAwesome icon hex code</param>
        /// <returns></returns>
        public static Bitmap GetImage(int iconText)
        {
            //get icon really size
            Size size = GetIconSize(iconText);
            var bmp = new Bitmap(size.Width, size.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                //convert font code
                string unicode = char.ConvertFromUtf32(iconText);
                Font font = GetFont();// new Font("IconFontAwesome", IconSize * (3f / 4f), FontStyle.Regular, GraphicsUnit.Point);

                //setting graphics
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                Rectangle rect = new Rectangle(new Point(0, 0), size);

                //Draw background color
                Brush backBrush = new SolidBrush(BackColer);
                g.FillRectangle(backBrush, rect);
                backBrush.Dispose();

                //draw icon
                Brush iconBrush = new SolidBrush(ForeColer);
                g.DrawString(unicode, font, iconBrush, new PointF(0, 0));

                iconBrush.Dispose();

                //draw icon to bmp
                g.DrawImage(bmp, 0, 0);
            }
            //resizer image
            bmp = Resizer(bmp, new Size(IconSize, IconSize),
                new Point((int)Math.Ceiling(IconSize * 0.04), (int)Math.Ceiling(IconSize * 0.05)), BackColer,
                BorderVisible, BorderColer);
            return bmp;
        }

        #endregion

        #region //get icon really size

        /// <summary>
        /// get icon really size
        /// </summary>
        /// <param name="iconText">IconFontAwesome icon hex code</param>
        /// <returns></returns>
        private static Size GetIconSize(int iconText)
        {
            using (var bmp = new Bitmap(IconSize, IconSize))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    string unicode = char.ConvertFromUtf32(iconText);
                    Font font = GetFont(); //new Font("IconFontAwesome", IconSize * (3f / 4f), FontStyle.Regular, GraphicsUnit.Point);
                    SizeF size = g.MeasureString(unicode, font);
                    return size.ToSize();
                }
            }
        }

        #endregion

        #region //image resizer funtion

        /// <summary>
        /// image resizer funtion
        /// </summary>
        /// <param name="srcImage">source Bitmap object</param>
        /// <param name="destSize">dest image's size</param>
        /// <param name="offset">dest image offset point</param>
        /// <param name="backColor">dest image's background color,default value is <value>Color.Transparent</value></param>
        /// <param name="drawBorder">dest image's size</param>
        /// <param name="borderColor">dest image's border color,default value is Color.Gray</param>
        /// <returns></returns>
        private static Bitmap Resizer(Bitmap srcImage, Size destSize, Point offset, Color backColor, bool drawBorder,
            Color borderColor)
        {
            if (srcImage == null)
            {
                throw new ArgumentNullException("srcImage");
            }
            if (destSize == null)
            {
                throw new ArgumentNullException("destSize");
            }

            var bmp = new Bitmap(destSize.Width, destSize.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                Size os = srcImage.Size;

                int max = Math.Max(os.Height, os.Width);

                int width = max;
                int height = max;
                int x = (os.Width - max) / 2 - offset.X;
                int y = (os.Height - max) / 2 - offset.Y;

                //get dest & src image's draw rectangle
                Rectangle destRectangle = new Rectangle(new Point(0, 0), bmp.Size);
                Rectangle srcRectangle = new Rectangle(x, y, width, height);

                //fill background color
                Brush brush = new SolidBrush(backColor);
                g.FillRectangle(brush, destRectangle);
                brush.Dispose();

                //resizer image
                g.DrawImage(srcImage, destRectangle, srcRectangle, GraphicsUnit.Pixel);

                if (drawBorder)
                {
                    Pen pen = new Pen(borderColor);
                    g.DrawRectangle(pen, destRectangle);
                    pen.Dispose();
                }
                return bmp;
            }
        }

        #endregion

        #region //convert image to icon

        /// <summary>
        /// convert image to icon
        /// </summary>
        /// <param name="srcBitmap">The input stream</param>
        /// <param name="size">The size (16x16 px by default)</param>
        /// <returns>Icon</returns>
        private static Icon ToIcon(Bitmap srcBitmap, int size)
        {
            if (srcBitmap == null)
            {
                throw new ArgumentNullException("srcBitmap");
            }
            Icon icon = null;

            Bitmap bmp = new Bitmap(srcBitmap, new Size(size, size));

            // save the resized png into a memory stream for future use
            using (MemoryStream tmpStream = new MemoryStream())
            {
                bmp.Save(tmpStream, ImageFormat.Png);

                Stream outStraem = new MemoryStream();
                BinaryWriter writer = new BinaryWriter(outStraem);
                if (outStraem.Length <= 0)
                {
                    return null;
                }
                // 0-1 reserved, 0
                writer.Write((byte)0);
                writer.Write((byte)0);

                // 2-3 image type, 1 = icon, 2 = cursor
                writer.Write((short)1);

                // 4-5 number of images
                writer.Write((short)1);

                // image entry 1
                // 0 image width
                writer.Write((byte)size);
                // 1 image height
                writer.Write((byte)size);

                // 2 number of colors
                writer.Write((byte)0);

                // 3 reserved
                writer.Write((byte)0);

                // 4-5 color planes
                writer.Write((short)0);

                // 6-7 bits per pixel
                writer.Write((short)32);

                // 8-11 size of image data
                writer.Write((int)tmpStream.Length);

                // 12-15 offset of image data
                writer.Write((int)(6 + 16));

                // write image data
                // png data must contain the whole png data file
                writer.Write(tmpStream.ToArray());

                writer.Flush();
                writer.Seek(0, SeekOrigin.Begin);
                icon = new Icon(outStraem);
                outStraem.Dispose();
            }
            return icon;
        }

        #endregion

        #region //get font function
        /// <summary>
        /// get font function
        /// </summary>
        /// <returns></returns>
        private static Font GetFont()
        {
            var size = IconSize * (3f / 4f);
            var font = new Font(FontCollection.Families[0], size, FontStyle.Regular, GraphicsUnit.Point);
            return font;
        }
        #endregion

        #region //Type Dictionary

        /// <summary>
        /// Type Dictionary
        /// </summary>
        public static Dictionary<string, int> TypeDict = new Dictionary<string, int>()
        {
            {"fa-glass", 0xf000},
            {"fa-music", 0xf001},
            {"fa-search", 0xf002},
            {"fa-envelope-o", 0xf003},
            {"fa-heart", 0xf004},
            {"fa-star", 0xf005},
            {"fa-star-o", 0xf006},
            {"fa-user", 0xf007},
            {"fa-film", 0xf008},
            {"fa-th-large", 0xf009},
            {"fa-th", 0xf00a},
            {"fa-th-list", 0xf00b},
            {"fa-check", 0xf00c},
            {"fa-times", 0xf00d},
            {"fa-remove", 0xf00d},
            {"fa-close", 0xf00d},
            {"fa-search-plus", 0xf00e},
            {"fa-search-minus", 0xf010},
            {"fa-power-off", 0xf011},
            {"fa-signal", 0xf012},
            {"fa-cog", 0xf013},
            {"fa-gear", 0xf013},
            {"fa-trash-o", 0xf014},
            {"fa-home", 0xf015},
            {"fa-file-o", 0xf016},
            {"fa-clock-o", 0xf017},
            {"fa-road", 0xf018},
            {"fa-download", 0xf019},
            {"fa-arrow-circle-o-down", 0xf01a},
            {"fa-arrow-circle-o-up", 0xf01b},
            {"fa-inbox", 0xf01c},
            {"fa-play-circle-o", 0xf01d},
            {"fa-repeat", 0xf01e},
            {"fa-rotate-right", 0xf01e},
            {"fa-refresh", 0xf021},
            {"fa-list-alt", 0xf022},
            {"fa-lock", 0xf023},
            {"fa-flag", 0xf024},
            {"fa-headphones", 0xf025},
            {"fa-volume-off", 0xf026},
            {"fa-volume-down", 0xf027},
            {"fa-volume-up", 0xf028},
            {"fa-qrcode", 0xf029},
            {"fa-barcode", 0xf02a},
            {"fa-tag", 0xf02b},
            {"fa-tags", 0xf02c},
            {"fa-book", 0xf02d},
            {"fa-bookmark", 0xf02e},
            {"fa-print", 0xf02f},
            {"fa-camera", 0xf030},
            {"fa-font", 0xf031},
            {"fa-bold", 0xf032},
            {"fa-italic", 0xf033},
            {"fa-text-height", 0xf034},
            {"fa-text-width", 0xf035},
            {"fa-align-left", 0xf036},
            {"fa-align-center", 0xf037},
            {"fa-align-right", 0xf038},
            {"fa-align-justify", 0xf039},
            {"fa-list", 0xf03a},
            {"fa-outdent", 0xf03b},
            {"fa-dedent", 0xf03b},
            {"fa-indent", 0xf03c},
            {"fa-video-camera", 0xf03d},
            {"fa-picture-o", 0xf03e},
            {"fa-photo", 0xf03e},
            {"fa-image", 0xf03e},
            {"fa-pencil", 0xf040},
            {"fa-map-marker", 0xf041},
            {"fa-adjust", 0xf042},
            {"fa-tint", 0xf043},
            {"fa-pencil-square-o", 0xf044},
            {"fa-edit", 0xf044},
            {"fa-share-square-o", 0xf045},
            {"fa-check-square-o", 0xf046},
            {"fa-arrows", 0xf047},
            {"fa-step-backward", 0xf048},
            {"fa-fast-backward", 0xf049},
            {"fa-backward", 0xf04a},
            {"fa-play", 0xf04b},
            {"fa-pause", 0xf04c},
            {"fa-stop", 0xf04d},
            {"fa-forward", 0xf04e},
            {"fa-fast-forward", 0xf050},
            {"fa-step-forward", 0xf051},
            {"fa-eject", 0xf052},
            {"fa-chevron-left", 0xf053},
            {"fa-chevron-right", 0xf054},
            {"fa-plus-circle", 0xf055},
            {"fa-minus-circle", 0xf056},
            {"fa-times-circle", 0xf057},
            {"fa-check-circle", 0xf058},
            {"fa-question-circle", 0xf059},
            {"fa-info-circle", 0xf05a},
            {"fa-crosshairs", 0xf05b},
            {"fa-times-circle-o", 0xf05c},
            {"fa-check-circle-o", 0xf05d},
            {"fa-ban", 0xf05e},
            {"fa-arrow-left", 0xf060},
            {"fa-arrow-right", 0xf061},
            {"fa-arrow-up", 0xf062},
            {"fa-arrow-down", 0xf063},
            {"fa-share", 0xf064},
            {"fa-mail-forward", 0xf064},
            {"fa-expand", 0xf065},
            {"fa-compress", 0xf066},
            {"fa-plus", 0xf067},
            {"fa-minus", 0xf068},
            {"fa-asterisk", 0xf069},
            {"fa-exclamation-circle", 0xf06a},
            {"fa-gift", 0xf06b},
            {"fa-leaf", 0xf06c},
            {"fa-fire", 0xf06d},
            {"fa-eye", 0xf06e},
            {"fa-eye-slash", 0xf070},
            {"fa-exclamation-triangle", 0xf071},
            {"fa-warning", 0xf071},
            {"fa-plane", 0xf072},
            {"fa-calendar", 0xf073},
            {"fa-random", 0xf074},
            {"fa-comment", 0xf075},
            {"fa-magnet", 0xf076},
            {"fa-chevron-up", 0xf077},
            {"fa-chevron-down", 0xf078},
            {"fa-retweet", 0xf079},
            {"fa-shopping-cart", 0xf07a},
            {"fa-folder", 0xf07b},
            {"fa-folder-open", 0xf07c},
            {"fa-arrows-v", 0xf07d},
            {"fa-arrows-h", 0xf07e},
            {"fa-bar-chart", 0xf080},
            {"fa-bar-chart-o", 0xf080},
            {"fa-twitter-square", 0xf081},
            {"fa-facebook-square", 0xf082},
            {"fa-camera-retro", 0xf083},
            {"fa-key", 0xf084},
            {"fa-cogs", 0xf085},
            {"fa-gears", 0xf085},
            {"fa-comments", 0xf086},
            {"fa-thumbs-o-up", 0xf087},
            {"fa-thumbs-o-down", 0xf088},
            {"fa-star-half", 0xf089},
            {"fa-heart-o", 0xf08a},
            {"fa-sign-out", 0xf08b},
            {"fa-linkedin-square", 0xf08c},
            {"fa-thumb-tack", 0xf08d},
            {"fa-external-link", 0xf08e},
            {"fa-sign-in", 0xf090},
            {"fa-trophy", 0xf091},
            {"fa-github-square", 0xf092},
            {"fa-upload", 0xf093},
            {"fa-lemon-o", 0xf094},
            {"fa-phone", 0xf095},
            {"fa-square-o", 0xf096},
            {"fa-bookmark-o", 0xf097},
            {"fa-phone-square", 0xf098},
            {"fa-twitter", 0xf099},
            {"fa-facebook", 0xf09a},
            {"fa-facebook-f", 0xf09a},
            {"fa-github", 0xf09b},
            {"fa-unlock", 0xf09c},
            {"fa-credit-card", 0xf09d},
            {"fa-rss", 0xf09e},
            {"fa-feed", 0xf09e},
            {"fa-hdd-o", 0xf0a0},
            {"fa-bullhorn", 0xf0a1},
            {"fa-bell", 0xf0f3},
            {"fa-certificate", 0xf0a3},
            {"fa-hand-o-right", 0xf0a4},
            {"fa-hand-o-left", 0xf0a5},
            {"fa-hand-o-up", 0xf0a6},
            {"fa-hand-o-down", 0xf0a7},
            {"fa-arrow-circle-left", 0xf0a8},
            {"fa-arrow-circle-right", 0xf0a9},
            {"fa-arrow-circle-up", 0xf0aa},
            {"fa-arrow-circle-down", 0xf0ab},
            {"fa-globe", 0xf0ac},
            {"fa-wrench", 0xf0ad},
            {"fa-tasks", 0xf0ae},
            {"fa-filter", 0xf0b0},
            {"fa-briefcase", 0xf0b1},
            {"fa-arrows-alt", 0xf0b2},
            {"fa-users", 0xf0c0},
            {"fa-group", 0xf0c0},
            {"fa-link", 0xf0c1},
            {"fa-chain", 0xf0c1},
            {"fa-cloud", 0xf0c2},
            {"fa-flask", 0xf0c3},
            {"fa-scissors", 0xf0c4},
            {"fa-cut", 0xf0c4},
            {"fa-files-o", 0xf0c5},
            {"fa-copy", 0xf0c5},
            {"fa-paperclip", 0xf0c6},
            {"fa-floppy-o", 0xf0c7},
            {"fa-save", 0xf0c7},
            {"fa-square", 0xf0c8},
            {"fa-bars", 0xf0c9},
            {"fa-navicon", 0xf0c9},
            {"fa-reorder", 0xf0c9},
            {"fa-list-ul", 0xf0ca},
            {"fa-list-ol", 0xf0cb},
            {"fa-strikethrough", 0xf0cc},
            {"fa-underline", 0xf0cd},
            {"fa-table", 0xf0ce},
            {"fa-magic", 0xf0d0},
            {"fa-truck", 0xf0d1},
            {"fa-pinterest", 0xf0d2},
            {"fa-pinterest-square", 0xf0d3},
            {"fa-google-plus-square", 0xf0d4},
            {"fa-google-plus", 0xf0d5},
            {"fa-money", 0xf0d6},
            {"fa-caret-down", 0xf0d7},
            {"fa-caret-up", 0xf0d8},
            {"fa-caret-left", 0xf0d9},
            {"fa-caret-right", 0xf0da},
            {"fa-columns", 0xf0db},
            {"fa-sort", 0xf0dc},
            {"fa-unsorted", 0xf0dc},
            {"fa-sort-desc", 0xf0dd},
            {"fa-sort-down", 0xf0dd},
            {"fa-sort-asc", 0xf0de},
            {"fa-sort-up", 0xf0de},
            {"fa-envelope", 0xf0e0},
            {"fa-linkedin", 0xf0e1},
            {"fa-undo", 0xf0e2},
            {"fa-rotate-left", 0xf0e2},
            {"fa-gavel", 0xf0e3},
            {"fa-legal", 0xf0e3},
            {"fa-tachometer", 0xf0e4},
            {"fa-dashboard", 0xf0e4},
            {"fa-comment-o", 0xf0e5},
            {"fa-comments-o", 0xf0e6},
            {"fa-bolt", 0xf0e7},
            {"fa-flash", 0xf0e7},
            {"fa-sitemap", 0xf0e8},
            {"fa-umbrella", 0xf0e9},
            {"fa-clipboard", 0xf0ea},
            {"fa-paste", 0xf0ea},
            {"fa-lightbulb-o", 0xf0eb},
            {"fa-exchange", 0xf0ec},
            {"fa-cloud-download", 0xf0ed},
            {"fa-cloud-upload", 0xf0ee},
            {"fa-user-md", 0xf0f0},
            {"fa-stethoscope", 0xf0f1},
            {"fa-suitcase", 0xf0f2},
            {"fa-bell-o", 0xf0a2},
            {"fa-coffee", 0xf0f4},
            {"fa-cutlery", 0xf0f5},
            {"fa-file-text-o", 0xf0f6},
            {"fa-building-o", 0xf0f7},
            {"fa-hospital-o", 0xf0f8},
            {"fa-ambulance", 0xf0f9},
            {"fa-medkit", 0xf0fa},
            {"fa-fighter-jet", 0xf0fb},
            {"fa-beer", 0xf0fc},
            {"fa-h-square", 0xf0fd},
            {"fa-plus-square", 0xf0fe},
            {"fa-angle-double-left", 0xf100},
            {"fa-angle-double-right", 0xf101},
            {"fa-angle-double-up", 0xf102},
            {"fa-angle-double-down", 0xf103},
            {"fa-angle-left", 0xf104},
            {"fa-angle-right", 0xf105},
            {"fa-angle-up", 0xf106},
            {"fa-angle-down", 0xf107},
            {"fa-desktop", 0xf108},
            {"fa-laptop", 0xf109},
            {"fa-tablet", 0xf10a},
            {"fa-mobile", 0xf10b},
            {"fa-mobile-phone", 0xf10b},
            {"fa-circle-o", 0xf10c},
            {"fa-quote-left", 0xf10d},
            {"fa-quote-right", 0xf10e},
            {"fa-spinner", 0xf110},
            {"fa-circle", 0xf111},
            {"fa-reply", 0xf112},
            {"fa-mail-reply", 0xf112},
            {"fa-github-alt", 0xf113},
            {"fa-folder-o", 0xf114},
            {"fa-folder-open-o", 0xf115},
            {"fa-smile-o", 0xf118},
            {"fa-frown-o", 0xf119},
            {"fa-meh-o", 0xf11a},
            {"fa-gamepad", 0xf11b},
            {"fa-keyboard-o", 0xf11c},
            {"fa-flag-o", 0xf11d},
            {"fa-flag-checkered", 0xf11e},
            {"fa-terminal", 0xf120},
            {"fa-code", 0xf121},
            {"fa-reply-all", 0xf122},
            {"fa-mail-reply-all", 0xf122},
            {"fa-star-half-o", 0xf123},
            {"fa-star-half-empty", 0xf123},
            {"fa-star-half-full", 0xf123},
            {"fa-location-arrow", 0xf124},
            {"fa-crop", 0xf125},
            {"fa-code-fork", 0xf126},
            {"fa-chain-broken", 0xf127},
            {"fa-unlink", 0xf127},
            {"fa-question", 0xf128},
            {"fa-info", 0xf129},
            {"fa-exclamation", 0xf12a},
            {"fa-superscript", 0xf12b},
            {"fa-subscript", 0xf12c},
            {"fa-eraser", 0xf12d},
            {"fa-puzzle-piece", 0xf12e},
            {"fa-microphone", 0xf130},
            {"fa-microphone-slash", 0xf131},
            {"fa-shield", 0xf132},
            {"fa-calendar-o", 0xf133},
            {"fa-fire-extinguisher", 0xf134},
            {"fa-rocket", 0xf135},
            {"fa-maxcdn", 0xf136},
            {"fa-chevron-circle-left", 0xf137},
            {"fa-chevron-circle-right", 0xf138},
            {"fa-chevron-circle-up", 0xf139},
            {"fa-chevron-circle-down", 0xf13a},
            {"fa-html5", 0xf13b},
            {"fa-css3", 0xf13c},
            {"fa-anchor", 0xf13d},
            {"fa-unlock-alt", 0xf13e},
            {"fa-bullseye", 0xf140},
            {"fa-ellipsis-h", 0xf141},
            {"fa-ellipsis-v", 0xf142},
            {"fa-rss-square", 0xf143},
            {"fa-play-circle", 0xf144},
            {"fa-ticket", 0xf145},
            {"fa-minus-square", 0xf146},
            {"fa-minus-square-o", 0xf147},
            {"fa-level-up", 0xf148},
            {"fa-level-down", 0xf149},
            {"fa-check-square", 0xf14a},
            {"fa-pencil-square", 0xf14b},
            {"fa-external-link-square", 0xf14c},
            {"fa-share-square", 0xf14d},
            {"fa-compass", 0xf14e},
            {"fa-caret-square-o-down", 0xf150},
            {"fa-toggle-down", 0xf150},
            {"fa-caret-square-o-up", 0xf151},
            {"fa-toggle-up", 0xf151},
            {"fa-caret-square-o-right", 0xf152},
            {"fa-toggle-right", 0xf152},
            {"fa-eur", 0xf153},
            {"fa-euro", 0xf153},
            {"fa-gbp", 0xf154},
            {"fa-usd", 0xf155},
            {"fa-dollar", 0xf155},
            {"fa-inr", 0xf156},
            {"fa-rupee", 0xf156},
            {"fa-jpy", 0xf157},
            {"fa-cny", 0xf157},
            {"fa-rmb", 0xf157},
            {"fa-yen", 0xf157},
            {"fa-rub", 0xf158},
            {"fa-ruble", 0xf158},
            {"fa-rouble", 0xf158},
            {"fa-krw", 0xf159},
            {"fa-won", 0xf159},
            {"fa-btc", 0xf15a},
            {"fa-bitcoin", 0xf15a},
            {"fa-file", 0xf15b},
            {"fa-file-text", 0xf15c},
            {"fa-sort-alpha-asc", 0xf15d},
            {"fa-sort-alpha-desc", 0xf15e},
            {"fa-sort-amount-asc", 0xf160},
            {"fa-sort-amount-desc", 0xf161},
            {"fa-sort-numeric-asc", 0xf162},
            {"fa-sort-numeric-desc", 0xf163},
            {"fa-thumbs-up", 0xf164},
            {"fa-thumbs-down", 0xf165},
            {"fa-youtube-square", 0xf166},
            {"fa-youtube", 0xf167},
            {"fa-xing", 0xf168},
            {"fa-xing-square", 0xf169},
            {"fa-youtube-play", 0xf16a},
            {"fa-dropbox", 0xf16b},
            {"fa-stack-overflow", 0xf16c},
            {"fa-instagram", 0xf16d},
            {"fa-flickr", 0xf16e},
            {"fa-adn", 0xf170},
            {"fa-bitbucket", 0xf171},
            {"fa-bitbucket-square", 0xf172},
            {"fa-tumblr", 0xf173},
            {"fa-tumblr-square", 0xf174},
            {"fa-long-arrow-down", 0xf175},
            {"fa-long-arrow-up", 0xf176},
            {"fa-long-arrow-left", 0xf177},
            {"fa-long-arrow-right", 0xf178},
            {"fa-apple", 0xf179},
            {"fa-windows", 0xf17a},
            {"fa-android", 0xf17b},
            {"fa-linux", 0xf17c},
            {"fa-dribbble", 0xf17d},
            {"fa-skype", 0xf17e},
            {"fa-foursquare", 0xf180},
            {"fa-trello", 0xf181},
            {"fa-female", 0xf182},
            {"fa-male", 0xf183},
            {"fa-gratipay", 0xf184},
            {"fa-gittip", 0xf184},
            {"fa-sun-o", 0xf185},
            {"fa-moon-o", 0xf186},
            {"fa-archive", 0xf187},
            {"fa-bug", 0xf188},
            {"fa-vk", 0xf189},
            {"fa-weibo", 0xf18a},
            {"fa-renren", 0xf18b},
            {"fa-pagelines", 0xf18c},
            {"fa-stack-exchange", 0xf18d},
            {"fa-arrow-circle-o-right", 0xf18e},
            {"fa-arrow-circle-o-left", 0xf190},
            {"fa-caret-square-o-left", 0xf191},
            {"fa-toggle-left", 0xf191},
            {"fa-dot-circle-o", 0xf192},
            {"fa-wheelchair", 0xf193},
            {"fa-vimeo-square", 0xf194},
            {"fa-try", 0xf195},
            {"fa-turkish-lira", 0xf195},
            {"fa-plus-square-o", 0xf196},
            {"fa-space-shuttle", 0xf197},
            {"fa-slack", 0xf198},
            {"fa-envelope-square", 0xf199},
            {"fa-wordpress", 0xf19a},
            {"fa-openid", 0xf19b},
            {"fa-university", 0xf19c},
            {"fa-institution", 0xf19c},
            {"fa-bank", 0xf19c},
            {"fa-graduation-cap", 0xf19d},
            {"fa-mortar-board", 0xf19d},
            {"fa-yahoo", 0xf19e},
            {"fa-google", 0xf1a0},
            {"fa-reddit", 0xf1a1},
            {"fa-reddit-square", 0xf1a2},
            {"fa-stumbleupon-circle", 0xf1a3},
            {"fa-stumbleupon", 0xf1a4},
            {"fa-delicious", 0xf1a5},
            {"fa-digg", 0xf1a6},
            {"fa-pied-piper-pp", 0xf1a7},
            {"fa-pied-piper-alt", 0xf1a8},
            {"fa-drupal", 0xf1a9},
            {"fa-joomla", 0xf1aa},
            {"fa-language", 0xf1ab},
            {"fa-fax", 0xf1ac},
            {"fa-building", 0xf1ad},
            {"fa-child", 0xf1ae},
            {"fa-paw", 0xf1b0},
            {"fa-spoon", 0xf1b1},
            {"fa-cube", 0xf1b2},
            {"fa-cubes", 0xf1b3},
            {"fa-behance", 0xf1b4},
            {"fa-behance-square", 0xf1b5},
            {"fa-steam", 0xf1b6},
            {"fa-steam-square", 0xf1b7},
            {"fa-recycle", 0xf1b8},
            {"fa-car", 0xf1b9},
            {"fa-automobile", 0xf1b9},
            {"fa-taxi", 0xf1ba},
            {"fa-cab", 0xf1ba},
            {"fa-tree", 0xf1bb},
            {"fa-spotify", 0xf1bc},
            {"fa-deviantart", 0xf1bd},
            {"fa-soundcloud", 0xf1be},
            {"fa-database", 0xf1c0},
            {"fa-file-pdf-o", 0xf1c1},
            {"fa-file-word-o", 0xf1c2},
            {"fa-file-excel-o", 0xf1c3},
            {"fa-file-powerpoint-o", 0xf1c4},
            {"fa-file-image-o", 0xf1c5},
            {"fa-file-photo-o", 0xf1c5},
            {"fa-file-picture-o", 0xf1c5},
            {"fa-file-archive-o", 0xf1c6},
            {"fa-file-zip-o", 0xf1c6},
            {"fa-file-audio-o", 0xf1c7},
            {"fa-file-sound-o", 0xf1c7},
            {"fa-file-video-o", 0xf1c8},
            {"fa-file-movie-o", 0xf1c8},
            {"fa-file-code-o", 0xf1c9},
            {"fa-vine", 0xf1ca},
            {"fa-codepen", 0xf1cb},
            {"fa-jsfiddle", 0xf1cc},
            {"fa-life-ring", 0xf1cd},
            {"fa-life-bouy", 0xf1cd},
            {"fa-life-buoy", 0xf1cd},
            {"fa-life-saver", 0xf1cd},
            {"fa-support", 0xf1cd},
            {"fa-circle-o-notch", 0xf1ce},
            {"fa-rebel", 0xf1d0},
            {"fa-ra", 0xf1d0},
            {"fa-resistance", 0xf1d0},
            {"fa-empire", 0xf1d1},
            {"fa-ge", 0xf1d1},
            {"fa-git-square", 0xf1d2},
            {"fa-git", 0xf1d3},
            {"fa-hacker-news", 0xf1d4},
            {"fa-y-combinator-square", 0xf1d4},
            {"fa-yc-square", 0xf1d4},
            {"fa-tencent-weibo", 0xf1d5},
            {"fa-qq", 0xf1d6},
            {"fa-weixin", 0xf1d7},
            {"fa-wechat", 0xf1d7},
            {"fa-paper-plane", 0xf1d8},
            {"fa-send", 0xf1d8},
            {"fa-paper-plane-o", 0xf1d9},
            {"fa-send-o", 0xf1d9},
            {"fa-history", 0xf1da},
            {"fa-circle-thin", 0xf1db},
            {"fa-header", 0xf1dc},
            {"fa-paragraph", 0xf1dd},
            {"fa-sliders", 0xf1de},
            {"fa-share-alt", 0xf1e0},
            {"fa-share-alt-square", 0xf1e1},
            {"fa-bomb", 0xf1e2},
            {"fa-futbol-o", 0xf1e3},
            {"fa-soccer-ball-o", 0xf1e3},
            {"fa-tty", 0xf1e4},
            {"fa-binoculars", 0xf1e5},
            {"fa-plug", 0xf1e6},
            {"fa-slideshare", 0xf1e7},
            {"fa-twitch", 0xf1e8},
            {"fa-yelp", 0xf1e9},
            {"fa-newspaper-o", 0xf1ea},
            {"fa-wifi", 0xf1eb},
            {"fa-calculator", 0xf1ec},
            {"fa-paypal", 0xf1ed},
            {"fa-google-wallet", 0xf1ee},
            {"fa-cc-visa", 0xf1f0},
            {"fa-cc-mastercard", 0xf1f1},
            {"fa-cc-discover", 0xf1f2},
            {"fa-cc-amex", 0xf1f3},
            {"fa-cc-paypal", 0xf1f4},
            {"fa-cc-stripe", 0xf1f5},
            {"fa-bell-slash", 0xf1f6},
            {"fa-bell-slash-o", 0xf1f7},
            {"fa-trash", 0xf1f8},
            {"fa-copyright", 0xf1f9},
            {"fa-at", 0xf1fa},
            {"fa-eyedropper", 0xf1fb},
            {"fa-paint-brush", 0xf1fc},
            {"fa-birthday-cake", 0xf1fd},
            {"fa-area-chart", 0xf1fe},
            {"fa-pie-chart", 0xf200},
            {"fa-line-chart", 0xf201},
            {"fa-lastfm", 0xf202},
            {"fa-lastfm-square", 0xf203},
            {"fa-toggle-off", 0xf204},
            {"fa-toggle-on", 0xf205},
            {"fa-bicycle", 0xf206},
            {"fa-bus", 0xf207},
            {"fa-ioxhost", 0xf208},
            {"fa-angellist", 0xf209},
            {"fa-cc", 0xf20a},
            {"fa-ils", 0xf20b},
            {"fa-shekel", 0xf20b},
            {"fa-sheqel", 0xf20b},
            {"fa-meanpath", 0xf20c},
            {"fa-buysellads", 0xf20d},
            {"fa-connectdevelop", 0xf20e},
            {"fa-dashcube", 0xf210},
            {"fa-forumbee", 0xf211},
            {"fa-leanpub", 0xf212},
            {"fa-sellsy", 0xf213},
            {"fa-shirtsinbulk", 0xf214},
            {"fa-simplybuilt", 0xf215},
            {"fa-skyatlas", 0xf216},
            {"fa-cart-plus", 0xf217},
            {"fa-cart-arrow-down", 0xf218},
            {"fa-diamond", 0xf219},
            {"fa-ship", 0xf21a},
            {"fa-user-secret", 0xf21b},
            {"fa-motorcycle", 0xf21c},
            {"fa-street-view", 0xf21d},
            {"fa-heartbeat", 0xf21e},
            {"fa-venus", 0xf221},
            {"fa-mars", 0xf222},
            {"fa-mercury", 0xf223},
            {"fa-transgender", 0xf224},
            {"fa-intersex", 0xf224},
            {"fa-transgender-alt", 0xf225},
            {"fa-venus-double", 0xf226},
            {"fa-mars-double", 0xf227},
            {"fa-venus-mars", 0xf228},
            {"fa-mars-stroke", 0xf229},
            {"fa-mars-stroke-v", 0xf22a},
            {"fa-mars-stroke-h", 0xf22b},
            {"fa-neuter", 0xf22c},
            {"fa-genderless", 0xf22d},
            {"fa-facebook-official", 0xf230},
            {"fa-pinterest-p", 0xf231},
            {"fa-whatsapp", 0xf232},
            {"fa-server", 0xf233},
            {"fa-user-plus", 0xf234},
            {"fa-user-times", 0xf235},
            {"fa-bed", 0xf236},
            {"fa-hotel", 0xf236},
            {"fa-viacoin", 0xf237},
            {"fa-train", 0xf238},
            {"fa-subway", 0xf239},
            {"fa-medium", 0xf23a},
            {"fa-y-combinator", 0xf23b},
            {"fa-yc", 0xf23b},
            {"fa-optin-monster", 0xf23c},
            {"fa-opencart", 0xf23d},
            {"fa-expeditedssl", 0xf23e},
            {"fa-battery-full", 0xf240},
            {"fa-battery-4", 0xf240},
            {"fa-battery", 0xf240},
            {"fa-battery-three-quarters", 0xf241},
            {"fa-battery-3", 0xf241},
            {"fa-battery-half", 0xf242},
            {"fa-battery-2", 0xf242},
            {"fa-battery-quarter", 0xf243},
            {"fa-battery-1", 0xf243},
            {"fa-battery-empty", 0xf244},
            {"fa-battery-0", 0xf244},
            {"fa-mouse-pointer", 0xf245},
            {"fa-i-cursor", 0xf246},
            {"fa-object-group", 0xf247},
            {"fa-object-ungroup", 0xf248},
            {"fa-sticky-note", 0xf249},
            {"fa-sticky-note-o", 0xf24a},
            {"fa-cc-jcb", 0xf24b},
            {"fa-cc-diners-club", 0xf24c},
            {"fa-clone", 0xf24d},
            {"fa-balance-scale", 0xf24e},
            {"fa-hourglass-o", 0xf250},
            {"fa-hourglass-start", 0xf251},
            {"fa-hourglass-1", 0xf251},
            {"fa-hourglass-half", 0xf252},
            {"fa-hourglass-2", 0xf252},
            {"fa-hourglass-end", 0xf253},
            {"fa-hourglass-3", 0xf253},
            {"fa-hourglass", 0xf254},
            {"fa-hand-rock-o", 0xf255},
            {"fa-hand-grab-o", 0xf255},
            {"fa-hand-paper-o", 0xf256},
            {"fa-hand-stop-o", 0xf256},
            {"fa-hand-scissors-o", 0xf257},
            {"fa-hand-lizard-o", 0xf258},
            {"fa-hand-spock-o", 0xf259},
            {"fa-hand-pointer-o", 0xf25a},
            {"fa-hand-peace-o", 0xf25b},
            {"fa-trademark", 0xf25c},
            {"fa-registered", 0xf25d},
            {"fa-creative-commons", 0xf25e},
            {"fa-gg", 0xf260},
            {"fa-gg-circle", 0xf261},
            {"fa-tripadvisor", 0xf262},
            {"fa-odnoklassniki", 0xf263},
            {"fa-odnoklassniki-square", 0xf264},
            {"fa-get-pocket", 0xf265},
            {"fa-wikipedia-w", 0xf266},
            {"fa-safari", 0xf267},
            {"fa-chrome", 0xf268},
            {"fa-firefox", 0xf269},
            {"fa-opera", 0xf26a},
            {"fa-internet-explorer", 0xf26b},
            {"fa-television", 0xf26c},
            {"fa-tv", 0xf26c},
            {"fa-contao", 0xf26d},
            {"fa-500px", 0xf26e},
            {"fa-amazon", 0xf270},
            {"fa-calendar-plus-o", 0xf271},
            {"fa-calendar-minus-o", 0xf272},
            {"fa-calendar-times-o", 0xf273},
            {"fa-calendar-check-o", 0xf274},
            {"fa-industry", 0xf275},
            {"fa-map-pin", 0xf276},
            {"fa-map-signs", 0xf277},
            {"fa-map-o", 0xf278},
            {"fa-map", 0xf279},
            {"fa-commenting", 0xf27a},
            {"fa-commenting-o", 0xf27b},
            {"fa-houzz", 0xf27c},
            {"fa-vimeo", 0xf27d},
            {"fa-black-tie", 0xf27e},
            {"fa-fonticons", 0xf280},
            {"fa-reddit-alien", 0xf281},
            {"fa-edge", 0xf282},
            {"fa-credit-card-alt", 0xf283},
            {"fa-codiepie", 0xf284},
            {"fa-modx", 0xf285},
            {"fa-fort-awesome", 0xf286},
            {"fa-usb", 0xf287},
            {"fa-product-hunt", 0xf288},
            {"fa-mixcloud", 0xf289},
            {"fa-scribd", 0xf28a},
            {"fa-pause-circle", 0xf28b},
            {"fa-pause-circle-o", 0xf28c},
            {"fa-stop-circle", 0xf28d},
            {"fa-stop-circle-o", 0xf28e},
            {"fa-shopping-bag", 0xf290},
            {"fa-shopping-basket", 0xf291},
            {"fa-hashtag", 0xf292},
            {"fa-bluetooth", 0xf293},
            {"fa-bluetooth-b", 0xf294},
            {"fa-percent", 0xf295},
            {"fa-gitlab", 0xf296},
            {"fa-wpbeginner", 0xf297},
            {"fa-wpforms", 0xf298},
            {"fa-envira", 0xf299},
            {"fa-universal-access", 0xf29a},
            {"fa-wheelchair-alt", 0xf29b},
            {"fa-question-circle-o", 0xf29c},
            {"fa-blind", 0xf29d},
            {"fa-audio-description", 0xf29e},
            {"fa-volume-control-phone", 0xf2a0},
            {"fa-braille", 0xf2a1},
            {"fa-assistive-listening-systems", 0xf2a2},
            {"fa-american-sign-language-interpreting", 0xf2a3},
            {"fa-asl-interpreting", 0xf2a3},
            {"fa-deaf", 0xf2a4},
            {"fa-deafness", 0xf2a4},
            {"fa-hard-of-hearing", 0xf2a4},
            {"fa-glide", 0xf2a5},
            {"fa-glide-g", 0xf2a6},
            {"fa-sign-language", 0xf2a7},
            {"fa-signing", 0xf2a7},
            {"fa-low-vision", 0xf2a8},
            {"fa-viadeo", 0xf2a9},
            {"fa-viadeo-square", 0xf2aa},
            {"fa-snapchat", 0xf2ab},
            {"fa-snapchat-ghost", 0xf2ac},
            {"fa-snapchat-square", 0xf2ad},
            {"fa-pied-piper", 0xf2ae},
            {"fa-first-order", 0xf2b0},
            {"fa-yoast", 0xf2b1},
            {"fa-themeisle", 0xf2b2},
            {"fa-google-plus-official", 0xf2b3},
            {"fa-google-plus-circle", 0xf2b3},
            {"fa-font-awesome", 0xf2b4},
            {"fa-fa", 0xf2b4},
            {"fa-handshake-o", 0xf2b5},
            {"fa-envelope-open", 0xf2b6},
            {"fa-envelope-open-o", 0xf2b7},
            {"fa-linode", 0xf2b8},
            {"fa-address-book", 0xf2b9},
            {"fa-address-book-o", 0xf2ba},
            {"fa-address-card", 0xf2bb},
            {"fa-vcard", 0xf2bb},
            {"fa-address-card-o", 0xf2bc},
            {"fa-vcard-o", 0xf2bc},
            {"fa-user-circle", 0xf2bd},
            {"fa-user-circle-o", 0xf2be},
            {"fa-user-o", 0xf2c0},
            {"fa-id-badge", 0xf2c1},
            {"fa-id-card", 0xf2c2},
            {"fa-drivers-license", 0xf2c2},
            {"fa-id-card-o", 0xf2c3},
            {"fa-drivers-license-o", 0xf2c3},
            {"fa-quora", 0xf2c4},
            {"fa-free-code-camp", 0xf2c5},
            {"fa-telegram", 0xf2c6},
            {"fa-thermometer-full", 0xf2c7},
            {"fa-thermometer-4", 0xf2c7},
            {"fa-thermometer", 0xf2c7},
            {"fa-thermometer-three-quarters", 0xf2c8},
            {"fa-thermometer-3", 0xf2c8},
            {"fa-thermometer-half", 0xf2c9},
            {"fa-thermometer-2", 0xf2c9},
            {"fa-thermometer-quarter", 0xf2ca},
            {"fa-thermometer-1", 0xf2ca},
            {"fa-thermometer-empty", 0xf2cb},
            {"fa-thermometer-0", 0xf2cb},
            {"fa-shower", 0xf2cc},
            {"fa-bath", 0xf2cd},
            {"fa-bathtub", 0xf2cd},
            {"fa-s15", 0xf2cd},
            {"fa-podcast", 0xf2ce},
            {"fa-window-maximize", 0xf2d0},
            {"fa-window-minimize", 0xf2d1},
            {"fa-window-restore", 0xf2d2},
            {"fa-window-close", 0xf2d3},
            {"fa-times-rectangle", 0xf2d3},
            {"fa-window-close-o", 0xf2d4},
            {"fa-times-rectangle-o", 0xf2d4},
            {"fa-bandcamp", 0xf2d5},
            {"fa-grav", 0xf2d6},
            {"fa-etsy", 0xf2d7},
            {"fa-imdb", 0xf2d8},
            {"fa-ravelry", 0xf2d9},
            {"fa-eercast", 0xf2da},
            {"fa-microchip", 0xf2db},
            {"fa-snowflake-o", 0xf2dc},
            {"fa-superpowers", 0xf2dd},
            {"fa-wpexplorer", 0xf2de},
            {"fa-meetup", 0xf2e0}
        };

        #endregion
    }
}

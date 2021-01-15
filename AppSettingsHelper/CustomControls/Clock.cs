namespace AppSettingsHelper.CustomControls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    using System.Windows.Forms;

    public class Clock : UserControl
    {
        private StringFormat sf = null;
        private Timer time1s = null;
        private Brush foreBrush = new SolidBrush(Color.Chocolate);
        private Color clockBackColor = Color.White;
        private Brush brushClockBack = new SolidBrush(Color.White);
        private Color hourColor = Color.Chocolate;
        private Pen penHour = new Pen(Color.Chocolate, 2f);
        private Color minuteColor = Color.Coral;
        private Pen penMinute = new Pen(Color.Coral, 2f);
        private Color secondColor = Color.Green;
        private Pen penSecond = new Pen(Color.Green, 2f);
        private bool isSecondStep = false;
        private float needleWidth = 2f;
        private int secondCurrent = -1;
        private IContainer components = null;

        public Clock()
        {
            this.InitializeComponent();
            this.sf = new StringFormat();
            this.sf.Alignment = StringAlignment.Center;
            this.sf.LineAlignment = StringAlignment.Center;
            base.SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.ResizeRedraw, true);
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.time1s = new Timer();
            this.time1s.Interval = 50;
            this.time1s.Tick += new EventHandler(this.Time1s_Tick);
            this.BackgroundImageLayout = ImageLayout.None;
            this.ForeColor = Color.Chocolate;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private Bitmap getBackGround()
        {
            int width = Math.Min(base.Width, base.Height);
            Bitmap image = new Bitmap(width, width);
            Graphics graphics = Graphics.FromImage(image);
            Pen pen = new Pen(Color.Chocolate, 2f);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            int num2 = 10;
            graphics.TranslateTransform(((float)image.Width) / 2f, ((float)image.Height) / 2f);
            float num3 = ((float)(image.Width - (num2 * 2))) / 2f;
            graphics.FillEllipse(Brushes.DarkGray, new RectangleF(-num3, -num3, 2f * num3, 2f * num3));
            graphics.FillEllipse(this.brushClockBack, new RectangleF(-num3 + 2f, -num3 + 2f, (2f * num3) - 4f, (2f * num3) - 4f));
            graphics.DrawEllipse(Pens.Black, new RectangleF(-4f, -4f, 8f, 8f));
            for (int i = 0; i < 60; i++)
            {
                graphics.RotateTransform(6f);
                graphics.DrawLine(Pens.DarkGray, new PointF(num3 - 3f, 0f), new PointF(num3 - 1f, 0f));
            }
            for (int j = 0; j < 12; j++)
            {
                graphics.RotateTransform(30f);
                graphics.DrawLine(pen, new PointF(num3 - 6f, 0f), new PointF(num3 - 1f, 0f));
            }
            for (int k = 0; k < 12; k++)
            {
                float num7 = (float)(((num3 - 5f) - ((width > 100) ? ((float)this.Font.Height) : 7f)) * Math.Cos(((((double)((30 * k) - 60)) / 360.0) * 2.0) * 3.1415926535897931));
                float num8 = (float)(((num3 - 5f) - ((width > 100) ? ((float)this.Font.Height) : 7f)) * Math.Sin(((((double)((30 * k) - 60)) / 360.0) * 2.0) * 3.1415926535897931));
                RectangleF layoutRectangle = new RectangleF(num7 - 30f, num8 - (this.Font.Height / 2), 60f, (float)this.Font.Height);
                graphics.DrawString((k + 1).ToString(), this.Font, this.foreBrush, layoutRectangle, this.sf);
            }
            pen.Dispose();
            graphics.ResetTransform();
            graphics.Dispose();
            return image;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Clock
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Name = "Clock";
            this.Size = new System.Drawing.Size(182, 179);
            this.ResumeLayout(false);

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.BackgroundImage = this.getBackGround();
            this.time1s.Start();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            DateTime now = DateTime.Now;
            int num = 10;
            int num2 = Math.Min(base.Width, base.Height);
            float num3 = ((float)(num2 - (num * 2))) / 2f;
            float num4 = now.Hour + (((float)now.Minute) / 60f);
            float num5 = now.Minute + (((float)now.Second) / 60f);
            float second = now.Second + (((float)now.Millisecond) / 1000f);
            if (this.isSecondStep)
            {
                second = now.Second;
            }
            float angle = (num4 * 30f) + 270f;
            float num8 = (num5 * 6f) + 270f;
            float num9 = (second * 6f) + 270f;
            graphics.TranslateTransform((float)(num2 / 2), (float)(num2 / 2));
            if (num2 > 130)
            {
                graphics.DrawString(now.DayOfWeek.ToString(), this.Font, this.foreBrush, new RectangleF(-100f, num3 / 4f, 200f, (float)this.Font.Height), this.sf);
            }
            graphics.DrawString(this.Text, this.Font, this.foreBrush, new RectangleF(-100f, -num3 / 3f, 200f, (float)this.Font.Height), this.sf);
            if (num2 > 180)
            {
                RectangleF rect = new RectangleF((num3 / 2f) - 30f, (float)((-this.Font.Height / 2) - 2), 40f, (float)(this.Font.Height + 4));
                graphics.FillRectangle(Brushes.LimeGreen, rect);
                graphics.DrawString(now.Day.ToString(), this.Font, Brushes.White, rect, this.sf);
            }
            graphics.RotateTransform(angle, MatrixOrder.Prepend);
            graphics.DrawLine(this.penHour, new Point(4, 0), new Point(9, 0));
            PointF[] points = new PointF[] { new PointF(12f, 2f), new PointF(10f, 0f), new PointF(12f, -2f), new PointF(num3 / 2f, -2f), new PointF((num3 / 2f) + 6f, 0f), new PointF(num3 / 2f, 2f) };
            graphics.DrawClosedCurve(this.penHour, points);
            graphics.RotateTransform(-angle);
            graphics.RotateTransform(num8, MatrixOrder.Prepend);
            graphics.DrawLine(this.penMinute, new Point(4, 0), new Point(9, 0));
            PointF[] tfArray2 = new PointF[] { new PointF(14f, 2f), new PointF(10f, 0f), new PointF(14f, -2f), new PointF(num3 - 17f, -2f), new PointF(num3 - 10f, 0f), new PointF(num3 - 17f, 2f) };
            graphics.DrawClosedCurve(this.penMinute, tfArray2);
            graphics.RotateTransform(-num8);
            graphics.RotateTransform(num9, MatrixOrder.Prepend);
            graphics.DrawLine(this.penSecond, new PointF(-13f, 0f), new PointF(num3 - 6f, 0f));
            graphics.ResetTransform();
            base.OnPaint(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            this.BackgroundImage = this.getBackGround();
            base.OnSizeChanged(e);
        }

        private void Time1s_Tick(object sender, EventArgs e)
        {
            if (this.isSecondStep)
            {
                if (DateTime.Now.Second != this.secondCurrent)
                {
                    this.secondCurrent = DateTime.Now.Second;
                    base.Invalidate();
                }
            }
            else
            {
                base.Invalidate();
            }
        }

        [Browsable(true), Description("获取或设置控件的背景色"), Category("Appearance"), DefaultValue(typeof(Color), "Transparent"), EditorBrowsable(EditorBrowsableState.Always)]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
            }
        }

        [Browsable(true), Category("Appearance"), Description("获取或设置控件的字体信息")]
        public override System.Drawing.Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                this.BackgroundImage = this.getBackGround();
            }
        }

        [Browsable(true), Category("Appearance"), DefaultValue(0), Description("用于组件的背景图像布局")]
        public override ImageLayout BackgroundImageLayout
        {
            get
            {
                return base.BackgroundImageLayout;
            }
            set
            {
                base.BackgroundImageLayout = value;
            }
        }

        [Browsable(true), Category("Appearance"), Description("获取或设置时钟指针的颜色"), DefaultValue(typeof(Color), "Chocolate")]
        public Color HourColor
        {
            get
            {
                return this.hourColor;
            }
            set
            {
                this.hourColor = value;
                this.penHour.Dispose();
                this.penHour = new Pen(this.hourColor, this.needleWidth);
                base.Invalidate();
            }
        }

        [Browsable(true), Category("Appearance"), Description("获取或设置分钟指针的颜色"), DefaultValue(typeof(Color), "Coral")]
        public Color MinuteColor
        {
            get
            {
                return this.minuteColor;
            }
            set
            {
                this.minuteColor = value;
                this.penMinute.Dispose();
                this.penMinute = new Pen(this.minuteColor, this.needleWidth);
                base.Invalidate();
            }
        }

        [Browsable(true), Category("Appearance"), Description("获取或设置秒钟指针的颜色"), DefaultValue(typeof(Color), "Green")]
        public Color SecondColor
        {
            get
            {
                return this.secondColor;
            }
            set
            {
                this.secondColor = value;
                this.penSecond.Dispose();
                this.penSecond = new Pen(this.secondColor, this.needleWidth);
                base.Invalidate();
            }
        }

        [Browsable(true), Description("获取或设置当前控件的文本"), Category("Appearance"), EditorBrowsable(EditorBrowsableState.Always), Bindable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                base.Invalidate();
            }
        }

        [Browsable(true), Description("获取或设置秒针是否按照每秒前进还是连续变化"), Category("Appearance"), DefaultValue(false)]
        public bool IsSecondStep
        {
            get
            {
                return this.isSecondStep;
            }
            set
            {
                this.isSecondStep = value;
            }
        }

        [Browsable(true), Description("获取或设置时钟的背景颜色"), Category("Appearance"), DefaultValue(typeof(Color), "White")]
        public Color ClockBackColor
        {
            get
            {
                return this.clockBackColor;
            }
            set
            {
                this.clockBackColor = value;
                this.brushClockBack.Dispose();
                this.brushClockBack = new SolidBrush(value);
                this.BackgroundImage = this.getBackGround();
            }
        }

        [Browsable(true), Description("获取或设置文本的颜色"), Category("Appearance"), DefaultValue(typeof(Color), "Chocolate")]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                this.foreBrush.Dispose();
                this.foreBrush = new SolidBrush(value);
                this.BackgroundImage = this.getBackGround();
            }
        }
    }
}


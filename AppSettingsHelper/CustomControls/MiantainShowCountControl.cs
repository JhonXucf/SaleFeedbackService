namespace AppSettingsHelper
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    public partial class MiantainShowCountControl : UserControl
    {
        [CompilerGenerated, DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private Color textForeColor = Color.Black;
        private Brush textForeBrush = new SolidBrush(Color.Black); 
        private Color backColor = Color.SkyBlue;
        private Color pisindextextForeColor = Color.Green;
        private Color enablecolor = Color.FromArgb(190, 190, 190); 
        private bool borderVisiable = false;
        private Font pisIndexFont = new Font("宋体", 9f, FontStyle.Regular);
        private string labelText = "1";
        private string pis_index = string.Empty;
        private StringFormat sf = null;
        public MiantainShowCountControl()
        {
            InitializeComponent();
            this.sf = new StringFormat();
            this.sf.Alignment = StringAlignment.Center;
            this.sf.LineAlignment = StringAlignment.Center;
            base.SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.ResizeRedraw, true);
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(new RectangleF(0, 0, base.Width - 1, base.Height - 1));           
                Brush brush = null;
                Brush brush2 = null;
                Rectangle layoutRectangle = new Rectangle(base.ClientRectangle.X, base.ClientRectangle.Y + base.ClientRectangle.Height / 4, base.ClientRectangle.Width, base.ClientRectangle.Height / 3);
                Rectangle layoutPisTextRectangle = new Rectangle(base.ClientRectangle.X, base.ClientRectangle.Y + base.ClientRectangle.Height / 2, base.ClientRectangle.Width, base.ClientRectangle.Height / 3);
                if (base.Enabled)
                {
                    brush = new SolidBrush(this.ForeColor);
                    brush2 = new SolidBrush(this.backColor);
                }
                else
                {
                    brush = new SolidBrush(Color.Gray);
                    brush2 = new SolidBrush(this.EnableColor);
                }
                e.Graphics.FillPath(brush2, path);
                Pen pen = new Pen(Color.FromArgb(170, 170, 170));
                if (this.BorderVisiable)
                {
                    e.Graphics.DrawPath(pen, path);
                }
                //brush2 = new SolidBrush(this.BackColor);
                //e.Graphics.FillRectangle(brush2, this.ClientRectangle);
                e.Graphics.DrawString(this.labelText, this.Font, brush, layoutRectangle, this.sf);
                brush = new SolidBrush(pisindextextForeColor);
                e.Graphics.DrawString(this.Pis_Index, this.pisIndexFont, brush, layoutPisTextRectangle, this.sf);
                brush.Dispose();
                brush2.Dispose();
                pen.Dispose();
                path.Dispose();
                base.OnPaint(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
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
        [Browsable(true), Description("获取或设置圆形的背景色"), Category("Appearance"), DefaultValue(typeof(Color), "Transparent"), EditorBrowsable(EditorBrowsableState.Always)]
        public Color EclipsBackColor
        {
            get
            {
                return this.backColor;
            }
            set
            {
                this.backColor = value;
                this.Invalidate();
            }
        }
        [Browsable(true), Description("获取或设置当前控件的文本的颜色"), Category("Appearance"), DefaultValue(typeof(Color), "DimGray"), EditorBrowsable(EditorBrowsableState.Always)]
        public override Color ForeColor
        {
            get
            {
                return this.textForeColor;
            }
            set
            {
                this.textForeColor = value;
                this.textForeBrush.Dispose();
                this.textForeBrush = new SolidBrush(value);
                base.Invalidate();
            }
        }

        [Browsable(true), Description("获取或设置当前控件的文本"), Category("Appearance"), EditorBrowsable(EditorBrowsableState.Always), Bindable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string LabelText
        {
            get
            {
                return labelText;
            }
            set
            {
                labelText = value;
                base.Invalidate();
            }
        }
        [Browsable(true), Description("获取或设置Pisindex的文本"), Category("Appearance"), EditorBrowsable(EditorBrowsableState.Always), Bindable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Pis_Index
        {
            get
            {
                return pis_index;
            }
            set
            {
                pis_index = value;
                base.Invalidate();
            }
        }
        [Browsable(true), Description("获取或设置Pisindex的文本的颜色"), Category("Appearance"), DefaultValue(typeof(Color), "DimGray"), EditorBrowsable(EditorBrowsableState.Always)]
        public Color PisindexForeColor
        {
            get
            {
                return this.pisindextextForeColor;
            }
            set
            {
                this.pisindextextForeColor = value;
                base.Invalidate();
            }
        }
        [Category("Appearance"), DefaultValue(typeof(Color), "Lavender"), Description("控件背景色")]
        public Color OriginalColor
        {
            get
            {
                return this.backColor;
            }
            set
            {
                this.backColor = value;
                base.Invalidate();
            }
        }

        [Category("Appearance"), Description("活动色"), DefaultValue(typeof(Color), "0xBEBEBE")]
        public Color EnableColor
        {
            get
            {
                return this.enablecolor;
            }
            set
            {
                this.enablecolor = value;
                base.Invalidate();
            }
        }
        [Category("Appearance"), Browsable(true), DefaultValue(true), Description("指示是否存在边框")]
        public bool BorderVisiable
        {
            get
            {
                return this.borderVisiable;
            }
            set
            {
                this.borderVisiable = value;
                base.Invalidate();
            }
        }
        [Category("Appearance"), Browsable(true), DefaultValue(true), Description("PisIndex 字体大小")]
        public Font PisIndexFont
        {
            get
            {
                return this.pisIndexFont;
            }
            set
            {
                this.pisIndexFont = value;
                base.Invalidate();
            }
        }
    } 
}

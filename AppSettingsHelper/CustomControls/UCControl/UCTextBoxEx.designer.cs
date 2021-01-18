namespace AppSettingsHelper
{
    /// <summary>
    /// Class UCTextBoxEx.
    /// Implements the <see cref="AppSettingsHelper.UCControlBase" />
    /// </summary>
    /// <seealso cref="AppSettingsHelper.UCControlBase" />
    partial class UCTextBoxEx
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCTextBoxEx));
            this.txtInput = new AppSettingsHelper.TextBoxEx();
            this.btnClear = new System.Windows.Forms.Panel();
            this.btnKeybord = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInput.DecLength = 2;
            this.txtInput.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtInput.InputType = AppSettingsHelper.TextInputType.NotControl;
            this.txtInput.Location = new System.Drawing.Point(8, 9);
            this.txtInput.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.txtInput.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txtInput.MinValue = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.txtInput.MyRectangle = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtInput.Name = "txtInput";
            this.txtInput.OldText = null;
            this.txtInput.PromptColor = System.Drawing.Color.Gray;
            this.txtInput.PromptFont = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtInput.PromptText = "";
            this.txtInput.RegexPattern = "";
            this.txtInput.Size = new System.Drawing.Size(261, 24);
            this.txtInput.TabIndex = 0;
            this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            this.txtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInput_KeyDown);
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClear.BackgroundImage")));
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClear.Location = new System.Drawing.Point(179, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(30, 32);
            this.btnClear.TabIndex = 4;
            this.btnClear.Visible = false;
            this.btnClear.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnClear_MouseDown);
            // 
            // btnKeybord
            // 
            this.btnKeybord.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnKeybord.BackgroundImage")));
            this.btnKeybord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnKeybord.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnKeybord.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnKeybord.Location = new System.Drawing.Point(209, 5);
            this.btnKeybord.Name = "btnKeybord";
            this.btnKeybord.Size = new System.Drawing.Size(30, 32);
            this.btnKeybord.TabIndex = 6;
            this.btnKeybord.Visible = false;
            this.btnKeybord.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnKeybord_MouseDown);
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSearch.Location = new System.Drawing.Point(239, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(30, 32);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Visible = false;
            this.btnSearch.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSearch_MouseDown);
            // 
            // UCTextBoxEx
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.ConerRadius = 5;
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnKeybord);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtInput);
            this.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.IsRadius = true;
            this.IsShowRect = true;
            this.Name = "UCTextBoxEx";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(274, 42);
            this.Load += new System.EventHandler(this.UCTextBoxEx_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UCTextBoxEx_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        /// <summary>
        /// The text input
        /// </summary>
        public TextBoxEx txtInput;
        /// <summary>
        /// The BTN clear
        /// </summary>
        private System.Windows.Forms.Panel btnClear;
        /// <summary>
        /// The BTN search
        /// </summary>
        private System.Windows.Forms.Panel btnSearch;
        /// <summary>
        /// The BTN keybord
        /// </summary>
        private System.Windows.Forms.Panel btnKeybord;
    }
}

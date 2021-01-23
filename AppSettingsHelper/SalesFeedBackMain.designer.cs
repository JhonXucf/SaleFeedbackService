namespace AppSettingsHelper
{
    partial class SalesFeedBackMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesFeedBackMain));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpg_deviceManager = new System.Windows.Forms.TabPage();
            this.contextMenuDevice = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txt_serach = new AppSettingsHelper.UCTextBoxEx();
            this.lbl_medium = new System.Windows.Forms.Label();
            this.dtp_EndTime = new System.Windows.Forms.DateTimePicker();
            this.lbl_EndTime = new System.Windows.Forms.Label();
            this.lbl_StartTime = new System.Windows.Forms.Label();
            this.dtp_StartTime = new System.Windows.Forms.DateTimePicker();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage_Information = new System.Windows.Forms.TabPage();
            this.richTextBox_information = new System.Windows.Forms.RichTextBox();
            this.contextMenuLog = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空日志ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage_Warning = new System.Windows.Forms.TabPage();
            this.richTextBox_warning = new System.Windows.Forms.RichTextBox();
            this.tabPage_eroor = new System.Windows.Forms.TabPage();
            this.richTextBox_error = new System.Windows.Forms.RichTextBox();
            this.tabPage_Fatal = new System.Windows.Forms.TabPage();
            this.richTextBox_Fatal = new System.Windows.Forms.RichTextBox();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.lbMessage = new System.Windows.Forms.Label();
            this.lbServicestate = new System.Windows.Forms.Label();
            this.btnServiceUninstall = new System.Windows.Forms.Button();
            this.btnServiceStop = new System.Windows.Forms.Button();
            this.btnServiceStart = new System.Windows.Forms.Button();
            this.btnServiceInstall = new System.Windows.Forms.Button();
            this.pnl_header = new System.Windows.Forms.Panel();
            this.pnl_minimizeAndClose = new System.Windows.Forms.Panel();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_minimize = new System.Windows.Forms.Button();
            this.pnl_title = new System.Windows.Forms.Panel();
            this.lbl_title = new System.Windows.Forms.Label();
            this.pb_icon = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage_Information.SuspendLayout();
            this.contextMenuLog.SuspendLayout();
            this.tabPage_Warning.SuspendLayout();
            this.tabPage_eroor.SuspendLayout();
            this.tabPage_Fatal.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.pnl_header.SuspendLayout();
            this.pnl_minimizeAndClose.SuspendLayout();
            this.pnl_title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_icon)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpg_deviceManager);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage9);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControl1.ItemSize = new System.Drawing.Size(100, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 113);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1300, 655);
            this.tabControl1.TabIndex = 1;
            // 
            // tpg_deviceManager
            // 
            this.tpg_deviceManager.AutoScroll = true;
            this.tpg_deviceManager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(166)))), ((int)(((byte)(171)))));
            this.tpg_deviceManager.ContextMenuStrip = this.contextMenuDevice;
            this.tpg_deviceManager.Location = new System.Drawing.Point(4, 34);
            this.tpg_deviceManager.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tpg_deviceManager.Name = "tpg_deviceManager";
            this.tpg_deviceManager.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tpg_deviceManager.Size = new System.Drawing.Size(1292, 617);
            this.tpg_deviceManager.TabIndex = 0;
            this.tpg_deviceManager.Text = "设备管理";
            this.tpg_deviceManager.SizeChanged += new System.EventHandler(this.tpg_deviceManager_SizeChanged);
            // 
            // contextMenuDevice
            // 
            this.contextMenuDevice.Name = "contextMenuDevice";
            this.contextMenuDevice.Size = new System.Drawing.Size(61, 4);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(166)))), ((int)(((byte)(171)))));
            this.tabPage3.Controls.Add(this.splitContainer1);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage3.Size = new System.Drawing.Size(1292, 617);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "查看log";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(4, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txt_serach);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_medium);
            this.splitContainer1.Panel1.Controls.Add(this.dtp_EndTime);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_EndTime);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_StartTime);
            this.splitContainer1.Panel1.Controls.Add(this.dtp_StartTime);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl2);
            this.splitContainer1.Size = new System.Drawing.Size(1284, 611);
            this.splitContainer1.SplitterDistance = 39;
            this.splitContainer1.TabIndex = 1;
            // 
            // txt_serach
            // 
            this.txt_serach.BackColor = System.Drawing.Color.Transparent;
            this.txt_serach.ConerRadius = 5;
            this.txt_serach.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_serach.DecLength = 2;
            this.txt_serach.Dock = System.Windows.Forms.DockStyle.Right;
            this.txt_serach.FillColor = System.Drawing.Color.Empty;
            this.txt_serach.FocusBorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.txt_serach.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txt_serach.InputText = "";
            this.txt_serach.InputType = AppSettingsHelper.TextInputType.NotControl;
            this.txt_serach.IsFocusColor = true;
            this.txt_serach.IsRadius = true;
            this.txt_serach.IsShowClearBtn = true;
            this.txt_serach.IsShowKeyboard = false;
            this.txt_serach.IsShowRect = true;
            this.txt_serach.IsShowSearchBtn = true;
            this.txt_serach.KeyBoardType = AppSettingsHelper.KeyBoardType.UCKeyBorderAll_EN;
            this.txt_serach.Location = new System.Drawing.Point(466, 0);
            this.txt_serach.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_serach.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.txt_serach.MinValue = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.txt_serach.Name = "txt_serach";
            this.txt_serach.Padding = new System.Windows.Forms.Padding(5);
            this.txt_serach.PromptColor = System.Drawing.Color.Gray;
            this.txt_serach.PromptFont = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txt_serach.PromptText = "日志默认展示一天信息，请在这里输入要查询的日志信息";
            this.txt_serach.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txt_serach.RectWidth = 1;
            this.txt_serach.RegexPattern = "";
            this.txt_serach.Size = new System.Drawing.Size(818, 39);
            this.txt_serach.TabIndex = 5;
            // 
            // lbl_medium
            // 
            this.lbl_medium.AutoSize = true;
            this.lbl_medium.Location = new System.Drawing.Point(214, 10);
            this.lbl_medium.Name = "lbl_medium";
            this.lbl_medium.Size = new System.Drawing.Size(38, 18);
            this.lbl_medium.TabIndex = 4;
            this.lbl_medium.Text = "------";
            // 
            // dtp_EndTime
            // 
            this.dtp_EndTime.CustomFormat = "yyyy-MM-dd";
            this.dtp_EndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_EndTime.Location = new System.Drawing.Point(336, 7);
            this.dtp_EndTime.Name = "dtp_EndTime";
            this.dtp_EndTime.Size = new System.Drawing.Size(123, 24);
            this.dtp_EndTime.TabIndex = 3;
            // 
            // lbl_EndTime
            // 
            this.lbl_EndTime.AutoSize = true;
            this.lbl_EndTime.Location = new System.Drawing.Point(260, 10);
            this.lbl_EndTime.Name = "lbl_EndTime";
            this.lbl_EndTime.Size = new System.Drawing.Size(68, 18);
            this.lbl_EndTime.TabIndex = 2;
            this.lbl_EndTime.Text = "结束日期";
            // 
            // lbl_StartTime
            // 
            this.lbl_StartTime.AutoSize = true;
            this.lbl_StartTime.Location = new System.Drawing.Point(7, 10);
            this.lbl_StartTime.Name = "lbl_StartTime";
            this.lbl_StartTime.Size = new System.Drawing.Size(68, 18);
            this.lbl_StartTime.TabIndex = 1;
            this.lbl_StartTime.Text = "开始日期";
            // 
            // dtp_StartTime
            // 
            this.dtp_StartTime.CustomFormat = "yyyy-MM-dd";
            this.dtp_StartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_StartTime.Location = new System.Drawing.Point(83, 7);
            this.dtp_StartTime.Name = "dtp_StartTime";
            this.dtp_StartTime.Size = new System.Drawing.Size(123, 24);
            this.dtp_StartTime.TabIndex = 0;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage_Information);
            this.tabControl2.Controls.Add(this.tabPage_Warning);
            this.tabControl2.Controls.Add(this.tabPage_eroor);
            this.tabControl2.Controls.Add(this.tabPage_Fatal);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1284, 568);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage_Information
            // 
            this.tabPage_Information.Controls.Add(this.richTextBox_information);
            this.tabPage_Information.Location = new System.Drawing.Point(4, 27);
            this.tabPage_Information.Name = "tabPage_Information";
            this.tabPage_Information.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Information.Size = new System.Drawing.Size(1276, 537);
            this.tabPage_Information.TabIndex = 0;
            this.tabPage_Information.Text = "信息";
            this.tabPage_Information.UseVisualStyleBackColor = true;
            // 
            // richTextBox_information
            // 
            this.richTextBox_information.BackColor = System.Drawing.Color.White;
            this.richTextBox_information.ContextMenuStrip = this.contextMenuLog;
            this.richTextBox_information.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_information.ForeColor = System.Drawing.Color.Black;
            this.richTextBox_information.Location = new System.Drawing.Point(3, 3);
            this.richTextBox_information.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.richTextBox_information.Name = "richTextBox_information";
            this.richTextBox_information.Size = new System.Drawing.Size(1270, 531);
            this.richTextBox_information.TabIndex = 1;
            this.richTextBox_information.Text = "";
            // 
            // contextMenuLog
            // 
            this.contextMenuLog.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.刷新ToolStripMenuItem,
            this.清空日志ToolStripMenuItem});
            this.contextMenuLog.Name = "contextMenuStrip1";
            this.contextMenuLog.Size = new System.Drawing.Size(127, 48);
            // 
            // 刷新ToolStripMenuItem
            // 
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.刷新ToolStripMenuItem.Text = "刷新";
            this.刷新ToolStripMenuItem.Click += new System.EventHandler(this.刷新ToolStripMenuItem_Click);
            // 
            // 清空日志ToolStripMenuItem
            // 
            this.清空日志ToolStripMenuItem.Name = "清空日志ToolStripMenuItem";
            this.清空日志ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.清空日志ToolStripMenuItem.Text = "清空日志";
            this.清空日志ToolStripMenuItem.Click += new System.EventHandler(this.清空日志ToolStripMenuItem_Click);
            // 
            // tabPage_Warning
            // 
            this.tabPage_Warning.Controls.Add(this.richTextBox_warning);
            this.tabPage_Warning.Location = new System.Drawing.Point(4, 27);
            this.tabPage_Warning.Name = "tabPage_Warning";
            this.tabPage_Warning.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Warning.Size = new System.Drawing.Size(1276, 537);
            this.tabPage_Warning.TabIndex = 1;
            this.tabPage_Warning.Text = "警告";
            this.tabPage_Warning.UseVisualStyleBackColor = true;
            // 
            // richTextBox_warning
            // 
            this.richTextBox_warning.BackColor = System.Drawing.Color.White;
            this.richTextBox_warning.ContextMenuStrip = this.contextMenuLog;
            this.richTextBox_warning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_warning.ForeColor = System.Drawing.Color.Black;
            this.richTextBox_warning.Location = new System.Drawing.Point(3, 3);
            this.richTextBox_warning.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.richTextBox_warning.Name = "richTextBox_warning";
            this.richTextBox_warning.Size = new System.Drawing.Size(1270, 531);
            this.richTextBox_warning.TabIndex = 2;
            this.richTextBox_warning.Text = "";
            // 
            // tabPage_eroor
            // 
            this.tabPage_eroor.Controls.Add(this.richTextBox_error);
            this.tabPage_eroor.Location = new System.Drawing.Point(4, 27);
            this.tabPage_eroor.Name = "tabPage_eroor";
            this.tabPage_eroor.Size = new System.Drawing.Size(1276, 537);
            this.tabPage_eroor.TabIndex = 2;
            this.tabPage_eroor.Text = "错误";
            this.tabPage_eroor.UseVisualStyleBackColor = true;
            // 
            // richTextBox_error
            // 
            this.richTextBox_error.BackColor = System.Drawing.Color.White;
            this.richTextBox_error.ContextMenuStrip = this.contextMenuLog;
            this.richTextBox_error.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_error.ForeColor = System.Drawing.Color.Black;
            this.richTextBox_error.Location = new System.Drawing.Point(0, 0);
            this.richTextBox_error.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.richTextBox_error.Name = "richTextBox_error";
            this.richTextBox_error.Size = new System.Drawing.Size(1276, 537);
            this.richTextBox_error.TabIndex = 2;
            this.richTextBox_error.Text = "";
            // 
            // tabPage_Fatal
            // 
            this.tabPage_Fatal.Controls.Add(this.richTextBox_Fatal);
            this.tabPage_Fatal.Location = new System.Drawing.Point(4, 27);
            this.tabPage_Fatal.Name = "tabPage_Fatal";
            this.tabPage_Fatal.Size = new System.Drawing.Size(1276, 537);
            this.tabPage_Fatal.TabIndex = 3;
            this.tabPage_Fatal.Text = "严重错误";
            this.tabPage_Fatal.UseVisualStyleBackColor = true;
            // 
            // richTextBox_Fatal
            // 
            this.richTextBox_Fatal.BackColor = System.Drawing.Color.White;
            this.richTextBox_Fatal.ContextMenuStrip = this.contextMenuLog;
            this.richTextBox_Fatal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_Fatal.ForeColor = System.Drawing.Color.Black;
            this.richTextBox_Fatal.Location = new System.Drawing.Point(0, 0);
            this.richTextBox_Fatal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.richTextBox_Fatal.Name = "richTextBox_Fatal";
            this.richTextBox_Fatal.Size = new System.Drawing.Size(1276, 537);
            this.richTextBox_Fatal.TabIndex = 2;
            this.richTextBox_Fatal.Text = "";
            // 
            // tabPage9
            // 
            this.tabPage9.BackColor = System.Drawing.Color.White;
            this.tabPage9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabPage9.Controls.Add(this.lbMessage);
            this.tabPage9.Controls.Add(this.lbServicestate);
            this.tabPage9.Controls.Add(this.btnServiceUninstall);
            this.tabPage9.Controls.Add(this.btnServiceStop);
            this.tabPage9.Controls.Add(this.btnServiceStart);
            this.tabPage9.Controls.Add(this.btnServiceInstall);
            this.tabPage9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tabPage9.Location = new System.Drawing.Point(4, 34);
            this.tabPage9.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage9.Size = new System.Drawing.Size(1292, 617);
            this.tabPage9.TabIndex = 4;
            this.tabPage9.Text = "windows服务管理";
            // 
            // lbMessage
            // 
            this.lbMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbMessage.AutoSize = true;
            this.lbMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbMessage.ForeColor = System.Drawing.Color.Blue;
            this.lbMessage.Location = new System.Drawing.Point(9, 559);
            this.lbMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(322, 31);
            this.lbMessage.TabIndex = 8;
            this.lbMessage.Text = "服务已安装，正在运行。";
            this.lbMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbServicestate
            // 
            this.lbServicestate.AutoSize = true;
            this.lbServicestate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbServicestate.ForeColor = System.Drawing.Color.Red;
            this.lbServicestate.Location = new System.Drawing.Point(477, 263);
            this.lbServicestate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbServicestate.Name = "lbServicestate";
            this.lbServicestate.Size = new System.Drawing.Size(179, 25);
            this.lbServicestate.TabIndex = 6;
            this.lbServicestate.Text = "服务正在运行.....";
            // 
            // btnServiceUninstall
            // 
            this.btnServiceUninstall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(166)))), ((int)(((byte)(171)))));
            this.btnServiceUninstall.FlatAppearance.BorderSize = 0;
            this.btnServiceUninstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServiceUninstall.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnServiceUninstall.ForeColor = System.Drawing.Color.White;
            this.btnServiceUninstall.Location = new System.Drawing.Point(286, 105);
            this.btnServiceUninstall.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnServiceUninstall.Name = "btnServiceUninstall";
            this.btnServiceUninstall.Size = new System.Drawing.Size(140, 75);
            this.btnServiceUninstall.TabIndex = 1;
            this.btnServiceUninstall.Text = "卸载服务";
            this.btnServiceUninstall.UseVisualStyleBackColor = false;
            // 
            // btnServiceStop
            // 
            this.btnServiceStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(166)))), ((int)(((byte)(171)))));
            this.btnServiceStop.FlatAppearance.BorderSize = 0;
            this.btnServiceStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServiceStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnServiceStop.ForeColor = System.Drawing.Color.White;
            this.btnServiceStop.Location = new System.Drawing.Point(286, 241);
            this.btnServiceStop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnServiceStop.Name = "btnServiceStop";
            this.btnServiceStop.Size = new System.Drawing.Size(140, 75);
            this.btnServiceStop.TabIndex = 3;
            this.btnServiceStop.Text = "停止服务";
            this.btnServiceStop.UseVisualStyleBackColor = false;
            // 
            // btnServiceStart
            // 
            this.btnServiceStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(166)))), ((int)(((byte)(171)))));
            this.btnServiceStart.FlatAppearance.BorderSize = 0;
            this.btnServiceStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServiceStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnServiceStart.ForeColor = System.Drawing.Color.White;
            this.btnServiceStart.Location = new System.Drawing.Point(83, 241);
            this.btnServiceStart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnServiceStart.Name = "btnServiceStart";
            this.btnServiceStart.Size = new System.Drawing.Size(140, 75);
            this.btnServiceStart.TabIndex = 2;
            this.btnServiceStart.Text = "启动服务";
            this.btnServiceStart.UseVisualStyleBackColor = false;
            // 
            // btnServiceInstall
            // 
            this.btnServiceInstall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(166)))), ((int)(((byte)(171)))));
            this.btnServiceInstall.FlatAppearance.BorderSize = 0;
            this.btnServiceInstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServiceInstall.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnServiceInstall.ForeColor = System.Drawing.Color.White;
            this.btnServiceInstall.Location = new System.Drawing.Point(83, 105);
            this.btnServiceInstall.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnServiceInstall.Name = "btnServiceInstall";
            this.btnServiceInstall.Size = new System.Drawing.Size(140, 75);
            this.btnServiceInstall.TabIndex = 0;
            this.btnServiceInstall.Text = "安装服务";
            this.btnServiceInstall.UseVisualStyleBackColor = false;
            this.btnServiceInstall.Click += new System.EventHandler(this.btnDwInstall_Click);
            // 
            // pnl_header
            // 
            this.pnl_header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(37)))), ((int)(((byte)(75)))));
            this.pnl_header.Controls.Add(this.pnl_minimizeAndClose);
            this.pnl_header.Controls.Add(this.pnl_title);
            this.pnl_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_header.Location = new System.Drawing.Point(0, 0);
            this.pnl_header.Margin = new System.Windows.Forms.Padding(0);
            this.pnl_header.Name = "pnl_header";
            this.pnl_header.Size = new System.Drawing.Size(1300, 113);
            this.pnl_header.TabIndex = 2;
            // 
            // pnl_minimizeAndClose
            // 
            this.pnl_minimizeAndClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(166)))), ((int)(((byte)(171)))));
            this.pnl_minimizeAndClose.Controls.Add(this.btn_close);
            this.pnl_minimizeAndClose.Controls.Add(this.btn_minimize);
            this.pnl_minimizeAndClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_minimizeAndClose.Location = new System.Drawing.Point(1175, 0);
            this.pnl_minimizeAndClose.Margin = new System.Windows.Forms.Padding(0, 3, 4, 0);
            this.pnl_minimizeAndClose.Name = "pnl_minimizeAndClose";
            this.pnl_minimizeAndClose.Size = new System.Drawing.Size(125, 113);
            this.pnl_minimizeAndClose.TabIndex = 1;
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.Brown;
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_close.ForeColor = System.Drawing.Color.White;
            this.btn_close.Location = new System.Drawing.Point(69, 39);
            this.btn_close.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(42, 42);
            this.btn_close.TabIndex = 1;
            this.btn_close.Text = "×";
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_minimize
            // 
            this.btn_minimize.BackColor = System.Drawing.Color.Silver;
            this.btn_minimize.FlatAppearance.BorderSize = 0;
            this.btn_minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_minimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_minimize.ForeColor = System.Drawing.Color.Black;
            this.btn_minimize.Location = new System.Drawing.Point(4, 39);
            this.btn_minimize.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_minimize.Name = "btn_minimize";
            this.btn_minimize.Size = new System.Drawing.Size(42, 42);
            this.btn_minimize.TabIndex = 0;
            this.btn_minimize.Text = "—";
            this.btn_minimize.UseVisualStyleBackColor = false;
            this.btn_minimize.Click += new System.EventHandler(this.btn_minimize_Click);
            // 
            // pnl_title
            // 
            this.pnl_title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(166)))), ((int)(((byte)(171)))));
            this.pnl_title.Controls.Add(this.lbl_title);
            this.pnl_title.Controls.Add(this.pb_icon);
            this.pnl_title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_title.Location = new System.Drawing.Point(0, 0);
            this.pnl_title.Margin = new System.Windows.Forms.Padding(4, 3, 0, 0);
            this.pnl_title.Name = "pnl_title";
            this.pnl_title.Size = new System.Drawing.Size(1300, 113);
            this.pnl_title.TabIndex = 0;
            this.pnl_title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnl_titile_MouseDown);
            this.pnl_title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_titile_MouseMove);
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 27F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_title.ForeColor = System.Drawing.Color.White;
            this.lbl_title.Location = new System.Drawing.Point(230, 47);
            this.lbl_title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(350, 40);
            this.lbl_title.TabIndex = 1;
            this.lbl_title.Text = "设备保养与维修服务";
            // 
            // pb_icon
            // 
            this.pb_icon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pb_icon.BackgroundImage")));
            this.pb_icon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_icon.ImageLocation = "";
            this.pb_icon.InitialImage = null;
            this.pb_icon.Location = new System.Drawing.Point(9, 15);
            this.pb_icon.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pb_icon.Name = "pb_icon";
            this.pb_icon.Size = new System.Drawing.Size(203, 81);
            this.pb_icon.TabIndex = 0;
            this.pb_icon.TabStop = false;
            // 
            // SalesFeedBackMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(166)))), ((int)(((byte)(171)))));
            this.ClientSize = new System.Drawing.Size(1300, 768);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pnl_header);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "SalesFeedBackMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SalesFeedBackMainSettings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage_Information.ResumeLayout(false);
            this.contextMenuLog.ResumeLayout(false);
            this.tabPage_Warning.ResumeLayout(false);
            this.tabPage_eroor.ResumeLayout(false);
            this.tabPage_Fatal.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            this.tabPage9.PerformLayout();
            this.pnl_header.ResumeLayout(false);
            this.pnl_minimizeAndClose.ResumeLayout(false);
            this.pnl_title.ResumeLayout(false);
            this.pnl_title.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_icon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpg_deviceManager;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ContextMenuStrip contextMenuLog;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.Button btnServiceUninstall;
        private System.Windows.Forms.Button btnServiceStop;
        private System.Windows.Forms.Button btnServiceStart;
        private System.Windows.Forms.Button btnServiceInstall;
        private System.Windows.Forms.Panel pnl_header;
        private System.Windows.Forms.Panel pnl_minimizeAndClose;
        private System.Windows.Forms.Panel pnl_title;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.PictureBox pb_icon;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_minimize;
        private System.Windows.Forms.ToolStripMenuItem 清空日志ToolStripMenuItem;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.ContextMenuStrip contextMenuDevice;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage_Information;
        private System.Windows.Forms.RichTextBox richTextBox_information;
        private System.Windows.Forms.TabPage tabPage_Warning;
        private System.Windows.Forms.TabPage tabPage_eroor;
        private System.Windows.Forms.TabPage tabPage_Fatal;
        private System.Windows.Forms.Label lbServicestate;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lbl_medium;
        private System.Windows.Forms.DateTimePicker dtp_EndTime;
        private System.Windows.Forms.Label lbl_EndTime;
        private System.Windows.Forms.Label lbl_StartTime;
        private System.Windows.Forms.DateTimePicker dtp_StartTime;
        private UCTextBoxEx txt_serach;
        private System.Windows.Forms.RichTextBox richTextBox_warning;
        private System.Windows.Forms.RichTextBox richTextBox_error;
        private System.Windows.Forms.RichTextBox richTextBox_Fatal;
    }
}


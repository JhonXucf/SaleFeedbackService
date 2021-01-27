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
            this.tabControl_log = new System.Windows.Forms.TabControl();
            this.tabPage_Information = new System.Windows.Forms.TabPage();
            this.richTextBox_information = new System.Windows.Forms.RichTextBox();
            this.contextMenuLog = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_SearchPatternShow = new System.Windows.Forms.Panel();
            this.btn_jumpToIndex = new System.Windows.Forms.Button();
            this.tbx_currentPatternNum = new System.Windows.Forms.TextBox();
            this.lbl_SearchTip = new System.Windows.Forms.Label();
            this.btn_Last = new System.Windows.Forms.Button();
            this.btn_Next = new System.Windows.Forms.Button();
            this.lbl_SearchCount = new System.Windows.Forms.Label();
            this.lbl_SearchTitle = new System.Windows.Forms.Label();
            this.tabPage_Warning = new System.Windows.Forms.TabPage();
            this.tabPage_eroor = new System.Windows.Forms.TabPage();
            this.tabPage_Fatal = new System.Windows.Forms.TabPage();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.gbx_ServiceContainer = new System.Windows.Forms.GroupBox();
            this.btn_saveAppSettingJson = new System.Windows.Forms.Button();
            this.gbx_TcpContainer = new System.Windows.Forms.GroupBox();
            this.tbx_ip = new System.Windows.Forms.TextBox();
            this.lbl_tcpIp = new System.Windows.Forms.Label();
            this.cbx_saveTcpLog = new System.Windows.Forms.CheckBox();
            this.tbx_tcpPort = new System.Windows.Forms.TextBox();
            this.lbl_tcpPort = new System.Windows.Forms.Label();
            this.gbx_UdpContainer = new System.Windows.Forms.GroupBox();
            this.cbx_saveUdpLog = new System.Windows.Forms.CheckBox();
            this.tbx_udpPort = new System.Windows.Forms.TextBox();
            this.lbl_udpPort = new System.Windows.Forms.Label();
            this.cbx_enableTCP = new System.Windows.Forms.CheckBox();
            this.cbx_enableUDP = new System.Windows.Forms.CheckBox();
            this.lbl_domain = new System.Windows.Forms.Label();
            this.cbx_domain = new System.Windows.Forms.ComboBox();
            this.lbMessage = new System.Windows.Forms.Label();
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
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuHide = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemShowMainform = new System.Windows.Forms.ToolStripMenuItem();
            this.itemCloseMainform = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl_log.SuspendLayout();
            this.tabPage_Information.SuspendLayout();
            this.contextMenuLog.SuspendLayout();
            this.panel_SearchPatternShow.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.gbx_ServiceContainer.SuspendLayout();
            this.gbx_TcpContainer.SuspendLayout();
            this.gbx_UdpContainer.SuspendLayout();
            this.pnl_header.SuspendLayout();
            this.pnl_minimizeAndClose.SuspendLayout();
            this.pnl_title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_icon)).BeginInit();
            this.contextMenuHide.SuspendLayout();
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
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.LightGray;
            this.splitContainer1.Panel1.Controls.Add(this.txt_serach);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_medium);
            this.splitContainer1.Panel1.Controls.Add(this.dtp_EndTime);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_EndTime);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_StartTime);
            this.splitContainer1.Panel1.Controls.Add(this.dtp_StartTime);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl_log);
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
            this.txt_serach.IsShowRect = false;
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
            // tabControl_log
            // 
            this.tabControl_log.Controls.Add(this.tabPage_Information);
            this.tabControl_log.Controls.Add(this.tabPage_Warning);
            this.tabControl_log.Controls.Add(this.tabPage_eroor);
            this.tabControl_log.Controls.Add(this.tabPage_Fatal);
            this.tabControl_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_log.Location = new System.Drawing.Point(0, 0);
            this.tabControl_log.Name = "tabControl_log";
            this.tabControl_log.SelectedIndex = 0;
            this.tabControl_log.Size = new System.Drawing.Size(1284, 568);
            this.tabControl_log.TabIndex = 0;
            this.tabControl_log.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl_log_Selected);
            // 
            // tabPage_Information
            // 
            this.tabPage_Information.Controls.Add(this.richTextBox_information);
            this.tabPage_Information.Controls.Add(this.panel_SearchPatternShow);
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
            this.richTextBox_information.Size = new System.Drawing.Size(1270, 497);
            this.richTextBox_information.TabIndex = 1;
            this.richTextBox_information.Text = "";
            // 
            // contextMenuLog
            // 
            this.contextMenuLog.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.刷新ToolStripMenuItem});
            this.contextMenuLog.Name = "contextMenuStrip1";
            this.contextMenuLog.Size = new System.Drawing.Size(101, 26);
            // 
            // 刷新ToolStripMenuItem
            // 
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.刷新ToolStripMenuItem.Text = "刷新";
            this.刷新ToolStripMenuItem.Click += new System.EventHandler(this.刷新ToolStripMenuItem_Click);
            // 
            // panel_SearchPatternShow
            // 
            this.panel_SearchPatternShow.Controls.Add(this.btn_jumpToIndex);
            this.panel_SearchPatternShow.Controls.Add(this.tbx_currentPatternNum);
            this.panel_SearchPatternShow.Controls.Add(this.lbl_SearchTip);
            this.panel_SearchPatternShow.Controls.Add(this.btn_Last);
            this.panel_SearchPatternShow.Controls.Add(this.btn_Next);
            this.panel_SearchPatternShow.Controls.Add(this.lbl_SearchCount);
            this.panel_SearchPatternShow.Controls.Add(this.lbl_SearchTitle);
            this.panel_SearchPatternShow.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_SearchPatternShow.Location = new System.Drawing.Point(3, 500);
            this.panel_SearchPatternShow.Name = "panel_SearchPatternShow";
            this.panel_SearchPatternShow.Size = new System.Drawing.Size(1270, 34);
            this.panel_SearchPatternShow.TabIndex = 2;
            // 
            // btn_jumpToIndex
            // 
            this.btn_jumpToIndex.Location = new System.Drawing.Point(530, 5);
            this.btn_jumpToIndex.Name = "btn_jumpToIndex";
            this.btn_jumpToIndex.Size = new System.Drawing.Size(91, 25);
            this.btn_jumpToIndex.TabIndex = 8;
            this.btn_jumpToIndex.Text = "跳转";
            this.btn_jumpToIndex.UseVisualStyleBackColor = true;
            this.btn_jumpToIndex.Click += new System.EventHandler(this.btn_jumpToIndex_Click);
            // 
            // tbx_currentPatternNum
            // 
            this.tbx_currentPatternNum.Location = new System.Drawing.Point(424, 5);
            this.tbx_currentPatternNum.Name = "tbx_currentPatternNum";
            this.tbx_currentPatternNum.Size = new System.Drawing.Size(100, 24);
            this.tbx_currentPatternNum.TabIndex = 7;
            this.tbx_currentPatternNum.Text = "0";
            this.tbx_currentPatternNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_SearchTip
            // 
            this.lbl_SearchTip.AutoSize = true;
            this.lbl_SearchTip.ForeColor = System.Drawing.Color.Gray;
            this.lbl_SearchTip.Location = new System.Drawing.Point(1037, 8);
            this.lbl_SearchTip.Name = "lbl_SearchTip";
            this.lbl_SearchTip.Size = new System.Drawing.Size(141, 18);
            this.lbl_SearchTip.TabIndex = 6;
            this.lbl_SearchTip.Text = "查询中，请稍后.......";
            // 
            // btn_Last
            // 
            this.btn_Last.Location = new System.Drawing.Point(327, 5);
            this.btn_Last.Name = "btn_Last";
            this.btn_Last.Size = new System.Drawing.Size(91, 25);
            this.btn_Last.TabIndex = 3;
            this.btn_Last.Text = "上一项";
            this.btn_Last.UseVisualStyleBackColor = true;
            this.btn_Last.Click += new System.EventHandler(this.btn_Last_Click);
            // 
            // btn_Next
            // 
            this.btn_Next.Location = new System.Drawing.Point(230, 5);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(91, 25);
            this.btn_Next.TabIndex = 2;
            this.btn_Next.Text = "下一项";
            this.btn_Next.UseVisualStyleBackColor = true;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // lbl_SearchCount
            // 
            this.lbl_SearchCount.AutoSize = true;
            this.lbl_SearchCount.Location = new System.Drawing.Point(126, 8);
            this.lbl_SearchCount.Name = "lbl_SearchCount";
            this.lbl_SearchCount.Size = new System.Drawing.Size(0, 18);
            this.lbl_SearchCount.TabIndex = 1;
            // 
            // lbl_SearchTitle
            // 
            this.lbl_SearchTitle.AutoSize = true;
            this.lbl_SearchTitle.Location = new System.Drawing.Point(27, 8);
            this.lbl_SearchTitle.Name = "lbl_SearchTitle";
            this.lbl_SearchTitle.Size = new System.Drawing.Size(83, 18);
            this.lbl_SearchTitle.TabIndex = 0;
            this.lbl_SearchTitle.Text = "查询匹配项";
            // 
            // tabPage_Warning
            // 
            this.tabPage_Warning.Location = new System.Drawing.Point(4, 27);
            this.tabPage_Warning.Name = "tabPage_Warning";
            this.tabPage_Warning.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Warning.Size = new System.Drawing.Size(1276, 537);
            this.tabPage_Warning.TabIndex = 1;
            this.tabPage_Warning.Text = "警告";
            this.tabPage_Warning.UseVisualStyleBackColor = true;
            // 
            // tabPage_eroor
            // 
            this.tabPage_eroor.Location = new System.Drawing.Point(4, 27);
            this.tabPage_eroor.Name = "tabPage_eroor";
            this.tabPage_eroor.Size = new System.Drawing.Size(1276, 537);
            this.tabPage_eroor.TabIndex = 2;
            this.tabPage_eroor.Text = "错误";
            this.tabPage_eroor.UseVisualStyleBackColor = true;
            // 
            // tabPage_Fatal
            // 
            this.tabPage_Fatal.Location = new System.Drawing.Point(4, 27);
            this.tabPage_Fatal.Name = "tabPage_Fatal";
            this.tabPage_Fatal.Size = new System.Drawing.Size(1276, 537);
            this.tabPage_Fatal.TabIndex = 3;
            this.tabPage_Fatal.Text = "严重错误";
            this.tabPage_Fatal.UseVisualStyleBackColor = true;
            // 
            // tabPage9
            // 
            this.tabPage9.BackColor = System.Drawing.Color.White;
            this.tabPage9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabPage9.Controls.Add(this.gbx_ServiceContainer);
            this.tabPage9.Controls.Add(this.lbMessage);
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
            // gbx_ServiceContainer
            // 
            this.gbx_ServiceContainer.Controls.Add(this.btn_saveAppSettingJson);
            this.gbx_ServiceContainer.Controls.Add(this.gbx_TcpContainer);
            this.gbx_ServiceContainer.Controls.Add(this.gbx_UdpContainer);
            this.gbx_ServiceContainer.Controls.Add(this.cbx_enableTCP);
            this.gbx_ServiceContainer.Controls.Add(this.cbx_enableUDP);
            this.gbx_ServiceContainer.Controls.Add(this.lbl_domain);
            this.gbx_ServiceContainer.Controls.Add(this.cbx_domain);
            this.gbx_ServiceContainer.Location = new System.Drawing.Point(9, 3);
            this.gbx_ServiceContainer.Name = "gbx_ServiceContainer";
            this.gbx_ServiceContainer.Size = new System.Drawing.Size(467, 553);
            this.gbx_ServiceContainer.TabIndex = 11;
            this.gbx_ServiceContainer.TabStop = false;
            // 
            // btn_saveAppSettingJson
            // 
            this.btn_saveAppSettingJson.Location = new System.Drawing.Point(324, 461);
            this.btn_saveAppSettingJson.Name = "btn_saveAppSettingJson";
            this.btn_saveAppSettingJson.Size = new System.Drawing.Size(103, 30);
            this.btn_saveAppSettingJson.TabIndex = 15;
            this.btn_saveAppSettingJson.Text = "保  存";
            this.btn_saveAppSettingJson.UseVisualStyleBackColor = true;
            this.btn_saveAppSettingJson.Click += new System.EventHandler(this.btn_saveAppSettingJson_Click);
            // 
            // gbx_TcpContainer
            // 
            this.gbx_TcpContainer.Controls.Add(this.tbx_ip);
            this.gbx_TcpContainer.Controls.Add(this.lbl_tcpIp);
            this.gbx_TcpContainer.Controls.Add(this.cbx_saveTcpLog);
            this.gbx_TcpContainer.Controls.Add(this.tbx_tcpPort);
            this.gbx_TcpContainer.Controls.Add(this.lbl_tcpPort);
            this.gbx_TcpContainer.Enabled = false;
            this.gbx_TcpContainer.Location = new System.Drawing.Point(40, 280);
            this.gbx_TcpContainer.Name = "gbx_TcpContainer";
            this.gbx_TcpContainer.Size = new System.Drawing.Size(387, 159);
            this.gbx_TcpContainer.TabIndex = 14;
            this.gbx_TcpContainer.TabStop = false;
            // 
            // tbx_ip
            // 
            this.tbx_ip.Location = new System.Drawing.Point(138, 28);
            this.tbx_ip.Name = "tbx_ip";
            this.tbx_ip.Size = new System.Drawing.Size(163, 29);
            this.tbx_ip.TabIndex = 15;
            this.tbx_ip.Text = "127.0.0.1";
            this.tbx_ip.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_tcpIp
            // 
            this.lbl_tcpIp.AutoSize = true;
            this.lbl_tcpIp.Location = new System.Drawing.Point(9, 30);
            this.lbl_tcpIp.Name = "lbl_tcpIp";
            this.lbl_tcpIp.Size = new System.Drawing.Size(68, 24);
            this.lbl_tcpIp.TabIndex = 14;
            this.lbl_tcpIp.Text = "IP地址";
            // 
            // cbx_saveTcpLog
            // 
            this.cbx_saveTcpLog.AutoSize = true;
            this.cbx_saveTcpLog.Location = new System.Drawing.Point(9, 116);
            this.cbx_saveTcpLog.Name = "cbx_saveTcpLog";
            this.cbx_saveTcpLog.Size = new System.Drawing.Size(230, 28);
            this.cbx_saveTcpLog.TabIndex = 13;
            this.cbx_saveTcpLog.Text = "将UDP信息保存到日志";
            this.cbx_saveTcpLog.UseVisualStyleBackColor = true;
            // 
            // tbx_tcpPort
            // 
            this.tbx_tcpPort.Location = new System.Drawing.Point(139, 71);
            this.tbx_tcpPort.Name = "tbx_tcpPort";
            this.tbx_tcpPort.Size = new System.Drawing.Size(162, 29);
            this.tbx_tcpPort.TabIndex = 1;
            this.tbx_tcpPort.Text = "8888";
            this.tbx_tcpPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_tcpPort
            // 
            this.lbl_tcpPort.AutoSize = true;
            this.lbl_tcpPort.Location = new System.Drawing.Point(9, 73);
            this.lbl_tcpPort.Name = "lbl_tcpPort";
            this.lbl_tcpPort.Size = new System.Drawing.Size(90, 24);
            this.lbl_tcpPort.TabIndex = 0;
            this.lbl_tcpPort.Text = "TCP端口";
            // 
            // gbx_UdpContainer
            // 
            this.gbx_UdpContainer.Controls.Add(this.cbx_saveUdpLog);
            this.gbx_UdpContainer.Controls.Add(this.tbx_udpPort);
            this.gbx_UdpContainer.Controls.Add(this.lbl_udpPort);
            this.gbx_UdpContainer.Enabled = false;
            this.gbx_UdpContainer.Location = new System.Drawing.Point(40, 110);
            this.gbx_UdpContainer.Name = "gbx_UdpContainer";
            this.gbx_UdpContainer.Size = new System.Drawing.Size(387, 121);
            this.gbx_UdpContainer.TabIndex = 13;
            this.gbx_UdpContainer.TabStop = false;
            // 
            // cbx_saveUdpLog
            // 
            this.cbx_saveUdpLog.AutoSize = true;
            this.cbx_saveUdpLog.Location = new System.Drawing.Point(9, 74);
            this.cbx_saveUdpLog.Name = "cbx_saveUdpLog";
            this.cbx_saveUdpLog.Size = new System.Drawing.Size(230, 28);
            this.cbx_saveUdpLog.TabIndex = 13;
            this.cbx_saveUdpLog.Text = "将UDP信息保存到日志";
            this.cbx_saveUdpLog.UseVisualStyleBackColor = true;
            // 
            // tbx_udpPort
            // 
            this.tbx_udpPort.Location = new System.Drawing.Point(138, 25);
            this.tbx_udpPort.Name = "tbx_udpPort";
            this.tbx_udpPort.Size = new System.Drawing.Size(163, 29);
            this.tbx_udpPort.TabIndex = 1;
            this.tbx_udpPort.Text = "6666";
            this.tbx_udpPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_udpPort
            // 
            this.lbl_udpPort.AutoSize = true;
            this.lbl_udpPort.Location = new System.Drawing.Point(9, 25);
            this.lbl_udpPort.Name = "lbl_udpPort";
            this.lbl_udpPort.Size = new System.Drawing.Size(91, 24);
            this.lbl_udpPort.TabIndex = 0;
            this.lbl_udpPort.Text = "UDP端口";
            // 
            // cbx_enableTCP
            // 
            this.cbx_enableTCP.AutoSize = true;
            this.cbx_enableTCP.Location = new System.Drawing.Point(19, 247);
            this.cbx_enableTCP.Name = "cbx_enableTCP";
            this.cbx_enableTCP.Size = new System.Drawing.Size(149, 28);
            this.cbx_enableTCP.TabIndex = 12;
            this.cbx_enableTCP.Text = "启用TCP通信";
            this.cbx_enableTCP.UseVisualStyleBackColor = true;
            this.cbx_enableTCP.CheckedChanged += new System.EventHandler(this.cbx_enableTCP_CheckedChanged);
            // 
            // cbx_enableUDP
            // 
            this.cbx_enableUDP.AutoSize = true;
            this.cbx_enableUDP.Location = new System.Drawing.Point(19, 77);
            this.cbx_enableUDP.Name = "cbx_enableUDP";
            this.cbx_enableUDP.Size = new System.Drawing.Size(150, 28);
            this.cbx_enableUDP.TabIndex = 11;
            this.cbx_enableUDP.Text = "启用UDP通信";
            this.cbx_enableUDP.UseVisualStyleBackColor = true;
            this.cbx_enableUDP.CheckedChanged += new System.EventHandler(this.cbx_enableUDP_CheckedChanged);
            // 
            // lbl_domain
            // 
            this.lbl_domain.AutoSize = true;
            this.lbl_domain.Location = new System.Drawing.Point(19, 35);
            this.lbl_domain.Name = "lbl_domain";
            this.lbl_domain.Size = new System.Drawing.Size(90, 24);
            this.lbl_domain.TabIndex = 9;
            this.lbl_domain.Text = "当前域名";
            // 
            // cbx_domain
            // 
            this.cbx_domain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_domain.FormattingEnabled = true;
            this.cbx_domain.Location = new System.Drawing.Point(115, 32);
            this.cbx_domain.Name = "cbx_domain";
            this.cbx_domain.Size = new System.Drawing.Size(194, 32);
            this.cbx_domain.TabIndex = 10;
            // 
            // lbMessage
            // 
            this.lbMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbMessage.AutoSize = true;
            this.lbMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbMessage.ForeColor = System.Drawing.Color.Blue;
            this.lbMessage.Location = new System.Drawing.Point(9, 573);
            this.lbMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(322, 31);
            this.lbMessage.TabIndex = 8;
            this.lbMessage.Text = "服务已安装，正在运行。";
            this.lbMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnServiceUninstall
            // 
            this.btnServiceUninstall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(166)))), ((int)(((byte)(171)))));
            this.btnServiceUninstall.FlatAppearance.BorderSize = 0;
            this.btnServiceUninstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServiceUninstall.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnServiceUninstall.ForeColor = System.Drawing.Color.White;
            this.btnServiceUninstall.Location = new System.Drawing.Point(695, 35);
            this.btnServiceUninstall.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnServiceUninstall.Name = "btnServiceUninstall";
            this.btnServiceUninstall.Size = new System.Drawing.Size(140, 75);
            this.btnServiceUninstall.TabIndex = 1;
            this.btnServiceUninstall.Text = "卸载服务";
            this.btnServiceUninstall.UseVisualStyleBackColor = false;
            this.btnServiceUninstall.Click += new System.EventHandler(this.btnServiceUninstall_Click);
            // 
            // btnServiceStop
            // 
            this.btnServiceStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(166)))), ((int)(((byte)(171)))));
            this.btnServiceStop.FlatAppearance.BorderSize = 0;
            this.btnServiceStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServiceStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnServiceStop.ForeColor = System.Drawing.Color.White;
            this.btnServiceStop.Location = new System.Drawing.Point(695, 171);
            this.btnServiceStop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnServiceStop.Name = "btnServiceStop";
            this.btnServiceStop.Size = new System.Drawing.Size(140, 75);
            this.btnServiceStop.TabIndex = 3;
            this.btnServiceStop.Text = "停止服务";
            this.btnServiceStop.UseVisualStyleBackColor = false;
            this.btnServiceStop.Click += new System.EventHandler(this.btnServiceStop_Click);
            // 
            // btnServiceStart
            // 
            this.btnServiceStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(166)))), ((int)(((byte)(171)))));
            this.btnServiceStart.FlatAppearance.BorderSize = 0;
            this.btnServiceStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServiceStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnServiceStart.ForeColor = System.Drawing.Color.White;
            this.btnServiceStart.Location = new System.Drawing.Point(492, 171);
            this.btnServiceStart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnServiceStart.Name = "btnServiceStart";
            this.btnServiceStart.Size = new System.Drawing.Size(140, 75);
            this.btnServiceStart.TabIndex = 2;
            this.btnServiceStart.Text = "启动服务";
            this.btnServiceStart.UseVisualStyleBackColor = false;
            this.btnServiceStart.Click += new System.EventHandler(this.btnServiceStart_Click);
            // 
            // btnServiceInstall
            // 
            this.btnServiceInstall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(166)))), ((int)(((byte)(171)))));
            this.btnServiceInstall.FlatAppearance.BorderSize = 0;
            this.btnServiceInstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServiceInstall.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnServiceInstall.ForeColor = System.Drawing.Color.White;
            this.btnServiceInstall.Location = new System.Drawing.Point(492, 35);
            this.btnServiceInstall.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnServiceInstall.Name = "btnServiceInstall";
            this.btnServiceInstall.Size = new System.Drawing.Size(140, 75);
            this.btnServiceInstall.TabIndex = 0;
            this.btnServiceInstall.Text = "安装服务";
            this.btnServiceInstall.UseVisualStyleBackColor = false;
            this.btnServiceInstall.Click += new System.EventHandler(this.btnServiceInstall_Click);
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
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuHide;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "VCAM设备保养与维修服务";
            this.notifyIcon.Visible = true;
            // 
            // contextMenuHide
            // 
            this.contextMenuHide.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemShowMainform,
            this.itemCloseMainform});
            this.contextMenuHide.Name = "contextMenuHide";
            this.contextMenuHide.Size = new System.Drawing.Size(101, 48);
            // 
            // itemShowMainform
            // 
            this.itemShowMainform.Name = "itemShowMainform";
            this.itemShowMainform.Size = new System.Drawing.Size(100, 22);
            this.itemShowMainform.Text = "显示";
            // 
            // itemCloseMainform
            // 
            this.itemCloseMainform.Name = "itemCloseMainform";
            this.itemCloseMainform.Size = new System.Drawing.Size(100, 22);
            this.itemCloseMainform.Text = "退出";
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
            this.tabControl_log.ResumeLayout(false);
            this.tabPage_Information.ResumeLayout(false);
            this.contextMenuLog.ResumeLayout(false);
            this.panel_SearchPatternShow.ResumeLayout(false);
            this.panel_SearchPatternShow.PerformLayout();
            this.tabPage9.ResumeLayout(false);
            this.tabPage9.PerformLayout();
            this.gbx_ServiceContainer.ResumeLayout(false);
            this.gbx_ServiceContainer.PerformLayout();
            this.gbx_TcpContainer.ResumeLayout(false);
            this.gbx_TcpContainer.PerformLayout();
            this.gbx_UdpContainer.ResumeLayout(false);
            this.gbx_UdpContainer.PerformLayout();
            this.pnl_header.ResumeLayout(false);
            this.pnl_minimizeAndClose.ResumeLayout(false);
            this.pnl_title.ResumeLayout(false);
            this.pnl_title.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_icon)).EndInit();
            this.contextMenuHide.ResumeLayout(false);
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
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.ContextMenuStrip contextMenuDevice;
        private System.Windows.Forms.TabControl tabControl_log;
        private System.Windows.Forms.TabPage tabPage_Information;
        private System.Windows.Forms.RichTextBox richTextBox_information;
        private System.Windows.Forms.TabPage tabPage_Warning;
        private System.Windows.Forms.TabPage tabPage_eroor;
        private System.Windows.Forms.TabPage tabPage_Fatal;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lbl_medium;
        private System.Windows.Forms.DateTimePicker dtp_EndTime;
        private System.Windows.Forms.Label lbl_EndTime;
        private System.Windows.Forms.Label lbl_StartTime;
        private System.Windows.Forms.DateTimePicker dtp_StartTime;
        private UCTextBoxEx txt_serach;
        private System.Windows.Forms.Panel panel_SearchPatternShow;
        private System.Windows.Forms.Label lbl_SearchTitle;
        private System.Windows.Forms.Label lbl_SearchCount;
        private System.Windows.Forms.Button btn_Last;
        private System.Windows.Forms.Button btn_Next;
        private System.Windows.Forms.Label lbl_SearchTip;
        private System.Windows.Forms.Button btn_jumpToIndex;
        private System.Windows.Forms.TextBox tbx_currentPatternNum;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuHide;
        private System.Windows.Forms.ToolStripMenuItem itemShowMainform;
        private System.Windows.Forms.ToolStripMenuItem itemCloseMainform;
        private System.Windows.Forms.GroupBox gbx_ServiceContainer;
        private System.Windows.Forms.Label lbl_domain;
        private System.Windows.Forms.ComboBox cbx_domain;
        private System.Windows.Forms.GroupBox gbx_TcpContainer;
        private System.Windows.Forms.TextBox tbx_ip;
        private System.Windows.Forms.Label lbl_tcpIp;
        private System.Windows.Forms.CheckBox cbx_saveTcpLog;
        private System.Windows.Forms.TextBox tbx_tcpPort;
        private System.Windows.Forms.Label lbl_tcpPort;
        private System.Windows.Forms.GroupBox gbx_UdpContainer;
        private System.Windows.Forms.CheckBox cbx_saveUdpLog;
        private System.Windows.Forms.TextBox tbx_udpPort;
        private System.Windows.Forms.Label lbl_udpPort;
        private System.Windows.Forms.CheckBox cbx_enableTCP;
        private System.Windows.Forms.CheckBox cbx_enableUDP;
        private System.Windows.Forms.Button btn_saveAppSettingJson;
    }
}


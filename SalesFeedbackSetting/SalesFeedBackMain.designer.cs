namespace SalesFeedbackSetting
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox_dw800SavePath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_dw800SaveTime = new System.Windows.Forms.TextBox();
            this.radioButton_Per800SaveTime = new System.Windows.Forms.RadioButton();
            this.radioButton_Pin800SaveTime = new System.Windows.Forms.RadioButton();
            this.dateTimePicker_dw800SaveTime = new System.Windows.Forms.DateTimePicker();
            this.groupBox_dw800 = new System.Windows.Forms.GroupBox();
            this.button_dw800Save = new System.Windows.Forms.Button();
            this.button_dw800cancelAll = new System.Windows.Forms.Button();
            this.button_dw800selectAll = new System.Windows.Forms.Button();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.textBox_dw900SaveTime = new System.Windows.Forms.TextBox();
            this.radioButton_Per900SaveTime = new System.Windows.Forms.RadioButton();
            this.radioButton_Pin900SaveTime = new System.Windows.Forms.RadioButton();
            this.dateTimePicker_dw900SaveTime = new System.Windows.Forms.DateTimePicker();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox_dw900SavePath = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button_dw900Save = new System.Windows.Forms.Button();
            this.button_dw900cancelAll = new System.Windows.Forms.Button();
            this.button_dw900selectAll = new System.Windows.Forms.Button();
            this.groupBox_dw900 = new System.Windows.Forms.GroupBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.contextMenuLog = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空日志ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.lbMessage = new System.Windows.Forms.Label();
            this.lbDw900state = new System.Windows.Forms.Label();
            this.lbDw800state = new System.Windows.Forms.Label();
            this.btnDw900Stop = new System.Windows.Forms.Button();
            this.btnDw900Start = new System.Windows.Forms.Button();
            this.btnDw800Uninstall = new System.Windows.Forms.Button();
            this.btnDw800Stop = new System.Windows.Forms.Button();
            this.btnDw800Start = new System.Windows.Forms.Button();
            this.btnDw800Install = new System.Windows.Forms.Button();
            this.pnl_header = new System.Windows.Forms.Panel();
            this.pnl_minimizeAndClose = new System.Windows.Forms.Panel();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_minimize = new System.Windows.Forms.Button();
            this.pnl_title = new System.Windows.Forms.Panel();
            this.lbl_title = new System.Windows.Forms.Label();
            this.pb_icon = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuDevice = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.新建设备ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.contextMenuLog.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.pnl_header.SuspendLayout();
            this.pnl_minimizeAndClose.SuspendLayout();
            this.pnl_title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_icon)).BeginInit();
            this.contextMenuDevice.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage9);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.tabControl1.ItemSize = new System.Drawing.Size(100, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 98);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1280, 586);
            this.tabControl1.TabIndex = 1;
            this.toolTip1.SetToolTip(this.tabControl1, "Tip:更改后需要手动重启服务");
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(166)))), ((int)(((byte)(171)))));
            this.tabPage1.ContextMenuStrip = this.contextMenuDevice;
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1272, 548);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "设备管理";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(166)))), ((int)(((byte)(171)))));
            this.tabPage4.Controls.Add(this.tabControl3);
            this.tabPage4.Location = new System.Drawing.Point(4, 34);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1272, 548);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "配置导出报表数据";
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage7);
            this.tabControl3.Controls.Add(this.tabPage8);
            this.tabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl3.Location = new System.Drawing.Point(3, 3);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.Padding = new System.Drawing.Point(0, 0);
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(1266, 542);
            this.tabControl3.TabIndex = 0;
            // 
            // tabPage7
            // 
            this.tabPage7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(166)))), ((int)(((byte)(171)))));
            this.tabPage7.Controls.Add(this.groupBox4);
            this.tabPage7.Controls.Add(this.groupBox2);
            this.tabPage7.Controls.Add(this.groupBox_dw800);
            this.tabPage7.Controls.Add(this.button_dw800Save);
            this.tabPage7.Controls.Add(this.button_dw800cancelAll);
            this.tabPage7.Controls.Add(this.button_dw800selectAll);
            this.tabPage7.Location = new System.Drawing.Point(4, 27);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(1258, 511);
            this.tabPage7.TabIndex = 0;
            this.tabPage7.Text = "Dw800";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox_dw800SavePath);
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(3, 333);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(660, 66);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "选择固定存储路径";
            // 
            // textBox_dw800SavePath
            // 
            this.textBox_dw800SavePath.BackColor = System.Drawing.Color.White;
            this.textBox_dw800SavePath.ForeColor = System.Drawing.Color.Black;
            this.textBox_dw800SavePath.Location = new System.Drawing.Point(6, 28);
            this.textBox_dw800SavePath.Name = "textBox_dw800SavePath";
            this.textBox_dw800SavePath.Size = new System.Drawing.Size(558, 24);
            this.textBox_dw800SavePath.TabIndex = 9;
            this.textBox_dw800SavePath.Text = "C:\\\\VCAM\\\\SalesFeedBackMain\\\\";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(570, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 26);
            this.button1.TabIndex = 8;
            this.button1.Text = "选择";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_dw800SaveTime);
            this.groupBox2.Controls.Add(this.radioButton_Per800SaveTime);
            this.groupBox2.Controls.Add(this.radioButton_Pin800SaveTime);
            this.groupBox2.Controls.Add(this.dateTimePicker_dw800SaveTime);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(3, 406);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(660, 100);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "存储时间模式选择";
            // 
            // textBox_dw800SaveTime
            // 
            this.textBox_dw800SaveTime.Location = new System.Drawing.Point(254, 61);
            this.textBox_dw800SaveTime.Name = "textBox_dw800SaveTime";
            this.textBox_dw800SaveTime.Size = new System.Drawing.Size(144, 24);
            this.textBox_dw800SaveTime.TabIndex = 13;
            this.toolTip1.SetToolTip(this.textBox_dw800SaveTime, "请输入大于1的整数！");
            this.textBox_dw800SaveTime.TextChanged += new System.EventHandler(this.textBox_dw800SaveTime_TextChanged);
            // 
            // radioButton_Per800SaveTime
            // 
            this.radioButton_Per800SaveTime.AutoSize = true;
            this.radioButton_Per800SaveTime.Location = new System.Drawing.Point(21, 60);
            this.radioButton_Per800SaveTime.Name = "radioButton_Per800SaveTime";
            this.radioButton_Per800SaveTime.Size = new System.Drawing.Size(176, 22);
            this.radioButton_Per800SaveTime.TabIndex = 12;
            this.radioButton_Per800SaveTime.Text = "选择存储间隔（分钟）";
            this.radioButton_Per800SaveTime.UseVisualStyleBackColor = true;
            // 
            // radioButton_Pin800SaveTime
            // 
            this.radioButton_Pin800SaveTime.AutoSize = true;
            this.radioButton_Pin800SaveTime.Checked = true;
            this.radioButton_Pin800SaveTime.Location = new System.Drawing.Point(21, 23);
            this.radioButton_Pin800SaveTime.Name = "radioButton_Pin800SaveTime";
            this.radioButton_Pin800SaveTime.Size = new System.Drawing.Size(146, 22);
            this.radioButton_Pin800SaveTime.TabIndex = 0;
            this.radioButton_Pin800SaveTime.TabStop = true;
            this.radioButton_Pin800SaveTime.Text = "选择固定存储时间";
            this.radioButton_Pin800SaveTime.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker_dw800SaveTime
            // 
            this.dateTimePicker_dw800SaveTime.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dateTimePicker_dw800SaveTime.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(25)))), ((int)(((byte)(91)))));
            this.dateTimePicker_dw800SaveTime.CustomFormat = "HH:mm:ss";
            this.dateTimePicker_dw800SaveTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_dw800SaveTime.Location = new System.Drawing.Point(254, 22);
            this.dateTimePicker_dw800SaveTime.Name = "dateTimePicker_dw800SaveTime";
            this.dateTimePicker_dw800SaveTime.Size = new System.Drawing.Size(144, 24);
            this.dateTimePicker_dw800SaveTime.TabIndex = 11;
            // 
            // groupBox_dw800
            // 
            this.groupBox_dw800.BackColor = System.Drawing.Color.White;
            this.groupBox_dw800.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_dw800.ForeColor = System.Drawing.Color.Black;
            this.groupBox_dw800.Location = new System.Drawing.Point(3, 3);
            this.groupBox_dw800.Name = "groupBox_dw800";
            this.groupBox_dw800.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox_dw800.Size = new System.Drawing.Size(1252, 284);
            this.groupBox_dw800.TabIndex = 1;
            this.groupBox_dw800.TabStop = false;
            this.groupBox_dw800.Text = "请勾选需要导出报表的字段";
            // 
            // button_dw800Save
            // 
            this.button_dw800Save.BackColor = System.Drawing.Color.White;
            this.button_dw800Save.FlatAppearance.BorderSize = 0;
            this.button_dw800Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_dw800Save.ForeColor = System.Drawing.Color.Black;
            this.button_dw800Save.Location = new System.Drawing.Point(702, 479);
            this.button_dw800Save.Name = "button_dw800Save";
            this.button_dw800Save.Size = new System.Drawing.Size(75, 26);
            this.button_dw800Save.TabIndex = 5;
            this.button_dw800Save.Text = "保存";
            this.button_dw800Save.UseVisualStyleBackColor = false;
            this.button_dw800Save.Click += new System.EventHandler(this.button_dw800Save_Click);
            // 
            // button_dw800cancelAll
            // 
            this.button_dw800cancelAll.BackColor = System.Drawing.Color.White;
            this.button_dw800cancelAll.FlatAppearance.BorderSize = 0;
            this.button_dw800cancelAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_dw800cancelAll.ForeColor = System.Drawing.Color.Black;
            this.button_dw800cancelAll.Location = new System.Drawing.Point(122, 299);
            this.button_dw800cancelAll.Name = "button_dw800cancelAll";
            this.button_dw800cancelAll.Size = new System.Drawing.Size(75, 26);
            this.button_dw800cancelAll.TabIndex = 4;
            this.button_dw800cancelAll.Text = "反选";
            this.button_dw800cancelAll.UseVisualStyleBackColor = false;
            this.button_dw800cancelAll.Click += new System.EventHandler(this.button_dw800cancelAll_Click);
            // 
            // button_dw800selectAll
            // 
            this.button_dw800selectAll.BackColor = System.Drawing.Color.White;
            this.button_dw800selectAll.FlatAppearance.BorderSize = 0;
            this.button_dw800selectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_dw800selectAll.ForeColor = System.Drawing.Color.Black;
            this.button_dw800selectAll.Location = new System.Drawing.Point(9, 299);
            this.button_dw800selectAll.Name = "button_dw800selectAll";
            this.button_dw800selectAll.Size = new System.Drawing.Size(75, 26);
            this.button_dw800selectAll.TabIndex = 3;
            this.button_dw800selectAll.Text = "全选";
            this.button_dw800selectAll.UseVisualStyleBackColor = false;
            this.button_dw800selectAll.Click += new System.EventHandler(this.button_dw800selectAll_Click);
            // 
            // tabPage8
            // 
            this.tabPage8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(166)))), ((int)(((byte)(171)))));
            this.tabPage8.Controls.Add(this.groupBox6);
            this.tabPage8.Controls.Add(this.groupBox5);
            this.tabPage8.Controls.Add(this.button_dw900Save);
            this.tabPage8.Controls.Add(this.button_dw900cancelAll);
            this.tabPage8.Controls.Add(this.button_dw900selectAll);
            this.tabPage8.Controls.Add(this.groupBox_dw900);
            this.tabPage8.Location = new System.Drawing.Point(4, 27);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(1258, 511);
            this.tabPage8.TabIndex = 1;
            this.tabPage8.Text = "ID900";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.textBox_dw900SaveTime);
            this.groupBox6.Controls.Add(this.radioButton_Per900SaveTime);
            this.groupBox6.Controls.Add(this.radioButton_Pin900SaveTime);
            this.groupBox6.Controls.Add(this.dateTimePicker_dw900SaveTime);
            this.groupBox6.ForeColor = System.Drawing.Color.White;
            this.groupBox6.Location = new System.Drawing.Point(9, 408);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(659, 99);
            this.groupBox6.TabIndex = 18;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "存储时间模式选择";
            // 
            // textBox_dw900SaveTime
            // 
            this.textBox_dw900SaveTime.Location = new System.Drawing.Point(244, 61);
            this.textBox_dw900SaveTime.Name = "textBox_dw900SaveTime";
            this.textBox_dw900SaveTime.Size = new System.Drawing.Size(144, 24);
            this.textBox_dw900SaveTime.TabIndex = 17;
            this.toolTip1.SetToolTip(this.textBox_dw900SaveTime, "请输入大于1的整数！");
            this.textBox_dw900SaveTime.TextChanged += new System.EventHandler(this.textBox_dw800SaveTime_TextChanged);
            // 
            // radioButton_Per900SaveTime
            // 
            this.radioButton_Per900SaveTime.AutoSize = true;
            this.radioButton_Per900SaveTime.Location = new System.Drawing.Point(6, 63);
            this.radioButton_Per900SaveTime.Name = "radioButton_Per900SaveTime";
            this.radioButton_Per900SaveTime.Size = new System.Drawing.Size(176, 22);
            this.radioButton_Per900SaveTime.TabIndex = 14;
            this.radioButton_Per900SaveTime.Text = "选择存储间隔（分钟）";
            this.radioButton_Per900SaveTime.UseVisualStyleBackColor = true;
            // 
            // radioButton_Pin900SaveTime
            // 
            this.radioButton_Pin900SaveTime.AutoSize = true;
            this.radioButton_Pin900SaveTime.Checked = true;
            this.radioButton_Pin900SaveTime.Location = new System.Drawing.Point(6, 26);
            this.radioButton_Pin900SaveTime.Name = "radioButton_Pin900SaveTime";
            this.radioButton_Pin900SaveTime.Size = new System.Drawing.Size(146, 22);
            this.radioButton_Pin900SaveTime.TabIndex = 13;
            this.radioButton_Pin900SaveTime.TabStop = true;
            this.radioButton_Pin900SaveTime.Text = "选择固定存储时间";
            this.radioButton_Pin900SaveTime.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker_dw900SaveTime
            // 
            this.dateTimePicker_dw900SaveTime.CustomFormat = "HH:mm:ss";
            this.dateTimePicker_dw900SaveTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_dw900SaveTime.Location = new System.Drawing.Point(244, 26);
            this.dateTimePicker_dw900SaveTime.Name = "dateTimePicker_dw900SaveTime";
            this.dateTimePicker_dw900SaveTime.Size = new System.Drawing.Size(144, 24);
            this.dateTimePicker_dw900SaveTime.TabIndex = 16;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox_dw900SavePath);
            this.groupBox5.Controls.Add(this.button2);
            this.groupBox5.ForeColor = System.Drawing.Color.White;
            this.groupBox5.Location = new System.Drawing.Point(9, 336);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(659, 66);
            this.groupBox5.TabIndex = 17;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "选择固定存储路径";
            // 
            // textBox_dw900SavePath
            // 
            this.textBox_dw900SavePath.ForeColor = System.Drawing.Color.Black;
            this.textBox_dw900SavePath.Location = new System.Drawing.Point(8, 27);
            this.textBox_dw900SavePath.Name = "textBox_dw900SavePath";
            this.textBox_dw900SavePath.Size = new System.Drawing.Size(558, 24);
            this.textBox_dw900SavePath.TabIndex = 14;
            this.textBox_dw900SavePath.Text = "C:\\\\VCAM\\\\SalesFeedBackMain\\\\";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(572, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 26);
            this.button2.TabIndex = 13;
            this.button2.Text = "选择";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_dw900Save
            // 
            this.button_dw900Save.BackColor = System.Drawing.Color.White;
            this.button_dw900Save.FlatAppearance.BorderSize = 0;
            this.button_dw900Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_dw900Save.ForeColor = System.Drawing.Color.Black;
            this.button_dw900Save.Location = new System.Drawing.Point(684, 479);
            this.button_dw900Save.Name = "button_dw900Save";
            this.button_dw900Save.Size = new System.Drawing.Size(75, 26);
            this.button_dw900Save.TabIndex = 8;
            this.button_dw900Save.Text = "保存";
            this.button_dw900Save.UseVisualStyleBackColor = false;
            this.button_dw900Save.Click += new System.EventHandler(this.button_dw900Save_Click);
            // 
            // button_dw900cancelAll
            // 
            this.button_dw900cancelAll.BackColor = System.Drawing.Color.White;
            this.button_dw900cancelAll.FlatAppearance.BorderSize = 0;
            this.button_dw900cancelAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_dw900cancelAll.ForeColor = System.Drawing.Color.Black;
            this.button_dw900cancelAll.Location = new System.Drawing.Point(122, 301);
            this.button_dw900cancelAll.Name = "button_dw900cancelAll";
            this.button_dw900cancelAll.Size = new System.Drawing.Size(75, 26);
            this.button_dw900cancelAll.TabIndex = 7;
            this.button_dw900cancelAll.Text = "反选";
            this.button_dw900cancelAll.UseVisualStyleBackColor = false;
            this.button_dw900cancelAll.Click += new System.EventHandler(this.button_dw900cancelAll_Click);
            // 
            // button_dw900selectAll
            // 
            this.button_dw900selectAll.BackColor = System.Drawing.Color.White;
            this.button_dw900selectAll.FlatAppearance.BorderSize = 0;
            this.button_dw900selectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_dw900selectAll.ForeColor = System.Drawing.Color.Black;
            this.button_dw900selectAll.Location = new System.Drawing.Point(9, 301);
            this.button_dw900selectAll.Name = "button_dw900selectAll";
            this.button_dw900selectAll.Size = new System.Drawing.Size(75, 26);
            this.button_dw900selectAll.TabIndex = 6;
            this.button_dw900selectAll.Text = "全选";
            this.button_dw900selectAll.UseVisualStyleBackColor = false;
            this.button_dw900selectAll.Click += new System.EventHandler(this.button_dw900selectAll_Click);
            // 
            // groupBox_dw900
            // 
            this.groupBox_dw900.BackColor = System.Drawing.Color.White;
            this.groupBox_dw900.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_dw900.ForeColor = System.Drawing.Color.Black;
            this.groupBox_dw900.Location = new System.Drawing.Point(3, 3);
            this.groupBox_dw900.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox_dw900.Name = "groupBox_dw900";
            this.groupBox_dw900.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox_dw900.Size = new System.Drawing.Size(1252, 287);
            this.groupBox_dw900.TabIndex = 2;
            this.groupBox_dw900.TabStop = false;
            this.groupBox_dw900.Text = "请勾选需要导出报表的字段";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(166)))), ((int)(((byte)(171)))));
            this.tabPage3.Controls.Add(this.richTextBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1272, 548);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "查看log";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.ContextMenuStrip = this.contextMenuLog;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.ForeColor = System.Drawing.Color.Black;
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1266, 542);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
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
            // tabPage9
            // 
            this.tabPage9.BackColor = System.Drawing.Color.White;
            this.tabPage9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabPage9.Controls.Add(this.lbMessage);
            this.tabPage9.Controls.Add(this.lbDw900state);
            this.tabPage9.Controls.Add(this.lbDw800state);
            this.tabPage9.Controls.Add(this.btnDw900Stop);
            this.tabPage9.Controls.Add(this.btnDw900Start);
            this.tabPage9.Controls.Add(this.btnDw800Uninstall);
            this.tabPage9.Controls.Add(this.btnDw800Stop);
            this.tabPage9.Controls.Add(this.btnDw800Start);
            this.tabPage9.Controls.Add(this.btnDw800Install);
            this.tabPage9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage9.Location = new System.Drawing.Point(4, 34);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(1272, 548);
            this.tabPage9.TabIndex = 4;
            this.tabPage9.Text = "windows服务管理";
            // 
            // lbMessage
            // 
            this.lbMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbMessage.AutoSize = true;
            this.lbMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMessage.ForeColor = System.Drawing.Color.Blue;
            this.lbMessage.Location = new System.Drawing.Point(8, 503);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(229, 31);
            this.lbMessage.TabIndex = 8;
            this.lbMessage.Text = "ServiceMessage";
            this.lbMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbDw900state
            // 
            this.lbDw900state.AutoSize = true;
            this.lbDw900state.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDw900state.ForeColor = System.Drawing.Color.Red;
            this.lbDw900state.Location = new System.Drawing.Point(409, 347);
            this.lbDw900state.Name = "lbDw900state";
            this.lbDw900state.Size = new System.Drawing.Size(125, 25);
            this.lbDw900state.TabIndex = 7;
            this.lbDw900state.Text = "ID900state";
            // 
            // lbDw800state
            // 
            this.lbDw800state.AutoSize = true;
            this.lbDw800state.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDw800state.ForeColor = System.Drawing.Color.Red;
            this.lbDw800state.Location = new System.Drawing.Point(409, 228);
            this.lbDw800state.Name = "lbDw800state";
            this.lbDw800state.Size = new System.Drawing.Size(135, 25);
            this.lbDw800state.TabIndex = 6;
            this.lbDw800state.Text = "Dw800state";
            // 
            // btnDw900Stop
            // 
            this.btnDw900Stop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(166)))), ((int)(((byte)(171)))));
            this.btnDw900Stop.FlatAppearance.BorderSize = 0;
            this.btnDw900Stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDw900Stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDw900Stop.ForeColor = System.Drawing.Color.White;
            this.btnDw900Stop.Location = new System.Drawing.Point(245, 328);
            this.btnDw900Stop.Name = "btnDw900Stop";
            this.btnDw900Stop.Size = new System.Drawing.Size(120, 65);
            this.btnDw900Stop.TabIndex = 5;
            this.btnDw900Stop.Text = "停止ID900";
            this.btnDw900Stop.UseVisualStyleBackColor = false;
            // 
            // btnDw900Start
            // 
            this.btnDw900Start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(166)))), ((int)(((byte)(171)))));
            this.btnDw900Start.FlatAppearance.BorderSize = 0;
            this.btnDw900Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDw900Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDw900Start.ForeColor = System.Drawing.Color.White;
            this.btnDw900Start.Location = new System.Drawing.Point(71, 328);
            this.btnDw900Start.Name = "btnDw900Start";
            this.btnDw900Start.Size = new System.Drawing.Size(120, 65);
            this.btnDw900Start.TabIndex = 4;
            this.btnDw900Start.Text = "启动ID900";
            this.btnDw900Start.UseVisualStyleBackColor = false;
            // 
            // btnDw800Uninstall
            // 
            this.btnDw800Uninstall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(166)))), ((int)(((byte)(171)))));
            this.btnDw800Uninstall.FlatAppearance.BorderSize = 0;
            this.btnDw800Uninstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDw800Uninstall.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDw800Uninstall.ForeColor = System.Drawing.Color.White;
            this.btnDw800Uninstall.Location = new System.Drawing.Point(245, 91);
            this.btnDw800Uninstall.Name = "btnDw800Uninstall";
            this.btnDw800Uninstall.Size = new System.Drawing.Size(120, 65);
            this.btnDw800Uninstall.TabIndex = 1;
            this.btnDw800Uninstall.Text = "卸载服务";
            this.btnDw800Uninstall.UseVisualStyleBackColor = false;
            // 
            // btnDw800Stop
            // 
            this.btnDw800Stop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(166)))), ((int)(((byte)(171)))));
            this.btnDw800Stop.FlatAppearance.BorderSize = 0;
            this.btnDw800Stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDw800Stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDw800Stop.ForeColor = System.Drawing.Color.White;
            this.btnDw800Stop.Location = new System.Drawing.Point(245, 209);
            this.btnDw800Stop.Name = "btnDw800Stop";
            this.btnDw800Stop.Size = new System.Drawing.Size(120, 65);
            this.btnDw800Stop.TabIndex = 3;
            this.btnDw800Stop.Text = "停止Dw800";
            this.btnDw800Stop.UseVisualStyleBackColor = false;
            // 
            // btnDw800Start
            // 
            this.btnDw800Start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(166)))), ((int)(((byte)(171)))));
            this.btnDw800Start.FlatAppearance.BorderSize = 0;
            this.btnDw800Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDw800Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDw800Start.ForeColor = System.Drawing.Color.White;
            this.btnDw800Start.Location = new System.Drawing.Point(71, 209);
            this.btnDw800Start.Name = "btnDw800Start";
            this.btnDw800Start.Size = new System.Drawing.Size(120, 65);
            this.btnDw800Start.TabIndex = 2;
            this.btnDw800Start.Text = "启动Dw800";
            this.btnDw800Start.UseVisualStyleBackColor = false;
            // 
            // btnDw800Install
            // 
            this.btnDw800Install.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(166)))), ((int)(((byte)(171)))));
            this.btnDw800Install.FlatAppearance.BorderSize = 0;
            this.btnDw800Install.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDw800Install.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDw800Install.ForeColor = System.Drawing.Color.White;
            this.btnDw800Install.Location = new System.Drawing.Point(71, 91);
            this.btnDw800Install.Name = "btnDw800Install";
            this.btnDw800Install.Size = new System.Drawing.Size(120, 65);
            this.btnDw800Install.TabIndex = 0;
            this.btnDw800Install.Text = "安装服务";
            this.btnDw800Install.UseVisualStyleBackColor = false;
            this.btnDw800Install.Click += new System.EventHandler(this.btnDwInstall_Click);
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
            this.pnl_header.Size = new System.Drawing.Size(1280, 98);
            this.pnl_header.TabIndex = 2;
            // 
            // pnl_minimizeAndClose
            // 
            this.pnl_minimizeAndClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(166)))), ((int)(((byte)(171)))));
            this.pnl_minimizeAndClose.Controls.Add(this.btn_close);
            this.pnl_minimizeAndClose.Controls.Add(this.btn_minimize);
            this.pnl_minimizeAndClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_minimizeAndClose.Location = new System.Drawing.Point(1173, 0);
            this.pnl_minimizeAndClose.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
            this.pnl_minimizeAndClose.Name = "pnl_minimizeAndClose";
            this.pnl_minimizeAndClose.Size = new System.Drawing.Size(107, 98);
            this.pnl_minimizeAndClose.TabIndex = 1;
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.Red;
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_close.ForeColor = System.Drawing.Color.White;
            this.btn_close.Location = new System.Drawing.Point(59, 34);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(36, 39);
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
            this.btn_minimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_minimize.ForeColor = System.Drawing.Color.Black;
            this.btn_minimize.Location = new System.Drawing.Point(3, 34);
            this.btn_minimize.Name = "btn_minimize";
            this.btn_minimize.Size = new System.Drawing.Size(36, 39);
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
            this.pnl_title.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.pnl_title.Name = "pnl_title";
            this.pnl_title.Size = new System.Drawing.Size(1280, 98);
            this.pnl_title.TabIndex = 0;
            this.pnl_title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnl_titile_MouseDown);
            this.pnl_title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_titile_MouseMove);
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 27F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_title.ForeColor = System.Drawing.Color.White;
            this.lbl_title.Location = new System.Drawing.Point(197, 41);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(350, 40);
            this.lbl_title.TabIndex = 1;
            this.lbl_title.Text = "设备保养与维修服务";
            // 
            // pb_icon
            // 
            this.pb_icon.Image = global::SalesFeedbackSetting.Properties.Resources.Logo;
            this.pb_icon.InitialImage = ((System.Drawing.Image)(resources.GetObject("pb_icon.InitialImage")));
            this.pb_icon.Location = new System.Drawing.Point(8, 13);
            this.pb_icon.Name = "pb_icon";
            this.pb_icon.Size = new System.Drawing.Size(174, 70);
            this.pb_icon.TabIndex = 0;
            this.pb_icon.TabStop = false;
            // 
            // contextMenuDevice
            // 
            this.contextMenuDevice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建设备ToolStripMenuItem});
            this.contextMenuDevice.Name = "contextMenuDevice";
            this.contextMenuDevice.Size = new System.Drawing.Size(127, 26);
            // 
            // 新建设备ToolStripMenuItem
            // 
            this.新建设备ToolStripMenuItem.Name = "新建设备ToolStripMenuItem";
            this.新建设备ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.新建设备ToolStripMenuItem.Text = "新建设备";
            // 
            // SalesFeedBackMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(166)))), ((int)(((byte)(171)))));
            this.ClientSize = new System.Drawing.Size(1280, 684);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pnl_header);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SalesFeedBackMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SalesFeedBackMainSettings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.contextMenuLog.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            this.tabPage9.PerformLayout();
            this.pnl_header.ResumeLayout(false);
            this.pnl_minimizeAndClose.ResumeLayout(false);
            this.pnl_title.ResumeLayout(false);
            this.pnl_title.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_icon)).EndInit();
            this.contextMenuDevice.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.GroupBox groupBox_dw800;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.GroupBox groupBox_dw900;
        private System.Windows.Forms.Button button_dw800Save;
        private System.Windows.Forms.Button button_dw800cancelAll;
        private System.Windows.Forms.Button button_dw800selectAll;
        private System.Windows.Forms.Button button_dw900Save;
        private System.Windows.Forms.Button button_dw900cancelAll;
        private System.Windows.Forms.Button button_dw900selectAll;
        private System.Windows.Forms.DateTimePicker dateTimePicker_dw800SaveTime;
        private System.Windows.Forms.TextBox textBox_dw800SavePath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_dw900SaveTime;
        private System.Windows.Forms.TextBox textBox_dw900SavePath;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ContextMenuStrip contextMenuLog;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.Button btnDw800Uninstall;
        private System.Windows.Forms.Button btnDw800Stop;
        private System.Windows.Forms.Button btnDw800Start;
        private System.Windows.Forms.Button btnDw800Install;
        private System.Windows.Forms.Button btnDw900Stop;
        private System.Windows.Forms.Button btnDw900Start;
        private System.Windows.Forms.Label lbDw900state;
        private System.Windows.Forms.Label lbDw800state;
        private System.Windows.Forms.Panel pnl_header;
        private System.Windows.Forms.Panel pnl_minimizeAndClose;
        private System.Windows.Forms.Panel pnl_title;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.PictureBox pb_icon;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_minimize;
        private System.Windows.Forms.ToolStripMenuItem 清空日志ToolStripMenuItem;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_dw800SaveTime;
        private System.Windows.Forms.RadioButton radioButton_Per800SaveTime;
        private System.Windows.Forms.RadioButton radioButton_Pin800SaveTime;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox textBox_dw900SaveTime;
        private System.Windows.Forms.RadioButton radioButton_Per900SaveTime;
        private System.Windows.Forms.RadioButton radioButton_Pin900SaveTime;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuDevice;
        private System.Windows.Forms.ToolStripMenuItem 新建设备ToolStripMenuItem;
    }
}


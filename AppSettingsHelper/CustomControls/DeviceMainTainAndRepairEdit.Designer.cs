
namespace AppSettingsHelper.CustomControls
{
    partial class DeviceMainTainAndRepairEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbl_title = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.gbxContainer1 = new System.Windows.Forms.GroupBox();
            this.lbl_error = new System.Windows.Forms.Label();
            this.tbx_maintainId = new System.Windows.Forms.TextBox();
            this.lbl_maintainId = new System.Windows.Forms.Label();
            this.dtime_maintainTime = new System.Windows.Forms.DateTimePicker();
            this.txt_maintainDescription = new System.Windows.Forms.TextBox();
            this.lbl_maintainDescription = new System.Windows.Forms.Label();
            this.lbl_maintainTime = new System.Windows.Forms.Label();
            this.txt_maintainOperator = new System.Windows.Forms.TextBox();
            this.lbl_maintainOperator = new System.Windows.Forms.Label();
            this.groupBoxMain = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_Close = new AppSettingsHelper.UCBtnExt();
            this.btn_Save = new AppSettingsHelper.UCBtnExt();
            this.btn_Cancel = new AppSettingsHelper.UCBtnExt();
            this.button1 = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pcb_PartImage4 = new System.Windows.Forms.PictureBox();
            this.pcb_PartImage2 = new System.Windows.Forms.PictureBox();
            this.pcb_PartImage3 = new System.Windows.Forms.PictureBox();
            this.pcb_PartImage1 = new System.Windows.Forms.PictureBox();
            this.btn_Translate = new AppSettingsHelper.UCBtnExt();
            this.btn_Clear = new AppSettingsHelper.UCBtnExt();
            this.btnAdd = new AppSettingsHelper.UCBtnExt();
            this.pcb_PartImage = new System.Windows.Forms.PictureBox();
            this.lbl_PartImage = new System.Windows.Forms.Label();
            this.gbxContainer1.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_PartImage4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_PartImage2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_PartImage3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_PartImage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_PartImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Microsoft YaHei", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_title.Location = new System.Drawing.Point(18, 11);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(120, 25);
            this.lbl_title.TabIndex = 10;
            this.lbl_title.Text = "保养明细新增";
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label15.Location = new System.Drawing.Point(2, 2);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(10, 43);
            this.label15.TabIndex = 9;
            // 
            // gbxContainer1
            // 
            this.gbxContainer1.Controls.Add(this.pcb_PartImage4);
            this.gbxContainer1.Controls.Add(this.pcb_PartImage2);
            this.gbxContainer1.Controls.Add(this.pcb_PartImage3);
            this.gbxContainer1.Controls.Add(this.pcb_PartImage1);
            this.gbxContainer1.Controls.Add(this.btn_Translate);
            this.gbxContainer1.Controls.Add(this.btn_Clear);
            this.gbxContainer1.Controls.Add(this.btnAdd);
            this.gbxContainer1.Controls.Add(this.pcb_PartImage);
            this.gbxContainer1.Controls.Add(this.lbl_PartImage);
            this.gbxContainer1.Controls.Add(this.lbl_error);
            this.gbxContainer1.Controls.Add(this.tbx_maintainId);
            this.gbxContainer1.Controls.Add(this.lbl_maintainId);
            this.gbxContainer1.Controls.Add(this.dtime_maintainTime);
            this.gbxContainer1.Controls.Add(this.txt_maintainDescription);
            this.gbxContainer1.Controls.Add(this.lbl_maintainDescription);
            this.gbxContainer1.Controls.Add(this.lbl_maintainTime);
            this.gbxContainer1.Controls.Add(this.txt_maintainOperator);
            this.gbxContainer1.Controls.Add(this.lbl_maintainOperator);
            this.gbxContainer1.Location = new System.Drawing.Point(7, 265);
            this.gbxContainer1.Name = "gbxContainer1";
            this.gbxContainer1.Size = new System.Drawing.Size(868, 241);
            this.gbxContainer1.TabIndex = 15;
            this.gbxContainer1.TabStop = false;
            // 
            // lbl_error
            // 
            this.lbl_error.AutoSize = true;
            this.lbl_error.ForeColor = System.Drawing.Color.Red;
            this.lbl_error.Location = new System.Drawing.Point(93, 9);
            this.lbl_error.Name = "lbl_error";
            this.lbl_error.Size = new System.Drawing.Size(12, 15);
            this.lbl_error.TabIndex = 19;
            this.lbl_error.Text = "*";
            // 
            // tbx_maintainId
            // 
            this.tbx_maintainId.Location = new System.Drawing.Point(110, 5);
            this.tbx_maintainId.Name = "tbx_maintainId";
            this.tbx_maintainId.Size = new System.Drawing.Size(257, 23);
            this.tbx_maintainId.TabIndex = 18;
            // 
            // lbl_maintainId
            // 
            this.lbl_maintainId.AutoSize = true;
            this.lbl_maintainId.Location = new System.Drawing.Point(49, 9);
            this.lbl_maintainId.Name = "lbl_maintainId";
            this.lbl_maintainId.Size = new System.Drawing.Size(44, 15);
            this.lbl_maintainId.TabIndex = 17;
            this.lbl_maintainId.Text = "保养ID";
            // 
            // dtime_maintainTime
            // 
            this.dtime_maintainTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtime_maintainTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtime_maintainTime.Location = new System.Drawing.Point(110, 77);
            this.dtime_maintainTime.Name = "dtime_maintainTime";
            this.dtime_maintainTime.Size = new System.Drawing.Size(257, 23);
            this.dtime_maintainTime.TabIndex = 8;
            // 
            // txt_maintainDescription
            // 
            this.txt_maintainDescription.Location = new System.Drawing.Point(110, 117);
            this.txt_maintainDescription.Multiline = true;
            this.txt_maintainDescription.Name = "txt_maintainDescription";
            this.txt_maintainDescription.Size = new System.Drawing.Size(257, 108);
            this.txt_maintainDescription.TabIndex = 5;
            // 
            // lbl_maintainDescription
            // 
            this.lbl_maintainDescription.AutoSize = true;
            this.lbl_maintainDescription.Location = new System.Drawing.Point(8, 117);
            this.lbl_maintainDescription.Name = "lbl_maintainDescription";
            this.lbl_maintainDescription.Size = new System.Drawing.Size(85, 15);
            this.lbl_maintainDescription.TabIndex = 4;
            this.lbl_maintainDescription.Text = "保养详细信息";
            // 
            // lbl_maintainTime
            // 
            this.lbl_maintainTime.AutoSize = true;
            this.lbl_maintainTime.Location = new System.Drawing.Point(34, 81);
            this.lbl_maintainTime.Name = "lbl_maintainTime";
            this.lbl_maintainTime.Size = new System.Drawing.Size(59, 15);
            this.lbl_maintainTime.TabIndex = 2;
            this.lbl_maintainTime.Text = "保养时间";
            // 
            // txt_maintainOperator
            // 
            this.txt_maintainOperator.Location = new System.Drawing.Point(110, 41);
            this.txt_maintainOperator.Name = "txt_maintainOperator";
            this.txt_maintainOperator.Size = new System.Drawing.Size(257, 23);
            this.txt_maintainOperator.TabIndex = 1;
            // 
            // lbl_maintainOperator
            // 
            this.lbl_maintainOperator.AutoSize = true;
            this.lbl_maintainOperator.Location = new System.Drawing.Point(34, 45);
            this.lbl_maintainOperator.Name = "lbl_maintainOperator";
            this.lbl_maintainOperator.Size = new System.Drawing.Size(59, 15);
            this.lbl_maintainOperator.TabIndex = 0;
            this.lbl_maintainOperator.Text = "保养人员";
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.dataGridView1);
            this.groupBoxMain.Location = new System.Drawing.Point(7, 48);
            this.groupBoxMain.Name = "groupBoxMain";
            this.groupBoxMain.Size = new System.Drawing.Size(868, 217);
            this.groupBoxMain.TabIndex = 16;
            this.groupBoxMain.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(862, 195);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.White;
            this.btn_Close.BtnBackColor = System.Drawing.Color.White;
            this.btn_Close.BtnFont = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_Close.BtnForeColor = System.Drawing.Color.Black;
            this.btn_Close.BtnText = "关   闭";
            this.btn_Close.ConerRadius = 5;
            this.btn_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Close.EnabledMouseEffect = false;
            this.btn_Close.FillColor = System.Drawing.Color.Silver;
            this.btn_Close.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btn_Close.IsRadius = true;
            this.btn_Close.IsShowRect = false;
            this.btn_Close.IsShowTips = false;
            this.btn_Close.Location = new System.Drawing.Point(398, 519);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(58)))));
            this.btn_Close.RectWidth = 1;
            this.btn_Close.Size = new System.Drawing.Size(102, 33);
            this.btn_Close.TabIndex = 19;
            this.btn_Close.TabStop = false;
            this.btn_Close.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.btn_Close.TipsText = "";
            this.toolTip1.SetToolTip(this.btn_Close, "关闭窗口，保存数据到文件");
            this.btn_Close.BtnClick += new System.EventHandler(this.btn_Close_BtnClick);
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.White;
            this.btn_Save.BtnBackColor = System.Drawing.Color.White;
            this.btn_Save.BtnFont = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_Save.BtnForeColor = System.Drawing.Color.Black;
            this.btn_Save.BtnText = "保   存";
            this.btn_Save.ConerRadius = 5;
            this.btn_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Save.EnabledMouseEffect = false;
            this.btn_Save.FillColor = System.Drawing.Color.Silver;
            this.btn_Save.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btn_Save.IsRadius = true;
            this.btn_Save.IsShowRect = false;
            this.btn_Save.IsShowTips = false;
            this.btn_Save.Location = new System.Drawing.Point(252, 519);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(58)))));
            this.btn_Save.RectWidth = 1;
            this.btn_Save.Size = new System.Drawing.Size(102, 33);
            this.btn_Save.TabIndex = 18;
            this.btn_Save.TabStop = false;
            this.btn_Save.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.btn_Save.TipsText = "";
            this.toolTip1.SetToolTip(this.btn_Save, "保存后可继续添加或修改，此操作不保存到文件");
            this.btn_Save.BtnClick += new System.EventHandler(this.btn_Save_BtnClick);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.White;
            this.btn_Cancel.BtnBackColor = System.Drawing.Color.White;
            this.btn_Cancel.BtnFont = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_Cancel.BtnForeColor = System.Drawing.Color.Black;
            this.btn_Cancel.BtnText = "取   消";
            this.btn_Cancel.ConerRadius = 5;
            this.btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cancel.EnabledMouseEffect = false;
            this.btn_Cancel.FillColor = System.Drawing.Color.Silver;
            this.btn_Cancel.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btn_Cancel.IsRadius = true;
            this.btn_Cancel.IsShowRect = false;
            this.btn_Cancel.IsShowTips = false;
            this.btn_Cancel.Location = new System.Drawing.Point(543, 519);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(58)))));
            this.btn_Cancel.RectWidth = 1;
            this.btn_Cancel.Size = new System.Drawing.Size(102, 33);
            this.btn_Cancel.TabIndex = 20;
            this.btn_Cancel.TabStop = false;
            this.btn_Cancel.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.btn_Cancel.TipsText = "";
            this.toolTip1.SetToolTip(this.btn_Cancel, "关闭窗口，丢弃修改的数据");
            this.btn_Cancel.BtnClick += new System.EventHandler(this.btn_Cancel_BtnClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Brown;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(833, 7);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 32);
            this.button1.TabIndex = 21;
            this.button1.Text = "×";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btn_Cancel_BtnClick);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pcb_PartImage4
            // 
            this.pcb_PartImage4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcb_PartImage4.Location = new System.Drawing.Point(702, 188);
            this.pcb_PartImage4.Name = "pcb_PartImage4";
            this.pcb_PartImage4.Size = new System.Drawing.Size(57, 50);
            this.pcb_PartImage4.TabIndex = 66;
            this.pcb_PartImage4.TabStop = false;
            this.pcb_PartImage4.Click += new System.EventHandler(this.pcb_PartImage1_Click);
            // 
            // pcb_PartImage2
            // 
            this.pcb_PartImage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcb_PartImage2.Location = new System.Drawing.Point(572, 188);
            this.pcb_PartImage2.Name = "pcb_PartImage2";
            this.pcb_PartImage2.Size = new System.Drawing.Size(57, 50);
            this.pcb_PartImage2.TabIndex = 65;
            this.pcb_PartImage2.TabStop = false;
            this.pcb_PartImage2.Click += new System.EventHandler(this.pcb_PartImage1_Click);
            // 
            // pcb_PartImage3
            // 
            this.pcb_PartImage3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcb_PartImage3.Location = new System.Drawing.Point(637, 188);
            this.pcb_PartImage3.Name = "pcb_PartImage3";
            this.pcb_PartImage3.Size = new System.Drawing.Size(57, 50);
            this.pcb_PartImage3.TabIndex = 64;
            this.pcb_PartImage3.TabStop = false;
            this.pcb_PartImage3.Click += new System.EventHandler(this.pcb_PartImage1_Click);
            // 
            // pcb_PartImage1
            // 
            this.pcb_PartImage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcb_PartImage1.Location = new System.Drawing.Point(507, 188);
            this.pcb_PartImage1.Name = "pcb_PartImage1";
            this.pcb_PartImage1.Size = new System.Drawing.Size(57, 50);
            this.pcb_PartImage1.TabIndex = 63;
            this.pcb_PartImage1.TabStop = false;
            this.pcb_PartImage1.Click += new System.EventHandler(this.pcb_PartImage1_Click);
            // 
            // btn_Translate
            // 
            this.btn_Translate.BackColor = System.Drawing.Color.White;
            this.btn_Translate.BtnBackColor = System.Drawing.Color.White;
            this.btn_Translate.BtnFont = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_Translate.BtnForeColor = System.Drawing.Color.Black;
            this.btn_Translate.BtnText = "旋  转";
            this.btn_Translate.ConerRadius = 5;
            this.btn_Translate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Translate.EnabledMouseEffect = false;
            this.btn_Translate.FillColor = System.Drawing.Color.Silver;
            this.btn_Translate.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btn_Translate.IsRadius = true;
            this.btn_Translate.IsShowRect = false;
            this.btn_Translate.IsShowTips = false;
            this.btn_Translate.Location = new System.Drawing.Point(772, 87);
            this.btn_Translate.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Translate.Name = "btn_Translate";
            this.btn_Translate.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(58)))));
            this.btn_Translate.RectWidth = 1;
            this.btn_Translate.Size = new System.Drawing.Size(73, 23);
            this.btn_Translate.TabIndex = 61;
            this.btn_Translate.TabStop = false;
            this.btn_Translate.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.btn_Translate.TipsText = "";
            this.btn_Translate.BtnClick += new System.EventHandler(this.btn_Translate_BtnClick);
            // 
            // btn_Clear
            // 
            this.btn_Clear.BackColor = System.Drawing.Color.White;
            this.btn_Clear.BtnBackColor = System.Drawing.Color.White;
            this.btn_Clear.BtnFont = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_Clear.BtnForeColor = System.Drawing.Color.Black;
            this.btn_Clear.BtnText = "清  除";
            this.btn_Clear.ConerRadius = 5;
            this.btn_Clear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Clear.EnabledMouseEffect = false;
            this.btn_Clear.FillColor = System.Drawing.Color.Silver;
            this.btn_Clear.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btn_Clear.IsRadius = true;
            this.btn_Clear.IsShowRect = false;
            this.btn_Clear.IsShowTips = false;
            this.btn_Clear.Location = new System.Drawing.Point(772, 46);
            this.btn_Clear.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(58)))));
            this.btn_Clear.RectWidth = 1;
            this.btn_Clear.Size = new System.Drawing.Size(73, 23);
            this.btn_Clear.TabIndex = 62;
            this.btn_Clear.TabStop = false;
            this.btn_Clear.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.btn_Clear.TipsText = "";
            this.btn_Clear.BtnClick += new System.EventHandler(this.btn_Clear_BtnClick);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.BtnBackColor = System.Drawing.Color.White;
            this.btnAdd.BtnFont = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAdd.BtnForeColor = System.Drawing.Color.Black;
            this.btnAdd.BtnText = "添  加";
            this.btnAdd.ConerRadius = 5;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.EnabledMouseEffect = false;
            this.btnAdd.FillColor = System.Drawing.Color.Silver;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnAdd.IsRadius = true;
            this.btnAdd.IsShowRect = false;
            this.btnAdd.IsShowTips = false;
            this.btnAdd.Location = new System.Drawing.Point(772, 5);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(58)))));
            this.btnAdd.RectWidth = 1;
            this.btnAdd.Size = new System.Drawing.Size(73, 23);
            this.btnAdd.TabIndex = 60;
            this.btnAdd.TabStop = false;
            this.btnAdd.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.btnAdd.TipsText = "";
            this.btnAdd.BtnClick += new System.EventHandler(this.btnPathSelect_BtnClick);
            // 
            // pcb_PartImage
            // 
            this.pcb_PartImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcb_PartImage.Location = new System.Drawing.Point(507, 5);
            this.pcb_PartImage.Name = "pcb_PartImage";
            this.pcb_PartImage.Size = new System.Drawing.Size(253, 175);
            this.pcb_PartImage.TabIndex = 59;
            this.pcb_PartImage.TabStop = false;
            // 
            // lbl_PartImage
            // 
            this.lbl_PartImage.AutoSize = true;
            this.lbl_PartImage.Location = new System.Drawing.Point(424, 5);
            this.lbl_PartImage.Name = "lbl_PartImage";
            this.lbl_PartImage.Size = new System.Drawing.Size(59, 15);
            this.lbl_PartImage.TabIndex = 58;
            this.lbl_PartImage.Text = "保养图片";
            // 
            // DeviceMainTainAndRepairEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(881, 564);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.groupBoxMain);
            this.Controls.Add(this.gbxContainer1);
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.label15);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DeviceMainTainAndRepairEdit";
            this.Text = "DeviceMainTainAndRepairEdit";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Control_MouseMove);
            this.gbxContainer1.ResumeLayout(false);
            this.gbxContainer1.PerformLayout();
            this.groupBoxMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_PartImage4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_PartImage2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_PartImage3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_PartImage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_PartImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox gbxContainer1;
        private System.Windows.Forms.DateTimePicker dtime_maintainTime;
        private System.Windows.Forms.TextBox txt_maintainDescription;
        private System.Windows.Forms.Label lbl_maintainDescription;
        private System.Windows.Forms.Label lbl_maintainTime;
        private System.Windows.Forms.TextBox txt_maintainOperator;
        private System.Windows.Forms.Label lbl_maintainOperator;
        private System.Windows.Forms.GroupBox groupBoxMain;
        private System.Windows.Forms.DataGridView dataGridView1;
        private UCBtnExt btn_Close;
        private UCBtnExt btn_Save;
        private System.Windows.Forms.TextBox tbx_maintainId;
        private System.Windows.Forms.Label lbl_maintainId;
        private UCBtnExt btn_Cancel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_error;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pcb_PartImage4;
        private System.Windows.Forms.PictureBox pcb_PartImage2;
        private System.Windows.Forms.PictureBox pcb_PartImage3;
        private System.Windows.Forms.PictureBox pcb_PartImage1;
        private UCBtnExt btn_Translate;
        private UCBtnExt btn_Clear;
        private UCBtnExt btnAdd;
        private System.Windows.Forms.PictureBox pcb_PartImage;
        private System.Windows.Forms.Label lbl_PartImage;
    }
}

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
            this.lbl_title = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.gbxContainer1 = new System.Windows.Forms.GroupBox();
            this.tbx_maintainId = new System.Windows.Forms.TextBox();
            this.lbl_maintainId = new System.Windows.Forms.Label();
            this.btnPathSelect = new AppSettingsHelper.UCBtnExt();
            this.dtime_maintainTime = new System.Windows.Forms.DateTimePicker();
            this.txt_maintainImagePath = new System.Windows.Forms.TextBox();
            this.lbl_maintainImagePath = new System.Windows.Forms.Label();
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
            this.gbxContainer1.SuspendLayout();
            this.groupBoxMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.gbxContainer1.Controls.Add(this.tbx_maintainId);
            this.gbxContainer1.Controls.Add(this.lbl_maintainId);
            this.gbxContainer1.Controls.Add(this.btnPathSelect);
            this.gbxContainer1.Controls.Add(this.dtime_maintainTime);
            this.gbxContainer1.Controls.Add(this.txt_maintainImagePath);
            this.gbxContainer1.Controls.Add(this.lbl_maintainImagePath);
            this.gbxContainer1.Controls.Add(this.txt_maintainDescription);
            this.gbxContainer1.Controls.Add(this.lbl_maintainDescription);
            this.gbxContainer1.Controls.Add(this.lbl_maintainTime);
            this.gbxContainer1.Controls.Add(this.txt_maintainOperator);
            this.gbxContainer1.Controls.Add(this.lbl_maintainOperator);
            this.gbxContainer1.Location = new System.Drawing.Point(7, 265);
            this.gbxContainer1.Name = "gbxContainer1";
            this.gbxContainer1.Size = new System.Drawing.Size(868, 129);
            this.gbxContainer1.TabIndex = 15;
            this.gbxContainer1.TabStop = false;
            // 
            // tbx_maintainId
            // 
            this.tbx_maintainId.Location = new System.Drawing.Point(110, 15);
            this.tbx_maintainId.Name = "tbx_maintainId";
            this.tbx_maintainId.Size = new System.Drawing.Size(107, 23);
            this.tbx_maintainId.TabIndex = 18;
            this.tbx_maintainId.Text = "阿斯蒂";
            // 
            // lbl_maintainId
            // 
            this.lbl_maintainId.AutoSize = true;
            this.lbl_maintainId.Location = new System.Drawing.Point(49, 19);
            this.lbl_maintainId.Name = "lbl_maintainId";
            this.lbl_maintainId.Size = new System.Drawing.Size(44, 15);
            this.lbl_maintainId.TabIndex = 17;
            this.lbl_maintainId.Text = "保养ID";
            // 
            // btnPathSelect
            // 
            this.btnPathSelect.BackColor = System.Drawing.Color.White;
            this.btnPathSelect.BtnBackColor = System.Drawing.Color.White;
            this.btnPathSelect.BtnFont = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPathSelect.BtnForeColor = System.Drawing.Color.Black;
            this.btnPathSelect.BtnText = "选 择";
            this.btnPathSelect.ConerRadius = 5;
            this.btnPathSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPathSelect.EnabledMouseEffect = false;
            this.btnPathSelect.FillColor = System.Drawing.Color.Silver;
            this.btnPathSelect.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnPathSelect.IsRadius = true;
            this.btnPathSelect.IsShowRect = false;
            this.btnPathSelect.IsShowTips = false;
            this.btnPathSelect.Location = new System.Drawing.Point(796, 44);
            this.btnPathSelect.Margin = new System.Windows.Forms.Padding(0);
            this.btnPathSelect.Name = "btnPathSelect";
            this.btnPathSelect.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(58)))));
            this.btnPathSelect.RectWidth = 1;
            this.btnPathSelect.Size = new System.Drawing.Size(59, 23);
            this.btnPathSelect.TabIndex = 16;
            this.btnPathSelect.TabStop = false;
            this.btnPathSelect.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.btnPathSelect.TipsText = "";
            this.btnPathSelect.Click += new System.EventHandler(this.btnPathSelect_BtnClick);
            // 
            // dtime_maintainTime
            // 
            this.dtime_maintainTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtime_maintainTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtime_maintainTime.Location = new System.Drawing.Point(510, 15);
            this.dtime_maintainTime.Name = "dtime_maintainTime";
            this.dtime_maintainTime.Size = new System.Drawing.Size(144, 23);
            this.dtime_maintainTime.TabIndex = 8;
            // 
            // txt_maintainImagePath
            // 
            this.txt_maintainImagePath.Location = new System.Drawing.Point(101, 44);
            this.txt_maintainImagePath.Name = "txt_maintainImagePath";
            this.txt_maintainImagePath.Size = new System.Drawing.Size(683, 23);
            this.txt_maintainImagePath.TabIndex = 7;
            // 
            // lbl_maintainImagePath
            // 
            this.lbl_maintainImagePath.AutoSize = true;
            this.lbl_maintainImagePath.Location = new System.Drawing.Point(8, 48);
            this.lbl_maintainImagePath.Name = "lbl_maintainImagePath";
            this.lbl_maintainImagePath.Size = new System.Drawing.Size(85, 15);
            this.lbl_maintainImagePath.TabIndex = 6;
            this.lbl_maintainImagePath.Text = "保养照片路径";
            // 
            // txt_maintainDescription
            // 
            this.txt_maintainDescription.Location = new System.Drawing.Point(101, 75);
            this.txt_maintainDescription.Multiline = true;
            this.txt_maintainDescription.Name = "txt_maintainDescription";
            this.txt_maintainDescription.Size = new System.Drawing.Size(683, 47);
            this.txt_maintainDescription.TabIndex = 5;
            // 
            // lbl_maintainDescription
            // 
            this.lbl_maintainDescription.AutoSize = true;
            this.lbl_maintainDescription.Location = new System.Drawing.Point(8, 78);
            this.lbl_maintainDescription.Name = "lbl_maintainDescription";
            this.lbl_maintainDescription.Size = new System.Drawing.Size(85, 15);
            this.lbl_maintainDescription.TabIndex = 4;
            this.lbl_maintainDescription.Text = "保养详细信息";
            // 
            // lbl_maintainTime
            // 
            this.lbl_maintainTime.AutoSize = true;
            this.lbl_maintainTime.Location = new System.Drawing.Point(434, 19);
            this.lbl_maintainTime.Name = "lbl_maintainTime";
            this.lbl_maintainTime.Size = new System.Drawing.Size(59, 15);
            this.lbl_maintainTime.TabIndex = 2;
            this.lbl_maintainTime.Text = "保养时间";
            // 
            // txt_maintainOperator
            // 
            this.txt_maintainOperator.Location = new System.Drawing.Point(310, 15);
            this.txt_maintainOperator.Name = "txt_maintainOperator";
            this.txt_maintainOperator.Size = new System.Drawing.Size(107, 23);
            this.txt_maintainOperator.TabIndex = 1;
            this.txt_maintainOperator.Text = "阿斯蒂";
            // 
            // lbl_maintainOperator
            // 
            this.lbl_maintainOperator.AutoSize = true;
            this.lbl_maintainOperator.Location = new System.Drawing.Point(234, 19);
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
            this.btn_Close.Location = new System.Drawing.Point(398, 404);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(58)))));
            this.btn_Close.RectWidth = 1;
            this.btn_Close.Size = new System.Drawing.Size(102, 33);
            this.btn_Close.TabIndex = 19;
            this.btn_Close.TabStop = false;
            this.btn_Close.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.btn_Close.TipsText = "";
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
            this.btn_Save.Location = new System.Drawing.Point(252, 404);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(58)))));
            this.btn_Save.RectWidth = 1;
            this.btn_Save.Size = new System.Drawing.Size(102, 33);
            this.btn_Save.TabIndex = 18;
            this.btn_Save.TabStop = false;
            this.btn_Save.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.btn_Save.TipsText = "";
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
            this.btn_Cancel.Location = new System.Drawing.Point(543, 404);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(58)))));
            this.btn_Cancel.RectWidth = 1;
            this.btn_Cancel.Size = new System.Drawing.Size(102, 33);
            this.btn_Cancel.TabIndex = 20;
            this.btn_Cancel.TabStop = false;
            this.btn_Cancel.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.btn_Cancel.TipsText = "";
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
            // DeviceMainTainAndRepairEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(881, 450);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox gbxContainer1;
        private UCBtnExt btnPathSelect;
        private System.Windows.Forms.DateTimePicker dtime_maintainTime;
        private System.Windows.Forms.TextBox txt_maintainImagePath;
        private System.Windows.Forms.Label lbl_maintainImagePath;
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
    }
}
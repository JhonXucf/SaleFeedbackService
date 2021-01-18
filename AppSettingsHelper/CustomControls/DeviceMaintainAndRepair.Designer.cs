
namespace AppSettingsHelper.CustomControls
{
    partial class DeviceMaintainAndRepair
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
            this.gbxContainer = new System.Windows.Forms.GroupBox();
            this.txt_serach = new AppSettingsHelper.UCTextBoxEx();
            this.btn_Save = new AppSettingsHelper.UCBtnExt();
            this.gbxContainer1 = new System.Windows.Forms.GroupBox();
            this.btnPathSelect = new AppSettingsHelper.UCBtnExt();
            this.dtime_maintainTime = new System.Windows.Forms.DateTimePicker();
            this.txt_maintainImagePath = new System.Windows.Forms.TextBox();
            this.lbl_maintainImagePath = new System.Windows.Forms.Label();
            this.txt_maintainDescription = new System.Windows.Forms.TextBox();
            this.lbl_maintainDescription = new System.Windows.Forms.Label();
            this.lbl_maintainTime = new System.Windows.Forms.Label();
            this.txt_maintainOperator = new System.Windows.Forms.TextBox();
            this.lbl_maintainOperator = new System.Windows.Forms.Label();
            this.btn_Close = new AppSettingsHelper.UCBtnExt();
            this.gbxContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Microsoft YaHei", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_title.Location = new System.Drawing.Point(19, 11);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(84, 25);
            this.lbl_title.TabIndex = 10;
            this.lbl_title.Text = "设备保养";
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label15.Location = new System.Drawing.Point(3, 2);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(10, 43);
            this.label15.TabIndex = 9;
            // 
            // gbxContainer
            // 
            this.gbxContainer.Location = new System.Drawing.Point(10, 90);
            this.gbxContainer.Name = "gbxContainer";
            this.gbxContainer.Size = new System.Drawing.Size(869, 357);
            this.gbxContainer.TabIndex = 12;
            this.gbxContainer.TabStop = false;
            // 
            // txt_serach
            // 
            this.txt_serach.BackColor = System.Drawing.Color.Transparent;
            this.txt_serach.ConerRadius = 5;
            this.txt_serach.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_serach.DecLength = 2;
            this.txt_serach.FillColor = System.Drawing.Color.Empty;
            this.txt_serach.FocusBorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.txt_serach.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txt_serach.InputText = "";
            this.txt_serach.InputType = AppSettingsHelper.TextInputType.NotControl;
            this.txt_serach.IsFocusColor = true;
            this.txt_serach.IsRadius = true;
            this.txt_serach.IsShowClearBtn = true;
            this.txt_serach.IsShowKeyboard = true;
            this.txt_serach.IsShowRect = true;
            this.txt_serach.IsShowSearchBtn = true;
            this.txt_serach.KeyBoardType = AppSettingsHelper.KeyBoardType.UCKeyBorderAll_EN;
            this.txt_serach.Location = new System.Drawing.Point(10, 52);
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
            this.txt_serach.PromptText = "请在这里输入要查询的部件信息";
            this.txt_serach.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txt_serach.RectWidth = 1;
            this.txt_serach.RegexPattern = "";
            this.txt_serach.Size = new System.Drawing.Size(554, 41);
            this.txt_serach.TabIndex = 0;
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
            this.btn_Save.Location = new System.Drawing.Point(335, 567);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(58)))));
            this.btn_Save.RectWidth = 1;
            this.btn_Save.Size = new System.Drawing.Size(102, 33);
            this.btn_Save.TabIndex = 13;
            this.btn_Save.TabStop = false;
            this.btn_Save.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.btn_Save.TipsText = "";
            // 
            // gbxContainer1
            // 
            this.gbxContainer1.Controls.Add(this.btnPathSelect);
            this.gbxContainer1.Controls.Add(this.dtime_maintainTime);
            this.gbxContainer1.Controls.Add(this.txt_maintainImagePath);
            this.gbxContainer1.Controls.Add(this.lbl_maintainImagePath);
            this.gbxContainer1.Controls.Add(this.txt_maintainDescription);
            this.gbxContainer1.Controls.Add(this.lbl_maintainDescription);
            this.gbxContainer1.Controls.Add(this.lbl_maintainTime);
            this.gbxContainer1.Controls.Add(this.txt_maintainOperator);
            this.gbxContainer1.Controls.Add(this.lbl_maintainOperator);
            this.gbxContainer1.Location = new System.Drawing.Point(11, 446);
            this.gbxContainer1.Name = "gbxContainer1";
            this.gbxContainer1.Size = new System.Drawing.Size(868, 108);
            this.gbxContainer1.TabIndex = 14;
            this.gbxContainer1.TabStop = false;
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
            this.btnPathSelect.Location = new System.Drawing.Point(792, 16);
            this.btnPathSelect.Margin = new System.Windows.Forms.Padding(0);
            this.btnPathSelect.Name = "btnPathSelect";
            this.btnPathSelect.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(58)))));
            this.btnPathSelect.RectWidth = 1;
            this.btnPathSelect.Size = new System.Drawing.Size(59, 23);
            this.btnPathSelect.TabIndex = 16;
            this.btnPathSelect.TabStop = false;
            this.btnPathSelect.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.btnPathSelect.TipsText = "";
            // 
            // dtime_maintainTime
            // 
            this.dtime_maintainTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtime_maintainTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtime_maintainTime.Location = new System.Drawing.Point(283, 16);
            this.dtime_maintainTime.Name = "dtime_maintainTime";
            this.dtime_maintainTime.Size = new System.Drawing.Size(144, 23);
            this.dtime_maintainTime.TabIndex = 8;
            // 
            // txt_maintainImagePath
            // 
            this.txt_maintainImagePath.Location = new System.Drawing.Point(528, 16);
            this.txt_maintainImagePath.Name = "txt_maintainImagePath";
            this.txt_maintainImagePath.Size = new System.Drawing.Size(256, 23);
            this.txt_maintainImagePath.TabIndex = 7;
            // 
            // lbl_maintainImagePath
            // 
            this.lbl_maintainImagePath.AutoSize = true;
            this.lbl_maintainImagePath.Location = new System.Drawing.Point(435, 20);
            this.lbl_maintainImagePath.Name = "lbl_maintainImagePath";
            this.lbl_maintainImagePath.Size = new System.Drawing.Size(85, 15);
            this.lbl_maintainImagePath.TabIndex = 6;
            this.lbl_maintainImagePath.Text = "保养照片路径";
            // 
            // txt_maintainDescription
            // 
            this.txt_maintainDescription.Location = new System.Drawing.Point(101, 55);
            this.txt_maintainDescription.Multiline = true;
            this.txt_maintainDescription.Name = "txt_maintainDescription";
            this.txt_maintainDescription.Size = new System.Drawing.Size(683, 47);
            this.txt_maintainDescription.TabIndex = 5;
            // 
            // lbl_maintainDescription
            // 
            this.lbl_maintainDescription.AutoSize = true;
            this.lbl_maintainDescription.Location = new System.Drawing.Point(8, 58);
            this.lbl_maintainDescription.Name = "lbl_maintainDescription";
            this.lbl_maintainDescription.Size = new System.Drawing.Size(85, 15);
            this.lbl_maintainDescription.TabIndex = 4;
            this.lbl_maintainDescription.Text = "保养详细信息";
            // 
            // lbl_maintainTime
            // 
            this.lbl_maintainTime.AutoSize = true;
            this.lbl_maintainTime.Location = new System.Drawing.Point(216, 20);
            this.lbl_maintainTime.Name = "lbl_maintainTime";
            this.lbl_maintainTime.Size = new System.Drawing.Size(59, 15);
            this.lbl_maintainTime.TabIndex = 2;
            this.lbl_maintainTime.Text = "保养时间";
            // 
            // txt_maintainOperator
            // 
            this.txt_maintainOperator.Location = new System.Drawing.Point(101, 16);
            this.txt_maintainOperator.Name = "txt_maintainOperator";
            this.txt_maintainOperator.Size = new System.Drawing.Size(107, 23);
            this.txt_maintainOperator.TabIndex = 1;
            this.txt_maintainOperator.Text = "阿斯蒂";
            // 
            // lbl_maintainOperator
            // 
            this.lbl_maintainOperator.AutoSize = true;
            this.lbl_maintainOperator.Location = new System.Drawing.Point(34, 20);
            this.lbl_maintainOperator.Name = "lbl_maintainOperator";
            this.lbl_maintainOperator.Size = new System.Drawing.Size(59, 15);
            this.lbl_maintainOperator.TabIndex = 0;
            this.lbl_maintainOperator.Text = "保养人员";
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.White;
            this.btn_Close.BtnBackColor = System.Drawing.Color.White;
            this.btn_Close.BtnFont = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_Close.BtnForeColor = System.Drawing.Color.Black;
            this.btn_Close.BtnText = "取   消";
            this.btn_Close.ConerRadius = 5;
            this.btn_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Close.EnabledMouseEffect = false;
            this.btn_Close.FillColor = System.Drawing.Color.Silver;
            this.btn_Close.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btn_Close.IsRadius = true;
            this.btn_Close.IsShowRect = false;
            this.btn_Close.IsShowTips = false;
            this.btn_Close.Location = new System.Drawing.Point(483, 567);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(58)))));
            this.btn_Close.RectWidth = 1;
            this.btn_Close.Size = new System.Drawing.Size(102, 33);
            this.btn_Close.TabIndex = 15;
            this.btn_Close.TabStop = false;
            this.btn_Close.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.btn_Close.TipsText = "";
            // 
            // DeviceMaintainAndRepair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(889, 609);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.gbxContainer1);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.txt_serach);
            this.Controls.Add(this.gbxContainer);
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.label15);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DeviceMaintainAndRepair";
            this.Text = "DeviceMaintainAndRepair";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Control_MouseMove);
            this.gbxContainer1.ResumeLayout(false);
            this.gbxContainer1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox gbxContainer;
        private UCTextBoxEx txt_serach;
        private UCBtnExt btn_Save;
        private System.Windows.Forms.GroupBox gbxContainer1;
        private System.Windows.Forms.Label lbl_maintainOperator;
        private UCBtnExt btn_Close;
        private UCBtnExt btnPathSelect;
        private System.Windows.Forms.DateTimePicker dtime_maintainTime;
        private System.Windows.Forms.TextBox txt_maintainImagePath;
        private System.Windows.Forms.Label lbl_maintainImagePath;
        private System.Windows.Forms.TextBox txt_maintainDescription;
        private System.Windows.Forms.Label lbl_maintainDescription;
        private System.Windows.Forms.Label lbl_maintainTime;
        private System.Windows.Forms.TextBox txt_maintainOperator;
    }
}
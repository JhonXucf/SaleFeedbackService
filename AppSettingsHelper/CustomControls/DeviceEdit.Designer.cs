
namespace AppSettingsHelper.CustomControls
{
    partial class DeviceEdit
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
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Cancle = new System.Windows.Forms.Button();
            this.lbl_deviceId = new System.Windows.Forms.Label();
            this.tbx_deviceId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_title = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbx_description = new System.Windows.Forms.TextBox();
            this.dtp_ScrapTime = new System.Windows.Forms.DateTimePicker();
            this.dtp_productTime = new System.Windows.Forms.DateTimePicker();
            this.lbl_description = new System.Windows.Forms.Label();
            this.lbl_ScrapTime = new System.Windows.Forms.Label();
            this.lbl_productTime = new System.Windows.Forms.Label();
            this.cbx_deviceType = new System.Windows.Forms.ComboBox();
            this.lbl_deviceType = new System.Windows.Forms.Label();
            this.tbx_deviceName = new System.Windows.Forms.TextBox();
            this.lbl_deviceName = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(46, 406);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 27);
            this.btn_Save.TabIndex = 0;
            this.btn_Save.Text = "保   存";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Cancle
            // 
            this.btn_Cancle.Location = new System.Drawing.Point(167, 406);
            this.btn_Cancle.Name = "btn_Cancle";
            this.btn_Cancle.Size = new System.Drawing.Size(75, 27);
            this.btn_Cancle.TabIndex = 1;
            this.btn_Cancle.Text = "取   消";
            this.btn_Cancle.UseVisualStyleBackColor = true;
            this.btn_Cancle.Click += new System.EventHandler(this.btn_Cancle_Click);
            // 
            // lbl_deviceId
            // 
            this.lbl_deviceId.AutoSize = true;
            this.lbl_deviceId.Location = new System.Drawing.Point(14, 28);
            this.lbl_deviceId.Name = "lbl_deviceId";
            this.lbl_deviceId.Size = new System.Drawing.Size(44, 15);
            this.lbl_deviceId.TabIndex = 2;
            this.lbl_deviceId.Text = "设备ID";
            // 
            // tbx_deviceId
            // 
            this.tbx_deviceId.Location = new System.Drawing.Point(84, 24);
            this.tbx_deviceId.Name = "tbx_deviceId";
            this.tbx_deviceId.Size = new System.Drawing.Size(167, 23);
            this.tbx_deviceId.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(2, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 43);
            this.label2.TabIndex = 4;
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Microsoft YaHei", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_title.Location = new System.Drawing.Point(23, 12);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(84, 25);
            this.lbl_title.TabIndex = 5;
            this.lbl_title.Text = "设备新增";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbx_description);
            this.groupBox1.Controls.Add(this.dtp_ScrapTime);
            this.groupBox1.Controls.Add(this.dtp_productTime);
            this.groupBox1.Controls.Add(this.lbl_description);
            this.groupBox1.Controls.Add(this.lbl_ScrapTime);
            this.groupBox1.Controls.Add(this.lbl_productTime);
            this.groupBox1.Controls.Add(this.cbx_deviceType);
            this.groupBox1.Controls.Add(this.lbl_deviceType);
            this.groupBox1.Controls.Add(this.tbx_deviceName);
            this.groupBox1.Controls.Add(this.lbl_deviceName);
            this.groupBox1.Controls.Add(this.tbx_deviceId);
            this.groupBox1.Controls.Add(this.lbl_deviceId);
            this.groupBox1.Location = new System.Drawing.Point(13, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 346);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // tbx_description
            // 
            this.tbx_description.Location = new System.Drawing.Point(84, 224);
            this.tbx_description.Multiline = true;
            this.tbx_description.Name = "tbx_description";
            this.tbx_description.Size = new System.Drawing.Size(167, 114);
            this.tbx_description.TabIndex = 13;
            // 
            // dtp_ScrapTime
            // 
            this.dtp_ScrapTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp_ScrapTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_ScrapTime.Location = new System.Drawing.Point(84, 184);
            this.dtp_ScrapTime.Name = "dtp_ScrapTime";
            this.dtp_ScrapTime.Size = new System.Drawing.Size(167, 23);
            this.dtp_ScrapTime.TabIndex = 12;
            // 
            // dtp_productTime
            // 
            this.dtp_productTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtp_productTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_productTime.Location = new System.Drawing.Point(84, 144);
            this.dtp_productTime.Name = "dtp_productTime";
            this.dtp_productTime.Size = new System.Drawing.Size(167, 23);
            this.dtp_productTime.TabIndex = 11;
            // 
            // lbl_description
            // 
            this.lbl_description.AutoSize = true;
            this.lbl_description.Location = new System.Drawing.Point(14, 228);
            this.lbl_description.Name = "lbl_description";
            this.lbl_description.Size = new System.Drawing.Size(59, 15);
            this.lbl_description.TabIndex = 10;
            this.lbl_description.Text = "设备描述";
            // 
            // lbl_ScrapTime
            // 
            this.lbl_ScrapTime.AutoSize = true;
            this.lbl_ScrapTime.Location = new System.Drawing.Point(14, 188);
            this.lbl_ScrapTime.Name = "lbl_ScrapTime";
            this.lbl_ScrapTime.Size = new System.Drawing.Size(59, 15);
            this.lbl_ScrapTime.TabIndex = 9;
            this.lbl_ScrapTime.Text = "报废时间";
            // 
            // lbl_productTime
            // 
            this.lbl_productTime.AutoSize = true;
            this.lbl_productTime.Location = new System.Drawing.Point(14, 148);
            this.lbl_productTime.Name = "lbl_productTime";
            this.lbl_productTime.Size = new System.Drawing.Size(59, 15);
            this.lbl_productTime.TabIndex = 8;
            this.lbl_productTime.Text = "出厂时间";
            // 
            // cbx_deviceType
            // 
            this.cbx_deviceType.FormattingEnabled = true;
            this.cbx_deviceType.Location = new System.Drawing.Point(84, 104);
            this.cbx_deviceType.Name = "cbx_deviceType";
            this.cbx_deviceType.Size = new System.Drawing.Size(167, 23);
            this.cbx_deviceType.TabIndex = 7;
            // 
            // lbl_deviceType
            // 
            this.lbl_deviceType.AutoSize = true;
            this.lbl_deviceType.Location = new System.Drawing.Point(14, 108);
            this.lbl_deviceType.Name = "lbl_deviceType";
            this.lbl_deviceType.Size = new System.Drawing.Size(59, 15);
            this.lbl_deviceType.TabIndex = 6;
            this.lbl_deviceType.Text = "设备类型";
            // 
            // tbx_deviceName
            // 
            this.tbx_deviceName.Location = new System.Drawing.Point(84, 64);
            this.tbx_deviceName.Name = "tbx_deviceName";
            this.tbx_deviceName.Size = new System.Drawing.Size(167, 23);
            this.tbx_deviceName.TabIndex = 5;
            // 
            // lbl_deviceName
            // 
            this.lbl_deviceName.AutoSize = true;
            this.lbl_deviceName.Location = new System.Drawing.Point(14, 68);
            this.lbl_deviceName.Name = "lbl_deviceName";
            this.lbl_deviceName.Size = new System.Drawing.Size(59, 15);
            this.lbl_deviceName.TabIndex = 4;
            this.lbl_deviceName.Text = "设备名称";
            // 
            // DeviceEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Cancle);
            this.Controls.Add(this.btn_Save);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DeviceEdit";
            this.Text = "DeviceEdit";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Cancle;
        private System.Windows.Forms.Label lbl_deviceId;
        private System.Windows.Forms.TextBox tbx_deviceId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbx_deviceType;
        private System.Windows.Forms.Label lbl_deviceType;
        private System.Windows.Forms.TextBox tbx_deviceName;
        private System.Windows.Forms.Label lbl_deviceName;
        private System.Windows.Forms.TextBox tbx_description;
        private System.Windows.Forms.DateTimePicker dtp_ScrapTime;
        private System.Windows.Forms.DateTimePicker dtp_productTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_ScrapTime;
        private System.Windows.Forms.Label lbl_productTime;
        private System.Windows.Forms.Label lbl_;
        private System.Windows.Forms.Label lbl_description;
    }
}
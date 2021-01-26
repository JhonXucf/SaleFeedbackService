
namespace AppSettingsHelper.CustomControls
{
    partial class DeviceSingleFrm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_title = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_deviceDescription = new System.Windows.Forms.Label();
            this.lbl_devicePartNum = new System.Windows.Forms.Label();
            this.lbl_deviceName = new System.Windows.Forms.Label();
            this.lbl_deviceId = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.miantainShowCountControl1 = new AppSettingsHelper.MiantainShowCountControl();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 43);
            this.label1.TabIndex = 0;
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Microsoft YaHei", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_title.Location = new System.Drawing.Point(20, 13);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(41, 25);
            this.lbl_title.TabIndex = 6;
            this.lbl_title.Text = "PIS";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_deviceDescription);
            this.groupBox1.Controls.Add(this.lbl_devicePartNum);
            this.groupBox1.Controls.Add(this.lbl_deviceName);
            this.groupBox1.Controls.Add(this.lbl_deviceId);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(9, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 156);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // lbl_deviceDescription
            // 
            this.lbl_deviceDescription.Location = new System.Drawing.Point(93, 106);
            this.lbl_deviceDescription.Name = "lbl_deviceDescription";
            this.lbl_deviceDescription.Size = new System.Drawing.Size(125, 47);
            this.lbl_deviceDescription.TabIndex = 7;
            this.lbl_deviceDescription.Text = "24-365监控回流炉的状态";
            // 
            // lbl_devicePartNum
            // 
            this.lbl_devicePartNum.AutoSize = true;
            this.lbl_devicePartNum.Location = new System.Drawing.Point(93, 77);
            this.lbl_devicePartNum.Name = "lbl_devicePartNum";
            this.lbl_devicePartNum.Size = new System.Drawing.Size(20, 15);
            this.lbl_devicePartNum.TabIndex = 6;
            this.lbl_devicePartNum.Text = "无";
            // 
            // lbl_deviceName
            // 
            this.lbl_deviceName.AutoSize = true;
            this.lbl_deviceName.Location = new System.Drawing.Point(93, 48);
            this.lbl_deviceName.Name = "lbl_deviceName";
            this.lbl_deviceName.Size = new System.Drawing.Size(61, 15);
            this.lbl_deviceName.TabIndex = 5;
            this.lbl_deviceName.Text = "PIS 24-365";
            // 
            // lbl_deviceId
            // 
            this.lbl_deviceId.AutoSize = true;
            this.lbl_deviceId.Location = new System.Drawing.Point(93, 19);
            this.lbl_deviceId.Name = "lbl_deviceId";
            this.lbl_deviceId.Size = new System.Drawing.Size(114, 15);
            this.lbl_deviceId.TabIndex = 4;
            this.lbl_deviceId.Text = "babc220e-4d78-4f9a";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "设备描述";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "设备部件";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "设备名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "设备ID";
            // 
            // miantainShowCountControl1
            // 
            this.miantainShowCountControl1.BorderVisiable = false;
            this.miantainShowCountControl1.EclipsBackColor = System.Drawing.Color.LightCoral;
            this.miantainShowCountControl1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.miantainShowCountControl1.ForeColor = System.Drawing.Color.Black;
            this.miantainShowCountControl1.LabelText = "";
            this.miantainShowCountControl1.Location = new System.Drawing.Point(208, 4);
            this.miantainShowCountControl1.Margin = new System.Windows.Forms.Padding(4);
            this.miantainShowCountControl1.Name = "miantainShowCountControl1";
            this.miantainShowCountControl1.OriginalColor = System.Drawing.Color.LightCoral;
            this.miantainShowCountControl1.Pis_Index = "";
            this.miantainShowCountControl1.PisIndexFont = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.miantainShowCountControl1.PisindexForeColor = System.Drawing.SystemColors.ControlText;
            this.miantainShowCountControl1.Size = new System.Drawing.Size(27, 27);
            this.miantainShowCountControl1.TabIndex = 8;
            // 
            // DeviceSingleFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.miantainShowCountControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.label1);
            this.Name = "DeviceSingleFrm";
            this.Size = new System.Drawing.Size(243, 216);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_deviceId;
        private System.Windows.Forms.Label lbl_deviceDescription;
        private System.Windows.Forms.Label lbl_devicePartNum;
        private System.Windows.Forms.Label lbl_deviceName;
        private MiantainShowCountControl miantainShowCountControl1;
    }
}


namespace AppSettingsHelper.CustomControls
{
    partial class DevicePartSingle
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_partName = new System.Windows.Forms.Label();
            this.lbl_partID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.lbl_partName);
            this.groupBox1.Controls.Add(this.lbl_partID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(181, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lbl_partName
            // 
            this.lbl_partName.Location = new System.Drawing.Point(68, 39);
            this.lbl_partName.Name = "lbl_partName";
            this.lbl_partName.Size = new System.Drawing.Size(105, 36);
            this.lbl_partName.TabIndex = 3;
            this.lbl_partName.Text = "sdfsfsdfsfsf适当的放松放松";
            // 
            // lbl_partID
            // 
            this.lbl_partID.AutoSize = true;
            this.lbl_partID.Location = new System.Drawing.Point(70, 15);
            this.lbl_partID.Name = "lbl_partID";
            this.lbl_partID.Size = new System.Drawing.Size(57, 15);
            this.lbl_partID.TabIndex = 2;
            this.lbl_partID.Text = "fgadfasdf";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "部件品名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "部件ID";
            // 
            // DevicePartSingle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "DevicePartSingle";
            this.Size = new System.Drawing.Size(190, 86);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_partName;
        private System.Windows.Forms.Label lbl_partID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

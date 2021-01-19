
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
            this.btn_Close = new AppSettingsHelper.UCBtnExt();
            this.button1 = new System.Windows.Forms.Button();
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
            this.gbxContainer.Size = new System.Drawing.Size(869, 439);
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
            this.btn_Save.Location = new System.Drawing.Point(335, 553);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(58)))));
            this.btn_Save.RectWidth = 1;
            this.btn_Save.Size = new System.Drawing.Size(102, 33);
            this.btn_Save.TabIndex = 13;
            this.btn_Save.TabStop = false;
            this.btn_Save.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.btn_Save.TipsText = "";
            this.btn_Save.BtnClick += new System.EventHandler(this.btn_Save_BtnClick);
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
            this.btn_Close.Location = new System.Drawing.Point(483, 553);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(58)))));
            this.btn_Close.RectWidth = 1;
            this.btn_Close.Size = new System.Drawing.Size(102, 33);
            this.btn_Close.TabIndex = 15;
            this.btn_Close.TabStop = false;
            this.btn_Close.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.btn_Close.TipsText = "";
            this.btn_Close.BtnClick += new System.EventHandler(this.btn_Close_BtnClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Brown;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(837, 7);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 32);
            this.button1.TabIndex = 16;
            this.button1.Text = "×";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btn_Close_BtnClick);
            // 
            // DeviceMaintainAndRepair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(889, 609);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_Close);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox gbxContainer;
        private UCTextBoxEx txt_serach;
        private UCBtnExt btn_Save;
        private UCBtnExt btn_Close;
        private System.Windows.Forms.Button button1;
    }
}
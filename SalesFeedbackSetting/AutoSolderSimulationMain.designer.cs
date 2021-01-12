
namespace SalesFeedbackSetting
{
    partial class AutoSolderSimulationMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoSolderSimulationMain));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.新增DW800ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新增ID900ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新增DW800ToolStripMenuItem,
            this.新增ID900ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(138, 48);
            // 
            // 新增DW800ToolStripMenuItem
            // 
            this.新增DW800ToolStripMenuItem.Name = "新增DW800ToolStripMenuItem";
            this.新增DW800ToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.新增DW800ToolStripMenuItem.Text = "新增DW800";
            this.新增DW800ToolStripMenuItem.Click += new System.EventHandler(this.新增DW800ToolStripMenuItem_Click);
            // 
            // 新增ID900ToolStripMenuItem
            // 
            this.新增ID900ToolStripMenuItem.Name = "新增ID900ToolStripMenuItem";
            this.新增ID900ToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.新增ID900ToolStripMenuItem.Text = "新增ID900";
            this.新增ID900ToolStripMenuItem.Click += new System.EventHandler(this.新增ID900ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.ContextMenuStrip = this.contextMenuStrip1;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1264, 761);
            this.panel1.TabIndex = 1;
            // 
            // AutoSolderSimulationMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AutoSolderSimulationMain";
            this.Text = "加锡机网络模拟数据";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 新增DW800ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新增ID900ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SalesFeedbackSetting
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            this.textBox1.MouseEnter += TextBox1_MouseEnter;
        }

        private void TextBox1_MouseEnter(object sender, EventArgs e)
        {
            this.textBox1.Location = new Point(this.textBox1.Location.X - 20, this.textBox1.Location.Y - 20);
            System.Threading.Thread.Sleep(500);
            while (this.textBox1.Location.X + this.textBox1.Width > 0)
            {
                this.textBox1.Location = new Point(this.textBox1.Location.X - 20, this.textBox1.Location.Y);
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}

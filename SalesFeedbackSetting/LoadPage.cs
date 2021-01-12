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
    public partial class LoadPage : Form
    {
        public LoadPage()
        {
            InitializeComponent();
        }

        private void timerProgressbar_Tick(object sender, EventArgs e)
        {
            pnl_Load.Width += 10;
            if (pnl_Load.Width >= 700)
            {
                timerProgressbar.Stop();
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}

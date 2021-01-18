using SalesFeedBackInfrasturcture.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AppSettingsHelper.CustomControls
{
    public partial class DevicePartSingle : UserControl
    {
        public DevicePartSingle( DevicePart devicePart)
        {
            InitializeComponent();
            this.lbl_partID.Text = devicePart.ID;
            this.lbl_partName.Text = devicePart.PartName;
            foreach (Control item in this.Controls)
            {
                item.Click += Item_Click;
            }
        }
        bool IsSelected = false;
        private void Item_Click(object sender, EventArgs e)
        {
            if (IsSelected)
            {
                IsSelected = false;
                this.groupBox1.BackColor = Color.White;
            }
            else
            {
                IsSelected = true;
                this.groupBox1.BackColor = Color.AliceBlue;
            }
        }
    }
}

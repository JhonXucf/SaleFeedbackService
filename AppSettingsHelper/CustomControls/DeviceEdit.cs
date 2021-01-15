using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using SalesFeedBackInfrasturcture.Entities;
using System.Text;
using System.Windows.Forms;

namespace AppSettingsHelper.CustomControls
{
    public partial class DeviceEdit : Form
    {
        Device _device;
        public Device _Device
        {
            get { return _device; }
            set { _device = value; }
        }
        public DeviceEdit()
        {
            InitializeComponent();
            _device = new Device();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_Cancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            this.Close();
        }
    }
}

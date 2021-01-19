using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using SalesFeedBackInfrasturcture.Entities;
using System.Text;
using System.Windows.Forms;
using SalesFeedBackInfrasturcture.Infrastructure;
using System.Drawing;

namespace AppSettingsHelper.CustomControls
{
    public partial class DeviceEdit : Form
    {
        #region 鼠标移动
        private Point _mousePoint = new Point();     //鼠标所在位置（top,left）
        /// <summary>
        /// 标题块按压事件（记住鼠标的位置）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            this._mousePoint.X = e.X;
            this._mousePoint.Y = e.Y;
        }

        /// <summary>
        /// 鼠标移动事件（根据鼠标按下的位置和鼠标移动后的位置 移动窗体）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Control_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                this.Top = Control.MousePosition.Y - _mousePoint.Y;
                this.Left = Control.MousePosition.X - _mousePoint.X;
            }
        }
        #endregion
        Device _device = new Device();
        public Device _Device
        {
            get { return _device; }
            set
            {
                _device = value;
                if (null != value)
                {
                    SetDeviceInfo(value);
                }
            }
        }
        private void SetDeviceInfo(Device device)
        {
            this.tbx_deviceId.Text = device.ID;
            this.tbx_deviceName.Text = device.DeviceName;
            this.cbx_deviceType.Text = device.DeviceStyle.GetEnumDescription<DeviceStyle>();
            this.dtp_productTime.Value = device.ProductedTime;
            this.dtp_ScrapTime.Value = device.ProductScrapTime;
            this.tbx_description.Text = device.DeviceDescription;
        }
        private Device GetDevice()
        {
            if (string.IsNullOrWhiteSpace(this.tbx_deviceId.Text))
            {
                this.errorProvider1.SetError(this.lbl_error, "设备ID不能为空！");
                return null;
            }
            if (this.dtp_ScrapTime.Value < this.dtp_productTime.Value)
            {
                MessageBox.Show("报废日期不能小于生产日期！");
                return null;
            }
            Device device = new Device();
            device.ID = this.tbx_deviceId.Text;
            device.DeviceName = this.tbx_deviceName.Text;
            device.DeviceStyle = (DeviceStyle)int.Parse(this.cbx_deviceType.SelectedValue.ToString());
            device.ProductedTime = this.dtp_productTime.Value;
            device.ProductScrapTime = this.dtp_ScrapTime.Value;
            device.DeviceDescription = this.tbx_description.Text;
            return device;
        }
        public DeviceEdit(SalesFeedBackMain.OperatorType operatorType)
        {
            InitializeComponent();
            InitDeviceStyles();
            switch (operatorType)
            {
                case SalesFeedBackMain.OperatorType.Add:
                    this.dtp_ScrapTime.Value = this.dtp_ScrapTime.Value.AddYears(70);
                    break;
                case SalesFeedBackMain.OperatorType.Modify:
                    this.lbl_title.Text = "设备修改";
                    break;
                case SalesFeedBackMain.OperatorType.Delete:
                    break;
                default:
                    break;
            }
        }
        void InitDeviceStyles()
        {
            var deviceOprs = typeof(DeviceStyle).GetFields();
            var deviceStyles = new List<DeviceStyleInfoToComBox>();
            foreach (var fieldInfo in deviceOprs)
            {
                if (!fieldInfo.FieldType.IsEnum) continue;
                var des = (DescriptionAttribute)(fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false)[0]);
                var deviceStyleInfoToComBox = new DeviceStyleInfoToComBox();
                deviceStyleInfoToComBox.CustomerName = des.Description;
                deviceStyleInfoToComBox.CustomerCode = ((int)fieldInfo.GetValue(null)).ToString();
                deviceStyles.Add(deviceStyleInfoToComBox);
            }
            if (deviceStyles.Count > 0)
            {
                this.cbx_deviceType.DisplayMember = "CustomerName";
                this.cbx_deviceType.ValueMember = "CustomerCode";
                this.cbx_deviceType.DataSource = deviceStyles;
                this.cbx_deviceType.SelectedIndex = 0;
            }
        }
        internal sealed class DeviceStyleInfoToComBox
        {
            public String CustomerCode { get; set; }
            public String CustomerName { get; set; }
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (null == (this._Device = GetDevice())) return;
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

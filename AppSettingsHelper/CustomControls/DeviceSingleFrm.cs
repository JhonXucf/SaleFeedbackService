using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using SalesFeedBackInfrasturcture.Entities;
using SalesFeedBackInfrasturcture.Infrastructure;
using System.Windows.Forms;

namespace AppSettingsHelper.CustomControls
{
    public partial class DeviceSingleFrm : UserControl
    {
        Device _device;
        public Device _Device
        {
            get { return _device; }
            set
            {
                _device = value;
                if (null != value)
                {
                    SetDeviceInfo(_device);
                }
            }
        }
        ContextMenuStrip contextOpreatorMenu;
        public DeviceSingleFrm()
        {
            InitializeComponent();
            InitDeviceOpreatorMenu();
            this.ContextMenuStrip = this.contextOpreatorMenu;
            foreach (Control item in this.Controls)
            {
                item.ContextMenuStrip = this.contextOpreatorMenu;
            }
        }
        private void SetDeviceInfo(Device device)
        {
            this.lbl_title.Text = GetEnumDescription(device.DeviceStyle);
            this.lbl_deviceId.Text = device.ID;
            this.lbl_deviceName.Text = device.DeviceName;
            this.lbl_devicePartNum.Text = "0";
            this.lbl_deviceDescription.Text = device.DeviceDescription;
        }
        public String GetEnumDescription(DeviceStyle deviceStyle)
        {
            var deviceOprs = typeof(DeviceStyle).GetFields();
            foreach (var fieldInfo in deviceOprs)
            {
                if (!fieldInfo.FieldType.IsEnum) continue;
                if (fieldInfo.Name.Equals(deviceStyle.ToString()))
                {
                    var des = (DescriptionAttribute)(fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false)[0]);
                    return des.Description;
                }
            }
            return null;
        }
        void InitDeviceOpreatorMenu()
        {
            contextOpreatorMenu = new ContextMenuStrip();
            var toolStripMenuDevicePart = new ToolStripMenuItem
            {
                Name = "toolStripMenuDevicePart",
                Text = "部件维护",
                Tag = "DevicePart",
                Image = "fa-microchip".GetBitmap(),
            };
            toolStripMenuDevicePart.Click += ToolStripMenuItem_Click;
            this.contextOpreatorMenu.Items.Add(toolStripMenuDevicePart);
            var deviceOprs = typeof(DeviceOperatorStyle).GetFields();
            foreach (var fieldInfo in deviceOprs)
            {
                if (!fieldInfo.FieldType.IsEnum) continue;
                var des = (DescriptionAttribute)(fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false)[0]);
                var iconImage = fieldInfo.Name.ToString().Equals("Maintain") ? "fa-steam-square".GetBitmap() : "fa-legal".GetBitmap();
                var toolStripMenuItem = new ToolStripMenuItem
                {
                    Name = "toolStripMenu" + fieldInfo.Name,
                    Text = des.Description,
                    Tag = fieldInfo.Name,
                    Image = iconImage,
                };
                toolStripMenuItem.Click += ToolStripMenuItem_Click;
                this.contextOpreatorMenu.Items.Add(toolStripMenuItem);
            }
            deviceOprs = typeof(DeviceMenuStyle).GetFields();
            foreach (var fieldInfo in deviceOprs)
            {
                if (!fieldInfo.FieldType.IsEnum) continue;
                var des = (DescriptionAttribute)(fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false)[0]);
                var iconImage = fieldInfo.Name.ToString().Equals("ModifyDevice") ? "fa-pencil-square-o".GetBitmap() : "fa-times-circle-o".GetBitmap();
                var toolStripMenuItem = new ToolStripMenuItem
                {
                    Name = "toolStripMenu" + fieldInfo.Name,
                    Text = des.Description,
                    Tag = fieldInfo.Name,
                    Image = iconImage,
                };
                toolStripMenuItem.Click += ToolStripMenuItem_Click;
                this.contextOpreatorMenu.Items.Add(toolStripMenuItem);
            }
        }
        public enum DeviceMenuStyle
        {
            [Description("修改设备")]
            ModifyDevice = 0x01,
            [Description("删除设备")]
            DeleteDevice = 0x02,
        }
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var toolMenu = (ToolStripMenuItem)sender;
            switch (toolMenu.Tag.ToString())
            {
                case "Maintain":
                    if (null == this._device || this._device.DeviceParts.Count == 0)
                    {
                        MessageBox.Show("设备部件信息为空，请先添加设备部件！");
                        return;
                    }
                    var deviceMaintain = new DeviceMaintainAndRepair(DeviceOperatorStyle.Maintain, this._device.DeviceParts);
                    deviceMaintain.StartPosition = FormStartPosition.CenterParent;
                    if (deviceMaintain.ShowDialog() == DialogResult.OK)
                    {

                    }
                    break;
                case "ModifyDevice":
                    ModifyEventClicked?.Invoke(this, e);
                    break;
                case "DeleteDevice":
                    DeleteEventClicked?.Invoke(this, e);
                    break;
                case "Repair":
                    if (null == this._device || this._device.DeviceParts.Count == 0)
                    {
                        MessageBox.Show("设备部件信息为空，请先添加设备部件！");
                        return;
                    }
                    var deviceRepair = new DeviceMaintainAndRepair(DeviceOperatorStyle.Repair, this._device.DeviceParts);
                    deviceRepair.StartPosition = FormStartPosition.CenterParent;
                    if (deviceRepair.ShowDialog() == DialogResult.OK)
                    {

                    }
                    break;
                case "DevicePart":
                    var devicePartEdit = new DevicePartEdit();
                    devicePartEdit.StartPosition = FormStartPosition.CenterParent;
                    devicePartEdit.ShowDialog();
                    if (devicePartEdit.ShowDialog() == DialogResult.OK)
                    {

                    }
                    break;
                default:
                    break;
            }
        }
        public event EventHandler ModifyEventClicked;
        public event EventHandler DeleteEventClicked;
    }
}

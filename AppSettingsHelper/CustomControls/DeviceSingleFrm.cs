using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using SalesFeedBackInfrasturcture.Entities;
using SalesFeedBackInfrasturcture.Infrastructure;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;
using System.Threading.Tasks;

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
        List<String> _PartIds;
        public void SetMaintainCount(String partId)
        {
            if (null == _PartIds) _PartIds = new List<string>();
            if (_PartIds.Contains(partId)) return;
            _PartIds.Add(partId);
            this.miantainShowCountControl1.Pis_Index = _PartIds.Count.ToString(); 
        }
        public void RemoveMaintainCount(String partId)
        {
            if (null == _PartIds) return;
            if (_PartIds.Contains(partId))
                _PartIds.Remove(partId);
            if (_PartIds.Count == 0)
                this.miantainShowCountControl1.Visible = false;
            this.miantainShowCountControl1.Pis_Index = _PartIds.Count.ToString();
        } 
        System.Threading.Timer timer;
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
            timer = new System.Threading.Timer(Processer, null, Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);
            //立即执行一次
            timer.Change(TimeSpan.Zero, Timeout.InfiniteTimeSpan);
        }
        private void Processer(object sender)
        { 
            //设置三分钟执行一次
            var nextTime = DateTime.Now.AddMinutes(3);
            //执行完后,重新设置定时器下次执行时间.
            timer.Change(nextTime.Subtract(DateTime.Now), Timeout.InfiniteTimeSpan);
            if (null == this._PartIds || this._PartIds.Count == 0)
            {
                return;
            }
            this.Invoke(new Action(() =>
            {
                this.miantainShowCountControl1.EclipsBackColor = Color.LightCoral;
                Task.Delay(30);
                this.miantainShowCountControl1.EclipsBackColor = Color.IndianRed;
                Task.Delay(30);
                this.miantainShowCountControl1.EclipsBackColor = Color.Firebrick;
                Task.Delay(30);
                this.miantainShowCountControl1.EclipsBackColor = Color.Brown;
                Task.Delay(30);
                this.miantainShowCountControl1.EclipsBackColor = Color.DarkRed;
                Task.Delay(30);
                this.miantainShowCountControl1.EclipsBackColor = Color.Maroon;
                Task.Delay(30);
                this.miantainShowCountControl1.EclipsBackColor = Color.Red;
                Task.Delay(30);
            }));

        }
        private void SetDeviceInfo(Device device)
        {
            this.lbl_title.Text = device.DeviceStyle.GetEnumDescription<DeviceStyle>();
            this.lbl_deviceId.Text = device.ID;
            this.lbl_deviceName.Text = device.DeviceName;
            this.lbl_devicePartNum.Text = device.DeviceParts.Count.ToString();
            this.lbl_deviceDescription.Text = device.DeviceDescription;
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
                    var deviceMaintain = new DeviceMaintainAndRepair(DeviceOperatorStyle.Maintain, this._device);
                    deviceMaintain.StartPosition = FormStartPosition.CenterParent;
                    if (deviceMaintain.ShowDialog() == DialogResult.OK)
                    {
                        this._device.DeviceParts = deviceMaintain._device.DeviceParts;
                        this.lbl_devicePartNum.Text = this._device.DeviceParts.Count.ToString();
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
                    var deviceRepair = new DeviceMaintainAndRepair(DeviceOperatorStyle.Repair, this._device);
                    deviceRepair.StartPosition = FormStartPosition.CenterParent;
                    if (deviceRepair.ShowDialog() == DialogResult.OK)
                    {
                        this._device.DeviceParts = deviceRepair._device.DeviceParts;
                        this.lbl_devicePartNum.Text = _device.DeviceParts.Count.ToString();
                    }
                    break;
                case "DevicePart":
                    var devicePartEdit = new DevicePartEdit(SalesFeedBackMain.OperatorType.Add, this._device.DeviceParts.Keys.ToArray());
                    devicePartEdit.StartPosition = FormStartPosition.CenterParent;
                    if (devicePartEdit.ShowDialog() == DialogResult.OK)
                    {
                        this._device.DeviceParts[devicePartEdit._DevicePart.ID] = devicePartEdit._DevicePart;
                        this.lbl_devicePartNum.Text = _device.DeviceParts.Count.ToString();
                        GlobalSet.WriteDevicePartToFile(_device, devicePartEdit._DevicePart, SalesFeedBackMain.OperatorType.Add);
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

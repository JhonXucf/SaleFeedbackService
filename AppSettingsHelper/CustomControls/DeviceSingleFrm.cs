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
            set { _device = value; }
        }
        ContextMenuStrip contextOpreatorMenu;
        public DeviceSingleFrm()
        {
            InitializeComponent();
            InitDeviceOpreatorMenu();
            foreach (Control item in this.Controls)
            {
                item.ContextMenuStrip = this.contextOpreatorMenu;
            }
        }
        void InitDeviceOpreatorMenu()
        {
            contextOpreatorMenu = new ContextMenuStrip();
            var deviceOprs = typeof(DeviceOpreatorStyle).GetFields();
            foreach (var fieldInfo in deviceOprs)
            {
                if (!fieldInfo.FieldType.IsEnum) continue;
                var des = (DescriptionAttribute)(fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false)[0]);
                var iconImage = fieldInfo.Name.ToString().Equals("Maintain") ? "fa-steam-square-o".GetBitmap() : "fa-legal".GetBitmap();
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
                    MessageBox.Show("保养设备");
                    break;
                case "ModifyDevice":
                    MessageBox.Show("修改设备");
                    ModifyEventClicked?.Invoke(this, e);
                    break;
                case "DeleteDevice":
                    MessageBox.Show("删除设备");
                    DeleteEventClicked?.Invoke(this, e);
                    break;
                case "Repair":
                    MessageBox.Show("维护设备");
                    break;
                default:
                    break;
            }
        }
        public event EventHandler ModifyEventClicked;
        public event EventHandler DeleteEventClicked;
    }
}

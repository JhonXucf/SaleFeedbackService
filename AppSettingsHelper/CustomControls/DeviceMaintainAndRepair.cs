using SalesFeedBackInfrasturcture.Entities;
using SalesFeedBackInfrasturcture.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AppSettingsHelper.CustomControls
{
    public partial class DeviceMaintainAndRepair : Form
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
        DeviceOperatorStyle _deviceOperator;
        /// <summary>
        /// 设备部件信息
        /// </summary>
        Dictionary<String, DevicePart> _deviceParts;
        public DeviceMaintainAndRepair(DeviceOperatorStyle deviceOperator, Dictionary<String, DevicePart> deviceParts)
        {
            InitializeComponent();
            _deviceOperator = deviceOperator;
            _deviceParts = deviceParts;
            switch (deviceOperator)
            {
                case DeviceOperatorStyle.Maintain:
                    this.lbl_title.Text = "设备保养";

                    break;
                case DeviceOperatorStyle.Repair:
                    this.lbl_title.Text = "设备维修";
                    this.lbl_maintainOperator.Text = "维修人员";
                    this.lbl_maintainTime.Text = "维修时间";
                    this.lbl_maintainImagePath.Text = "维修图片路径";
                    this.lbl_maintainDescription.Text = "维修详情";
                    break;
                default:
                    break;
            }
            foreach (var item in deviceParts)
            {
                var deviceSingle = new DevicePartSingle(item.Value);
                this.gbxContainer.Controls.Add(deviceSingle);
            }
            if (this.gbxContainer.Controls.Count > 0)
                this.gbxContainer.UpdateControlLocation(5, 5, 5);

        }
    }
}

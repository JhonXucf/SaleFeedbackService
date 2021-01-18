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
    public partial class DevicePartEdit : Form
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
        DevicePart devicePart;
        DevicePart DevicePart
        {
            get { return devicePart; }
            set
            {
                devicePart = value;
                if (null != value)
                {
                    SetDevicePart(value);
                }
            }
        }
        void SetDevicePart(DevicePart devicePart)
        {

        }
        DevicePart GetDevicePart()
        {
            DevicePart devicePart = new DevicePart();
            return devicePart;
        }
        public DevicePartEdit()
        {
            InitializeComponent();
        }
    }
}

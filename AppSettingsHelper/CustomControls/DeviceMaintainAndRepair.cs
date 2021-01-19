using SalesFeedBackInfrasturcture.Entities;
using SalesFeedBackInfrasturcture.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq.Expressions;
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
        public Dictionary<String, DevicePart> _deviceParts;
        public DeviceMaintainAndRepair(DeviceOperatorStyle deviceOperator, Dictionary<String, DevicePart> deviceParts)
        {
            InitializeComponent();
            this.txt_serach.SearchClick += Txt_serach_SearchClick;
            this.txt_serach.ClearClick += Txt_serach_ClearClick;
            this.txt_serach.TextChanged += Txt_serach_TextChanged;
            _deviceOperator = deviceOperator;
            _deviceParts = deviceParts;
            switch (deviceOperator)
            {
                case DeviceOperatorStyle.Maintain:
                    this.lbl_title.Text = "设备保养";
                    break;
                case DeviceOperatorStyle.Repair:
                    this.lbl_title.Text = "设备维修";
                    break;
                default:
                    break;
            }
            InitPartInfos();
        }
        private void InitPartInfos(Expression<Func<DevicePart, String, bool>> criteria = null, String text = null)
        {
            this.gbxContainer.Controls.Clear();
            foreach (var item in _deviceParts)
            {
                if (null != criteria)
                {
                    if (item.Value.Find(criteria, text))
                    {
                        var deviceSingle = new DevicePartSingle(item.Value, _deviceOperator);
                        deviceSingle.AddHandle += DeviceSingle_AddHandle;
                        deviceSingle.ModifiedHandle += DeviceSingle_ModifiedHandle;
                        deviceSingle.DeletedHandle += DeviceSingle_DeletedHandle;
                        this.gbxContainer.Controls.Add(deviceSingle);
                    }
                }
                else
                {
                    var deviceSingle = new DevicePartSingle(item.Value, _deviceOperator);
                    deviceSingle.AddHandle += DeviceSingle_AddHandle;
                    deviceSingle.ModifiedHandle += DeviceSingle_ModifiedHandle;
                    deviceSingle.DeletedHandle += DeviceSingle_DeletedHandle;
                    this.gbxContainer.Controls.Add(deviceSingle);
                }
            }
            if (this.gbxContainer.Controls.Count > 0)
            {
                if (null != criteria)
                    IsPatterned = true;
                else
                    IsPatterned = false;
                this.gbxContainer.UpdateControlLocation(5, 10, 5);
            }
            else
            {
                if (null != criteria)
                {
                    MessageBox.Show("没有匹配项！");
                }
            }
        }

        private void DeviceSingle_AddHandle(object sender, EventArgs e)
        {
            //调起维护界面
            Int16 count = 0;
            DevicePartSingle devicePartSingle;
            DevicePart devicePart = null;
            foreach (Control item in this.gbxContainer.Controls)
            {
                if (item is DevicePartSingle)
                {
                    devicePartSingle = item as DevicePartSingle;
                    if (devicePartSingle.IsSelected)
                        count++;
                    if (count > 1)
                    {
                        devicePart = null;
                        break;
                    }
                    else
                    {
                        devicePart = devicePartSingle._DevicePart;
                    }
                }
            }
            var mainAndRepair = new DeviceMainTainAndRepairEdit(this._deviceOperator, devicePart);
            mainAndRepair.StartPosition = FormStartPosition.CenterParent;
            if (mainAndRepair.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void DeviceSingle_DeletedHandle(object sender, EventArgs e)
        {
            var partSingle = sender as DevicePartSingle;
            if (this._deviceParts.ContainsKey(partSingle._DevicePart.ID))
                this._deviceParts.Remove(partSingle._DevicePart.ID);
            if (this._deviceParts.Count == 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void DeviceSingle_ModifiedHandle(object sender, EventArgs e)
        {
            var partSingle = sender as DevicePartSingle;
            if (this._deviceParts.ContainsKey(partSingle._DevicePart.ID))
                this._deviceParts[partSingle._DevicePart.ID] = partSingle._DevicePart;
        }

        private void Txt_serach_TextChanged(object sender, EventArgs e)
        {
            var textbox = sender as TextBoxEx;
            if (string.IsNullOrWhiteSpace(textbox.Text))
            {
                if (IsPatterned)
                {
                    InitPartInfos();
                }
            }
        }
        /// <summary>
        /// 是否匹配到项目
        /// </summary>
        Boolean IsPatterned = false;
        private void Txt_serach_ClearClick(object sender, EventArgs e)
        {
            if (IsPatterned)
            {
                InitPartInfos();
            }
        }

        private void Txt_serach_SearchClick(object sender, EventArgs e)
        {
            var textbox = sender as UCTextBoxEx;
            var inputText = textbox.InputText;
            if (string.IsNullOrWhiteSpace(inputText))
            {
                return;
            }
            Expression<Func<DevicePart, String, bool>> criteria = (d, text) => d.ID.Contains(text) || d.PartName.Contains(text) || d.PartDescription.Contains(text) || d.ModelNumber.Contains(text);
            InitPartInfos(criteria, inputText);
        }

        private void btn_Close_BtnClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void btn_Save_BtnClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

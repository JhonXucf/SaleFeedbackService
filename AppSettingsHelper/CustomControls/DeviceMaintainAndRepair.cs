using SalesFeedBackInfrasturcture.Entities;
using SalesFeedBackInfrasturcture.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Drawing;
using System.Linq.Expressions;
using System.Threading.Tasks;
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
            if (e.X < this.Height / 2) return;
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
        public Device _device;
        /// <summary>
        /// 需要保养的部件Id集合
        /// </summary>
        List<String> _PartIds;
        public DeviceMaintainAndRepair(DeviceOperatorStyle deviceOperator, Device device, List<String> partIds = null)
        {
            InitializeComponent();
            if (null != partIds)
            {
                _PartIds = partIds;
            }
            this.txt_serach.SearchClick += Txt_serach_SearchClick;
            this.txt_serach.ClearClick += Txt_serach_ClearClick;
            this.txt_serach.TextChanged += Txt_serach_TextChanged;
            _deviceOperator = deviceOperator;
            _device = device;
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
            foreach (var item in _device.DeviceParts)
            {
                if (null != criteria)
                {
                    if (item.Value.Find(criteria, text))
                    {
                        var deviceSingle = new DevicePartSingle(item.Value, _deviceOperator);
                        if (null != _PartIds && _PartIds.Contains(item.Key))
                        {
                            deviceSingle.IsSelected = true;
                        }
                        deviceSingle.AddHandle += DeviceSingle_AddHandle;
                        deviceSingle.ModifiedHandle += DeviceSingle_ModifiedHandle;
                        deviceSingle.DeletedHandle += DeviceSingle_DeletedHandle;
                        this.gbxContainer.Controls.Add(deviceSingle);
                    }
                }
                else
                {
                    var deviceSingle = new DevicePartSingle(item.Value, _deviceOperator);
                    if (null != _PartIds && _PartIds.Contains(item.Key))
                    {
                        deviceSingle.IsSelected = true;
                    }
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
            DevicePartSingle devicePartSingle = sender as DevicePartSingle;
            DevicePart devicePart = devicePartSingle._DevicePart;
            if (null != e)//如果参数是null，则代表双击了
            {
                foreach (Control item in this.gbxContainer.Controls)
                {
                    if (item is DevicePartSingle)
                    {
                        DevicePartSingle tempSingle = item as DevicePartSingle;
                        if (!tempSingle.IsSelected) continue;
                        count++;
                        if (count > 1)
                        {
                            devicePart = null;
                            break;
                        }
                    }
                }
            }
            var mainAndRepair = new DeviceMainTainAndRepairEdit(this._deviceOperator, devicePart);
            mainAndRepair.StartPosition = FormStartPosition.CenterParent;
            if (mainAndRepair.ShowDialog() == DialogResult.OK)
            {
                if (count > 1)
                {
                    if (this._deviceOperator == DeviceOperatorStyle.Maintain && mainAndRepair._DevicePart.MaintainDetails.Count == 0) return;
                    if (this._deviceOperator == DeviceOperatorStyle.Repair && mainAndRepair._DevicePart.RepairDetails.Count == 0) return;
                    foreach (Control item in this.gbxContainer.Controls)
                    {
                        if (item is DevicePartSingle)
                        {
                            devicePartSingle = item as DevicePartSingle;
                            if (devicePartSingle.IsSelected)
                            {
                                if (this._deviceOperator == DeviceOperatorStyle.Maintain)
                                {
                                    foreach (var maintain in mainAndRepair._DevicePart.MaintainDetails)
                                    {
                                        if (devicePartSingle._DevicePart.MaintainDetails.ContainsKey(maintain.Key))
                                        {
                                            devicePartSingle._DevicePart.MaintainDetails[maintain.Key] = maintain.Value;
                                            continue;
                                        }
                                        devicePartSingle._DevicePart.MaintainDetails[maintain.Key] = maintain.Value;
                                    }
                                    devicePartSingle.MaintainCount = devicePartSingle._DevicePart.MaintainDetails.Count;
                                }
                                else
                                {
                                    foreach (var maintain in mainAndRepair._DevicePart.RepairDetails)
                                    {
                                        if (devicePartSingle._DevicePart.RepairDetails.ContainsKey(maintain.Key))
                                        {
                                            devicePartSingle._DevicePart.RepairDetails[maintain.Key] = maintain.Value;
                                            continue;
                                        }
                                        devicePartSingle._DevicePart.RepairDetails[maintain.Key] = maintain.Value;
                                    }
                                    devicePartSingle.MaintainCount = devicePartSingle._DevicePart.RepairDetails.Count;
                                }
                            }
                        }
                    }
                    GlobalSet.WriteDevicePartMainTainOrRepaitToFile(this._device, devicePartSingle._DevicePart, _deviceOperator, SalesFeedBackMain.OperatorType.Add);
                }
                else
                {
                    devicePartSingle.MaintainCount = this._deviceOperator == DeviceOperatorStyle.Maintain? mainAndRepair._DevicePart.MaintainDetails.Count:
                         mainAndRepair._DevicePart.RepairDetails.Count;
                    GlobalSet.WriteDevicePartMainTainOrRepaitToFile(this._device, devicePart, _deviceOperator, SalesFeedBackMain.OperatorType.Add);

                    #region 不允许删除保养和维修记录
                    //if (this._deviceOperator == DeviceOperatorStyle.Maintain)
                    //{
                    //    var deleteMaintains = new List<DeviceMaintain>();
                    //    foreach (var item in devicePart.MaintainDetails)
                    //    {
                    //        //如果不存在，则说明删除了
                    //        if (mainAndRepair._DevicePart.MaintainDetails.Keys.Where(p => !p.Contains(item.Key)).Count() == 0)
                    //        {
                    //            deleteMaintains.Add(item.Value);
                    //        }
                    //    }
                    //    devicePartSingle.MaintainCount = mainAndRepair._DevicePart.MaintainDetails.Count;
                    //    devicePartSingle._DevicePart = mainAndRepair._DevicePart;
                    //    GlobalSet.WriteDevicePartMainTainOrRepaitToFile(this._device, devicePartSingle._DevicePart, _deviceOperator, SalesFeedBackMain.OperatorType.Add);
                    //    if (deleteMaintains.Count > 0)
                    //    {
                    //        GlobalSet.WriteDevicePartMainTainOrRepaitToFile(this._device, devicePartSingle._DevicePart, _deviceOperator, SalesFeedBackMain.OperatorType.Delete, deleteMaintains);
                    //    }
                    //}
                    //else
                    //{
                    //    devicePartSingle.MaintainCount = mainAndRepair._DevicePart.RepairDetails.Count;
                    //    var deleteRepairs = new List<DeviceRepair>();
                    //    foreach (var item in devicePart.RepairDetails)
                    //    {
                    //        //如果不存在，则说明删除了
                    //        if (mainAndRepair._DevicePart.RepairDetails.Keys.Where(p => !p.Contains(item.Key)).Count() == 0)
                    //        {
                    //            deleteRepairs.Add(item.Value);
                    //        }
                    //    }
                    //    devicePartSingle.MaintainCount = mainAndRepair._DevicePart.MaintainDetails.Count;
                    //    devicePartSingle._DevicePart = mainAndRepair._DevicePart;
                    //    GlobalSet.WriteDevicePartMainTainOrRepaitToFile(this._device, devicePartSingle._DevicePart, _deviceOperator, SalesFeedBackMain.OperatorType.Add);
                    //    if (deleteRepairs.Count > 0)
                    //    {
                    //        GlobalSet.WriteDevicePartMainTainOrRepaitToFile(this._device, devicePartSingle._DevicePart, _deviceOperator, SalesFeedBackMain.OperatorType.Delete, null, deleteRepairs);
                    //    }
                    //}
                    #endregion 
                }
            }
        }
        /// <summary>
        /// 删除部件直接保存到文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeviceSingle_DeletedHandle(object sender, EventArgs e)
        {
            var partSingle = sender as DevicePartSingle;
            if (MessageBox.Show("确定删除设备部件[" + partSingle.DevicePartId + "]吗?", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (this._device.DeviceParts.ContainsKey(partSingle.DevicePartId))
                {
                    this._device.DeviceParts.Remove(partSingle.DevicePartId);
                    GlobalSet.WriteDevicePartToFile(_device, partSingle._DevicePart, SalesFeedBackMain.OperatorType.Delete);
                }
                if (_device.DeviceParts.Count == 0)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
        /// <summary>
        /// 修改部件信息之后直接保存文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeviceSingle_ModifiedHandle(object sender, EventArgs e)
        {
            var partSingle = sender as DevicePartSingle;
            if (_device.DeviceParts.ContainsKey(partSingle.DevicePartId))
            {
                _device.DeviceParts[partSingle.DevicePartId] = partSingle._DevicePart;
                GlobalSet.WriteDevicePartToFile(_device, partSingle._DevicePart, SalesFeedBackMain.OperatorType.Modify);
            }
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

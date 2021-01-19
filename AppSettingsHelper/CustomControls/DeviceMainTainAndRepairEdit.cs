using SalesFeedBackInfrasturcture.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SalesFeedBackInfrasturcture.Entities;

namespace AppSettingsHelper.CustomControls
{
    public partial class DeviceMainTainAndRepairEdit : Form
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
        DeviceMaintain _deviceMaintian;
        DeviceRepair _deviceRepair;
        DevicePart _devicePart;
        public DeviceMainTainAndRepairEdit(DeviceOperatorStyle deviceOperator, DevicePart devicePart = null)
        {
            InitializeComponent();
            _deviceOperator = deviceOperator;
            switch (deviceOperator)
            {
                case DeviceOperatorStyle.Maintain:
                    this.lbl_title.Text = "部件保养明细";
                    InitDataGridview("保养");
                    if (null != devicePart)
                    {
                        Int32 index = 0;
                        foreach (var item in devicePart.MaintainDetails)
                        {
                            this.dataGridView1.Rows.Add(
                                index++,
                                item.Value.ID,
                                item.Value.MaintainMan,
                                item.Value.MaintainTime,
                                item.Value.MaintainImagePath,
                                item.Value.MaintainBody);
                        }
                    }
                    break;
                case DeviceOperatorStyle.Repair:
                    this.lbl_title.Text = "部件维修明细";
                    this.lbl_maintainId.Text = "维修ID";
                    this.lbl_maintainOperator.Text = "维修人员";
                    this.lbl_maintainTime.Text = "维修时间";
                    this.lbl_maintainImagePath.Text = "维修图片路径";
                    this.lbl_maintainDescription.Text = "维修详情";
                    InitDataGridview("维修");
                    if (null != devicePart)
                    {
                        Int32 index = 0;
                        foreach (var item in devicePart.RepairDetails)
                        {
                            this.dataGridView1.Rows.Add(
                                index++,
                                item.Value.ID,
                                item.Value.RepairMan,
                                item.Value.RepairTime,
                                item.Value.RepairImagePath,
                                item.Value.RepairBody);
                        }
                    }
                    break;
                default:
                    break;
            }

        }
        void InitDataGridview(String title)
        {
            var index = new DataGridViewTextBoxColumn();
            index.DisplayIndex = 0;
            index.Width = 20;
            index.Name = "Index";
            index.HeaderText = "序号";
            var ID = new DataGridViewTextBoxColumn();
            ID.DisplayIndex = 1;
            ID.Width = 50;
            ID.Name = "ID";
            ID.HeaderText = title + "ID";
            var person = new DataGridViewTextBoxColumn();
            person.DisplayIndex = 2;
            person.Width = 50;
            person.Name = "person";
            person.HeaderText = title + "人员";
            var time = new DataGridViewTextBoxColumn();
            time.DisplayIndex = 3;
            time.Width = 50;
            time.Name = "time";
            time.HeaderText = title + "时间";
            var path = new DataGridViewTextBoxColumn();
            path.DisplayIndex = 4;
            path.Width = 120;
            path.Name = "path";
            path.HeaderText = title + "图片路径";
            var description = new DataGridViewTextBoxColumn();
            description.DisplayIndex = 5;
            description.Width = 180;
            description.Name = "description";
            description.HeaderText = title + "详情";
            var deletebutton = new DataGridViewButtonColumn();
            deletebutton.DisplayIndex = 6;
            deletebutton.Width = 30;
            deletebutton.Name = "deletebutton";
            deletebutton.HeaderText = "删除";
            this.dataGridView1.Columns.AddRange(index, ID, person, time, path, description, deletebutton);
        }
        private void btnPathSelect_BtnClick(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog pOpenFileDialog = new OpenFileDialog();
                pOpenFileDialog.Filter =
                  "All Image Files|*.bmp;*.ico;*.gif;*.jpeg;*.jpg;*.png;*.tif;*.tiff;*.emf|" +
                  "Windows Bitmap(*.bmp)|*.bmp|" +
                  "Windows Icon(*.ico)|*.ico|" +
                  "Graphics Interchange Format (*.gif)|(*.gif)|" +
                  "JPEG File Interchange Format (*.jpg)|*.jpg;*.jpeg|" +
                  "Portable Network Graphics (*.png)|*.png|" +
                  "Tag Image File Format (*.tif)|*.tif;*.tiff|" +
                  "EMF File (*.emf)|*.emf";
                pOpenFileDialog.Multiselect = false;
                //"打开图片"
                pOpenFileDialog.Title = "Select Picture";/* GetString("OpenFileDialog_img");*/
                if (!string.IsNullOrWhiteSpace(this.txt_maintainImagePath.Text))
                    pOpenFileDialog.InitialDirectory = this.txt_maintainImagePath.Text;
                if (pOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.txt_maintainImagePath.Text = pOpenFileDialog.FileName;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btn_Save_BtnClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_Close_BtnClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_Cancel_BtnClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}

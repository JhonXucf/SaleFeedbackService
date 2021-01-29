using SalesFeedBackInfrasturcture.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SalesFeedBackInfrasturcture.Entities;
using System.Linq;
using System.Threading.Tasks;

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
        DataTable _dt;
        public DevicePart _DevicePart => _devicePart;
        public DeviceMainTainAndRepairEdit(DeviceOperatorStyle deviceOperator, DevicePart devicePart = null)
        {
            InitializeComponent();
            this.Load += DeviceMainTainAndRepairEdit_Load;
            _deviceOperator = deviceOperator;
            _devicePart = devicePart;
            #region 我擅作主张将删除功能去掉了，如果以后有需要可以开启，我的意思是保养和维修数据不管是不是测试数据都可以保留
            //ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            //var toolStripMenuItemDelete = new ToolStripMenuItem
            //{
            //    Name = "toolStripMenuDelete",
            //    Text = "删除",
            //    Image = "fa-times-circle-o".GetBitmap(),
            //};
            //toolStripMenuItemDelete.Click += ToolStripMenuItemDelete_Click;
            //contextMenuStrip.Items.Add(toolStripMenuItemDelete);
            //var toolStripMenuItemSelectAll = new ToolStripMenuItem
            //{
            //    Name = "toolStripMenuItemSelectAll",
            //    Text = "全选",
            //    Image = "fa-check-circle-o".GetBitmap(),
            //};
            //toolStripMenuItemSelectAll.Click += ToolStripMenuItemSelectAll_Click;
            //contextMenuStrip.Items.Add(toolStripMenuItemSelectAll);
            //var toolStripMenuItemNoSelete = new ToolStripMenuItem
            //{
            //    Name = "toolStripMenuItemNoSelete",
            //    Text = "反选",
            //    Image = "fa-times-circle-o".GetBitmap(),
            //};
            //toolStripMenuItemNoSelete.Click += ToolStripMenuItemNoSelete_Click;
            //contextMenuStrip.Items.Add(toolStripMenuItemNoSelete);
            //this.dataGridView1.ContextMenuStrip = contextMenuStrip;
            #endregion
        }
        #region 删除功能
        //Boolean IsAllSelected = false;
        //private void ToolStripMenuItemNoSelete_Click(object sender, EventArgs e)
        //{
        //    if (this.dataGridView1.Rows.Count == 0) return;
        //    foreach (DataGridViewRow item in this.dataGridView1.Rows)
        //    {
        //        item.Selected = false;
        //    }
        //    IsAllSelected = false;
        //}

        //private void ToolStripMenuItemSelectAll_Click(object sender, EventArgs e)
        //{
        //    if (this.dataGridView1.Rows.Count == 0) return;
        //    foreach (DataGridViewRow item in this.dataGridView1.Rows)
        //    {
        //        item.Selected = true;
        //    }
        //    IsAllSelected = true;
        //}

        //private void ToolStripMenuItemDelete_Click(object sender, EventArgs e)
        //{
        //    if (this.dataGridView1.Rows.Count == 0) return;
        //    if (IsAllSelected)
        //    {
        //        if (MessageBox.Show("确定删除所有吗?", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
        //        {
        //            if (_deviceOperator == DeviceOperatorStyle.Maintain)
        //            {
        //                _devicePart.MaintainDetails.Clear();
        //            }
        //            else
        //            {
        //                _devicePart.RepairDetails.Clear();
        //            }
        //            dataGridView1.Rows.Clear();
        //        }
        //        return;
        //    }
        //    if (rowIndex < 0) return;
        //    string Id = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
        //    if (MessageBox.Show("确定删除[" + Id + "]吗?", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
        //    {
        //        if (_deviceOperator == DeviceOperatorStyle.Maintain)
        //        {
        //            if (_devicePart.MaintainDetails.ContainsKey(Id))
        //            {
        //                _devicePart.MaintainDetails.Remove(Id);
        //            }
        //            dataGridView1.Rows.RemoveAt(rowIndex);
        //        }
        //        else
        //        {
        //            if (_devicePart.RepairDetails.ContainsKey(Id))
        //            {
        //                _devicePart.RepairDetails.Remove(Id);

        //            }
        //            dataGridView1.Rows.RemoveAt(rowIndex);
        //        }
        //    }
        //}
        #endregion

        private void DeviceMainTainAndRepairEdit_Load(object sender, EventArgs e)
        {
            switch (_deviceOperator)
            {
                case DeviceOperatorStyle.Maintain:
                    this.lbl_title.Text = "部件保养明细";
                    InitMaintainDataGridview("保养");
                    this.dataGridView1.Rows.Clear();
                    if (null != _devicePart)
                    {
                        Int32 index = 0;
                        foreach (var item in _devicePart.MaintainDetails)
                        {
                            DataRow dr = _dt.NewRow();
                            dr[0] = index++;
                            dr[1] = item.Value.ID.ToString();
                            dr[2] = item.Value.MaintainMan.ToString();
                            dr[3] = item.Value.MaintainTime.ToLocalTime().ToString();
                            dr[4] = MaintainTimeToLocalTime(_devicePart, item.Value.MaintainTime).ToLocalTime().ToString();
                            dr[5] = item.Value.MaintainBody.ToString();
                            _dt.Rows.Add(dr);
                        }
                    }
                    break;
                case DeviceOperatorStyle.Repair:
                    this.lbl_title.Text = "部件维修明细";
                    this.lbl_PartImage.Text = "维修图片";
                    this.lbl_maintainId.Text = "维修ID";
                    this.lbl_maintainOperator.Text = "维修人员";
                    this.lbl_maintainTime.Text = "维修时间";
                    this.lbl_maintainDescription.Text = "维修详情";
                    InitDataGridview("维修");
                    this.dataGridView1.Rows.Clear();
                    if (null != _devicePart)
                    {
                        Int32 index = 0;
                        foreach (var item in _devicePart.RepairDetails)
                        {
                            DataRow dr = _dt.NewRow();
                            dr[0] = index++;
                            dr[1] = item.Value.ID.ToString();
                            dr[2] = item.Value.RepairMan.ToString();
                            dr[3] = item.Value.RepairTime.ToLocalTime().ToString();
                            dr[4] = item.Value.RepairBody.ToString();
                            _dt.Rows.Add(dr);
                        }
                    }
                    break;
                default:
                    break;
            }
            this.dataGridView1.DataSource = _dt;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private DateTime MaintainTimeToLocalTime(DevicePart devicePart, DateTime maintianTime)
        {
            foreach (var mainCycle in devicePart.MaintainCycles)
            {
                switch (mainCycle.Key)
                {
                    case DeviceMaintainStyle.Minute:
                        maintianTime = maintianTime.AddMinutes(mainCycle.Value);
                        break;
                    case DeviceMaintainStyle.Hour:
                        maintianTime = maintianTime.AddHours(mainCycle.Value);
                        break;
                    case DeviceMaintainStyle.Day:
                        maintianTime = maintianTime.AddDays(mainCycle.Value);
                        break;
                    case DeviceMaintainStyle.Month:
                        maintianTime = maintianTime.AddMonths(mainCycle.Value);
                        break;
                    case DeviceMaintainStyle.Quarter:
                        maintianTime = maintianTime.AddMonths(mainCycle.Value * 3);
                        break;
                    case DeviceMaintainStyle.Year:
                        maintianTime = maintianTime.AddYears(mainCycle.Value);
                        break;
                    default:
                        break;
                }
            }
            return maintianTime;
        }
        void InitMaintainDataGridview(String title)
        {
            _dt = new DataTable();
            _dt.Columns.AddRange(new DataColumn[] {
                new DataColumn("序号",typeof(String)),
                new DataColumn(title +"ID",typeof(String)),
                new DataColumn(title + "人员",typeof(String)),
                new DataColumn( title + "时间",typeof(String)),
                new DataColumn("下次"+ title + "时间",typeof(String)),
                new DataColumn( title + "详情",typeof(String)),
            });
        }
        void InitDataGridview(String title)
        {
            _dt = new DataTable();
            _dt.Columns.AddRange(new DataColumn[] {
                new DataColumn("序号",typeof(String)),
                new DataColumn(title +"ID",typeof(String)),
                new DataColumn(title + "人员",typeof(String)),
                new DataColumn( title + "时间",typeof(String)),
                new DataColumn( title + "详情",typeof(String)),
            });
        }
        String pathImg;
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
                pOpenFileDialog.Multiselect = true;
                //"打开图片"
                pOpenFileDialog.Title = "Select Picture";/* GetString("OpenFileDialog_img");*/
                if (!string.IsNullOrWhiteSpace(pathImg))
                    pOpenFileDialog.InitialDirectory = pathImg;
                if (pOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (pOpenFileDialog.FileNames.Length > 1)
                    {
                        pathImg = pOpenFileDialog.FileNames[0];
                        if (pOpenFileDialog.FileNames.Length >= 1)
                        {
                            this.pcb_PartImage.SizeMode = PictureBoxSizeMode.StretchImage;
                            this.pcb_PartImage.Image = Image.FromFile(pOpenFileDialog.FileNames[0]);
                        }
                        if (pOpenFileDialog.FileNames.Length >= 2)
                        {
                            this.pcb_PartImage1.SizeMode = PictureBoxSizeMode.StretchImage;
                            this.pcb_PartImage1.Image = Image.FromFile(pOpenFileDialog.FileNames[1]);
                        }
                        if (pOpenFileDialog.FileNames.Length >= 3)
                        {
                            this.pcb_PartImage2.SizeMode = PictureBoxSizeMode.StretchImage;
                            this.pcb_PartImage2.Image = Image.FromFile(pOpenFileDialog.FileNames[2]);
                        }
                        if (pOpenFileDialog.FileNames.Length >= 4)
                        {
                            this.pcb_PartImage3.SizeMode = PictureBoxSizeMode.StretchImage;
                            this.pcb_PartImage3.Image = Image.FromFile(pOpenFileDialog.FileNames[3]);
                        }
                        if (pOpenFileDialog.FileNames.Length >= 5)
                        {
                            this.pcb_PartImage4.SizeMode = PictureBoxSizeMode.StretchImage;
                            this.pcb_PartImage4.Image = Image.FromFile(pOpenFileDialog.FileNames[4]);
                        }
                    }
                    else
                    {
                        pathImg = pOpenFileDialog.FileName;
                        this.pcb_PartImage.SizeMode = PictureBoxSizeMode.StretchImage;
                        this.pcb_PartImage.Image = Image.FromFile(pOpenFileDialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                GlobalSet.m_Logger.Error("添加图片", ex);
            }
        }

        private void btn_Save_BtnClick(object sender, EventArgs e)
        {
            if (_deviceOperator == DeviceOperatorStyle.Maintain)
            {
                if (String.IsNullOrWhiteSpace(this.tbx_maintainId.Text))
                {
                    this.errorProvider1.SetError(this.lbl_error, "保养ID不能为空！");
                    return;
                }
                if (_devicePart != null)
                {
                    if (_devicePart.MaintainDetails.ContainsKey(this.tbx_maintainId.Text))
                    {
                        _devicePart.MaintainDetails[this.tbx_maintainId.Text].MaintainMan = this.txt_maintainOperator.Text;
                        _devicePart.MaintainDetails[this.tbx_maintainId.Text].MaintainTime = this.dtime_maintainTime.Value.ToUniversalTime();
                        _devicePart.MaintainDetails[this.tbx_maintainId.Text].MaintainImages = GetBytes();
                        _devicePart.MaintainDetails[this.tbx_maintainId.Text].MaintainBody = this.txt_maintainDescription.Text;
                        _devicePart.MaintainDetails[this.tbx_maintainId.Text].Modified = DateTime.UtcNow;
                        for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                        {
                            if (!this.dataGridView1.Rows[i].IsNewRow && this.dataGridView1.Rows[i].Cells[1].Value.ToString().Equals(this.tbx_maintainId.Text))
                            {
                                this.dataGridView1.BeginEdit(true);
                                this.dataGridView1.Rows[i].Cells[2].Value = this.txt_maintainOperator.Text;
                                this.dataGridView1.Rows[i].Cells[3].Value = this.dtime_maintainTime.Value;
                                this.dataGridView1.Rows[i].Cells[4].Value = MaintainTimeToLocalTime(_devicePart, this.dtime_maintainTime.Value).ToLocalTime().ToString();
                                this.dataGridView1.Rows[i].Cells[5].Value = this.txt_maintainDescription.Text;
                                this.dataGridView1.EndEdit();
                                break;
                            }
                        }
                        this.errorProvider1.SetError(this.lbl_error, "保养ID已存在！修改完成");
                        return;
                    }
                }
                else
                    this._devicePart = new DevicePart();
                _deviceMaintian = new DeviceMaintain();
                _deviceMaintian.ID = this.tbx_maintainId.Text;
                _deviceMaintian.MaintainMan = this.txt_maintainOperator.Text;
                _deviceMaintian.MaintainTime = this.dtime_maintainTime.Value.ToUniversalTime();
                _deviceMaintian.MaintainBody = this.txt_maintainDescription.Text;
                _deviceMaintian.MaintainImages = GetBytes();
                _deviceMaintian.Created = DateTime.UtcNow;

                this._devicePart.MaintainDetails[this.tbx_maintainId.Text] = _deviceMaintian;

                Int32 index = this._devicePart.MaintainDetails.Count - 1;
                DataRow dr = _dt.NewRow();
                dr[0] = index++;
                dr[1] = _deviceMaintian.ID.ToString();
                dr[2] = _deviceMaintian.MaintainMan.ToString();
                dr[3] = _deviceMaintian.MaintainTime.ToLocalTime().ToString();
                dr[4] = MaintainTimeToLocalTime(_devicePart, this.dtime_maintainTime.Value).ToLocalTime().ToString();
                dr[5] = _deviceMaintian.MaintainBody.ToString();
                _dt.Rows.Add(dr);
            }
            else
            {
                if (String.IsNullOrWhiteSpace(this.tbx_maintainId.Text))
                {
                    this.errorProvider1.SetError(this.lbl_error, "维修ID不能为空！");
                    return;
                }
                if (_devicePart != null)
                {
                    if (_devicePart.RepairDetails.ContainsKey(this.tbx_maintainId.Text))
                    {
                        _devicePart.RepairDetails[this.tbx_maintainId.Text].RepairMan = this.txt_maintainOperator.Text;
                        _devicePart.RepairDetails[this.tbx_maintainId.Text].RepairTime = this.dtime_maintainTime.Value.ToUniversalTime();
                        _devicePart.RepairDetails[this.tbx_maintainId.Text].RepairBody = this.txt_maintainDescription.Text;
                        _devicePart.RepairDetails[this.tbx_maintainId.Text].RepairImages = GetBytes();
                        _devicePart.RepairDetails[this.tbx_maintainId.Text].Modified = DateTime.UtcNow;
                        for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
                        {
                            if (!this.dataGridView1.Rows[i].IsNewRow && this.dataGridView1.Rows[i].Cells[1].Value.ToString().Equals(this.tbx_maintainId.Text))
                            {
                                this.dataGridView1.BeginEdit(true);
                                this.dataGridView1.Rows[i].Cells[2].Value = this.txt_maintainOperator.Text;
                                this.dataGridView1.Rows[i].Cells[3].Value = this.dtime_maintainTime.Value.ToString();
                                this.dataGridView1.Rows[i].Cells[4].Value = this.txt_maintainDescription.Text;
                                this.dataGridView1.EndEdit();
                                break;
                            }
                        }
                        this.errorProvider1.SetError(this.lbl_error, "维修ID已存在！修改完成！");
                        return;
                    }
                }
                else
                    this._devicePart = new DevicePart();
                _deviceRepair = new DeviceRepair();
                _deviceRepair.ID = this.tbx_maintainId.Text;
                _deviceRepair.RepairMan = this.txt_maintainOperator.Text;
                _deviceRepair.RepairTime = this.dtime_maintainTime.Value.ToUniversalTime();
                _deviceRepair.RepairBody = this.txt_maintainDescription.Text;
                _deviceRepair.RepairImages = GetBytes();
                _deviceRepair.Created = DateTime.UtcNow;

                this._devicePart.RepairDetails[this.tbx_maintainId.Text] = _deviceRepair;
                Int32 index = this._devicePart.RepairDetails.Count - 1;
                DataRow dr = _dt.NewRow();
                dr[0] = index++;
                dr[1] = _deviceRepair.ID.ToString();
                dr[2] = _deviceRepair.RepairMan.ToString();
                dr[3] = _deviceRepair.RepairTime.ToLocalTime().ToString();
                dr[4] = _deviceRepair.RepairBody.ToString();
                _dt.Rows.Add(dr);
            }
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
        Int32 rowIndex = -1;
        Int32 columnIndex = -1;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            rowIndex = e.RowIndex;
            columnIndex = e.ColumnIndex;

            this.tbx_maintainId.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            if (String.IsNullOrWhiteSpace(this.tbx_maintainId.Text))
            {
                return;
            }
            this.txt_maintainOperator.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            this.dtime_maintainTime.Value = DateTime.Parse(dataGridView1.Rows[rowIndex].Cells[3].Value.ToString());
            this.txt_maintainDescription.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
            List<Bitmap> images = null;
            if (_deviceOperator == DeviceOperatorStyle.Maintain)
            {
                images = GetImages(_devicePart.MaintainDetails[this.tbx_maintainId.Text].MaintainImages);
            }
            else
            {
                images = GetImages(_devicePart.RepairDetails[this.tbx_maintainId.Text].RepairImages);
            }
            if (null != images && images.Count > 0)
            {
                if (images.Count >= 1)
                {
                    this.pcb_PartImage.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.pcb_PartImage.Image = images[0];
                }
                if (images.Count >= 2)
                {
                    this.pcb_PartImage1.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.pcb_PartImage1.Image = images[1];
                }
                if (images.Count >= 3)
                {
                    this.pcb_PartImage2.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.pcb_PartImage2.Image = images[2];
                }
                if (images.Count >= 4)
                {
                    this.pcb_PartImage3.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.pcb_PartImage3.Image = images[3];
                }
                if (images.Count >= 5)
                {
                    this.pcb_PartImage4.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.pcb_PartImage4.Image = images[4];
                }
            }
        }

        private void btn_Clear_BtnClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定清除图片吗?", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                ClearImage();
            }
        }
        private void ClearImage()
        {
            this.pcb_PartImage.Image = null;
            this.pcb_PartImage1.Image = null;
            this.pcb_PartImage2.Image = null;
            this.pcb_PartImage3.Image = null;
            this.pcb_PartImage4.Image = null;
        }
        private List<Byte[]> GetBytes()
        {
            List<Byte[]> listImages = new List<Byte[]>();
            if (null != this.pcb_PartImage.Image)
            {
                listImages.Add(this.pcb_PartImage.Image.ImageToByteArray());
            }
            if (null != this.pcb_PartImage1.Image)
            {
                listImages.Add(this.pcb_PartImage1.Image.ImageToByteArray());
            }
            if (null != this.pcb_PartImage2.Image)
            {
                listImages.Add(this.pcb_PartImage2.Image.ImageToByteArray());
            }
            if (null != this.pcb_PartImage3.Image)
            {
                listImages.Add(this.pcb_PartImage3.Image.ImageToByteArray());
            }
            if (null != this.pcb_PartImage4.Image)
            {
                listImages.Add(this.pcb_PartImage4.Image.ImageToByteArray());
            }
            if (listImages.Count == 0) return null;
            return listImages;
        }
        private List<Bitmap> GetImages(List<Byte[]> listBytes)
        {
            List<Bitmap> images = new List<Bitmap>();
            try
            {
                if (listBytes == null || listBytes.Count == 0) return null;
                foreach (var item in listBytes)
                {
                    images.Add((Bitmap)item.byteArrayToImage());
                }
            }
            catch (Exception ex)
            {
                GlobalSet.m_Logger.Error("转换图片失败", ex);
            }
            return images;

        }
        private void btn_Translate_BtnClick(object sender, EventArgs e)
        {
            try
            {
                Image image = pcb_PartImage.Image;
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pcb_PartImage.Image = image;
            }
            catch
            {
            }
        }

        private void pcb_PartImage1_Click(object sender, EventArgs e)
        {
            var pic = sender as PictureBox;
            if (pic.Image != null)
            {
                Image bitmap = (Image)pic.Image.Clone();
                pic.Image = this.pcb_PartImage.Image;
                this.pcb_PartImage.Image = bitmap;
            }
        }
    }
}

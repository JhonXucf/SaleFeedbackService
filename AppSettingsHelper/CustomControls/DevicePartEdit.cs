using SalesFeedBackInfrasturcture.Entities;
using SalesFeedBackInfrasturcture.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using static AppSettingsHelper.CustomControls.DeviceEdit;

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
        DevicePart _devicePart;
        public DevicePart _DevicePart
        {
            get { return _devicePart; }
            set
            {
                _devicePart = value;
                if (null != value)
                {
                    SetDevicePart(value);
                }
            }
        }
        void SetDevicePart(DevicePart devicePart)
        {
            this.tbx_deviceId.Text = devicePart.ID;
            this.tbx_deviceName.Text = devicePart.PartName;
            this.tbx_PartId.Text = devicePart.PartId;
            this.tbx_ModelNumber.Text = devicePart.ModelNumber;
            this.tbx_Consumption.Text = devicePart.Consumption.ToString();
            this.tbx_Count.Text = devicePart.Count.ToString();
            this.tbx_PartDescription.Text = devicePart.PartDescription;
            this.cbx_Unit.Text = devicePart.Unit.GetEnumDescription<UnitStyle>();
            foreach (var item in devicePart.MaintainCycles)
            {
                switch (item.Key)
                {
                    case DeviceMaintainStyle.Minute:
                        this.cbx_Minute.Text = item.Value.ToString();
                        break;
                    case DeviceMaintainStyle.Hour:
                        this.cbx_Hour.Text = item.Value.ToString();
                        break;
                    case DeviceMaintainStyle.Day:
                        this.cbx_Day.Text = item.Value.ToString();
                        break;
                    case DeviceMaintainStyle.Month:
                        this.cbx_Month.Text = item.Value.ToString();
                        break;
                    case DeviceMaintainStyle.Quarter:
                        this.cbx_Quarter.Text = item.Value.ToString();
                        break;
                    case DeviceMaintainStyle.Year:
                        this.cbx_Year.Text = item.Value.ToString();
                        break;
                    default:
                        break;
                }
            }
            if (null != devicePart.PartImages && devicePart.PartImages.Count > 0)
            {
                if (devicePart.PartImages.Count >= 1)
                {
                    this.pcb_PartImage.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.pcb_PartImage.Image = devicePart.PartImages[0].byteArrayToImage();
                }
                if (devicePart.PartImages.Count >= 2)
                {
                    this.pcb_PartImage1.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.pcb_PartImage1.Image = devicePart.PartImages[1].byteArrayToImage();
                }
                if (devicePart.PartImages.Count >= 3)
                {
                    this.pcb_PartImage2.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.pcb_PartImage2.Image = devicePart.PartImages[2].byteArrayToImage();
                }
                if (devicePart.PartImages.Count >= 4)
                {
                    this.pcb_PartImage3.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.pcb_PartImage3.Image = devicePart.PartImages[3].byteArrayToImage();
                }
                if (devicePart.PartImages.Count >= 5)
                {
                    this.pcb_PartImage4.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.pcb_PartImage4.Image = devicePart.PartImages[4].byteArrayToImage();
                }
            }
        }
        DevicePart GetDevicePart()
        {
            DevicePart devicePart = new DevicePart();
            if (string.IsNullOrWhiteSpace(this.tbx_deviceId.Text))
            {
                this.errorProvider1.SetError(this.lbl_error, "部件ID不能为空!");
                return null;
            }
            devicePart.ID = this.tbx_deviceId.Text;
            devicePart.PartName = this.tbx_deviceName.Text;
            devicePart.PartId = this.tbx_PartId.Text;
            devicePart.ModelNumber = this.tbx_ModelNumber.Text;
            devicePart.Consumption = 0;
            Int32 temp = 0;
            if (!string.IsNullOrWhiteSpace(this.tbx_deviceId.Text) && int.TryParse(this.tbx_Consumption.Text, out temp))
            {
                devicePart.Consumption = temp;
            }
            if (string.IsNullOrWhiteSpace(this.tbx_Count.Text) || !int.TryParse(this.tbx_Count.Text, out temp))
            {
                this.errorProvider1.SetError(this.lbl_error2, "部件数量最少为1");
                return null;
            }
            else
            {
                devicePart.Count = temp;
            }
            devicePart.PartDescription = this.tbx_PartDescription.Text;
            devicePart.Unit = (UnitStyle)int.Parse(this.cbx_Unit.SelectedValue.ToString());
            #region 保养周期赋值
            if (!string.IsNullOrWhiteSpace(this.cbx_Minute.Text))
            {
                if (!int.TryParse(this.cbx_Minute.Text, out temp))
                {
                    MessageBox.Show("请输入正确数量的分钟");
                }
                devicePart.MaintainCycles[DeviceMaintainStyle.Minute] = temp;
            }
            if (!string.IsNullOrWhiteSpace(this.cbx_Hour.Text))
            {
                if (!int.TryParse(this.cbx_Hour.Text, out temp))
                {
                    MessageBox.Show("请输入正确数量的小时");
                }
                devicePart.MaintainCycles[DeviceMaintainStyle.Hour] = temp;
            }
            if (!string.IsNullOrWhiteSpace(this.cbx_Day.Text))
            {
                if (!int.TryParse(this.cbx_Day.Text, out temp))
                {
                    MessageBox.Show("请输入正确数量的天");
                }
                devicePart.MaintainCycles[DeviceMaintainStyle.Day] = temp;
            }
            if (!string.IsNullOrWhiteSpace(this.cbx_Month.Text))
            {
                if (!int.TryParse(this.cbx_Month.Text, out temp))
                {
                    MessageBox.Show("请输入正确数量的月");
                }
                devicePart.MaintainCycles[DeviceMaintainStyle.Month] = temp;
            }
            if (!string.IsNullOrWhiteSpace(this.cbx_Quarter.Text))
            {
                if (!int.TryParse(this.cbx_Quarter.Text, out temp))
                {
                    MessageBox.Show("请输入正确数量的季");
                }
                devicePart.MaintainCycles[DeviceMaintainStyle.Quarter] = temp;
            }
            if (!string.IsNullOrWhiteSpace(this.cbx_Year.Text))
            {
                if (!int.TryParse(this.cbx_Year.Text, out temp))
                {
                    MessageBox.Show("请输入正确数量的年");
                }
                devicePart.MaintainCycles[DeviceMaintainStyle.Year] = temp;
            }
            #endregion
            devicePart.PartImages = new List<byte[]>();
            if (null != this.pcb_PartImage.Image)
            {
                devicePart.PartImages.Add(this.pcb_PartImage.Image.ImageToByteArray());
            }
            if (null != this.pcb_PartImage1.Image)
            {
                devicePart.PartImages.Add(this.pcb_PartImage1.Image.ImageToByteArray());
            }
            if (null != this.pcb_PartImage2.Image)
            {
                devicePart.PartImages.Add(this.pcb_PartImage2.Image.ImageToByteArray());
            }
            if (null != this.pcb_PartImage3.Image)
            {
                devicePart.PartImages.Add(this.pcb_PartImage3.Image.ImageToByteArray());
            }
            if (null != this.pcb_PartImage4.Image)
            {
                devicePart.PartImages.Add(this.pcb_PartImage4.Image.ImageToByteArray());
            }
            if (_operatorType == SalesFeedBackMain.OperatorType.Add)
                devicePart.Created = DateTime.UtcNow;
            else
                devicePart.Modified = DateTime.UtcNow;
            return devicePart;
        }
        SalesFeedBackMain.OperatorType _operatorType;
        String[] _Ids;
        public DevicePartEdit(SalesFeedBackMain.OperatorType operatorType = SalesFeedBackMain.OperatorType.Add,String[] Ids = null)
        {
            InitializeComponent();
            InitUnitStyles();
            _operatorType = operatorType;
            _Ids = Ids;
            switch (operatorType)
            {
                case SalesFeedBackMain.OperatorType.Add:

                    break;
                case SalesFeedBackMain.OperatorType.Modify:
                    this.lbl_title.Text = "部件修改";
                    this.tbx_deviceId.Enabled = false;
                    break;
                case SalesFeedBackMain.OperatorType.Delete:
                    break;
                default:
                    break;
            }
        }
        void InitUnitStyles()
        {
            var deviceOprs = typeof(UnitStyle).GetFields();
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
                this.cbx_Unit.DisplayMember = "CustomerName";
                this.cbx_Unit.ValueMember = "CustomerCode";
                this.cbx_Unit.DataSource = deviceStyles;
                this.cbx_Unit.SelectedIndex = 0;
            }
        }
        private void btn_Save_BtnClick(object sender, EventArgs e)
        {
            if (null == (this._devicePart = GetDevicePart()))
            {
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_Close_BtnClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
        String pathImg;
        private void btnAdd_BtnClick(object sender, EventArgs e)
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
                pOpenFileDialog.Multiselect = true;//允许多张图片
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
                GlobalSet.m_Logger.Error("选择图片", ex);
            }
        }

        private void btn_Clear_BtnClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定清除图片吗?", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.pcb_PartImage.Image = null;
                this.pcb_PartImage1.Image = null;
                this.pcb_PartImage2.Image = null;
                this.pcb_PartImage3.Image = null;
                this.pcb_PartImage4.Image = null;
            } 
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
            if (pic.Image!=null)
            {
                Image bitmap = (Image)pic.Image.Clone();
                pic.Image = this.pcb_PartImage.Image;
                this.pcb_PartImage.Image = bitmap;
            }
        }

        private void tbx_deviceId_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbx_deviceId.Text)) return;

            foreach (var item in _Ids)
            {
                if (item.Equals(tbx_deviceId.Text))
                {
                    this.errorProvider1.SetError(this.lbl_error, "设备部件ID已存在！");
                    return;
                }
            }
            this.errorProvider1.Clear();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using SalesFeedBackInfrasturcture.Entities;
using System.Collections;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;
using SalesFeedBackInfrasturcture.Infrastructure;
using AppCommondHelper;
using AppSettingsHelper.CustomControls;

namespace AppSettingsHelper
{
    public partial class SalesFeedBackMain : Form
    {

        public SalesFeedBackMain()
        {
            InitializeComponent();
            _clock = new Clock();
            _clock.Size = new Size(this.pnl_title.Height - 5, this.pnl_title.Height - 5);
            _clock.Location = new Point(this.pnl_title.Width - this.pnl_minimizeAndClose.Width - this._clock.Width, 5);
            this.pnl_title.Controls.Add(_clock);
            InitBorder();
        }
        #region 私有成员

        private Clock _clock = null;
        private Point _mousePoint = new Point();     //鼠标所在位置（top,left）
        System.Windows.Forms.Label[] _labels = new System.Windows.Forms.Label[4];    //上下左右边框集合
        private int _lastWidth = 0;                  //上次窗体宽度（改变窗体大小时使用）
        private int _lastHeight = 0;                   //上次窗体高度（改变窗体大小时使用）
        /// <summary>
        /// 判断是否登陆
        /// </summary>
        bool IsLogin = false;
        /// <summary>
        /// 获取本地bin路径
        /// </summary>
        string FilePath = System.AppDomain.CurrentDomain.BaseDirectory;
        #endregion

        #region 边框鼠标拖动及关闭
        /// <summary>
        /// 初始化窗体边框,（Form1设置无边框，需要自定义边框）
        /// </summary>
        void InitBorder()
        {
            _labels[0] = new System.Windows.Forms.Label();
            _labels[1] = new System.Windows.Forms.Label();
            _labels[2] = new System.Windows.Forms.Label();
            _labels[3] = new System.Windows.Forms.Label();

            _labels[0].BackColor = _labels[2].BackColor = _labels[1].BackColor = _labels[3].BackColor = Color.FromArgb(0, 0, 0); //边框颜色

            Controls.Add(_labels[0]);
            Controls.Add(_labels[1]);
            Controls.Add(_labels[2]);
            Controls.Add(_labels[3]);

            _labels[0].Cursor = _labels[2].Cursor = Cursors.SizeWE;
            _labels[1].Cursor = _labels[3].Cursor = Cursors.SizeNS;

            _labels[0].MouseDown += BorderMouseDown;
            _labels[1].MouseDown += BorderMouseDown;
            _labels[2].MouseDown += BorderMouseDown;
            _labels[3].MouseDown += BorderMouseDown;

            _labels[0].MouseMove += WMouseMove;
            _labels[2].MouseMove += EMouseMove;
            _labels[1].MouseMove += NMouseMove;
            _labels[3].MouseMove += SMouseMove;

            _labels[0].Dock = DockStyle.Left;
            _labels[2].Dock = DockStyle.Right;
            _labels[1].Dock = DockStyle.Top;
            _labels[3].Dock = DockStyle.Bottom;

            UpdateBorder();
        }

        /// <summary>
        /// 边框鼠标按压事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BorderMouseDown(object sender, MouseEventArgs e)
        {
            _lastWidth = Width;
            _lastHeight = Height;
            this._mousePoint.X = MousePosition.X;
            this._mousePoint.Y = MousePosition.Y;
        }

        /// <summary>
        /// 左边框拖动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <summary>
        /// 上边框拖动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Width != MinimumSize.Width)
                {
                    Left = MousePosition.X;
                }
                this.Width = _lastWidth - (Control.MousePosition.X - _mousePoint.X);
            }

        }

        /// <summary>
        /// 右边框边框拖动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Width = _lastWidth + (Control.MousePosition.X - _mousePoint.X);
            }

        }

        /// <summary>
        /// 上边框边框拖动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Height != MinimumSize.Height)
                {
                    Top = MousePosition.Y;
                }
                this.Height = _lastHeight - (Control.MousePosition.Y - _mousePoint.Y);
            }

        }

        /// <summary>
        /// 下边框拖动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Height = _lastHeight + (Control.MousePosition.Y - _mousePoint.Y);
            }

        }

        /// <summary>
        /// 自定义给窗体添加边框
        /// </summary>
        private void UpdateBorder()
        {
            _labels[1].Height = _labels[3].Height = 2;
            _labels[0].Width = _labels[2].Width = 2;
        }

        /// <summary>
        /// 最小化按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// 关闭按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定关闭吗?", "Closing.....", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
        /// <summary>
        /// 标题块按压事件（记住鼠标的位置）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnl_titile_MouseDown(object sender, MouseEventArgs e)
        {
            this._mousePoint.X = e.X;
            this._mousePoint.Y = e.Y;
        }

        /// <summary>
        /// 鼠标移动事件（根据鼠标按下的位置和鼠标移动后的位置 移动窗体）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnl_titile_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                this.Top = Control.MousePosition.Y - _mousePoint.Y;
                this.Left = Control.MousePosition.X - _mousePoint.X;
            }
        }
        #endregion

        #region 初始化
        //Form1加载过程
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //设置窗体的启动位置
                this.StartPosition = FormStartPosition.CenterScreen;
                //初始化设备菜单管理按钮
                InitDeviceManagerMenu();
            }
            catch (Exception ex)
            {
            }
        }
        void InitIconFont()
        {
            string[] names = IconFontAwesome.TypeDict.Select(v => v.Key).ToArray();
            //this.cmbFontAwesomeType.Items.AddRange(names);
            string[] colorNames = Enum.GetNames(typeof(KnownColor));
            //this.cmbForeColor.Items.AddRange(colorNames);
            //this.cmbBackColor.Items.AddRange(colorNames);
            //this.cmbBorderColor.Items.AddRange(colorNames);
            //this.cmbFontAwesomeType.SelectedIndex = 0;
            //if (this.cmbFontAwesomeType.SelectedIndex < 0)
            //{
            //    return;
            //}
            //FontAwesome.IconSize = (int)this.nudIconSize.Value;
            //if (this.cmbBackColor.SelectedIndex > -1)
            //{
            //    FontAwesome.BackColer = Color.FromName(this.cmbBackColor.Text);
            //}
            //if (this.cmbBorderColor.SelectedIndex > -1)
            //{
            //    FontAwesome.BorderColer = Color.FromName(this.cmbBorderColor.Text);
            //}
            //if (this.cmbForeColor.SelectedIndex > -1)
            //{
            //    FontAwesome.ForeColer = Color.FromName(this.cmbForeColor.Text);
            //}
            //FontAwesome.BorderVisible = this.cbShowBorder.Checked == true;

            //int val = FontAwesome.TypeDict[this.cmbFontAwesomeType.Text];
            //Bitmap bmp = FontAwesome.GetImage(val);//f188
            //this.panel1.BackgroundImage = bmp;
            //this.Icon = FontAwesome.GetIcon(val);//f188;
        }
        void InitDeviceManagerMenu()
        {
            this.contextMenuDevice.Items.Clear();
            var deviceOprs = typeof(DeviceMenuStyle).GetFields();
            foreach (var fieldInfo in deviceOprs)
            {
                if (!fieldInfo.FieldType.IsEnum) continue;
                var des = (DescriptionAttribute)(fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false)[0]);
                var iconImage = fieldInfo.Name.ToString().Equals("NewDevice") ? "fa-plus-circle".GetBitmap() : "fa-houzz".GetBitmap();
                var toolStripMenuItem = new ToolStripMenuItem
                {
                    Name = "toolStripMenu" + fieldInfo.Name,
                    Text = des.Description,
                    Tag = fieldInfo.Name,
                    Image = iconImage,
                };
                toolStripMenuItem.Click += ToolStripMenuItem_Click;
                this.contextMenuDevice.Items.Add(toolStripMenuItem);
            }
        }

        public enum DeviceMenuStyle
        {
            [Description("新增设备")]
            NewDevice = 0x01,
            [Description("导出设备信息到文件")]
            Export = 0x02,
        }
        enum OperatorType
        {
            Add = 1,
            Modify = 2,
            Delete = 3,
        }
        int _StartX = 10, _StartY = 10, _Offset = 10;
        private void ShowAutoItem(OperatorType operatorType, Device device = null)
        {
           var deviceEdit = new DeviceEdit();
            if (null != device) deviceEdit._Device = device;
            deviceEdit.StartPosition = FormStartPosition.CenterParent;
            deviceEdit.ShowDialog();
            if (deviceEdit.DialogResult == DialogResult.OK && operatorType == OperatorType.Add)
            {
                var deviceSingle = new DeviceSingleFrm();
                if (null != deviceEdit._Device) deviceSingle._Device = deviceEdit._Device;
                deviceSingle.ModifyEventClicked += deviceSingle_ModifyEventClicked;
                deviceSingle.DeleteEventClicked += deviceSingle_DeleteEventClicked;
                deviceSingle.Location = this.tpg_deviceManager.SetControlLocation(_StartX, _StartY, _Offset);
                this.tpg_deviceManager.Controls.Add(deviceSingle);
            }
        }
        private void deviceSingle_DeleteEventClicked(object sender, EventArgs e)
        {
            this.tpg_deviceManager.Controls.Remove((DeviceSingleFrm)sender);
            if (this.tpg_deviceManager.Controls.Count > 0)
                this.tpg_deviceManager.UpdateControlLocation(_StartX, _StartY, _Offset);
        }

        private void deviceSingle_ModifyEventClicked(object sender, EventArgs e)
        {
            var itemShow = (DeviceSingleFrm)sender;
            ShowAutoItem(OperatorType.Modify, itemShow._Device);
        }
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var toolMenu = (ToolStripMenuItem)sender;
            if (toolMenu.Name.Contains("NewDevice"))
            {
                ShowAutoItem(OperatorType.Add);
            }
            else
            {
                MessageBox.Show("导出设备信息到文件");
            }
        }
        #endregion

        ///事件：安装服务（使用线程）
        private void btnDwInstall_Click(object sender, EventArgs e)
        {
            try
            {
                //创建一个进程
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;//是否使用操作系统shell启动
                p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
                p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
                p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
                p.StartInfo.CreateNoWindow = true;//不显示程序窗口
                p.Start();//启动程序

                string strCMD = @"sc.exe create SalesFeedbackService binpath= c:\temp\SalesFeedbackService\publish start= auto";
                //向cmd窗口发送输入信息
                p.StandardInput.WriteLine(strCMD + "&exit");

                p.StandardInput.AutoFlush = true;
                strCMD = "sc.exe start SalesFeedbackService";
                //获取cmd窗口的输出信息
                string output = p.StandardOutput.ReadToEnd();
                //等待程序执行完退出进程
                p.WaitForExit();
                p.Close();


                MessageBox.Show(output);
                Console.WriteLine(output);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n跟踪;" + ex.StackTrace);
            }
            this.lbMessage.Text = "正在安装服务，请稍后...";

        }

        /// <summary>
        /// 切换选项卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        // 事件：切换选项卡
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }



        /// <summary>
        /// 方法：读取Txt文件，（日志文件）
        /// </summary>
        /// <param name="path"></param>
        public void Read()
        {
            string path = FilePath + "LOGFile.txt";
            if (this.richTextBox1.InvokeRequired)
            {
                Action Deleread = new Action(Read);
                this.Invoke(Deleread);
            }
            else
            {
                //使用指定的路径、创建模式和读 / 写权限初始化 System.IO.FileStream 类的新实例。
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);

                //用指定的字符编码为指定的流初始化 System.IO.StreamReader 类的一个新实例。
                StreamReader sr = new StreamReader(fs, Encoding.UTF8);

                string line = "";
                richTextBox1.Text = "";
                List<string> loglist = new List<string>();
                while ((line = sr.ReadLine()) != null)
                {
                    //将对象添加到List<>的结尾处
                    loglist.Add(line.ToString());
                    if (line.ToString().Contains('-'))
                    {
                        //回车加换行
                        loglist.Add("\r\n");
                    }
                }
                //当泛型loglist元素数大于300时，将元素显示在控件richTextBox1上（倒序）。
                if (loglist.Count > 300)
                {
                    for (int i = loglist.Count - 1; i >= loglist.Count - 300; i--)
                    {
                        richTextBox1.Text += loglist[i].ToString();
                    }
                }
                //当泛型loglist元素数小于等于300时，将元素显示在控件richTextBox1上（倒序）。
                else
                    for (int i = loglist.Count - 1; i >= 0; i--)
                    {
                        richTextBox1.Text += loglist[i].ToString();
                    }
                //关闭、释放资源
                fs.Close();
                fs.Dispose();
                sr.Close();
                sr.Dispose();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog openFileDialog = new FolderBrowserDialog();

                openFileDialog.Description = "请选择文件路径";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                }
            }
            catch (Exception ex)
            {
            }
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                Read();
            });
        }
        private void 清空日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = FilePath + "LOGFile.txt";
            //指定标识符  来指示   对话框中  的  返回值
            DialogResult dr = MessageBox.Show("确定清空所有日志吗?数据无法恢复！", "Warning", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                //将richTextBox页面内容清空
                richTextBox1.Text = "";

                //实例化一个  FileStream  对象（对文件进行读写操作）
                FileStream fs;

                //判断文件是否存在。其中path为  日志文件地址  ，在上面代码中已赋值。
                if (File.Exists(path))
                {
                    fs = new FileStream(path, FileMode.Truncate, FileAccess.Write);//Truncate模式打开文件可以清空。
                }
                else
                {
                    fs = new FileStream(path, FileMode.Create, FileAccess.Write);
                }
                fs.Close();
            }
        }
    }
}


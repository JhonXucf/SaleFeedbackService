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
using System.Windows.Forms;
using System.Diagnostics;
using SalesFeedBackInfrasturcture.Infrastructure;
using AppSettingsHelper.CustomControls;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Threading;
using AppCommondHelper.Logger;

namespace AppSettingsHelper
{
    public partial class SalesFeedBackMain : Form
    {
        public SalesFeedBackMain(ConcurrentDictionary<String, Device> device = null)
        {
            InitializeComponent();
            InitBorder();
            _clock = new Clock();
            _clock.Size = new Size(this.pnl_title.Height - 5, this.pnl_title.Height - 5);
            _clock.Location = new Point(this.pnl_title.Width - this.pnl_minimizeAndClose.Width - this._clock.Width, 5);
            this.pnl_title.Controls.Add(_clock);
            if (null != device)
            {
                this._Devices = device;
            }
        }
        #region 私有成员
        private Boolean IsShowed = false;
        private Clock _clock = null;
        private Point _mousePoint = new Point();     //鼠标所在位置（top,left）
        System.Windows.Forms.Label[] _labels = new System.Windows.Forms.Label[4];    //上下左右边框集合
        private Int32 _lastWidth = 0;                  //上次窗体宽度（改变窗体大小时使用）
        private Int32 _lastHeight = 0;                   //上次窗体高度（改变窗体大小时使用） 
        CancellationTokenSource _cts;
        DeviceSingleFrm _deviceSingleFrm;
        ConcurrentDictionary<String, Device> _Devices = new ConcurrentDictionary<string, Device>();
        /// <summary>
        /// 是否匹配到项目
        /// </summary>
        Boolean _IsPatterned = false;
        String _searchPattern = String.Empty;
        Int32 _LogContainerSelectedIndex = 0;
        Boolean _IsFirstLoadLog = false;
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
                InitDeviceFromJsonFile();
                InitSearchText();
                IsShowed = true;
                _cts = new CancellationTokenSource();
            }
            catch (Exception ex)
            {
            }
        }
        void InitSearchText()
        {
            this.dtp_StartTime.Value = DateTime.Today;
            this.dtp_EndTime.Value = DateTime.Today;
            this.txt_serach.SearchClick += Txt_serach_SearchClick;
            this.txt_serach.ClearClick += Txt_serach_ClearClick;
            this.txt_serach.TextChanged += Txt_serach_TextChanged;
        }
        private void Txt_serach_TextChanged(object sender, EventArgs e)
        {
            var textbox = sender as TextBoxEx;
            if (string.IsNullOrWhiteSpace(textbox.Text))
            {
                if (_IsPatterned)
                {

                }
            }
        }

        private void Txt_serach_ClearClick(object sender, EventArgs e)
        {
            if (_IsPatterned)
            {

            }
        }

        private void Txt_serach_SearchClick(object sender, EventArgs e)
        {
            var textbox = sender as UCTextBoxEx;
            var inputText = textbox.InputText;
            if (string.IsNullOrWhiteSpace(inputText))
            {
                Task.Run(() => ReadLogAsync());
                return;
            }
            Task.Run(() => ReadLogAsync(inputText));
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
        void InitDeviceFromJsonFile()
        {
            if (_Devices.Count > 0)
            {
                foreach (var device in _Devices)
                {
                    var deviceSingle = new DeviceSingleFrm();
                    deviceSingle._Device = device.Value;
                    deviceSingle.ModifyEventClicked += deviceSingle_ModifyEventClicked;
                    deviceSingle.DeleteEventClicked += deviceSingle_DeleteEventClicked;
                    this.tpg_deviceManager.Controls.Add(deviceSingle);
                }
            }
            if (this.tpg_deviceManager.Controls.Count > 0)
                this.tpg_deviceManager.UpdateControlLocation(_StartX, _StartY, _Offset);
        }
        public enum DeviceMenuStyle
        {
            [Description("新增设备")]
            NewDevice = 0x01,
            [Description("导出设备信息")]
            Export = 0x02,
        }
        public enum OperatorType
        {
            Add = 1,
            Modify = 2,
            Delete = 3,
        }
        int _StartX = 10, _StartY = 10, _Offset = 5;
        private void ShowAutoItem(OperatorType operatorType, Device device = null)
        {
            var deviceEdit = new DeviceEdit(operatorType, this._Devices.Keys.ToArray());
            if (null != device) deviceEdit._Device = device;
            deviceEdit.StartPosition = FormStartPosition.CenterParent;
            deviceEdit.ShowDialog();
            if (deviceEdit.DialogResult == DialogResult.OK && operatorType == OperatorType.Add)
            {
                var deviceSingle = new DeviceSingleFrm();
                deviceSingle._Device = deviceEdit._Device;
                deviceSingle.ModifyEventClicked += deviceSingle_ModifyEventClicked;
                deviceSingle.DeleteEventClicked += deviceSingle_DeleteEventClicked;
                this.tpg_deviceManager.Controls.Add(deviceSingle);
                if (this.tpg_deviceManager.Controls.Count > 0)
                    this.tpg_deviceManager.UpdateControlLocation(_StartX, _StartY, _Offset);
                GlobalSet.WriteDeviceToFile(deviceEdit._Device, SalesFeedBackMain.OperatorType.Add);
            }
            else if (deviceEdit.DialogResult == DialogResult.OK && operatorType == OperatorType.Modify)
            {
                _deviceSingleFrm._Device = deviceEdit._Device;
                GlobalSet.WriteDeviceToFile(deviceEdit._Device, SalesFeedBackMain.OperatorType.Modify);
            }
        }
        private void deviceSingle_DeleteEventClicked(object sender, EventArgs e)
        {
            var single = (DeviceSingleFrm)sender;
            if (MessageBox.Show("确定删除[" + single._Device.DeviceName + "]设备吗?", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                var device = new Device();
                if (this._Devices.Remove(single._Device.ID, out device))
                {
                    GlobalSet.WriteDeviceToFile(device, OperatorType.Delete);
                    this.tpg_deviceManager.Controls.Remove(single);
                    if (this.tpg_deviceManager.Controls.Count > 0)
                        this.tpg_deviceManager.UpdateControlLocation(_StartX, _StartY, _Offset);
                }
            }
        }

        private void deviceSingle_ModifyEventClicked(object sender, EventArgs e)
        {
            _deviceSingleFrm = (DeviceSingleFrm)sender;
            ShowAutoItem(OperatorType.Modify, _deviceSingleFrm._Device);
        }
        String _BrowserExportPath;
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var toolMenu = (ToolStripMenuItem)sender;
            if (toolMenu.Name.Contains("NewDevice"))
            {
                ShowAutoItem(OperatorType.Add);
            }
            else
            {
                if (this._Devices.Count == 0)
                {
                    MessageBox.Show("无设备信息");
                    return;
                }
                FolderBrowserDialog browserDialog = new FolderBrowserDialog();
                browserDialog.Description = "导出路径选择";
                browserDialog.RootFolder = Environment.SpecialFolder.MyDocuments;
                browserDialog.ShowNewFolderButton = true;
                if (browserDialog.ShowDialog() == DialogResult.OK)
                {
                    _BrowserExportPath = browserDialog.SelectedPath;
                    var files = Directory.GetFiles(GlobalSet.m_deviceJsonPath);
                    Parallel.ForEach(files, file =>
                     {
                         String filePath = _BrowserExportPath + "\\" + Path.GetFileName(file);
                         if (File.Exists(filePath))//如果存在同名文件，选择删除再拷贝
                         {
                             File.Delete(filePath);
                         }
                         File.Copy(file, _BrowserExportPath + "\\" + Path.GetFileName(file));
                     });
                    MessageBox.Show("导出完成！");
                }
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
        public sealed class ReadLogOption
        {
            public LogEventLevel logEventLevel { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public String SearchPattern { get; set; }
        }

        void ReadLogAsync(String searchPattern = null)
        {
            var readLogOption = new ReadLogOption();
            readLogOption.StartTime = this.dtp_StartTime.Value;
            readLogOption.EndTime = this.dtp_EndTime.Value;
            readLogOption.SearchPattern = searchPattern;
            switch (_LogContainerSelectedIndex)
            {
                case 0:
                    readLogOption.logEventLevel = LogEventLevel.Information;
                    break;
                case 1:
                    readLogOption.logEventLevel = LogEventLevel.Warning;
                    break;
                case 2:
                    readLogOption.logEventLevel = LogEventLevel.Error;
                    break;
                case 3:
                    readLogOption.logEventLevel = LogEventLevel.Fatal;
                    break;
                default:
                    break;
            }
            var ct = _cts.Token;
            var taskResult = ReadAsync(readLogOption, ct).ContinueWith(task =>
            {
                this.Invoke(new Action(() =>
                {
                    switch (readLogOption.logEventLevel)
                    {
                        case LogEventLevel.Verbose:
                            break;
                        case LogEventLevel.Debug:
                            break;
                        case LogEventLevel.Information:
                            this.richTextBox_information.Text = "";
                            if (task.Result == null || task.Result.Length == 0)
                            {                                
                                return;
                            }
                            foreach (var item in task.Result)
                            {
                                this.richTextBox_information.Text += item;
                            }
                            break;
                        case LogEventLevel.Warning:
                            //this.richTextBox_warning.Text = taskResult.Result.ToString();
                            break;
                        case LogEventLevel.Error:
                            //this.richTextBox_error.Text = taskResult.Result.ToString();
                            break;
                        case LogEventLevel.Fatal:
                            //this.richTextBox_Fatal.Text = taskResult.Result.ToString();
                            break;
                        default:
                            break;
                    }
                }));
            });
        }
        /// <summary>
        /// 方法：读取Txt文件，（日志文件）
        /// </summary>
        /// <param name="path"></param>
        public async Task<String[]> ReadAsync(ReadLogOption op, CancellationToken ct)
        {
            var pop = new ParallelOptions();
            pop.CancellationToken = ct;
            var path = GlobalSet.m_AppOption.LoggerPath + "logs\\";
            switch (op.logEventLevel)
            {
                case LogEventLevel.Verbose:
                    break;
                case LogEventLevel.Debug:
                    break;
                case LogEventLevel.Information:
                    path += "Info\\";
                    break;
                case LogEventLevel.Warning:
                    path += "Warning\\";
                    break;
                case LogEventLevel.Error:
                    path += "Error\\";
                    break;
                case LogEventLevel.Fatal:
                    path += "Fatal\\";
                    break;
                default:
                    break;
            }
            var files = Directory.GetFiles(path);
            var searchFiles = new List<String>();
            foreach (var file in files)
            {
                String stringFileNameWithOutExtension = Path.GetFileNameWithoutExtension(file);
                var stringDate = stringFileNameWithOutExtension.Substring(stringFileNameWithOutExtension.Length - 10, 10);
                var dateTime = Convert.ToDateTime(stringDate);
                if (dateTime.CompareTo(op.StartTime) >= 0 && dateTime.CompareTo(op.EndTime) <= 0)
                {
                    searchFiles.Add(file);
                } 
            }
            #region ParallelLoopResult
            //ParallelLoopResult loopResult = Parallel.ForEach<String, String>(
            //   files,
            //   pop,
            //   () => { return null; },
            //   (file, loopState, index, taskLocalString) =>
            //   {
            //       String stringFileNameWithOutExtension = Path.GetFileNameWithoutExtension(file);
            //       var stringDate = stringFileNameWithOutExtension.Substring(stringFileNameWithOutExtension.Length - 10, 10);
            //       var dateTime = Convert.ToDateTime(stringDate);
            //        //var year = stringDate.Substring(0, 4) + "-";
            //        //var month = stringDate.Substring(4, 2) + "-";
            //        //var day = stringDate.Substring(6, 2);
            //        //var dateTime = Convert.ToDateTime(year + month + day);
            //        if (dateTime.CompareTo(op.StartTime) >= 0 && dateTime.CompareTo(op.EndTime) <= 0)
            //       {
            //           return file;
            //       }
            //       return null;
            //   },
            //   taskLocalFinally =>
            //   {
            //       if (taskLocalFinally != null)
            //       {
            //           searchFiles.Add(taskLocalFinally);
            //       }
            //   });
            #endregion 
            if (searchFiles.Count == 0) return null;
            Task<String>[] readTasks = new Task<String>[searchFiles.Count];
            for (int i = searchFiles.Count - 1; i >= 0; i--)
            {
                readTasks[i] = ReadLineAsync(searchFiles[i]);
            }
            String[] results = await Task.WhenAll(readTasks);

            return results;
        }
        private static async Task<String> ReadLineAsync(String file)
        {
            var sb = new StringBuilder();
            FileStream fs = null;
            try
            {
                fs = File.OpenRead(file);
                using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                {
                    var line = String.Empty;
                    while ((line = await sr.ReadLineAsync()) != null)
                    {
                        sb.AppendLine(line);
                    }
                }
            }
            catch (IOException ex)
            { /*忽略拒绝访问的任何文件*/}
            finally { if (fs != null) fs.Dispose(); }
            return sb.ToString();
        }
        private void tpg_deviceManager_SizeChanged(object sender, EventArgs e)
        {
            if (IsShowed)
            {
                _clock.Location = new Point(this.pnl_title.Width - this.pnl_minimizeAndClose.Width - this._clock.Width, 5);
                if (this.tpg_deviceManager.Controls.Count > 0)
                {
                    this.tpg_deviceManager.UpdateControlLocation(_StartX, _StartY, _Offset);
                }
            }
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            _LogContainerSelectedIndex = tabControl2.SelectedIndex;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_IsFirstLoadLog)
            {
                _IsFirstLoadLog = true;
                Task.Run(() => ReadLogAsync());
            }
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                ReadLogAsync();
            });
        }
        private void 清空日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = "LOGFile.txt";
            //指定标识符  来指示   对话框中  的  返回值
            DialogResult dr = MessageBox.Show("确定清空所有日志吗?数据无法恢复！", "Warning", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                //将richTextBox页面内容清空
                richTextBox_information.Text = "";

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


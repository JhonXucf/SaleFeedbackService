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
            lbl_SearchTip.Visible = false;
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

        String _searchPattern = null;
        Int32 _LogContainerSelectedIndex = 0;
        Boolean _IsFirstLoadLog = false;
        TabPage _tabPageSelected = null;
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
            else
            {
                GlobalSet.m_Logger.Information($"This is {GlobalSet.m_AppOption.AppName} app Ended.");
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
                _tabPageSelected = tabControl_log.TabPages[0];
            }
            catch (Exception ex)
            {
                GlobalSet.m_Logger.Error("初始化", ex);
            }
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
            if (MessageBox.Show("确定删除[" + single._Device.ID + " - " + single._Device.DeviceName + "]设备吗?", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
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
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_IsFirstLoadLog)
            {
                _IsFirstLoadLog = true;
                Task.Run(() => ReadLogAsync());
            }
        }
        #region 日志操作
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
                this.lbl_SearchCount.Text = "0";
                this.tbx_currentPatternNum.Text = "0";
                _searchPattern = null;
                richTextBox_information.SelectionColor = Color.Black;
            }
        }

        private void Txt_serach_ClearClick(object sender, EventArgs e)
        {
            this.lbl_SearchCount.Text = "0";
            this.tbx_currentPatternNum.Text = "0";
            _searchPattern = null;
            richTextBox_information.SelectionColor = Color.Black;
        }

        private void Txt_serach_SearchClick(object sender, EventArgs e)
        {
            lbl_SearchTip.Visible = true;
            var textbox = sender as UCTextBoxEx;
            var inputText = textbox.InputText;
            this.lbl_SearchCount.Text = "0";
            this.tbx_currentPatternNum.Text = "0";
            if (string.IsNullOrWhiteSpace(inputText))
            {
                Task.Run(() => ReadLogAsync());
                return;
            }
            _searchPattern = inputText;
            Task.Run(() => ReadLogAsync(inputText));
        }
        public sealed class ReadLogOption
        {
            public LogEventLevel logEventLevel { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public String SearchPattern { get; set; }
        }
        public struct SearchPatternStructSingle
        {
            public Int32 CurrentIndex;
            public Int32 StartIndex;
            public Int32 SelectedLength;
        }
        Int32 _SearchLogPatternCount = 0;
        Int32 _SearchLogPatternIndex = 0;
        List<SearchPatternStructSingle> _SearchPatternStructs;
        ReadLogOption _ReadLogOption;
        /// <summary>
        /// 异步读取日志
        /// </summary>
        /// <param name="searchPattern">查询文本</param>
        void ReadLogAsync(String searchPattern = null)
        {
            _SearchLogPatternCount = 0;
            _SearchLogPatternIndex = 0;
            _ReadLogOption = new ReadLogOption();
            _ReadLogOption.StartTime = this.dtp_StartTime.Value;
            _ReadLogOption.EndTime = this.dtp_EndTime.Value;
            _ReadLogOption.SearchPattern = searchPattern;
            switch (_LogContainerSelectedIndex)
            {
                case 0:
                    _ReadLogOption.logEventLevel = LogEventLevel.Information;
                    break;
                case 1:
                    _ReadLogOption.logEventLevel = LogEventLevel.Warning;
                    break;
                case 2:
                    _ReadLogOption.logEventLevel = LogEventLevel.Error;
                    break;
                case 3:
                    _ReadLogOption.logEventLevel = LogEventLevel.Fatal;
                    break;
                default:
                    break;
            }
            var ct = _cts.Token;
            var taskResult = ReadAsync(_ReadLogOption, ct).ContinueWith(task =>
            {
                this.Invoke(new Action(() =>
                {
                    switch (_ReadLogOption.logEventLevel)
                    {
                        case LogEventLevel.Verbose:
                        case LogEventLevel.Debug:
                        case LogEventLevel.Information:
                        case LogEventLevel.Warning:
                        case LogEventLevel.Error:
                            if (task.Result == null || task.Result.Length == 0)
                            {
                                this.richTextBox_information.Text = "";
                                return;
                            }
                            var sb = new StringBuilder();
                            foreach (var item in task.Result)
                            {
                                sb.Append(item);
                            }
                            var strText = sb.ToString();
                            this.richTextBox_information.Text = strText;
                            _SearchPatternStructs = new List<SearchPatternStructSingle>();
                            if (!String.IsNullOrWhiteSpace(searchPattern) && strText.Contains(searchPattern))
                            {
                                var index = 0;
                                var currentIndex = 0;
                                while ((index = this.richTextBox_information.Find(searchPattern, index, RichTextBoxFinds.MatchCase)) > 0)
                                {
                                    currentIndex++;
                                    var searchSingle = new SearchPatternStructSingle();
                                    searchSingle.CurrentIndex = currentIndex;
                                    searchSingle.StartIndex = index;
                                    searchSingle.SelectedLength = searchPattern.Length;
                                    _SearchPatternStructs.Add(searchSingle);
                                    _SearchLogPatternCount++;
                                    index += searchPattern.Length;
                                }
                            }
                            if (_SearchLogPatternCount > 0)
                            {
                                this.lbl_SearchCount.Text = _SearchLogPatternCount.ToString();
                                UpdateRichTextBox(this._SearchLogPatternIndex);
                            }
                            break;
                        default:
                            break;
                    }
                    lbl_SearchTip.Visible = false;
                }));
            });
        }
        /// <summary>
        /// 异步读取日志
        /// </summary>
        /// <param name="op">读取日志选项</param>
        /// <param name="ct">是否取消</param>
        /// <returns></returns>
        public async Task<String[]> ReadAsync(ReadLogOption op, CancellationToken ct)
        {
            var pop = new ParallelOptions();
            pop.CancellationToken = ct;
            var path = GlobalSet.m_AppOption.LoggerPath + "logs\\";
            switch (op.logEventLevel)
            {
                case LogEventLevel.Verbose:
                    path += "Verbose\\";
                    break;
                case LogEventLevel.Debug:
                    path += "Debug\\";
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
            if (!Directory.Exists(path)) return null;
            var files = Directory.GetFiles(path);
            if (files.Length == 0) return null;
            var concurrentFiles = new Dictionary<Int32, String>();
            var fileIndex = 0;
            foreach (var item in files)
            {
                concurrentFiles[fileIndex] = item;
                fileIndex++;
            }
            var searchFiles = new ConcurrentDictionary<Int32, String>();
            Parallel.ForEach(concurrentFiles, ac =>
            {
                String stringFileNameWithOutExtension = Path.GetFileNameWithoutExtension(ac.Value);
                var stringDate = stringFileNameWithOutExtension.Substring(stringFileNameWithOutExtension.Length - 10, 10);
                var dateTime = Convert.ToDateTime(stringDate);
                if (dateTime.CompareTo(op.StartTime) >= 0 && dateTime.CompareTo(op.EndTime) <= 0)
                {
                    searchFiles.TryAdd(ac.Key, ac.Value);
                }
            });
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
            //       if (dateTime.CompareTo(op.StartTime) >= 0 && dateTime.CompareTo(op.EndTime) <= 0)
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
            //while (!loopResult.IsCompleted);
            #endregion 
            if (searchFiles.Count == 0) return null;
            Task<String>[] readTasks = new Task<String>[searchFiles.Count];
            var aimFiles = searchFiles.OrderBy(p => p.Key);
            fileIndex = 0;
            foreach (var item in aimFiles)
            {
                readTasks[fileIndex] = ReadLineAsync(item.Value);
                fileIndex++;
            }
            String[] results = await Task.WhenAll(readTasks);

            return results;
        }
        /// <summary>
        /// 读取日志
        /// </summary>
        /// <param name="file">日志路径</param>
        /// <returns></returns>
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
            catch (IOException)
            { /*忽略拒绝访问的任何文件*/}
            finally { if (fs != null) fs.Dispose(); }
            return sb.ToString();
        }
        /// <summary>
        /// 下一项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Next_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_ReadLogOption.SearchPattern))
            {
                MessageBox.Show("查询文本为空！");
                return;
            }
            this._SearchLogPatternIndex++;
            if (this._SearchLogPatternIndex >= this._SearchLogPatternCount)
            {
                this._SearchLogPatternIndex = 0;
            }
            UpdateRichTextBox(this._SearchLogPatternIndex);
        }
        /// <summary>
        /// 上一项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Last_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_ReadLogOption.SearchPattern))
            {
                MessageBox.Show("查询文本为空！");
                return;
            }
            this._SearchLogPatternIndex--;
            if (this._SearchLogPatternIndex < 0)
            {
                this._SearchLogPatternIndex = this._SearchLogPatternCount - 1;
            }
            UpdateRichTextBox(this._SearchLogPatternIndex);
        }
        /// <summary>
        /// 跳转查找
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_jumpToIndex_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_ReadLogOption.SearchPattern))
            {
                MessageBox.Show("查询文本为空！");
                return;
            }
            var index = 0;
            if (!int.TryParse(this.tbx_currentPatternNum.Text, out index))
            {
                MessageBox.Show($"请输入要跳转的从1到{ this._SearchLogPatternCount }之间的正确数字！");
                return;
            }
            if (index < 1 || index > this._SearchLogPatternCount)
            {
                MessageBox.Show($"请输入要跳转的从1到{ this._SearchLogPatternCount }之间的正确数字！");
                return;
            }
            this._SearchLogPatternIndex = --index;
            UpdateRichTextBox(this._SearchLogPatternIndex);
        }
        private void UpdateRichTextBox(Int32 index)
        {
            var searchSingle = _SearchPatternStructs[index];
            richTextBox_information.SelectionColor = Color.Black;
            richTextBox_information.SelectionStart = searchSingle.StartIndex;
            //得到字符串的长度
            richTextBox_information.SelectionLength = searchSingle.SelectedLength;
            //然后就可以改变这个字符串的颜色
            richTextBox_information.SelectionColor = Color.Blue;
            //改变字体
            //richTextBox_information.SelectionFont = new Font("黑体", 13);
            this.tbx_currentPatternNum.Text = (index + 1).ToString();
            richTextBox_information.ScrollToCaret();
        }

        private void dtp_StartTime_Leave(object sender, EventArgs e)
        {
            this.txt_serach.Focus();
        }

        private void tabControl_log_Selected(object sender, TabControlEventArgs e)
        {
            if (null != _tabPageSelected)
            {
                _tabPageSelected.Controls.Clear();
            }
            _tabPageSelected = tabControl_log.TabPages[e.TabPageIndex];
            _LogContainerSelectedIndex = e.TabPageIndex;
            if (e.TabPage == this.tabPage_Information)
            {
                this.tabPage_Information.Controls.Add(this.richTextBox_information);
                this.tabPage_Information.Controls.Add(this.panel_SearchPatternShow);
            }
            else if (e.TabPage == this.tabPage_Warning)
            {
                this.tabPage_Warning.Controls.Add(this.richTextBox_information);
                this.tabPage_Warning.Controls.Add(this.panel_SearchPatternShow);
            }
            else if (e.TabPage == this.tabPage_eroor)
            {
                this.tabPage_eroor.Controls.Add(this.richTextBox_information);
                this.tabPage_eroor.Controls.Add(this.panel_SearchPatternShow);
            }
            else if (e.TabPage == this.tabPage_Fatal)
            {
                this.tabPage_Fatal.Controls.Add(this.richTextBox_information);
                this.tabPage_Fatal.Controls.Add(this.panel_SearchPatternShow);
            }
            Task.Run(() =>
            {
                ReadLogAsync(_searchPattern);
            });
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                ReadLogAsync(_searchPattern);
            });
        }
        #endregion 
    }
}


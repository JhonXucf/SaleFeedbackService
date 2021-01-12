using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Collections;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;

namespace SalesFeedbackSetting
{
    public partial class SalesFeedBackMain : Form
    {
        public SalesFeedBackMain()
        {
            InitializeComponent();
            InitBorder();
        }


        private Point mousePoint = new Point();     //鼠标所在位置（top,left）
        System.Windows.Forms.Label[] labels = new System.Windows.Forms.Label[4];    //上下左右边框集合
        private int lastWidth = 0;                  //上次窗体宽度（改变窗体大小时使用）
        private int lastHeight = 0;                   //上次窗体高度（改变窗体大小时使用）


        /// <summary>
        /// 初始化窗体边框,（Form1设置无边框，需要自定义边框）
        /// </summary>
        void InitBorder()
        {
            labels[0] = new System.Windows.Forms.Label();
            labels[1] = new System.Windows.Forms.Label();
            labels[2] = new System.Windows.Forms.Label();
            labels[3] = new System.Windows.Forms.Label();

            labels[0].BackColor = labels[2].BackColor = labels[1].BackColor = labels[3].BackColor = Color.FromArgb(0, 0, 0); //边框颜色

            Controls.Add(labels[0]);
            Controls.Add(labels[1]);
            Controls.Add(labels[2]);
            Controls.Add(labels[3]);

            labels[0].Cursor = labels[2].Cursor = Cursors.SizeWE;
            labels[1].Cursor = labels[3].Cursor = Cursors.SizeNS;

            labels[0].MouseDown += BorderMouseDown;
            labels[1].MouseDown += BorderMouseDown;
            labels[2].MouseDown += BorderMouseDown;
            labels[3].MouseDown += BorderMouseDown;

            labels[0].MouseMove += WMouseMove;
            labels[2].MouseMove += EMouseMove;
            labels[1].MouseMove += NMouseMove;
            labels[3].MouseMove += SMouseMove;

            labels[0].Dock = DockStyle.Left;
            labels[2].Dock = DockStyle.Right;
            labels[1].Dock = DockStyle.Top;
            labels[3].Dock = DockStyle.Bottom;

            UpdateBorder();
        }

        void InitDeviceManagerMenu()
        {
            Type deviceType = typeof(DeviceOpreatorStyle);
            PropertyInfo[] props = deviceType.GetProperties();
            for (int i = 0; i < props.Length; i++)
            {
                PropertyDescriptor des = TypeDescriptor.GetProperties(deviceType)[i];
                this.contextMenuDevice.Items.Add(des.Description);
            }
            this.contextMenuDevice.Items.AddRange(new ToolStripItem[] { new ToolStripMenuItem("sd") });
        }

        /// <summary>
        /// 边框鼠标按压事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BorderMouseDown(object sender, MouseEventArgs e)
        {
            lastWidth = Width;
            lastHeight = Height;
            this.mousePoint.X = MousePosition.X;
            this.mousePoint.Y = MousePosition.Y;
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
                this.Width = lastWidth - (Control.MousePosition.X - mousePoint.X);
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
                this.Width = lastWidth + (Control.MousePosition.X - mousePoint.X);
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
                this.Height = lastHeight - (Control.MousePosition.Y - mousePoint.Y);
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
                this.Height = lastHeight + (Control.MousePosition.Y - mousePoint.Y);
            }

        }



        /// <summary>
        /// 自定义给窗体添加边框
        /// </summary>
        private void UpdateBorder()
        {
            labels[1].Height = labels[3].Height = 2;
            labels[0].Width = labels[2].Width = 2;
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
        /// 标题块按压事件（记住鼠标的位置）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnl_titile_MouseDown(object sender, MouseEventArgs e)
        {
            this.mousePoint.X = e.X;
            this.mousePoint.Y = e.Y;
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
                this.Top = Control.MousePosition.Y - mousePoint.Y;
                this.Left = Control.MousePosition.X - mousePoint.X;
            }
        }






        /// <summary>
        /// 判断是否登陆
        /// </summary>
        bool IsLogin = false;
        /// <summary>
        /// 获取本地bin路径
        /// </summary>
        static string FilePath = System.AppDomain.CurrentDomain.BaseDirectory;
        static string Dw800Path = @"SalesFeedBackMainNet\DW800Set\SalesFeedBackMainNetDw800.ini";
        static string ID900Path = @"SalesFeedBackMainNet\ID900Set\SalesFeedBackMainNetID900.ini";

        //Form1加载过程
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //设置窗体的启动位置
                this.StartPosition = FormStartPosition.CenterParent;

                ///加载加锡机配置文件信息
                LoadGridDw900Data();

                //加载 服务状态信息、按钮状态

            }
            catch (Exception ex)
            {
            }
        }



        //启动时，控件状态
        private void Btn_EnabledStopAndUninstall1()
        {
            btnDw800Stop.Enabled = btnDw900Stop.Enabled = btnDw800Uninstall.Enabled = false;
        }

        //启动后，控件状态
        private void Btn_EnabledStopAndUninstall2()
        {
            btnDw800Stop.Enabled = btnDw900Stop.Enabled = btnDw800Uninstall.Enabled = true;
        }

        //卸载时，控件状态
        private void Btn_EnabledStartAndStop()
        {
            btnDw800Start.Enabled = btnDw800Stop.Enabled = btnDw900Stop.Enabled = btnDw900Start.Enabled = false;
        }

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
        private void InstallCMD(Process p, string cmd)
        {

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
        /// 校验IP地址
        /// </summary>
        /// <param name="strIP"></param>
        /// <returns></returns>
        /// 方法：判断IP地址
        public static bool ValidateIPAddress(string strIP)
        {
            bool istrue = false;
            if (null == strIP || "" == strIP.Trim() || Convert.IsDBNull(strIP))
                return istrue;
            Regex reg = new Regex(@"^(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])$");
            //指定的正则表达式，在指定的输入字符串中，是否找到了匹配项
            istrue = reg.IsMatch(strIP);
            return istrue;
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
                //当选项卡切换到   tabPage2
                if (tabControl1.SelectedTab.Name == "tabPage2")
                {
                    //调用方法：初始化加载加锡机网络配置
                    LoadGridXml();
                }
                //当选项卡切换到   tabPage3
                else if (tabControl1.SelectedTab.Name == "tabPage3")
                {
                    //创建线程并启动
                    System.Threading.Tasks.Task.Factory.StartNew(() =>
                    {
                        //调用方法：
                        Read();
                    });
                }
                //当选项卡切换到   tabPage4
                else if (tabControl1.SelectedTab.Name == "tabPage4")
                {
                    //调用方法：加载导出Dw800项目
                    LoadExportDw800Items();
                    //调用方法：加载导出Dw900项目
                    LoadExportDw900Items();
                }
                //当选项卡切换到   tabPage9
                else if (tabControl1.SelectedTab.Name == "tabPage9")
                {

                }
            }
            catch (Exception ex)
            {
                LogClass.WriteLogFile("148行：" + ex.Message, "SetingLog.txt");
            }
        }


        //方法：加载导出Dw800项目
        private void LoadExportDw800Items(bool? isselectAll = null)
        {
            //移除所有控件
            this.groupBox_dw800.Controls.Clear();

            //属性信息，创建一个PropertyInfo[] 类型的 props 
            PropertyInfo[] props = null;

            //typeof获取数据类型。typeof(x)中的x，必须是具体的类名、类型名称等
            Type type = typeof(IDataStore.BaseProfile);

            //利用反射获取类里面的属性信息。Activator.CreateInstance（x）使用指定类型的默认构造函数来创建该类型的实例
            object obj = Activator.CreateInstance(type);

            //获取当前type的所有公共属性（包括指定类和实例成员）
            props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            //Desc desc = new Desc();

            ////不用反射 获取属性的特性
            //PropertyDescriptor pd = TypeDescriptor.GetProperties(typeof(Desc))["des"];
            //DescriptionAttribute description = pd == null ? null : pd.Attributes[typeof(DescriptionAttribute)] as DescriptionAttribute;
            //str = description == null ? "" : description.Description;

            //////用反射 获取属性的特性
            //PropertyInfo pi = typeof(Desc).GetProperty("des");
            //foreach (object obj in pi.GetCustomAttributes(false))
            //{
            //    if (obj is DescriptionAttribute)
            //        str = (obj as DescriptionAttribute).Description;
            //}

            //////不用反射 获取结构体的特性
            //AttributeCollection attributes = TypeDescriptor.GetAttributes(desc);//or typeof(Desc)
            //DescriptionAttribute da = (DescriptionAttribute)attributes[typeof(DescriptionAttribute)];
            //if (attributes.Contains(da))
            //    str = da.Description;

            //////用反射 获取结构体的特性
            //Type myType = typeof(Desc);
            //foreach (object obj in myType.GetCustomAttributes(false))
            //{
            //    if (obj is DescriptionAttribute)
            //        str = (obj as DescriptionAttribute).Description;
            //}

            string Section = "Dw800Export";
            string path = FilePath + @"SalesFeedBackMainNet\DW800Set\Dw800ExportSet.ini";
            for (int i = 0; i < props.Length; i++)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.AutoSize = true;
                string[] name = props.GetValue(i).ToString().Split(' ');
                checkBox.Name = name[1];
                ////不用反射 获取属性的特性
                PropertyDescriptor pd = TypeDescriptor.GetProperties(type)[name[1]];
                checkBox.Text = pd.Description;

                //读取INI文件的值，根据参数的值，来设置  单选框是否选中
                if (INIHelper.Read(Section, name[1], path) == "")
                {
                    checkBox.Checked = isselectAll != null ? (bool)isselectAll : false;
                }
                else
                    checkBox.Checked = isselectAll != null ? (bool)isselectAll : bool.Parse(INIHelper.Read(Section, name[1], path));
                this.groupBox_dw800.Controls.Add(checkBox);
            }
            this.groupBox_dw800.UpdateControlLocation(5, 15, 10);
            if (INIHelper.Read(Section, "Dw800SavePath", path) != "")
            {
                this.textBox_dw800SavePath.Text = INIHelper.Read(Section, "Dw800SavePath", path);
                if (INIHelper.Read(Section, "Dw800SaveTimeModel", path) == "Time")
                {
                    this.radioButton_Pin800SaveTime.Checked = true;
                    this.dateTimePicker_dw800SaveTime.Text = INIHelper.Read(Section, "Dw800SaveTime", path);
                }
                else
                {
                    this.radioButton_Per800SaveTime.Checked = true;
                    this.textBox_dw800SaveTime.Text = INIHelper.Read(Section, "Dw800SaveTime", path);
                }
            }
            else
            {
                this.textBox_dw800SavePath.Text = "C:\\VCAM\\SalesFeedBackMain\\";
                this.radioButton_Pin800SaveTime.Checked = true;
                this.dateTimePicker_dw800SaveTime.Value = DateTime.Now;
            }
        }

        private void LoadExportDw900Items(bool? isselectAll = null)
        {

            this.groupBox_dw900.Controls.Clear();
            PropertyInfo[] props = null;//属性信息
            Type type = typeof(IDataStore.Dw900BaseInfo);
            object obj = Activator.CreateInstance(type);//利用反射获取类里面的属性信息
            props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            string Section = "ID900Export";
            string path = FilePath + @"SalesFeedBackMainNet\ID900Set\ID900ExportSet.ini";
            for (int i = 0; i < props.Length; i++)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.AutoSize = true;
                checkBox.Location = new Point(5 + (i % 5) * 160, 15 + (i / 5) * 25);
                string[] name = props.GetValue(i).ToString().Split(' ');
                checkBox.Name = name[1];
                ////不用反射 获取属性的特性
                PropertyDescriptor pd = TypeDescriptor.GetProperties(type)[name[1]];
                checkBox.Text = pd.Description;
                if (INIHelper.Read(Section, name[1], path) == "")
                {
                    checkBox.Checked = isselectAll != null ? (bool)isselectAll : false;
                }
                else
                    checkBox.Checked = isselectAll != null ? (bool)isselectAll : bool.Parse(INIHelper.Read(Section, name[1], path));
                this.groupBox_dw900.Controls.Add(checkBox);
            }
            this.groupBox_dw900.UpdateControlLocation(5, 15, 10);
            if (INIHelper.Read(Section, "ID900SavePath", path) != "")
            {
                this.textBox_dw900SavePath.Text = INIHelper.Read(Section, "ID900SavePath", path);
                if (INIHelper.Read(Section, "ID900SaveTimeModel", path) == "Time")
                {
                    this.radioButton_Pin900SaveTime.Checked = true;
                    this.dateTimePicker_dw900SaveTime.Text = INIHelper.Read(Section, "ID900SaveTime", path);
                }
                else
                {
                    this.radioButton_Per900SaveTime.Checked = true;
                    this.textBox_dw900SaveTime.Text = INIHelper.Read(Section, "ID900SaveTime", path);
                }
            }
            else
            {
                this.textBox_dw900SavePath.Text = "C:\\VCAM\\SalesFeedBackMain\\";
                this.radioButton_Pin900SaveTime.Checked = true;
                this.dateTimePicker_dw900SaveTime.Value = DateTime.Now;
            }
        }


        /// <summary>
        /// 初始化加载加锡机网络配置800
        /// </summary>
        private void LoadGridData()
        {
            dataGridView_dw800Ip.Columns.Clear();//清空表
            PropertyInfo[] props = null;//属性信息
            Type type = typeof(NetConfig);//读取NetConfig的类型

            //用props接收，获取当前type的所有公共属性（包括指定类和实例成员）
            props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            for (int i = 0; i < props.Length; i++)
            {
                //实例化一个DGC
                DataGridViewTextBoxColumn DGC = new DataGridViewTextBoxColumn();

                //Split()方法，以括号内指定的字符来分割字符串，并返回到数组name中
                string[] name = props.GetValue(i).ToString().Split(' ');

                ////不用反射，获取   “type”属性  (Netconfig的类型)   的特性
                PropertyDescriptor pd = TypeDescriptor.GetProperties(type)[name[1]];

                //将  pd的说明  （type的属性（Netconfig的类型））   存入   DGC的列标题
                DGC.HeaderText = pd.Description;

                //向集合添加给定的列（DGC）
                this.dataGridView_dw800Ip.Columns.Add(DGC);//数据列
            }
            DataGridViewButtonColumn DGCModify = new DataGridViewButtonColumn();//按钮列
            DGCModify.HeaderText = "操作";
            this.dataGridView_dw800Ip.Columns.Add(DGCModify);

            DataGridViewButtonColumn DGCDel = new DataGridViewButtonColumn();//按钮列
            DGCDel.HeaderText = "操作";
            this.dataGridView_dw800Ip.Columns.Add(DGCDel);

            //读取配置文件值，通过ReadFun()方法读取配置文件值，存入list
            List<NetConfig> list = Autosolini.ReadFun();

            //如果配置文件没有值，写入默认
            if (list == null || list.Count == 0)
            {
                this.dataGridView_dw800Ip.Rows.Add();
                dataGridView_dw800Ip.Rows[0].Cells[0].Value = "192.168.1.136";
                dataGridView_dw800Ip.Rows[0].Cells[1].Value = "1234";
                dataGridView_dw800Ip.Rows[0].Cells[2].Value = "SA1";
                dataGridView_dw800Ip.Rows[0].Cells[3].Value = "True";
                dataGridView_dw800Ip.Rows[0].Cells[4].Value = "WZS";
                dataGridView_dw800Ip.Rows[0].Cells[5].Value = "PL1";
                dataGridView_dw800Ip.Rows[0].Cells[6].Value = "Printer";
                dataGridView_dw800Ip.Rows[0].Cells[7].Value = "修改";
                dataGridView_dw800Ip.Rows[0].Cells[8].Value = "删除";
                return;
            }
            //显示数据
            for (int i = 0; i < list.Count; i++)
            {
                this.dataGridView_dw800Ip.Rows.Add();
                dataGridView_dw800Ip.Rows[i].Cells[0].Value = list[i].Ip.ToString();
                dataGridView_dw800Ip.Rows[i].Cells[1].Value = list[i].Port.ToString();
                dataGridView_dw800Ip.Rows[i].Cells[2].Value = list[i].Line.ToString();
                dataGridView_dw800Ip.Rows[i].Cells[3].Value = list[i].Status.ToString();
                dataGridView_dw800Ip.Rows[i].Cells[4].Value = list[i].Site.ToString();
                dataGridView_dw800Ip.Rows[i].Cells[5].Value = list[i].Plant.ToString();
                dataGridView_dw800Ip.Rows[i].Cells[6].Value = list[i].MachineName.ToString();
                dataGridView_dw800Ip.Rows[i].Cells[7].Value = "修改";
                dataGridView_dw800Ip.Rows[i].Cells[8].Value = "删除";
            }
        }

        //初始化加载加锡机网络配置DW900
        private void LoadGridDw900Data()
        {
            dataGridView_dw900Ip.Columns.Clear();//清空表
            PropertyInfo[] props = null;//属性信息
            //将NetConfig的类型读出，存放在type中
            Type type = typeof(NetConfig);
            props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            for (int i = 0; i < props.Length; i++)
            {
                DataGridViewTextBoxColumn DGC = new DataGridViewTextBoxColumn();
                string[] name = props.GetValue(i).ToString().Split(' ');
                ////不用反射 获取属性的特性
                PropertyDescriptor pd = TypeDescriptor.GetProperties(type)[name[1]];
                DGC.HeaderText = pd.Description;
                this.dataGridView_dw900Ip.Columns.Add(DGC);//数据列

            }
            DataGridViewButtonColumn DGCModify = new DataGridViewButtonColumn();//按钮列
            DGCModify.HeaderText = "操作";
            this.dataGridView_dw900Ip.Columns.Add(DGCModify);
            DataGridViewButtonColumn DGCDel = new DataGridViewButtonColumn();//按钮列
            DGCDel.HeaderText = "操作";
            this.dataGridView_dw900Ip.Columns.Add(DGCDel);
            ///读取配置文件值
            List<NetConfig> list = Autosolini.ReadFun();
            if (list == null || list.Count == 0)//如果配置文件没有值，写入默认
            {
                this.dataGridView_dw900Ip.Rows.Add();
                dataGridView_dw900Ip.Rows[0].Cells[0].Value = "192.168.1.136";
                dataGridView_dw900Ip.Rows[0].Cells[1].Value = "502";
                dataGridView_dw900Ip.Rows[0].Cells[2].Value = "SA1";
                dataGridView_dw900Ip.Rows[0].Cells[3].Value = "True";
                dataGridView_dw900Ip.Rows[0].Cells[4].Value = "WZS";
                dataGridView_dw900Ip.Rows[0].Cells[5].Value = "PL1";
                dataGridView_dw900Ip.Rows[0].Cells[6].Value = "Printer";
                dataGridView_dw900Ip.Rows[0].Cells[7].Value = "修改";
                dataGridView_dw900Ip.Rows[0].Cells[8].Value = "删除";
                return;
            }
            for (int i = 0; i < list.Count; i++)//显示数据
            {
                this.dataGridView_dw900Ip.Rows.Add();
                dataGridView_dw900Ip.Rows[i].Cells[0].Value = list[i].Ip.ToString();
                dataGridView_dw900Ip.Rows[i].Cells[1].Value = list[i].Port.ToString();
                dataGridView_dw900Ip.Rows[i].Cells[2].Value = list[i].Line.ToString();
                dataGridView_dw900Ip.Rows[i].Cells[3].Value = list[i].Status.ToString();
                dataGridView_dw900Ip.Rows[i].Cells[4].Value = list[i].Site.ToString();
                dataGridView_dw900Ip.Rows[i].Cells[5].Value = list[i].Plant.ToString();
                dataGridView_dw900Ip.Rows[i].Cells[6].Value = list[i].MachineName.ToString();
                dataGridView_dw900Ip.Rows[i].Cells[7].Value = "修改";
                dataGridView_dw900Ip.Rows[i].Cells[8].Value = "删除";
            }
        }

        /// <summary>
        /// 初始化加载加锡机网络配置
        /// </summary>
        private void LoadGridXml()
        {
            dataGridView2.Columns.Clear();//清空表
            PropertyInfo[] props = null;//属性信息
            Type type = typeof(DbConfig);
            props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            for (int i = 0; i < props.Length; i++)
            {
                DataGridViewTextBoxColumn DGC = new DataGridViewTextBoxColumn();
                string[] name = props.GetValue(i).ToString().Split(' ');
                ////不用反射 获取属性的特性
                PropertyDescriptor pd = TypeDescriptor.GetProperties(type)[name[1]];
                DGC.HeaderText = pd.Description;
                this.dataGridView2.Columns.Add(DGC);//数据列

            }
            DataGridViewButtonColumn DGCModify = new DataGridViewButtonColumn();//按钮列
            DGCModify.HeaderText = "操作";
            this.dataGridView2.Columns.Add(DGCModify);
            DataGridViewButtonColumn DGCCon = new DataGridViewButtonColumn();//按钮列
            DataGridViewComboBoxColumn Combox = new DataGridViewComboBoxColumn();
            Combox.Items.Add("True");
            Combox.Items.Add("False");
            DGCCon.HeaderText = "操作";
            this.dataGridView2.Columns.Add(DGCCon);
            ///读取配置文件值            
            this.dataGridView2.Rows.Add();
            dbcfg = new DbConfig();
            dataGridView2.Rows[0].Cells[0].Value = dbcfg.Source;
            dataGridView2.Rows[0].Cells[1].Value = dbcfg.Port;
            dataGridView2.Rows[0].Cells[2].Value = dbcfg.Catalog;
            dataGridView2.Rows[0].Cells[3].Value = dbcfg.User;
            dataGridView2.Rows[0].Cells[4].Value = dbcfg.Password;
            dataGridView2.Rows[0].Cells[5].Value = dbcfg.Frequency;
            dataGridView2.Rows[0].Cells[6].Value = dbcfg.InterfaceAddress;
            dataGridView2.Rows[0].Cells[7].Value = dbcfg.PostDataSwitch;
            dataGridView2.Rows[0].Cells[8].Value = dbcfg.SaveDBDataSwitch;
            dataGridView2.Rows[0].Cells[9].Value = dbcfg.AutoCleanDuration;
            dataGridView2.Rows[0].Cells[10].Value = "修改";
            dataGridView2.Rows[0].Cells[11].Value = "测试连接";

        }
        /// <summary>
        /// 按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //获取点击事件行和列
                int colindex = e.ColumnIndex;
                int rowindex = e.RowIndex;
                if (colindex < 0)
                {
                    return;
                }
                if (dataGridView2.Rows[rowindex].Cells[colindex].Value == null)
                {
                    return;
                }
                else if (dataGridView2.Rows[rowindex].Cells[colindex].Value.ToString() == "保存")
                {
                    dataGridView2.ReadOnly = true;
                    dataGridView2.Rows[rowindex].Cells[10].Value = "修改";
                    for (int i = 0; i < dataGridView2.ColumnCount; i++)
                    {
                        if (dataGridView2.Rows[rowindex].Cells[i].Value == null)
                        {
                            MessageBox.Show("配置有空值，请填写完整！", "错误", MessageBoxButtons.OKCancel);
                            return;
                        }
                    }

                    dbcfg = new DbConfig();
                    dbcfg.Source = dataGridView2.Rows[rowindex].Cells[0].Value.ToString();
                    dbcfg.Port = dataGridView2.Rows[rowindex].Cells[1].Value.ToString();
                    dbcfg.Catalog = dataGridView2.Rows[rowindex].Cells[2].Value.ToString();
                    dbcfg.User = dataGridView2.Rows[rowindex].Cells[3].Value.ToString();
                    dbcfg.Password = dataGridView2.Rows[rowindex].Cells[4].Value.ToString();

                    string Frequency = dataGridView2.Rows[rowindex].Cells[5].Value.ToString();
                    try
                    {
                        if (double.Parse(Frequency) > 30)
                        {
                            MessageBox.Show("硬件采样频率最大设置30秒！", "错误", MessageBoxButtons.OK);
                            dataGridView2.Rows[rowindex].Cells[5].Value = 30;
                            dbcfg.Frequency = "30";
                        }
                        else if (double.Parse(Frequency) <= 0)
                        {
                            MessageBox.Show("硬件采样频率最小设置0.1秒！", "错误", MessageBoxButtons.OK);
                            dataGridView2.Rows[rowindex].Cells[5].Value = 30;
                            dbcfg.Frequency = "0.1";
                        }
                        else
                        {
                            dbcfg.Frequency = Frequency;
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("硬件采样频率错误，为您设置0.5秒！", "错误", MessageBoxButtons.OK);
                        dataGridView2.Rows[rowindex].Cells[5].Value = 0.5;
                        dbcfg.Frequency = "0.5";
                    }
                    dbcfg.InterfaceAddress = "";
                    Regex reg = new Regex(@"(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%$#_]*)?");

                    string input = dataGridView2.Rows[rowindex].Cells[6].Value.ToString();
                    if (!string.IsNullOrEmpty(input))
                    {
                        string[] result = input.Replace('；', ';').Split(';');
                        if (result.Length > 0)
                        {
                            for (int i = 0; i < result.Length; i++)
                            {
                                if (reg.IsMatch(result[i]))
                                {
                                    dbcfg.InterfaceAddress += result[i] + ";";
                                }
                            }
                        }
                        else
                        {
                            dbcfg.InterfaceAddress = "http://localhost:8888";
                        }
                    }
                    else
                    {
                        dbcfg.InterfaceAddress = "http://localhost:8888";
                    }
                    dataGridView2.Rows[rowindex].Cells[6].Value = dbcfg.InterfaceAddress;
                    dbcfg.PostDataSwitch = dataGridView2.Rows[rowindex].Cells[7].Value.ToString();
                    dbcfg.SaveDBDataSwitch = dataGridView2.Rows[rowindex].Cells[8].Value.ToString();
                    dbcfg.AutoCleanDuration = dataGridView2.Rows[rowindex].Cells[9].Value.ToString();
                }
                else if (dataGridView2.Rows[rowindex].Cells[colindex].Value.ToString() == "修改")
                {
                    dataGridView2.ReadOnly = false;
                    dataGridView2.Rows[rowindex].Cells[10].Value = "保存";
                }
                else if (dataGridView2.Rows[rowindex].Cells[colindex].Value.ToString() == "测试连接")
                {
                    try
                    {
                        dbcfg = new DbConfig();
                        string rootmysqlStr = "Data Source=" + dbcfg.Source + ";User Id=" + dbcfg.User + ";Database=" + dbcfg.Catalog + "; Password=" + dbcfg.Password + ";pooling=false;CharSet=utf8;port=" + dbcfg.Port + ";";
                        MySqlConnection mycon = new MySqlConnection(rootmysqlStr);
                        mycon.Open();
                        mycon.Close();
                        MessageBox.Show("数据库测试连接成功！", "消息", MessageBoxButtons.OK);
                    }
                    catch
                    {
                        //捕获到无法建立连接即服务未启动或未安装数据库
                        MessageBox.Show("数据库测试连接失败，请检查！", "消息", MessageBoxButtons.OKCancel);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("数据格式错误，请检查！", "错误", MessageBoxButtons.OKCancel);
            }
        }

        /// <summary>
        /// 方法：读取Txt文件，（日志文件）
        /// </summary>
        /// <param name="path"></param>
        string path = FilePath + "LOGFile.txt";
        public void Read()
        {

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


        /// <summary>
        /// 方法：获取当前最新一条数据
        /// </summary>
        /// <param name="connection">连接字符串</param>
        /// <param name="sqlCmd_select">数据库操作命令</param>
        /// <param name="cmdParams">命令参数</param>
        /// <returns>返回数据库中的一个表</returns>
        public static DataTable GetDataTable(MySqlConnection connection, string sqlCmd_select, params MySqlParameter[] cmdParams)
        {
            //新实例初始化 System.Data.DataTable 不带任何参数的类。
            DataTable Dt = new DataTable();
            try
            {
                //初始化的新实例MySql.Data.MySqlClient.MySqlCommand类和查询的文本。
                MySqlCommand cmd = new MySqlCommand(sqlCmd_select);
                cmd.Connection = connection;
                if (cmdParams != null && cmdParams.Length > 0)
                {
                    //将值数组添加到MySql.Data.MySqlClient.MySqlParameterCollection。
                    cmd.Parameters.AddRange(cmdParams);
                }

                //初始化的新实例MySqlDataAdapter类与指定的MySqlCommand类作为MySqlDataAdapter.SelectCommand类的财产。
                MySqlDataAdapter Da = new MySqlDataAdapter(cmd);

                try
                {
                    //添加或刷新指定范围中的行 System.Data.DataSet 以匹配中使用数据源的那些 System.Data.DataTable 名称。
                    Da.Fill(Dt);
                }
                catch (MySqlException ex)
                {
                    Dt = null;
                    //PISTrace.WriteStrLine("DataTable填充数据异常" + ex.Message);
                    LogClass.WriteLogFile("Class-AccessDBBase;Fun-GetDataTable;行号281;" + ex.Message, "SetingLog.txt");
                    // throw;
                }
            }
            catch (MySqlException ex)
            {
                Dt = null;
                //  PISTrace.WriteStrLine("DataTable填充数据异常" + ex.Message);
                LogClass.WriteLogFile("Class-AccessDBBase;Fun-GetDataTable;行号289;" + ex.Message, "SetingLog.txt");
                //  throw;
            }
            return Dt;
        }


        /// <summary>
        /// 方法：将密码列用*号表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // 把第4列显示*号，*号的个数和实际数据的长度相同
            if (e.ColumnIndex == 4)
            {
                if (e.Value != null && e.Value.ToString().Length > 0)
                {
                    e.Value = new string('*', e.Value.ToString().Length);
                }
            }
        }

        //事件：dw800 全选
        private void button_dw800selectAll_Click(object sender, EventArgs e)
        {
            LoadExportDw800Items(true);
        }

        //事件：dw800 反选
        private void button_dw800cancelAll_Click(object sender, EventArgs e)
        {
            LoadExportDw800Items(false);
        }

        //事件：dw800 保存
        private void button_dw800Save_Click(object sender, EventArgs e)
        {
            //声明泛型类型
            List<string> dw800Title = new List<string>();
            List<string> dw800Value = new List<string>();

            //遍历控件groupBox_dw800  中所有控件
            foreach (Control item in groupBox_dw800.Controls)
            {
                if (item is CheckBox)
                {
                    //强转item类型
                    CheckBox checkBox = (CheckBox)item;
                    //向  泛型类型  中  添加元素 （名称、单选框选中状态）
                    dw800Title.Add(checkBox.Name);
                    dw800Value.Add(checkBox.Checked.ToString());
                }
            }
            //向泛型类型中   添加元素 （保存地址、保存时间）
            dw800Title.Add("Dw800SavePath");
            dw800Value.Add(this.textBox_dw800SavePath.Text);
            dw800Title.Add("Dw800SaveTimeModel");//保存时间模式
            if (radioButton_Pin800SaveTime.Checked)
            {
                dw800Value.Add("Time");
                dw800Title.Add("Dw800SaveTime");
                dw800Value.Add(this.dateTimePicker_dw800SaveTime.Text);
            }
            else
            {
                dw800Value.Add("Minutes");
                dw800Title.Add("Dw800SaveTime");
                dw800Value.Add(int.Parse(this.textBox_dw800SaveTime.Text).ToString());
            }
            string section = "Dw800Export";
            string path = FilePath + @"SalesFeedBackMainNet\DW800Set\Dw800ExportSet.ini";
            for (int i = 0; i < dw800Title.Count; i++)
            {
                INIHelper.Write(section, dw800Title[i], dw800Value[i], path);
            }
            MessageBox.Show("保存成功！");
        }

        //事件：dw900 全选
        private void button_dw900selectAll_Click(object sender, EventArgs e)
        {
            LoadExportDw900Items(true);
        }

        //事件：dw900 反选
        private void button_dw900cancelAll_Click(object sender, EventArgs e)
        {
            LoadExportDw900Items(false);
        }

        //事件：dw900 保存
        private void button_dw900Save_Click(object sender, EventArgs e)
        {
            List<string> dw800Title = new List<string>();
            List<string> dw800Value = new List<string>();
            foreach (Control item in groupBox_dw900.Controls)
            {

                if (item is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)item;
                    dw800Title.Add(checkBox.Name);
                    dw800Value.Add(checkBox.Checked.ToString());
                }
            }
            dw800Title.Add("ID900SavePath");
            dw800Value.Add(this.textBox_dw900SavePath.Text);
            dw800Title.Add("ID900SaveTimeModel");//保存时间模式
            if (radioButton_Pin900SaveTime.Checked)
            {
                dw800Value.Add("Time");
                dw800Title.Add("ID900SaveTime");
                dw800Value.Add(this.dateTimePicker_dw900SaveTime.Text);
            }
            else
            {
                dw800Value.Add("Minutes");
                dw800Title.Add("ID900SaveTime");
                dw800Value.Add(int.Parse(this.textBox_dw900SaveTime.Text).ToString());
            }
            string section = "ID900Export";
            string path = FilePath + @"SalesFeedBackMainNet\ID900Set\ID900ExportSet.ini";
            for (int i = 0; i < dw800Title.Count; i++)
            {
                INIHelper.Write(section, dw800Title[i], dw800Value[i], path);
            }
            MessageBox.Show("保存成功！");
        }

        //事件：dw800 选择文件保存路径
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog openFileDialog = new FolderBrowserDialog();

                openFileDialog.Description = "请选择文件路径";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.textBox_dw800SavePath.Text = openFileDialog.SelectedPath;
                }
            }
            catch (Exception ex)
            {
            }
        }

        //事件：dw900 选择文件保存路径
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog openFileDialog = new FolderBrowserDialog();

                openFileDialog.Description = "请选择文件路径";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.textBox_dw900SavePath.Text = openFileDialog.SelectedPath;
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

        private void textBox_dw800SaveTime_TextChanged(object sender, EventArgs e)
        {
            try
            {

                TextBox t = (TextBox)sender;
                if (string.IsNullOrEmpty(t.Text))
                {
                    return;
                }
                int result = 0;
                if (!int.TryParse(t.Text, out result))
                {
                    t.Text = "";
                    MessageBox.Show("请输入整数！");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}


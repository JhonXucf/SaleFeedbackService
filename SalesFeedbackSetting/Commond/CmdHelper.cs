using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace SalesFeedBackInfrasturcture.Commond
{
    /// <summary>
    /// 执行命令
    /// </summary>
    public class CmdHelper
    {
        ///
        /// 执行cmd.exe命令
        ///
        ///命令文本
        /// 命令输出文本
        public static string ExeCommand(string commandText)
        {
            return ExeCommand(new string[] { commandText });
        }
        ///
        /// 执行多条cmd.exe命令
        ///
        ///命令文本数组
        /// 命令输出文本
        public static string ExeCommand(string[] commandTexts)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            string strOutput = null;
            try
            {
                p.Start();
                foreach (string item in commandTexts)
                {
                    p.StandardInput.WriteLine(item);
                }
                p.StandardInput.WriteLine("exit");
                strOutput = p.StandardOutput.ReadToEnd();
                //strOutput = Encoding.UTF8.GetString(Encoding.Default.GetBytes(strOutput));
                p.WaitForExit();
                p.Close();
            }
            catch (Exception e)
            {
                strOutput = e.Message;
            }
            return strOutput;
        }
        ///
        /// 启动外部Windows应用程序，隐藏程序界面
        ///
        ///应用程序路径名称
        /// true表示成功，false表示失败
        public static bool StartApp(string appName)
        {
            return StartApp(appName, ProcessWindowStyle.Hidden);
        }
        ///
        /// 启动外部应用程序
        ///
        ///应用程序路径名称
        ///进程窗口模式
        /// true表示成功，false表示失败
        public static bool StartApp(string appName, ProcessWindowStyle style)
        {
            return StartApp(appName, null, style);
        }
        ///
        /// 启动外部应用程序，隐藏程序界面
        ///
        ///应用程序路径名称
        ///启动参数
        /// true表示成功，false表示失败
        public static bool StartApp(string appName, string arguments)
        {
            return StartApp(appName, arguments, ProcessWindowStyle.Hidden);
        }
        ///
        /// 启动外部应用程序
        ///
        ///应用程序路径名称
        ///启动参数
        ///进程窗口模式
        /// true表示成功，false表示失败
        public static bool StartApp(string appName, string arguments, ProcessWindowStyle style)
        {
            bool blnRst = false;
            Process p = new Process();
            p.StartInfo.FileName = appName;//exe,bat and so on
            p.StartInfo.WindowStyle = style;
            p.StartInfo.Arguments = arguments;
            try
            {
                p.Start();
                p.WaitForExit();
                p.Close();
                blnRst = true;
            }
            catch
            {
            }
            return blnRst;
        }
        /// <summary>
        /// 检查Winddows激活有效期
        /// </summary>
        public static void CheckWindowsActiveValid()
        {
            CmdHelper.ExeCommand("slmgr.vbs -xpr");
        }
        /// <summary>
        /// 计算器
        /// </summary>
        public static void OpenCaculate()
        {
            CmdHelper.ExeCommand("calc");
        }
        /// <summary>
        /// 打开记事本
        /// </summary>
        public static void OpenNotePad()
        {
            CmdHelper.ExeCommand("notepad");
        }
        /// <summary>
        /// 打开注册表
        /// </summary>
        public static void OpenRegisterEdit()
        {
            CmdHelper.ExeCommand("regedit");
        }
        /// <summary>
        /// 打开画图
        /// </summary>
        public static void OpenMsPaint()
        {
            CmdHelper.ExeCommand("mspaint");
        }
        /// <summary>
        /// 打开屏幕键盘
        /// </summary>
        public static void OpenMsKeys()
        {
            CmdHelper.ExeCommand("osk");
        }
        /// <summary>
        /// 注销
        /// </summary>
        public static void WindowsLogOff()
        {
            CmdHelper.ExeCommand("logoff");
        }
        /// <summary>
        /// 多少秒后关机
        /// </summary>
        public static void WindowsShutdown(int second = 0)
        {
            CmdHelper.ExeCommand($"shutdown -s -t {second}");
        }
        /// <summary>
        /// 多少秒后重启
        /// </summary>
        public static void WindowsRestart(int second = 0)
        {
            CmdHelper.ExeCommand($"shutdown -r -t {second}");
        }
        /// <summary>
        /// 取消关机/重启指令
        /// </summary>
        public static void WindowsShutdownRestartCancel(int second = 0)
        {
            CmdHelper.ExeCommand("shutdown -a");
        }
    }
}
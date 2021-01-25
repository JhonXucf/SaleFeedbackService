using AppCommondHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppSettingsHelper
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Process ps = RunningInstance();
            if (ps != null)
            {
                //防止重复打开
                return;
            }
            //处理未捕获的异常
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //处理UI线程异常
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            //处理非UI线程异常
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            GlobalSet.m_Logger = new AppCommondHelper.Logger.CustomLogger();
            GlobalSet.m_Logger.Information($"This is {GlobalSet.m_AppOption.AppName} app Started.");
            var pageLoad = new LoadPage();
            if (pageLoad.ShowDialog() == DialogResult.OK)
            {
                var devices = pageLoad._Devices;
                Application.Run(new SalesFeedBackMain(devices));
            }
        }
        ///// <summary>
        /// 获取UI线程异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Exception error = e.Exception;
            GlobalSet.m_Logger.Error("Application_ThreadException第二类异常/r/n", error);
        }
        /// <summary>
        /// 获取非UI线程异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception error = (Exception)e.ExceptionObject;
            GlobalSet.m_Logger.Fatal("CurrentDomain_UnhandledException第一类异常/r/n", error);
        }
        /// <summary>
        /// 获取当前应用程序是否在执行中
        /// </summary>
        /// <returns></returns>
        public static Process RunningInstance()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            foreach (Process process in processes)
            {
                if (process.Id != current.Id)
                {
                    if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName)
                    {
                        return process;
                    }
                }
            }
            return null;
        }
    }
}

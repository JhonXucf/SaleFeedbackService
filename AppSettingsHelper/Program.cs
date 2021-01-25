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
                //��ֹ�ظ���
                return;
            }
            //����δ������쳣
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //����UI�߳��쳣
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            //�����UI�߳��쳣
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
        /// ��ȡUI�߳��쳣
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Exception error = e.Exception;
            GlobalSet.m_Logger.Error("Application_ThreadException�ڶ����쳣/r/n", error);
        }
        /// <summary>
        /// ��ȡ��UI�߳��쳣
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception error = (Exception)e.ExceptionObject;
            GlobalSet.m_Logger.Fatal("CurrentDomain_UnhandledException��һ���쳣/r/n", error);
        }
        /// <summary>
        /// ��ȡ��ǰӦ�ó����Ƿ���ִ����
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

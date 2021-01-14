using AppCommondHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppSettingsHelper
{
    static class Program
    {
        #region 全局静态成员

        #endregion
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //var logPath = SerilogLogger.GetLogPath();
            //SerilogLogger.InitSerilog(logPath);
            //SerilogLogger.Logger.Information("This is AppSetting app");
            Application.Run(new SalesFeedBackMain());
        }
    }
}

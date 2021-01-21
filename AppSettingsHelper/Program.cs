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
            var pageLoad = new LoadPage();
            if (pageLoad.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new SalesFeedBackMain(pageLoad._Devices));
            }
        }
    }
}

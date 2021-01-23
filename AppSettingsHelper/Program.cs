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
            SerilogLogger.InitSerilog(GlobalSet.m_AppOption.LoggerPath);
            SerilogLogger.Logger.Information($"This is {GlobalSet.m_AppOption.AppName} app Started.");
            var pageLoad = new LoadPage();
            if (pageLoad.ShowDialog() == DialogResult.OK)
            {
                var devices = pageLoad._Devices;
                Application.Run(new SalesFeedBackMain(devices));
            }
        }
    }
}

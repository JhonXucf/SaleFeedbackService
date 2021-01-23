using SalesFeedBackInfrasturcture.Entities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppSettingsHelper
{
    public partial class LoadPage : Form
    {
        System.Threading.Timer timer;
        public ConcurrentDictionary<String, Device> _Devices;
        public LoadPage()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += LoadPage_Load;
            Task.Run(() =>
            {
                var files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "DevicesInfo\\");
                if (files.Length == 0) return;
                _Devices = new ConcurrentDictionary<string, Device>();
                Parallel.ForEach(files, ac =>
                {
                    var device = AppCommondHelper.JsonSerilize.JsonHelper.ReadTFromJsonFile<Device>(ac);
                    _Devices[device.ID] = device;
                });
            });
        }

        private void LoadPage_Load(object sender, EventArgs e)
        {
            timer = new System.Threading.Timer(Processer, null, Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);
            //立即执行一次
            timer.Change(TimeSpan.Zero, Timeout.InfiniteTimeSpan);
        }

        private void Processer(object sender)
        {
            var nextTime = DateTime.Now.AddMilliseconds(50);
            //执行完后,重新设置定时器下次执行时间.
            timer.Change(nextTime.Subtract(DateTime.Now), Timeout.InfiniteTimeSpan);
            this.Invoke(new Action(() =>
            {
                pnl_Load.Width += 10;
            }));
            if (pnl_Load.Width >= 700)
            {
                timer.Dispose();
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}

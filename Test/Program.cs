using System;
using SalesFeedBackInfrasturcture.Entities;
using AppCommondHelper.JsonSerilize;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;
using System.Collections.Concurrent;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
             
            var text = "log_info20210123";
            var stringDate = text.Substring(8);
            var year = stringDate.Substring(0, 4) + "-";
            var month = stringDate.Substring(4, 2) + "-";
            var day = stringDate.Substring(6, 2);
            var dateTime = Convert.ToDateTime(year + month + day);
            if (dateTime.CompareTo(DateTime.Now.AddDays(-1)) >= 0 && dateTime.CompareTo(DateTime.Now.AddDays(1)) <= 0)
            {

            }
            Device device = new Device();
            device["sdf"] = new DevicePart();
            device["hhh"] = new DevicePart();
            device["sdadff"] = new DevicePart();
            device["asdfsf"] = new DevicePart();
            var jsBuild = JsonHelper.WriteTToJsonBulider(device);
            Console.WriteLine(jsBuild.ToJson());
        }
        private static async Task<String[]> ReadLineAsync(StreamReader sr)
        {
            Task<String>[] readTasks = new Task<String>[4];
            String[] files = new String[4];
            for (int i = 0; i < 4; i++)
            {
                readTasks[i] = ReadLineAsync(files[0]);
            }

            String[] sums = await Task.WhenAll(readTasks);
            return sums;
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
            catch (IOException) { /*忽略拒绝访问的任何文件*/}
            finally { if (fs != null) fs.Dispose(); }
            return sb.ToString();
        }
    }
}

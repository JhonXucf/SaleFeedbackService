using System;
using SalesFeedBackInfrasturcture.Entities;
using AppCommondHelper.JsonSerilize;
namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Device device = new Device();
            device["sdf"] = new DevicePart();
            device["hhh"] = new DevicePart();
            device["sdadff"] = new DevicePart();
            device["asdfsf"] = new DevicePart();
            var jsBuild = JsonHelper.WriteTToJsonBulider(device);
            Console.WriteLine(jsBuild.ToJson());
        }
    }
}

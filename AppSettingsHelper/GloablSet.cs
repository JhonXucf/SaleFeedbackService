using AppCommondHelper;
using AppCommondHelper.JsonSerilize;
using AppCommondHelper.Logger;
using SalesFeedBackInfrasturcture.Entities;
using SalesFeedBackInfrasturcture.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text; 
using System.Threading.Tasks;

namespace AppSettingsHelper
{
    public class GlobalSet
    {
        /// <summary>
        /// APP重要变量
        /// </summary>
        public static AppCommondHelper.Infrastucture.AppOption m_AppOption { get; }
        /// <summary>
        /// 静态构造
        /// </summary>
        static GlobalSet()
        {
            m_AppOption = new AppCommondHelper.Infrastucture.AppOption
            {
                AppName = "AppSettingsHelper",
                LoggerPath = AppDomain.CurrentDomain.BaseDirectory,
            };
        }
        #region 静态成员
        /// <summary>
        /// 获取本地bin路径
        /// </summary>
        public static String m_filePath = System.AppDomain.CurrentDomain.BaseDirectory;
        /// <summary>
        /// json文件写入路径
        /// </summary>
        public static String m_deviceJsonPath = m_filePath + "DevicesInfo\\";
        /// <summary>
        /// 设备文件头
        /// </summary>
        public static String m_deviceFileName = "Device_";
        public static String m_FileExtensionName = ".json";
        public static Byte[] m_TodayLog = null;
        public static CustomLogger m_Logger;
        #endregion
        #region 静态方法
        /// <summary>
        /// 将设备信息写入文件或删除文件，写入对应的log
        /// </summary>
        /// <param name="device">设备信息</param>
        /// <param name="operatorType">操作</param>
        public static void WriteDeviceToFile(Device device, SalesFeedBackMain.OperatorType operatorType)
        {
            switch (operatorType)
            {
                case SalesFeedBackMain.OperatorType.Add:
                case SalesFeedBackMain.OperatorType.Modify:
                    Task.Run(() =>
                    {
                        var js = JsonHelper.GetSerilization(device);
                        JsonHelper.WriteToFile(m_deviceJsonPath, m_deviceFileName + device.ID + m_FileExtensionName, js); 
                    });
                    var deviceCopy = device.Clone();
                    foreach (var item in deviceCopy.DeviceParts.Values)
                    {
                        item.PartImages = null;
                        foreach (var maintain in item.MaintainDetails.Values)
                        {
                            maintain.MaintainImages = null;
                        }
                        foreach (var maintain in item.RepairDetails.Values)
                        {
                            maintain.RepairImages = null;
                        }
                    }
                    var opType = operatorType == SalesFeedBackMain.OperatorType.Add ? "新增设备##" : "修改设备##";
                    m_Logger.Information(m_AppOption.AppName + "##" + opType + JsonHelper.GetSerilization(deviceCopy));
                    break;
                case SalesFeedBackMain.OperatorType.Delete:
                    var deviceCopy1 = device.Clone();
                    foreach (var item in deviceCopy1.DeviceParts.Values)
                    {
                        item.PartImages = null;
                        foreach (var maintain in item.MaintainDetails.Values)
                        {
                            maintain.MaintainImages = null;
                        }
                        foreach (var maintain in item.RepairDetails.Values)
                        {
                            maintain.RepairImages = null;
                        }
                    }
                    File.Delete(m_deviceJsonPath + m_deviceFileName + deviceCopy1.ID + m_FileExtensionName);
                    m_Logger.Warning(m_AppOption.AppName + "##删除设备##" + JsonHelper.GetSerilization(deviceCopy1));
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 将设备信息写入文件或删除文件，写入对应的log
        /// </summary>
        /// <param name="device">设备信息</param>
        /// <param name="devicePart">设备部件信息</param>
        /// <param name="operatorType">操作</param>
        public static void WriteDevicePartToFile(Device device, DevicePart devicePart, SalesFeedBackMain.OperatorType operatorType)
        {
            switch (operatorType)
            {
                case SalesFeedBackMain.OperatorType.Add:
                case SalesFeedBackMain.OperatorType.Modify:
                    Task.Run(() =>
                    {
                        var js = JsonHelper.GetSerilization(device);
                        JsonHelper.WriteToFile(m_deviceJsonPath, m_deviceFileName + device.ID + m_FileExtensionName, js); 
                    }); 
                    var deviceCopy = devicePart.Clone();
                    deviceCopy.PartImages = null;
                    var opType = operatorType == SalesFeedBackMain.OperatorType.Add ? "新增设备部件##" : "修改设备部件##";
                    m_Logger.Information(m_AppOption.AppName + "##设备ID" + device.ID + "##" + opType + JsonHelper.GetSerilization(deviceCopy));
                    break;
                case SalesFeedBackMain.OperatorType.Delete:
                    Task.Run(() =>
                    {
                        var js = JsonHelper.GetSerilization(device);
                        JsonHelper.WriteToFile(m_deviceJsonPath, m_deviceFileName + device.ID + m_FileExtensionName, js);
                        var deviceCopy = devicePart.Clone();
                        deviceCopy.PartImages = null;
                        m_Logger.Warning(m_AppOption.AppName + "##设备ID" + device.ID + "##删除设备部件##" + JsonHelper.GetSerilization(deviceCopy));
                    });
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 设备部件保养信息写入日志
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="devicePart"></param>
        /// <param name="operatorStyle"></param>
        /// <param name="operatorType"></param>
        /// <param name="deviceMaintain"></param>
        /// <param name="deviceRepair"></param>
        public static void WriteDevicePartMainTainOrRepaitToFile(Device device, DevicePart devicePart, DeviceOperatorStyle operatorStyle, SalesFeedBackMain.OperatorType operatorType)
        {
            switch (operatorType)
            {
                case SalesFeedBackMain.OperatorType.Add:
                case SalesFeedBackMain.OperatorType.Modify:
                    switch (operatorStyle)
                    {
                        case DeviceOperatorStyle.Maintain:
                            Task.Run(() =>
                            {
                                var js = JsonHelper.GetSerilization(device);
                                JsonHelper.WriteToFile(m_deviceJsonPath, m_deviceFileName + device.ID + m_FileExtensionName, js);
                            });
                            var opType = "设备部件保养##";
                            var sb = new StringBuilder();
                            foreach (var item in devicePart.MaintainDetails)
                            {
                                var main = item.Value.Clone();
                                main.MaintainImages = null;
                                sb.Append(m_AppOption.AppName + "##设备ID" + device.ID + "##部件ID" + devicePart.ID + "##" + opType + "保养ID" + item.Key + JsonHelper.GetSerilization(main));
                            }
                            if (sb.Length > 0)
                            {
                                m_Logger.Information(sb.ToString());
                            }
                            break;
                        case DeviceOperatorStyle.Repair:
                            Task.Run(() =>
                            {
                                var js = JsonHelper.GetSerilization(device);
                                JsonHelper.WriteToFile(m_deviceJsonPath, m_deviceFileName + device.ID + m_FileExtensionName, js);
                            });
                            var opType1 = "设备部件修复##";
                            var sb1 = new StringBuilder();
                            foreach (var item in devicePart.RepairDetails)
                            {
                                var main = item.Value.Clone();
                                main.RepairImages = null;
                                sb1.Append(m_AppOption.AppName + "##设备ID" + device.ID + "##部件ID" + devicePart.ID + "##" + opType1 + "修复ID" + item.Key + JsonHelper.GetSerilization(main));
                            }
                            if (sb1.Length > 0)
                            {
                                m_Logger.Information(sb1.ToString());
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                //case SalesFeedBackMain.OperatorType.Delete:
                //    switch (operatorStyle)
                //    {
                //        case DeviceOperatorStyle.Maintain:
                //            var sb = new StringBuilder();
                //            foreach (var item in deviceMaintains)
                //            {
                //                var main = item.Clone();
                //                main.MaintainImages = null;
                //                var opType = "设备部件保养删除##";
                //                sb.Append(m_AppOption.AppName + "##设备ID" + device.ID + "##部件ID" + devicePart.ID + "##" + opType + "保养ID" + main.ID + JsonHelper.GetSerilization(main));
                //            } 
                //            m_Logger.Warning(sb.ToString());
                //            break;
                //        case DeviceOperatorStyle.Repair:
                //            var sbRepair = new StringBuilder();
                //            foreach (var item in deviceRepairs)
                //            {
                //                var repair = item.Clone();
                //                repair.RepairImages = null;
                //                var opType = "设备部件修复删除##";
                //                sbRepair.Append(m_AppOption.AppName + "##设备ID" + device.ID + "##部件ID" + devicePart.ID + "##" + opType + "修复ID" + repair.ID + JsonHelper.GetSerilization(repair));
                //            } 
                //            m_Logger.Warning(sbRepair.ToString());
                //            break;
                //        default:
                //            break;
                //    }
                //    break;
                default:
                    break;
            }
        }
        #endregion 
        /// <summary>
        /// 文件句柄操作类
        /// </summary>
        public class FileHandleAPI
        {
            #region 文件访问模式
            public const int OF_READ = 0;
            public const int OF_WRITE = 1;
            public const int OF_READWRITE = 2;
            #endregion

            #region 共享模式（参考OpenFile函数的标志常数表）
            public const int OF_SHARE_COMPAT = 0x0;      //文件可由多个应用程序打开多次
            public const int OF_SHARE_EXCLUSIVE = 0x10;  //其他任何一个程序都不能再打开这个文件
            public const int OF_SHARE_DENY_WRITE = 0x20; //其他程序可以读文件，但不能写文件
            public const int OF_SHARE_DENY_READ = 0x30;  //禁止其他程序读写文件内容
            public const int OF_SHARE_DENY_NONE = 0x40;  //可打开文件，以便由其他程序读写
            #endregion

            public static readonly IntPtr HFILE_ERROR = new IntPtr(-1);


            /// <summary>
            /// 获取当前线程文件句柄
            /// </summary>
            /// <param name="lpPathName">file path</param>
            /// <param name="iReadWrite"></param>
            /// <returns></returns>
            [DllImport("kernel32.dll")]
            public static extern IntPtr _lopen(string lpPathName, int iReadWrite);

            /// <summary>
            /// 关闭当前线程的文件句柄
            /// </summary>
            /// <param name="hObject"></param>
            /// <returns></returns>
            [DllImport("kernel32.dll")]
            public static extern bool CloseHandle(IntPtr hObject);

            /// <summary>
            /// 检查当前文件的句柄是否被占用
            /// </summary>
            /// <param name="filePath">file path</param>
            /// <returns></returns>
            public static bool IsOpen(string filePath)
            {
                IntPtr vHandle = _lopen(filePath, OF_READWRITE | OF_SHARE_EXCLUSIVE);
                if (vHandle == HFILE_ERROR)
                {
                    return true;
                }
                else
                {
                    CloseHandle(vHandle);
                    return false;
                }
            }
        }
    }
}

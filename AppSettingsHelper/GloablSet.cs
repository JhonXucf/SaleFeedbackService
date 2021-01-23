using AppCommondHelper;
using AppCommondHelper.JsonSerilize;
using SalesFeedBackInfrasturcture.Entities;
using SalesFeedBackInfrasturcture.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
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
                LoggerPath = SerilogLogger.GetLogPath(),
                IsEnableJsonSerilize = true
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
                        SerilogLogger.Logger.Information(m_AppOption.AppName + "##" + opType + JsonHelper.GetSerilization(deviceCopy));
                    });
                    break;
                case SalesFeedBackMain.OperatorType.Delete:
                    Task.Run(() =>
                    {
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
                        File.Delete(m_deviceJsonPath + m_deviceFileName + deviceCopy.ID + m_FileExtensionName);
                        SerilogLogger.Logger.Warning(m_AppOption.AppName + "##删除设备##" + JsonHelper.GetSerilization(deviceCopy));
                    });
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
                        var deviceCopy = devicePart.Clone();
                        deviceCopy.PartImages = null;
                        var opType = operatorType == SalesFeedBackMain.OperatorType.Add ? "新增设备部件##" : "修改设备部件##";
                        SerilogLogger.Logger.Information(m_AppOption.AppName + "##设备ID" + device.ID + "##" + opType + JsonHelper.GetSerilization(deviceCopy));
                    });                  
                    break;
                case SalesFeedBackMain.OperatorType.Delete:
                    Task.Run(() =>
                    {
                        var js = JsonHelper.GetSerilization(device);
                        JsonHelper.WriteToFile(m_deviceJsonPath, m_deviceFileName + device.ID + m_FileExtensionName, js);
                        var deviceCopy = devicePart.Clone();
                        deviceCopy.PartImages = null;
                        SerilogLogger.Logger.Warning(m_AppOption.AppName + "##设备ID" + device.ID + "##删除设备部件##" + JsonHelper.GetSerilization(deviceCopy));
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
        public static void WriteDevicePartMainTainOrRepaitToFile(String deviceId, DevicePart devicePart, DeviceOperatorStyle operatorStyle, SalesFeedBackMain.OperatorType operatorType, DeviceMaintain deviceMaintain = null, DeviceRepair deviceRepair = null)
        {
            switch (operatorType)
            {
                case SalesFeedBackMain.OperatorType.Add:
                case SalesFeedBackMain.OperatorType.Modify:
                    switch (operatorStyle)
                    {
                        case DeviceOperatorStyle.Maintain:
                            var opType = "设备部件保养##";
                            var sb = new StringBuilder();
                            foreach (var item in devicePart.MaintainDetails)
                            {
                                var main = item.Value.Clone();
                                main.MaintainImages = null;
                                sb.Append(m_AppOption.AppName + "##设备ID" + deviceId + "##部件ID" + devicePart.ID + "##" + opType + "保养ID" + item.Key + JsonHelper.GetSerilization(main));
                            }
                            if (sb.Length > 0)
                            {
                                SerilogLogger.Logger.Information(sb.ToString());
                            }
                            break;
                        case DeviceOperatorStyle.Repair:
                            var opType1 = "设备部件修复##";
                            var sb1 = new StringBuilder();
                            foreach (var item in devicePart.RepairDetails)
                            {
                                var main = item.Value.Clone();
                                main.RepairImages = null;
                                sb1.Append(m_AppOption.AppName + "##设备ID" + deviceId + "##部件ID" + devicePart.ID + "##" + opType1 + "修复ID" + item.Key + JsonHelper.GetSerilization(main));
                            }
                            if (sb1.Length > 0)
                            {
                                SerilogLogger.Logger.Information(sb1.ToString());
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                case SalesFeedBackMain.OperatorType.Delete:
                    switch (operatorStyle)
                    {
                        case DeviceOperatorStyle.Maintain:
                            var main = deviceMaintain.Clone();
                            main.MaintainImages = null;
                            var opType = "设备部件保养删除##";
                            SerilogLogger.Logger.Warning(m_AppOption.AppName + "##设备ID" + deviceId + "##部件ID" + devicePart.ID + "##" + opType + "保养ID" + deviceMaintain.ID + JsonHelper.GetSerilization(main));
                            break;
                        case DeviceOperatorStyle.Repair:
                            var repair = deviceRepair.Clone();
                            repair.RepairImages = null;
                            var opType1 = "设备部件修复删除##";
                            SerilogLogger.Logger.Warning(m_AppOption.AppName + "##设备ID" + deviceId + "##部件ID" + devicePart.ID + "##" + opType1 + "修复ID" + deviceRepair.ID + JsonHelper.GetSerilization(repair));
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion 
    }
}

using AppCommondHelper.Logger;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaleFeedbackService
{
    public class GlobalSet
    {
        public static CustomLogger m_Logger;
        static GlobalSet()
        {
            m_Logger = new CustomLogger();
        }
        /// <summary>
        /// 获取本地bin路径
        /// </summary>
        public static String m_filePath = System.AppDomain.CurrentDomain.BaseDirectory;
        /// <summary>
        /// json文件写入路径
        /// </summary>
        public static String m_deviceJsonPath = m_filePath + "DevicesInfo\\";
    }
}

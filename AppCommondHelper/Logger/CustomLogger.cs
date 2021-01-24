using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AppCommondHelper.Logger
{
    public class CustomLogger : ILog
    {
        static String m_filePath = AppDomain.CurrentDomain.BaseDirectory;
        /// <summary>
        /// 获取本地bin路径
        /// </summary>
        static readonly String m_LogPath = m_filePath + "Logs";
        /// <summary>
        /// 信息日志信息文件写入路径
        /// </summary>
        static readonly String m_LogInfo = m_LogPath + "\\Info\\log_Info";
        /// <summary>
        /// 调试日志信息文件写入路径
        /// </summary>
        static readonly String m_LogDebug = m_LogPath + "\\Info\\log_Debug";
        /// <summary>
        /// 冗长的日志信息文件写入路径
        /// </summary>
        static readonly String m_LogVerbose = m_LogPath + "\\Info\\log_Verbose";
        /// <summary>
        /// 警告的日志信息文件写入路径
        /// </summary>
        static readonly String m_LogWarning = m_LogPath + "\\Warning\\log_Warn";
        /// <summary>
        /// 错误的日志信息文件写入路径
        /// </summary>
        static readonly String m_LogError = m_LogPath + "\\Error\\log_Error";
        /// <summary>
        /// 致命的日志信息文件写入路径
        /// </summary>
        static readonly String m_LogFatal = m_LogPath + "\\Fatal\\log_Fatal";
        static readonly String m_FileExtension = ".txt";
        public String LogRootPath
        {
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    m_filePath = value;
                }
            }
        }

        public void Debug(string msg, Exception error = null)
        {
            var date = DateTime.Now.ToString("yyyy-MM-dd");
            var filePath = m_LogDebug + date + m_FileExtension;
            WriteToFileAsync(filePath, msg, error);
        }
        public void Error(string msg, Exception error = null)
        {
            var date = DateTime.Now.ToString("yyyy-MM-dd");
            var filePath = m_LogError + date + m_FileExtension;
            WriteToFileAsync(filePath, msg, error);
        }

        public void Fatal(string msg, Exception error = null)
        {
            var date = DateTime.Now.ToString("yyyy-MM-dd");
            var filePath = m_LogFatal + date + m_FileExtension;
            WriteToFileAsync(filePath, msg, error);
        }

        public void Information(string msg, Exception error = null)
        {
            var date = DateTime.Now.ToString("yyyy-MM-dd");
            var filePath = m_LogInfo + date + m_FileExtension;
            WriteToFileAsync(filePath, msg, error);
        }

        public void Verbose(string msg, Exception error = null)
        {
            var date = DateTime.Now.ToString("yyyy-MM-dd");
            var filePath = m_LogVerbose + date + m_FileExtension;
            WriteToFileAsync(filePath, msg, error);
        }

        public void Warning(string msg, Exception error = null)
        {
            var date = DateTime.Now.ToString("yyyy-MM-dd");
            var filePath = m_LogWarning + date + m_FileExtension;
            WriteToFileAsync(filePath, msg, error);
        }
        private void WriteToFileAsync(String filePath, String msg, Exception ex = null)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            var sb = new StringBuilder();
            sb.Append(msg);
            if (null != ex)
            {
                sb.Append(ex.Message);
                sb.Append(ex.StackTrace);
            }
            using (StreamWriter sw = new StreamWriter(filePath, true, Encoding.UTF8))
            {
                sw.WriteLineAsync(sb.ToString());
            }
        }
    }
    public enum LogEventLevel
    {
        Information,
        Warning,
        Error,
        Fatal,
        Verbose,
        Debug
    }
}

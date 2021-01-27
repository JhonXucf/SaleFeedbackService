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
            var filePath = GetLogPath(LogEventLevel.Debug);
            WriteToFileAsync(filePath, msg, "Debug", error);
        }
        public void Error(string msg, Exception error = null)
        {
            var filePath = GetLogPath(LogEventLevel.Error);
            WriteToFileAsync(filePath, msg, "Error", error);
        }

        public void Fatal(string msg, Exception error = null)
        {
            var filePath = GetLogPath(LogEventLevel.Fatal);
            WriteToFileAsync(filePath, msg, "Fatal", error);
        }

        public void Information(string msg, Exception error = null)
        {
            var filePath = GetLogPath(LogEventLevel.Information);
            WriteToFileAsync(filePath, msg, "Information", error);
        }

        public void Verbose(string msg, Exception error = null)
        {
            var filePath = GetLogPath(LogEventLevel.Verbose);
            WriteToFileAsync(filePath, msg, "Verbose", error);
        }

        public void Warning(string msg, Exception error = null)
        {
            var filePath = GetLogPath(LogEventLevel.Warning);
            WriteToFileAsync(filePath, msg, "Warning", error);
        }
        private void WriteToFileAsync(String filePath, String msg, String title, Exception ex = null)
        {
            msg = DateTime.Now.ToString("yyyy-MM-dd HH:mm:dd") + " [" + title + "] " + msg;
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            }
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
            System.Threading.Tasks.Task.Delay(200);
        }
        private String GetLogPath(LogEventLevel eventLevel)
        {
            var date = DateTime.Now.ToString("yyyy-MM-dd");
            var filePath = string.Empty;
            switch (eventLevel)
            {
                case LogEventLevel.Information:
                    filePath = m_LogPath + "\\Info\\log_Info" + date + m_FileExtension;
                    break;
                case LogEventLevel.Warning:
                    filePath = m_LogPath + "\\Warning\\log_Warn" + date + m_FileExtension;
                    break;
                case LogEventLevel.Error:
                    filePath = m_LogPath + "\\Error\\log_Error" + date + m_FileExtension;
                    break;
                case LogEventLevel.Fatal:
                    filePath = m_LogPath + "\\Fatal\\log_Fatal" + date + m_FileExtension;
                    break;
                case LogEventLevel.Verbose:
                    filePath = m_LogPath + "\\Verbose\\log_Verbose" + date + m_FileExtension;
                    break;
                case LogEventLevel.Debug:
                    filePath = m_LogPath + "\\Debug\\log_Debug" + date + m_FileExtension;
                    break;
                default:
                    break;
            }
            return filePath;
        }
    }
    public enum LogEventLevel
    {
        Information,//信息
        Warning,//警告
        Error,//错误
        Fatal,//严重错误
        Verbose,//冗余
        Debug,//调试
    }
}

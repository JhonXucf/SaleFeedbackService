using System;

namespace AppCommondHelper
{
    public interface ILog
    {
        void Verbose(string msg, Exception error = null);
        /// <summary>
        /// 调试信息日志
        /// </summary>
        /// <param name="msg"></param>
        void Debug(string msg, Exception error = null);
        /// <summary>
        /// 普通信息 日志
        /// </summary>
        /// <param name="msg"></param>
        void Information(string msg, Exception error = null);
        /// <summary>
        ///警告
        /// </summary>
        /// <param name="msg"></param>
        void Warning(string msg, Exception error = null);

        /// <summary>
        /// 异常
        /// </summary>
        /// <param name="error"></param>
        /// <param name="msg"></param>
        void Error(string msg, Exception error = null); 
        /// <summary>
        /// 致命的错误
        /// </summary>
        /// <param name="msg"></param>
        void Fatal(string msg, Exception error = null);

    }
}

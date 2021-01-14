using System;
using System.Text;
using System.Text.RegularExpressions;

namespace AppCommondHelper.Infrastucture
{
    public static class HelperExtension
    {
        public static String GetUtf8Str(this Byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }
        public static Byte[] GetStrBytes(this String str)
        {
            return Encoding.UTF8.GetBytes(str);
        }
        /// <summary>
        /// 校验IP地址
        /// </summary>
        /// <param name="strIP"></param>
        /// <returns></returns>
        /// 方法：判断IP地址
        public static bool ValidateIPAddress(String strIP)
        {
            bool istrue = false;
            if (null == strIP || "" == strIP.Trim() || Convert.IsDBNull(strIP))
                return istrue;
            Regex reg = new Regex(@"^(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])$");
            //指定的正则表达式，在指定的输入字符串中，是否找到了匹配项
            istrue = reg.IsMatch(strIP);
            return istrue;
        }
    }
}

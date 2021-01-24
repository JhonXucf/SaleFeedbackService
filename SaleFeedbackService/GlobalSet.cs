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
    }
}

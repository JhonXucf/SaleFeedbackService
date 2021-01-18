// ***********************************************************************
// Assembly         : AppSettingsHelper
// Created          : 08-08-2019
//
// ***********************************************************************
// <copyright file="KeyBoardType.cs">
//     Copyright by VCAM All
// </copyright>
//
// Blog: https://www.cnblogs.com/bfyx
// GitHub：https://github.com/kwwwvagaa/NetWinformControl
// gitee：https://gitee.com/kwwwvagaa/net_winform_custom_control.git
//
// If you use this code, please keep this note.
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppSettingsHelper
{
    /// <summary>
    /// Enum KeyBoardType
    /// </summary>
    public enum KeyBoardType
    {
        /// <summary>
        /// The null
        /// </summary>
        Null = 1,
        /// <summary>
        /// The uc key border all en
        /// </summary>
        UCKeyBorderAll_EN = 2,
        /// <summary>
        /// The uc key border all number
        /// </summary>
        UCKeyBorderAll_Num = 4,
        /// <summary>
        /// The uc key border number
        /// </summary>
        UCKeyBorderNum = 8,
        /// <summary>
        /// The uc key border hand
        /// </summary>
        UCKeyBorderHand = 16
    }
}

// ***********************************************************************
// Assembly         : AppSettingsHelper
// Created          : 08-08-2019
//
// ***********************************************************************
// <copyright file="UCSplitLine_V.cs">
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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppSettingsHelper
{
    /// <summary>
    /// Class UCSplitLine_V.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class UCSplitLine_V : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UCSplitLine_V" /> class.
        /// </summary>
        public UCSplitLine_V()
        {
            InitializeComponent();
            this.TabStop = false;
        }
    }
}

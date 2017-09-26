/***************************************************************************************************
 * Project      : AUPS
 * Description  : Amphenol Universal Platform and Sequenzer, develop an universal test platform MDI
 *              : application, served for Amphenol Automatical Production Testing System.
 * =================================================================================================
 * File name    : Program.cs
 * Description  : This file implements the Main() method inside the class Amphenol.AUPS.Program, it
 *              : is the entry point of the entire AUPS application.
 * Creator      : Frederick Hsu
 * Creation date: Mon.  25 Sep., 2017
 * Copyright(C) 2017    Shanghai Amphenol Airwave Communication Electronics Co., Ltd.
 * All rights reserved.
 * 
 ***************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Amphenol.AUPS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}

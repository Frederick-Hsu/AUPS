/***************************************************************************************************
 * File name    : TestPanel.cs
 * Description  : Design and implement the MDI child window TestPanel.
 * Creator      : Frederick Hsu
 * Creation date: Mon.  25 Sep., 2017
 * Copyright(C) 2017    Shanghai Amphenol Airwave Communication Electronics Co., Ltd.
 * All rights reserved.
 * 
 ***************************************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Amphenol.AUPS
{
    public partial class TestPanel : Form
    {
        private string stationName;

        /*=========================================================================================*/

        public string StationName
        {
            get
            {
                return stationName;
            }
            set
            {
                stationName = value;
            }
        }

        /*=========================================================================================*/

        public TestPanel(MainWindow parent)
        {
            InitializeComponent();

            MdiParent = parent;         /* MUST set the MdiParent property as the MDI child window of container window. */
        }

        public TestPanel(MainWindow parent, string testStationName)
        {
            InitializeComponent();
            MdiParent = parent;
            stationName = testStationName;
        }
    }
}

/***************************************************************************************************
 * File name    : MainWindow.cs
 * Description  : Implement the main window UI, which is the container of MDI application AUPS.
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

using AUPS.Tools;

namespace Amphenol.AUPS
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Main Window Events Pool
        private void testPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
        #if false
            StationNameDialog dialog = new StationNameDialog();
            dialog.Parent = this;
            dialog.ShowDialog();
        #else
            StationNameDialog dialog = new StationNameDialog();
            dialog.Parent = this;
            dialog.Counter = GetChildWindowCount() + 1;
            dialog.ShowDialog();    
        #endif
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void sequenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SequenceEditor seq = new SequenceEditor(this);
            seq.Show();
        }

        private void vehicleAntennaTestingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool openedFlag = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.GetType().ToString() == "AUPS.Tools.GMVehicleAntennaTesting")
                {
                    openedFlag = true;
                    break;
                }
            }
            if (openedFlag == false)
            {
                GMVehicleAntennaTesting vehicleAntenna = new GMVehicleAntennaTesting(this);
                vehicleAntenna.Show();
            }
        }
        #endregion

        private int GetChildWindowCount()
        {
            int count = 0;
            foreach (Form frm in this.MdiChildren)
            {
                count++;
            }
            return count;
        }
    }
}

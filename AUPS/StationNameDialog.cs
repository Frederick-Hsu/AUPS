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
    public partial class StationNameDialog : Form
    {
        private MainWindow parent;
        private int counter;

        public MainWindow Parent
        {
            get
            {
                return parent;
            }
            set
            {
                parent = value;
            }
        }

        public int Counter
        {
            get
            {
                return counter;
            }
            set
            {
                counter = value;
            }
        }

        public StationNameDialog()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (textBoxStationName.Text.Length == 0)
                return;
            // TestPanel child = new TestPanel(parent, textBoxStationName.Text);
            TestPanel child = new TestPanel(parent, textBoxStationName.Text, counter);
            Close();
            child.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AUPS.Tools
{
    public partial class ChangeConfigurationForm : Form
    {
        private int testPointHeight;
        private int frequency;
        private int bandwidth;
        private int channel;

        public ChangeConfigurationForm()
        {
            InitializeComponent();

            InitializeConfigParameters();
        }

        private void InitializeConfigParameters()
        {
            testPointHeight = 0;
            frequency = 0;
            bandwidth = 0;
            channel = 0;
        }

        #region Configuration properties
        public int TestPointHeight
        {
            get { return testPointHeight; }
        }
        public int Frequency
        {
            get { return frequency; }
        }
        public int Bandwidth
        {
            get { return bandwidth; }
        }
        public int Channel
        {
            get { return channel; }
        }
        #endregion

        private void btnOkay_Click(object sender, EventArgs e)
        {
            if (CheckParametersSetting() == false)
            {
                return;
            }
            RetrieveParameters();
            Close();
        }

        private bool CheckParametersSetting()
        {
            if (textBoxHeight.Text == string.Empty)
            {
                MessageBox.Show("Height value was not set.", "Warning");
                return false;
            }
            if (textBoxFrequency.Text == string.Empty)
            {
                MessageBox.Show("Frequency value was not set.", "Warning");
                return false;
            }
            if (comboBoxBandwidth.Text == string.Empty)
            {
                MessageBox.Show("Bandwidth value was not selected.", "Warning");
                return false;
            }
            if (comboBoxChannel.Text == string.Empty)
            {
                MessageBox.Show("WiFi channel was not selected.", "Warning");
                return false;
            }
            return true;
        }

        private void RetrieveParameters()
        {
            try
            {
                testPointHeight = Convert.ToInt32(textBoxHeight.Text);
                frequency = Convert.ToInt32(textBoxFrequency.Text);
                bandwidth = Convert.ToInt32(comboBoxBandwidth.Text);
                channel = Convert.ToInt32(comboBoxChannel.Text);
            }
            catch (FormatException exc)
            {
                MessageBox.Show("An format exception occurs : " + exc.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

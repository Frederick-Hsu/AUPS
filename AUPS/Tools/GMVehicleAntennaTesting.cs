using System;
using System.Collections;
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
    public partial class GMVehicleAntennaTesting : Form
    {
        public GMVehicleAntennaTesting()
        {
            InitializeComponent();
        }

        public GMVehicleAntennaTesting(Amphenol.AUPS.MainWindow parent)
        {
            InitializeComponent();
            MdiParent = parent;
        }

        private void CLearDataGridViewAllRows()
        {
            dataGridViewTestResults.Rows.Clear();
            dataGridViewTestResults.DataSource = null;
        }

        #region Dynamically generate the test field UI.
        /* In the real test field, you should change the scale down ratio accordingly to have the 
         * tab page window accommodated the max radius circle. 
         */
        private static int scaleDownRatio = 2;

        private void btnNewPoint_Click(object sender, EventArgs e)
        {
            DrawCoordinateSystem();

            if (CheckTestingPointsSettings() == false)
            {
                return;
            }
            int radius, angle, height, freq, bandWidth, channel;
            RetrieveTestingPointsSettings(out radius, out angle, out height, out freq, out bandWidth, out channel);
            CheckBox newTestPoint = CreateNewCheckBoxBy(radius, angle, height, freq, bandWidth, channel);

            tabControlTesting.SuspendLayout();
            tabPageField.SuspendLayout();
            SuspendLayout();

            tabPageField.Controls.Add(newTestPoint);
            tabControlTesting.ResumeLayout(false);
            tabPageField.ResumeLayout(false);
            tabPageField.PerformLayout();

            this.ResumeLayout(false);
            this.PerformLayout();

            FlushTestingPointsSettings();
        }

        private void DrawCoordinateSystem()
        {
            Graphics graph = tabPageField.CreateGraphics();
            Pen blackPen = new Pen(Color.Black, 2);

            Point origin = getOriginPointOfCoordinateSystem(), 
                  positiveXaxis = new Point(), 
                  negativeXaxis = new Point(), 
                  positiveYaxis = new Point(), 
                  negativeYaxis = new Point();

            positiveXaxis.X = origin.X + tabPageField.Width / 2 - 8;
            positiveXaxis.Y = origin.Y;

            negativeXaxis.X = origin.X - tabPageField.Width / 2;
            negativeXaxis.Y = origin.Y;

            positiveYaxis.X = origin.X;
            positiveYaxis.Y = origin.Y - tabPageField.Height / 2;

            negativeYaxis.X = origin.X;
            negativeYaxis.Y = origin.Y + tabPageField.Height / 2;

            /* Draw the cross lines */
            graph.DrawLine(blackPen, origin, positiveXaxis);
            graph.DrawLine(blackPen, origin, negativeXaxis);
            graph.DrawLine(blackPen, origin, positiveYaxis);
            graph.DrawLine(blackPen, origin, negativeYaxis);

            /****************************************************************************/

            Point topArrowX = new Point(),
                  bottomArrowX = new Point(),
                  leftArrowY = new Point(),
                  rightArrowY = new Point();

            topArrowX.X = positiveXaxis.X - 10;
            topArrowX.Y = positiveXaxis.Y - (int)(10 * Math.Tan(Math.PI/6));

            bottomArrowX.X = positiveXaxis.X - 10;
            bottomArrowX.Y = positiveXaxis.Y + (int)(10 * Math.Tan(Math.PI/6));

            leftArrowY.Y = positiveYaxis.Y + 10;
            leftArrowY.X = positiveYaxis.X - (int)(10 * Math.Tan(Math.PI/6));

            rightArrowY.Y = positiveYaxis.Y + 10;
            rightArrowY.X = positiveYaxis.X + (int)(10 * Math.Tan(Math.PI/6));

            /* draw the 2 arrows */
            graph.DrawLine(blackPen, positiveXaxis, topArrowX);
            graph.DrawLine(blackPen, positiveXaxis, bottomArrowX);
            graph.DrawLine(blackPen, positiveYaxis, leftArrowY);
            graph.DrawLine(blackPen, positiveYaxis, rightArrowY);

            /****************************************************************************/

            PointF pointX = new PointF();
            pointX.X = bottomArrowX.X;
            pointX.Y = bottomArrowX.Y + 5;

            PointF pointY = new PointF();
            pointY.X = rightArrowY.X + 5;
            pointY.Y = rightArrowY.Y - 5;

            System.Drawing.Font font = new Font("Microsoft Sans Serif", 8);     
            graph.DrawString("X", font, Brushes.Black, pointX);
            graph.DrawString("Y", font, Brushes.Black, pointY);
        }

        private Point getOriginPointOfCoordinateSystem()
        {
            Point origin = new Point();

            Point picBoxLocation = pictureBoxCar.Location;
            Size picBoxSize = pictureBoxCar.Size;
            origin.X = picBoxLocation.X + picBoxSize.Width / 2;
            origin.Y = picBoxLocation.Y + picBoxSize.Height / 2;

            return origin;
        }

        private void DrawCircle(int radius)
        {
            radius = radius / scaleDownRatio;
            Point origin = getOriginPointOfCoordinateSystem();

            Graphics graph = tabPageField.CreateGraphics();
            Pen bluePen = new Pen(Color.Blue, 1);

            graph.DrawEllipse(bluePen, origin.X - radius, origin.Y - radius, 2 * radius, 2 * radius);
        }

        private bool RetrieveTestingPointsSettings(out int radius, out int angle, out int height, out int freq, out int bandWidth, out int channel)
        {
            try
            {
                radius = Convert.ToInt32(textBoxRadius.Text);
                angle = Convert.ToInt32(textBoxAngle.Text);
                height = Convert.ToInt32(textBoxHeight.Text);
                freq = Convert.ToInt32(textBoxFreqBand.Text);
                bandWidth = Convert.ToInt32(comboBoxBandWidth.Text);
                channel = Convert.ToInt32(textBoxChannel.Text);
            }
            catch (FormatException formatEx)
            {
                MessageBox.Show(formatEx.Message, "Error");
                radius = 0;
                angle = 0;
                height = 0;
                freq = 0;
                bandWidth = 0;
                channel = 0;
                return false;
            }
            catch (OverflowException overflowEx)
            {
                MessageBox.Show(overflowEx.Message, "Error");
                radius = 0;
                angle = 0;
                height = 0;
                freq = 0;
                bandWidth = 0;
                channel = 0;
                return false;
            }
            return true;
        }

        private void FlushTestingPointsSettings()
        {
            textBoxRadius.Text = string.Empty;
            textBoxAngle.Text = string.Empty;
            textBoxHeight.Text = string.Empty;
            textBoxFreqBand.Text = string.Empty;
            comboBoxBandWidth.Text = string.Empty;
            textBoxChannel.Text = string.Empty;
        }

        private bool CheckTestingPointsSettings()
        {
            if (textBoxRadius.Text == string.Empty)
            {
                MessageBox.Show("Radius has not yet been set.", "Warning");
                return false;
            }
            if (textBoxAngle.Text == string.Empty)
            {
                MessageBox.Show("Angle has not yet been set.", "Warning");
                return false;
            }
            if (textBoxHeight.Text == string.Empty)
            {
                MessageBox.Show("Height has not yet been set.", "Warning");
                return false;
            }
            if (textBoxFreqBand.Text == string.Empty)
            {
                MessageBox.Show("Frequency has not yet been set.", "Warning");
                return false;
            }
            if (comboBoxBandWidth.Text == string.Empty)
            {
                MessageBox.Show("Bandwidth has not yet been selected.", "Warning");
                return false;
            }
            if (textBoxChannel.Text == string.Empty)
            {
                MessageBox.Show("Channel has not yet been set.", "Warning");
                return false;
            }
            if (textBoxServerIP.Text == string.Empty)
            {
                MessageBox.Show("Server IP address has not yet been set.", "Warning");
                return false;
            }
            if (textBoxIperf3Path.Text == string.Empty)
            {
                MessageBox.Show("iPerf3.exe path has not yet been browsed.", "Warning");
                return false;
            }
            return true;
        }

        private List<CheckBox> testPoints = new List<CheckBox>();
        private List<int> radiusList = new List<int>();

        private CheckBox CreateNewCheckBoxBy(int radius, int angle, int height, int freq, int bandWidth, int channel)
        {
            Point origin = getOriginPointOfCoordinateSystem();
            int x = origin.X + (int)((radius/scaleDownRatio) * Math.Cos(2 * Math.PI * angle / 360.00));
            int y = origin.Y - (int)((radius/scaleDownRatio) * Math.Sin(2 * Math.PI * angle / 360.00));
            DrawCircle(radius);
            radiusList.Add(radius);

            string info = "Radius = " + radius + "\n" +
                          "Angle = " + angle + "\n" +
                          "Height = " + height + "\n" +
                          "Frequency = " + freq + "\n" +
                          "Bandwidth = " + bandWidth + "\n" +
                          "Channel = " + channel;

            CheckBox newCheckBox = new CheckBox();
            // tabPageField.Controls.Add(newCheckBox);

            newCheckBox.AutoSize = true;
            newCheckBox.Location = new Point(x, y);
            newCheckBox.Size = new Size(113, 24);       /* Use default size */
            newCheckBox.TabIndex = testPoints.Count + 1;
            newCheckBox.Text = "Point #" + (testPoints.Count + 1);
            toolTipToDisplayInfo.SetToolTip(newCheckBox, info);
            newCheckBox.UseVisualStyleBackColor = true;
            newCheckBox.CheckStateChanged += new EventHandler(newCheckBox_CheckStateChanged);

            testPoints.Add(newCheckBox);
            return newCheckBox;
        }

        private static bool doneFlag = false;
        private static System.DateTime timer;
        private void newCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            CheckBox currentTestPoint = sender as CheckBox;
            if (currentTestPoint.Checked == false)
            {
                return;
            }

            #region Trace the execution time and display progress 
            // System.Threading.Thread timerThread = new System.Threading.Thread(new System.Threading.ThreadStart(TraceTestingTime));
            System.Threading.Thread timerThread = new System.Threading.Thread(TraceTestingTime);
            timerThread.IsBackground = true;
            timerThread.Start();

            doneFlag = false;
            timer = DateTime.Now;
            progressBarTesting.Maximum = 100;
            progressBarTesting.Minimum = 0;
            progressBarTesting.Value = 1;
            #endregion

            string toolTip = toolTipToDisplayInfo.GetToolTip(currentTestPoint);

            int radius, angle, height, freq, bandWidth, channel;
            ParseOutToolTip(toolTip, out radius, out angle, out height, out freq, out bandWidth, out channel);

            /* Perform the network connectivity test items */
            string tcpUplinkThroughput   = "", tcpDownlinkThroughput = "";
            string udpUplinkThroughput   = "", udpUplinkLatency   = "", udpUplinkPacketLoss   = "",
                   udpDownlinkThroughput = "", udpDownlinkLatency = "", udpDownlinkPacketLoss = "";

            InitializeIperfProcess();
            MeasureTcpUplinkPerformance(out tcpUplinkThroughput);
            CloseIperfProcess();
            progressBarTesting.Value = 20;

            InitializeIperfProcess();
            MeasureTcpDownlinkPerformance(out tcpDownlinkThroughput);
            CloseIperfProcess();
            progressBarTesting.Value = 40;

            InitializeIperfProcess();
            MeasureUdpUplinkPerformance(out udpUplinkThroughput, out udpUplinkLatency, out udpUplinkPacketLoss);
            CloseIperfProcess();
            progressBarTesting.Value = 60;

            InitializeIperfProcess();
            MeasureUdpDownlinkPerformance(out udpDownlinkThroughput, out udpDownlinkLatency, out udpDownlinkPacketLoss);
            CloseIperfProcess();
            progressBarTesting.Value = 80;

            FillTestResultsTable(currentTestPoint.Text, 
                                 radius.ToString(), 
                                 angle.ToString(), 
                                 height.ToString(), 
                                 freq.ToString(), 
                                 bandWidth.ToString(), 
                                 channel.ToString(),
                                 tcpUplinkThroughput, 
                                 tcpDownlinkThroughput,
                                 udpUplinkThroughput, 
                                 udpUplinkLatency, 
                                 udpUplinkPacketLoss,
                                 udpDownlinkThroughput, 
                                 udpDownlinkLatency, 
                                 udpDownlinkPacketLoss,
                                 "", 
                                 "");
            progressBarTesting.Value = 100;
            doneFlag = true;
        }

        private void btnRefreshDrawing_Click(object sender, EventArgs e)
        {
            DrawCoordinateSystem();
            foreach (int radius in radiusList)
            {
                DrawCircle(radius);
            }

            /* Move all the check boxes accordingy. */
            Point origin = getOriginPointOfCoordinateSystem();
            foreach (CheckBox testPoint in testPoints)
            {
                string toolTip = toolTipToDisplayInfo.GetToolTip(testPoint);
                int radius, angle, height, freq, bandWidth, channel;
                ParseOutToolTip(toolTip, out radius, out angle, out height, out freq, out bandWidth, out channel);

                int x = origin.X + (int)((radius / scaleDownRatio) * Math.Cos(2 * Math.PI * angle / 360.00));
                int y = origin.Y - (int)((radius / scaleDownRatio) * Math.Sin(2 * Math.PI * angle / 360.00));
                testPoint.Location = new Point(x, y);
            }
        }

        private void ParseOutToolTip(string toolTip, out int radius, out int angle, out int height, out int freq, out int bandWidth, out int channel)
        {
            string[] fields = toolTip.Split(new char[] { '\n' });
            int count = fields.Length;
            string[] field_values = new string[count];

            for (int index = 0; index < count; index++)
            {
                field_values[index] = fields[index].Substring(fields[index].IndexOf("=") + 2);
            }
            radius = Convert.ToInt32(field_values[0]);
            angle = Convert.ToInt32(field_values[1]);
            height = Convert.ToInt32(field_values[2]);
            freq = Convert.ToInt32(field_values[3]);
            bandWidth = Convert.ToInt32(field_values[4]);
            channel = Convert.ToInt32(field_values[5]);
        }

        private void tabControlTesting_Resize(object sender, EventArgs e)
        {
            /* After resize the tabControl, acquire its location and size */
            Point tabStartPoint = tabControlTesting.Location;
            Size tabSize = tabControlTesting.Size;

            /* Re-calculate the center point of tabControl */
            int centerX = tabStartPoint.X + tabSize.Width / 2;
            int centerY = tabStartPoint.Y + tabSize.Height / 2;
            int picBoxWidth = pictureBoxCar.Size.Width;
            int picBoxHeight = pictureBoxCar.Size.Height;
            int picBoxX = centerX - picBoxWidth / 2 - groupBoxTestPointsSetting.Size.Width;
            int picBoxY = centerY - picBoxHeight / 2;

            /* Move the picture box to the center of tabPageField. */
            pictureBoxCar.Location = new System.Drawing.Point(picBoxX, picBoxY);
        }

        private void btnBrowseIperf3_Click(object sender, EventArgs e)
        {
            textBoxIperf3Path.Text = string.Empty;

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Browse the iPerf3 .exe file.";
            dlg.DefaultExt = "exe";
            dlg.Filter = "Exe file | *.exe";
            dlg.AddExtension = true;
            dlg.InitialDirectory = @"";

            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            textBoxIperf3Path.Text = dlg.FileName;
        }
#endregion

        private void FillTestResultsTable(string pointNo,
                                          string radius,
                                          string angle,
                                          string height,
                                          string frequecy,
                                          string band,
                                          string channel,
                                          string tcpUplinkThroughput,
                                          string tcpDownlinkThroughput,
                                          string udpUplinkThroughput,
                                          string udpUplinkLatency,
                                          string udpUplinkPacketLoss,
                                          string udpDownlinkThroughput,
                                          string udpDownlinkLatency,
                                          string udpDownlinkPacketLoss,
                                          string rssi,
                                          string snr)
        {
            int existedRows = dataGridViewTestResults.Rows.Add();

            dataGridViewTestResults.Rows[existedRows].Cells[0].Value = pointNo;
            dataGridViewTestResults.Rows[existedRows].Cells[1].Value = radius;
            dataGridViewTestResults.Rows[existedRows].Cells[2].Value = angle;
            dataGridViewTestResults.Rows[existedRows].Cells[3].Value = height;
            dataGridViewTestResults.Rows[existedRows].Cells[4].Value = frequecy;
            dataGridViewTestResults.Rows[existedRows].Cells[5].Value = band;
            dataGridViewTestResults.Rows[existedRows].Cells[6].Value = channel;
            dataGridViewTestResults.Rows[existedRows].Cells[7].Value = tcpUplinkThroughput;
            dataGridViewTestResults.Rows[existedRows].Cells[8].Value = tcpDownlinkThroughput;
            dataGridViewTestResults.Rows[existedRows].Cells[9].Value = udpUplinkThroughput;
            dataGridViewTestResults.Rows[existedRows].Cells[10].Value = udpUplinkLatency;
            dataGridViewTestResults.Rows[existedRows].Cells[11].Value = udpUplinkPacketLoss;
            dataGridViewTestResults.Rows[existedRows].Cells[12].Value = udpDownlinkThroughput;
            dataGridViewTestResults.Rows[existedRows].Cells[13].Value = udpDownlinkLatency;
            dataGridViewTestResults.Rows[existedRows].Cells[14].Value = udpDownlinkPacketLoss;
            dataGridViewTestResults.Rows[existedRows].Cells[15].Value = rssi;
            dataGridViewTestResults.Rows[existedRows].Cells[16].Value = snr;
            dataGridViewTestResults.Rows[existedRows].Cells[17].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private delegate void TraceTestingTimeDelegate();

        private void DisplayElapsedTestTime()
        {
            TraceTestingTime();
        }

        private void TraceTestingTime()
        {
            if (labelElapsedTime.InvokeRequired)
            {
                TraceTestingTimeDelegate delg = new TraceTestingTimeDelegate(TraceTestingTime);
                this.Invoke(delg);
            }
            else
            {
                while (doneFlag == false)
                {
                    labelElapsedTime.Text = "Elapsed time : " + DateTime.Now.Subtract(timer).ToString();
                    Application.DoEvents();
                }
                labelElapsedTime.Text = "Elapsed time : " + DateTime.Now.Subtract(timer).ToString();
            }
        }

        private void btnClearTestResults_Click(object sender, EventArgs e)
        {
            dataGridViewTestResults.Rows.Clear();
        }

        private void btnSaveTestResults_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "Save the test results into .csv file you specified";
            dlg.InitialDirectory = "";
            dlg.DefaultExt = "csv";
            dlg.Filter = "CSV file | *.csv";
            dlg.AddExtension = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                labelFilePathToSave.Text = dlg.FileName;
                SaveTestResultsToCsv(dlg.FileName);
            }
        }

        private void SaveTestResultsToCsv(string csvFileName)
        {
            int cols = dataGridViewTestResults.Columns.Count;
            int rows = dataGridViewTestResults.Rows.Count;
            int colIndex = 0, rowIndex = 0;

            System.IO.FileStream fs = new System.IO.FileStream(csvFileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
            System.IO.StreamWriter sw = new System.IO.StreamWriter(fs, System.Text.Encoding.UTF8);

            string title = "";
            for (colIndex = 0; colIndex < cols; colIndex++)
            {
                title += dataGridViewTestResults.Columns[colIndex].HeaderText;
                if (colIndex < (cols -1))   /* Caution : the last column cannot append the comma(",") */
                {
                    title += ",";
                }
            }
            sw.WriteLine(title);


            string line = "";
            for (rowIndex = 0; rowIndex < (rows -1); rowIndex++)    /* NOTICE : the last row is empty */
            {
                for (colIndex = 0; colIndex < cols; colIndex++)
                {
                    line += (dataGridViewTestResults.Rows[rowIndex].Cells[colIndex].Value as string);
                    if (colIndex < (cols-1))
                    {
                        line += ",";
                    }
                }
                sw.WriteLine(line);
            }

            sw.Close();
            fs.Close();
            MessageBox.Show("The .csv file of test results had been saved successfully.", "Save");
        }
    }
}

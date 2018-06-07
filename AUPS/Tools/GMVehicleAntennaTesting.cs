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
using System.IO;

namespace AUPS.Tools
{
    public partial class GMVehicleAntennaTesting : Form
    {
        private CustomizedResizableRectControl resizableDataGridView;

        public GMVehicleAntennaTesting()
        {
            InitializeComponent();
        }

        public GMVehicleAntennaTesting(Amphenol.AUPS.MainWindow parent)
        {
            InitializeComponent();
            MdiParent = parent;

            // InitializeBackgroundWork();
            InitializeUI();
        }

        private void InitializeUI()
        {
            resizableDataGridView = new CustomizedResizableRectControl(dataGridViewPointSettings);
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
            double power;
            RetrieveTestingPointsSettings(out radius, out angle, out height, out freq, out bandWidth, out channel, out power);
            CheckBox newTestPoint = CreateNewCheckBoxBy(radius, angle, height, freq, bandWidth, channel, power);

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

        private bool RetrieveTestingPointsSettings(out int radius, out int angle, out int height, out int freq, out int bandWidth, out int channel, out double power)
        {
            try
            {
                radius = Convert.ToInt32(textBoxRadius.Text);
                angle = Convert.ToInt32(textBoxAngle.Text);
                height = Convert.ToInt32(textBoxHeight.Text);
                freq = Convert.ToInt32(textBoxFreqBand.Text);
                bandWidth = Convert.ToInt32(comboBoxBandWidth.Text);
                channel = Convert.ToInt32(textBoxChannel.Text);
                power = Convert.ToDouble(textBoxTxPower.Text);
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
                power = 0.00;
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
                power = 0.00;
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
            textBoxTxPower.Text = string.Empty;
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
            if (textBoxTxPower.Text == string.Empty)
            {
                MessageBox.Show("Tx power has not yet been set.", "Warning");
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

        private CheckBox CreateNewCheckBoxBy(int radius, int angle, int height, int freq, int bandWidth, int channel, double power)
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
                          "Channel = " + channel + "\n" +
                          "Tx Power = " + power;

            CheckBox newCheckBox = new CheckBox();
            // tabPageField.Controls.Add(newCheckBox);

            newCheckBox.AutoSize = true;
            newCheckBox.Location = new Point(x, y);
            newCheckBox.Size = new Size(113, 24);       /* Use default size */
            newCheckBox.TabIndex = testPoints.Count + 1;
            newCheckBox.Text = "Point #" + (testPoints.Count + 1);
            toolTipToDisplayInfo.SetToolTip(newCheckBox, info);
            newCheckBox.UseVisualStyleBackColor = true;
            // newCheckBox.ContextMenuStrip = contextMenuStripModify;
            newCheckBox.CheckStateChanged += new EventHandler(newCheckBox_CheckStateChanged);

            testPoints.Add(newCheckBox);

                int newRowIndex = dataGridViewPointSettings.Rows.Add();
                dataGridViewPointSettings.Rows[newRowIndex].Cells[1].Value = newCheckBox.Text;
                dataGridViewPointSettings.Rows[newRowIndex].Cells[2].Value = radius;
                dataGridViewPointSettings.Rows[newRowIndex].Cells[3].Value = angle;
                dataGridViewPointSettings.Rows[newRowIndex].Cells[4].Value = height;
                dataGridViewPointSettings.Rows[newRowIndex].Cells[5].Value = freq;
                dataGridViewPointSettings.Rows[newRowIndex].Cells[6].Value = bandWidth;
                dataGridViewPointSettings.Rows[newRowIndex].Cells[7].Value = channel;
                dataGridViewPointSettings.Rows[newRowIndex].Cells[8].Value = power;

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
            doneFlag = false;
            timer = DateTime.Now;
            TraceAndShowElapsedTime();             
            #endregion

            string toolTip = toolTipToDisplayInfo.GetToolTip(currentTestPoint);

            int radius, angle, height, freq, bandWidth, channel;
            double power;
            ParseOutToolTip(toolTip, out radius, out angle, out height, out freq, out bandWidth, out channel, out power);

            for (int row = 0; row < (dataGridViewPointSettings.Rows.Count-1); row++)
            {
                if ( ((dataGridViewPointSettings.Rows[row].Cells[1].Value as string) == currentTestPoint.Text) && 
                     (true == Convert.ToBoolean(((DataGridViewCheckBoxCell)dataGridViewPointSettings.Rows[row].Cells[0]).Value)) )
                {
                    PerformTestingProcedure(currentTestPoint.Text,                                                     /* Point # */
                                            Convert.ToInt32(dataGridViewPointSettings.Rows[row].Cells[2].Value),       /* Radius */
                                            Convert.ToInt32(dataGridViewPointSettings.Rows[row].Cells[3].Value),       /* Angle */
                                            Convert.ToInt32(dataGridViewPointSettings.Rows[row].Cells[4].Value),       /* Height */
                                            Convert.ToInt32(dataGridViewPointSettings.Rows[row].Cells[5].Value),       /* Freq. */
                                            Convert.ToInt32(dataGridViewPointSettings.Rows[row].Cells[6].Value),       /* Bandwidth */
                                            Convert.ToInt32(dataGridViewPointSettings.Rows[row].Cells[7].Value),       /* Channel */
                                            Convert.ToDouble(dataGridViewPointSettings.Rows[row].Cells[8].Value));     /* Power */
                }
            }               
            doneFlag = true;
        }

        private void PerformTestingProcedure(string pointNo, int radius, int angle, int height, int freq, int bandWidth, int channel, double power)
        {
            /* Perform the network connectivity test items */
            string tcpUplinkThroughput = "", tcpDownlinkThroughput = "";
            string udpUplinkThroughput = "", udpUplinkLatency = "", udpUplinkPacketLoss = "",
                   udpDownlinkThroughput = "", udpDownlinkLatency = "", udpDownlinkPacketLoss = "";

            progressBarTesting.Value = 1;

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

            FillTestResultsTable(pointNo,
                                 radius.ToString(),
                                 angle.ToString(),
                                 height.ToString(),
                                 freq.ToString(),
                                 bandWidth.ToString(),
                                 channel.ToString(),
                                 power.ToString(),
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
                double power;
                ParseOutToolTip(toolTip, out radius, out angle, out height, out freq, out bandWidth, out channel, out power);

                int x = origin.X + (int)((radius / scaleDownRatio) * Math.Cos(2 * Math.PI * angle / 360.00));
                int y = origin.Y - (int)((radius / scaleDownRatio) * Math.Sin(2 * Math.PI * angle / 360.00));
                testPoint.Location = new Point(x, y);
            }
        }

        private void ParseOutToolTip(string toolTip, out int radius, out int angle, out int height, out int freq, out int bandWidth, out int channel, out double power)
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
            power = Convert.ToDouble(field_values[6]);
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
                                          string power,
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
            dataGridViewTestResults.Rows[existedRows].Cells[7].Value = power;
            dataGridViewTestResults.Rows[existedRows].Cells[8].Value = tcpUplinkThroughput;
            dataGridViewTestResults.Rows[existedRows].Cells[9].Value = tcpDownlinkThroughput;
            dataGridViewTestResults.Rows[existedRows].Cells[10].Value = udpUplinkThroughput;
            dataGridViewTestResults.Rows[existedRows].Cells[11].Value = udpUplinkLatency;
            dataGridViewTestResults.Rows[existedRows].Cells[12].Value = udpUplinkPacketLoss;
            dataGridViewTestResults.Rows[existedRows].Cells[13].Value = udpDownlinkThroughput;
            dataGridViewTestResults.Rows[existedRows].Cells[14].Value = udpDownlinkLatency;
            dataGridViewTestResults.Rows[existedRows].Cells[15].Value = udpDownlinkPacketLoss;
            dataGridViewTestResults.Rows[existedRows].Cells[16].Value = rssi;
            dataGridViewTestResults.Rows[existedRows].Cells[17].Value = snr;
            dataGridViewTestResults.Rows[existedRows].Cells[18].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

#if false
        #region BackgroundWorker to trace the testing elapsed time asynchronously
        private BackgroundWorker bgwork;

        private void InitializeBackgroundWork()
        {
            bgwork = new BackgroundWorker();
            bgwork.WorkerReportsProgress = true;

            bgwork.DoWork += new DoWorkEventHandler(bgwork_DoWork);
            bgwork.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgwork_RunWorkerCompleted);
            bgwork.ProgressChanged += new ProgressChangedEventHandler(bgwork_ProgressChanged);
        }

        private void bgwork_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            TraceAndDisplayTestingElapsedTime(worker, e);
        }

        private void TraceAndDisplayTestingElapsedTime(BackgroundWorker worker, DoWorkEventArgs e)
        {
            while (doneFlag == false)
            {
                e.Result = DateTime.Now.Subtract(timer).ToString();
                Application.DoEvents();
            }
        }

        private void bgwork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            labelElapsedTime.Text = DateTime.Now.Subtract(timer).ToString();
        }

        private void bgwork_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            labelElapsedTime.Text = "Elapsed time : " + DateTime.Now.Subtract(timer).ToString();
        }
#endregion
#endif

        private void btnClearTestResults_Click(object sender, EventArgs e)
        {
            dataGridViewTestResults.Rows.Clear();
        }

        private void btnSaveTestResults_Click(object sender, EventArgs e)
        {
            if (labelFilePathToSave.Text != string.Empty)
            {
                SaveTestResultsToCsv(labelFilePathToSave.Text);
                return;
            }

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
                line = "";
            }

            sw.Close();
            fs.Close();
            MessageBox.Show("The .csv file of test results had been saved successfully.", "Save");
        }

        private void TraceAndShowElapsedTime()
        {
            System.Threading.Thread threadTraceTime = new System.Threading.Thread(new System.Threading.ThreadStart(()=>
            {
                while (doneFlag == false)
                {
                    labelElapsedTime.BeginInvoke(new MethodInvoker(()=>labelElapsedTime.Text = "Elapsed time : " + DateTime.Now.Subtract(timer).ToString()));
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(500);
                }
            }));
            threadTraceTime.IsBackground = true;
            threadTraceTime.Start();
        }

        private void modifySettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeConfigurationForm changeConfigForm = new ChangeConfigurationForm();
            changeConfigForm.ShowDialog();

            int height = changeConfigForm.TestPointHeight;
            int frequency = changeConfigForm.Frequency;
            int bandwidth = changeConfigForm.Bandwidth;
            int channel = changeConfigForm.Channel;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            /* Load from the csv file to fill the test points setting table, and 
             * draw all test points in the figure.
             */
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open the .csv file to load into test points setting table.";
            dlg.InitialDirectory = "";
            dlg.DefaultExt = "csv";
            dlg.Filter = "CSV file | *.csv";
            dlg.AddExtension = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dataGridViewPointSettings.Rows.Clear();
                RemoveOldTestPoints();

                DataTable table = ReadTestPointsSettingFrom(dlg.FileName);
                FillTestPointsSettingTable(table);
                CreateCheckBoxesInBatch(table);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            /* Save the test points setting table into a csv file. */
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "Save the test points setting into .csv file.";
            dlg.InitialDirectory = "";
            dlg.DefaultExt = "csv";
            dlg.Filter = "CSV file | *.csv";
            dlg.AddExtension = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                SaveTestPointsSettingTable(dlg.FileName);
            }
        }

        private void SaveTestPointsSettingTable(string csvFileName)
        {
            int rowCount = dataGridViewPointSettings.Rows.Count;
            int colCount = dataGridViewPointSettings.Columns.Count;

            int rowIndex, colIndex;
            FileStream fs = new FileStream(csvFileName, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

            string title = "";
            for (colIndex = 1; colIndex < colCount; colIndex++)     /* Ignore column 0 "Selected", which is checked by test engineer manually */
            {
                title += dataGridViewPointSettings.Columns[colIndex].HeaderText;
                if (colIndex < (colCount-1))
                {
                    title += ",";
                }
            }
            sw.WriteLine(title);

            string line = "";
            for (rowIndex = 0; rowIndex < (rowCount-1); rowIndex++)
            {
                for (colIndex = 1; colIndex < colCount; colIndex++)
                {
                    line += Convert.ToString(dataGridViewPointSettings.Rows[rowIndex].Cells[colIndex].Value);
                    if (colIndex < (colCount-1))
                    {
                        line += ",";
                    }
                }
                sw.WriteLine(line);
                line = "";
            }
            sw.Close();
            fs.Close();
            MessageBox.Show("The test points setting table had been saved into .csv file!", "Save");
        }

        private DataTable ReadTestPointsSettingFrom(string csvFileName)
        {
            DataTable dt = new DataTable();
            FileStream fs = new FileStream(csvFileName, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string line = "";
            bool headFlag = true;
            while ((line = sr.ReadLine()) != null)  /* Read one line each time from the csv file */
            {
                string[] columnFields = line.Split(',');
                if (headFlag == true)       /* Focus on dealing with the table title */
                {
                    for (int colIndex = 0; colIndex < 8; colIndex++)
                    {
                        DataColumn dcol = new DataColumn(columnFields[colIndex]);
                        dt.Columns.Add(dcol);
                    }
                    headFlag = false;
                }
                else        /* Focus on dealing with the table content */
                {
                    DataRow drow = dt.NewRow();
                    for (int colIndex = 0; colIndex < 8 /* columnFields.Length */; colIndex++)
                    {
                        drow[colIndex] = columnFields[colIndex];
                    }
                    dt.Rows.Add(drow);
                }
            }

            sr.Close();
            fs.Close();
            return dt;
        }

        private void FillTestPointsSettingTable(DataTable table)
        {
            int rowCount = table.Rows.Count;
            int colCount = table.Columns.Count;

            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                int existedRowIndex = dataGridViewPointSettings.Rows.Add();
                for (int colIndex = 0; colIndex < colCount; colIndex++)
                {
                    dataGridViewPointSettings.Rows[existedRowIndex].Cells[colIndex + 1].Value = table.Rows[rowIndex][colIndex];
                }
            }
        }

        private void CreateCheckBoxesInBatch(DataTable testPointsSettingTable)
        {
            int rowCount = testPointsSettingTable.Rows.Count;
            Point origin = getOriginPointOfCoordinateSystem();

            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                string pointNo = Convert.ToString(testPointsSettingTable.Rows[rowIndex][0]);
                int radius = Convert.ToInt32(testPointsSettingTable.Rows[rowIndex][1]);
                int angle = Convert.ToInt32(testPointsSettingTable.Rows[rowIndex][2]);
                int height = Convert.ToInt32(testPointsSettingTable.Rows[rowIndex][3]);
                int freq = Convert.ToInt32(testPointsSettingTable.Rows[rowIndex][4]);
                int bandwidth = Convert.ToInt32(testPointsSettingTable.Rows[rowIndex][5]);
                int channel = Convert.ToInt32(testPointsSettingTable.Rows[rowIndex][6]);
                double power = Convert.ToDouble(testPointsSettingTable.Rows[rowIndex][7]);

                int x = origin.X + (int)((radius / scaleDownRatio) * Math.Cos(2 * Math.PI * angle / 360.00));
                int y = origin.Y - (int)((radius / scaleDownRatio) * Math.Sin(2 * Math.PI * angle / 360.00));
                DrawCircle(radius);
                radiusList.Add(radius);
                string info = "Radius = " + radius + "\n" +
                              "Angle = " + angle + "\n" +
                              "Height = " + height + "\n" +
                              "Frequency = " + freq + "\n" +
                              "Bandwidth = " + bandwidth + "\n" +
                              "Channel = " + channel + "\n" +
                              "Tx Power = " + power;

                CheckBox newCheckBox = new CheckBox();
                newCheckBox.AutoSize = true;
                newCheckBox.Location = new Point(x, y);
                newCheckBox.Size = new Size(113, 24);
                newCheckBox.Text = pointNo;
                toolTipToDisplayInfo.SetToolTip(newCheckBox, info);
                newCheckBox.UseVisualStyleBackColor = true;
                newCheckBox.CheckStateChanged += new EventHandler(newCheckBox_CheckStateChanged);
                testPoints.Add(newCheckBox);

                tabControlTesting.SuspendLayout();
                tabPageField.SuspendLayout();
                SuspendLayout();
                tabPageField.Controls.Add(newCheckBox);
                tabControlTesting.ResumeLayout(false);
                tabPageField.ResumeLayout(false);
                tabPageField.PerformLayout();
                this.ResumeLayout(false);
                this.PerformLayout();
            }
        } 

        private void RemoveOldTestPoints()
        {
            if ((testPoints.Count == 0) || (radiusList.Count == 0))
            {
                return;
            }

            foreach (CheckBox cbox in testPoints)
            {
                tabPageField.Controls.Remove(cbox);
            }
            radiusList.Clear();
            return;
        }
    }
}

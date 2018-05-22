namespace AUPS.Tools
{
    partial class GMVehicleAntennaTesting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GMVehicleAntennaTesting));
            this.toolTipToDisplayInfo = new System.Windows.Forms.ToolTip(this.components);
            this.groupBoxTestPointsSetting = new System.Windows.Forms.GroupBox();
            this.textBoxSaVisaAddress = new System.Windows.Forms.TextBox();
            this.labelSaVisaAddress = new System.Windows.Forms.Label();
            this.textBoxSgVisaAddress = new System.Windows.Forms.TextBox();
            this.labelSgVisaAddress = new System.Windows.Forms.Label();
            this.btnBrowseIperf3 = new System.Windows.Forms.Button();
            this.textBoxIperf3Path = new System.Windows.Forms.TextBox();
            this.labelIperf3Path = new System.Windows.Forms.Label();
            this.comboBoxBandWidth = new System.Windows.Forms.ComboBox();
            this.labelBandWidth = new System.Windows.Forms.Label();
            this.textBoxServerIP = new System.Windows.Forms.TextBox();
            this.labelServerIP = new System.Windows.Forms.Label();
            this.textBoxChannel = new System.Windows.Forms.TextBox();
            this.btnRefreshDrawing = new System.Windows.Forms.Button();
            this.labelChannel = new System.Windows.Forms.Label();
            this.textBoxFreqBand = new System.Windows.Forms.TextBox();
            this.labelFreqBand = new System.Windows.Forms.Label();
            this.btnNewPoint = new System.Windows.Forms.Button();
            this.textBoxHeight = new System.Windows.Forms.TextBox();
            this.labelHeight = new System.Windows.Forms.Label();
            this.textBoxAngle = new System.Windows.Forms.TextBox();
            this.labelAngle = new System.Windows.Forms.Label();
            this.textBoxRadius = new System.Windows.Forms.TextBox();
            this.labelRadius = new System.Windows.Forms.Label();
            this.tabControlTesting = new System.Windows.Forms.TabControl();
            this.tabPageField = new System.Windows.Forms.TabPage();
            this.pictureBoxCar = new System.Windows.Forms.PictureBox();
            this.tabPageIperfLog = new System.Windows.Forms.TabPage();
            this.textBoxIperfTestLog = new System.Windows.Forms.TextBox();
            this.tabPageResults = new System.Windows.Forms.TabPage();
            this.dataGridViewTestResults = new System.Windows.Forms.DataGridView();
            this.columnPointNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnRadius = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnAngle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnFrequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnBand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnChannel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnTcpUplinkThroughput = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnTcpDownlinkThroughput = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnUdpUplinkThroughput = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnUdpUplinkLatency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnUdpUplinkPacketLoss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnUdpDownlinkThroughput = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnUdpDownlinkLatency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnUdpDownlinkPacketLoss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnRssi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnSnr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnTimeStamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progressBarTesting = new System.Windows.Forms.ProgressBar();
            this.labelElapsedTime = new System.Windows.Forms.Label();
            this.groupBoxTestPointsSetting.SuspendLayout();
            this.tabControlTesting.SuspendLayout();
            this.tabPageField.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCar)).BeginInit();
            this.tabPageIperfLog.SuspendLayout();
            this.tabPageResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTestResults)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxTestPointsSetting
            // 
            this.groupBoxTestPointsSetting.AutoSize = true;
            this.groupBoxTestPointsSetting.Controls.Add(this.labelElapsedTime);
            this.groupBoxTestPointsSetting.Controls.Add(this.textBoxSaVisaAddress);
            this.groupBoxTestPointsSetting.Controls.Add(this.labelSaVisaAddress);
            this.groupBoxTestPointsSetting.Controls.Add(this.textBoxSgVisaAddress);
            this.groupBoxTestPointsSetting.Controls.Add(this.labelSgVisaAddress);
            this.groupBoxTestPointsSetting.Controls.Add(this.btnBrowseIperf3);
            this.groupBoxTestPointsSetting.Controls.Add(this.textBoxIperf3Path);
            this.groupBoxTestPointsSetting.Controls.Add(this.labelIperf3Path);
            this.groupBoxTestPointsSetting.Controls.Add(this.comboBoxBandWidth);
            this.groupBoxTestPointsSetting.Controls.Add(this.labelBandWidth);
            this.groupBoxTestPointsSetting.Controls.Add(this.textBoxServerIP);
            this.groupBoxTestPointsSetting.Controls.Add(this.labelServerIP);
            this.groupBoxTestPointsSetting.Controls.Add(this.textBoxChannel);
            this.groupBoxTestPointsSetting.Controls.Add(this.btnRefreshDrawing);
            this.groupBoxTestPointsSetting.Controls.Add(this.labelChannel);
            this.groupBoxTestPointsSetting.Controls.Add(this.textBoxFreqBand);
            this.groupBoxTestPointsSetting.Controls.Add(this.labelFreqBand);
            this.groupBoxTestPointsSetting.Controls.Add(this.btnNewPoint);
            this.groupBoxTestPointsSetting.Controls.Add(this.textBoxHeight);
            this.groupBoxTestPointsSetting.Controls.Add(this.labelHeight);
            this.groupBoxTestPointsSetting.Controls.Add(this.textBoxAngle);
            this.groupBoxTestPointsSetting.Controls.Add(this.labelAngle);
            this.groupBoxTestPointsSetting.Controls.Add(this.textBoxRadius);
            this.groupBoxTestPointsSetting.Controls.Add(this.labelRadius);
            this.groupBoxTestPointsSetting.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxTestPointsSetting.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBoxTestPointsSetting.Location = new System.Drawing.Point(0, 0);
            this.groupBoxTestPointsSetting.Name = "groupBoxTestPointsSetting";
            this.groupBoxTestPointsSetting.Size = new System.Drawing.Size(397, 1319);
            this.groupBoxTestPointsSetting.TabIndex = 1;
            this.groupBoxTestPointsSetting.TabStop = false;
            this.groupBoxTestPointsSetting.Text = "Testing points setting";
            // 
            // textBoxSaVisaAddress
            // 
            this.textBoxSaVisaAddress.Location = new System.Drawing.Point(19, 870);
            this.textBoxSaVisaAddress.Name = "textBoxSaVisaAddress";
            this.textBoxSaVisaAddress.Size = new System.Drawing.Size(372, 26);
            this.textBoxSaVisaAddress.TabIndex = 21;
            // 
            // labelSaVisaAddress
            // 
            this.labelSaVisaAddress.AutoSize = true;
            this.labelSaVisaAddress.Location = new System.Drawing.Point(15, 827);
            this.labelSaVisaAddress.Name = "labelSaVisaAddress";
            this.labelSaVisaAddress.Size = new System.Drawing.Size(231, 20);
            this.labelSaVisaAddress.TabIndex = 20;
            this.labelSaVisaAddress.Text = "Signal analyzer VISA address : ";
            // 
            // textBoxSgVisaAddress
            // 
            this.textBoxSgVisaAddress.Location = new System.Drawing.Point(19, 764);
            this.textBoxSgVisaAddress.Name = "textBoxSgVisaAddress";
            this.textBoxSgVisaAddress.Size = new System.Drawing.Size(372, 26);
            this.textBoxSgVisaAddress.TabIndex = 19;
            // 
            // labelSgVisaAddress
            // 
            this.labelSgVisaAddress.AutoSize = true;
            this.labelSgVisaAddress.Location = new System.Drawing.Point(15, 729);
            this.labelSgVisaAddress.Name = "labelSgVisaAddress";
            this.labelSgVisaAddress.Size = new System.Drawing.Size(241, 20);
            this.labelSgVisaAddress.TabIndex = 18;
            this.labelSgVisaAddress.Text = "Signal generator VISA address : ";
            // 
            // btnBrowseIperf3
            // 
            this.btnBrowseIperf3.Location = new System.Drawing.Point(203, 600);
            this.btnBrowseIperf3.Name = "btnBrowseIperf3";
            this.btnBrowseIperf3.Size = new System.Drawing.Size(188, 37);
            this.btnBrowseIperf3.TabIndex = 17;
            this.btnBrowseIperf3.Text = "Browse iPerf3.exe";
            this.btnBrowseIperf3.UseVisualStyleBackColor = true;
            this.btnBrowseIperf3.Click += new System.EventHandler(this.btnBrowseIperf3_Click);
            // 
            // textBoxIperf3Path
            // 
            this.textBoxIperf3Path.Location = new System.Drawing.Point(19, 657);
            this.textBoxIperf3Path.Name = "textBoxIperf3Path";
            this.textBoxIperf3Path.Size = new System.Drawing.Size(372, 26);
            this.textBoxIperf3Path.TabIndex = 16;
            // 
            // labelIperf3Path
            // 
            this.labelIperf3Path.AutoSize = true;
            this.labelIperf3Path.Location = new System.Drawing.Point(19, 605);
            this.labelIperf3Path.Name = "labelIperf3Path";
            this.labelIperf3Path.Size = new System.Drawing.Size(86, 20);
            this.labelIperf3Path.TabIndex = 15;
            this.labelIperf3Path.Text = "iPerf3 path";
            // 
            // comboBoxBandWidth
            // 
            this.comboBoxBandWidth.FormattingEnabled = true;
            this.comboBoxBandWidth.Items.AddRange(new object[] {
            "20",
            "40",
            "80"});
            this.comboBoxBandWidth.Location = new System.Drawing.Point(203, 245);
            this.comboBoxBandWidth.Name = "comboBoxBandWidth";
            this.comboBoxBandWidth.Size = new System.Drawing.Size(188, 28);
            this.comboBoxBandWidth.TabIndex = 14;
            // 
            // labelBandWidth
            // 
            this.labelBandWidth.AutoSize = true;
            this.labelBandWidth.Location = new System.Drawing.Point(19, 245);
            this.labelBandWidth.Name = "labelBandWidth";
            this.labelBandWidth.Size = new System.Drawing.Size(173, 20);
            this.labelBandWidth.TabIndex = 13;
            this.labelBandWidth.Text = "Band width (unit : MHz)";
            // 
            // textBoxServerIP
            // 
            this.textBoxServerIP.Location = new System.Drawing.Point(203, 537);
            this.textBoxServerIP.Name = "textBoxServerIP";
            this.textBoxServerIP.Size = new System.Drawing.Size(188, 26);
            this.textBoxServerIP.TabIndex = 12;
            // 
            // labelServerIP
            // 
            this.labelServerIP.AutoSize = true;
            this.labelServerIP.Location = new System.Drawing.Point(15, 537);
            this.labelServerIP.Name = "labelServerIP";
            this.labelServerIP.Size = new System.Drawing.Size(135, 20);
            this.labelServerIP.TabIndex = 11;
            this.labelServerIP.Text = "Server IP address";
            // 
            // textBoxChannel
            // 
            this.textBoxChannel.Location = new System.Drawing.Point(203, 291);
            this.textBoxChannel.Name = "textBoxChannel";
            this.textBoxChannel.Size = new System.Drawing.Size(188, 26);
            this.textBoxChannel.TabIndex = 10;
            // 
            // btnRefreshDrawing
            // 
            this.btnRefreshDrawing.Location = new System.Drawing.Point(19, 438);
            this.btnRefreshDrawing.Name = "btnRefreshDrawing";
            this.btnRefreshDrawing.Size = new System.Drawing.Size(372, 43);
            this.btnRefreshDrawing.TabIndex = 4;
            this.btnRefreshDrawing.Text = "Refresh drawing";
            this.btnRefreshDrawing.UseVisualStyleBackColor = true;
            this.btnRefreshDrawing.Click += new System.EventHandler(this.btnRefreshDrawing_Click);
            // 
            // labelChannel
            // 
            this.labelChannel.AutoSize = true;
            this.labelChannel.Location = new System.Drawing.Point(15, 291);
            this.labelChannel.Name = "labelChannel";
            this.labelChannel.Size = new System.Drawing.Size(108, 20);
            this.labelChannel.TabIndex = 9;
            this.labelChannel.Text = "Wi-Fi Channel";
            // 
            // textBoxFreqBand
            // 
            this.textBoxFreqBand.Location = new System.Drawing.Point(203, 191);
            this.textBoxFreqBand.Name = "textBoxFreqBand";
            this.textBoxFreqBand.Size = new System.Drawing.Size(188, 26);
            this.textBoxFreqBand.TabIndex = 8;
            // 
            // labelFreqBand
            // 
            this.labelFreqBand.AutoSize = true;
            this.labelFreqBand.Location = new System.Drawing.Point(15, 191);
            this.labelFreqBand.Name = "labelFreqBand";
            this.labelFreqBand.Size = new System.Drawing.Size(169, 20);
            this.labelFreqBand.TabIndex = 7;
            this.labelFreqBand.Text = "Frequency (unit : MHz)";
            // 
            // btnNewPoint
            // 
            this.btnNewPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNewPoint.Location = new System.Drawing.Point(19, 354);
            this.btnNewPoint.Name = "btnNewPoint";
            this.btnNewPoint.Size = new System.Drawing.Size(372, 53);
            this.btnNewPoint.TabIndex = 6;
            this.btnNewPoint.Text = "New Testing Point";
            this.btnNewPoint.UseVisualStyleBackColor = true;
            this.btnNewPoint.Click += new System.EventHandler(this.btnNewPoint_Click);
            // 
            // textBoxHeight
            // 
            this.textBoxHeight.Location = new System.Drawing.Point(203, 139);
            this.textBoxHeight.Name = "textBoxHeight";
            this.textBoxHeight.Size = new System.Drawing.Size(188, 26);
            this.textBoxHeight.TabIndex = 5;
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Location = new System.Drawing.Point(15, 139);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(129, 20);
            this.labelHeight.TabIndex = 4;
            this.labelHeight.Text = "Height (unit : cm)";
            // 
            // textBoxAngle
            // 
            this.textBoxAngle.Location = new System.Drawing.Point(203, 89);
            this.textBoxAngle.Name = "textBoxAngle";
            this.textBoxAngle.Size = new System.Drawing.Size(188, 26);
            this.textBoxAngle.TabIndex = 3;
            // 
            // labelAngle
            // 
            this.labelAngle.AutoSize = true;
            this.labelAngle.Location = new System.Drawing.Point(15, 89);
            this.labelAngle.Name = "labelAngle";
            this.labelAngle.Size = new System.Drawing.Size(152, 20);
            this.labelAngle.TabIndex = 2;
            this.labelAngle.Text = "Angle (unit : degree)";
            // 
            // textBoxRadius
            // 
            this.textBoxRadius.Location = new System.Drawing.Point(203, 38);
            this.textBoxRadius.Name = "textBoxRadius";
            this.textBoxRadius.Size = new System.Drawing.Size(188, 26);
            this.textBoxRadius.TabIndex = 1;
            // 
            // labelRadius
            // 
            this.labelRadius.AutoSize = true;
            this.labelRadius.Location = new System.Drawing.Point(15, 38);
            this.labelRadius.Name = "labelRadius";
            this.labelRadius.Size = new System.Drawing.Size(132, 20);
            this.labelRadius.TabIndex = 0;
            this.labelRadius.Text = "Radius (unit : cm)";
            // 
            // tabControlTesting
            // 
            this.tabControlTesting.Controls.Add(this.tabPageField);
            this.tabControlTesting.Controls.Add(this.tabPageIperfLog);
            this.tabControlTesting.Controls.Add(this.tabPageResults);
            this.tabControlTesting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlTesting.Location = new System.Drawing.Point(397, 0);
            this.tabControlTesting.Name = "tabControlTesting";
            this.tabControlTesting.SelectedIndex = 0;
            this.tabControlTesting.Size = new System.Drawing.Size(1582, 1319);
            this.tabControlTesting.TabIndex = 5;
            this.tabControlTesting.Resize += new System.EventHandler(this.tabControlTesting_Resize);
            // 
            // tabPageField
            // 
            this.tabPageField.AutoScroll = true;
            this.tabPageField.Controls.Add(this.pictureBoxCar);
            this.tabPageField.Location = new System.Drawing.Point(4, 29);
            this.tabPageField.Name = "tabPageField";
            this.tabPageField.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageField.Size = new System.Drawing.Size(1574, 1286);
            this.tabPageField.TabIndex = 0;
            this.tabPageField.Text = "Test field";
            this.tabPageField.UseVisualStyleBackColor = true;
            // 
            // pictureBoxCar
            // 
            this.pictureBoxCar.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxCar.Image")));
            this.pictureBoxCar.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxCar.InitialImage")));
            this.pictureBoxCar.Location = new System.Drawing.Point(704, 516);
            this.pictureBoxCar.Name = "pictureBoxCar";
            this.pictureBoxCar.Size = new System.Drawing.Size(155, 125);
            this.pictureBoxCar.TabIndex = 0;
            this.pictureBoxCar.TabStop = false;
            // 
            // tabPageIperfLog
            // 
            this.tabPageIperfLog.Controls.Add(this.textBoxIperfTestLog);
            this.tabPageIperfLog.Location = new System.Drawing.Point(4, 29);
            this.tabPageIperfLog.Name = "tabPageIperfLog";
            this.tabPageIperfLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageIperfLog.Size = new System.Drawing.Size(1574, 1286);
            this.tabPageIperfLog.TabIndex = 1;
            this.tabPageIperfLog.Text = "iPerf log";
            this.tabPageIperfLog.UseVisualStyleBackColor = true;
            // 
            // textBoxIperfTestLog
            // 
            this.textBoxIperfTestLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxIperfTestLog.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIperfTestLog.Location = new System.Drawing.Point(3, 3);
            this.textBoxIperfTestLog.Multiline = true;
            this.textBoxIperfTestLog.Name = "textBoxIperfTestLog";
            this.textBoxIperfTestLog.ReadOnly = true;
            this.textBoxIperfTestLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxIperfTestLog.Size = new System.Drawing.Size(1568, 1280);
            this.textBoxIperfTestLog.TabIndex = 0;
            this.textBoxIperfTestLog.WordWrap = false;
            // 
            // tabPageResults
            // 
            this.tabPageResults.Controls.Add(this.dataGridViewTestResults);
            this.tabPageResults.Location = new System.Drawing.Point(4, 29);
            this.tabPageResults.Name = "tabPageResults";
            this.tabPageResults.Size = new System.Drawing.Size(1574, 1286);
            this.tabPageResults.TabIndex = 2;
            this.tabPageResults.Text = "Test results";
            this.tabPageResults.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTestResults
            // 
            this.dataGridViewTestResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTestResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnPointNo,
            this.columnRadius,
            this.columnAngle,
            this.columnHeight,
            this.columnFrequency,
            this.columnBand,
            this.columnChannel,
            this.columnTcpUplinkThroughput,
            this.columnTcpDownlinkThroughput,
            this.columnUdpUplinkThroughput,
            this.columnUdpUplinkLatency,
            this.columnUdpUplinkPacketLoss,
            this.columnUdpDownlinkThroughput,
            this.columnUdpDownlinkLatency,
            this.columnUdpDownlinkPacketLoss,
            this.columnRssi,
            this.columnSnr,
            this.columnTimeStamp});
            this.dataGridViewTestResults.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewTestResults.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewTestResults.Name = "dataGridViewTestResults";
            this.dataGridViewTestResults.RowTemplate.Height = 28;
            this.dataGridViewTestResults.Size = new System.Drawing.Size(1574, 710);
            this.dataGridViewTestResults.TabIndex = 0;
            // 
            // columnPointNo
            // 
            this.columnPointNo.HeaderText = "Point #";
            this.columnPointNo.Name = "columnPointNo";
            // 
            // columnRadius
            // 
            this.columnRadius.HeaderText = "Radius (unit : cm)";
            this.columnRadius.Name = "columnRadius";
            // 
            // columnAngle
            // 
            this.columnAngle.HeaderText = "Angle (unit : degree)";
            this.columnAngle.Name = "columnAngle";
            // 
            // columnHeight
            // 
            this.columnHeight.HeaderText = "Height (unit : cm)";
            this.columnHeight.Name = "columnHeight";
            // 
            // columnFrequency
            // 
            this.columnFrequency.HeaderText = "Frequency (unit : MHz)";
            this.columnFrequency.Name = "columnFrequency";
            // 
            // columnBand
            // 
            this.columnBand.HeaderText = "Band (unit : MHz)";
            this.columnBand.Name = "columnBand";
            // 
            // columnChannel
            // 
            this.columnChannel.HeaderText = "Channel";
            this.columnChannel.Name = "columnChannel";
            // 
            // columnTcpUplinkThroughput
            // 
            this.columnTcpUplinkThroughput.HeaderText = "TCP uplink throughput";
            this.columnTcpUplinkThroughput.Name = "columnTcpUplinkThroughput";
            // 
            // columnTcpDownlinkThroughput
            // 
            this.columnTcpDownlinkThroughput.HeaderText = "TCP downlink throughput";
            this.columnTcpDownlinkThroughput.Name = "columnTcpDownlinkThroughput";
            // 
            // columnUdpUplinkThroughput
            // 
            this.columnUdpUplinkThroughput.HeaderText = "UDP uplink throughput";
            this.columnUdpUplinkThroughput.Name = "columnUdpUplinkThroughput";
            // 
            // columnUdpUplinkLatency
            // 
            this.columnUdpUplinkLatency.HeaderText = "UDP uplink latency";
            this.columnUdpUplinkLatency.Name = "columnUdpUplinkLatency";
            // 
            // columnUdpUplinkPacketLoss
            // 
            this.columnUdpUplinkPacketLoss.HeaderText = "UDP uplink packet loss";
            this.columnUdpUplinkPacketLoss.Name = "columnUdpUplinkPacketLoss";
            // 
            // columnUdpDownlinkThroughput
            // 
            this.columnUdpDownlinkThroughput.HeaderText = "UDP downlink throughput";
            this.columnUdpDownlinkThroughput.Name = "columnUdpDownlinkThroughput";
            // 
            // columnUdpDownlinkLatency
            // 
            this.columnUdpDownlinkLatency.HeaderText = "UDP downlink latency";
            this.columnUdpDownlinkLatency.Name = "columnUdpDownlinkLatency";
            // 
            // columnUdpDownlinkPacketLoss
            // 
            this.columnUdpDownlinkPacketLoss.HeaderText = "UDP downlink packet loss";
            this.columnUdpDownlinkPacketLoss.Name = "columnUdpDownlinkPacketLoss";
            // 
            // columnRssi
            // 
            this.columnRssi.HeaderText = "RSSI (unit : dBm)";
            this.columnRssi.Name = "columnRssi";
            // 
            // columnSnr
            // 
            this.columnSnr.HeaderText = "SNR (unit : dB)";
            this.columnSnr.Name = "columnSnr";
            // 
            // columnTimeStamp
            // 
            this.columnTimeStamp.HeaderText = "Time stamp";
            this.columnTimeStamp.Name = "columnTimeStamp";
            // 
            // progressBarTesting
            // 
            this.progressBarTesting.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBarTesting.Location = new System.Drawing.Point(397, 1293);
            this.progressBarTesting.Name = "progressBarTesting";
            this.progressBarTesting.Size = new System.Drawing.Size(1582, 26);
            this.progressBarTesting.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarTesting.TabIndex = 6;
            // 
            // labelElapsedTime
            // 
            this.labelElapsedTime.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelElapsedTime.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelElapsedTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.labelElapsedTime.Location = new System.Drawing.Point(3, 1293);
            this.labelElapsedTime.Name = "labelElapsedTime";
            this.labelElapsedTime.Size = new System.Drawing.Size(391, 23);
            this.labelElapsedTime.TabIndex = 7;
            this.labelElapsedTime.Text = "Elapsed time : 00:00:00.000";
            // 
            // GMVehicleAntennaTesting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1979, 1319);
            this.Controls.Add(this.progressBarTesting);
            this.Controls.Add(this.tabControlTesting);
            this.Controls.Add(this.groupBoxTestPointsSetting);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GMVehicleAntennaTesting";
            this.Text = "GM vehicle Wi-Fi antenna testing";
            this.groupBoxTestPointsSetting.ResumeLayout(false);
            this.groupBoxTestPointsSetting.PerformLayout();
            this.tabControlTesting.ResumeLayout(false);
            this.tabPageField.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCar)).EndInit();
            this.tabPageIperfLog.ResumeLayout(false);
            this.tabPageIperfLog.PerformLayout();
            this.tabPageResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTestResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTipToDisplayInfo;
        private System.Windows.Forms.GroupBox groupBoxTestPointsSetting;
        private System.Windows.Forms.Label labelRadius;
        private System.Windows.Forms.TextBox textBoxAngle;
        private System.Windows.Forms.Label labelAngle;
        private System.Windows.Forms.TextBox textBoxRadius;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.TextBox textBoxHeight;
        private System.Windows.Forms.Label labelFreqBand;
        private System.Windows.Forms.Button btnNewPoint;
        private System.Windows.Forms.TextBox textBoxFreqBand;
        private System.Windows.Forms.TextBox textBoxChannel;
        private System.Windows.Forms.Label labelChannel;
        private System.Windows.Forms.Button btnRefreshDrawing;
        private System.Windows.Forms.TabControl tabControlTesting;
        private System.Windows.Forms.TabPage tabPageField;
        private System.Windows.Forms.TabPage tabPageIperfLog;
        private System.Windows.Forms.PictureBox pictureBoxCar;
        private System.Windows.Forms.TabPage tabPageResults;
        private System.Windows.Forms.TextBox textBoxIperfTestLog;
        private System.Windows.Forms.Label labelServerIP;
        private System.Windows.Forms.TextBox textBoxServerIP;
        private System.Windows.Forms.ComboBox comboBoxBandWidth;
        private System.Windows.Forms.Label labelBandWidth;
        private System.Windows.Forms.Label labelIperf3Path;
        private System.Windows.Forms.TextBox textBoxIperf3Path;
        private System.Windows.Forms.Button btnBrowseIperf3;
        private System.Windows.Forms.ProgressBar progressBarTesting;
        private System.Windows.Forms.DataGridView dataGridViewTestResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPointNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnRadius;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnAngle;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnHeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnFrequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnBand;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnChannel;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnTcpUplinkThroughput;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnTcpDownlinkThroughput;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnUdpUplinkThroughput;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnUdpUplinkLatency;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnUdpUplinkPacketLoss;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnUdpDownlinkThroughput;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnUdpDownlinkLatency;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnUdpDownlinkPacketLoss;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnRssi;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnSnr;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnTimeStamp;
        private System.Windows.Forms.TextBox textBoxSgVisaAddress;
        private System.Windows.Forms.Label labelSgVisaAddress;
        private System.Windows.Forms.TextBox textBoxSaVisaAddress;
        private System.Windows.Forms.Label labelSaVisaAddress;
        private System.Windows.Forms.Label labelElapsedTime;
    }
}
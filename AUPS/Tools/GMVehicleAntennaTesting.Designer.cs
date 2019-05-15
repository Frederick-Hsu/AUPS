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
            this.numericUpDownPacketSize = new System.Windows.Forms.NumericUpDown();
            this.labelPacketSize = new System.Windows.Forms.Label();
            this.labelScaleDownRatio = new System.Windows.Forms.Label();
            this.comboBoxScaleDownRatio = new System.Windows.Forms.ComboBox();
            this.comboBoxAntennaPolarization = new System.Windows.Forms.ComboBox();
            this.labelAntennaPolorization = new System.Windows.Forms.Label();
            this.comboBoxChannel = new System.Windows.Forms.ComboBox();
            this.textBoxTxPower = new System.Windows.Forms.TextBox();
            this.labelTxPower = new System.Windows.Forms.Label();
            this.labelElapsedTime = new System.Windows.Forms.Label();
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
            this.groupBoxOption = new System.Windows.Forms.GroupBox();
            this.radioBtnPhyLayerTesting = new System.Windows.Forms.RadioButton();
            this.radioBtnAppLayerTesting = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.dataGridViewPointSettings = new System.Windows.Forms.DataGridView();
            this.colSelectedFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colPointNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRadius = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAngle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPolarization = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFreq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBandwidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChannel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPower = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageIperfLog = new System.Windows.Forms.TabPage();
            this.textBoxIperfTestLog = new System.Windows.Forms.TextBox();
            this.tabPageResults = new System.Windows.Forms.TabPage();
            this.groupBoxRFTesting = new System.Windows.Forms.GroupBox();
            this.btnClearPhysicalTestResultsTable = new System.Windows.Forms.Button();
            this.btnSaveRFTestResults = new System.Windows.Forms.Button();
            this.dataGridViewRFTestResults = new System.Windows.Forms.DataGridView();
            this.colmPointNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colmRadius = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colmAngle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colmHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colmPolarization = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colmFrequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colmBandwidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colmChannel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colmTxPower = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colmRssi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colmTimeStamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxApplicationLayerTesting = new System.Windows.Forms.GroupBox();
            this.dataGridViewTestResults = new System.Windows.Forms.DataGridView();
            this.columnPointNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnRadius = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnAngle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPolarization = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnFrequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnBand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnChannel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTxPower = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnTcpUplinkThroughput = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnTcpDownlinkThroughput = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnUdpUplinkThroughput = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnUdpUplinkLatency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnUdpUplinkPacketLoss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnUdpDownlinkThroughput = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnUdpDownlinkLatency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnUdpDownlinkPacketLoss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnTimeStamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSaveTestResults = new System.Windows.Forms.Button();
            this.btnClearTestResults = new System.Windows.Forms.Button();
            this.labelFilePathToSave = new System.Windows.Forms.Label();
            this.progressBarTesting = new System.Windows.Forms.ProgressBar();
            this.contextMenuStripModify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeCurrentTestPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifySettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxTestPointsSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPacketSize)).BeginInit();
            this.tabControlTesting.SuspendLayout();
            this.tabPageField.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCar)).BeginInit();
            this.groupBoxOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPointSettings)).BeginInit();
            this.tabPageIperfLog.SuspendLayout();
            this.tabPageResults.SuspendLayout();
            this.groupBoxRFTesting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRFTestResults)).BeginInit();
            this.groupBoxApplicationLayerTesting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTestResults)).BeginInit();
            this.contextMenuStripModify.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxTestPointsSetting
            // 
            this.groupBoxTestPointsSetting.AutoSize = true;
            this.groupBoxTestPointsSetting.Controls.Add(this.numericUpDownPacketSize);
            this.groupBoxTestPointsSetting.Controls.Add(this.labelPacketSize);
            this.groupBoxTestPointsSetting.Controls.Add(this.labelScaleDownRatio);
            this.groupBoxTestPointsSetting.Controls.Add(this.comboBoxScaleDownRatio);
            this.groupBoxTestPointsSetting.Controls.Add(this.comboBoxAntennaPolarization);
            this.groupBoxTestPointsSetting.Controls.Add(this.labelAntennaPolorization);
            this.groupBoxTestPointsSetting.Controls.Add(this.comboBoxChannel);
            this.groupBoxTestPointsSetting.Controls.Add(this.textBoxTxPower);
            this.groupBoxTestPointsSetting.Controls.Add(this.labelTxPower);
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
            this.groupBoxTestPointsSetting.Size = new System.Drawing.Size(398, 1318);
            this.groupBoxTestPointsSetting.TabIndex = 1;
            this.groupBoxTestPointsSetting.TabStop = false;
            this.groupBoxTestPointsSetting.Text = "Testing points setting";
            // 
            // numericUpDownPacketSize
            // 
            this.numericUpDownPacketSize.Location = new System.Drawing.Point(267, 1072);
            this.numericUpDownPacketSize.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numericUpDownPacketSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPacketSize.Name = "numericUpDownPacketSize";
            this.numericUpDownPacketSize.Size = new System.Drawing.Size(123, 26);
            this.numericUpDownPacketSize.TabIndex = 30;
            this.numericUpDownPacketSize.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // labelPacketSize
            // 
            this.labelPacketSize.AutoSize = true;
            this.labelPacketSize.Location = new System.Drawing.Point(18, 1072);
            this.labelPacketSize.Name = "labelPacketSize";
            this.labelPacketSize.Size = new System.Drawing.Size(239, 20);
            this.labelPacketSize.TabIndex = 29;
            this.labelPacketSize.Text = "iPerf3 packet size (unit : MBytes)";
            // 
            // labelScaleDownRatio
            // 
            this.labelScaleDownRatio.AutoSize = true;
            this.labelScaleDownRatio.Location = new System.Drawing.Point(15, 1017);
            this.labelScaleDownRatio.Name = "labelScaleDownRatio";
            this.labelScaleDownRatio.Size = new System.Drawing.Size(126, 20);
            this.labelScaleDownRatio.TabIndex = 28;
            this.labelScaleDownRatio.Text = "Scale down ratio";
            // 
            // comboBoxScaleDownRatio
            // 
            this.comboBoxScaleDownRatio.FormattingEnabled = true;
            this.comboBoxScaleDownRatio.Items.AddRange(new object[] {
            "5",
            "10",
            "20",
            "40",
            "50",
            "80",
            "100",
            "200",
            "500"});
            this.comboBoxScaleDownRatio.Location = new System.Drawing.Point(159, 1014);
            this.comboBoxScaleDownRatio.Name = "comboBoxScaleDownRatio";
            this.comboBoxScaleDownRatio.Size = new System.Drawing.Size(230, 28);
            this.comboBoxScaleDownRatio.TabIndex = 27;
            // 
            // comboBoxAntennaPolarization
            // 
            this.comboBoxAntennaPolarization.FormattingEnabled = true;
            this.comboBoxAntennaPolarization.Items.AddRange(new object[] {
            "Horizontal",
            "Vertical"});
            this.comboBoxAntennaPolarization.Location = new System.Drawing.Point(202, 183);
            this.comboBoxAntennaPolarization.Name = "comboBoxAntennaPolarization";
            this.comboBoxAntennaPolarization.Size = new System.Drawing.Size(187, 28);
            this.comboBoxAntennaPolarization.TabIndex = 26;
            // 
            // labelAntennaPolorization
            // 
            this.labelAntennaPolorization.AutoSize = true;
            this.labelAntennaPolorization.Location = new System.Drawing.Point(15, 183);
            this.labelAntennaPolorization.Name = "labelAntennaPolorization";
            this.labelAntennaPolorization.Size = new System.Drawing.Size(155, 20);
            this.labelAntennaPolorization.TabIndex = 25;
            this.labelAntennaPolorization.Text = "Antenna polarization";
            // 
            // comboBoxChannel
            // 
            this.comboBoxChannel.FormattingEnabled = true;
            this.comboBoxChannel.Location = new System.Drawing.Point(202, 231);
            this.comboBoxChannel.Name = "comboBoxChannel";
            this.comboBoxChannel.Size = new System.Drawing.Size(188, 28);
            this.comboBoxChannel.TabIndex = 24;
            this.comboBoxChannel.SelectedIndexChanged += new System.EventHandler(this.comboBoxChannel_SelectedIndexChanged);
            // 
            // textBoxTxPower
            // 
            this.textBoxTxPower.Location = new System.Drawing.Point(202, 383);
            this.textBoxTxPower.Name = "textBoxTxPower";
            this.textBoxTxPower.Size = new System.Drawing.Size(188, 26);
            this.textBoxTxPower.TabIndex = 23;
            // 
            // labelTxPower
            // 
            this.labelTxPower.AutoSize = true;
            this.labelTxPower.Location = new System.Drawing.Point(20, 383);
            this.labelTxPower.Name = "labelTxPower";
            this.labelTxPower.Size = new System.Drawing.Size(157, 20);
            this.labelTxPower.TabIndex = 22;
            this.labelTxPower.Text = "Tx power (unit : dBm)";
            // 
            // labelElapsedTime
            // 
            this.labelElapsedTime.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelElapsedTime.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelElapsedTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.labelElapsedTime.Location = new System.Drawing.Point(3, 1292);
            this.labelElapsedTime.Name = "labelElapsedTime";
            this.labelElapsedTime.Size = new System.Drawing.Size(392, 23);
            this.labelElapsedTime.TabIndex = 7;
            this.labelElapsedTime.Text = "Elapsed time : 00:00:00.000";
            // 
            // textBoxSaVisaAddress
            // 
            this.textBoxSaVisaAddress.Location = new System.Drawing.Point(20, 937);
            this.textBoxSaVisaAddress.Name = "textBoxSaVisaAddress";
            this.textBoxSaVisaAddress.Size = new System.Drawing.Size(372, 26);
            this.textBoxSaVisaAddress.TabIndex = 21;
            // 
            // labelSaVisaAddress
            // 
            this.labelSaVisaAddress.AutoSize = true;
            this.labelSaVisaAddress.Location = new System.Drawing.Point(15, 894);
            this.labelSaVisaAddress.Name = "labelSaVisaAddress";
            this.labelSaVisaAddress.Size = new System.Drawing.Size(231, 20);
            this.labelSaVisaAddress.TabIndex = 20;
            this.labelSaVisaAddress.Text = "Signal analyzer VISA address : ";
            // 
            // textBoxSgVisaAddress
            // 
            this.textBoxSgVisaAddress.Location = new System.Drawing.Point(20, 831);
            this.textBoxSgVisaAddress.Name = "textBoxSgVisaAddress";
            this.textBoxSgVisaAddress.Size = new System.Drawing.Size(372, 26);
            this.textBoxSgVisaAddress.TabIndex = 19;
            // 
            // labelSgVisaAddress
            // 
            this.labelSgVisaAddress.AutoSize = true;
            this.labelSgVisaAddress.Location = new System.Drawing.Point(15, 797);
            this.labelSgVisaAddress.Name = "labelSgVisaAddress";
            this.labelSgVisaAddress.Size = new System.Drawing.Size(241, 20);
            this.labelSgVisaAddress.TabIndex = 18;
            this.labelSgVisaAddress.Text = "Signal generator VISA address : ";
            // 
            // btnBrowseIperf3
            // 
            this.btnBrowseIperf3.Location = new System.Drawing.Point(202, 668);
            this.btnBrowseIperf3.Name = "btnBrowseIperf3";
            this.btnBrowseIperf3.Size = new System.Drawing.Size(188, 37);
            this.btnBrowseIperf3.TabIndex = 17;
            this.btnBrowseIperf3.Text = "Browse iPerf3.exe";
            this.btnBrowseIperf3.UseVisualStyleBackColor = true;
            this.btnBrowseIperf3.Click += new System.EventHandler(this.btnBrowseIperf3_Click);
            // 
            // textBoxIperf3Path
            // 
            this.textBoxIperf3Path.Location = new System.Drawing.Point(20, 723);
            this.textBoxIperf3Path.Name = "textBoxIperf3Path";
            this.textBoxIperf3Path.Size = new System.Drawing.Size(372, 26);
            this.textBoxIperf3Path.TabIndex = 16;
            // 
            // labelIperf3Path
            // 
            this.labelIperf3Path.AutoSize = true;
            this.labelIperf3Path.Location = new System.Drawing.Point(20, 672);
            this.labelIperf3Path.Name = "labelIperf3Path";
            this.labelIperf3Path.Size = new System.Drawing.Size(86, 20);
            this.labelIperf3Path.TabIndex = 15;
            this.labelIperf3Path.Text = "iPerf3 path";
            // 
            // comboBoxBandWidth
            // 
            this.comboBoxBandWidth.FormattingEnabled = true;
            this.comboBoxBandWidth.Items.AddRange(new object[] {
            "10",
            "20",
            "22",
            "40",
            "80",
            "160"});
            this.comboBoxBandWidth.Location = new System.Drawing.Point(202, 329);
            this.comboBoxBandWidth.Name = "comboBoxBandWidth";
            this.comboBoxBandWidth.Size = new System.Drawing.Size(188, 28);
            this.comboBoxBandWidth.TabIndex = 14;
            // 
            // labelBandWidth
            // 
            this.labelBandWidth.AutoSize = true;
            this.labelBandWidth.Location = new System.Drawing.Point(20, 329);
            this.labelBandWidth.Name = "labelBandWidth";
            this.labelBandWidth.Size = new System.Drawing.Size(173, 20);
            this.labelBandWidth.TabIndex = 13;
            this.labelBandWidth.Text = "Band width (unit : MHz)";
            // 
            // textBoxServerIP
            // 
            this.textBoxServerIP.Location = new System.Drawing.Point(202, 603);
            this.textBoxServerIP.Name = "textBoxServerIP";
            this.textBoxServerIP.Size = new System.Drawing.Size(188, 26);
            this.textBoxServerIP.TabIndex = 12;
            // 
            // labelServerIP
            // 
            this.labelServerIP.AutoSize = true;
            this.labelServerIP.Location = new System.Drawing.Point(15, 603);
            this.labelServerIP.Name = "labelServerIP";
            this.labelServerIP.Size = new System.Drawing.Size(135, 20);
            this.labelServerIP.TabIndex = 11;
            this.labelServerIP.Text = "Server IP address";
            // 
            // btnRefreshDrawing
            // 
            this.btnRefreshDrawing.Location = new System.Drawing.Point(20, 505);
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
            this.labelChannel.Location = new System.Drawing.Point(15, 231);
            this.labelChannel.Name = "labelChannel";
            this.labelChannel.Size = new System.Drawing.Size(108, 20);
            this.labelChannel.TabIndex = 9;
            this.labelChannel.Text = "Wi-Fi Channel";
            // 
            // textBoxFreqBand
            // 
            this.textBoxFreqBand.Location = new System.Drawing.Point(202, 280);
            this.textBoxFreqBand.Name = "textBoxFreqBand";
            this.textBoxFreqBand.Size = new System.Drawing.Size(188, 26);
            this.textBoxFreqBand.TabIndex = 8;
            // 
            // labelFreqBand
            // 
            this.labelFreqBand.AutoSize = true;
            this.labelFreqBand.Location = new System.Drawing.Point(15, 280);
            this.labelFreqBand.Name = "labelFreqBand";
            this.labelFreqBand.Size = new System.Drawing.Size(169, 20);
            this.labelFreqBand.TabIndex = 7;
            this.labelFreqBand.Text = "Frequency (unit : MHz)";
            // 
            // btnNewPoint
            // 
            this.btnNewPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNewPoint.Location = new System.Drawing.Point(20, 422);
            this.btnNewPoint.Name = "btnNewPoint";
            this.btnNewPoint.Size = new System.Drawing.Size(372, 52);
            this.btnNewPoint.TabIndex = 6;
            this.btnNewPoint.Text = "New Testing Point";
            this.btnNewPoint.UseVisualStyleBackColor = true;
            this.btnNewPoint.Click += new System.EventHandler(this.btnNewPoint_Click);
            // 
            // textBoxHeight
            // 
            this.textBoxHeight.Location = new System.Drawing.Point(202, 138);
            this.textBoxHeight.Name = "textBoxHeight";
            this.textBoxHeight.Size = new System.Drawing.Size(188, 26);
            this.textBoxHeight.TabIndex = 5;
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Location = new System.Drawing.Point(15, 138);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(134, 20);
            this.labelHeight.TabIndex = 4;
            this.labelHeight.Text = "Height (unit : mm)";
            // 
            // textBoxAngle
            // 
            this.textBoxAngle.Location = new System.Drawing.Point(202, 89);
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
            this.textBoxRadius.Location = new System.Drawing.Point(202, 37);
            this.textBoxRadius.Name = "textBoxRadius";
            this.textBoxRadius.Size = new System.Drawing.Size(188, 26);
            this.textBoxRadius.TabIndex = 1;
            // 
            // labelRadius
            // 
            this.labelRadius.AutoSize = true;
            this.labelRadius.Location = new System.Drawing.Point(18, 37);
            this.labelRadius.Name = "labelRadius";
            this.labelRadius.Size = new System.Drawing.Size(137, 20);
            this.labelRadius.TabIndex = 0;
            this.labelRadius.Text = "Radius (unit : mm)";
            // 
            // tabControlTesting
            // 
            this.tabControlTesting.Controls.Add(this.tabPageField);
            this.tabControlTesting.Controls.Add(this.tabPageIperfLog);
            this.tabControlTesting.Controls.Add(this.tabPageResults);
            this.tabControlTesting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlTesting.Location = new System.Drawing.Point(398, 0);
            this.tabControlTesting.Name = "tabControlTesting";
            this.tabControlTesting.SelectedIndex = 0;
            this.tabControlTesting.Size = new System.Drawing.Size(1580, 1318);
            this.tabControlTesting.TabIndex = 5;
            this.tabControlTesting.Resize += new System.EventHandler(this.tabControlTesting_Resize);
            // 
            // tabPageField
            // 
            this.tabPageField.AutoScroll = true;
            this.tabPageField.Controls.Add(this.pictureBoxCar);
            this.tabPageField.Controls.Add(this.groupBoxOption);
            this.tabPageField.Controls.Add(this.btnSave);
            this.tabPageField.Controls.Add(this.btnLoad);
            this.tabPageField.Controls.Add(this.dataGridViewPointSettings);
            this.tabPageField.Location = new System.Drawing.Point(4, 29);
            this.tabPageField.Name = "tabPageField";
            this.tabPageField.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPageField.Size = new System.Drawing.Size(1572, 1285);
            this.tabPageField.TabIndex = 0;
            this.tabPageField.Text = "Test field";
            this.tabPageField.UseVisualStyleBackColor = true;
            // 
            // pictureBoxCar
            // 
            this.pictureBoxCar.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxCar.Image")));
            this.pictureBoxCar.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxCar.InitialImage")));
            this.pictureBoxCar.Location = new System.Drawing.Point(574, 512);
            this.pictureBoxCar.Name = "pictureBoxCar";
            this.pictureBoxCar.Size = new System.Drawing.Size(44, 97);
            this.pictureBoxCar.TabIndex = 5;
            this.pictureBoxCar.TabStop = false;
            // 
            // groupBoxOption
            // 
            this.groupBoxOption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxOption.Controls.Add(this.radioBtnPhyLayerTesting);
            this.groupBoxOption.Controls.Add(this.radioBtnAppLayerTesting);
            this.groupBoxOption.Location = new System.Drawing.Point(1270, 9);
            this.groupBoxOption.Name = "groupBoxOption";
            this.groupBoxOption.Size = new System.Drawing.Size(292, 129);
            this.groupBoxOption.TabIndex = 4;
            this.groupBoxOption.TabStop = false;
            this.groupBoxOption.Text = "Select test section";
            // 
            // radioBtnPhyLayerTesting
            // 
            this.radioBtnPhyLayerTesting.AutoSize = true;
            this.radioBtnPhyLayerTesting.Location = new System.Drawing.Point(6, 86);
            this.radioBtnPhyLayerTesting.Name = "radioBtnPhyLayerTesting";
            this.radioBtnPhyLayerTesting.Size = new System.Drawing.Size(279, 24);
            this.radioBtnPhyLayerTesting.TabIndex = 1;
            this.radioBtnPhyLayerTesting.Text = "RF / Physical Layer Testing section";
            this.radioBtnPhyLayerTesting.UseVisualStyleBackColor = true;
            // 
            // radioBtnAppLayerTesting
            // 
            this.radioBtnAppLayerTesting.AutoSize = true;
            this.radioBtnAppLayerTesting.Checked = true;
            this.radioBtnAppLayerTesting.Location = new System.Drawing.Point(6, 40);
            this.radioBtnAppLayerTesting.Name = "radioBtnAppLayerTesting";
            this.radioBtnAppLayerTesting.Size = new System.Drawing.Size(266, 24);
            this.radioBtnAppLayerTesting.TabIndex = 0;
            this.radioBtnAppLayerTesting.TabStop = true;
            this.radioBtnAppLayerTesting.Text = "Application Layer Testing section";
            this.radioBtnAppLayerTesting.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(350, 312);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(284, 40);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save test points setting table";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(6, 312);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(284, 32);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load test points setting table";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // dataGridViewPointSettings
            // 
            this.dataGridViewPointSettings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPointSettings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelectedFlag,
            this.colPointNo,
            this.colRadius,
            this.colAngle,
            this.colHeight,
            this.colPolarization,
            this.colFreq,
            this.colBandwidth,
            this.colChannel,
            this.colPower});
            this.dataGridViewPointSettings.Location = new System.Drawing.Point(6, 8);
            this.dataGridViewPointSettings.Name = "dataGridViewPointSettings";
            this.dataGridViewPointSettings.RowTemplate.Height = 28;
            this.dataGridViewPointSettings.Size = new System.Drawing.Size(626, 297);
            this.dataGridViewPointSettings.TabIndex = 1;
            // 
            // colSelectedFlag
            // 
            this.colSelectedFlag.HeaderText = "Selected";
            this.colSelectedFlag.Name = "colSelectedFlag";
            this.colSelectedFlag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colSelectedFlag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colPointNo
            // 
            this.colPointNo.HeaderText = "Point No.";
            this.colPointNo.Name = "colPointNo";
            this.colPointNo.ReadOnly = true;
            // 
            // colRadius
            // 
            this.colRadius.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colRadius.HeaderText = "Radius";
            this.colRadius.Name = "colRadius";
            this.colRadius.ReadOnly = true;
            this.colRadius.Width = 95;
            // 
            // colAngle
            // 
            this.colAngle.HeaderText = "Angle";
            this.colAngle.Name = "colAngle";
            this.colAngle.ReadOnly = true;
            // 
            // colHeight
            // 
            this.colHeight.HeaderText = "Height";
            this.colHeight.Name = "colHeight";
            // 
            // colPolarization
            // 
            this.colPolarization.HeaderText = "Antenna Polarization";
            this.colPolarization.Name = "colPolarization";
            // 
            // colFreq
            // 
            this.colFreq.HeaderText = "Freq.";
            this.colFreq.Name = "colFreq";
            // 
            // colBandwidth
            // 
            this.colBandwidth.HeaderText = "Bandwidth";
            this.colBandwidth.Name = "colBandwidth";
            // 
            // colChannel
            // 
            this.colChannel.HeaderText = "Channel";
            this.colChannel.Name = "colChannel";
            // 
            // colPower
            // 
            this.colPower.HeaderText = "Power";
            this.colPower.Name = "colPower";
            // 
            // tabPageIperfLog
            // 
            this.tabPageIperfLog.Controls.Add(this.textBoxIperfTestLog);
            this.tabPageIperfLog.Location = new System.Drawing.Point(4, 29);
            this.tabPageIperfLog.Name = "tabPageIperfLog";
            this.tabPageIperfLog.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPageIperfLog.Size = new System.Drawing.Size(1572, 1285);
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
            this.textBoxIperfTestLog.Size = new System.Drawing.Size(1566, 1279);
            this.textBoxIperfTestLog.TabIndex = 0;
            this.textBoxIperfTestLog.WordWrap = false;
            // 
            // tabPageResults
            // 
            this.tabPageResults.Controls.Add(this.groupBoxRFTesting);
            this.tabPageResults.Controls.Add(this.groupBoxApplicationLayerTesting);
            this.tabPageResults.Controls.Add(this.labelFilePathToSave);
            this.tabPageResults.Location = new System.Drawing.Point(4, 29);
            this.tabPageResults.Name = "tabPageResults";
            this.tabPageResults.Size = new System.Drawing.Size(1572, 1285);
            this.tabPageResults.TabIndex = 2;
            this.tabPageResults.Text = "Test results";
            this.tabPageResults.UseVisualStyleBackColor = true;
            // 
            // groupBoxRFTesting
            // 
            this.groupBoxRFTesting.Controls.Add(this.btnClearPhysicalTestResultsTable);
            this.groupBoxRFTesting.Controls.Add(this.btnSaveRFTestResults);
            this.groupBoxRFTesting.Controls.Add(this.dataGridViewRFTestResults);
            this.groupBoxRFTesting.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBoxRFTesting.Location = new System.Drawing.Point(0, 637);
            this.groupBoxRFTesting.Name = "groupBoxRFTesting";
            this.groupBoxRFTesting.Size = new System.Drawing.Size(1572, 648);
            this.groupBoxRFTesting.TabIndex = 8;
            this.groupBoxRFTesting.TabStop = false;
            this.groupBoxRFTesting.Text = "Test results for RF / Physical Layer Testing";
            // 
            // btnClearPhysicalTestResultsTable
            // 
            this.btnClearPhysicalTestResultsTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearPhysicalTestResultsTable.Location = new System.Drawing.Point(1162, 580);
            this.btnClearPhysicalTestResultsTable.Name = "btnClearPhysicalTestResultsTable";
            this.btnClearPhysicalTestResultsTable.Size = new System.Drawing.Size(94, 40);
            this.btnClearPhysicalTestResultsTable.TabIndex = 5;
            this.btnClearPhysicalTestResultsTable.Text = "Clear";
            this.btnClearPhysicalTestResultsTable.UseVisualStyleBackColor = true;
            this.btnClearPhysicalTestResultsTable.Click += new System.EventHandler(this.btnClearPhysicalTestResultsTable_Click);
            // 
            // btnSaveRFTestResults
            // 
            this.btnSaveRFTestResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveRFTestResults.Location = new System.Drawing.Point(1292, 580);
            this.btnSaveRFTestResults.Name = "btnSaveRFTestResults";
            this.btnSaveRFTestResults.Size = new System.Drawing.Size(273, 40);
            this.btnSaveRFTestResults.TabIndex = 6;
            this.btnSaveRFTestResults.Text = "Save RF/Physical layer test results";
            this.btnSaveRFTestResults.UseVisualStyleBackColor = true;
            this.btnSaveRFTestResults.Click += new System.EventHandler(this.btnSaveRFTestResults_Click);
            // 
            // dataGridViewRFTestResults
            // 
            this.dataGridViewRFTestResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRFTestResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colmPointNo,
            this.colmRadius,
            this.colmAngle,
            this.colmHeight,
            this.colmPolarization,
            this.colmFrequency,
            this.colmBandwidth,
            this.colmChannel,
            this.colmTxPower,
            this.colmRssi,
            this.colmTimeStamp});
            this.dataGridViewRFTestResults.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewRFTestResults.Location = new System.Drawing.Point(3, 22);
            this.dataGridViewRFTestResults.Name = "dataGridViewRFTestResults";
            this.dataGridViewRFTestResults.RowTemplate.Height = 28;
            this.dataGridViewRFTestResults.Size = new System.Drawing.Size(1566, 552);
            this.dataGridViewRFTestResults.TabIndex = 4;
            // 
            // colmPointNo
            // 
            this.colmPointNo.HeaderText = "Point #";
            this.colmPointNo.Name = "colmPointNo";
            // 
            // colmRadius
            // 
            this.colmRadius.HeaderText = "Radius (unit : mm)";
            this.colmRadius.Name = "colmRadius";
            // 
            // colmAngle
            // 
            this.colmAngle.HeaderText = "Angle (unit : degree)";
            this.colmAngle.Name = "colmAngle";
            // 
            // colmHeight
            // 
            this.colmHeight.HeaderText = "Height (unit : mm)";
            this.colmHeight.Name = "colmHeight";
            // 
            // colmPolarization
            // 
            this.colmPolarization.HeaderText = "Antenna polarization";
            this.colmPolarization.Name = "colmPolarization";
            // 
            // colmFrequency
            // 
            this.colmFrequency.HeaderText = "Frequency (unit : MHz)";
            this.colmFrequency.Name = "colmFrequency";
            // 
            // colmBandwidth
            // 
            this.colmBandwidth.HeaderText = "Bandwidth (unit : MHz)";
            this.colmBandwidth.Name = "colmBandwidth";
            // 
            // colmChannel
            // 
            this.colmChannel.HeaderText = "Channel";
            this.colmChannel.Name = "colmChannel";
            // 
            // colmTxPower
            // 
            this.colmTxPower.HeaderText = "Tx Power (unit : dBm)";
            this.colmTxPower.Name = "colmTxPower";
            // 
            // colmRssi
            // 
            this.colmRssi.HeaderText = "RSSI (unit : dBm)";
            this.colmRssi.Name = "colmRssi";
            // 
            // colmTimeStamp
            // 
            this.colmTimeStamp.HeaderText = "Time stamp";
            this.colmTimeStamp.Name = "colmTimeStamp";
            // 
            // groupBoxApplicationLayerTesting
            // 
            this.groupBoxApplicationLayerTesting.Controls.Add(this.dataGridViewTestResults);
            this.groupBoxApplicationLayerTesting.Controls.Add(this.btnSaveTestResults);
            this.groupBoxApplicationLayerTesting.Controls.Add(this.btnClearTestResults);
            this.groupBoxApplicationLayerTesting.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxApplicationLayerTesting.Location = new System.Drawing.Point(0, 0);
            this.groupBoxApplicationLayerTesting.Name = "groupBoxApplicationLayerTesting";
            this.groupBoxApplicationLayerTesting.Size = new System.Drawing.Size(1572, 600);
            this.groupBoxApplicationLayerTesting.TabIndex = 7;
            this.groupBoxApplicationLayerTesting.TabStop = false;
            this.groupBoxApplicationLayerTesting.Text = "Test results for Application Layer Testing";
            // 
            // dataGridViewTestResults
            // 
            this.dataGridViewTestResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTestResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnPointNo,
            this.columnRadius,
            this.columnAngle,
            this.columnHeight,
            this.columnPolarization,
            this.columnFrequency,
            this.columnBand,
            this.columnChannel,
            this.colTxPower,
            this.columnTcpUplinkThroughput,
            this.columnTcpDownlinkThroughput,
            this.columnUdpUplinkThroughput,
            this.columnUdpUplinkLatency,
            this.columnUdpUplinkPacketLoss,
            this.columnUdpDownlinkThroughput,
            this.columnUdpDownlinkLatency,
            this.columnUdpDownlinkPacketLoss,
            this.columnTimeStamp});
            this.dataGridViewTestResults.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewTestResults.Location = new System.Drawing.Point(3, 22);
            this.dataGridViewTestResults.Name = "dataGridViewTestResults";
            this.dataGridViewTestResults.ReadOnly = true;
            this.dataGridViewTestResults.RowTemplate.Height = 28;
            this.dataGridViewTestResults.Size = new System.Drawing.Size(1566, 525);
            this.dataGridViewTestResults.TabIndex = 0;
            // 
            // columnPointNo
            // 
            this.columnPointNo.HeaderText = "Point #";
            this.columnPointNo.Name = "columnPointNo";
            this.columnPointNo.ReadOnly = true;
            // 
            // columnRadius
            // 
            this.columnRadius.HeaderText = "Radius (unit : mm)";
            this.columnRadius.Name = "columnRadius";
            this.columnRadius.ReadOnly = true;
            // 
            // columnAngle
            // 
            this.columnAngle.HeaderText = "Angle (unit : degree)";
            this.columnAngle.Name = "columnAngle";
            this.columnAngle.ReadOnly = true;
            // 
            // columnHeight
            // 
            this.columnHeight.HeaderText = "Height (unit : mm)";
            this.columnHeight.Name = "columnHeight";
            this.columnHeight.ReadOnly = true;
            // 
            // columnPolarization
            // 
            this.columnPolarization.HeaderText = "Antenna polarization";
            this.columnPolarization.Name = "columnPolarization";
            this.columnPolarization.ReadOnly = true;
            // 
            // columnFrequency
            // 
            this.columnFrequency.HeaderText = "Frequency (unit : MHz)";
            this.columnFrequency.Name = "columnFrequency";
            this.columnFrequency.ReadOnly = true;
            // 
            // columnBand
            // 
            this.columnBand.HeaderText = "Bandwidth (unit : MHz)";
            this.columnBand.Name = "columnBand";
            this.columnBand.ReadOnly = true;
            // 
            // columnChannel
            // 
            this.columnChannel.HeaderText = "Channel";
            this.columnChannel.Name = "columnChannel";
            this.columnChannel.ReadOnly = true;
            // 
            // colTxPower
            // 
            this.colTxPower.HeaderText = "Tx Power (unit : dBm)";
            this.colTxPower.Name = "colTxPower";
            this.colTxPower.ReadOnly = true;
            // 
            // columnTcpUplinkThroughput
            // 
            this.columnTcpUplinkThroughput.HeaderText = "TCP uplink throughput (unit : Mbits/sec)";
            this.columnTcpUplinkThroughput.Name = "columnTcpUplinkThroughput";
            this.columnTcpUplinkThroughput.ReadOnly = true;
            // 
            // columnTcpDownlinkThroughput
            // 
            this.columnTcpDownlinkThroughput.HeaderText = "TCP downlink throughput (unit : Mbits/sec)";
            this.columnTcpDownlinkThroughput.Name = "columnTcpDownlinkThroughput";
            this.columnTcpDownlinkThroughput.ReadOnly = true;
            // 
            // columnUdpUplinkThroughput
            // 
            this.columnUdpUplinkThroughput.HeaderText = "UDP uplink throughput (unit : Mbits/sec)";
            this.columnUdpUplinkThroughput.Name = "columnUdpUplinkThroughput";
            this.columnUdpUplinkThroughput.ReadOnly = true;
            // 
            // columnUdpUplinkLatency
            // 
            this.columnUdpUplinkLatency.HeaderText = "UDP uplink latency (unit : ms)";
            this.columnUdpUplinkLatency.Name = "columnUdpUplinkLatency";
            this.columnUdpUplinkLatency.ReadOnly = true;
            // 
            // columnUdpUplinkPacketLoss
            // 
            this.columnUdpUplinkPacketLoss.HeaderText = "UDP uplink packet loss";
            this.columnUdpUplinkPacketLoss.Name = "columnUdpUplinkPacketLoss";
            this.columnUdpUplinkPacketLoss.ReadOnly = true;
            // 
            // columnUdpDownlinkThroughput
            // 
            this.columnUdpDownlinkThroughput.HeaderText = "UDP downlink throughput (unit : Mbits/sec)";
            this.columnUdpDownlinkThroughput.Name = "columnUdpDownlinkThroughput";
            this.columnUdpDownlinkThroughput.ReadOnly = true;
            // 
            // columnUdpDownlinkLatency
            // 
            this.columnUdpDownlinkLatency.HeaderText = "UDP downlink latency (unit : ms)";
            this.columnUdpDownlinkLatency.Name = "columnUdpDownlinkLatency";
            this.columnUdpDownlinkLatency.ReadOnly = true;
            // 
            // columnUdpDownlinkPacketLoss
            // 
            this.columnUdpDownlinkPacketLoss.HeaderText = "UDP downlink packet loss";
            this.columnUdpDownlinkPacketLoss.Name = "columnUdpDownlinkPacketLoss";
            this.columnUdpDownlinkPacketLoss.ReadOnly = true;
            // 
            // columnTimeStamp
            // 
            this.columnTimeStamp.HeaderText = "Time stamp";
            this.columnTimeStamp.Name = "columnTimeStamp";
            this.columnTimeStamp.ReadOnly = true;
            // 
            // btnSaveTestResults
            // 
            this.btnSaveTestResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveTestResults.Location = new System.Drawing.Point(1292, 552);
            this.btnSaveTestResults.Name = "btnSaveTestResults";
            this.btnSaveTestResults.Size = new System.Drawing.Size(273, 40);
            this.btnSaveTestResults.TabIndex = 1;
            this.btnSaveTestResults.Text = "Save application layer test results";
            this.btnSaveTestResults.UseVisualStyleBackColor = true;
            this.btnSaveTestResults.Click += new System.EventHandler(this.btnSaveTestResults_Click);
            // 
            // btnClearTestResults
            // 
            this.btnClearTestResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearTestResults.Location = new System.Drawing.Point(1162, 552);
            this.btnClearTestResults.Name = "btnClearTestResults";
            this.btnClearTestResults.Size = new System.Drawing.Size(94, 40);
            this.btnClearTestResults.TabIndex = 2;
            this.btnClearTestResults.Text = "Clear";
            this.btnClearTestResults.UseVisualStyleBackColor = true;
            this.btnClearTestResults.Click += new System.EventHandler(this.btnClearTestResults_Click);
            // 
            // labelFilePathToSave
            // 
            this.labelFilePathToSave.AutoSize = true;
            this.labelFilePathToSave.Location = new System.Drawing.Point(1173, 572);
            this.labelFilePathToSave.Name = "labelFilePathToSave";
            this.labelFilePathToSave.Size = new System.Drawing.Size(0, 20);
            this.labelFilePathToSave.TabIndex = 3;
            // 
            // progressBarTesting
            // 
            this.progressBarTesting.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBarTesting.Location = new System.Drawing.Point(398, 1292);
            this.progressBarTesting.Name = "progressBarTesting";
            this.progressBarTesting.Size = new System.Drawing.Size(1580, 26);
            this.progressBarTesting.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarTesting.TabIndex = 6;
            // 
            // contextMenuStripModify
            // 
            this.contextMenuStripModify.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripModify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeCurrentTestPointToolStripMenuItem,
            this.modifySettingsToolStripMenuItem});
            this.contextMenuStripModify.Name = "contextMenuStripModify";
            this.contextMenuStripModify.Size = new System.Drawing.Size(290, 64);
            // 
            // removeCurrentTestPointToolStripMenuItem
            // 
            this.removeCurrentTestPointToolStripMenuItem.Name = "removeCurrentTestPointToolStripMenuItem";
            this.removeCurrentTestPointToolStripMenuItem.Size = new System.Drawing.Size(289, 30);
            this.removeCurrentTestPointToolStripMenuItem.Text = "Remove current test point";
            // 
            // modifySettingsToolStripMenuItem
            // 
            this.modifySettingsToolStripMenuItem.Name = "modifySettingsToolStripMenuItem";
            this.modifySettingsToolStripMenuItem.Size = new System.Drawing.Size(289, 30);
            this.modifySettingsToolStripMenuItem.Text = "Modify settings";
            this.modifySettingsToolStripMenuItem.Click += new System.EventHandler(this.modifySettingsToolStripMenuItem_Click);
            // 
            // GMVehicleAntennaTesting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1978, 1318);
            this.Controls.Add(this.progressBarTesting);
            this.Controls.Add(this.tabControlTesting);
            this.Controls.Add(this.groupBoxTestPointsSetting);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GMVehicleAntennaTesting";
            this.Text = "GM vehicle Wi-Fi antenna testing";
            this.Load += new System.EventHandler(this.GMVehicleAntennaTesting_Load);
            this.groupBoxTestPointsSetting.ResumeLayout(false);
            this.groupBoxTestPointsSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPacketSize)).EndInit();
            this.tabControlTesting.ResumeLayout(false);
            this.tabPageField.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCar)).EndInit();
            this.groupBoxOption.ResumeLayout(false);
            this.groupBoxOption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPointSettings)).EndInit();
            this.tabPageIperfLog.ResumeLayout(false);
            this.tabPageIperfLog.PerformLayout();
            this.tabPageResults.ResumeLayout(false);
            this.tabPageResults.PerformLayout();
            this.groupBoxRFTesting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRFTestResults)).EndInit();
            this.groupBoxApplicationLayerTesting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTestResults)).EndInit();
            this.contextMenuStripModify.ResumeLayout(false);
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
        private System.Windows.Forms.Label labelChannel;
        private System.Windows.Forms.Button btnRefreshDrawing;
        private System.Windows.Forms.TabControl tabControlTesting;
        private System.Windows.Forms.TabPage tabPageField;
        private System.Windows.Forms.TabPage tabPageIperfLog;
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
        private System.Windows.Forms.TextBox textBoxSgVisaAddress;
        private System.Windows.Forms.Label labelSgVisaAddress;
        private System.Windows.Forms.TextBox textBoxSaVisaAddress;
        private System.Windows.Forms.Label labelSaVisaAddress;
        private System.Windows.Forms.Label labelElapsedTime;
        private System.Windows.Forms.Button btnSaveTestResults;
        private System.Windows.Forms.Button btnClearTestResults;
        private System.Windows.Forms.Label labelFilePathToSave;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripModify;
        private System.Windows.Forms.ToolStripMenuItem removeCurrentTestPointToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifySettingsToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewPointSettings;
        private System.Windows.Forms.Label labelTxPower;
        private System.Windows.Forms.TextBox textBoxTxPower;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox comboBoxChannel;
        private System.Windows.Forms.GroupBox groupBoxOption;
        private System.Windows.Forms.RadioButton radioBtnAppLayerTesting;
        private System.Windows.Forms.RadioButton radioBtnPhyLayerTesting;
        private System.Windows.Forms.DataGridView dataGridViewRFTestResults;
        private System.Windows.Forms.Button btnSaveRFTestResults;
        private System.Windows.Forms.Button btnClearPhysicalTestResultsTable;
        private System.Windows.Forms.GroupBox groupBoxApplicationLayerTesting;
        private System.Windows.Forms.GroupBox groupBoxRFTesting;
        private System.Windows.Forms.PictureBox pictureBoxCar;
        private System.Windows.Forms.Label labelAntennaPolorization;
        private System.Windows.Forms.ComboBox comboBoxAntennaPolarization;
        private System.Windows.Forms.DataGridViewTextBoxColumn colmPointNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colmRadius;
        private System.Windows.Forms.DataGridViewTextBoxColumn colmAngle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colmHeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colmPolarization;
        private System.Windows.Forms.DataGridViewTextBoxColumn colmFrequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn colmBandwidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn colmChannel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colmTxPower;
        private System.Windows.Forms.DataGridViewTextBoxColumn colmRssi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colmTimeStamp;
        private System.Windows.Forms.Label labelScaleDownRatio;
        private System.Windows.Forms.ComboBox comboBoxScaleDownRatio;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPointNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnRadius;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnAngle;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnHeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPolarization;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnFrequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnBand;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnChannel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTxPower;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnTcpUplinkThroughput;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnTcpDownlinkThroughput;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnUdpUplinkThroughput;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnUdpUplinkLatency;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnUdpUplinkPacketLoss;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnUdpDownlinkThroughput;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnUdpDownlinkLatency;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnUdpDownlinkPacketLoss;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnTimeStamp;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelectedFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPointNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRadius;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAngle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPolarization;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFreq;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBandwidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChannel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPower;
        private System.Windows.Forms.NumericUpDown numericUpDownPacketSize;
        private System.Windows.Forms.Label labelPacketSize;
    }
}
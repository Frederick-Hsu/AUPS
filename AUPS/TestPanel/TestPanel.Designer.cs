namespace Amphenol.AUPS
{
    partial class TestPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestPanel));
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Open COM port");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Coomunicate with DMM");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Configure network");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Initialization", new System.Windows.Forms.TreeNode[] {
            treeNode15,
            treeNode16,
            treeNode17});
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Measure VDD");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Measure Vref");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Voltage measurement", new System.Windows.Forms.TreeNode[] {
            treeNode19,
            treeNode20});
            this.cellToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnOpenSequence = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnSettings = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripComboBoxManualAuto = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabelSequenceFile = new System.Windows.Forms.ToolStripLabel();
            this.cellStatusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelBasic = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelItemInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelElapsedTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControlTestStation = new System.Windows.Forms.TabControl();
            this.tabPageHome = new System.Windows.Forms.TabPage();
            this.listViewTestItems = new System.Windows.Forms.ListView();
            this.columnHeaderSeqNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTestItem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderConclusion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBoxStartEnd = new System.Windows.Forms.GroupBox();
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.textBoxSerialNum = new System.Windows.Forms.TextBox();
            this.labelSerialNum = new System.Windows.Forms.Label();
            this.progressBarTestProgress = new System.Windows.Forms.ProgressBar();
            this.labelIndicator = new System.Windows.Forms.Label();
            this.labelStationName = new System.Windows.Forms.Label();
            this.labelCellNumber = new System.Windows.Forms.Label();
            this.tabPageLog = new System.Windows.Forms.TabPage();
            this.textBoxTestLog = new System.Windows.Forms.TextBox();
            this.tabPageViewSequence = new System.Windows.Forms.TabPage();
            this.splitContainerSequenceView = new System.Windows.Forms.SplitContainer();
            this.treeViewSequenceItemList = new System.Windows.Forms.TreeView();
            this.labelTestSequenceItemList = new System.Windows.Forms.Label();
            this.tabControlTestResultView = new System.Windows.Forms.TabControl();
            this.tabPageTestResult = new System.Windows.Forms.TabPage();
            this.groupBoxTestConclusion = new System.Windows.Forms.GroupBox();
            this.dataGridViewTestConclusion = new System.Windows.Forms.DataGridView();
            this.groupBoxResult = new System.Windows.Forms.GroupBox();
            this.dataGridViewTestResult = new System.Windows.Forms.DataGridView();
            this.groupBoxTestFunctionParams = new System.Windows.Forms.GroupBox();
            this.textBoxTestFunctionName = new System.Windows.Forms.TextBox();
            this.textBoxParameter6 = new System.Windows.Forms.TextBox();
            this.textBoxParameter5 = new System.Windows.Forms.TextBox();
            this.textBoxParameter4 = new System.Windows.Forms.TextBox();
            this.textBoxParameter3 = new System.Windows.Forms.TextBox();
            this.textBoxParameter2 = new System.Windows.Forms.TextBox();
            this.textBoxParameter1 = new System.Windows.Forms.TextBox();
            this.labelParameters = new System.Windows.Forms.Label();
            this.labelTestFunctionName = new System.Windows.Forms.Label();
            this.groupBoxBasicTestStepInfo = new System.Windows.Forms.GroupBox();
            this.textBoxStepDescription = new System.Windows.Forms.TextBox();
            this.textBoxStepName = new System.Windows.Forms.TextBox();
            this.textBoxStepNo = new System.Windows.Forms.TextBox();
            this.labelStepDescription = new System.Windows.Forms.Label();
            this.labelStepName = new System.Windows.Forms.Label();
            this.labelStepNo = new System.Windows.Forms.Label();
            this.cellToolStrip.SuspendLayout();
            this.cellStatusStrip.SuspendLayout();
            this.tabControlTestStation.SuspendLayout();
            this.tabPageHome.SuspendLayout();
            this.groupBoxStartEnd.SuspendLayout();
            this.tabPageLog.SuspendLayout();
            this.tabPageViewSequence.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSequenceView)).BeginInit();
            this.splitContainerSequenceView.Panel1.SuspendLayout();
            this.splitContainerSequenceView.Panel2.SuspendLayout();
            this.splitContainerSequenceView.SuspendLayout();
            this.tabControlTestResultView.SuspendLayout();
            this.tabPageTestResult.SuspendLayout();
            this.groupBoxTestConclusion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTestConclusion)).BeginInit();
            this.groupBoxResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTestResult)).BeginInit();
            this.groupBoxTestFunctionParams.SuspendLayout();
            this.groupBoxBasicTestStepInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // cellToolStrip
            // 
            this.cellToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cellToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnOpenSequence,
            this.toolStripBtnSettings,
            this.toolStripBtnRefresh,
            this.toolStripSeparator1,
            this.toolStripComboBoxManualAuto,
            this.toolStripSeparator2,
            this.toolStripLabelSequenceFile});
            this.cellToolStrip.Location = new System.Drawing.Point(0, 0);
            this.cellToolStrip.Name = "cellToolStrip";
            this.cellToolStrip.Size = new System.Drawing.Size(916, 27);
            this.cellToolStrip.TabIndex = 0;
            this.cellToolStrip.Text = "toolStrip1";
            // 
            // toolStripBtnOpenSequence
            // 
            this.toolStripBtnOpenSequence.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnOpenSequence.Image")));
            this.toolStripBtnOpenSequence.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnOpenSequence.Name = "toolStripBtnOpenSequence";
            this.toolStripBtnOpenSequence.Size = new System.Drawing.Size(166, 24);
            this.toolStripBtnOpenSequence.Text = "Open/Load test sequence";
            this.toolStripBtnOpenSequence.Click += new System.EventHandler(this.toolStripBtnOpenSequence_Click);
            // 
            // toolStripBtnSettings
            // 
            this.toolStripBtnSettings.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnSettings.Image")));
            this.toolStripBtnSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnSettings.Name = "toolStripBtnSettings";
            this.toolStripBtnSettings.Size = new System.Drawing.Size(73, 24);
            this.toolStripBtnSettings.Text = "Settings";
            // 
            // toolStripBtnRefresh
            // 
            this.toolStripBtnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnRefresh.Image")));
            this.toolStripBtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnRefresh.Name = "toolStripBtnRefresh";
            this.toolStripBtnRefresh.Size = new System.Drawing.Size(70, 24);
            this.toolStripBtnRefresh.Text = "Refresh";
            this.toolStripBtnRefresh.Click += new System.EventHandler(this.toolStripBtnRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripComboBoxManualAuto
            // 
            this.toolStripComboBoxManualAuto.Items.AddRange(new object[] {
            "Manual",
            "Auto"});
            this.toolStripComboBoxManualAuto.Name = "toolStripComboBoxManualAuto";
            this.toolStripComboBoxManualAuto.Size = new System.Drawing.Size(151, 27);
            this.toolStripComboBoxManualAuto.Text = "Select your mode here";
            this.toolStripComboBoxManualAuto.ToolTipText = "Switch between Manual and Auto mode";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripLabelSequenceFile
            // 
            this.toolStripLabelSequenceFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabelSequenceFile.ForeColor = System.Drawing.Color.Red;
            this.toolStripLabelSequenceFile.Name = "toolStripLabelSequenceFile";
            this.toolStripLabelSequenceFile.Size = new System.Drawing.Size(222, 24);
            this.toolStripLabelSequenceFile.Text = "Please load your test sequence file firstly!";
            this.toolStripLabelSequenceFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cellStatusStrip
            // 
            this.cellStatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cellStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelBasic,
            this.toolStripStatusLabelItemInfo,
            this.toolStripStatusLabelElapsedTime});
            this.cellStatusStrip.Location = new System.Drawing.Point(0, 666);
            this.cellStatusStrip.Name = "cellStatusStrip";
            this.cellStatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.cellStatusStrip.Size = new System.Drawing.Size(916, 24);
            this.cellStatusStrip.TabIndex = 1;
            this.cellStatusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabelBasic
            // 
            this.toolStripStatusLabelBasic.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.toolStripStatusLabelBasic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabelBasic.Name = "toolStripStatusLabelBasic";
            this.toolStripStatusLabelBasic.Size = new System.Drawing.Size(301, 19);
            this.toolStripStatusLabelBasic.Spring = true;
            this.toolStripStatusLabelBasic.Text = "Current status";
            this.toolStripStatusLabelBasic.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabelItemInfo
            // 
            this.toolStripStatusLabelItemInfo.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.toolStripStatusLabelItemInfo.Name = "toolStripStatusLabelItemInfo";
            this.toolStripStatusLabelItemInfo.Size = new System.Drawing.Size(301, 19);
            this.toolStripStatusLabelItemInfo.Spring = true;
            this.toolStripStatusLabelItemInfo.Text = "Item Info";
            this.toolStripStatusLabelItemInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabelElapsedTime
            // 
            this.toolStripStatusLabelElapsedTime.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabelElapsedTime.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.toolStripStatusLabelElapsedTime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabelElapsedTime.Name = "toolStripStatusLabelElapsedTime";
            this.toolStripStatusLabelElapsedTime.Size = new System.Drawing.Size(301, 19);
            this.toolStripStatusLabelElapsedTime.Spring = true;
            this.toolStripStatusLabelElapsedTime.Text = "Elapsed time : ";
            this.toolStripStatusLabelElapsedTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabControlTestStation
            // 
            this.tabControlTestStation.Controls.Add(this.tabPageHome);
            this.tabControlTestStation.Controls.Add(this.tabPageLog);
            this.tabControlTestStation.Controls.Add(this.tabPageViewSequence);
            this.tabControlTestStation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlTestStation.Location = new System.Drawing.Point(0, 27);
            this.tabControlTestStation.Margin = new System.Windows.Forms.Padding(2);
            this.tabControlTestStation.Name = "tabControlTestStation";
            this.tabControlTestStation.SelectedIndex = 0;
            this.tabControlTestStation.Size = new System.Drawing.Size(916, 639);
            this.tabControlTestStation.TabIndex = 2;
            // 
            // tabPageHome
            // 
            this.tabPageHome.Controls.Add(this.listViewTestItems);
            this.tabPageHome.Controls.Add(this.groupBoxStartEnd);
            this.tabPageHome.Controls.Add(this.progressBarTestProgress);
            this.tabPageHome.Controls.Add(this.labelIndicator);
            this.tabPageHome.Controls.Add(this.labelStationName);
            this.tabPageHome.Controls.Add(this.labelCellNumber);
            this.tabPageHome.Location = new System.Drawing.Point(4, 22);
            this.tabPageHome.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageHome.Name = "tabPageHome";
            this.tabPageHome.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageHome.Size = new System.Drawing.Size(908, 613);
            this.tabPageHome.TabIndex = 0;
            this.tabPageHome.Text = "Home";
            this.tabPageHome.UseVisualStyleBackColor = true;
            // 
            // listViewTestItems
            // 
            this.listViewTestItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewTestItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewTestItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderSeqNum,
            this.columnHeaderTestItem,
            this.columnHeaderConclusion});
            this.listViewTestItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listViewTestItems.FullRowSelect = true;
            this.listViewTestItems.Location = new System.Drawing.Point(7, 219);
            this.listViewTestItems.Margin = new System.Windows.Forms.Padding(2);
            this.listViewTestItems.MultiSelect = false;
            this.listViewTestItems.Name = "listViewTestItems";
            this.listViewTestItems.Size = new System.Drawing.Size(898, 282);
            this.listViewTestItems.TabIndex = 6;
            this.listViewTestItems.UseCompatibleStateImageBehavior = false;
            this.listViewTestItems.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderSeqNum
            // 
            this.columnHeaderSeqNum.Text = "Seq. #";
            this.columnHeaderSeqNum.Width = 100;
            // 
            // columnHeaderTestItem
            // 
            this.columnHeaderTestItem.Text = "Item";
            this.columnHeaderTestItem.Width = 500;
            // 
            // columnHeaderConclusion
            // 
            this.columnHeaderConclusion.Text = "Conclusion";
            this.columnHeaderConclusion.Width = 300;
            // 
            // groupBoxStartEnd
            // 
            this.groupBoxStartEnd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxStartEnd.Controls.Add(this.btnEnd);
            this.groupBoxStartEnd.Controls.Add(this.btnStart);
            this.groupBoxStartEnd.Controls.Add(this.textBoxSerialNum);
            this.groupBoxStartEnd.Controls.Add(this.labelSerialNum);
            this.groupBoxStartEnd.Location = new System.Drawing.Point(7, 506);
            this.groupBoxStartEnd.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxStartEnd.Name = "groupBoxStartEnd";
            this.groupBoxStartEnd.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxStartEnd.Size = new System.Drawing.Size(901, 81);
            this.groupBoxStartEnd.TabIndex = 5;
            this.groupBoxStartEnd.TabStop = false;
            // 
            // btnEnd
            // 
            this.btnEnd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnd.AutoSize = true;
            this.btnEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEnd.Location = new System.Drawing.Point(764, 25);
            this.btnEnd.Margin = new System.Windows.Forms.Padding(2);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(132, 56);
            this.btnEnd.TabIndex = 2;
            this.btnEnd.Text = "&End";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Visible = false;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.AutoSize = true;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStart.Location = new System.Drawing.Point(616, 25);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(132, 56);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "&Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // textBoxSerialNum
            // 
            this.textBoxSerialNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxSerialNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxSerialNum.Location = new System.Drawing.Point(234, 28);
            this.textBoxSerialNum.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSerialNum.Name = "textBoxSerialNum";
            this.textBoxSerialNum.Size = new System.Drawing.Size(351, 38);
            this.textBoxSerialNum.TabIndex = 0;
            // 
            // labelSerialNum
            // 
            this.labelSerialNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSerialNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSerialNum.Location = new System.Drawing.Point(4, 15);
            this.labelSerialNum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSerialNum.Name = "labelSerialNum";
            this.labelSerialNum.Size = new System.Drawing.Size(212, 64);
            this.labelSerialNum.TabIndex = 7;
            this.labelSerialNum.Text = "Serial Number : ";
            this.labelSerialNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBarTestProgress
            // 
            this.progressBarTestProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarTestProgress.Location = new System.Drawing.Point(4, 592);
            this.progressBarTestProgress.Margin = new System.Windows.Forms.Padding(2);
            this.progressBarTestProgress.Name = "progressBarTestProgress";
            this.progressBarTestProgress.Size = new System.Drawing.Size(899, 19);
            this.progressBarTestProgress.TabIndex = 100;
            // 
            // labelIndicator
            // 
            this.labelIndicator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelIndicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelIndicator.ForeColor = System.Drawing.Color.Black;
            this.labelIndicator.Location = new System.Drawing.Point(5, 102);
            this.labelIndicator.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelIndicator.Name = "labelIndicator";
            this.labelIndicator.Size = new System.Drawing.Size(899, 115);
            this.labelIndicator.TabIndex = 5;
            this.labelIndicator.Text = "Ready";
            this.labelIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelStationName
            // 
            this.labelStationName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStationName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelStationName.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelStationName.Location = new System.Drawing.Point(90, 6);
            this.labelStationName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStationName.Name = "labelStationName";
            this.labelStationName.Size = new System.Drawing.Size(814, 94);
            this.labelStationName.TabIndex = 4;
            this.labelStationName.Text = "Station Name";
            this.labelStationName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCellNumber
            // 
            this.labelCellNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelCellNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelCellNumber.Location = new System.Drawing.Point(5, 6);
            this.labelCellNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCellNumber.Name = "labelCellNumber";
            this.labelCellNumber.Size = new System.Drawing.Size(81, 94);
            this.labelCellNumber.TabIndex = 3;
            this.labelCellNumber.Text = "1";
            // 
            // tabPageLog
            // 
            this.tabPageLog.Controls.Add(this.textBoxTestLog);
            this.tabPageLog.Location = new System.Drawing.Point(4, 22);
            this.tabPageLog.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageLog.Name = "tabPageLog";
            this.tabPageLog.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageLog.Size = new System.Drawing.Size(908, 613);
            this.tabPageLog.TabIndex = 1;
            this.tabPageLog.Text = "Log";
            this.tabPageLog.UseVisualStyleBackColor = true;
            // 
            // textBoxTestLog
            // 
            this.textBoxTestLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTestLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxTestLog.Location = new System.Drawing.Point(2, 2);
            this.textBoxTestLog.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxTestLog.Multiline = true;
            this.textBoxTestLog.Name = "textBoxTestLog";
            this.textBoxTestLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxTestLog.Size = new System.Drawing.Size(904, 609);
            this.textBoxTestLog.TabIndex = 0;
            this.textBoxTestLog.Text = "This text box will display the complete test log.\r\n\r\nIt can display many lines of" +
    " string.";
            // 
            // tabPageViewSequence
            // 
            this.tabPageViewSequence.Controls.Add(this.splitContainerSequenceView);
            this.tabPageViewSequence.Location = new System.Drawing.Point(4, 22);
            this.tabPageViewSequence.Name = "tabPageViewSequence";
            this.tabPageViewSequence.Size = new System.Drawing.Size(908, 613);
            this.tabPageViewSequence.TabIndex = 2;
            this.tabPageViewSequence.Text = "View sequence";
            this.tabPageViewSequence.UseVisualStyleBackColor = true;
            // 
            // splitContainerSequenceView
            // 
            this.splitContainerSequenceView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerSequenceView.Location = new System.Drawing.Point(0, 0);
            this.splitContainerSequenceView.Name = "splitContainerSequenceView";
            // 
            // splitContainerSequenceView.Panel1
            // 
            this.splitContainerSequenceView.Panel1.Controls.Add(this.treeViewSequenceItemList);
            this.splitContainerSequenceView.Panel1.Controls.Add(this.labelTestSequenceItemList);
            // 
            // splitContainerSequenceView.Panel2
            // 
            this.splitContainerSequenceView.Panel2.Controls.Add(this.tabControlTestResultView);
            this.splitContainerSequenceView.Size = new System.Drawing.Size(908, 613);
            this.splitContainerSequenceView.SplitterDistance = 208;
            this.splitContainerSequenceView.TabIndex = 0;
            // 
            // treeViewSequenceItemList
            // 
            this.treeViewSequenceItemList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewSequenceItemList.Location = new System.Drawing.Point(0, 23);
            this.treeViewSequenceItemList.Name = "treeViewSequenceItemList";
            treeNode15.Name = "Block1_Item1";
            treeNode15.Text = "Open COM port";
            treeNode16.Name = "Blcok1_Item2";
            treeNode16.Text = "Coomunicate with DMM";
            treeNode17.Name = "Block1_Item3";
            treeNode17.Text = "Configure network";
            treeNode18.Name = "Block1";
            treeNode18.Text = "Initialization";
            treeNode19.Name = "Block2_Item1";
            treeNode19.Text = "Measure VDD";
            treeNode20.Name = "Block2_Item2";
            treeNode20.Text = "Measure Vref";
            treeNode21.Name = "Block2";
            treeNode21.Text = "Voltage measurement";
            this.treeViewSequenceItemList.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode18,
            treeNode21});
            this.treeViewSequenceItemList.Size = new System.Drawing.Size(208, 590);
            this.treeViewSequenceItemList.TabIndex = 1;
            this.treeViewSequenceItemList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewSequenceItemList_AfterSelect);
            // 
            // labelTestSequenceItemList
            // 
            this.labelTestSequenceItemList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTestSequenceItemList.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTestSequenceItemList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTestSequenceItemList.Location = new System.Drawing.Point(0, 0);
            this.labelTestSequenceItemList.Name = "labelTestSequenceItemList";
            this.labelTestSequenceItemList.Size = new System.Drawing.Size(208, 23);
            this.labelTestSequenceItemList.TabIndex = 2;
            this.labelTestSequenceItemList.Text = "Test Sequence Item List";
            this.labelTestSequenceItemList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabControlTestResultView
            // 
            this.tabControlTestResultView.Controls.Add(this.tabPageTestResult);
            this.tabControlTestResultView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlTestResultView.Location = new System.Drawing.Point(0, 0);
            this.tabControlTestResultView.Name = "tabControlTestResultView";
            this.tabControlTestResultView.SelectedIndex = 0;
            this.tabControlTestResultView.Size = new System.Drawing.Size(696, 613);
            this.tabControlTestResultView.TabIndex = 1;
            // 
            // tabPageTestResult
            // 
            this.tabPageTestResult.Controls.Add(this.groupBoxTestConclusion);
            this.tabPageTestResult.Controls.Add(this.groupBoxResult);
            this.tabPageTestResult.Controls.Add(this.groupBoxTestFunctionParams);
            this.tabPageTestResult.Controls.Add(this.groupBoxBasicTestStepInfo);
            this.tabPageTestResult.Location = new System.Drawing.Point(4, 22);
            this.tabPageTestResult.Name = "tabPageTestResult";
            this.tabPageTestResult.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTestResult.Size = new System.Drawing.Size(688, 587);
            this.tabPageTestResult.TabIndex = 0;
            this.tabPageTestResult.Text = "Test Result";
            this.tabPageTestResult.UseVisualStyleBackColor = true;
            // 
            // groupBoxTestConclusion
            // 
            this.groupBoxTestConclusion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTestConclusion.Controls.Add(this.dataGridViewTestConclusion);
            this.groupBoxTestConclusion.Location = new System.Drawing.Point(6, 417);
            this.groupBoxTestConclusion.Name = "groupBoxTestConclusion";
            this.groupBoxTestConclusion.Size = new System.Drawing.Size(676, 104);
            this.groupBoxTestConclusion.TabIndex = 4;
            this.groupBoxTestConclusion.TabStop = false;
            this.groupBoxTestConclusion.Text = "Test conclusion";
            // 
            // dataGridViewTestConclusion
            // 
            this.dataGridViewTestConclusion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewTestConclusion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTestConclusion.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewTestConclusion.Name = "dataGridViewTestConclusion";
            this.dataGridViewTestConclusion.Size = new System.Drawing.Size(664, 79);
            this.dataGridViewTestConclusion.TabIndex = 5;
            // 
            // groupBoxResult
            // 
            this.groupBoxResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxResult.Controls.Add(this.dataGridViewTestResult);
            this.groupBoxResult.Location = new System.Drawing.Point(6, 274);
            this.groupBoxResult.Name = "groupBoxResult";
            this.groupBoxResult.Size = new System.Drawing.Size(676, 137);
            this.groupBoxResult.TabIndex = 3;
            this.groupBoxResult.TabStop = false;
            this.groupBoxResult.Text = "Real time test result";
            // 
            // dataGridViewTestResult
            // 
            this.dataGridViewTestResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewTestResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTestResult.Location = new System.Drawing.Point(7, 19);
            this.dataGridViewTestResult.Name = "dataGridViewTestResult";
            this.dataGridViewTestResult.Size = new System.Drawing.Size(663, 112);
            this.dataGridViewTestResult.TabIndex = 5;
            // 
            // groupBoxTestFunctionParams
            // 
            this.groupBoxTestFunctionParams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTestFunctionParams.Controls.Add(this.textBoxTestFunctionName);
            this.groupBoxTestFunctionParams.Controls.Add(this.textBoxParameter6);
            this.groupBoxTestFunctionParams.Controls.Add(this.textBoxParameter5);
            this.groupBoxTestFunctionParams.Controls.Add(this.textBoxParameter4);
            this.groupBoxTestFunctionParams.Controls.Add(this.textBoxParameter3);
            this.groupBoxTestFunctionParams.Controls.Add(this.textBoxParameter2);
            this.groupBoxTestFunctionParams.Controls.Add(this.textBoxParameter1);
            this.groupBoxTestFunctionParams.Controls.Add(this.labelParameters);
            this.groupBoxTestFunctionParams.Controls.Add(this.labelTestFunctionName);
            this.groupBoxTestFunctionParams.Location = new System.Drawing.Point(6, 133);
            this.groupBoxTestFunctionParams.Name = "groupBoxTestFunctionParams";
            this.groupBoxTestFunctionParams.Size = new System.Drawing.Size(676, 135);
            this.groupBoxTestFunctionParams.TabIndex = 2;
            this.groupBoxTestFunctionParams.TabStop = false;
            // 
            // textBoxTestFunctionName
            // 
            this.textBoxTestFunctionName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTestFunctionName.Location = new System.Drawing.Point(113, 25);
            this.textBoxTestFunctionName.Name = "textBoxTestFunctionName";
            this.textBoxTestFunctionName.ReadOnly = true;
            this.textBoxTestFunctionName.Size = new System.Drawing.Size(554, 20);
            this.textBoxTestFunctionName.TabIndex = 9;
            this.textBoxTestFunctionName.Text = "ProjTestItem.OpenComPort";
            // 
            // textBoxParameter6
            // 
            this.textBoxParameter6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxParameter6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxParameter6.Location = new System.Drawing.Point(493, 93);
            this.textBoxParameter6.Name = "textBoxParameter6";
            this.textBoxParameter6.ReadOnly = true;
            this.textBoxParameter6.Size = new System.Drawing.Size(174, 20);
            this.textBoxParameter6.TabIndex = 8;
            // 
            // textBoxParameter5
            // 
            this.textBoxParameter5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxParameter5.Location = new System.Drawing.Point(291, 93);
            this.textBoxParameter5.Name = "textBoxParameter5";
            this.textBoxParameter5.ReadOnly = true;
            this.textBoxParameter5.Size = new System.Drawing.Size(179, 20);
            this.textBoxParameter5.TabIndex = 7;
            // 
            // textBoxParameter4
            // 
            this.textBoxParameter4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxParameter4.Location = new System.Drawing.Point(113, 93);
            this.textBoxParameter4.Name = "textBoxParameter4";
            this.textBoxParameter4.ReadOnly = true;
            this.textBoxParameter4.Size = new System.Drawing.Size(159, 20);
            this.textBoxParameter4.TabIndex = 6;
            this.textBoxParameter4.Text = "STOP:1";
            // 
            // textBoxParameter3
            // 
            this.textBoxParameter3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxParameter3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxParameter3.Location = new System.Drawing.Point(493, 57);
            this.textBoxParameter3.Name = "textBoxParameter3";
            this.textBoxParameter3.ReadOnly = true;
            this.textBoxParameter3.Size = new System.Drawing.Size(174, 20);
            this.textBoxParameter3.TabIndex = 5;
            this.textBoxParameter3.Text = "LEN:8";
            // 
            // textBoxParameter2
            // 
            this.textBoxParameter2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxParameter2.Location = new System.Drawing.Point(291, 57);
            this.textBoxParameter2.Name = "textBoxParameter2";
            this.textBoxParameter2.ReadOnly = true;
            this.textBoxParameter2.Size = new System.Drawing.Size(179, 20);
            this.textBoxParameter2.TabIndex = 4;
            this.textBoxParameter2.Text = "BAUD:115200";
            // 
            // textBoxParameter1
            // 
            this.textBoxParameter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxParameter1.Location = new System.Drawing.Point(113, 57);
            this.textBoxParameter1.Name = "textBoxParameter1";
            this.textBoxParameter1.ReadOnly = true;
            this.textBoxParameter1.Size = new System.Drawing.Size(159, 20);
            this.textBoxParameter1.TabIndex = 3;
            this.textBoxParameter1.Text = "COM:1";
            // 
            // labelParameters
            // 
            this.labelParameters.AutoSize = true;
            this.labelParameters.Location = new System.Drawing.Point(16, 64);
            this.labelParameters.Name = "labelParameters";
            this.labelParameters.Size = new System.Drawing.Size(83, 13);
            this.labelParameters.TabIndex = 2;
            this.labelParameters.Text = "Parameter List : ";
            // 
            // labelTestFunctionName
            // 
            this.labelTestFunctionName.AutoSize = true;
            this.labelTestFunctionName.Location = new System.Drawing.Point(13, 25);
            this.labelTestFunctionName.Name = "labelTestFunctionName";
            this.labelTestFunctionName.Size = new System.Drawing.Size(88, 13);
            this.labelTestFunctionName.TabIndex = 0;
            this.labelTestFunctionName.Text = "Function Name : ";
            // 
            // groupBoxBasicTestStepInfo
            // 
            this.groupBoxBasicTestStepInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxBasicTestStepInfo.Controls.Add(this.textBoxStepDescription);
            this.groupBoxBasicTestStepInfo.Controls.Add(this.textBoxStepName);
            this.groupBoxBasicTestStepInfo.Controls.Add(this.textBoxStepNo);
            this.groupBoxBasicTestStepInfo.Controls.Add(this.labelStepDescription);
            this.groupBoxBasicTestStepInfo.Controls.Add(this.labelStepName);
            this.groupBoxBasicTestStepInfo.Controls.Add(this.labelStepNo);
            this.groupBoxBasicTestStepInfo.Location = new System.Drawing.Point(6, 6);
            this.groupBoxBasicTestStepInfo.Name = "groupBoxBasicTestStepInfo";
            this.groupBoxBasicTestStepInfo.Size = new System.Drawing.Size(568, 121);
            this.groupBoxBasicTestStepInfo.TabIndex = 1;
            this.groupBoxBasicTestStepInfo.TabStop = false;
            // 
            // textBoxStepDescription
            // 
            this.textBoxStepDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStepDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxStepDescription.Location = new System.Drawing.Point(113, 85);
            this.textBoxStepDescription.Name = "textBoxStepDescription";
            this.textBoxStepDescription.ReadOnly = true;
            this.textBoxStepDescription.Size = new System.Drawing.Size(446, 20);
            this.textBoxStepDescription.TabIndex = 5;
            this.textBoxStepDescription.Text = "Open the COM port to intialize the network analyzer";
            // 
            // textBoxStepName
            // 
            this.textBoxStepName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStepName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxStepName.Location = new System.Drawing.Point(113, 53);
            this.textBoxStepName.Name = "textBoxStepName";
            this.textBoxStepName.ReadOnly = true;
            this.textBoxStepName.Size = new System.Drawing.Size(446, 20);
            this.textBoxStepName.TabIndex = 4;
            this.textBoxStepName.Text = "Open COM port";
            // 
            // textBoxStepNo
            // 
            this.textBoxStepNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStepNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxStepNo.Location = new System.Drawing.Point(113, 17);
            this.textBoxStepNo.Name = "textBoxStepNo";
            this.textBoxStepNo.ReadOnly = true;
            this.textBoxStepNo.Size = new System.Drawing.Size(446, 20);
            this.textBoxStepNo.TabIndex = 3;
            this.textBoxStepNo.Text = "1.1";
            // 
            // labelStepDescription
            // 
            this.labelStepDescription.AutoSize = true;
            this.labelStepDescription.Location = new System.Drawing.Point(13, 85);
            this.labelStepDescription.Name = "labelStepDescription";
            this.labelStepDescription.Size = new System.Drawing.Size(94, 13);
            this.labelStepDescription.TabIndex = 2;
            this.labelStepDescription.Text = "Step Description : ";
            // 
            // labelStepName
            // 
            this.labelStepName.AutoSize = true;
            this.labelStepName.Location = new System.Drawing.Point(13, 53);
            this.labelStepName.Name = "labelStepName";
            this.labelStepName.Size = new System.Drawing.Size(69, 13);
            this.labelStepName.TabIndex = 1;
            this.labelStepName.Text = "Step Name : ";
            // 
            // labelStepNo
            // 
            this.labelStepNo.AutoSize = true;
            this.labelStepNo.Location = new System.Drawing.Point(13, 20);
            this.labelStepNo.Name = "labelStepNo";
            this.labelStepNo.Size = new System.Drawing.Size(58, 13);
            this.labelStepNo.TabIndex = 0;
            this.labelStepNo.Text = "Step No. : ";
            // 
            // TestPanel
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 690);
            this.Controls.Add(this.tabControlTestStation);
            this.Controls.Add(this.cellStatusStrip);
            this.Controls.Add(this.cellToolStrip);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TestPanel";
            this.Text = "Test Panel";
            this.cellToolStrip.ResumeLayout(false);
            this.cellToolStrip.PerformLayout();
            this.cellStatusStrip.ResumeLayout(false);
            this.cellStatusStrip.PerformLayout();
            this.tabControlTestStation.ResumeLayout(false);
            this.tabPageHome.ResumeLayout(false);
            this.groupBoxStartEnd.ResumeLayout(false);
            this.groupBoxStartEnd.PerformLayout();
            this.tabPageLog.ResumeLayout(false);
            this.tabPageLog.PerformLayout();
            this.tabPageViewSequence.ResumeLayout(false);
            this.splitContainerSequenceView.Panel1.ResumeLayout(false);
            this.splitContainerSequenceView.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSequenceView)).EndInit();
            this.splitContainerSequenceView.ResumeLayout(false);
            this.tabControlTestResultView.ResumeLayout(false);
            this.tabPageTestResult.ResumeLayout(false);
            this.groupBoxTestConclusion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTestConclusion)).EndInit();
            this.groupBoxResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTestResult)).EndInit();
            this.groupBoxTestFunctionParams.ResumeLayout(false);
            this.groupBoxTestFunctionParams.PerformLayout();
            this.groupBoxBasicTestStepInfo.ResumeLayout(false);
            this.groupBoxBasicTestStepInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip cellToolStrip;
        private System.Windows.Forms.StatusStrip cellStatusStrip;
        private System.Windows.Forms.ToolStripButton toolStripBtnSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxManualAuto;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelBasic;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelItemInfo;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelElapsedTime;
        private System.Windows.Forms.TabControl tabControlTestStation;
        private System.Windows.Forms.TabPage tabPageHome;
        private System.Windows.Forms.TabPage tabPageLog;
        private System.Windows.Forms.Label labelCellNumber;
        private System.Windows.Forms.Label labelStationName;
        private System.Windows.Forms.Label labelIndicator;
        private System.Windows.Forms.ListView listViewTestItems;
        private System.Windows.Forms.GroupBox groupBoxStartEnd;
        private System.Windows.Forms.ProgressBar progressBarTestProgress;
        private System.Windows.Forms.TextBox textBoxSerialNum;
        private System.Windows.Forms.Label labelSerialNum;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.ColumnHeader columnHeaderSeqNum;
        private System.Windows.Forms.ColumnHeader columnHeaderTestItem;
        private System.Windows.Forms.ColumnHeader columnHeaderConclusion;
        private System.Windows.Forms.TextBox textBoxTestLog;
        private System.Windows.Forms.ToolStripButton toolStripBtnOpenSequence;
        private System.Windows.Forms.TabPage tabPageViewSequence;
        private System.Windows.Forms.SplitContainer splitContainerSequenceView;
        private System.Windows.Forms.TreeView treeViewSequenceItemList;
        private System.Windows.Forms.Label labelTestSequenceItemList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabelSequenceFile;
        private System.Windows.Forms.TabControl tabControlTestResultView;
        private System.Windows.Forms.TabPage tabPageTestResult;
        private System.Windows.Forms.GroupBox groupBoxBasicTestStepInfo;
        private System.Windows.Forms.TextBox textBoxStepDescription;
        private System.Windows.Forms.TextBox textBoxStepName;
        private System.Windows.Forms.TextBox textBoxStepNo;
        private System.Windows.Forms.Label labelStepDescription;
        private System.Windows.Forms.Label labelStepName;
        private System.Windows.Forms.Label labelStepNo;
        private System.Windows.Forms.GroupBox groupBoxTestFunctionParams;
        private System.Windows.Forms.TextBox textBoxParameter6;
        private System.Windows.Forms.TextBox textBoxParameter5;
        private System.Windows.Forms.TextBox textBoxParameter4;
        private System.Windows.Forms.TextBox textBoxParameter3;
        private System.Windows.Forms.TextBox textBoxParameter2;
        private System.Windows.Forms.TextBox textBoxParameter1;
        private System.Windows.Forms.Label labelParameters;
        private System.Windows.Forms.Label labelTestFunctionName;
        private System.Windows.Forms.GroupBox groupBoxTestConclusion;
        private System.Windows.Forms.GroupBox groupBoxResult;
        private System.Windows.Forms.TextBox textBoxTestFunctionName;
        private System.Windows.Forms.DataGridView dataGridViewTestResult;
        private System.Windows.Forms.DataGridView dataGridViewTestConclusion;
        private System.Windows.Forms.ToolStripButton toolStripBtnRefresh;
    }
}
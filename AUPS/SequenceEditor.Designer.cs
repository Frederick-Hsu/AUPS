namespace Amphenol.AUPS
{
    partial class SequenceEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SequenceEditor));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Open COM port");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Communicate with DMM");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Configure network");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Initialization", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Measure VDD");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Measure Vref");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Voltage measurement", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6});
            this.sequenceEditorToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnSaveAs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnCopyStep = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnCutStep = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnPasteStep = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBoxSequenceFilePath = new System.Windows.Forms.ToolStripTextBox();
            this.editorSplitContainer = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.labelItemList = new System.Windows.Forms.Label();
            this.editorTabControl = new System.Windows.Forms.TabControl();
            this.tabPageEditStep = new System.Windows.Forms.TabPage();
            this.groupBoxSpecification = new System.Windows.Forms.GroupBox();
            this.listViewTestSepc = new System.Windows.Forms.ListView();
            this.columnHeaderLowerLimit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTypical = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderUpperLimit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderResult = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.comboBoxLimitType = new System.Windows.Forms.ComboBox();
            this.labelLimitType = new System.Windows.Forms.Label();
            this.groupBoxTestFunctionParams = new System.Windows.Forms.GroupBox();
            this.textBoxParameter6 = new System.Windows.Forms.TextBox();
            this.textBoxParameter5 = new System.Windows.Forms.TextBox();
            this.textBoxParameter4 = new System.Windows.Forms.TextBox();
            this.textBoxParameter3 = new System.Windows.Forms.TextBox();
            this.textBoxParameter2 = new System.Windows.Forms.TextBox();
            this.textBoxParameter1 = new System.Windows.Forms.TextBox();
            this.labelParameters = new System.Windows.Forms.Label();
            this.comboBoxTestFunctionName = new System.Windows.Forms.ComboBox();
            this.labelTestFunctionName = new System.Windows.Forms.Label();
            this.groupBoxBasicTestStepInfo = new System.Windows.Forms.GroupBox();
            this.textBoxStepDescription = new System.Windows.Forms.TextBox();
            this.textBoxStepName = new System.Windows.Forms.TextBox();
            this.textBoxStepNo = new System.Windows.Forms.TextBox();
            this.labelStepDescription = new System.Windows.Forms.Label();
            this.labelStepName = new System.Windows.Forms.Label();
            this.labelStepNo = new System.Windows.Forms.Label();
            this.sequenceEditorToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editorSplitContainer)).BeginInit();
            this.editorSplitContainer.Panel1.SuspendLayout();
            this.editorSplitContainer.Panel2.SuspendLayout();
            this.editorSplitContainer.SuspendLayout();
            this.editorTabControl.SuspendLayout();
            this.tabPageEditStep.SuspendLayout();
            this.groupBoxSpecification.SuspendLayout();
            this.groupBoxTestFunctionParams.SuspendLayout();
            this.groupBoxBasicTestStepInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // sequenceEditorToolStrip
            // 
            this.sequenceEditorToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnNew,
            this.toolStripBtnOpen,
            this.toolStripBtnSave,
            this.toolStripBtnSaveAs,
            this.toolStripSeparator1,
            this.toolStripBtnRefresh,
            this.toolStripBtnCopyStep,
            this.toolStripBtnCutStep,
            this.toolStripBtnPasteStep,
            this.toolStripSeparator2,
            this.toolStripTextBoxSequenceFilePath});
            this.sequenceEditorToolStrip.Location = new System.Drawing.Point(0, 0);
            this.sequenceEditorToolStrip.Name = "sequenceEditorToolStrip";
            this.sequenceEditorToolStrip.Size = new System.Drawing.Size(1189, 38);
            this.sequenceEditorToolStrip.TabIndex = 1;
            this.sequenceEditorToolStrip.Text = "toolStrip1";
            // 
            // toolStripBtnNew
            // 
            this.toolStripBtnNew.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnNew.Image")));
            this.toolStripBtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnNew.Name = "toolStripBtnNew";
            this.toolStripBtnNew.Size = new System.Drawing.Size(35, 35);
            this.toolStripBtnNew.Text = "New";
            this.toolStripBtnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripBtnOpen
            // 
            this.toolStripBtnOpen.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnOpen.Image")));
            this.toolStripBtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnOpen.Name = "toolStripBtnOpen";
            this.toolStripBtnOpen.Size = new System.Drawing.Size(40, 35);
            this.toolStripBtnOpen.Text = "Open";
            this.toolStripBtnOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripBtnSave
            // 
            this.toolStripBtnSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnSave.Image")));
            this.toolStripBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnSave.Name = "toolStripBtnSave";
            this.toolStripBtnSave.Size = new System.Drawing.Size(35, 35);
            this.toolStripBtnSave.Text = "Save";
            this.toolStripBtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripBtnSaveAs
            // 
            this.toolStripBtnSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnSaveAs.Image")));
            this.toolStripBtnSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnSaveAs.Name = "toolStripBtnSaveAs";
            this.toolStripBtnSaveAs.Size = new System.Drawing.Size(51, 35);
            this.toolStripBtnSaveAs.Text = "Save As";
            this.toolStripBtnSaveAs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // toolStripBtnRefresh
            // 
            this.toolStripBtnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnRefresh.Image")));
            this.toolStripBtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnRefresh.Name = "toolStripBtnRefresh";
            this.toolStripBtnRefresh.Size = new System.Drawing.Size(50, 35);
            this.toolStripBtnRefresh.Text = "Refresh";
            this.toolStripBtnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripBtnCopyStep
            // 
            this.toolStripBtnCopyStep.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnCopyStep.Image")));
            this.toolStripBtnCopyStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnCopyStep.Name = "toolStripBtnCopyStep";
            this.toolStripBtnCopyStep.Size = new System.Drawing.Size(64, 35);
            this.toolStripBtnCopyStep.Text = "Copy step";
            this.toolStripBtnCopyStep.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripBtnCutStep
            // 
            this.toolStripBtnCutStep.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnCutStep.Image")));
            this.toolStripBtnCutStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnCutStep.Name = "toolStripBtnCutStep";
            this.toolStripBtnCutStep.Size = new System.Drawing.Size(55, 35);
            this.toolStripBtnCutStep.Text = "Cut step";
            this.toolStripBtnCutStep.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripBtnPasteStep
            // 
            this.toolStripBtnPasteStep.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnPasteStep.Image")));
            this.toolStripBtnPasteStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnPasteStep.Name = "toolStripBtnPasteStep";
            this.toolStripBtnPasteStep.Size = new System.Drawing.Size(64, 35);
            this.toolStripBtnPasteStep.Text = "Paste step";
            this.toolStripBtnPasteStep.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // toolStripTextBoxSequenceFilePath
            // 
            this.toolStripTextBoxSequenceFilePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBoxSequenceFilePath.Name = "toolStripTextBoxSequenceFilePath";
            this.toolStripTextBoxSequenceFilePath.ReadOnly = true;
            this.toolStripTextBoxSequenceFilePath.Size = new System.Drawing.Size(500, 38);
            // 
            // editorSplitContainer
            // 
            this.editorSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorSplitContainer.Location = new System.Drawing.Point(0, 38);
            this.editorSplitContainer.Name = "editorSplitContainer";
            // 
            // editorSplitContainer.Panel1
            // 
            this.editorSplitContainer.Panel1.Controls.Add(this.treeView1);
            this.editorSplitContainer.Panel1.Controls.Add(this.labelItemList);
            // 
            // editorSplitContainer.Panel2
            // 
            this.editorSplitContainer.Panel2.Controls.Add(this.editorTabControl);
            this.editorSplitContainer.Size = new System.Drawing.Size(1189, 614);
            this.editorSplitContainer.SplitterDistance = 265;
            this.editorSplitContainer.TabIndex = 2;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 13);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Block1_Item1";
            treeNode1.Text = "Open COM port";
            treeNode2.Name = "Block1_Item2";
            treeNode2.Text = "Communicate with DMM";
            treeNode3.Name = "Block1_Item3";
            treeNode3.Text = "Configure network";
            treeNode4.Checked = true;
            treeNode4.Name = "Block1";
            treeNode4.Text = "Initialization";
            treeNode5.Name = "Block2_Item1";
            treeNode5.Text = "Measure VDD";
            treeNode6.Name = "Block2_Item2";
            treeNode6.Text = "Measure Vref";
            treeNode7.Name = "Block2";
            treeNode7.Text = "Voltage measurement";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode7});
            this.treeView1.ShowNodeToolTips = true;
            this.treeView1.Size = new System.Drawing.Size(265, 601);
            this.treeView1.TabIndex = 3;
            // 
            // labelItemList
            // 
            this.labelItemList.AutoSize = true;
            this.labelItemList.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelItemList.Location = new System.Drawing.Point(0, 0);
            this.labelItemList.Name = "labelItemList";
            this.labelItemList.Size = new System.Drawing.Size(115, 13);
            this.labelItemList.TabIndex = 4;
            this.labelItemList.Text = "Test sequence item list";
            // 
            // editorTabControl
            // 
            this.editorTabControl.Controls.Add(this.tabPageEditStep);
            this.editorTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorTabControl.Location = new System.Drawing.Point(0, 0);
            this.editorTabControl.Name = "editorTabControl";
            this.editorTabControl.SelectedIndex = 0;
            this.editorTabControl.Size = new System.Drawing.Size(920, 614);
            this.editorTabControl.TabIndex = 3;
            // 
            // tabPageEditStep
            // 
            this.tabPageEditStep.Controls.Add(this.groupBoxSpecification);
            this.tabPageEditStep.Controls.Add(this.groupBoxTestFunctionParams);
            this.tabPageEditStep.Controls.Add(this.groupBoxBasicTestStepInfo);
            this.tabPageEditStep.Location = new System.Drawing.Point(4, 22);
            this.tabPageEditStep.Name = "tabPageEditStep";
            this.tabPageEditStep.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEditStep.Size = new System.Drawing.Size(912, 588);
            this.tabPageEditStep.TabIndex = 0;
            this.tabPageEditStep.Text = "Edit step";
            this.tabPageEditStep.UseVisualStyleBackColor = true;
            // 
            // groupBoxSpecification
            // 
            this.groupBoxSpecification.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSpecification.Controls.Add(this.listViewTestSepc);
            this.groupBoxSpecification.Controls.Add(this.comboBoxLimitType);
            this.groupBoxSpecification.Controls.Add(this.labelLimitType);
            this.groupBoxSpecification.Location = new System.Drawing.Point(7, 275);
            this.groupBoxSpecification.Name = "groupBoxSpecification";
            this.groupBoxSpecification.Size = new System.Drawing.Size(897, 126);
            this.groupBoxSpecification.TabIndex = 2;
            this.groupBoxSpecification.TabStop = false;
            this.groupBoxSpecification.Text = "Specification";
            // 
            // listViewTestSepc
            // 
            this.listViewTestSepc.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderLowerLimit,
            this.columnHeaderTypical,
            this.columnHeaderUpperLimit,
            this.columnHeaderResult});
            this.listViewTestSepc.Location = new System.Drawing.Point(7, 37);
            this.listViewTestSepc.Name = "listViewTestSepc";
            this.listViewTestSepc.Size = new System.Drawing.Size(884, 83);
            this.listViewTestSepc.TabIndex = 2;
            this.listViewTestSepc.UseCompatibleStateImageBehavior = false;
            this.listViewTestSepc.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderLowerLimit
            // 
            this.columnHeaderLowerLimit.Text = "Lower Limit";
            this.columnHeaderLowerLimit.Width = 200;
            // 
            // columnHeaderTypical
            // 
            this.columnHeaderTypical.Text = "Typical";
            this.columnHeaderTypical.Width = 200;
            // 
            // columnHeaderUpperLimit
            // 
            this.columnHeaderUpperLimit.Text = "Upper Limit";
            this.columnHeaderUpperLimit.Width = 200;
            // 
            // columnHeaderResult
            // 
            this.columnHeaderResult.Text = "Result";
            this.columnHeaderResult.Width = 250;
            // 
            // comboBoxLimitType
            // 
            this.comboBoxLimitType.FormattingEnabled = true;
            this.comboBoxLimitType.Items.AddRange(new object[] {
            "Numerical",
            "String"});
            this.comboBoxLimitType.Location = new System.Drawing.Point(641, 12);
            this.comboBoxLimitType.Name = "comboBoxLimitType";
            this.comboBoxLimitType.Size = new System.Drawing.Size(250, 21);
            this.comboBoxLimitType.TabIndex = 1;
            // 
            // labelLimitType
            // 
            this.labelLimitType.AutoSize = true;
            this.labelLimitType.Location = new System.Drawing.Point(548, 15);
            this.labelLimitType.Name = "labelLimitType";
            this.labelLimitType.Size = new System.Drawing.Size(60, 13);
            this.labelLimitType.TabIndex = 0;
            this.labelLimitType.Text = "Limit type : ";
            // 
            // groupBoxTestFunctionParams
            // 
            this.groupBoxTestFunctionParams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTestFunctionParams.Controls.Add(this.textBoxParameter6);
            this.groupBoxTestFunctionParams.Controls.Add(this.textBoxParameter5);
            this.groupBoxTestFunctionParams.Controls.Add(this.textBoxParameter4);
            this.groupBoxTestFunctionParams.Controls.Add(this.textBoxParameter3);
            this.groupBoxTestFunctionParams.Controls.Add(this.textBoxParameter2);
            this.groupBoxTestFunctionParams.Controls.Add(this.textBoxParameter1);
            this.groupBoxTestFunctionParams.Controls.Add(this.labelParameters);
            this.groupBoxTestFunctionParams.Controls.Add(this.comboBoxTestFunctionName);
            this.groupBoxTestFunctionParams.Controls.Add(this.labelTestFunctionName);
            this.groupBoxTestFunctionParams.Location = new System.Drawing.Point(6, 133);
            this.groupBoxTestFunctionParams.Name = "groupBoxTestFunctionParams";
            this.groupBoxTestFunctionParams.Size = new System.Drawing.Size(898, 135);
            this.groupBoxTestFunctionParams.TabIndex = 1;
            this.groupBoxTestFunctionParams.TabStop = false;
            // 
            // textBoxParameter6
            // 
            this.textBoxParameter6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxParameter6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxParameter6.Location = new System.Drawing.Point(642, 93);
            this.textBoxParameter6.Name = "textBoxParameter6";
            this.textBoxParameter6.Size = new System.Drawing.Size(250, 20);
            this.textBoxParameter6.TabIndex = 8;
            // 
            // textBoxParameter5
            // 
            this.textBoxParameter5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxParameter5.Location = new System.Drawing.Point(378, 93);
            this.textBoxParameter5.Name = "textBoxParameter5";
            this.textBoxParameter5.Size = new System.Drawing.Size(250, 20);
            this.textBoxParameter5.TabIndex = 7;
            // 
            // textBoxParameter4
            // 
            this.textBoxParameter4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxParameter4.Location = new System.Drawing.Point(113, 93);
            this.textBoxParameter4.Name = "textBoxParameter4";
            this.textBoxParameter4.Size = new System.Drawing.Size(250, 20);
            this.textBoxParameter4.TabIndex = 6;
            this.textBoxParameter4.Text = "STOP:1";
            // 
            // textBoxParameter3
            // 
            this.textBoxParameter3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxParameter3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxParameter3.Location = new System.Drawing.Point(642, 57);
            this.textBoxParameter3.Name = "textBoxParameter3";
            this.textBoxParameter3.Size = new System.Drawing.Size(250, 20);
            this.textBoxParameter3.TabIndex = 5;
            this.textBoxParameter3.Text = "LEN:8";
            // 
            // textBoxParameter2
            // 
            this.textBoxParameter2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxParameter2.Location = new System.Drawing.Point(378, 57);
            this.textBoxParameter2.Name = "textBoxParameter2";
            this.textBoxParameter2.Size = new System.Drawing.Size(250, 20);
            this.textBoxParameter2.TabIndex = 4;
            this.textBoxParameter2.Text = "BAUD:115200";
            // 
            // textBoxParameter1
            // 
            this.textBoxParameter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxParameter1.Location = new System.Drawing.Point(113, 57);
            this.textBoxParameter1.Name = "textBoxParameter1";
            this.textBoxParameter1.Size = new System.Drawing.Size(250, 20);
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
            // comboBoxTestFunctionName
            // 
            this.comboBoxTestFunctionName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxTestFunctionName.FormattingEnabled = true;
            this.comboBoxTestFunctionName.Items.AddRange(new object[] {
            "ProjTestItem.OpenComPort",
            "ProjTestItem.MeasureS11Impedence"});
            this.comboBoxTestFunctionName.Location = new System.Drawing.Point(113, 25);
            this.comboBoxTestFunctionName.Name = "comboBoxTestFunctionName";
            this.comboBoxTestFunctionName.Size = new System.Drawing.Size(775, 21);
            this.comboBoxTestFunctionName.TabIndex = 1;
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
            this.groupBoxBasicTestStepInfo.Size = new System.Drawing.Size(567, 121);
            this.groupBoxBasicTestStepInfo.TabIndex = 0;
            this.groupBoxBasicTestStepInfo.TabStop = false;
            // 
            // textBoxStepDescription
            // 
            this.textBoxStepDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStepDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxStepDescription.Location = new System.Drawing.Point(113, 85);
            this.textBoxStepDescription.Name = "textBoxStepDescription";
            this.textBoxStepDescription.Size = new System.Drawing.Size(444, 20);
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
            this.textBoxStepName.Size = new System.Drawing.Size(444, 20);
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
            this.textBoxStepNo.Size = new System.Drawing.Size(444, 20);
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
            // SequenceEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 652);
            this.Controls.Add(this.editorSplitContainer);
            this.Controls.Add(this.sequenceEditorToolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "SequenceEditor";
            this.Text = "Sequence Editor";
            this.sequenceEditorToolStrip.ResumeLayout(false);
            this.sequenceEditorToolStrip.PerformLayout();
            this.editorSplitContainer.Panel1.ResumeLayout(false);
            this.editorSplitContainer.Panel1.PerformLayout();
            this.editorSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.editorSplitContainer)).EndInit();
            this.editorSplitContainer.ResumeLayout(false);
            this.editorTabControl.ResumeLayout(false);
            this.tabPageEditStep.ResumeLayout(false);
            this.groupBoxSpecification.ResumeLayout(false);
            this.groupBoxSpecification.PerformLayout();
            this.groupBoxTestFunctionParams.ResumeLayout(false);
            this.groupBoxTestFunctionParams.PerformLayout();
            this.groupBoxBasicTestStepInfo.ResumeLayout(false);
            this.groupBoxBasicTestStepInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip sequenceEditorToolStrip;
        private System.Windows.Forms.ToolStripButton toolStripBtnNew;
        private System.Windows.Forms.ToolStripButton toolStripBtnOpen;
        private System.Windows.Forms.ToolStripButton toolStripBtnSave;
        private System.Windows.Forms.ToolStripButton toolStripBtnSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripBtnRefresh;
        private System.Windows.Forms.ToolStripButton toolStripBtnCopyStep;
        private System.Windows.Forms.ToolStripButton toolStripBtnCutStep;
        private System.Windows.Forms.ToolStripButton toolStripBtnPasteStep;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxSequenceFilePath;
        private System.Windows.Forms.SplitContainer editorSplitContainer;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label labelItemList;
        private System.Windows.Forms.TabControl editorTabControl;
        private System.Windows.Forms.TabPage tabPageEditStep;
        private System.Windows.Forms.GroupBox groupBoxBasicTestStepInfo;
        private System.Windows.Forms.TextBox textBoxStepDescription;
        private System.Windows.Forms.TextBox textBoxStepName;
        private System.Windows.Forms.TextBox textBoxStepNo;
        private System.Windows.Forms.Label labelStepDescription;
        private System.Windows.Forms.Label labelStepName;
        private System.Windows.Forms.Label labelStepNo;
        private System.Windows.Forms.GroupBox groupBoxTestFunctionParams;
        private System.Windows.Forms.Label labelTestFunctionName;
        private System.Windows.Forms.ComboBox comboBoxTestFunctionName;
        private System.Windows.Forms.Label labelParameters;
        private System.Windows.Forms.TextBox textBoxParameter3;
        private System.Windows.Forms.TextBox textBoxParameter2;
        private System.Windows.Forms.TextBox textBoxParameter1;
        private System.Windows.Forms.TextBox textBoxParameter6;
        private System.Windows.Forms.TextBox textBoxParameter5;
        private System.Windows.Forms.TextBox textBoxParameter4;
        private System.Windows.Forms.GroupBox groupBoxSpecification;
        private System.Windows.Forms.Label labelLimitType;
        private System.Windows.Forms.ComboBox comboBoxLimitType;
        private System.Windows.Forms.ListView listViewTestSepc;
        private System.Windows.Forms.ColumnHeader columnHeaderLowerLimit;
        private System.Windows.Forms.ColumnHeader columnHeaderTypical;
        private System.Windows.Forms.ColumnHeader columnHeaderUpperLimit;
        private System.Windows.Forms.ColumnHeader columnHeaderResult;
    }
}
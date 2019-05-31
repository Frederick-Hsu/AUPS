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
            this.components = new System.ComponentModel.Container();
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
            this.treeViewSequence = new System.Windows.Forms.TreeView();
            this.sequenceTreeContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewBlockAfterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewBlockBeforeBlockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeCurrentSelectedBlockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sequenceToolStripMenuItemSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addNewStepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewStepBeforeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeCurrentSelectedStepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyCurrentSelectedStepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutCurrentSelectedStepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteStepAfterCurrentSelectedStepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelItemList = new System.Windows.Forms.Label();
            this.editorTabControl = new System.Windows.Forms.TabControl();
            this.tabPageEditStep = new System.Windows.Forms.TabPage();
            this.groupBoxBlockInfo = new System.Windows.Forms.GroupBox();
            this.textBoxBlockName = new System.Windows.Forms.TextBox();
            this.labelBlockName = new System.Windows.Forms.Label();
            this.textBoxBlockNum = new System.Windows.Forms.TextBox();
            this.labelBlockNo = new System.Windows.Forms.Label();
            this.groupBoxSpecification = new System.Windows.Forms.GroupBox();
            this.dataGridViewTestSpec = new System.Windows.Forms.DataGridView();
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
            this.toolTipHints = new System.Windows.Forms.ToolTip(this.components);
            this.sequenceEditorToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editorSplitContainer)).BeginInit();
            this.editorSplitContainer.Panel1.SuspendLayout();
            this.editorSplitContainer.Panel2.SuspendLayout();
            this.editorSplitContainer.SuspendLayout();
            this.sequenceTreeContextMenuStrip.SuspendLayout();
            this.editorTabControl.SuspendLayout();
            this.tabPageEditStep.SuspendLayout();
            this.groupBoxBlockInfo.SuspendLayout();
            this.groupBoxSpecification.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTestSpec)).BeginInit();
            this.groupBoxTestFunctionParams.SuspendLayout();
            this.groupBoxBasicTestStepInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // sequenceEditorToolStrip
            // 
            this.sequenceEditorToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
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
            this.sequenceEditorToolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.sequenceEditorToolStrip.Size = new System.Drawing.Size(1784, 52);
            this.sequenceEditorToolStrip.TabIndex = 1;
            this.sequenceEditorToolStrip.Text = "toolStrip1";
            // 
            // toolStripBtnNew
            // 
            this.toolStripBtnNew.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnNew.Image")));
            this.toolStripBtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnNew.Name = "toolStripBtnNew";
            this.toolStripBtnNew.Size = new System.Drawing.Size(51, 49);
            this.toolStripBtnNew.Text = "New";
            this.toolStripBtnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripBtnNew.Click += new System.EventHandler(this.toolStripBtnNew_Click);
            // 
            // toolStripBtnOpen
            // 
            this.toolStripBtnOpen.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnOpen.Image")));
            this.toolStripBtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnOpen.Name = "toolStripBtnOpen";
            this.toolStripBtnOpen.Size = new System.Drawing.Size(60, 49);
            this.toolStripBtnOpen.Text = "Open";
            this.toolStripBtnOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripBtnOpen.Click += new System.EventHandler(this.toolStripBtnOpen_Click);
            // 
            // toolStripBtnSave
            // 
            this.toolStripBtnSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnSave.Image")));
            this.toolStripBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnSave.Name = "toolStripBtnSave";
            this.toolStripBtnSave.Size = new System.Drawing.Size(53, 49);
            this.toolStripBtnSave.Text = "Save";
            this.toolStripBtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripBtnSave.Click += new System.EventHandler(this.toolStripBtnSave_Click);
            // 
            // toolStripBtnSaveAs
            // 
            this.toolStripBtnSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnSaveAs.Image")));
            this.toolStripBtnSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnSaveAs.Name = "toolStripBtnSaveAs";
            this.toolStripBtnSaveAs.Size = new System.Drawing.Size(78, 49);
            this.toolStripBtnSaveAs.Text = "Save As";
            this.toolStripBtnSaveAs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripBtnSaveAs.Click += new System.EventHandler(this.toolStripBtnSaveAs_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 52);
            // 
            // toolStripBtnRefresh
            // 
            this.toolStripBtnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnRefresh.Image")));
            this.toolStripBtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnRefresh.Name = "toolStripBtnRefresh";
            this.toolStripBtnRefresh.Size = new System.Drawing.Size(74, 49);
            this.toolStripBtnRefresh.Text = "Refresh";
            this.toolStripBtnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripBtnCopyStep
            // 
            this.toolStripBtnCopyStep.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnCopyStep.Image")));
            this.toolStripBtnCopyStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnCopyStep.Name = "toolStripBtnCopyStep";
            this.toolStripBtnCopyStep.Size = new System.Drawing.Size(97, 49);
            this.toolStripBtnCopyStep.Text = "Copy step";
            this.toolStripBtnCopyStep.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripBtnCopyStep.Click += new System.EventHandler(this.toolStripBtnCopyStep_Click);
            // 
            // toolStripBtnCutStep
            // 
            this.toolStripBtnCutStep.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnCutStep.Image")));
            this.toolStripBtnCutStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnCutStep.Name = "toolStripBtnCutStep";
            this.toolStripBtnCutStep.Size = new System.Drawing.Size(82, 49);
            this.toolStripBtnCutStep.Text = "Cut step";
            this.toolStripBtnCutStep.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripBtnCutStep.Click += new System.EventHandler(this.toolStripBtnCutStep_Click);
            // 
            // toolStripBtnPasteStep
            // 
            this.toolStripBtnPasteStep.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnPasteStep.Image")));
            this.toolStripBtnPasteStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnPasteStep.Name = "toolStripBtnPasteStep";
            this.toolStripBtnPasteStep.Size = new System.Drawing.Size(96, 49);
            this.toolStripBtnPasteStep.Text = "Paste step";
            this.toolStripBtnPasteStep.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripBtnPasteStep.Click += new System.EventHandler(this.toolStripBtnPasteStep_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 52);
            // 
            // toolStripTextBoxSequenceFilePath
            // 
            this.toolStripTextBoxSequenceFilePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBoxSequenceFilePath.Name = "toolStripTextBoxSequenceFilePath";
            this.toolStripTextBoxSequenceFilePath.ReadOnly = true;
            this.toolStripTextBoxSequenceFilePath.Size = new System.Drawing.Size(749, 52);
            // 
            // editorSplitContainer
            // 
            this.editorSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorSplitContainer.Location = new System.Drawing.Point(0, 52);
            this.editorSplitContainer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.editorSplitContainer.Name = "editorSplitContainer";
            // 
            // editorSplitContainer.Panel1
            // 
            this.editorSplitContainer.Panel1.Controls.Add(this.treeViewSequence);
            this.editorSplitContainer.Panel1.Controls.Add(this.labelItemList);
            // 
            // editorSplitContainer.Panel2
            // 
            this.editorSplitContainer.Panel2.Controls.Add(this.editorTabControl);
            this.editorSplitContainer.Size = new System.Drawing.Size(1784, 950);
            this.editorSplitContainer.SplitterDistance = 396;
            this.editorSplitContainer.SplitterWidth = 6;
            this.editorSplitContainer.TabIndex = 2;
            // 
            // treeViewSequence
            // 
            this.treeViewSequence.ContextMenuStrip = this.sequenceTreeContextMenuStrip;
            this.treeViewSequence.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewSequence.LabelEdit = true;
            this.treeViewSequence.Location = new System.Drawing.Point(0, 20);
            this.treeViewSequence.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.treeViewSequence.Name = "treeViewSequence";
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
            this.treeViewSequence.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode7});
            this.treeViewSequence.ShowNodeToolTips = true;
            this.treeViewSequence.Size = new System.Drawing.Size(396, 930);
            this.treeViewSequence.TabIndex = 3;
            this.treeViewSequence.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeViewSequence_AfterLabelEdit);
            this.treeViewSequence.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewSequence_AfterSelect);
            // 
            // sequenceTreeContextMenuStrip
            // 
            this.sequenceTreeContextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.sequenceTreeContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewBlockAfterToolStripMenuItem,
            this.addNewBlockBeforeBlockToolStripMenuItem,
            this.removeCurrentSelectedBlockToolStripMenuItem,
            this.sequenceToolStripMenuItemSeparator1,
            this.addNewStepToolStripMenuItem,
            this.addNewStepBeforeToolStripMenuItem,
            this.removeCurrentSelectedStepToolStripMenuItem,
            this.copyCurrentSelectedStepToolStripMenuItem,
            this.cutCurrentSelectedStepToolStripMenuItem,
            this.pasteStepAfterCurrentSelectedStepToolStripMenuItem});
            this.sequenceTreeContextMenuStrip.Name = "sequenceTreeContextMenuStrip";
            this.sequenceTreeContextMenuStrip.Size = new System.Drawing.Size(452, 280);
            // 
            // addNewBlockAfterToolStripMenuItem
            // 
            this.addNewBlockAfterToolStripMenuItem.Name = "addNewBlockAfterToolStripMenuItem";
            this.addNewBlockAfterToolStripMenuItem.Size = new System.Drawing.Size(451, 30);
            this.addNewBlockAfterToolStripMenuItem.Text = "Add a new block after current selected block";
            this.addNewBlockAfterToolStripMenuItem.Click += new System.EventHandler(this.addNewBlockAfterToolStripMenuItem_Click);
            // 
            // addNewBlockBeforeBlockToolStripMenuItem
            // 
            this.addNewBlockBeforeBlockToolStripMenuItem.Name = "addNewBlockBeforeBlockToolStripMenuItem";
            this.addNewBlockBeforeBlockToolStripMenuItem.Size = new System.Drawing.Size(451, 30);
            this.addNewBlockBeforeBlockToolStripMenuItem.Text = "Add a new block before current selected block";
            this.addNewBlockBeforeBlockToolStripMenuItem.Click += new System.EventHandler(this.addNewBlockBeforeBlockToolStripMenuItem_Click);
            // 
            // removeCurrentSelectedBlockToolStripMenuItem
            // 
            this.removeCurrentSelectedBlockToolStripMenuItem.Name = "removeCurrentSelectedBlockToolStripMenuItem";
            this.removeCurrentSelectedBlockToolStripMenuItem.Size = new System.Drawing.Size(451, 30);
            this.removeCurrentSelectedBlockToolStripMenuItem.Text = "Remove current selected block";
            this.removeCurrentSelectedBlockToolStripMenuItem.Click += new System.EventHandler(this.removeCurrentSelectedBlockToolStripMenuItem_Click);
            // 
            // sequenceToolStripMenuItemSeparator1
            // 
            this.sequenceToolStripMenuItemSeparator1.Name = "sequenceToolStripMenuItemSeparator1";
            this.sequenceToolStripMenuItemSeparator1.Size = new System.Drawing.Size(448, 6);
            // 
            // addNewStepToolStripMenuItem
            // 
            this.addNewStepToolStripMenuItem.Name = "addNewStepToolStripMenuItem";
            this.addNewStepToolStripMenuItem.Size = new System.Drawing.Size(451, 30);
            this.addNewStepToolStripMenuItem.Text = "Add new step";
            this.addNewStepToolStripMenuItem.Click += new System.EventHandler(this.addNewStepToolStripMenuItem_Click);
            // 
            // addNewStepBeforeToolStripMenuItem
            // 
            this.addNewStepBeforeToolStripMenuItem.Name = "addNewStepBeforeToolStripMenuItem";
            this.addNewStepBeforeToolStripMenuItem.Size = new System.Drawing.Size(451, 30);
            this.addNewStepBeforeToolStripMenuItem.Text = "Add a new step before current selected step";
            this.addNewStepBeforeToolStripMenuItem.Click += new System.EventHandler(this.addNewStepBeforeToolStripMenuItem_Click);
            // 
            // removeCurrentSelectedStepToolStripMenuItem
            // 
            this.removeCurrentSelectedStepToolStripMenuItem.Name = "removeCurrentSelectedStepToolStripMenuItem";
            this.removeCurrentSelectedStepToolStripMenuItem.Size = new System.Drawing.Size(451, 30);
            this.removeCurrentSelectedStepToolStripMenuItem.Text = "Remove current selected step";
            this.removeCurrentSelectedStepToolStripMenuItem.Click += new System.EventHandler(this.removeCurrentSelectedStepToolStripMenuItem_Click);
            // 
            // copyCurrentSelectedStepToolStripMenuItem
            // 
            this.copyCurrentSelectedStepToolStripMenuItem.Name = "copyCurrentSelectedStepToolStripMenuItem";
            this.copyCurrentSelectedStepToolStripMenuItem.Size = new System.Drawing.Size(451, 30);
            this.copyCurrentSelectedStepToolStripMenuItem.Text = "Copy current selected step";
            this.copyCurrentSelectedStepToolStripMenuItem.Click += new System.EventHandler(this.copyCurrentSelectedStepToolStripMenuItem_Click);
            // 
            // cutCurrentSelectedStepToolStripMenuItem
            // 
            this.cutCurrentSelectedStepToolStripMenuItem.Name = "cutCurrentSelectedStepToolStripMenuItem";
            this.cutCurrentSelectedStepToolStripMenuItem.Size = new System.Drawing.Size(451, 30);
            this.cutCurrentSelectedStepToolStripMenuItem.Text = "Cut current selected step";
            this.cutCurrentSelectedStepToolStripMenuItem.Click += new System.EventHandler(this.cutCurrentSelectedStepToolStripMenuItem_Click);
            // 
            // pasteStepAfterCurrentSelectedStepToolStripMenuItem
            // 
            this.pasteStepAfterCurrentSelectedStepToolStripMenuItem.Name = "pasteStepAfterCurrentSelectedStepToolStripMenuItem";
            this.pasteStepAfterCurrentSelectedStepToolStripMenuItem.Size = new System.Drawing.Size(451, 30);
            this.pasteStepAfterCurrentSelectedStepToolStripMenuItem.Text = "Paste step after current selected step";
            this.pasteStepAfterCurrentSelectedStepToolStripMenuItem.Click += new System.EventHandler(this.pasteStepAfterCurrentSelectedStepToolStripMenuItem_Click);
            // 
            // labelItemList
            // 
            this.labelItemList.AutoSize = true;
            this.labelItemList.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelItemList.Location = new System.Drawing.Point(0, 0);
            this.labelItemList.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelItemList.Name = "labelItemList";
            this.labelItemList.Size = new System.Drawing.Size(171, 20);
            this.labelItemList.TabIndex = 4;
            this.labelItemList.Text = "Test sequence item list";
            // 
            // editorTabControl
            // 
            this.editorTabControl.Controls.Add(this.tabPageEditStep);
            this.editorTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorTabControl.Location = new System.Drawing.Point(0, 0);
            this.editorTabControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.editorTabControl.Name = "editorTabControl";
            this.editorTabControl.SelectedIndex = 0;
            this.editorTabControl.Size = new System.Drawing.Size(1382, 950);
            this.editorTabControl.TabIndex = 3;
            // 
            // tabPageEditStep
            // 
            this.tabPageEditStep.Controls.Add(this.groupBoxBlockInfo);
            this.tabPageEditStep.Controls.Add(this.groupBoxSpecification);
            this.tabPageEditStep.Controls.Add(this.groupBoxTestFunctionParams);
            this.tabPageEditStep.Controls.Add(this.groupBoxBasicTestStepInfo);
            this.tabPageEditStep.Location = new System.Drawing.Point(4, 29);
            this.tabPageEditStep.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageEditStep.Name = "tabPageEditStep";
            this.tabPageEditStep.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageEditStep.Size = new System.Drawing.Size(1374, 917);
            this.tabPageEditStep.TabIndex = 0;
            this.tabPageEditStep.Text = "Edit step";
            this.tabPageEditStep.UseVisualStyleBackColor = true;
            // 
            // groupBoxBlockInfo
            // 
            this.groupBoxBlockInfo.Controls.Add(this.textBoxBlockName);
            this.groupBoxBlockInfo.Controls.Add(this.labelBlockName);
            this.groupBoxBlockInfo.Controls.Add(this.textBoxBlockNum);
            this.groupBoxBlockInfo.Controls.Add(this.labelBlockNo);
            this.groupBoxBlockInfo.Location = new System.Drawing.Point(16, 8);
            this.groupBoxBlockInfo.Name = "groupBoxBlockInfo";
            this.groupBoxBlockInfo.Size = new System.Drawing.Size(1332, 71);
            this.groupBoxBlockInfo.TabIndex = 3;
            this.groupBoxBlockInfo.TabStop = false;
            // 
            // textBoxBlockName
            // 
            this.textBoxBlockName.Location = new System.Drawing.Point(548, 28);
            this.textBoxBlockName.Name = "textBoxBlockName";
            this.textBoxBlockName.Size = new System.Drawing.Size(774, 26);
            this.textBoxBlockName.TabIndex = 9;
            this.textBoxBlockName.Text = "First block, please edit your block name";
            this.textBoxBlockName.TextChanged += new System.EventHandler(this.textBoxBlockName_TextChanged);
            // 
            // labelBlockName
            // 
            this.labelBlockName.AutoSize = true;
            this.labelBlockName.Location = new System.Drawing.Point(435, 32);
            this.labelBlockName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBlockName.Name = "labelBlockName";
            this.labelBlockName.Size = new System.Drawing.Size(106, 20);
            this.labelBlockName.TabIndex = 8;
            this.labelBlockName.Text = "Block Name : ";
            // 
            // textBoxBlockNum
            // 
            this.textBoxBlockNum.Location = new System.Drawing.Point(162, 29);
            this.textBoxBlockNum.Name = "textBoxBlockNum";
            this.textBoxBlockNum.Size = new System.Drawing.Size(228, 26);
            this.textBoxBlockNum.TabIndex = 7;
            this.textBoxBlockNum.Text = "B1";
            // 
            // labelBlockNo
            // 
            this.labelBlockNo.AutoSize = true;
            this.labelBlockNo.Location = new System.Drawing.Point(16, 32);
            this.labelBlockNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBlockNo.Name = "labelBlockNo";
            this.labelBlockNo.Size = new System.Drawing.Size(88, 20);
            this.labelBlockNo.TabIndex = 6;
            this.labelBlockNo.Text = "Block No. : ";
            // 
            // groupBoxSpecification
            // 
            this.groupBoxSpecification.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSpecification.Controls.Add(this.dataGridViewTestSpec);
            this.groupBoxSpecification.Controls.Add(this.comboBoxLimitType);
            this.groupBoxSpecification.Controls.Add(this.labelLimitType);
            this.groupBoxSpecification.Location = new System.Drawing.Point(10, 500);
            this.groupBoxSpecification.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxSpecification.Name = "groupBoxSpecification";
            this.groupBoxSpecification.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxSpecification.Size = new System.Drawing.Size(1347, 194);
            this.groupBoxSpecification.TabIndex = 2;
            this.groupBoxSpecification.TabStop = false;
            this.groupBoxSpecification.Text = "Specification";
            // 
            // dataGridViewTestSpec
            // 
            this.dataGridViewTestSpec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTestSpec.Location = new System.Drawing.Point(8, 55);
            this.dataGridViewTestSpec.Name = "dataGridViewTestSpec";
            this.dataGridViewTestSpec.RowTemplate.Height = 28;
            this.dataGridViewTestSpec.Size = new System.Drawing.Size(1332, 131);
            this.dataGridViewTestSpec.TabIndex = 3;
            // 
            // comboBoxLimitType
            // 
            this.comboBoxLimitType.FormattingEnabled = true;
            this.comboBoxLimitType.Items.AddRange(new object[] {
            "Numerical",
            "String"});
            this.comboBoxLimitType.Location = new System.Drawing.Point(962, 18);
            this.comboBoxLimitType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxLimitType.Name = "comboBoxLimitType";
            this.comboBoxLimitType.Size = new System.Drawing.Size(373, 28);
            this.comboBoxLimitType.TabIndex = 1;
            this.comboBoxLimitType.SelectedIndexChanged += new System.EventHandler(this.comboBoxLimitType_SelectedIndexChanged);
            // 
            // labelLimitType
            // 
            this.labelLimitType.AutoSize = true;
            this.labelLimitType.Location = new System.Drawing.Point(822, 22);
            this.labelLimitType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLimitType.Name = "labelLimitType";
            this.labelLimitType.Size = new System.Drawing.Size(88, 20);
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
            this.groupBoxTestFunctionParams.Location = new System.Drawing.Point(9, 283);
            this.groupBoxTestFunctionParams.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxTestFunctionParams.Name = "groupBoxTestFunctionParams";
            this.groupBoxTestFunctionParams.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxTestFunctionParams.Size = new System.Drawing.Size(1348, 208);
            this.groupBoxTestFunctionParams.TabIndex = 1;
            this.groupBoxTestFunctionParams.TabStop = false;
            // 
            // textBoxParameter6
            // 
            this.textBoxParameter6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxParameter6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxParameter6.Location = new System.Drawing.Point(962, 142);
            this.textBoxParameter6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxParameter6.Name = "textBoxParameter6";
            this.textBoxParameter6.Size = new System.Drawing.Size(376, 26);
            this.textBoxParameter6.TabIndex = 8;
            // 
            // textBoxParameter5
            // 
            this.textBoxParameter5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxParameter5.Location = new System.Drawing.Point(567, 142);
            this.textBoxParameter5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxParameter5.Name = "textBoxParameter5";
            this.textBoxParameter5.Size = new System.Drawing.Size(374, 26);
            this.textBoxParameter5.TabIndex = 7;
            // 
            // textBoxParameter4
            // 
            this.textBoxParameter4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxParameter4.Location = new System.Drawing.Point(170, 142);
            this.textBoxParameter4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxParameter4.Name = "textBoxParameter4";
            this.textBoxParameter4.Size = new System.Drawing.Size(374, 26);
            this.textBoxParameter4.TabIndex = 6;
            this.textBoxParameter4.Text = "STOP:1";
            // 
            // textBoxParameter3
            // 
            this.textBoxParameter3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxParameter3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxParameter3.Location = new System.Drawing.Point(963, 88);
            this.textBoxParameter3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxParameter3.Name = "textBoxParameter3";
            this.textBoxParameter3.Size = new System.Drawing.Size(376, 26);
            this.textBoxParameter3.TabIndex = 5;
            this.textBoxParameter3.Text = "LEN:8";
            // 
            // textBoxParameter2
            // 
            this.textBoxParameter2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxParameter2.Location = new System.Drawing.Point(567, 88);
            this.textBoxParameter2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxParameter2.Name = "textBoxParameter2";
            this.textBoxParameter2.Size = new System.Drawing.Size(374, 26);
            this.textBoxParameter2.TabIndex = 4;
            this.textBoxParameter2.Text = "BAUD:115200";
            // 
            // textBoxParameter1
            // 
            this.textBoxParameter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxParameter1.Location = new System.Drawing.Point(170, 88);
            this.textBoxParameter1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxParameter1.Name = "textBoxParameter1";
            this.textBoxParameter1.Size = new System.Drawing.Size(374, 26);
            this.textBoxParameter1.TabIndex = 3;
            this.textBoxParameter1.Text = "COM:1";
            // 
            // labelParameters
            // 
            this.labelParameters.AutoSize = true;
            this.labelParameters.Location = new System.Drawing.Point(24, 98);
            this.labelParameters.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelParameters.Name = "labelParameters";
            this.labelParameters.Size = new System.Drawing.Size(124, 20);
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
            this.comboBoxTestFunctionName.Location = new System.Drawing.Point(170, 38);
            this.comboBoxTestFunctionName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxTestFunctionName.Name = "comboBoxTestFunctionName";
            this.comboBoxTestFunctionName.Size = new System.Drawing.Size(1162, 28);
            this.comboBoxTestFunctionName.TabIndex = 1;
            this.comboBoxTestFunctionName.SelectedIndexChanged += new System.EventHandler(this.comboBoxTestFunctionName_SelectedIndexChanged);
            // 
            // labelTestFunctionName
            // 
            this.labelTestFunctionName.AutoSize = true;
            this.labelTestFunctionName.Location = new System.Drawing.Point(20, 38);
            this.labelTestFunctionName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTestFunctionName.Name = "labelTestFunctionName";
            this.labelTestFunctionName.Size = new System.Drawing.Size(129, 20);
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
            this.groupBoxBasicTestStepInfo.Location = new System.Drawing.Point(9, 88);
            this.groupBoxBasicTestStepInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxBasicTestStepInfo.Name = "groupBoxBasicTestStepInfo";
            this.groupBoxBasicTestStepInfo.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxBasicTestStepInfo.Size = new System.Drawing.Size(852, 186);
            this.groupBoxBasicTestStepInfo.TabIndex = 0;
            this.groupBoxBasicTestStepInfo.TabStop = false;
            // 
            // textBoxStepDescription
            // 
            this.textBoxStepDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStepDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxStepDescription.Location = new System.Drawing.Point(170, 131);
            this.textBoxStepDescription.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxStepDescription.Name = "textBoxStepDescription";
            this.textBoxStepDescription.Size = new System.Drawing.Size(666, 26);
            this.textBoxStepDescription.TabIndex = 5;
            this.textBoxStepDescription.Text = "Open the COM port to intialize the network analyzer";
            // 
            // textBoxStepName
            // 
            this.textBoxStepName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStepName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxStepName.Location = new System.Drawing.Point(170, 82);
            this.textBoxStepName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxStepName.Name = "textBoxStepName";
            this.textBoxStepName.Size = new System.Drawing.Size(666, 26);
            this.textBoxStepName.TabIndex = 4;
            this.textBoxStepName.Text = "First step, please edit your step name";
            this.textBoxStepName.TextChanged += new System.EventHandler(this.textBoxStepName_TextChanged);
            // 
            // textBoxStepNo
            // 
            this.textBoxStepNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStepNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxStepNo.Location = new System.Drawing.Point(170, 26);
            this.textBoxStepNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxStepNo.Name = "textBoxStepNo";
            this.textBoxStepNo.Size = new System.Drawing.Size(666, 26);
            this.textBoxStepNo.TabIndex = 3;
            this.textBoxStepNo.Text = "1.1";
            // 
            // labelStepDescription
            // 
            this.labelStepDescription.AutoSize = true;
            this.labelStepDescription.Location = new System.Drawing.Point(20, 131);
            this.labelStepDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStepDescription.Name = "labelStepDescription";
            this.labelStepDescription.Size = new System.Drawing.Size(139, 20);
            this.labelStepDescription.TabIndex = 2;
            this.labelStepDescription.Text = "Step Description : ";
            // 
            // labelStepName
            // 
            this.labelStepName.AutoSize = true;
            this.labelStepName.Location = new System.Drawing.Point(20, 82);
            this.labelStepName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStepName.Name = "labelStepName";
            this.labelStepName.Size = new System.Drawing.Size(101, 20);
            this.labelStepName.TabIndex = 1;
            this.labelStepName.Text = "Step Name : ";
            // 
            // labelStepNo
            // 
            this.labelStepNo.AutoSize = true;
            this.labelStepNo.Location = new System.Drawing.Point(20, 31);
            this.labelStepNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStepNo.Name = "labelStepNo";
            this.labelStepNo.Size = new System.Drawing.Size(83, 20);
            this.labelStepNo.TabIndex = 0;
            this.labelStepNo.Text = "Step No. : ";
            // 
            // SequenceEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1784, 1002);
            this.Controls.Add(this.editorSplitContainer);
            this.Controls.Add(this.sequenceEditorToolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SequenceEditor";
            this.Text = "Sequence Editor";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SequenceEditor_KeyDown);
            this.sequenceEditorToolStrip.ResumeLayout(false);
            this.sequenceEditorToolStrip.PerformLayout();
            this.editorSplitContainer.Panel1.ResumeLayout(false);
            this.editorSplitContainer.Panel1.PerformLayout();
            this.editorSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.editorSplitContainer)).EndInit();
            this.editorSplitContainer.ResumeLayout(false);
            this.sequenceTreeContextMenuStrip.ResumeLayout(false);
            this.editorTabControl.ResumeLayout(false);
            this.tabPageEditStep.ResumeLayout(false);
            this.groupBoxBlockInfo.ResumeLayout(false);
            this.groupBoxBlockInfo.PerformLayout();
            this.groupBoxSpecification.ResumeLayout(false);
            this.groupBoxSpecification.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTestSpec)).EndInit();
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
        private System.Windows.Forms.TreeView treeViewSequence;
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
        private System.Windows.Forms.DataGridView dataGridViewTestSpec;
        private System.Windows.Forms.ContextMenuStrip sequenceTreeContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addNewBlockAfterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeCurrentSelectedBlockToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator sequenceToolStripMenuItemSeparator1;
        private System.Windows.Forms.ToolStripMenuItem addNewStepToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeCurrentSelectedStepToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyCurrentSelectedStepToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutCurrentSelectedStepToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteStepAfterCurrentSelectedStepToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBoxBlockInfo;
        private System.Windows.Forms.Label labelBlockNo;
        private System.Windows.Forms.TextBox textBoxBlockNum;
        private System.Windows.Forms.Label labelBlockName;
        private System.Windows.Forms.TextBox textBoxBlockName;
        private System.Windows.Forms.ToolStripMenuItem addNewBlockBeforeBlockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewStepBeforeToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTipHints;
    }
}
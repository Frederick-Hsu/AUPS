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
            this.cellToolStrip = new System.Windows.Forms.ToolStrip();
            this.cellStatusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripBtnSettings = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripComboBoxManualAuto = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripStatusLabelBasic = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelItemInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelElapsedTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControlTestStation = new System.Windows.Forms.TabControl();
            this.tabPageHome = new System.Windows.Forms.TabPage();
            this.tabPageLog = new System.Windows.Forms.TabPage();
            this.labelCellNumber = new System.Windows.Forms.Label();
            this.labelStationName = new System.Windows.Forms.Label();
            this.labelIndicator = new System.Windows.Forms.Label();
            this.progressBarTestProgress = new System.Windows.Forms.ProgressBar();
            this.groupBoxStartEnd = new System.Windows.Forms.GroupBox();
            this.listViewTestItems = new System.Windows.Forms.ListView();
            this.labelSerialNum = new System.Windows.Forms.Label();
            this.textBoxSerialNum = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.columnHeaderSeqNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTestItem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderConclusion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBoxTestLog = new System.Windows.Forms.TextBox();
            this.cellToolStrip.SuspendLayout();
            this.cellStatusStrip.SuspendLayout();
            this.tabControlTestStation.SuspendLayout();
            this.tabPageHome.SuspendLayout();
            this.tabPageLog.SuspendLayout();
            this.groupBoxStartEnd.SuspendLayout();
            this.SuspendLayout();
            // 
            // cellToolStrip
            // 
            this.cellToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cellToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnSettings,
            this.toolStripSeparator1,
            this.toolStripComboBoxManualAuto});
            this.cellToolStrip.Location = new System.Drawing.Point(0, 0);
            this.cellToolStrip.Name = "cellToolStrip";
            this.cellToolStrip.Size = new System.Drawing.Size(1221, 47);
            this.cellToolStrip.TabIndex = 0;
            this.cellToolStrip.Text = "toolStrip1";
            // 
            // cellStatusStrip
            // 
            this.cellStatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cellStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelBasic,
            this.toolStripStatusLabelItemInfo,
            this.toolStripStatusLabelElapsedTime});
            this.cellStatusStrip.Location = new System.Drawing.Point(0, 901);
            this.cellStatusStrip.Name = "cellStatusStrip";
            this.cellStatusStrip.Size = new System.Drawing.Size(1221, 29);
            this.cellStatusStrip.TabIndex = 1;
            this.cellStatusStrip.Text = "statusStrip1";
            // 
            // toolStripBtnSettings
            // 
            this.toolStripBtnSettings.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnSettings.Image")));
            this.toolStripBtnSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnSettings.Name = "toolStripBtnSettings";
            this.toolStripBtnSettings.Size = new System.Drawing.Size(66, 44);
            this.toolStripBtnSettings.Text = "Settings";
            this.toolStripBtnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 47);
            // 
            // toolStripComboBoxManualAuto
            // 
            this.toolStripComboBoxManualAuto.Items.AddRange(new object[] {
            "Manual",
            "Auto"});
            this.toolStripComboBoxManualAuto.Name = "toolStripComboBoxManualAuto";
            this.toolStripComboBoxManualAuto.Size = new System.Drawing.Size(200, 47);
            this.toolStripComboBoxManualAuto.Text = "Select your mode here";
            this.toolStripComboBoxManualAuto.ToolTipText = "Switch between Manual and Auto mode";
            // 
            // toolStripStatusLabelBasic
            // 
            this.toolStripStatusLabelBasic.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.toolStripStatusLabelBasic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabelBasic.Name = "toolStripStatusLabelBasic";
            this.toolStripStatusLabelBasic.Size = new System.Drawing.Size(402, 24);
            this.toolStripStatusLabelBasic.Spring = true;
            this.toolStripStatusLabelBasic.Text = "Current status";
            this.toolStripStatusLabelBasic.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabelItemInfo
            // 
            this.toolStripStatusLabelItemInfo.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.toolStripStatusLabelItemInfo.Name = "toolStripStatusLabelItemInfo";
            this.toolStripStatusLabelItemInfo.Size = new System.Drawing.Size(402, 24);
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
            this.toolStripStatusLabelElapsedTime.Size = new System.Drawing.Size(402, 24);
            this.toolStripStatusLabelElapsedTime.Spring = true;
            this.toolStripStatusLabelElapsedTime.Text = "Elapsed time : ";
            this.toolStripStatusLabelElapsedTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabControlTestStation
            // 
            this.tabControlTestStation.Controls.Add(this.tabPageHome);
            this.tabControlTestStation.Controls.Add(this.tabPageLog);
            this.tabControlTestStation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlTestStation.Location = new System.Drawing.Point(0, 47);
            this.tabControlTestStation.Name = "tabControlTestStation";
            this.tabControlTestStation.SelectedIndex = 0;
            this.tabControlTestStation.Size = new System.Drawing.Size(1221, 854);
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
            this.tabPageHome.Location = new System.Drawing.Point(4, 25);
            this.tabPageHome.Name = "tabPageHome";
            this.tabPageHome.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHome.Size = new System.Drawing.Size(1213, 825);
            this.tabPageHome.TabIndex = 0;
            this.tabPageHome.Text = "Home";
            this.tabPageHome.UseVisualStyleBackColor = true;
            // 
            // tabPageLog
            // 
            this.tabPageLog.Controls.Add(this.textBoxTestLog);
            this.tabPageLog.Location = new System.Drawing.Point(4, 25);
            this.tabPageLog.Name = "tabPageLog";
            this.tabPageLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLog.Size = new System.Drawing.Size(1213, 825);
            this.tabPageLog.TabIndex = 1;
            this.tabPageLog.Text = "Log";
            this.tabPageLog.UseVisualStyleBackColor = true;
            // 
            // labelCellNumber
            // 
            this.labelCellNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelCellNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelCellNumber.Location = new System.Drawing.Point(7, 7);
            this.labelCellNumber.Name = "labelCellNumber";
            this.labelCellNumber.Size = new System.Drawing.Size(107, 115);
            this.labelCellNumber.TabIndex = 0;
            this.labelCellNumber.Text = "1";
            // 
            // labelStationName
            // 
            this.labelStationName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStationName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelStationName.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelStationName.Location = new System.Drawing.Point(120, 7);
            this.labelStationName.Name = "labelStationName";
            this.labelStationName.Size = new System.Drawing.Size(1085, 115);
            this.labelStationName.TabIndex = 1;
            this.labelStationName.Text = "Station Name";
            this.labelStationName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelIndicator
            // 
            this.labelIndicator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelIndicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelIndicator.ForeColor = System.Drawing.Color.Black;
            this.labelIndicator.Location = new System.Drawing.Point(7, 126);
            this.labelIndicator.Name = "labelIndicator";
            this.labelIndicator.Size = new System.Drawing.Size(1198, 141);
            this.labelIndicator.TabIndex = 2;
            this.labelIndicator.Text = "Ready";
            this.labelIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBarTestProgress
            // 
            this.progressBarTestProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarTestProgress.Location = new System.Drawing.Point(6, 796);
            this.progressBarTestProgress.Name = "progressBarTestProgress";
            this.progressBarTestProgress.Size = new System.Drawing.Size(1199, 23);
            this.progressBarTestProgress.TabIndex = 4;
            // 
            // groupBoxStartEnd
            // 
            this.groupBoxStartEnd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxStartEnd.Controls.Add(this.btnEnd);
            this.groupBoxStartEnd.Controls.Add(this.btnStart);
            this.groupBoxStartEnd.Controls.Add(this.textBoxSerialNum);
            this.groupBoxStartEnd.Controls.Add(this.labelSerialNum);
            this.groupBoxStartEnd.Location = new System.Drawing.Point(9, 690);
            this.groupBoxStartEnd.Name = "groupBoxStartEnd";
            this.groupBoxStartEnd.Size = new System.Drawing.Size(1201, 100);
            this.groupBoxStartEnd.TabIndex = 5;
            this.groupBoxStartEnd.TabStop = false;
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
            this.listViewTestItems.Location = new System.Drawing.Point(9, 270);
            this.listViewTestItems.MultiSelect = false;
            this.listViewTestItems.Name = "listViewTestItems";
            this.listViewTestItems.Size = new System.Drawing.Size(1196, 414);
            this.listViewTestItems.TabIndex = 6;
            this.listViewTestItems.UseCompatibleStateImageBehavior = false;
            this.listViewTestItems.View = System.Windows.Forms.View.Details;
            // 
            // labelSerialNum
            // 
            this.labelSerialNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSerialNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSerialNum.Location = new System.Drawing.Point(6, 18);
            this.labelSerialNum.Name = "labelSerialNum";
            this.labelSerialNum.Size = new System.Drawing.Size(282, 79);
            this.labelSerialNum.TabIndex = 0;
            this.labelSerialNum.Text = "Serial Number : ";
            this.labelSerialNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxSerialNum
            // 
            this.textBoxSerialNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxSerialNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxSerialNum.Location = new System.Drawing.Point(312, 35);
            this.textBoxSerialNum.Name = "textBoxSerialNum";
            this.textBoxSerialNum.Size = new System.Drawing.Size(467, 45);
            this.textBoxSerialNum.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.AutoSize = true;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStart.Location = new System.Drawing.Point(822, 31);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(176, 49);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "&Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnd.AutoSize = true;
            this.btnEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEnd.Location = new System.Drawing.Point(1019, 31);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(176, 49);
            this.btnEnd.TabIndex = 3;
            this.btnEnd.Text = "&End";
            this.btnEnd.UseVisualStyleBackColor = true;
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
            // textBoxTestLog
            // 
            this.textBoxTestLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTestLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxTestLog.Location = new System.Drawing.Point(3, 3);
            this.textBoxTestLog.Multiline = true;
            this.textBoxTestLog.Name = "textBoxTestLog";
            this.textBoxTestLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxTestLog.Size = new System.Drawing.Size(1207, 819);
            this.textBoxTestLog.TabIndex = 0;
            this.textBoxTestLog.Text = "This text box will display the complete test log.\r\n\r\nIt can display many lines of" +
    " string.";
            // 
            // TestPanel
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 930);
            this.Controls.Add(this.tabControlTestStation);
            this.Controls.Add(this.cellStatusStrip);
            this.Controls.Add(this.cellToolStrip);
            this.Name = "TestPanel";
            this.Text = "Test Panel";
            this.cellToolStrip.ResumeLayout(false);
            this.cellToolStrip.PerformLayout();
            this.cellStatusStrip.ResumeLayout(false);
            this.cellStatusStrip.PerformLayout();
            this.tabControlTestStation.ResumeLayout(false);
            this.tabPageHome.ResumeLayout(false);
            this.tabPageLog.ResumeLayout(false);
            this.tabPageLog.PerformLayout();
            this.groupBoxStartEnd.ResumeLayout(false);
            this.groupBoxStartEnd.PerformLayout();
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
    }
}
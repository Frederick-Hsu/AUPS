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
            this.tabPageResults = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelServerIP = new System.Windows.Forms.Label();
            this.textBoxServerIP = new System.Windows.Forms.TextBox();
            this.labelBandWidth = new System.Windows.Forms.Label();
            this.comboBoxBandWidth = new System.Windows.Forms.ComboBox();
            this.groupBoxTestPointsSetting.SuspendLayout();
            this.tabControlTesting.SuspendLayout();
            this.tabPageField.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCar)).BeginInit();
            this.tabPageIperfLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxTestPointsSetting
            // 
            this.groupBoxTestPointsSetting.AutoSize = true;
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
            this.tabPageIperfLog.Controls.Add(this.textBox1);
            this.tabPageIperfLog.Location = new System.Drawing.Point(4, 29);
            this.tabPageIperfLog.Name = "tabPageIperfLog";
            this.tabPageIperfLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageIperfLog.Size = new System.Drawing.Size(1574, 1286);
            this.tabPageIperfLog.TabIndex = 1;
            this.tabPageIperfLog.Text = "iPerf log";
            this.tabPageIperfLog.UseVisualStyleBackColor = true;
            // 
            // tabPageResults
            // 
            this.tabPageResults.Location = new System.Drawing.Point(4, 29);
            this.tabPageResults.Name = "tabPageResults";
            this.tabPageResults.Size = new System.Drawing.Size(1574, 1286);
            this.tabPageResults.TabIndex = 2;
            this.tabPageResults.Text = "Test results";
            this.tabPageResults.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(1568, 1280);
            this.textBox1.TabIndex = 0;
            // 
            // labelServerIP
            // 
            this.labelServerIP.AutoSize = true;
            this.labelServerIP.Location = new System.Drawing.Point(19, 537);
            this.labelServerIP.Name = "labelServerIP";
            this.labelServerIP.Size = new System.Drawing.Size(135, 20);
            this.labelServerIP.TabIndex = 11;
            this.labelServerIP.Text = "Server IP address";
            // 
            // textBoxServerIP
            // 
            this.textBoxServerIP.Location = new System.Drawing.Point(203, 537);
            this.textBoxServerIP.Name = "textBoxServerIP";
            this.textBoxServerIP.Size = new System.Drawing.Size(188, 26);
            this.textBoxServerIP.TabIndex = 12;
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
            // GMVehicleAntennaTesting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1979, 1319);
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelServerIP;
        private System.Windows.Forms.TextBox textBoxServerIP;
        private System.Windows.Forms.ComboBox comboBoxBandWidth;
        private System.Windows.Forms.Label labelBandWidth;
    }
}
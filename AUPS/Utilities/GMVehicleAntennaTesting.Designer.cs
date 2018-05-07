namespace AUPS.Utilities
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
            this.toolTipToDisplayInfo = new System.Windows.Forms.ToolTip(this.components);
            this.groupBoxTestPointsSetting = new System.Windows.Forms.GroupBox();
            this.textBoxChannel = new System.Windows.Forms.TextBox();
            this.btnDraw = new System.Windows.Forms.Button();
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
            this.tabPageIperfLog = new System.Windows.Forms.TabPage();
            this.groupBoxTestPointsSetting.SuspendLayout();
            this.tabControlTesting.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxTestPointsSetting
            // 
            this.groupBoxTestPointsSetting.Controls.Add(this.textBoxChannel);
            this.groupBoxTestPointsSetting.Controls.Add(this.btnDraw);
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
            this.groupBoxTestPointsSetting.Location = new System.Drawing.Point(12, 13);
            this.groupBoxTestPointsSetting.Name = "groupBoxTestPointsSetting";
            this.groupBoxTestPointsSetting.Size = new System.Drawing.Size(1428, 138);
            this.groupBoxTestPointsSetting.TabIndex = 1;
            this.groupBoxTestPointsSetting.TabStop = false;
            this.groupBoxTestPointsSetting.Text = "Testing points setting";
            // 
            // textBoxChannel
            // 
            this.textBoxChannel.Location = new System.Drawing.Point(697, 89);
            this.textBoxChannel.Name = "textBoxChannel";
            this.textBoxChannel.Size = new System.Drawing.Size(240, 26);
            this.textBoxChannel.TabIndex = 10;
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(988, 45);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(128, 72);
            this.btnDraw.TabIndex = 4;
            this.btnDraw.Text = "Draw line";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // labelChannel
            // 
            this.labelChannel.AutoSize = true;
            this.labelChannel.Location = new System.Drawing.Point(561, 89);
            this.labelChannel.Name = "labelChannel";
            this.labelChannel.Size = new System.Drawing.Size(108, 20);
            this.labelChannel.TabIndex = 9;
            this.labelChannel.Text = "Wi-Fi Channel";
            // 
            // textBoxFreqBand
            // 
            this.textBoxFreqBand.Location = new System.Drawing.Point(255, 86);
            this.textBoxFreqBand.Name = "textBoxFreqBand";
            this.textBoxFreqBand.Size = new System.Drawing.Size(240, 26);
            this.textBoxFreqBand.TabIndex = 8;
            // 
            // labelFreqBand
            // 
            this.labelFreqBand.AutoSize = true;
            this.labelFreqBand.Location = new System.Drawing.Point(15, 86);
            this.labelFreqBand.Name = "labelFreqBand";
            this.labelFreqBand.Size = new System.Drawing.Size(219, 20);
            this.labelFreqBand.TabIndex = 7;
            this.labelFreqBand.Text = "Frequency / Band (unit : MHz)";
            // 
            // btnNewPoint
            // 
            this.btnNewPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNewPoint.Location = new System.Drawing.Point(1159, 42);
            this.btnNewPoint.Name = "btnNewPoint";
            this.btnNewPoint.Size = new System.Drawing.Size(224, 74);
            this.btnNewPoint.TabIndex = 6;
            this.btnNewPoint.Text = "New Testing Point";
            this.btnNewPoint.UseVisualStyleBackColor = true;
            // 
            // textBoxHeight
            // 
            this.textBoxHeight.Location = new System.Drawing.Point(942, 42);
            this.textBoxHeight.Name = "textBoxHeight";
            this.textBoxHeight.Size = new System.Drawing.Size(188, 26);
            this.textBoxHeight.TabIndex = 5;
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Location = new System.Drawing.Point(795, 42);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(121, 20);
            this.labelHeight.TabIndex = 4;
            this.labelHeight.Text = "Height (unit : m)";
            // 
            // textBoxAngle
            // 
            this.textBoxAngle.Location = new System.Drawing.Point(532, 42);
            this.textBoxAngle.Name = "textBoxAngle";
            this.textBoxAngle.Size = new System.Drawing.Size(188, 26);
            this.textBoxAngle.TabIndex = 3;
            // 
            // labelAngle
            // 
            this.labelAngle.AutoSize = true;
            this.labelAngle.Location = new System.Drawing.Point(374, 42);
            this.labelAngle.Name = "labelAngle";
            this.labelAngle.Size = new System.Drawing.Size(152, 20);
            this.labelAngle.TabIndex = 2;
            this.labelAngle.Text = "Angle (unit : degree)";
            // 
            // textBoxRadius
            // 
            this.textBoxRadius.Location = new System.Drawing.Point(146, 38);
            this.textBoxRadius.Name = "textBoxRadius";
            this.textBoxRadius.Size = new System.Drawing.Size(188, 26);
            this.textBoxRadius.TabIndex = 1;
            // 
            // labelRadius
            // 
            this.labelRadius.AutoSize = true;
            this.labelRadius.Location = new System.Drawing.Point(15, 38);
            this.labelRadius.Name = "labelRadius";
            this.labelRadius.Size = new System.Drawing.Size(124, 20);
            this.labelRadius.TabIndex = 0;
            this.labelRadius.Text = "Radius (unit : m)";
            // 
            // tabControlTesting
            // 
            this.tabControlTesting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlTesting.Controls.Add(this.tabPageField);
            this.tabControlTesting.Controls.Add(this.tabPageIperfLog);
            this.tabControlTesting.Location = new System.Drawing.Point(12, 158);
            this.tabControlTesting.Name = "tabControlTesting";
            this.tabControlTesting.SelectedIndex = 0;
            this.tabControlTesting.Size = new System.Drawing.Size(1428, 1038);
            this.tabControlTesting.TabIndex = 5;
            // 
            // tabPageField
            // 
            this.tabPageField.AutoScroll = true;
            this.tabPageField.Location = new System.Drawing.Point(4, 29);
            this.tabPageField.Name = "tabPageField";
            this.tabPageField.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageField.Size = new System.Drawing.Size(1420, 1005);
            this.tabPageField.TabIndex = 0;
            this.tabPageField.Text = "Test field";
            this.tabPageField.UseVisualStyleBackColor = true;
            // 
            // tabPageIperfLog
            // 
            this.tabPageIperfLog.Location = new System.Drawing.Point(4, 29);
            this.tabPageIperfLog.Name = "tabPageIperfLog";
            this.tabPageIperfLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageIperfLog.Size = new System.Drawing.Size(1420, 1005);
            this.tabPageIperfLog.TabIndex = 1;
            this.tabPageIperfLog.Text = "iPerf log";
            this.tabPageIperfLog.UseVisualStyleBackColor = true;
            // 
            // GMVehicleAntennaTesting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1453, 1208);
            this.Controls.Add(this.tabControlTesting);
            this.Controls.Add(this.groupBoxTestPointsSetting);
            this.Name = "GMVehicleAntennaTesting";
            this.Text = "GM vehicle Wi-Fi antenna testing";
            this.groupBoxTestPointsSetting.ResumeLayout(false);
            this.groupBoxTestPointsSetting.PerformLayout();
            this.tabControlTesting.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.TabControl tabControlTesting;
        private System.Windows.Forms.TabPage tabPageField;
        private System.Windows.Forms.TabPage tabPageIperfLog;
    }
}
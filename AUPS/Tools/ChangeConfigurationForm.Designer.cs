namespace AUPS.Tools
{
    partial class ChangeConfigurationForm
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
            this.labelHeight = new System.Windows.Forms.Label();
            this.textBoxHeight = new System.Windows.Forms.TextBox();
            this.labelFrequency = new System.Windows.Forms.Label();
            this.textBoxFrequency = new System.Windows.Forms.TextBox();
            this.labelBandwidth = new System.Windows.Forms.Label();
            this.comboBoxBandwidth = new System.Windows.Forms.ComboBox();
            this.labelWiFiChannel = new System.Windows.Forms.Label();
            this.comboBoxChannel = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOkay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Location = new System.Drawing.Point(45, 59);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(129, 20);
            this.labelHeight.TabIndex = 0;
            this.labelHeight.Text = "Height (unit : cm)";
            // 
            // textBoxHeight
            // 
            this.textBoxHeight.Location = new System.Drawing.Point(279, 59);
            this.textBoxHeight.Name = "textBoxHeight";
            this.textBoxHeight.Size = new System.Drawing.Size(246, 26);
            this.textBoxHeight.TabIndex = 1;
            // 
            // labelFrequency
            // 
            this.labelFrequency.AutoSize = true;
            this.labelFrequency.Enabled = false;
            this.labelFrequency.Location = new System.Drawing.Point(45, 135);
            this.labelFrequency.Name = "labelFrequency";
            this.labelFrequency.Size = new System.Drawing.Size(169, 20);
            this.labelFrequency.TabIndex = 2;
            this.labelFrequency.Text = "Frequency (unit : MHz)";
            // 
            // textBoxFrequency
            // 
            this.textBoxFrequency.Location = new System.Drawing.Point(279, 135);
            this.textBoxFrequency.Name = "textBoxFrequency";
            this.textBoxFrequency.Size = new System.Drawing.Size(246, 26);
            this.textBoxFrequency.TabIndex = 3;
            // 
            // labelBandwidth
            // 
            this.labelBandwidth.AutoSize = true;
            this.labelBandwidth.Enabled = false;
            this.labelBandwidth.Location = new System.Drawing.Point(49, 210);
            this.labelBandwidth.Name = "labelBandwidth";
            this.labelBandwidth.Size = new System.Drawing.Size(169, 20);
            this.labelBandwidth.TabIndex = 4;
            this.labelBandwidth.Text = "Bandwidth (unit : MHz)";
            // 
            // comboBoxBandwidth
            // 
            this.comboBoxBandwidth.FormattingEnabled = true;
            this.comboBoxBandwidth.Items.AddRange(new object[] {
            "20",
            "40",
            "80"});
            this.comboBoxBandwidth.Location = new System.Drawing.Point(279, 210);
            this.comboBoxBandwidth.Name = "comboBoxBandwidth";
            this.comboBoxBandwidth.Size = new System.Drawing.Size(246, 28);
            this.comboBoxBandwidth.TabIndex = 5;
            // 
            // labelWiFiChannel
            // 
            this.labelWiFiChannel.AutoSize = true;
            this.labelWiFiChannel.Enabled = false;
            this.labelWiFiChannel.Location = new System.Drawing.Point(53, 289);
            this.labelWiFiChannel.Name = "labelWiFiChannel";
            this.labelWiFiChannel.Size = new System.Drawing.Size(103, 20);
            this.labelWiFiChannel.TabIndex = 6;
            this.labelWiFiChannel.Text = "WiFi Channel";
            // 
            // comboBoxChannel
            // 
            this.comboBoxChannel.FormattingEnabled = true;
            this.comboBoxChannel.Location = new System.Drawing.Point(279, 289);
            this.comboBoxChannel.Name = "comboBoxChannel";
            this.comboBoxChannel.Size = new System.Drawing.Size(246, 28);
            this.comboBoxChannel.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(85, 375);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(145, 48);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOkay
            // 
            this.btnOkay.Location = new System.Drawing.Point(339, 375);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(145, 48);
            this.btnOkay.TabIndex = 9;
            this.btnOkay.Text = "OK";
            this.btnOkay.UseVisualStyleBackColor = true;
            this.btnOkay.Click += new System.EventHandler(this.btnOkay_Click);
            // 
            // ChangeConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 490);
            this.Controls.Add(this.btnOkay);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.comboBoxChannel);
            this.Controls.Add(this.labelWiFiChannel);
            this.Controls.Add(this.comboBoxBandwidth);
            this.Controls.Add(this.labelBandwidth);
            this.Controls.Add(this.textBoxFrequency);
            this.Controls.Add(this.labelFrequency);
            this.Controls.Add(this.textBoxHeight);
            this.Controls.Add(this.labelHeight);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeConfigurationForm";
            this.Text = "Change configuration for current test point";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.TextBox textBoxHeight;
        private System.Windows.Forms.Label labelFrequency;
        private System.Windows.Forms.TextBox textBoxFrequency;
        private System.Windows.Forms.Label labelBandwidth;
        private System.Windows.Forms.ComboBox comboBoxBandwidth;
        private System.Windows.Forms.Label labelWiFiChannel;
        private System.Windows.Forms.ComboBox comboBoxChannel;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOkay;
    }
}
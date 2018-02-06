namespace Socket_Server
{
    partial class MainWindow
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
            this.labelIPAddress = new System.Windows.Forms.Label();
            this.textBoxIPAddress = new System.Windows.Forms.TextBox();
            this.labelPort = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.labelSocketType = new System.Windows.Forms.Label();
            this.comboBoxSocket = new System.Windows.Forms.ComboBox();
            this.btnStartWatch = new System.Windows.Forms.Button();
            this.btnStopWatch = new System.Windows.Forms.Button();
            this.textBoxFilePath = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.btnSendMesg = new System.Windows.Forms.Button();
            this.groupBoxLog = new System.Windows.Forms.GroupBox();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.groupBoxMessage = new System.Windows.Forms.GroupBox();
            this.textBoxMesg = new System.Windows.Forms.TextBox();
            this.groupBoxLog.SuspendLayout();
            this.groupBoxMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelIPAddress
            // 
            this.labelIPAddress.AutoSize = true;
            this.labelIPAddress.Location = new System.Drawing.Point(12, 25);
            this.labelIPAddress.Name = "labelIPAddress";
            this.labelIPAddress.Size = new System.Drawing.Size(67, 13);
            this.labelIPAddress.TabIndex = 0;
            this.labelIPAddress.Text = "IP Address : ";
            // 
            // textBoxIPAddress
            // 
            this.textBoxIPAddress.Location = new System.Drawing.Point(85, 22);
            this.textBoxIPAddress.Name = "textBoxIPAddress";
            this.textBoxIPAddress.Size = new System.Drawing.Size(166, 20);
            this.textBoxIPAddress.TabIndex = 1;
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(276, 25);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(35, 13);
            this.labelPort.TabIndex = 2;
            this.labelPort.Text = "Port : ";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(317, 22);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(81, 20);
            this.textBoxPort.TabIndex = 3;
            // 
            // labelSocketType
            // 
            this.labelSocketType.AutoSize = true;
            this.labelSocketType.Location = new System.Drawing.Point(417, 25);
            this.labelSocketType.Name = "labelSocketType";
            this.labelSocketType.Size = new System.Drawing.Size(73, 13);
            this.labelSocketType.TabIndex = 4;
            this.labelSocketType.Text = "Socket type : ";
            // 
            // comboBoxSocket
            // 
            this.comboBoxSocket.FormattingEnabled = true;
            this.comboBoxSocket.Location = new System.Drawing.Point(497, 25);
            this.comboBoxSocket.Name = "comboBoxSocket";
            this.comboBoxSocket.Size = new System.Drawing.Size(166, 21);
            this.comboBoxSocket.TabIndex = 5;
            // 
            // btnStartWatch
            // 
            this.btnStartWatch.Location = new System.Drawing.Point(85, 62);
            this.btnStartWatch.Name = "btnStartWatch";
            this.btnStartWatch.Size = new System.Drawing.Size(166, 23);
            this.btnStartWatch.TabIndex = 6;
            this.btnStartWatch.Text = "Start to watch";
            this.btnStartWatch.UseVisualStyleBackColor = true;
            this.btnStartWatch.Click += new System.EventHandler(this.btnStartWatch_Click);
            // 
            // btnStopWatch
            // 
            this.btnStopWatch.Location = new System.Drawing.Point(317, 62);
            this.btnStopWatch.Name = "btnStopWatch";
            this.btnStopWatch.Size = new System.Drawing.Size(166, 23);
            this.btnStopWatch.TabIndex = 7;
            this.btnStopWatch.Text = "Stop watch";
            this.btnStopWatch.UseVisualStyleBackColor = true;
            this.btnStopWatch.Click += new System.EventHandler(this.btnStopWatch_Click);
            // 
            // textBoxFilePath
            // 
            this.textBoxFilePath.Location = new System.Drawing.Point(15, 452);
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.Size = new System.Drawing.Size(355, 20);
            this.textBoxFilePath.TabIndex = 10;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(392, 452);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 11;
            this.btnSelect.Text = "Select file";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnSendFile
            // 
            this.btnSendFile.Location = new System.Drawing.Point(473, 452);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(75, 23);
            this.btnSendFile.TabIndex = 12;
            this.btnSendFile.Text = "Send file";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // btnSendMesg
            // 
            this.btnSendMesg.Location = new System.Drawing.Point(554, 452);
            this.btnSendMesg.Name = "btnSendMesg";
            this.btnSendMesg.Size = new System.Drawing.Size(107, 23);
            this.btnSendMesg.TabIndex = 13;
            this.btnSendMesg.Text = "Send message";
            this.btnSendMesg.UseVisualStyleBackColor = true;
            this.btnSendMesg.Click += new System.EventHandler(this.btnSendMesg_Click);
            // 
            // groupBoxLog
            // 
            this.groupBoxLog.Controls.Add(this.textBoxLog);
            this.groupBoxLog.Location = new System.Drawing.Point(15, 94);
            this.groupBoxLog.Name = "groupBoxLog";
            this.groupBoxLog.Size = new System.Drawing.Size(646, 154);
            this.groupBoxLog.TabIndex = 14;
            this.groupBoxLog.TabStop = false;
            this.groupBoxLog.Text = "Log : ";
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(7, 20);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.Size = new System.Drawing.Size(633, 128);
            this.textBoxLog.TabIndex = 0;
            // 
            // groupBoxMessage
            // 
            this.groupBoxMessage.Controls.Add(this.textBoxMesg);
            this.groupBoxMessage.Location = new System.Drawing.Point(15, 255);
            this.groupBoxMessage.Name = "groupBoxMessage";
            this.groupBoxMessage.Size = new System.Drawing.Size(646, 191);
            this.groupBoxMessage.TabIndex = 15;
            this.groupBoxMessage.TabStop = false;
            this.groupBoxMessage.Text = "Message : ";
            // 
            // textBoxMesg
            // 
            this.textBoxMesg.Location = new System.Drawing.Point(7, 20);
            this.textBoxMesg.Multiline = true;
            this.textBoxMesg.Name = "textBoxMesg";
            this.textBoxMesg.Size = new System.Drawing.Size(633, 165);
            this.textBoxMesg.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 507);
            this.Controls.Add(this.groupBoxMessage);
            this.Controls.Add(this.groupBoxLog);
            this.Controls.Add(this.btnSendMesg);
            this.Controls.Add(this.btnSendFile);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.textBoxFilePath);
            this.Controls.Add(this.btnStopWatch);
            this.Controls.Add(this.btnStartWatch);
            this.Controls.Add(this.comboBoxSocket);
            this.Controls.Add(this.labelSocketType);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.labelPort);
            this.Controls.Add(this.textBoxIPAddress);
            this.Controls.Add(this.labelIPAddress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Server";
            this.groupBoxLog.ResumeLayout(false);
            this.groupBoxLog.PerformLayout();
            this.groupBoxMessage.ResumeLayout(false);
            this.groupBoxMessage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelIPAddress;
        private System.Windows.Forms.TextBox textBoxIPAddress;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Label labelSocketType;
        private System.Windows.Forms.ComboBox comboBoxSocket;
        private System.Windows.Forms.Button btnStartWatch;
        private System.Windows.Forms.Button btnStopWatch;
        private System.Windows.Forms.TextBox textBoxFilePath;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.Button btnSendMesg;
        private System.Windows.Forms.GroupBox groupBoxLog;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.GroupBox groupBoxMessage;
        private System.Windows.Forms.TextBox textBoxMesg;
    }
}


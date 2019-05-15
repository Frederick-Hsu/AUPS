namespace AUPS.Tools.Postgresql_Database_Tool
{
    partial class PostgresqlDatabaseToolPanel
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
            this.statusStripRowsAffected = new System.Windows.Forms.StatusStrip();
            this.layoutPanelDBTool = new System.Windows.Forms.TableLayoutPanel();
            this.labelDBConnectionInfo = new System.Windows.Forms.Label();
            this.labelServerIP = new System.Windows.Forms.Label();
            this.labelDBName = new System.Windows.Forms.Label();
            this.textBoxDatabaseName = new System.Windows.Forms.TextBox();
            this.textBoxServerIP = new System.Windows.Forms.TextBox();
            this.labelUserName = new System.Windows.Forms.Label();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.labelUserPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.labelSqlCommand = new System.Windows.Forms.Label();
            this.buttonExecute = new System.Windows.Forms.Button();
            this.textBoxSqlCmd = new System.Windows.Forms.TextBox();
            this.labelQueriedResult = new System.Windows.Forms.Label();
            this.dataGridViewQueriedResult = new System.Windows.Forms.DataGridView();
            this.statusBarLabelRowAffected = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStripRowsAffected.SuspendLayout();
            this.layoutPanelDBTool.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQueriedResult)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStripRowsAffected
            // 
            this.statusStripRowsAffected.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.statusBarLabelRowAffected });
            this.statusStripRowsAffected.Location = new System.Drawing.Point(0, 588);
            this.statusStripRowsAffected.Name = "statusStripRowsAffected";
            this.statusStripRowsAffected.Size = new System.Drawing.Size(1106, 22);
            this.statusStripRowsAffected.TabIndex = 0;
            this.statusStripRowsAffected.Text = "statusStrip1";
            // 
            // layoutPanelDBTool
            // 
            this.layoutPanelDBTool.ColumnCount = 5;
            this.layoutPanelDBTool.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layoutPanelDBTool.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layoutPanelDBTool.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layoutPanelDBTool.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layoutPanelDBTool.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.layoutPanelDBTool.Controls.Add(this.labelDBConnectionInfo, 0, 0);
            this.layoutPanelDBTool.Controls.Add(this.labelServerIP, 0, 1);
            this.layoutPanelDBTool.Controls.Add(this.labelDBName, 1, 1);
            this.layoutPanelDBTool.Controls.Add(this.textBoxDatabaseName, 1, 2);
            this.layoutPanelDBTool.Controls.Add(this.textBoxServerIP, 0, 2);
            this.layoutPanelDBTool.Controls.Add(this.labelUserName, 2, 1);
            this.layoutPanelDBTool.Controls.Add(this.textBoxUserName, 2, 2);
            this.layoutPanelDBTool.Controls.Add(this.labelUserPassword, 3, 1);
            this.layoutPanelDBTool.Controls.Add(this.textBoxPassword, 3, 2);
            this.layoutPanelDBTool.Controls.Add(this.buttonConnect, 4, 1);
            this.layoutPanelDBTool.Controls.Add(this.buttonDisconnect, 4, 2);
            this.layoutPanelDBTool.Controls.Add(this.labelSqlCommand, 0, 5);
            this.layoutPanelDBTool.Controls.Add(this.buttonExecute, 4, 7);
            this.layoutPanelDBTool.Controls.Add(this.textBoxSqlCmd, 0, 6);
            this.layoutPanelDBTool.Controls.Add(this.labelQueriedResult, 0, 9);
            this.layoutPanelDBTool.Controls.Add(this.dataGridViewQueriedResult, 0, 10);
            this.layoutPanelDBTool.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutPanelDBTool.Location = new System.Drawing.Point(0, 0);
            this.layoutPanelDBTool.Name = "layoutPanelDBTool";
            this.layoutPanelDBTool.RowCount = 15;
            this.layoutPanelDBTool.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutPanelDBTool.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutPanelDBTool.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutPanelDBTool.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutPanelDBTool.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutPanelDBTool.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layoutPanelDBTool.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.layoutPanelDBTool.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.layoutPanelDBTool.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.layoutPanelDBTool.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutPanelDBTool.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.layoutPanelDBTool.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.layoutPanelDBTool.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.layoutPanelDBTool.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.layoutPanelDBTool.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.layoutPanelDBTool.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutPanelDBTool.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutPanelDBTool.Size = new System.Drawing.Size(1106, 588);
            this.layoutPanelDBTool.TabIndex = 1;
            // 
            // labelDBConnectionInfo
            // 
            this.labelDBConnectionInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDBConnectionInfo.AutoSize = true;
            this.layoutPanelDBTool.SetColumnSpan(this.labelDBConnectionInfo, 5);
            this.labelDBConnectionInfo.Location = new System.Drawing.Point(3, 0);
            this.labelDBConnectionInfo.Name = "labelDBConnectionInfo";
            this.labelDBConnectionInfo.Size = new System.Drawing.Size(1100, 13);
            this.labelDBConnectionInfo.TabIndex = 0;
            this.labelDBConnectionInfo.Text = "PostgreSQL database server connection info.";
            // 
            // labelServerIP
            // 
            this.labelServerIP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelServerIP.AutoSize = true;
            this.labelServerIP.Location = new System.Drawing.Point(3, 21);
            this.labelServerIP.Name = "labelServerIP";
            this.labelServerIP.Size = new System.Drawing.Size(215, 13);
            this.labelServerIP.TabIndex = 1;
            this.labelServerIP.Text = "Database server IP";
            // 
            // labelDBName
            // 
            this.labelDBName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDBName.AutoSize = true;
            this.labelDBName.Location = new System.Drawing.Point(224, 21);
            this.labelDBName.Name = "labelDBName";
            this.labelDBName.Size = new System.Drawing.Size(215, 13);
            this.labelDBName.TabIndex = 3;
            this.labelDBName.Text = "Database name";
            // 
            // textBoxDatabaseName
            // 
            this.textBoxDatabaseName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDatabaseName.Location = new System.Drawing.Point(224, 46);
            this.textBoxDatabaseName.Name = "textBoxDatabaseName";
            this.textBoxDatabaseName.Size = new System.Drawing.Size(215, 20);
            this.textBoxDatabaseName.TabIndex = 4;
            // 
            // textBoxServerIP
            // 
            this.textBoxServerIP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxServerIP.Location = new System.Drawing.Point(3, 46);
            this.textBoxServerIP.Name = "textBoxServerIP";
            this.textBoxServerIP.Size = new System.Drawing.Size(215, 20);
            this.textBoxServerIP.TabIndex = 5;
            // 
            // labelUserName
            // 
            this.labelUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new System.Drawing.Point(445, 21);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(215, 13);
            this.labelUserName.TabIndex = 6;
            this.labelUserName.Text = "Database user name";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxUserName.Location = new System.Drawing.Point(445, 46);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(215, 20);
            this.textBoxUserName.TabIndex = 7;
            // 
            // labelUserPassword
            // 
            this.labelUserPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelUserPassword.AutoSize = true;
            this.labelUserPassword.Location = new System.Drawing.Point(666, 21);
            this.labelUserPassword.Name = "labelUserPassword";
            this.labelUserPassword.Size = new System.Drawing.Size(215, 13);
            this.labelUserPassword.TabIndex = 8;
            this.labelUserPassword.Text = "Password";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPassword.Location = new System.Drawing.Point(666, 46);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(215, 20);
            this.textBoxPassword.TabIndex = 9;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConnect.AutoSize = true;
            this.buttonConnect.Location = new System.Drawing.Point(887, 16);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(216, 23);
            this.buttonConnect.TabIndex = 10;
            this.buttonConnect.Text = "&Connect database server";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDisconnect.AutoSize = true;
            this.buttonDisconnect.Location = new System.Drawing.Point(887, 45);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(216, 23);
            this.buttonDisconnect.TabIndex = 11;
            this.buttonDisconnect.Text = "&Disconnect";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // labelSqlCommand
            // 
            this.labelSqlCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSqlCommand.AutoSize = true;
            this.layoutPanelDBTool.SetColumnSpan(this.labelSqlCommand, 5);
            this.labelSqlCommand.Location = new System.Drawing.Point(3, 71);
            this.labelSqlCommand.Name = "labelSqlCommand";
            this.labelSqlCommand.Size = new System.Drawing.Size(1100, 13);
            this.labelSqlCommand.TabIndex = 12;
            this.labelSqlCommand.Text = "SQL command";
            // 
            // buttonExecute
            // 
            this.buttonExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExecute.AutoSize = true;
            this.buttonExecute.Location = new System.Drawing.Point(887, 112);
            this.buttonExecute.Name = "buttonExecute";
            this.buttonExecute.Size = new System.Drawing.Size(216, 22);
            this.buttonExecute.TabIndex = 13;
            this.buttonExecute.Text = "&Execute";
            this.buttonExecute.UseVisualStyleBackColor = true;
            this.buttonExecute.Click += new System.EventHandler(this.buttonExecute_Click);
            // 
            // textBoxSqlCmd
            // 
            this.layoutPanelDBTool.SetColumnSpan(this.textBoxSqlCmd, 4);
            this.textBoxSqlCmd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxSqlCmd.Location = new System.Drawing.Point(3, 87);
            this.textBoxSqlCmd.Multiline = true;
            this.textBoxSqlCmd.Name = "textBoxSqlCmd";
            this.layoutPanelDBTool.SetRowSpan(this.textBoxSqlCmd, 3);
            this.textBoxSqlCmd.Size = new System.Drawing.Size(878, 66);
            this.textBoxSqlCmd.TabIndex = 14;
            // 
            // labelQueriedResult
            // 
            this.labelQueriedResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelQueriedResult.AutoSize = true;
            this.layoutPanelDBTool.SetColumnSpan(this.labelQueriedResult, 5);
            this.labelQueriedResult.Location = new System.Drawing.Point(3, 159);
            this.labelQueriedResult.Name = "labelQueriedResult";
            this.labelQueriedResult.Size = new System.Drawing.Size(1100, 13);
            this.labelQueriedResult.TabIndex = 15;
            this.labelQueriedResult.Text = "Queried result";
            // 
            // dataGridViewQueriedResult
            // 
            this.dataGridViewQueriedResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.layoutPanelDBTool.SetColumnSpan(this.dataGridViewQueriedResult, 5);
            this.dataGridViewQueriedResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewQueriedResult.Location = new System.Drawing.Point(3, 179);
            this.dataGridViewQueriedResult.Name = "dataGridViewQueriedResult";
            this.layoutPanelDBTool.SetRowSpan(this.dataGridViewQueriedResult, 7);
            this.dataGridViewQueriedResult.Size = new System.Drawing.Size(1100, 406);
            this.dataGridViewQueriedResult.TabIndex = 16;
            //
            // statusBarLabelRowAffected
            //
            this.statusBarLabelRowAffected.AutoSize = false;
            this.statusBarLabelRowAffected.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.statusBarLabelRowAffected.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusBarLabelRowAffected.Name = "statusBarLabelRowsAffected";
            this.statusBarLabelRowAffected.Size = new System.Drawing.Size(989, 17);
            this.statusBarLabelRowAffected.Spring = true;
            this.statusBarLabelRowAffected.Text = "How many rows are affected?";
            this.statusBarLabelRowAffected.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 610);
            this.Controls.Add(this.layoutPanelDBTool);
            this.Controls.Add(this.statusStripRowsAffected);
            this.Name = "MainWindow";
            this.Text = "PostgreSQL database tool";
            this.Load += new System.EventHandler(this.PostgresqlDatabaseToolPanel_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PostgresqlDatabaseToolPanel_FormClosed);
            this.statusStripRowsAffected.ResumeLayout(false);
            this.statusStripRowsAffected.PerformLayout();
            this.layoutPanelDBTool.ResumeLayout(false);
            this.layoutPanelDBTool.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQueriedResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStripRowsAffected;
        private System.Windows.Forms.TableLayoutPanel layoutPanelDBTool;
        private System.Windows.Forms.Label labelDBConnectionInfo;
        private System.Windows.Forms.Label labelServerIP;
        private System.Windows.Forms.Label labelDBName;
        private System.Windows.Forms.TextBox textBoxDatabaseName;
        private System.Windows.Forms.TextBox textBoxServerIP;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Label labelUserPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.Label labelSqlCommand;
        private System.Windows.Forms.Button buttonExecute;
        private System.Windows.Forms.TextBox textBoxSqlCmd;
        private System.Windows.Forms.Label labelQueriedResult;
        private System.Windows.Forms.DataGridView dataGridViewQueriedResult;
        private System.Windows.Forms.ToolStripStatusLabel statusBarLabelRowAffected;
    }
}


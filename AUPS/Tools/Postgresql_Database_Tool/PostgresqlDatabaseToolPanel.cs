using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Amphenol.PostgreSQL_Database.Library;

namespace AUPS.Tools.Postgresql_Database_Tool
{
    public partial class PostgresqlDatabaseToolPanel : Form
    {
        private PostgresqlDatabase postgresql;

        public PostgresqlDatabaseToolPanel()
        {
            InitializeComponent();
        }

        public PostgresqlDatabaseToolPanel(Amphenol.AUPS.MainWindow parent)
        {
            InitializeComponent();
            MdiParent = parent;
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            string serverIPAddress = textBoxServerIP.Text,
                   databaseName = textBoxDatabaseName.Text,
                   userName = textBoxUserName.Text,
                   password = textBoxPassword.Text;
            if ((serverIPAddress == string.Empty) || 
                (databaseName == string.Empty) ||
                (userName == "") ||
                (password == string.Empty))
            {
                MessageBox.Show("Please fill the correct values for PostgreSQL database server IP address, database name, user name and password in the 4 text boxes.", 
                                "Warning", 
                                MessageBoxButtons.OKCancel, 
                                MessageBoxIcon.Warning);
                return;
            }
            postgresql = new PostgresqlDatabase(serverIPAddress, databaseName, userName, password);
            if (postgresql.ConnectAndOpenDatabase() == ConnectionState.Closed)
            {
                buttonDisconnect.Enabled = true;
                buttonDisconnect.Visible = true;

                buttonExecute.Enabled = true;
                buttonExecute.Visible = true;

                buttonConnect.Enabled = false;
                buttonConnect.Visible = false;
            }
            else
            {
                buttonDisconnect.Enabled = false;
                buttonDisconnect.Visible = false;

                buttonExecute.Enabled = false;
                buttonExecute.Visible = false;

                buttonConnect.Enabled = true;
                buttonConnect.Visible = true;
            }
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            ConnectionState status = postgresql.CloseDatabase();

            if (status == ConnectionState.Closed)
            {
                buttonConnect.Enabled = true;
                buttonConnect.Visible = true;

                buttonDisconnect.Enabled = false;
                buttonDisconnect.Visible = false;

                buttonExecute.Enabled = false;
                buttonExecute.Visible = false;
            }
        }

        private void buttonExecute_Click(object sender, EventArgs e)
        {
            string sqlStatement = textBoxSqlCmd.Text;
            if (sqlStatement == string.Empty)
            {
                MessageBox.Show("Please enter the effective and correct SQL statement here.", 
                                "Error", 
                                MessageBoxButtons.AbortRetryIgnore, 
                                MessageBoxIcon.Error);
                return;
            }
            if (sqlStatement.ToUpper().Contains("SELECT") == true)
            {
                DataTable table;
                int rowsAffected = postgresql.ExecuteQuerySql(sqlStatement, out table);
                dataGridViewQueriedResult.DataSource = table;
                statusBarLabelRowAffected.Text = "Successfully run. " + rowsAffected + " rows affected.";
            }
            else if (sqlStatement.ToUpper().Contains("INSERT") == true)
            {
                int rowsAffected = postgresql.ExecuteInsertSql(sqlStatement);
                statusBarLabelRowAffected.Text = "Successfully run. " + rowsAffected + " rows affected.";
            }
            else if (sqlStatement.ToUpper().Contains("UPDATE") == true)
            {
                int rowsAffected = postgresql.ExecuteUpdateSql(sqlStatement);
                statusBarLabelRowAffected.Text = "Successfully run. " + rowsAffected + " rows affected.";
            }
            else if (sqlStatement.ToUpper().Contains("DELETE") == true)
            {
                int rowsAffected = postgresql.ExecuteDeleteSql(sqlStatement);
                statusBarLabelRowAffected.Text = "Successfully run. " + rowsAffected + " rows affected.";
            }
            else
            {
                int rowsAffected = postgresql.ExecuteCommonSQL(sqlStatement);
                statusBarLabelRowAffected.Text = "Successfully run. " + rowsAffected + " rows affected.";
            }
            // textBoxSqlCmd.Text = string.Empty;
        }

        private void PostgresqlDatabaseToolPanel_FormClosed(object sender, EventArgs e)
        {
            if (postgresql != null)
            {
                ConnectionState status = postgresql.CloseDatabase();
            }
        }

        private void PostgresqlDatabaseToolPanel_Load(object sender, EventArgs e)
        {
            postgresql = null;

            buttonConnect.Enabled = true;
            buttonConnect.Visible = true;
            buttonDisconnect.Enabled = false;
            buttonDisconnect.Visible = false;
            buttonExecute.Enabled = false;
            buttonExecute.Visible = false;
        }
    }
}

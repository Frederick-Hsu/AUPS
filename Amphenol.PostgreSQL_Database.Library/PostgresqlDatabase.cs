using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;

namespace Amphenol.PostgreSQL_Database.Library
{
    public partial class PostgresqlDatabase
    {
        private NpgsqlConnection psqlConnection;
        private string connectionStr;

        public PostgresqlDatabase(string dbServerIP, string dbName)
        {
            connectionStr = string.Format("Server = {0}; Database = {1}; User Id = {2}; Password = {3}; Port = {4};",
                                          dbServerIP,
                                          dbName,
                                          "amphenol_production_test",
                                          "Apt520*!",
                                          "5432");
        }

        public PostgresqlDatabase(string dbServerIP, string dbName, string dbUserName, string dbUserPassword)
        {
            connectionStr = string.Format("Server = {0}; Database = {1}; User Id = {2}; Password = {3}; Port = {4};",
                                          dbServerIP,
                                          dbName,
                                          dbUserName,
                                          dbUserPassword,
                                          "5432");
        }

        public ConnectionState ConnectAndOpenDatabase()
        {
            try
            {
                psqlConnection = new NpgsqlConnection(connectionStr);
            }
            catch (NpgsqlException exception)
            {
                Console.WriteLine("Exception message: {0}", exception.Message);
                throw;
            }
            return psqlConnection.State;
        }

        public ConnectionState CloseDatabase()
        {
            // psqlConnection.Dispose();
            psqlConnection.Close();
            return psqlConnection.State;
        }

        public int ExecuteQuerySql(string selectSqlCmd, out DataTable queriedTable)
        {
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(selectSqlCmd, psqlConnection);
            DataSet dtset = new DataSet();
            dtset.Reset();
            dataAdapter.Fill(dtset);
            queriedTable = new DataTable();
            queriedTable = dtset.Tables[0];
            return 0;
        }

        public int ExecuteInsertSql(string insertSqlCmd)
        {
            NpgsqlCommand command = new NpgsqlCommand(insertSqlCmd, psqlConnection);
            int affectedRowsNumber = command.ExecuteNonQuery();
            return affectedRowsNumber;
        }

        public int ExecuteUpdateSql(string updateSqlCmd)
        {
            NpgsqlCommand command = new NpgsqlCommand(updateSqlCmd, psqlConnection);
            int affectedRowsNumber = command.ExecuteNonQuery();
            return affectedRowsNumber;
        }

        public int ExecuteDeleteSql(string deleteSqlCmd)
        {
            NpgsqlCommand command = new NpgsqlCommand(deleteSqlCmd, psqlConnection);
            int affectedRowsNumber = command.ExecuteNonQuery();
            return affectedRowsNumber;
        }
    }
}

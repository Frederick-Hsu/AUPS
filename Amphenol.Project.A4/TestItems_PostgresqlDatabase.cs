using System;
using System.Collections.Generic;
using System.Data;

using Amphenol.PostgreSQL_Database.Library;

namespace Amphenol.Project.A4
{
    partial class TestItems
    {
        private static bool ConnectAndStoreTestDataIntoPostgresqlDatabase(List<string> stepParameters,
                                                                          out string stepResult,
                                                                          out string stepStatus,
                                                                          out string stepErrorCode,
                                                                          out string stepErrorDesc)
        {
            string databaseServerIPAddress = stepParameters[0];
            string postgresqlDatbaseName = stepParameters[1];
            string testDataTableName = stepParameters[2];
            string xmlTestLogTableName = stepParameters[3];

            PostgresqlDatabase pgdb = new PostgresqlDatabase(databaseServerIPAddress, postgresqlDatbaseName);
            ConnectionState state = pgdb.ConnectAndOpenDatabase();
            if (state == ConnectionState.Open)
            {
                pgdb.CloseDatabase();
                stepResult = "OK";
                stepStatus = "Pass";
                stepErrorCode = "";
                stepErrorDesc = "";
                return true;
            }
            else
            {
                pgdb.CloseDatabase();
                stepResult = "NG";
                stepStatus = "Fail";
                stepErrorCode = "PGDBFAL";
                stepErrorDesc = "Failed to neither connect with nor open PostgreSQL database server.";
                return false;
            }
        }
    }
}
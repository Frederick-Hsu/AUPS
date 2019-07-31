using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;

using Amphenol.PostgreSQL_Database.Library;

namespace Amphenol.SequenceLib
{
    public class TestSequence
    {
        private XmlDocument seqXmlDoc;
        private XmlNode currentSequenceNode;
        private List<TestBlock> testBlockList;

        public void Load(string sequenceXmlFile)
        {
            seqXmlDoc = new XmlDocument();
            seqXmlDoc.Load(sequenceXmlFile);

            /* Locate the <sequence> node, namely the root node. */
            currentSequenceNode = seqXmlDoc.SelectSingleNode("sequence");
            if (currentSequenceNode == null)
                return;
            /* Acquire the <block> node list under <sequence> node. */
            XmlNodeList blockNodeList = currentSequenceNode.ChildNodes;
            /* Initialize testblocks list. */
            testBlockList = new List<TestBlock>();
            foreach (XmlNode blockNode in blockNodeList)
            {
                TestBlock testBlock = new TestBlock(blockNode);
                testBlockList.Add(testBlock);
            }
        }

        public XmlDocument SeqXmlDoc
        {
            get { return seqXmlDoc; }
        }
        public List<TestBlock> TestBlockList
        {
            get { return testBlockList; }
        }
        public XmlNode CurrentSequenceNode
        {
            get { return currentSequenceNode; }
        }

        public void SaveAsTestRecord(string recordXmlFile)
        {
            seqXmlDoc.Save(recordXmlFile);
        }

        public int TotalBlockNum()
        {
            return testBlockList.Count;
        }

        public int TotalStepNum()
        {
            int num = 0;
            foreach (TestBlock block in testBlockList)
            {
                num += block.TestStepList.Count;
            }
            return num;
        }

        public bool StoreTestResultsIntoPostgresqlDatabase(string serialNumber, string finalConclusion)
        {
            bool databaseEnabled = false;
            string pgdbServerIP = "";
            string databaseName = "";
            string testResultsTableName = "";

            foreach (TestBlock block in testBlockList)
            {
                foreach (TestStep step in block.TestStepList)
                {
                    if (step.StepFunctionName == "ConnectAndStoreTestDataIntoPostgresqlDatabase")
                    {
                        databaseEnabled = true;
                        pgdbServerIP = step.StepParamList.Parameters[0];
                        databaseName = step.StepParamList.Parameters[1];
                        testResultsTableName = step.StepParamList.Parameters[2];
                        break;
                    }
                    else
                    {
                        databaseEnabled = false;
                    }
                }
            }

            if (databaseEnabled == false)
            {
                return false;
            }
            PostgresqlDatabase pgdb = new PostgresqlDatabase(pgdbServerIP, databaseName);
            ConnectionState state = pgdb.ConnectAndOpenDatabase();
            if (state != ConnectionState.Open)
            {
                pgdb.CloseDatabase();
                return false;
            }
            string insertSqlCommand = "INSERT INTO " + testResultsTableName + "(SN, ";
            string valuesCommand = "VALUES('" + serialNumber + "', ";
            foreach (TestBlock block in testBlockList)
            {
                foreach (TestStep step in block.TestStepList)
                {
                    if (step.StepFieldEnabled == true)
                    {
                        insertSqlCommand += (step.StepFieldName + ", ");
                        switch (step.StepLimitType)
                        {
                            case "String":
                                valuesCommand += (("'" + step.StepSpec.Result + "'") + ", ");
                                break;
                            case "Numerical":
                                valuesCommand += (step.StepSpec.Result + ", ");
                                break;
                        }
                    }
                    if (step.StepConclusion.Status.ToUpper() == "FAIL")
                    {
                        string stepErrorCode = step.StepConclusion.ErrorCode;
                        string stepErrorDesc = step.StepConclusion.ErrorDesc;
                        insertSqlCommand += "error_code, error_desc, ";
                        valuesCommand += ("'" + stepErrorCode + "', '" + stepErrorDesc + "', ");
                        goto EXIT;      /* Break out the entire big-foreach-loop, no need to proceed any more. */
                    }
                }
            }
            EXIT:
            insertSqlCommand += "Final_Conclusion)";
            valuesCommand += ("'" + finalConclusion + "')");

            int rows = pgdb.ExecuteInsertSql(insertSqlCommand + "\n" + valuesCommand + ";");
            if (rows != 1)
            {
                pgdb.CloseDatabase();
                return false;
            }
            pgdb.CloseDatabase();
            return true;
        }

        public bool StoreTestXmlLogIntoPostgresqlDatabase(string serialNumber, string finalConclusion)
        {
            bool dbEnabled = false;
            string dbServerIP = "", dbName = "", xmlLogTableName = "";
            foreach (TestBlock block in testBlockList)
            {
                foreach (TestStep step in block.TestStepList)
                {
                    if (step.StepFunctionName == "ConnectAndStoreTestDataIntoPostgresqlDatabase")
                    {
                        dbEnabled = true;
                        dbServerIP = step.StepParamList.Parameters[0];
                        dbName = step.StepParamList.Parameters[1];
                        xmlLogTableName = step.StepParamList.Parameters[3];
                        break;
                    }
                    else
                    {
                        dbEnabled = false;
                    }
                }
            }
            if (dbEnabled == false)
            {
                return false;
            }
            PostgresqlDatabase psqldb = new PostgresqlDatabase(dbServerIP, dbName);
            ConnectionState state = psqldb.ConnectAndOpenDatabase();
            if (state != ConnectionState.Open)
            {
                psqldb.CloseDatabase();
                return false;
            }

            string insertSqlCommand = "INSERT INTO " + xmlLogTableName + "(SN, xml_log_file, test_conclusion)";
            string valuesCommand = "VALUES('" + serialNumber + "', XMLPARSE(DOCUMENT '" + seqXmlDoc.OuterXml + "'), '" + finalConclusion + "');";
            int rows = psqldb.ExecuteInsertSql(insertSqlCommand + "\n" + valuesCommand);
            if (rows != 1)
            {
                psqldb.CloseDatabase();
                return false;
            }
            psqldb.CloseDatabase();
            return true;
        }

        public void Refresh()
        {
            foreach (TestBlock block in testBlockList)
            {
                foreach (TestStep step in block.TestStepList)
                {
                    if (step.StepSpec.Result != null)
                    {
                        step.StepSpec.Result = "";
                    }
                    if (step.StepConclusion != null)
                    {
                        step.StepConclusion.Status = "";
                        step.StepConclusion.ErrorCode = "";
                        step.StepConclusion.ErrorDesc = "";
                    }
                }
            }
        }
    }
}

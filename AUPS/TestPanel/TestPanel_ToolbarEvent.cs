using System;
using System.Windows.Forms;
using Amphenol.SequenceLib;

namespace Amphenol.AUPS
{
    partial class TestPanel
    {
        private static string prevOpenedDir = "";
        private TestSequence testSeq = null;

        private void toolStripBtnOpenSequence_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (prevOpenedDir.Length == 0)
            {
                dlg.InitialDirectory = @"C:\";
            }
            else
            {
                dlg.InitialDirectory = prevOpenedDir;
            }
            dlg.Title = "Select and open your test sequence XML file";
            dlg.DefaultExt = "xml";
            dlg.Filter = "XML file | *.xml";
            dlg.AddExtension = true;

            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            prevOpenedDir = System.IO.Path.GetFullPath(dlg.FileName);
            /* Indicate which test sequence XML file had been opened. */
            toolStripLabelSequenceFile.Text = dlg.FileName;

            /* Load the test sequence file, and parse out all elements */
            testSeq = new TestSequence();
            testSeq.Load(dlg.FileName);

            VisualizeTestSequenceInTreeView(testSeq);
        }

        private void VisualizeTestSequenceInTreeView(TestSequence testSeq)
        {
            treeViewSequenceItemList.Nodes.Clear();

            foreach (TestBlock block in testSeq.TestBlockList)
            {
                /* Create and display test-block tree node */
                TreeNode testBlockTreeNode = new TreeNode();
                testBlockTreeNode.Text = block.BlockName;
                testBlockTreeNode.Tag = block;      /* Assign and remember each TestBlock object */
                treeViewSequenceItemList.Nodes.Add(testBlockTreeNode);

                foreach (TestStep step in block.TestStepList)
                {
                    /* Create and display test-step tree node */
                    TreeNode testStepTreeNode = new TreeNode();
                    testStepTreeNode.Text = step.StepName;
                    testStepTreeNode.Tag = step;    /* Assign and remember each TestStep object */

                    testBlockTreeNode.Nodes.Add(testStepTreeNode);
                }
            }

            /* Display the content of TestBlockList[0].TestStepList[0] object */
            DisplayTestStepContentOnPanel(testSeq.TestBlockList[0].TestStepList[0]);

            treeViewSequenceItemList.ExpandAll();   /* Expand all tree nodes */
            treeViewSequenceItemList.SelectedNode = treeViewSequenceItemList.Nodes[0].Nodes[0];
        }

        private void DisplayTestStepContentOnPanel(TestStep step)
        {
            textBoxStepNo.Text = step.StepNum;
            textBoxStepName.Text = step.StepName;
            textBoxStepDescription.Text = step.StepDescription;

            textBoxTestFunctionName.Text = step.StepFunctionName;
            if (step.StepParamList != null)
                DisplayParameterList(step.StepParamList);

            if (step.StepSpec != null)
            {
                DisplayTestResult(step.StepLimitType, step.StepSpec);
            }
            else
            {
                dataGridViewTestResult.Columns.Clear();
            }

            if (step.StepConclusion != null)
            {
                DisplayTestConclusion(step.StepConclusion);
            }
            else
            {
                dataGridViewTestConclusion.Columns.Clear();
            }
        }

        private void DisplayParameterList(TestParameterList paramlist)
        {
            int paramCount = paramlist.Parameters.Count;

            textBoxParameter1.Text = string.Empty;
            textBoxParameter2.Text = string.Empty;
            textBoxParameter3.Text = string.Empty;
            textBoxParameter4.Text = string.Empty;
            textBoxParameter5.Text = string.Empty;
            textBoxParameter6.Text = string.Empty;

            switch (paramCount)
            {
                case 0:
                    break;
                case 1:
                    textBoxParameter1.Text = paramlist.Parameters[0];
                    break;
                case 2:
                    textBoxParameter1.Text = paramlist.Parameters[0];
                    textBoxParameter2.Text = paramlist.Parameters[1];
                    break;
                case 3:
                    textBoxParameter1.Text = paramlist.Parameters[0];
                    textBoxParameter2.Text = paramlist.Parameters[1];
                    textBoxParameter3.Text = paramlist.Parameters[2];
                    break;
                case 4:
                    textBoxParameter1.Text = paramlist.Parameters[0];
                    textBoxParameter2.Text = paramlist.Parameters[1];
                    textBoxParameter3.Text = paramlist.Parameters[2];
                    textBoxParameter4.Text = paramlist.Parameters[3];
                    break;
                case 5:
                    textBoxParameter1.Text = paramlist.Parameters[0];
                    textBoxParameter2.Text = paramlist.Parameters[1];
                    textBoxParameter3.Text = paramlist.Parameters[2];
                    textBoxParameter4.Text = paramlist.Parameters[3];
                    textBoxParameter5.Text = paramlist.Parameters[4];
                    break;
                case 6:
                    textBoxParameter1.Text = paramlist.Parameters[0];
                    textBoxParameter2.Text = paramlist.Parameters[1];
                    textBoxParameter3.Text = paramlist.Parameters[2];
                    textBoxParameter4.Text = paramlist.Parameters[3];
                    textBoxParameter5.Text = paramlist.Parameters[4];
                    textBoxParameter6.Text = paramlist.Parameters[5];
                    break;
                default:
                    break;
            }
        }

        private void DisplayTestResult(string limitType, TestSpec spec)
        {
            dataGridViewTestResult.Columns.Clear();

            if (limitType == "Numerical")
            {
                dataGridViewTestResult.Columns.Add("LowerLimit", "Lower");
                dataGridViewTestResult.Columns.Add("TypicalLimit", "Typical");
                dataGridViewTestResult.Columns.Add("UpperLimit", "Upper");
                dataGridViewTestResult.Columns.Add("Result", "Result");

                dataGridViewTestResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dataGridViewTestResult.Rows[0].Cells[0].Value = spec.Limits[0];
                dataGridViewTestResult.Rows[0].Cells[1].Value = spec.Limits[1];
                dataGridViewTestResult.Rows[0].Cells[2].Value = spec.Limits[2];
                dataGridViewTestResult.Rows[0].Cells[3].Value = spec.Result;
                dataGridViewTestResult.Rows[0].Cells[3].Style.ForeColor = System.Drawing.Color.Blue;
            }
            else if (limitType == "String")
            {
                dataGridViewTestResult.Columns.Add("ExpectLimit", "Expect");
                dataGridViewTestResult.Columns.Add("Result", "Result");
                dataGridViewTestResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dataGridViewTestResult.Rows[0].Cells[0].Value = spec.Limits[0];
                dataGridViewTestResult.Rows[0].Cells[1].Value = spec.Result;
                dataGridViewTestResult.Rows[0].Cells[1].Style.ForeColor = System.Drawing.Color.Blue;
            }
        }

        private void DisplayTestConclusion(TestConclusion conclusion)
        {
            dataGridViewTestConclusion.Columns.Clear();

            dataGridViewTestConclusion.Columns.Add("Status", "Status");
            dataGridViewTestConclusion.Columns.Add("ErrorCode", "Error code");
            dataGridViewTestConclusion.Columns.Add("ErrorDescription", "Error description");
            dataGridViewTestConclusion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridViewTestConclusion.Rows[0].Cells[0].Value = conclusion.Status;
            dataGridViewTestConclusion.Rows[0].Cells[1].Value = conclusion.ErrorCode;
            dataGridViewTestConclusion.Rows[0].Cells[2].Value = conclusion.ErrorDesc;

            if ( (conclusion.Status.ToUpper() == "PASS") || 
                 (conclusion.Status.ToUpper() == "OK")   ||
                 (conclusion.Status.ToUpper() == "OKAY") )
            {
                dataGridViewTestConclusion.Rows[0].Cells[0].Style.BackColor = System.Drawing.Color.Green;
            }
            else if ( (conclusion.Status.ToUpper() == "FAIL") ||
                      (conclusion.Status.ToUpper() == "NG") || 
                      (conclusion.Status.ToUpper() == "NOK") )
            {
                dataGridViewTestConclusion.Rows[0].Cells[0].Style.BackColor = System.Drawing.Color.Red;
            }
        }

        private void treeViewSequenceItemList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            /* Only display the TestStep node */
            if (treeViewSequenceItemList.SelectedNode.Tag is TestStep)
            {
                TreeNode currentSelectedTestStepTreeNode = treeViewSequenceItemList.SelectedNode;
                TestStep currentTestStepNode = currentSelectedTestStepTreeNode.Tag as TestStep;

                DisplayTestStepContentOnPanel(currentTestStepNode);

                if (currentTestStepNode.StepConclusion == null)     /* Skip the not-performed steps */
                {
                    currentSelectedTestStepTreeNode.ForeColor = System.Drawing.Color.Black;
                    return;
                }

                if ( (currentTestStepNode.StepConclusion.Status.ToUpper() == "PASS") ||
                     (currentTestStepNode.StepConclusion.Status.ToUpper() == "OK")   ||
                     (currentTestStepNode.StepConclusion.Status.ToUpper() == "OKAY") )
                {
                    currentSelectedTestStepTreeNode.ForeColor = System.Drawing.Color.Green;
                }
                else if ( (currentTestStepNode.StepConclusion.Status.ToUpper() == "FAIL") ||
                          (currentTestStepNode.StepConclusion.Status.ToUpper() == "NG")   ||
                          (currentTestStepNode.StepConclusion.Status.ToUpper() == "NOK")  )
                {
                    currentSelectedTestStepTreeNode.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    currentSelectedTestStepTreeNode.ForeColor = System.Drawing.Color.Black;
                }
            }
        }

        private void toolStripBtnRefresh_Click(object sender, EventArgs e)
        {
            treeViewSequenceItemList.ExpandAll();

            if (testSeq == null)
                return;

            int blockTreeNodeCount = treeViewSequenceItemList.Nodes.Count;
            for (int blockIndex = 0; blockIndex < blockTreeNodeCount; blockIndex++)
            {
                int stepTreeNodeCount = treeViewSequenceItemList.Nodes[blockIndex].Nodes.Count;
                for (int stepIndex = 0; stepIndex < stepTreeNodeCount; stepIndex++)
                {
                    treeViewSequenceItemList.SelectedNode = treeViewSequenceItemList.Nodes[blockIndex].Nodes[stepIndex];
                }
            }
        }
    }
}
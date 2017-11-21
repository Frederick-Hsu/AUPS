using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

using Amphenol.Seq;

namespace Amphenol.AUPS
{
    partial class SequenceEditor
    {
        private string previousOpenedDirectory = "";

        private void toolStripBtnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            if (previousOpenedDirectory.Length == 0)
                dlg.InitialDirectory = @"C:\";
            else
                dlg.InitialDirectory = previousOpenedDirectory;

            dlg.Title = "Select your sequence.xml file";
            dlg.DefaultExt = "xml";
            dlg.Filter = "XML file | *.xml";
            dlg.AddExtension = true;

            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            previousOpenedDirectory = Path.GetFullPath(dlg.FileName);
            toolStripTextBoxSequenceFilePath.Text = dlg.FileName;

            Sequence seq = new Sequence();
            seq.Load(dlg.FileName);

            VisualizeSequenceInTreeView(seq);
        }

        private void VisualizeSequenceInTreeView(Sequence seq)
        {
            treeViewSequence.Nodes.Clear();     /* Clean up the entire tree nodes */

            foreach (Block block in seq.Blocks)
            {
                /* Display the block tree node */
                TreeNode blockTreeNode = new TreeNode();
                blockTreeNode.Text = block.BlockName;
                blockTreeNode.Tag = block;      /* MUST assign the Block class object */
                treeViewSequence.Nodes.Add(blockTreeNode);

                foreach (Step step in block.Steps)
                {
                    /* Display the step tree node under each block tree node */
                    TreeNode stepTreeNode = new TreeNode();
                    stepTreeNode.Text = step.StepName;
                    stepTreeNode.Tag = step;        /* MUST assign the Step class object. */
                    blockTreeNode.Nodes.Add(stepTreeNode);
                }
            }

            /* Only display the content of Block[0]-->Step[0] on the panel. */
            DisplayStepContentOnPanel(seq.Blocks[0].Steps[0]);
        }

        private void DisplayStepContentOnPanel(Step stepNode)
        {
            textBoxStepNo.Text = stepNode.StepNum;
            textBoxStepName.Text = stepNode.StepName;
            textBoxStepDescription.Text = stepNode.StepDescription;

            comboBoxTestFunctionName.Text = stepNode.StepFunctionName;
            AssignParameterList(stepNode.ParamList);
            AssignSpecification(stepNode.LimitType, stepNode.LimitList);
        }

        private void AssignParameterList(ParameterList paramList)
        {
            switch (paramList.Parameters.Count)
            {
                case 0:
                    textBoxParameter1.Text = "";
                    textBoxParameter2.Text = "";
                    textBoxParameter3.Text = "";
                    textBoxParameter4.Text = "";
                    textBoxParameter5.Text = "";
                    textBoxParameter6.Text = "";
                    break;
                case 1:
                    textBoxParameter1.Text = paramList.Parameters[0];
                    textBoxParameter2.Text = "";
                    textBoxParameter3.Text = "";
                    textBoxParameter4.Text = "";
                    textBoxParameter5.Text = "";
                    textBoxParameter6.Text = "";
                    break;
                case 2:
                    textBoxParameter1.Text = paramList.Parameters[0];
                    textBoxParameter2.Text = paramList.Parameters[1];
                    textBoxParameter3.Text = "";
                    textBoxParameter4.Text = "";
                    textBoxParameter5.Text = "";
                    textBoxParameter6.Text = "";
                    break;
                case 3:
                    textBoxParameter1.Text = paramList.Parameters[0];
                    textBoxParameter2.Text = paramList.Parameters[1];
                    textBoxParameter3.Text = paramList.Parameters[2];
                    textBoxParameter4.Text = "";
                    textBoxParameter5.Text = "";
                    textBoxParameter6.Text = "";
                    break;
                case 4:
                    textBoxParameter1.Text = paramList.Parameters[0];
                    textBoxParameter2.Text = paramList.Parameters[1];
                    textBoxParameter3.Text = paramList.Parameters[2];
                    textBoxParameter4.Text = paramList.Parameters[3];
                    textBoxParameter5.Text = "";
                    textBoxParameter6.Text = "";
                    break;
                case 5:
                    textBoxParameter1.Text = paramList.Parameters[0];
                    textBoxParameter2.Text = paramList.Parameters[1];
                    textBoxParameter3.Text = paramList.Parameters[2];
                    textBoxParameter4.Text = paramList.Parameters[3];
                    textBoxParameter5.Text = paramList.Parameters[4];
                    textBoxParameter6.Text = "";
                    break;
                case 6:
                    textBoxParameter1.Text = paramList.Parameters[0];
                    textBoxParameter2.Text = paramList.Parameters[1];
                    textBoxParameter3.Text = paramList.Parameters[2];
                    textBoxParameter4.Text = paramList.Parameters[3];
                    textBoxParameter5.Text = paramList.Parameters[4];
                    textBoxParameter6.Text = paramList.Parameters[5];
                    break;
                default:
                    break;
            }
        }

        private void AssignSpecification(string limitType, Spec spec)
        {
            comboBoxLimitType.Text = limitType;
            dataGridViewTestSpec.Columns.Clear();
            
            int width = dataGridViewTestSpec.Width;
            if (limitType == "Numerical")
            {
                dataGridViewTestSpec.Columns.Add("LowerLimit", "Lower");
                dataGridViewTestSpec.Columns.Add("TypicalLimit", "Typical");
                dataGridViewTestSpec.Columns.Add("UpperLimit", "Upper");
                dataGridViewTestSpec.Columns.Add("Result", "Result");

                dataGridViewTestSpec.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dataGridViewTestSpec.Rows[0].Cells[0].Value = spec.Limits[0];
                dataGridViewTestSpec.Rows[0].Cells[1].Value = spec.Limits[1];
                dataGridViewTestSpec.Rows[0].Cells[2].Value = spec.Limits[2];
            }
            else if (limitType == "String")
            {
                dataGridViewTestSpec.Columns.Add("ExpectLimit", "Expect");
                dataGridViewTestSpec.Columns.Add("Result", "Result");

                dataGridViewTestSpec.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dataGridViewTestSpec.Rows[0].Cells[0].Value = spec.Limits[0];
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

using Amphenol.SequenceLib;
using Amphenol.Project.X577;

namespace Amphenol.AUPS
{
    partial class SequenceEditor
    {
        private string previousOpenedDirectory = "";

        private Sequence seq;

        private void toolStripBtnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            if (previousOpenedDirectory.Length == 0)
                dlg.InitialDirectory = @"";
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

            seq = new Sequence();
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
            DisplayBlockContentOnPanel(seq.Blocks[0]);
            DisplayStepContentOnPanel(seq.Blocks[0].Steps[0]);

            /* Expand the sequence tree, and selected the Block[0].Step[0] node */
            treeViewSequence.ExpandAll();
            treeViewSequence.SelectedNode = treeViewSequence.Nodes[0].Nodes[0];
        }

        private void DisplayBlockContentOnPanel(Block blockNode)
        {
            if (blockNode.BlockNum != null)
                textBoxBlockNum.Text = blockNode.BlockNum;
            if (blockNode.BlockName != null)
                textBoxBlockName.Text = blockNode.BlockName;
        }

        private void DisplayStepContentOnPanel(Step stepNode)
        {
            if (stepNode.StepNum != null)
                textBoxStepNo.Text = stepNode.StepNum;
            if (stepNode.StepName != null)
                textBoxStepName.Text = stepNode.StepName;
            if (stepNode.StepDescription != null)
                textBoxStepDescription.Text = stepNode.StepDescription;
            checkBoxStepFieldEnabled.Checked = stepNode.StepFieldEnabled;
            if (stepNode.StepFieldName != null)
                textBoxStepField.Text = stepNode.StepFieldName;

            if (stepNode.StepFunctionName != null)
            {
                comboBoxTestFunctionName.Text = stepNode.StepFunctionName;
                /* Assign the hints onto comboBoxTestFunctionName and textBoxParameter1...6 respectively 
                 * as their ToolTip, when the mouse hovers on those controls.
                 */
                try
                {
                    List<string> hints = TestItems.GatherTestFunctionsInfo()[stepNode.StepFunctionName];
                    AssignHintsOntoCtrlsAsToolTip(hints);
                }
                catch (KeyNotFoundException exception)
                {
                    // throw new KeyNotFoundException(exception.ToString());
                    MessageBox.Show(exception.Message, "Exception", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
            }
            if (stepNode.ParamList != null)
                AssignParameterList(stepNode.ParamList);
            if ((stepNode.LimitType != null) && (stepNode.LimitList != null))
                AssignSpecification(stepNode.LimitType, stepNode.LimitList);
        }

        private void AssignHintsOntoCtrlsAsToolTip(List<string> hints)
        {
            int count = hints.Count;
            toolTipHints.RemoveAll();
            switch (count)
            {
                case 0:
                    return;
                case 1:
                    toolTipHints.SetToolTip(comboBoxTestFunctionName, hints[0]);
                    break;
                case 2:
                    toolTipHints.SetToolTip(comboBoxTestFunctionName, hints[0]);
                    toolTipHints.SetToolTip(textBoxParameter1, hints[1]);
                    break;
                case 3:
                    toolTipHints.SetToolTip(comboBoxTestFunctionName, hints[0]);
                    toolTipHints.SetToolTip(textBoxParameter1, hints[1]);
                    toolTipHints.SetToolTip(textBoxParameter2, hints[2]);
                    break;
                case 4:
                    toolTipHints.SetToolTip(comboBoxTestFunctionName, hints[0]);
                    toolTipHints.SetToolTip(textBoxParameter1, hints[1]);
                    toolTipHints.SetToolTip(textBoxParameter2, hints[2]);
                    toolTipHints.SetToolTip(textBoxParameter3, hints[3]);
                    break;
                case 5:
                    toolTipHints.SetToolTip(comboBoxTestFunctionName, hints[0]);
                    toolTipHints.SetToolTip(textBoxParameter1, hints[1]);
                    toolTipHints.SetToolTip(textBoxParameter2, hints[2]);
                    toolTipHints.SetToolTip(textBoxParameter3, hints[3]);
                    toolTipHints.SetToolTip(textBoxParameter4, hints[4]);
                    break;
                case 6:
                    toolTipHints.SetToolTip(comboBoxTestFunctionName, hints[0]);
                    toolTipHints.SetToolTip(textBoxParameter1, hints[1]);
                    toolTipHints.SetToolTip(textBoxParameter2, hints[2]);
                    toolTipHints.SetToolTip(textBoxParameter3, hints[3]);
                    toolTipHints.SetToolTip(textBoxParameter4, hints[4]);
                    toolTipHints.SetToolTip(textBoxParameter5, hints[5]);
                    break;
                case 7:
                    toolTipHints.SetToolTip(comboBoxTestFunctionName, hints[0]);
                    toolTipHints.SetToolTip(textBoxParameter1, hints[1]);
                    toolTipHints.SetToolTip(textBoxParameter2, hints[2]);
                    toolTipHints.SetToolTip(textBoxParameter3, hints[3]);
                    toolTipHints.SetToolTip(textBoxParameter4, hints[4]);
                    toolTipHints.SetToolTip(textBoxParameter5, hints[5]);
                    toolTipHints.SetToolTip(textBoxParameter6, hints[6]);
                    break;
                default:
                    break;
            }
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

        private void CleanupStepContentPanel()
        {
            textBoxStepNo.Text = "";
            textBoxStepName.Text = "";
            textBoxStepDescription.Text = "";

            comboBoxTestFunctionName.Text = "";
            checkBoxStepFieldEnabled.Checked = false;
            textBoxStepField.Text = "";

            textBoxParameter1.Text = "";
            textBoxParameter2.Text = "";
            textBoxParameter3.Text = "";
            textBoxParameter4.Text = "";
            textBoxParameter5.Text = "";
            textBoxParameter6.Text = "";

            comboBoxLimitType.Text = "";
            if (dataGridViewTestSpec.Columns.Count != 0)
            {
                dataGridViewTestSpec.Columns.Clear();
            }
        }

        /*=========================================================================================*/

        private void toolStripBtnSave_Click(object sender, EventArgs e)
        {
            /* Save the changes into XML file */
            if (treeViewSequence.SelectedNode.Tag is Block)
            {
                TreeNode currentSelectedBlockTreeNode = treeViewSequence.SelectedNode;
                Block currentBlockNode = currentSelectedBlockTreeNode.Tag as Block;

                UpdateAndSaveBlockContent(currentBlockNode);
                seq.SaveSequenceToXml();
            }
            else if (treeViewSequence.SelectedNode.Tag is Step)
            {
                ModifyStepContent();
            }
        }

        private void toolStripBtnSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "Save your own XML file, enter your file name.";
            dlg.InitialDirectory = previousOpenedDirectory;
            dlg.DefaultExt = "xml";
            dlg.Filter = "XML file | *.xml";
            dlg.AddExtension = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                seq.SaveAsSequenceToXml(dlg.FileName);

                /* Change the previous directory accordingly */
                previousOpenedDirectory = Path.GetFullPath(dlg.FileName);
                toolStripTextBoxSequenceFilePath.Text = dlg.FileName;
            }
        }

        private void toolStripBtnNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "Enter your sequence XML file name, and save.";
            
            if (previousOpenedDirectory == string.Empty)
            {
                dlg.InitialDirectory = @"C:\";
            }
            else
            {
                dlg.InitialDirectory = previousOpenedDirectory;
            }
            dlg.DefaultExt = "xml";
            dlg.Filter = "XML file | *.xml";
            dlg.AddExtension = true;

            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            /* Create new sequence instance, and save into user-specified sequence.xml file. */
            seq = new Sequence();
            seq.CreateNewSequence(dlg.FileName);

            /* Change the previous directory accordingly */
            previousOpenedDirectory = Path.GetFullPath(dlg.FileName);
            toolStripTextBoxSequenceFilePath.Text = dlg.FileName;

            VisualizeSequenceInTreeView(seq);
        }

        /*=========================================================================================*/

        private void SequenceEditor_KeyDown(object sender, KeyEventArgs e)
        {
            /* Ctrl+S shortcut key */
            if ((e.KeyCode == Keys.S) && (e.Modifiers == Keys.Control))
            {
                if (treeViewSequence.SelectedNode.Tag is Block)
                {
                    TreeNode currentSelectedBlockTreeNode = treeViewSequence.SelectedNode;
                    Block currentBlockNode = currentSelectedBlockTreeNode.Tag as Block;

                    UpdateAndSaveBlockContent(currentBlockNode);
                    seq.SaveSequenceToXml();
                }
                else if (treeViewSequence.SelectedNode.Tag is Step)
                {
                    ModifyStepContent();
                }
            }
        }

        private void UpdateAndSaveBlockContent(Block block)
        {
            string blockNo = textBoxBlockNum.Text;
            string blockName = textBoxBlockName.Text;

            block.UpdateCurrentBlockContentForItems(blockNo, blockName);
            seq.SaveSequenceToXml();
        }

        private void ModifyStepContent()
        {
            TreeNode currentSelectedStepTreeNode = treeViewSequence.SelectedNode;
            TreeNode currentBlockTreeNode = treeViewSequence.SelectedNode.Parent;

            Block currentBlockNode = currentBlockTreeNode.Tag as Block;
            Step currentStepNode = currentSelectedStepTreeNode.Tag as Step;

            int indexOfCurrentSelectedStepTreeNode = treeViewSequence.SelectedNode.Index;

            /*=============================================================================*/

            string stepNum = textBoxStepNo.Text;
            string stepName = textBoxStepName.Text;
            string stepDescription = textBoxStepDescription.Text;
            string stepFunctionName = comboBoxTestFunctionName.Text;
            bool stepFieldEnabled = checkBoxStepFieldEnabled.Checked;
            string stepFieldName;
            if (stepFieldEnabled == true)
            {
                stepFieldName = textBoxStepField.Text;
            }
            else
            {
                stepFieldName = "";
            }

            List<string> parameterList = new List<string>();
            string parameter1 = textBoxParameter1.Text;
            if (parameter1 != string.Empty)
                parameterList.Add(parameter1);
            string parameter2 = textBoxParameter2.Text;
            if (parameter2 != string.Empty)
                parameterList.Add(parameter2);
            string parameter3 = textBoxParameter3.Text;
            if (parameter3 != string.Empty)
                parameterList.Add(parameter3);
            string parameter4 = textBoxParameter4.Text;
            if (parameter4 != string.Empty)
                parameterList.Add(parameter4);
            string parameter5 = textBoxParameter5.Text;
            if (parameter5 != string.Empty)
                parameterList.Add(parameter5);
            string parameter6 = textBoxParameter6.Text;
            if (parameter6 != string.Empty)
                parameterList.Add(parameter6);
            ParameterList stepParameterList = new ParameterList(parameterList, seq.SeqXml);

            string stepLimitType = comboBoxLimitType.Text;

            List<string> limits = new List<string>();
            if (stepLimitType == "String")
            {
                limits.Add(dataGridViewTestSpec.Rows[0].Cells[0].Value as string);
            }
            else if (stepLimitType == "Numerical")
            {
                limits.Add(dataGridViewTestSpec.Rows[0].Cells[0].Value as string);
                limits.Add(dataGridViewTestSpec.Rows[0].Cells[1].Value as string);
                limits.Add(dataGridViewTestSpec.Rows[0].Cells[2].Value as string);
            }
            else if (stepLimitType == string.Empty)
            {
                /* Assign 3 empty strings */
                limits.Add(string.Empty);
                limits.Add(string.Empty);
                limits.Add(string.Empty);
            }
            Spec stepSpec = new Spec(limits, seq.SeqXml);

            /*=============================================================================*/
            /* MUST modify current step node firstly */
            // currentStepNode.ModifyCurrentStep(stepNum, stepName, stepDescription, stepFunctionName, stepParameterList, stepLimitType, stepSpec);
            currentStepNode.ModifyCurrentStep(stepNum,
                                              stepName,
                                              stepDescription,
                                              stepFieldEnabled,
                                              stepFieldName,
                                              stepFunctionName,
                                              stepParameterList,
                                              stepLimitType,
                                              stepSpec);
            /* then modify its parent block node for current step node */
            currentBlockNode.ModifyStepAt(indexOfCurrentSelectedStepTreeNode, currentStepNode);

            seq.SaveSequenceToXml();
        }
    }
}
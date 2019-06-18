using System;
using System.Collections.Generic;
using Amphenol.SequenceLib;
using System.Windows.Forms;

namespace Amphenol.AUPS
{
    partial class SequenceEditor
    {
        private void addNewBlockAfterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* zero-based tree node index value in Block hierarchy */
            int currentBlockTreeNodeIndex = treeViewSequence.SelectedNode.Index;
            /* the count of total tree nodex in Block hierarchy */
            int countOfTotalBlockTreeNodes = treeViewSequence.Nodes.Count;

            /* Only allow to add block node, not step node */
            if (treeViewSequence.SelectedNode.Tag is Block)
            {
                TreeNode newBlockTreeNode = new TreeNode();
                /* Add this new block tree node after current selected block node */
                treeViewSequence.Nodes.Insert(currentBlockTreeNodeIndex + 1, newBlockTreeNode);
                newBlockTreeNode.Text = "New block, please assign your block name";

                /* Prompt user to edit this new block node's name. */
                treeViewSequence.LabelEdit = true;
                treeViewSequence.Nodes[currentBlockTreeNodeIndex + 1].BeginEdit();

                /* Add a new <block> node into the XML file. */
                Block newBlock = new Block(textBoxBlockNum.Text, textBoxBlockName.Text, seq.SeqXml);
                seq.InsertNewBlockAfter(currentBlockTreeNodeIndex, newBlock);
                seq.SaveSequenceToXml();

                /* Assign the tag of newBlockTreeNode. */
                newBlockTreeNode.Tag = newBlock;
            }
        }

        private void addNewBlockBeforeBlockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int currentBlockTreeNodeIndex = treeViewSequence.SelectedNode.Index;
            int countOfTotalBlockTreeNodes = treeViewSequence.Nodes.Count;

            /* Only allow to add block node, rather than step node */
            if (treeViewSequence.SelectedNode.Tag is Block)
            {
                TreeNode newBlockTreeNode = new TreeNode();
                /* Insert this new block tree node before current selected block node */
                treeViewSequence.Nodes.Insert(currentBlockTreeNodeIndex, newBlockTreeNode);
                newBlockTreeNode.Text = "New block, please assign your block name.";

                treeViewSequence.LabelEdit = true;
                treeViewSequence.Nodes[currentBlockTreeNodeIndex].BeginEdit();

                /* Synchronously add a new <block> node into the XML file. */
                Block newBlock = new Block(textBoxBlockNum.Text, textBoxBlockName.Text, seq.SeqXml);
                seq.InsertNewBlockBefore(currentBlockTreeNodeIndex, newBlock);
                seq.SaveSequenceToXml();

                /* Assign the tag of newBlockTreeNodde */
                newBlockTreeNode.Tag = newBlock;
            }
        }

        private void removeCurrentSelectedBlockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* Firstly, we need to prevent from removing all blocks, otherwise it will incur an exception
             * while adding a brand-new block into the tree node. That is the limitation I set deliberately.
             */
            if (treeViewSequence.Nodes.Count == 1)      /* At least 1 block tree node should be remained. */
            {
                return;
            }

            /* Only delete the selected block node */
            if (treeViewSequence.SelectedNode.Tag is Block)
            {
                /* Acquire the tree node and block which will be removed immediately */
                TreeNode blockTreeNodeToRemove = treeViewSequence.SelectedNode;
                Block blockNodeToRemove = blockTreeNodeToRemove.Tag as Block;

                treeViewSequence.Nodes.Remove(blockTreeNodeToRemove);   /* Remove the specified tree node */
                /* Synchronously remove the specified block from XML file */
                seq.RemoveSpecifiedBlock(blockNodeToRemove);
                seq.SaveSequenceToXml();
            }
        }

        private void addNewStepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* Preventing from adding new step before loading sequence.xml, because no seq object was 
             * instantiated, exception will happen while calling ParameterList and Spec constructors.
             */
            if (!((treeViewSequence.SelectedNode.Tag is Step) || (treeViewSequence.SelectedNode.Tag is Block)))
            {
                return;
            }

            string stepNo = textBoxStepNo.Text;
            string stepName = textBoxStepName.Text;
            string stepDescription = textBoxStepDescription.Text;
            string stepFunctionName = comboBoxTestFunctionName.Text;

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

            ParameterList paramlist = new ParameterList(parameterList, seq.SeqXml);

            string stepLimitType = comboBoxLimitType.Text;

            List<string> limitList = new List<string>();
            if (stepLimitType == "String")
            {
                limitList.Add(dataGridViewTestSpec.Rows[0].Cells[0].Value as string);
            }
            else if (stepLimitType == "Numerical")
            {
                limitList.Add(dataGridViewTestSpec.Rows[0].Cells[0].Value as string);
                limitList.Add(dataGridViewTestSpec.Rows[0].Cells[1].Value as string);
                limitList.Add(dataGridViewTestSpec.Rows[0].Cells[2].Value as string);
            }
            else if (stepLimitType == string.Empty)
            {
                limitList.Add(string.Empty);
                limitList.Add(string.Empty);
                limitList.Add(string.Empty);
            }

            Spec limits = new Spec(limitList, seq.SeqXml);

            /*=========================================================================================================*/

            /* Scenario : user selected the block tree node */
            if (treeViewSequence.SelectedNode.Tag is Block)
            {
                TreeNode currentBlockTreeNode = treeViewSequence.SelectedNode;
                Block currentBlockNode = currentBlockTreeNode.Tag as Block;

                /* Add a new step at the last position under current block tree node */
                TreeNode newStepTreeNode = new TreeNode();
                currentBlockTreeNode.Nodes.Add(newStepTreeNode);
                newStepTreeNode.Text = "New step, please assign your step name.";

                /* Prompt user to edit the step name for this new step tree node */
                treeViewSequence.LabelEdit = true;
                newStepTreeNode.BeginEdit();

                /* Synchronously add a new <step> node into the XML file */
                Step newStep = new Step("",     // stepNo, 
                                        "New step, please assign your step name",     //stepName, 
                                        "",     // stepDescription, 
                                        "",     // stepFunctionName, 
                                        paramlist, 
                                        stepLimitType, 
                                        limits, 
                                        seq.SeqXml,
                                        false,
                                        "");
                currentBlockNode.AddNewStep(newStep);
                seq.SaveSequenceToXml();

                /* Assign the tage of newStepTreeNode */
                newStepTreeNode.Tag = newStep;
            }
            /* Scenario : user selected the step tree node */
            else if (treeViewSequence.SelectedNode.Tag is Step)
            {
                /* Firstly retrieve the block tree node */
                TreeNode blockTreeNode = treeViewSequence.SelectedNode.Parent;
                Block blockNode = blockTreeNode.Tag as Block;

                int currentStepTreeNodeIndex = treeViewSequence.SelectedNode.Index;

                TreeNode newStepTreeNode = new TreeNode();
                /* [NOTE] : insert the newStepTreeNode after current selected step tree node */
                blockTreeNode.Nodes.Insert(currentStepTreeNodeIndex+1, newStepTreeNode);
                newStepTreeNode.Text = "New step, please assign your step name";

                treeViewSequence.LabelEdit = true;
                newStepTreeNode.BeginEdit();

                /* Sync to add a new <step> node into XML file. */
                Step newStep = new Step("",     // stepNo, 
                                        "New step, please assign your step name",     //stepName, 
                                        "",     // stepDescription, 
                                        "",     // stepFunctionName, 
                                        paramlist,
                                        stepLimitType,
                                        limits,
                                        seq.SeqXml,
                                        false,
                                        "");
                blockNode.InsertNewStepAfter(currentStepTreeNodeIndex, newStep);
                seq.SaveSequenceToXml();

                /* Assign the tage of newStepTreeNode */
                newStepTreeNode.Tag = newStep;
            }
        }

        private void addNewStepBeforeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* Preventing from adding new step before loading sequence.xml, because no seq object was 
             * instantiated, exception will happen while calling ParameterList and Spec constructors.
             */
            if (!((treeViewSequence.SelectedNode.Tag is Step) || (treeViewSequence.SelectedNode.Tag is Block)))
            {
                return;
            }

            string stepNo = textBoxStepNo.Text;
            string stepName = textBoxStepName.Text;
            string stepDescription = textBoxStepDescription.Text;
            string stepFunctionName = comboBoxTestFunctionName.Text;
            bool stepFieldEnabled = checkBoxStepFieldEnabled.Checked;
            string stepField = textBoxStepField.Text;

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

            ParameterList paramlist = new ParameterList(parameterList, seq.SeqXml);

            string stepLimitType = comboBoxLimitType.Text;

            List<string> limitList = new List<string>();
            if (stepLimitType == "String")
            {
                limitList.Add(dataGridViewTestSpec.Rows[0].Cells[0].Value as string);
            }
            else if (stepLimitType == "Numerical")
            {
                limitList.Add(dataGridViewTestSpec.Rows[0].Cells[0].Value as string);
                limitList.Add(dataGridViewTestSpec.Rows[0].Cells[1].Value as string);
                limitList.Add(dataGridViewTestSpec.Rows[0].Cells[2].Value as string);
            }
            else if (stepLimitType == string.Empty)
            {
                limitList.Add(string.Empty);
                limitList.Add(string.Empty);
                limitList.Add(string.Empty);
            }

            Spec limits = new Spec(limitList, seq.SeqXml);

            /*=========================================================================================================*/

            int index = treeViewSequence.SelectedNode.Index;
            /* This context menu item only valids after user selected step tree node */
            if (treeViewSequence.SelectedNode.Tag is Step)
            {
                TreeNode blockTreeNode = treeViewSequence.SelectedNode.Parent;
                Block blockNode = blockTreeNode.Tag as Block;

                TreeNode newStepTreeNode = new TreeNode();
                /* Insert the newStepTreeNode before current selected step tree node. */
                blockTreeNode.Nodes.Insert(index, newStepTreeNode);
                newStepTreeNode.Text = "New step, please assign your step name";

                treeViewSequence.LabelEdit = true;
                newStepTreeNode.BeginEdit();

                /* Synch to add a new <step> node into the XML file. */
                Step newStep = new Step("",     // stepNo, 
                                        "New step, please assign your step name",     //stepName, 
                                        "",     // stepDescription, 
                                        "",     // stepFunctionName, 
                                        paramlist, 
                                        stepLimitType, 
                                        limits, 
                                        seq.SeqXml,
                                        stepFieldEnabled,
                                        stepField);
                blockNode.InsertNewStepBefore(index, newStep);
                seq.SaveSequenceToXml();

                /* Assign the tag of newStepTreeNode */
                newStepTreeNode.Tag = newStep;
            }
        }

        private void removeCurrentSelectedStepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* This context menu item only valids after user selected step tree node */
            if (treeViewSequence.SelectedNode.Tag is Step)
            {
                Step stepNodeToRemove = treeViewSequence.SelectedNode.Tag as Step;
                TreeNode currentSelectedStepTreeNode = treeViewSequence.SelectedNode;

                TreeNode blockTreeNode = treeViewSequence.SelectedNode.Parent;
                Block blockNode = blockTreeNode.Tag as Block;

                /* Remove current selected step tree node */
                blockTreeNode.Nodes.Remove(currentSelectedStepTreeNode);
                /* Sync to remove the step node from XML file */
                blockNode.RemoveSpecifiedStep(stepNodeToRemove);
                seq.SaveSequenceToXml();
            }
        }
    }
}
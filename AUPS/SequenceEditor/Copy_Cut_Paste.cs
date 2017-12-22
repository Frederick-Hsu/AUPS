using System;
using System.Windows.Forms;
using Amphenol.SequenceLib;

namespace Amphenol.AUPS
{
    partial class SequenceEditor
    {
        private static Step intermediateStep = null;

        private void copyCurrentSelectedStepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* [Notice] : this "copy" menu item only validates when user selected the step tree node,
             *            so, we can but obtain the Step object.
             */
            TreeNode currentSelectedStepTreeNode = treeViewSequence.SelectedNode;
            Step copiedStep = currentSelectedStepTreeNode.Tag as Step;

            intermediateStep = copiedStep;      /* Store the Step object as an intermediate */
#if false
            // Clipboard.Clear();      /* Remove all data objects from the Clipboard. */
            Clipboard.SetDataObject(copiedStep, false);     /* Store the copied object content onto Clipboard. */
#endif
        }

        private void cutCurrentSelectedStepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode currentSelectedStepTreeNode = treeViewSequence.SelectedNode;
            Step currentStepNode = currentSelectedStepTreeNode.Tag as Step;

            TreeNode currentBlockTreeNode = currentSelectedStepTreeNode.Parent;
            Block currentBlockNode = currentBlockTreeNode.Tag as Block;

            intermediateStep = currentStepNode;     /* Assign the currentStepNode to the intermediate */

            /* Remove current selected step tree node */
            currentBlockTreeNode.Nodes.Remove(currentSelectedStepTreeNode);
            /* and sync to remove the <step> node from XML file */
            currentBlockNode.RemoveSpecifiedStep(currentStepNode);
            seq.SaveSequenceToXml();
        }

        private void pasteStepAfterCurrentSelectedStepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* [NOTE] : "paste" context menu item only validates when user selected step tree node. */
            TreeNode currentSelectedStepTreeNode = treeViewSequence.SelectedNode;
            Step currentStepNode = currentSelectedStepTreeNode.Tag as Step;

            TreeNode currentBlockTreeNode = currentSelectedStepTreeNode.Parent;
            Block currentBlock = currentBlockTreeNode.Tag as Block;

            int index = treeViewSequence.SelectedNode.Index;

#if false
            /* Retrieve the data object from clipboard. */
            IDataObject stepDataObj = Clipboard.GetDataObject();
            if (stepDataObj.GetDataPresent(typeof(Step)) == true)
            {
                Step retrievedStep = stepDataObj.GetData(typeof(Step)) as Step;
            }
#endif
            if (intermediateStep == null)
            {
                return;
            }
            Step stepToPaste = intermediateStep;    /* Retrieve the Step object from the intermediate */

            /* Insert this Step object after current selected step tree node. */
            TreeNode stepTreeNodeToPaste = new TreeNode();
            stepTreeNodeToPaste.Text = stepToPaste.StepName;
            stepTreeNodeToPaste.Tag = stepToPaste;

            currentBlockTreeNode.Nodes.Insert(index + 1, stepTreeNodeToPaste);
            treeViewSequence.LabelEdit = true;

            /* meanwhile, remember to insert the <step> node into sequence.xml file */
            currentBlock.InsertNewStepAfter(index, stepToPaste);
            seq.SaveSequenceToXml();

            /* At last, please remember to discard the intermediateStep object after each pasting. */
            intermediateStep = null;
        }
    }
}
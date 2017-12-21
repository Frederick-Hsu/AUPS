using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Amphenol.SequenceLib;

namespace Amphenol.AUPS
{
    public partial class SequenceEditor : Form
    {
        public SequenceEditor()
        {
            InitializeComponent();
        }

        public SequenceEditor(MainWindow parent)
        {
            InitializeComponent();
            MdiParent = parent;

            this.KeyPreview = true;     /* Allow to accept the shortcut key pressing event. */
        }

        private void treeViewSequence_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeViewSequence.SelectedNode.Tag is Block)   /* Block tree node */
            {
                Block selectedBlock = treeViewSequence.SelectedNode.Tag as Block;
                DisplayBlockContentOnPanel(selectedBlock);

                /* Dynamically display the context menu */
                addNewBlockAfterToolStripMenuItem.Enabled = true;
                addNewBlockBeforeBlockToolStripMenuItem.Enabled = true;
                removeCurrentSelectedBlockToolStripMenuItem.Enabled = true;

                addNewStepToolStripMenuItem.Enabled = true;
                addNewStepToolStripMenuItem.Text = "Add new step";

                addNewStepBeforeToolStripMenuItem.Enabled = false;
                removeCurrentSelectedStepToolStripMenuItem.Enabled = false;
                copyCurrentSelectedStepToolStripMenuItem.Enabled = false;
                cutCurrentSelectedStepToolStripMenuItem.Enabled = false;
                pasteStepAfterCurrentSelectedStepToolStripMenuItem.Enabled = false;
            }
            else if (treeViewSequence.SelectedNode.Tag is Step)      /* Step tree node */
            {
                Block selectedBlock = (treeViewSequence.SelectedNode.Parent).Tag as Block;
                Step selectedStep = treeViewSequence.SelectedNode.Tag as Step;

                DisplayBlockContentOnPanel(selectedBlock);
                DisplayStepContentOnPanel(selectedStep);

                /* Dynamically display the context menu */
                addNewBlockAfterToolStripMenuItem.Enabled = false;
                addNewBlockBeforeBlockToolStripMenuItem.Enabled = false;
                removeCurrentSelectedBlockToolStripMenuItem.Enabled = false;

                addNewStepToolStripMenuItem.Enabled = true;
                addNewStepToolStripMenuItem.Text = "Add a new step after current selected step";

                addNewStepBeforeToolStripMenuItem.Enabled = true;
                removeCurrentSelectedStepToolStripMenuItem.Enabled = true;
                copyCurrentSelectedStepToolStripMenuItem.Enabled = true;
                cutCurrentSelectedStepToolStripMenuItem.Enabled = true;
                pasteStepAfterCurrentSelectedStepToolStripMenuItem.Enabled = true;
            }
        }

        private void comboBoxLimitType_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewTestSpec.Columns.Clear();

            if (comboBoxLimitType.Text == "Numerical")
            {
                dataGridViewTestSpec.Columns.Add("LowerLimit", "Lower");
                dataGridViewTestSpec.Columns.Add("TypicalLimit", "Typical");
                dataGridViewTestSpec.Columns.Add("UpperLimit", "Upper");
                dataGridViewTestSpec.Columns.Add("Result", "Result");

                dataGridViewTestSpec.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else if (comboBoxLimitType.Text == "String")
            {
                dataGridViewTestSpec.Columns.Add("ExpectLimit", "Expect");
                dataGridViewTestSpec.Columns.Add("Result", "Result");

                dataGridViewTestSpec.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void textBoxStepName_TextChanged(object sender, EventArgs e)
        {
            string enteredStepNameText = textBoxStepName.Text;
            /* Filter to modify the step name, not the block name. */
            if (treeViewSequence.SelectedNode.Tag is Step)      /* Scenario : user selected the step tree node. */
            {
                TreeNode stepTreeNode = treeViewSequence.SelectedNode;
                stepTreeNode.Text = enteredStepNameText;
            }
            else if (treeViewSequence.SelectedNode.Tag is Block)    /* Scenario : user selected the block tree node. */
            {
                /* Nothing to do. */
            }
        }

        private void treeViewSequence_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            /* Scenario : user selected one block tree node, and want to modify its text. */
            if (treeViewSequence.SelectedNode.Tag is Block)
            {
                this.BeginInvoke(new MethodInvoker(delegate 
                {
                    string newBlockName = treeViewSequence.SelectedNode.Text;
                    textBoxBlockName.Text = newBlockName;
                }));
            }
            /* Scenario : user selected one step tree node, and modify its text. */
            else if (treeViewSequence.SelectedNode.Tag is Step)
            {
                this.BeginInvoke(new MethodInvoker(delegate
                {
                    string newStepName = treeViewSequence.SelectedNode.Text;
                    textBoxStepName.Text = newStepName;
                }));
            }
        }

        private void textBoxBlockName_TextChanged(object sender, EventArgs e)
        {
            string enteredBlockNameText = textBoxBlockName.Text;

            /* Filter to modify the block tree node, not the step node. */
            if (treeViewSequence.SelectedNode.Tag is Block)     /* Scenario : user selected the block tree node.*/
            {
                TreeNode blockTreeNode = treeViewSequence.SelectedNode;
                blockTreeNode.Text = enteredBlockNameText;
            }
            else if (treeViewSequence.SelectedNode.Tag is Step)     /* Scenario : user selected the step tree node. */
            {
                /* Navigate to the bloc tree node (i.e. parent) of current selected step tree node. */
                TreeNode blockTreeNode = treeViewSequence.SelectedNode.Parent;
                blockTreeNode.Text = enteredBlockNameText;
            }
        }
    }
}

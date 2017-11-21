using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Amphenol.Seq;

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
        }

        private void treeViewSequence_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeViewSequence.SelectedNode.Tag is Step)
            {
                DisplayStepContentOnPanel((Step)treeViewSequence.SelectedNode.Tag);
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
    }
}

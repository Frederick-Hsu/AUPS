using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}

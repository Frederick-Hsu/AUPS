using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AUPS.Utilities
{
    public partial class GMVehicleAntennaTesting : Form
    {
        public GMVehicleAntennaTesting()
        {
            InitializeComponent();
        }

        public GMVehicleAntennaTesting(Amphenol.AUPS.MainWindow parent)
        {
            InitializeComponent();
            MdiParent = parent;
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            // System.Drawing.Graphics graph = tabPageField.CreateGraphics();
            System.Drawing.Graphics graph = this.CreateGraphics();
            Pen blackPen = new Pen(Color.Black, 5);
            graph.DrawLine(blackPen, 500, 500, 500, 1000);

            Point location = tabControlTesting.Location;
            Size tabSize = tabControlTesting.Size;
            Point center = new Point(location.X + tabSize.Width / 2, location.Y + tabSize.Height / 2);
            Point down = new Point(center.X, center.Y + 200);
            Point left = new Point(center.X + 1000, center.Y);

            System.Drawing.Graphics tabGraph = tabPageField.CreateGraphics();
            Pen redPen = new Pen(Color.Red, 5);
            tabGraph.DrawLine(redPen, center, down);
            tabGraph.DrawLine(redPen, center, left);
            tabGraph.DrawEllipse(blackPen, center.X, center.Y, 100, 100);
        }
    }
}

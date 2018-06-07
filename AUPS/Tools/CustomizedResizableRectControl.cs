using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AUPS.Tools
{
    public partial class CustomizedResizableRectControl : UserControl
    {
        #region Fields
        private Control baseCtrl;

        const int Band = 5;
        const int MinWidth = 20, MinHeight = 20;
        private Size square = new Size(Band, Band);
        Graphics graph;

        Rectangle[] smallRects = new Rectangle[8];
        Rectangle[] sideRects = new Rectangle[4];
        Point[] linePoints = new Point[5];
        Rectangle controlRect;
        private MousePosOnCtrl mpoc;

        private Point prevPoint, currPoint;
        #endregion

        #region Properties
        private enum MousePosOnCtrl
        {
            NONE = 0,
            TOP = 1,
            RIGHT = 2,
            BOTTOM = 3,
            LEFT = 4,
            TOPLEFT = 5,
            TOPRIGHT = 6,
            BOTTOMLEFT = 7,
            BOTTOMRIGHT = 8
        }
        #endregion

        #region Constructor
        public CustomizedResizableRectControl()
        {
            InitializeComponent();
        }

        public CustomizedResizableRectControl(Control originCtrl)
        {
            InitializeComponent();
            baseCtrl = originCtrl;
            AddEvents();
            CreateBounds();
        }
        #endregion

        #region Methods
        private void AddEvents()
        {
            this.Name = "ResizableRectControl" + baseCtrl.Name;
            this.MouseClick += new MouseEventHandler(OnMouseClick);
            this.MouseDown += new MouseEventHandler(OnMouseDown);
            this.MouseMove += new MouseEventHandler(OnMouseMove);
            this.MouseUp += new MouseEventHandler(OnMouseUp);
        }

        private void CreateBounds()
        {
            /* Calculate the position for the base control's border */
            int x = baseCtrl.Bounds.X - square.Width - 1;
            int y = baseCtrl.Bounds.Y - square.Height - 1;
            /* and size */
            int width = baseCtrl.Bounds.Width + (square.Width * 2) + 2;
            int height = baseCtrl.Bounds.Height + (square.Height * 2) + 2;

            this.Bounds = new Rectangle(x, y, width, height);
            this.BringToFront();
            SetRectangle();
            this.Region = new Region(BUildFrame());

            graph = this.CreateGraphics();
        }

        private void SetRectangle()
        {
            /* 8 small rectangles */
            smallRects[0] = new Rectangle(new Point(0, 0), square);
            smallRects[1] = new Rectangle(new Point(this.Width - square.Width - 1, 0), square);
            smallRects[2] = new Rectangle(new Point(0, this.Height - square.Height - 1), square);
            smallRects[3] = new Rectangle(new Point(this.Width - square.Width - 1, this.Height - square.Height - 1), square);
            smallRects[4] = new Rectangle(new Point(this.Width / 2 - 1, 0), square);
            smallRects[5] = new Rectangle(new Point(this.Width / 2 - 1, this.Height - square.Height - 1), square);
            smallRects[6] = new Rectangle(new Point(0, this.Height - square.Height - 1), square);
            smallRects[7] = new Rectangle(new Point(this.Width + square.Width + 1, this.Height - 1), square);
            /* 5 points to draw the outer frame */
            linePoints[0] = new Point(square.Width / 2, square.Height / 2);
            linePoints[1] = new Point(this.Width - square.Width / 2 - 1, square.Height / 2);
            linePoints[2] = new Point(this.Width - square.Width / 2 - 1, this.Height - square.Height / 2);
            linePoints[3] = new Point(square.Width / 2, this.Height - square.Height / 2 - 1);
            linePoints[4] = new Point(square.Width / 2, square.Height / 2);

            controlRect = new Rectangle(new Point(0, 0), this.Bounds.Size);
        }

        private System.Drawing.Drawing2D.GraphicsPath BUildFrame()
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();

            sideRects[0] = new Rectangle(0, 0, this.Width - square.Width - 1, square.Height + 1);
            sideRects[1] = new Rectangle(0, square.Height + 1, square.Width + 1, this.Height - square.Height - 1);
            sideRects[2] = new Rectangle(square.Width + 1, this.Height - square.Height - 1, this.Width - square.Width - 1, square.Height + 1);
            sideRects[3] = new Rectangle(this.Width - square.Width - 1, 0, square.Width + 1, this.Height - square.Height - 1);

            path.AddRectangle(sideRects[0]);
            path.AddRectangle(sideRects[1]);
            path.AddRectangle(sideRects[2]);
            path.AddRectangle(sideRects[3]);

            return path;
        }

        public void Draw()
        {
            this.BringToFront();
            graph.FillRectangles(Brushes.LightGray, sideRects);
            Pen pen = new Pen(Color.Black);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            graph.DrawLines(pen, linePoints);
            graph.FillRectangles(Brushes.White, smallRects);

            foreach (Rectangle rect in smallRects)
            {
                graph.DrawEllipse(Pens.Black, rect);
            }
            graph.DrawRectangles(Pens.Black, smallRects);
        }

        public bool SetCursorShape(int x, int y)
        {
            Point point = new Point(x, y);

            if      (!controlRect.Contains(point))  { Cursor.Current = Cursors.Arrow; return false; }
            else if (smallRects[0].Contains(point)) { Cursor.Current = Cursors.SizeNWSE; mpoc = MousePosOnCtrl.TOPLEFT; }
            else if (smallRects[1].Contains(point)) { Cursor.Current = Cursors.SizeNESW; mpoc = MousePosOnCtrl.TOPRIGHT; }
            else if (smallRects[2].Contains(point)) { Cursor.Current = Cursors.SizeNESW; mpoc = MousePosOnCtrl.BOTTOMLEFT; }
            else if (smallRects[3].Contains(point)) { Cursor.Current = Cursors.SizeNWSE; mpoc = MousePosOnCtrl.BOTTOMRIGHT; }
            else if (sideRects[0].Contains(point))  { Cursor.Current = Cursors.SizeNS;   mpoc = MousePosOnCtrl.TOP; }
            else if (sideRects[1].Contains(point))  { Cursor.Current = Cursors.SizeWE;   mpoc = MousePosOnCtrl.LEFT; }
            else if (sideRects[2].Contains(point))  { Cursor.Current = Cursors.SizeNS;   mpoc = MousePosOnCtrl.BOTTOM; }
            else if (sideRects[3].Contains(point))  { Cursor.Current = Cursors.SizeWE;   mpoc = MousePosOnCtrl.RIGHT; }
            else                                    { Cursor.Current = Cursors.Arrow; }
            return true;
        }

        private void DrawDragBorder(Control ctrl)
        {
            ctrl.Refresh();
            Graphics g = ctrl.CreateGraphics();
            int width = ctrl.Width;
            int height = ctrl.Height;

            Point[] points = new Point[5] { new Point(ctrl.Location.X, ctrl.Location.Y),
                                            new Point(ctrl.Location.X + width-1, ctrl.Location.Y),
                                            new Point(ctrl.Location.X + width-1, ctrl.Location.Y-height-1),
                                            new Point(ctrl.Location.X, ctrl.Location.Y+height-1),
                                            new Point(ctrl.Location.X, ctrl.Location.Y)};
            g.DrawLines(new Pen(Color.Black), points);
        }

        public void DragToResizeControl()
        {
            currPoint = Cursor.Position;
            int x = currPoint.X - prevPoint.X;
            int y = currPoint.Y - prevPoint.Y;

            switch (this.mpoc)
            {
                case MousePosOnCtrl.TOP:
                    if (baseCtrl.Height - y > MinHeight) { baseCtrl.Top += y; baseCtrl.Height -= y; }
                    else                                 { baseCtrl.Top -= MinHeight - baseCtrl.Height; baseCtrl.Height = MinHeight; }
                    break;
                case MousePosOnCtrl.BOTTOM:
                    if (baseCtrl.Height + y > MinHeight) { baseCtrl.Height += y; }
                    else                                 { baseCtrl.Height = MinHeight; }
                    break;
                case MousePosOnCtrl.LEFT:
                    if (baseCtrl.Width - x > MinWidth)   { baseCtrl.Left += x; baseCtrl.Width -= x; }
                    else                                 { baseCtrl.Left -= (MinWidth - baseCtrl.Width); baseCtrl.Width = MinWidth; }
                    break;
                case MousePosOnCtrl.RIGHT:
                    if (baseCtrl.Width + x > MinWidth)   { baseCtrl.Width += x; }
                    else                                 { baseCtrl.Width = MinWidth; }
                    break;
                case MousePosOnCtrl.TOPLEFT:
                    if (baseCtrl.Height - y > MinHeight) { baseCtrl.Top += y; baseCtrl.Height -= y; }
                    else                                 { baseCtrl.Height -= (MinHeight - baseCtrl.Height); baseCtrl.Height = MinHeight; }
                    if (baseCtrl.Width - x > MinWidth)   { baseCtrl.Left += x;  baseCtrl.Width -= x; }
                    else                                 { baseCtrl.Left -= (MinWidth - baseCtrl.Width); baseCtrl.Width = MinWidth; }
                    break;
                case MousePosOnCtrl.TOPRIGHT:
                    if (baseCtrl.Height - y > MinHeight) { baseCtrl.Top += y;  baseCtrl.Height -= y; }
                    else                                 { baseCtrl.Top -= (MinHeight - baseCtrl.Height); baseCtrl.Height = MinHeight; }
                    if (baseCtrl.Width + x > MinWidth)   { baseCtrl.Width += x; }
                    else                                 { baseCtrl.Width = MinWidth; }
                    break;
                case MousePosOnCtrl.BOTTOMLEFT:
                    if (baseCtrl.Height + y > MinHeight) { baseCtrl.Height += y; }
                    else                                 { baseCtrl.Height = MinHeight; }
                    if (baseCtrl.Width - x > MinWidth)   { baseCtrl.Left += x;  baseCtrl.Width -= x; }
                    else                                 { baseCtrl.Left -= (MinWidth - baseCtrl.Width); baseCtrl.Width = MinWidth; }
                    break;
                case MousePosOnCtrl.BOTTOMRIGHT:
                    if (baseCtrl.Height + y > MinHeight) { baseCtrl.Height += y; }
                    else                                 { baseCtrl.Height = MinHeight; }
                    if (baseCtrl.Width + x > MinWidth)   { baseCtrl.Width += x; }
                    else                                 { baseCtrl.Width = MinWidth; }
                    break;
            }
            prevPoint = Cursor.Position;
        }
        #endregion

        #region Events
        private void OnMouseClick(object sender, MouseEventArgs e)
        {
            this.Parent.Refresh();
            this.BringToFront();
            Draw();
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            prevPoint = Cursor.Position;
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Visible = false;
                /* Move the mouse to drag the control to resize */
                DrawDragBorder(baseCtrl);
                DragToResizeControl();
            }
            else
            {
                this.Visible = true;
                SetCursorShape(e.X, e.Y);
            }
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            baseCtrl.Refresh();
            this.Visible = true;
            CreateBounds();
            Draw();
        }
        #endregion
    }
}

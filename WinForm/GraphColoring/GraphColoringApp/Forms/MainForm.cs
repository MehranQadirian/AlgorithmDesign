using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GraphColoringApp.Logic;
using GraphColoringApp.Utils;
using GraphColoringApp.Models;
using System.Drawing.Drawing2D;
using System.Collections.Generic;

namespace GraphColoringApp.Forms
{
    public partial class MainForm : Form
    {
        readonly GraphManager gm = new GraphManager();
        readonly Timer anim = new Timer();
        Point dragOff;
        Node dragNode = null, edgeStart = null;
        Point curMouse;

        private int animationStep = 0;
        private float animationProgress = 0f; // از 0 تا 1 برای افکت نرمی
        private Timer animationTimer;

        private List<Color> colorPalette = new List<Color> {
            Color.Red, Color.Green, Color.Blue,
            Color.Orange, Color.Purple, Color.Cyan,
            Color.Brown, Color.Magenta, Color.YellowGreen,
            Color.DeepSkyBlue, Color.HotPink
        };


        readonly Color[] palette = {
            Color.Red, Color.Green, Color.Blue,
            Color.Orange, Color.Purple, Color.Brown,
            Color.YellowGreen
        };

        int animStep = 0;

        public MainForm()
        {
            InitializeComponent();
            DoubleBuffered = true;

            animationTimer = new Timer();
            animationTimer.Interval = 5; 
            animationTimer.Tick += AnimationTimer_Tick;

            this.Icon = Properties.Resources.icon;

            MouseDown += MainForm_MouseDown;
            MouseMove += MainForm_MouseMove;
            MouseUp += MainForm_MouseUp;
            Paint += MainForm_Paint;

            anim.Interval = 50;
            anim.Tick += (s, e) =>
            {
                if (animStep >= gm.Nodes.Count)
                    anim.Stop();
                else
                {
                    gm.GreedyColor(colorPalette.ToList());
                    animStep = gm.Nodes.Count;
                    Invalidate();
                }
            };
        }

        private void DrawFilledArrow(Graphics g, Pen pen, Brush brush, Point from, Point to)
        {
            var angle = Math.Atan2(to.Y - from.Y, to.X - from.X);
            var arrowLength = 15;
            var arrowWidth = 7;

            
            Point tip = to;
            Point base1 = new Point(
                (int)(to.X - arrowLength * Math.Cos(angle) + arrowWidth * Math.Sin(angle)),
                (int)(to.Y - arrowLength * Math.Sin(angle) - arrowWidth * Math.Cos(angle)));

            Point base2 = new Point(
                (int)(to.X - arrowLength * Math.Cos(angle) - arrowWidth * Math.Sin(angle)),
                (int)(to.Y - arrowLength * Math.Sin(angle) + arrowWidth * Math.Cos(angle)));

            // رسم خط اصلی
            g.DrawLine(pen, from, to);

            // رسم مثلث پر شده به عنوان سر پیکان
            Point[] arrowPoints = { tip, base1, base2 };
            g.FillPolygon(brush, arrowPoints);
        }


        private void DrawCurvedArrow(Graphics g, Pen pen, Point from, Point to)
        {
            // تعیین نقاط میانی قوس (با افکت جابجایی عمودی)
            int curveHeight = 20; 
            Point mid = new Point((from.X + to.X) / 2, (from.Y + to.Y) / 2 - curveHeight);

            using (var path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                path.AddBezier(from, mid, mid, to);

                g.DrawPath(pen, path);
                
                DrawFilledArrow(g, pen, Brushes.Gray, mid, to);
            }
        }



        private void MainForm_Paint(object s, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(ThemeManager.BackgroundColor);

            using (var pen = new Pen(ThemeManager.EdgeColor, 2))
            using (var arrow = new Pen(ThemeManager.EdgeColor, 2))
            {
                LineCap EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                foreach (var ed in gm.Edges)
                {
                    var a = gm.Nodes.First(n => n.Id == ed.FromId).Position;
                    var b = gm.Nodes.First(n => n.Id == ed.ToId).Position;
                    if (ed.IsDirected)
                        DrawCurvedArrow(e.Graphics, pen, a, b);
                    else
                        g.DrawLine(pen, a, b);
                }
            };

            

            if (edgeStart != null)
            {
                using (var dash = new Pen(Color.DarkRed, 2))
                {
                    DashStyle DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    g.DrawLine(dash, edgeStart.Position, curMouse);
                };
                
            }

            foreach (var n in gm.Nodes)
            {
                Rectangle rect = new Rectangle(n.Position.X - 20, n.Position.Y - 20, 40, 40);

                Brush brush;
                if (n.Color == -1)
                    brush = Brushes.LightGray;
                else
                {
                    if (gm.Nodes.IndexOf(n) == animationStep && animationTimer.Enabled)
                    {
                        var targetColor = colorPalette[n.Color];
                        var startColor = Color.LightGray;

                        int red = (int)(startColor.R + (targetColor.R - startColor.R) * animationProgress);
                        int green = (int)(startColor.G + (targetColor.G - startColor.G) * animationProgress);
                        int blue = (int)(startColor.B + (targetColor.B - startColor.B) * animationProgress);

                        brush = new SolidBrush(Color.FromArgb(red, green, blue));
                    }
                    else
                    {
                        brush = new SolidBrush(colorPalette[n.Color]);
                    }
                }

                e.Graphics.FillEllipse(brush, rect);
                e.Graphics.DrawEllipse(Pens.Black, rect);

                // حلقه متحرک دور گره در حال رنگ آمیزی
                if (gm.Nodes.IndexOf(n) == animationStep && animationTimer.Enabled)
                {
                    int pulseRadius = 25 + (int)(5 * Math.Sin(animationProgress * Math.PI * 2));
                    var pen = new Pen(Color.Orange, 3);
                    e.Graphics.DrawEllipse(pen, new Rectangle(n.Position.X - pulseRadius, n.Position.Y - pulseRadius, pulseRadius * 2, pulseRadius * 2));
                    pen.Dispose();
                }

                TextRenderer.DrawText(e.Graphics, n.Id.ToString(), this.Font, rect, Color.White,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        void MainForm_MouseDown(object s, MouseEventArgs e)
        {
            var hit = gm.Nodes.FirstOrDefault(n =>
                Math.Pow(n.Position.X - e.X, 2) + Math.Pow(n.Position.Y - e.Y, 2) <= 400);

            if (e.Button == MouseButtons.Left)
            {
                if (hit != null)
                {
                    if (ModifierKeys.HasFlag(Keys.Shift))
                    {
                        edgeStart = hit;
                    }
                    else
                    {
                        dragNode = hit;
                        dragOff = new Point(e.X - hit.Position.X, e.Y - hit.Position.Y);
                    }
                }
                else
                {
                    gm.AddNode(e.X, e.Y);
                    Invalidate();
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (hit != null)
                    gm.RemoveNode(hit.Id);
                else
                {
                    var rem = gm.Edges.FirstOrDefault(ed =>
                    {
                        var p = gm.Nodes.First(n => n.Id == ed.FromId).Position;
                        var q = gm.Nodes.First(n => n.Id == ed.ToId).Position;
                        var d = DistanceToSegment(p, q, e.Location);
                        return d < 5;
                    });
                    if (rem != null)
                        gm.Edges.Remove(rem);
                }
                Invalidate();
            }
        }

        void MainForm_MouseUp(object s, MouseEventArgs e)
        {
            if (edgeStart != null)
            {
                var hit = gm.Nodes.FirstOrDefault(n =>
                    n != edgeStart &&
                    Math.Pow(n.Position.X - e.X, 2) + Math.Pow(n.Position.Y - e.Y, 2) <= 400);
                if (hit != null)
                    gm.AddEdge(edgeStart.Id, hit.Id, checkDirected.Checked);
            }
            dragNode = null;
            edgeStart = null;
            animStep = 0;
            Invalidate();
        }

        void MainForm_MouseMove(object s, MouseEventArgs e)
        {
            curMouse = e.Location;
            if (dragNode != null)
            {
                dragNode.Position = new Point(e.X - dragOff.X, e.Y - dragOff.Y);
                Invalidate();
            }
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (animationStep >= gm.Nodes.Count)
            {
                animationTimer.Stop();
                Invalidate();
                return;
            }

            animationProgress += 0.15f; // سرعت تغییر رنگ

            if (animationProgress >= 1f)
            {
                var node = gm.Nodes[animationStep];
                var neighborIds = gm.Edges
                    .Where(ed => ed.FromId == node.Id || (!ed.IsDirected && ed.ToId == node.Id))
                    .Select(ed => ed.FromId == node.Id ? ed.ToId : ed.FromId)
                    .ToHashSet();

                var usedColors = gm.Nodes
                    .Where(n => neighborIds.Contains(n.Id))
                    .Select(n => n.Color)
                    .Where(c => c != -1)
                    .ToHashSet();

                for (int c = 0; c < colorPalette.Count; c++)
                {
                    if (!usedColors.Contains(c))
                    {
                        node.Color = c;
                        break;
                    }
                }

                animationStep++;
                animationProgress = 0f;
            }

            Invalidate();
        }


        private double DistanceToSegment(Point A, Point B, Point P)
        {
            double dx = B.X - A.X, dy = B.Y - A.Y;
            if (dx == 0 && dy == 0)
                return Math.Sqrt(Math.Pow(P.X - A.X, 2) + Math.Pow(P.Y - A.Y, 2));
            double t = ((P.X - A.X) * dx + (P.Y - A.Y) * dy) / (dx * dx + dy * dy);
            t = Math.Max(0, Math.Min(1, t));
            var X = A.X + t * dx;
            var Y = A.Y + t * dy;
            return Math.Sqrt(Math.Pow(P.X - X, 2) + Math.Pow(P.Y - Y, 2));
        }

        private void BtnColor_Click(object s, EventArgs e)
        {
            foreach (var n in gm.Nodes)
                n.Color = -1;

            animationStep = 0;
            animationProgress = 0f;
            animationTimer.Start();

        }

        private void BtnReset_Click(object s, EventArgs e)
        {
            gm.Clear();
            Invalidate();
        }

        private void BtnSave_Click(object s, EventArgs e)
        {
            using (var dlg = new SaveFileDialog { Filter = "Graph|*.graphjson" })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var data = new GraphData
                    {
                        Nodes = gm.Nodes,
                        Edges = gm.Edges
                    };
                    GraphSaver.Save(dlg.FileName, data);
                }
            }
        }

        private void BtnLoad_Click(object s, EventArgs e)
        {
            using (var dlg = new OpenFileDialog { Filter = "Graph|*.graphjson" }) 
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var gd = GraphSaver.Load(dlg.FileName);
                gm.Clear();
                gm.Nodes.AddRange(gd.Nodes);
                gm.Edges.AddRange(gd.Edges);
                gm.SetNextNodeId();
                Invalidate();
            }
        }

        private void BtnTheme_Click(object s, EventArgs e)
        {
            ThemeManager.ToggleTheme();
            Invalidate();
        }

        private void BtnDeveloper_Click(object s, EventArgs e)
        {
            new DeveloperInfoForm().ShowDialog();
        }
    }
}

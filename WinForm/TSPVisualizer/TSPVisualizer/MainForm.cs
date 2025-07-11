using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TSPVisualizer.Core;
using TSPVisualizer.Core.Algorithms;
using TSPVisualizer.Core.Commands;
using TSPVisualizer.Models;
using System.Runtime.InteropServices;

namespace TSPVisualizer
{
    public partial class MainForm : Form
    {
        private List<ITspSolver> solvers = new List<ITspSolver>();

        private GraphManager graphManager;
        private int cityCount = 1;
        private ContextMenuStrip cityContextMenu;
        private City selectedCity = null;
        private bool isDragging = false;
        private City draggingCity = null;
        private Point dragOffset;
        private CommandManager commandManager;
        private Point oldDragPosition;
        private List<City> tspPath = new List<City>();
        private int animationIndex = 0;
        private Timer animationTimer;
        private bool isAnimating = false;
        private double total;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;


        public MainForm()
        {
            InitializeComponent();

            InitializeContextMenu();
            LoadSolvers();

            graphManager = new GraphManager();
            commandManager = new CommandManager();

            animationTimer = new Timer();
            animationTimer.Interval = 500;
            animationTimer.Tick += AnimationTimer_Tick;

            this.MouseClick += MainForm_MouseClick;
            this.Paint += MainForm_Paint;
            this.MouseDown += MainForm_MouseDown;
            this.MouseMove += MainForm_MouseMove;
            this.MouseUp += MainForm_MouseUp;
            this.KeyPreview = true;
            this.KeyDown += MainForm_KeyDown;
            this.FormBorderStyle = FormBorderStyle.None; // حذف قاب
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 2, 2)); // گوشه گرد
            this.BackColor = Color.FromArgb(34, 34, 34); 

            InitializeTitleBar();

            btnRunTSP.Click += btnRunTSP_Click;
            //btnStartAnimation.Click += (s, e) => StartAnimation();
            btnStopAnimation.Click += (s, e) => StopAnimation();
        }

        private void pnlTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private Panel titleBar;
        private Button btnClose, btnMinimize;
        private Point lastPoint;
        private PictureBox iconForm;

        private void InitializeTitleBar()
        {
            titleBar = new Panel()
            {
                Height = 40,
                Dock = DockStyle.Top,
                BackColor = Color.FromArgb(45, 45, 48)
            };
            this.Controls.Add(titleBar);
            titleBar.MouseDown += (s, e) => lastPoint = e.Location;
            titleBar.MouseMove += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    this.Left += e.X - lastPoint.X;
                    this.Top += e.Y - lastPoint.Y;
                }
            };
            iconForm = new PictureBox()
            {
                Size = new Size(50,50),
                Dock = DockStyle.Left,
                Image = Properties.Resources.icons8_journey_40px_1,
                Padding = new Padding(10,2,0,2)
            };
            titleBar.Controls.Add(iconForm);
            btnClose = new Button()
            {
                Text = "X",
                ForeColor = Color.White,
                BackColor = Color.DarkRed,
                FlatStyle = FlatStyle.Flat,
                Width = 25,
                Height = 27,
                Location = new Point(this.Width - 30, 0),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => this.Close();
            titleBar.Controls.Add(btnClose);

            btnMinimize = new Button()
            {
                Text = "_",
                ForeColor = Color.White,
                BackColor = Color.Gray,
                FlatStyle = FlatStyle.Flat,
                Width = 25,
                Height = 27,
                Location = new Point(this.Width - 60, 0),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.Click += (s, e) => this.WindowState = FormWindowState.Minimized;
            titleBar.Controls.Add(btnMinimize);

            
        }

        private void StartAnimation()
        {
            if (tspPath == null || tspPath.Count < 2)
                return;

            animationIndex = 0;
            isAnimating = true;
            animationTimer.Start();
        }
        private void StopAnimation()
        {
            animationTimer.Stop();
            isAnimating = false;
            animationIndex = 0;
            Invalidate();
        }

        private void LoadSolvers()
        {
            solvers.Add(new NearestNeighborSolver());
            solvers.Add(new BruteForceSolver());
            solvers.Add(new GeneticSolver());

            if (cmbAlgorithm == null)
            {
                MessageBox.Show("cmbAlgorithm مقداردهی نشده است!");
                return;
            }

            foreach (var solver in solvers)
                cmbAlgorithm.Items.Add(solver.Name);

            if (cmbAlgorithm.Items.Count > 0)
                cmbAlgorithm.SelectedIndex = 0;
        }


        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            animationIndex++;

            if (animationIndex >= tspPath.Count)
            {
                animationTimer.Stop();
                isAnimating = false;
                animationIndex = 0;
            }

            Invalidate();
            UpdatePathInfo();
        }


        private void btnRunTSP_Click(object sender, EventArgs e)
        {
            if (cmbAlgorithm.SelectedIndex < 0 || graphManager.Cities.Count < 2)
                return;

            var solver = solvers[cmbAlgorithm.SelectedIndex];
            var path = solver.FindPath(new List<City>(graphManager.Cities));

            if (path.Count > 1)
            {
                double totalLength = 0;
                for (int i = 0; i < path.Count - 1; i++)
                    totalLength += GraphManager.CalculateDistance(path[i], path[i + 1]);
                totalLength += GraphManager.CalculateDistance(path[path.Count - 1], path[0]);

                tspPath = path;
                lblPathLength.Text = $"طول مسیر: {totalLength:F2}";

                Invalidate();
            }
            StartAnimation();
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                foreach (var city in graphManager.Cities)
                {
                    var dx = city.Location.X - e.X;
                    var dy = city.Location.Y - e.Y;
                    if (Math.Sqrt(dx * dx + dy * dy) <= 10)
                        return;
                }

                string name = "C" + cityCount++;
                var cityToAdd = new City(name, e.Location);
                var cmd = new AddCityCommand(graphManager, cityToAdd);
                commandManager.ExecuteCommand(cmd);
                Invalidate();
            }
            else if (e.Button == MouseButtons.Right)
            {
                foreach (var city in graphManager.Cities)
                {
                    var dx = city.Location.X - e.X;
                    var dy = city.Location.Y - e.Y;
                    if (Math.Sqrt(dx * dx + dy * dy) <= 10)
                    {
                        selectedCity = city;
                        cityContextMenu.Show(this, e.Location);
                        return;
                    }
                }
                selectedCity = null;
            }
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                foreach (var city in graphManager.Cities)
                {
                    var dx = city.Location.X - e.X;
                    var dy = city.Location.Y - e.Y;
                    if (Math.Sqrt(dx * dx + dy * dy) <= 10)
                    {
                        draggingCity = city;
                        oldDragPosition = city.Location;
                        dragOffset = new Point(e.X - city.Location.X, e.Y - city.Location.Y);
                        isDragging = true;
                        break;
                    }
                }
            }
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && draggingCity != null)
            {
                draggingCity.Location = new Point(e.X - dragOffset.X, e.Y - dragOffset.Y);
                Invalidate();
            }
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDragging && draggingCity != null)
            {
                var moveCmd = new MoveCityCommand(draggingCity, oldDragPosition, draggingCity.Location);
                commandManager.ExecuteCommand(moveCmd);
                isDragging = false;
                draggingCity = null;
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z)
            {
                commandManager.Undo();
                Invalidate();
            }
            else if (e.Control && e.KeyCode == Keys.Y)
            {
                commandManager.Redo();
                Invalidate();
            }
        }

        private void DeleteItem_Click(object sender, EventArgs e)
        {
            if (selectedCity != null)
            {
                graphManager.RemoveCity(selectedCity);
                selectedCity = null;
                Invalidate();
            }
        }

        private void EditItem_Click(object sender, EventArgs e)
        {
            if (selectedCity != null)
            {
                string newName = Prompt.ShowDialog("نام جدید برای شهر:", "ویرایش شهر");
                if (!string.IsNullOrEmpty(newName))
                {
                    selectedCity.Name = newName;
                    Invalidate();
                }
            }
        }

        private void InitializeContextMenu()
        {
            cityContextMenu = new ContextMenuStrip();
            var editItem = new ToolStripMenuItem("ویرایش نام شهر");
            var deleteItem = new ToolStripMenuItem("حذف شهر");

            editItem.Click += EditItem_Click;
            deleteItem.Click += DeleteItem_Click;

            cityContextMenu.Items.Add(editItem);
            cityContextMenu.Items.Add(deleteItem);
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Font font = new Font("Segoe UI", 10);
            Brush cityBrush = new SolidBrush(Color.Coral);
            Brush textBrush = Brushes.White;

            foreach (var city in graphManager.Cities)
            {
                g.FillEllipse(cityBrush, city.Location.X - 10, city.Location.Y - 10, 20, 20);
                g.DrawString(city.Name, font, textBrush, city.Location.X + 12, city.Location.Y - 10);
            }

            foreach (var (c1, c2, dist) in graphManager.GetAllEdges())
            {
                g.DrawLine(Pens.LightGray, c1.Location, c2.Location);
                var midX = (c1.Location.X + c2.Location.X) / 2;
                var midY = (c1.Location.Y + c2.Location.Y) / 2;
                string distanceText = ((int)dist).ToString();
                var textSize = g.MeasureString(distanceText, font);
                var textPos = new PointF(midX - textSize.Width / 2, midY - textSize.Height / 2);
                g.DrawString(distanceText, font, Brushes.White, textPos);
            }

            if (tspPath != null && tspPath.Count > 1)
            {
                using (var tspPen = new Pen(Color.Orange, 3))
                {
                    for (int i = 0; i < tspPath.Count - 1; i++)
                        g.DrawLine(tspPen, tspPath[i].Location, tspPath[i + 1].Location);

                    g.DrawLine(tspPen, tspPath[tspPath.Count - 1].Location, tspPath[0].Location);

                }
            }

            if (isAnimating && animationIndex < tspPath.Count)
            {
                var point = tspPath[animationIndex].Location;
                g.FillEllipse(Brushes.DarkMagenta, point.X - 6, point.Y - 6, 12, 12);
            }
        }

        private void UpdatePathInfo()
        {
            lblCityCount.Text = $"تعداد شهرها: {graphManager.Cities.Count}";

            double total = 0;
            for (int i = 0; i < tspPath.Count - 1; i++)
                total += GraphManager.CalculateDistance(tspPath[i], tspPath[i + 1]);

            if (tspPath.Count > 1)
                total += GraphManager.CalculateDistance(tspPath[tspPath.Count - 1], tspPath[0]);

            lblTotalDistance.Text = $"طول مسیر: {(int)total}";

            lstPath.Items.Clear();
            for (int i = 0; i < tspPath.Count; i++)
                lstPath.Items.Add($"{i + 1}. {tspPath[i].Name}");
        }
    }
}

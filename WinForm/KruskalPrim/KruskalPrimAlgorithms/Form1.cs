using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Xml;

namespace KruskalPrimAlgorithms
{
    public partial class MainForm : Form
    {
        // کنترل های فرم
        private Panel panelMain;
        private Panel panelGraphInput;
        private Panel panelResults;
        private Panel panelSavedFiles;
        private Label lblVerticesCount;
        private NumericUpDown numVertices;
        private Button btnGenerateGraph;
        private Label lblGraphRepresentation;
        private ListBox lstGraph;
        private Label lblResults;
        private ListBox lstResults;
        private Button btnKruskal;
        private Button btnPrim;
        private Button btnInfo;
        private Button btnChangeLanguage;
        private ComboBox cmbThemes;
        private Button btnSaveGraph;
        private Button btnLoadGraph;
        private ListBox lstSavedFiles;
        private Label lblSavedFiles;

        // متغیرهای برنامه
        private int[,] graph;
        private List<Edge> edges = new List<Edge>();
        private int verticesCount = 0;
        private int cornerRadius = 15;
        private Color currentTheme = Color.FromArgb(52, 152, 219);
        private bool isEnglish = true;
        private string saveDirectory = Path.Combine(Application.StartupPath, "SavedGraphs");

        private readonly Dictionary<string, Color> themes = new Dictionary<string, Color>
        {
            {"آبی", Color.FromArgb(52, 152, 219)},
            {"سبز", Color.FromArgb(46, 204, 113)},
            {"قرمز", Color.FromArgb(231, 76, 60)},
            {"بنفش", Color.FromArgb(155, 89, 182)}
        };

        public MainForm()
        {
            InitializeComponents();
            ApplyTheme();
            UpdateLanguage();
            RoundControls();
            InitializeSaveDirectory();
            LoadSavedFilesList();
            this.Icon = Properties.Resources.icon;
        }

        private void InitializeSaveDirectory()
        {
            if (!Directory.Exists(saveDirectory))
            {
                Directory.CreateDirectory(saveDirectory);
            }
        }

        private void RoundControls()
        {
            RoundControl(btnGenerateGraph);
            RoundControl(btnKruskal);
            RoundControl(btnPrim);
            RoundControl(btnInfo);
            RoundControl(btnChangeLanguage);
            RoundControl(btnSaveGraph);
            RoundControl(btnLoadGraph);
            RoundControl(panelGraphInput);
            RoundControl(panelResults);
            RoundControl(panelSavedFiles);
            RoundControl(lstGraph);
            RoundControl(lstResults);
            RoundControl(lstSavedFiles);
            RoundControl(numVertices);
        }

        private void RoundControl(Control control)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
            path.AddArc(control.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
            path.AddArc(control.Width - cornerRadius, control.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            path.AddArc(0, control.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            path.CloseAllFigures();

            if (control is Panel panel)
            {
                panel.Region = new Region(path);
            }
            else if (control is Button button)
            {
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.Region = new Region(path);
            }
            else if (control is ListBox listBox)
            {
                listBox.BorderStyle = BorderStyle.None;
                listBox.Region = new Region(path);
            }
            else if (control is NumericUpDown numeric)
            {
                numeric.BorderStyle = BorderStyle.None;
            }
        }

        private void InitializeComponents()
        {
            // تنظیمات اصلی فرم
            this.Text = "Kruskal & Prim Algorithms";
            this.Size = new Size(1100, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);

            // پنل اصلی
            panelMain = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(20)
            };
            this.Controls.Add(panelMain);

            // پنل ورود گراف
            panelGraphInput = new Panel
            {
                Size = new Size(400, 250),
                Location = new Point(20, 20),
                BackColor = Color.FromArgb(240, 240, 240),
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };
            panelMain.Controls.Add(panelGraphInput);

            // لیبل تعداد رأس ها
            lblVerticesCount = new Label
            {
                Text = "Vertices Count:",
                Location = new Point(20, 20),
                AutoSize = true,
                ForeColor = currentTheme,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            panelGraphInput.Controls.Add(lblVerticesCount);

            // NumericUpDown برای تعداد رأس ها
            numVertices = new NumericUpDown
            {
                Location = new Point(150, 18),
                Size = new Size(80, 25),
                Minimum = 2,
                Maximum = 20,
                Value = 5,
                Font = new Font("Segoe UI", 10)
            };
            panelGraphInput.Controls.Add(numVertices);

            // دکمه تولید گراف
            btnGenerateGraph = new Button
            {
                Text = "Generate Graph",
                Location = new Point(250, 15),
                Size = new Size(120, 30),
                BackColor = currentTheme,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            btnGenerateGraph.Click += btnGenerateGraph_Click;
            panelGraphInput.Controls.Add(btnGenerateGraph);

            // لیبل نمایش گراف
            lblGraphRepresentation = new Label
            {
                Text = "Graph Representation:",
                Location = new Point(20, 60),
                AutoSize = true,
                ForeColor = currentTheme,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            panelGraphInput.Controls.Add(lblGraphRepresentation);

            // لیست نمایش گراف
            lstGraph = new ListBox
            {
                Location = new Point(20, 85),
                Size = new Size(310, 170),
                Font = new Font("Consolas", 9),
                BorderStyle = BorderStyle.None
            };
            panelGraphInput.Controls.Add(lstGraph);

            // پنل نتایج
            panelResults = new Panel
            {
                Size = new Size(400, 300),
                Location = new Point(20, 280),
                BackColor = Color.FromArgb(240, 240, 240),
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };
            panelMain.Controls.Add(panelResults);

            // لیبل نتایج
            lblResults = new Label
            {
                Text = "Results:",
                Location = new Point(20, 20),
                AutoSize = true,
                ForeColor = currentTheme,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            panelResults.Controls.Add(lblResults);

            // لیست نتایج
            lstResults = new ListBox
            {
                Location = new Point(20, 45),
                Size = new Size(310, 200),
                Font = new Font("Consolas", 9),
                BorderStyle = BorderStyle.None
            };
            panelResults.Controls.Add(lstResults);

            // پنل فایل های ذخیره شده
            panelSavedFiles = new Panel
            {
                Size = new Size(350, 550),
                Location = new Point(700, 20),
                BackColor = Color.FromArgb(240, 240, 240),
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };
            panelMain.Controls.Add(panelSavedFiles);

            // لیبل فایل های ذخیره شده
            lblSavedFiles = new Label
            {
                Text = "Saved Graphs:",
                Location = new Point(120, 20),
                AutoSize = true,
                ForeColor = currentTheme,
                Font = new Font("Segoe UI", 13, FontStyle.Bold)
            };
            panelSavedFiles.Controls.Add(lblSavedFiles);

            // لیست فایل های ذخیره شده
            lstSavedFiles = new ListBox
            {
                Location = new Point(20, 45),
                Size = new Size(310, 400),
                Font = new Font("Consolas", 9),
                BorderStyle = BorderStyle.None
            };
            lstSavedFiles.DoubleClick += lstSavedFiles_DoubleClick;
            panelSavedFiles.Controls.Add(lstSavedFiles);

            // دکمه ذخیره گراف
            btnSaveGraph = new Button
            {
                Text = "Save Graph",
                Location = new Point(70, 460),
                Size = new Size(210, 30),
                BackColor = currentTheme,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            btnSaveGraph.Click += btnSaveGraph_Click;
            panelSavedFiles.Controls.Add(btnSaveGraph);

            // دکمه بارگذاری گراف
            btnLoadGraph = new Button
            {
                Text = "Load Graph",
                Location = new Point(70, 500),
                Size = new Size(210, 30),
                BackColor = currentTheme,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            btnLoadGraph.Click += btnLoadGraph_Click;
            panelSavedFiles.Controls.Add(btnLoadGraph);

            // دکمه اجرای کراسکال
            btnKruskal = new Button
            {
                Text = "Run Kruskal",
                Location = new Point(480, 30),
                Size = new Size(150, 40),
                BackColor = currentTheme,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnKruskal.Click += btnKruskal_Click;
            panelMain.Controls.Add(btnKruskal);

            // دکمه اجرای پریم
            btnPrim = new Button
            {
                Text = "Run Prim",
                Location = new Point(480, 90),
                Size = new Size(150, 40),
                BackColor = currentTheme,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnPrim.Click += btnPrim_Click;
            panelMain.Controls.Add(btnPrim);

            // دکمه اطلاعات پروژه
            btnInfo = new Button
            {
                Text = "Project Info",
                Location = new Point(480, 150),
                Size = new Size(150, 40),
                BackColor = currentTheme,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnInfo.Click += btnInfo_Click;
            panelMain.Controls.Add(btnInfo);

            // دکمه تغییر زبان
            btnChangeLanguage = new Button
            {
                Text = "فارسی",
                Location = new Point(480, 210),
                Size = new Size(150, 40),
                BackColor = currentTheme,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnChangeLanguage.Click += btnChangeLanguage_Click;
            panelMain.Controls.Add(btnChangeLanguage);

            // ComboBox برای انتخاب تم
            cmbThemes = new ComboBox
            {
                Location = new Point(480, 270),
                Size = new Size(150, 30),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 9)
            };
            cmbThemes.Items.AddRange(themes.Keys.ToArray());
            cmbThemes.SelectedIndex = 0;
            cmbThemes.SelectedIndexChanged += cmbThemes_SelectedIndexChanged;
            panelMain.Controls.Add(cmbThemes);
        }

        private void LoadSavedFilesList()
        {
            lstSavedFiles.Items.Clear();
            var files = Directory.GetFiles(saveDirectory, "*.json")
                                .Select(Path.GetFileName)
                                .OrderByDescending(f => f);

            foreach (var file in files)
            {
                lstSavedFiles.Items.Add(file);
            }
        }

        // رویدادها
        private void btnGenerateGraph_Click(object sender, EventArgs e)
        {
            GenerateRandomGraph();
        }

        private void GenerateRandomGraph()
        {
            lstGraph.Items.Clear();
            edges.Clear();

            verticesCount = (int)numVertices.Value;
            graph = new int[verticesCount, verticesCount];

            Random rand = new Random();

            // تولید ماتریس مجاورت
            for (int i = 0; i < verticesCount; i++)
            {
                for (int j = i + 1; j < verticesCount; j++)
                {
                    // 70% احتمال ایجاد یال بین دو رأس
                    if (rand.NextDouble() < 0.7)
                    {
                        int weight = rand.Next(1, 100);
                        graph[i, j] = weight;
                        graph[j, i] = weight;
                        edges.Add(new Edge { Source = i, Destination = j, Weight = weight });
                    }
                }
            }

            // نمایش گراف
            DisplayGraph();

            // فعال کردن دکمه های الگوریتم ها
            btnKruskal.Enabled = true;
            btnPrim.Enabled = true;
        }

        private void btnKruskal_Click(object sender, EventArgs e)
        {
            RunKruskal();
        }
        private void RunKruskal()
        {
            if (edges.Count == 0)
            {
                MessageBox.Show(isEnglish ?
                    "Please generate a graph first!" :
                    "لطفاً ابتدا یک گراف تولید کنید!",
                    isEnglish ? "Error" : "خطا",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            lstResults.Items.Clear();
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            // اجرای الگوریتم کراسکال
            List<Edge> mst = KruskalAlgorithm();

            stopwatch.Stop();

            // نمایش نتایج
            DisplayResults(mst, stopwatch.Elapsed.TotalMilliseconds, "Kruskal");
        }

        private List<Edge> KruskalAlgorithm()
        {
            List<Edge> result = new List<Edge>();
            edges = edges.OrderBy(e => e.Weight).ToList();

            int[] parent = new int[verticesCount];
            for (int i = 0; i < verticesCount; i++)
                parent[i] = i;

            int edgeCount = 0;
            int index = 0;

            while (edgeCount < verticesCount - 1 && index < edges.Count)
            {
                Edge nextEdge = edges[index++];
                int x = Find(parent, nextEdge.Source);
                int y = Find(parent, nextEdge.Destination);

                if (x != y)
                {
                    result.Add(nextEdge);
                    Union(parent, x, y);
                    edgeCount++;
                }
            }

            return result;
        }

        private int Find(int[] parent, int i)
        {
            if (parent[i] != i)
                parent[i] = Find(parent, parent[i]);
            return parent[i];
        }

        private void Union(int[] parent, int x, int y)
        {
            int xset = Find(parent, x);
            int yset = Find(parent, y);
            parent[xset] = yset;
        }

        private void btnPrim_Click(object sender, EventArgs e)
        {
            RunPrim();
        }

        private void RunPrim()
        {
            if (graph == null || edges.Count == 0)
            {
                MessageBox.Show(isEnglish ?
                    "Please generate a graph first!" :
                    "لطفاً ابتدا یک گراف تولید کنید!",
                    isEnglish ? "Error" : "خطا",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            lstResults.Items.Clear();
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            // اجرای الگوریتم پریم
            List<Edge> mst = PrimAlgorithm();

            stopwatch.Stop();

            // نمایش نتایج
            DisplayResults(mst, stopwatch.Elapsed.TotalMilliseconds, "Prim");
        }

        private void DisplayResults(List<Edge> mst, double time, string algorithm)
        {
            int totalWeight = mst.Sum(e => e.Weight);

            if (isEnglish)
            {
                lstResults.Items.Add($"{algorithm}'s Algorithm Minimum Spanning Tree:");
                lstResults.Items.Add($"Total Weight: {totalWeight}");
                lstResults.Items.Add($"Execution Time: {time:F2} ms");
                lstResults.Items.Add("Edges in MST:");

                foreach (var edge in mst.OrderBy(e => e.Weight))
                {
                    lstResults.Items.Add($"{edge.Source} - {edge.Destination} | Weight: {edge.Weight}");
                }
            }
            else
            {
                lstResults.Items.Add($"درخت پوشای کمینه با الگوریتم {algorithm}:");
                lstResults.Items.Add($"وزن کلی: {totalWeight}");
                lstResults.Items.Add($"زمان اجرا: {time:F2} میلی ثانیه");
                lstResults.Items.Add("یال های درخت پوشا:");

                foreach (var edge in mst.OrderBy(e => e.Weight))
                {
                    lstResults.Items.Add($"{edge.Source} - {edge.Destination} | وزن: {edge.Weight}");
                }
            }

            // اضافه کردن نمودار MST به نتایج
            lstResults.Items.Add("\nMST Visualization:");
            DrawMST(mst);
        }

        private void DrawMST(List<Edge> mst)
        {
            // این متد می‌تواند برای رسم گراف توسعه داده شود
            string visualization = "";

            for (int i = 0; i < verticesCount; i++)
            {
                visualization += $"{i} ";
                foreach (var edge in mst.Where(e => e.Source == i))
                {
                    visualization += $"--{edge.Weight}--> {edge.Destination} ";
                }
                lstResults.Items.Add(visualization);
                visualization = "";
            }
        }

        private List<Edge> PrimAlgorithm()
        {
            List<Edge> result = new List<Edge>();
            bool[] inMST = new bool[verticesCount];
            inMST[0] = true;

            int edgeCount = 0;

            while (edgeCount < verticesCount - 1)
            {
                int min = int.MaxValue;
                Edge minEdge = new Edge();

                for (int i = 0; i < verticesCount; i++)
                {
                    if (inMST[i])
                    {
                        for (int j = 0; j < verticesCount; j++)
                        {
                            if (!inMST[j] && graph[i, j] != 0 && graph[i, j] < min)
                            {
                                min = graph[i, j];
                                minEdge.Source = i;
                                minEdge.Destination = j;
                                minEdge.Weight = min;
                            }
                        }
                    }
                }

                inMST[minEdge.Destination] = true;
                result.Add(minEdge);
                edgeCount++;
            }

            return result;
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            ShowInfoForm();
        }
        private void ShowInfoForm()
        {
            InfoForm infoForm = new InfoForm(currentTheme, cornerRadius, isEnglish);

            // تنظیم موقعیت فرم اطلاعات نسبت به فرم اصلی
            infoForm.StartPosition = FormStartPosition.Manual;
            infoForm.Left = this.Left + ((this.Width - infoForm.Width) / 2);
            infoForm.Top = this.Top + ((this.Height - infoForm.Height) / 2);

            infoForm.ShowDialog();
        }

        private void btnChangeLanguage_Click(object sender, EventArgs e)
        {
            isEnglish = !isEnglish;
            UpdateLanguage();
            if (graph != null) DisplayGraph();
        }

        private void btnSaveGraph_Click(object sender, EventArgs e)
        {
            if (graph == null || edges.Count == 0)
            {
                MessageBox.Show(isEnglish ?
                    "Please generate a graph first!" :
                    "لطفاً ابتدا یک گراف تولید کنید!",
                    isEnglish ? "Error" : "خطا",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string fileName = $"graph_{DateTime.Now:yyyyMMdd_HHmmss}[{verticesCount}].json";
            string filePath = Path.Combine(saveDirectory, fileName);

            var graphData = new
            {
                VerticesCount = verticesCount,
                AdjacencyMatrix = graph,
                Edges = edges,
                GeneratedTime = DateTime.Now
            };

            string json = JsonConvert.SerializeObject(graphData, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, json);

            /*MessageBox.Show(isEnglish ?
                $"Graph saved successfully as {fileName}" :
                $"گراف با موفقیت ذخیره شد: {fileName}",
                isEnglish ? "Success" : "موفقیت",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);*/

            LoadSavedFilesList();
        }

        private void btnLoadGraph_Click(object sender, EventArgs e)
        {
            if (lstSavedFiles.SelectedItem == null)
            {
                MessageBox.Show(isEnglish ?
                    "Please select a graph to load!" :
                    "لطفاً یک گراف برای بارگذاری انتخاب کنید!",
                    isEnglish ? "Error" : "خطا",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string fileName = lstSavedFiles.SelectedItem.ToString();
            string filePath = Path.Combine(saveDirectory, fileName);

            try
            {
                string json = File.ReadAllText(filePath);
                dynamic graphData = JsonConvert.DeserializeObject(json);

                verticesCount = graphData.VerticesCount;
                numVertices.Value = verticesCount;

                // تبدیل آرایه JSON به آرایه دوبعدی
                var matrix = graphData.AdjacencyMatrix.ToObject<int[,]>();
                graph = new int[verticesCount, verticesCount];
                Array.Copy(matrix, graph, matrix.Length);

                edges = graphData.Edges.ToObject<List<Edge>>();

                DisplayGraph();

                btnKruskal.Enabled = true;
                btnPrim.Enabled = true;

                /*MessageBox.Show(isEnglish ?
                    "Graph loaded successfully!" :
                    "گراف با موفقیت بارگذاری شد!",
                    isEnglish ? "Success" : "موفقیت",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(isEnglish ?
                    $"Error loading graph: {ex.Message}" :
                    $"خطا در بارگذاری گراف: {ex.Message}",
                    isEnglish ? "Error" : "خطا",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void lstSavedFiles_DoubleClick(object sender, EventArgs e)
        {
            btnLoadGraph_Click(sender, e);
        }

        private void UpdateLanguage()
        {
            if (isEnglish)
            {
                this.RightToLeft = RightToLeft.No;
                this.RightToLeftLayout = false;

                this.Text = "Kruskal & Prim Algorithms";
                lblVerticesCount.Text = "Vertices Count:";
                lblGraphRepresentation.Text = "Graph Representation:";
                lblResults.Text = "Results:";
                lblSavedFiles.Text = "Saved Graphs:";
                btnGenerateGraph.Text = "Generate Graph";
                btnKruskal.Text = "Run Kruskal";
                btnPrim.Text = "Run Prim";
                btnInfo.Text = "Project Info";
                btnChangeLanguage.Text = "فارسی";
                btnSaveGraph.Text = "Save Graph";
                btnLoadGraph.Text = "Load Graph";

                cmbThemes.Items.Clear();
                cmbThemes.Items.AddRange(themes.Keys.ToArray());
                cmbThemes.SelectedIndex = 0;
            }
            else
            {
                this.RightToLeft = RightToLeft.Yes;
                this.RightToLeftLayout = true;

                this.Text = "الگوریتم های کراسکال و پریم";
                lblVerticesCount.Text = "تعداد رأس ها:";
                lblGraphRepresentation.Text = "نمایش گراف:";
                lblResults.Text = "نتایج:";
                lblSavedFiles.Text = "گراف های ذخیره شده:";
                btnGenerateGraph.Text = "تولید گراف";
                btnKruskal.Text = "اجرای کراسکال";
                btnPrim.Text = "اجرای پریم";
                btnInfo.Text = "اطلاعات پروژه";
                btnChangeLanguage.Text = "English";
                btnSaveGraph.Text = "ذخیره گراف";
                btnLoadGraph.Text = "بارگذاری گراف";

                cmbThemes.Items.Clear();
                cmbThemes.Items.AddRange(themes.Keys.ToArray());
                cmbThemes.SelectedIndex = 0;
            }

            if (graph != null)
            {
                DisplayGraph();
            }
        }

        private void DisplayGraph()
        {
            lstGraph.Items.Clear();

            if (isEnglish)
            {
                lstGraph.Items.Add($"Graph with {verticesCount} vertices and {edges.Count} edges:");
                lstGraph.Items.Add("Adjacency Matrix:");
            }
            else
            {
                lstGraph.Items.Add($"گراف با {verticesCount} رأس و {edges.Count} یال:");
                lstGraph.Items.Add("ماتریس مجاورت:");
            }

            // نمایش ماتریس مجاورت
            for (int i = 0; i < verticesCount; i++)
            {
                string row = "";
                for (int j = 0; j < verticesCount; j++)
                {
                    row += $"{graph[i, j],3} ";
                }
                lstGraph.Items.Add(row);
            }

            // نمایش لیست یال ها
            if (isEnglish)
            {
                lstGraph.Items.Add("\nEdge List:");
            }
            else
            {
                lstGraph.Items.Add("\nلیست یال ها:");
            }

            foreach (var edge in edges.OrderBy(e => e.Weight))
            {
                if (isEnglish)
                {
                    lstGraph.Items.Add($"Edge: {edge.Source} - {edge.Destination} | Weight: {edge.Weight}");
                }
                else
                {
                    lstGraph.Items.Add($"یال: {edge.Source} - {edge.Destination} | وزن: {edge.Weight}");
                }
            }
        }

        private void cmbThemes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbThemes.SelectedItem != null)
            {
                currentTheme = themes[cmbThemes.SelectedItem.ToString()];
                ApplyTheme();
            }
        }
        private void ApplyTheme()
        {
            // تغییر رنگ دکمه ها و کنترل ها
            btnGenerateGraph.BackColor = currentTheme;
            btnKruskal.BackColor = currentTheme;
            btnPrim.BackColor = currentTheme;
            btnInfo.BackColor = currentTheme;
            btnChangeLanguage.BackColor = currentTheme;

            // تغییر رنگ پنل ها
            panelGraphInput.BackColor = Color.FromArgb(240, 240, 240);
            panelResults.BackColor = Color.FromArgb(240, 240, 240);

            // تغییر رنگ لیست ها
            lstGraph.ForeColor = Color.FromArgb(50, 50, 50);
            lstResults.ForeColor = Color.FromArgb(50, 50, 50);

            // تغییر رنگ لیبل ها
            lblVerticesCount.ForeColor = currentTheme;
            lblGraphRepresentation.ForeColor = currentTheme;
            lblResults.ForeColor = currentTheme;

            // تغییر رنگ ComboBox
            cmbThemes.ForeColor = Color.FromArgb(50, 50, 50);
            cmbThemes.BackColor = Color.White;

            // به روز رسانی ظاهر تمام کنترل ها
            foreach (Control control in panelMain.Controls)
            {
                if (control is Button button)
                {
                    button.ForeColor = Color.White;
                    button.FlatAppearance.MouseOverBackColor = Color.FromArgb(
                        Math.Max(currentTheme.R - 30, 0),
                        Math.Max(currentTheme.G - 30, 0),
                        Math.Max(currentTheme.B - 30, 0));
                    button.FlatAppearance.MouseDownBackColor = Color.FromArgb(
                        Math.Max(currentTheme.R - 50, 0),
                        Math.Max(currentTheme.G - 50, 0),
                        Math.Max(currentTheme.B - 50, 0));
                }
            }

            this.Refresh();
        }
    }

    public class Edge
    {
        public int Source { get; set; }
        public int Destination { get; set; }
        public int Weight { get; set; }
    }
}
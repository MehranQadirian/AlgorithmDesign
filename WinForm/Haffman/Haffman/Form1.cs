using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using Huffman;

namespace Haffman
{
    public partial class Form1 : Form
    {
        private float zoomFactor = 1.0f;
        private PointF translatePos = new PointF(0, 0);
        private Point lastMousePos;
        private HuffmanCoding lastHuffmanTree;
        private Theme currentTheme = Theme.Light;

        public enum Theme
        {
            Light,
            Dark,
            Blue,
            Green
        }

        public Form1()
        {
            InitializeComponent();
            InitializeUI();
            ApplyTheme(Theme.Light);
            this.Icon = Properties.Resources.icon;
        }

        private void InitializeUI()
        {
            // تنظیمات فرم اصلی
            this.Text = "Huffman Coding Visualizer";
            this.Size = new Size(1200, 800);
            this.Font = new Font("Segoe UI", 10);

            // پنل ورودی
            var inputPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 180,
                Padding = new Padding(15)
            };

            var inputLabel = new Label
            {
                Text = "Enter Text:",
                Dock = DockStyle.Top,
                Margin = new Padding(0, 0, 0, 10),
                AutoSize = true
            };

            var inputTextBox = new TextBox
            {
                Dock = DockStyle.Top,
                Height = 80,
                Multiline = true,
                BorderStyle = BorderStyle.FixedSingle,
                ScrollBars = ScrollBars.Vertical
            };

            var buttonPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50
            };

            var processButton = new Button
            {
                Text = "Generate Huffman Codes",
                Dock = DockStyle.Left,
                Width = 200,
                Height = 40,
                FlatStyle = FlatStyle.Flat
            };
            processButton.FlatAppearance.BorderSize = 0;

            var infoButton = new Button
            {
                Text = "Information",
                Dock = DockStyle.Left,
                Width = 150,
                Height = 40,
                FlatStyle = FlatStyle.Flat
            };
            infoButton.FlatAppearance.BorderSize = 0;

            var themeCombo = new ComboBox
            {
                Dock = DockStyle.Right,
                Width = 150,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            themeCombo.Items.AddRange(new object[] { "Light Theme", "Dark Theme", "Blue Theme", "Green Theme" });
            themeCombo.SelectedIndex = 0;
            themeCombo.SelectedIndexChanged += (s, e) =>
            {
                ApplyTheme((Theme)themeCombo.SelectedIndex);
            };

            buttonPanel.Controls.Add(themeCombo);
            buttonPanel.Controls.Add(processButton);
            buttonPanel.Controls.Add(infoButton);

            inputPanel.Controls.Add(buttonPanel);
            inputPanel.Controls.Add(inputTextBox);
            inputPanel.Controls.Add(inputLabel);

            // پنل نتایج
            var resultsPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10)
            };

            var tabControl = new TabControl
            {
                Dock = DockStyle.Fill,
                Appearance = TabAppearance.FlatButtons,
                ItemSize = new Size(0, 1),
                SizeMode = TabSizeMode.Fixed
            };

            var frequenciesTab = new TabPage();
            var codesTab = new TabPage();
            var treeTab = new TabPage();

            tabControl.TabPages.Add(frequenciesTab);
            tabControl.TabPages.Add(codesTab);
            tabControl.TabPages.Add(treeTab);

            // جدول فرکانس‌ها
            var frequenciesGridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.None,
                EnableHeadersVisualStyles = false,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
                ColumnHeadersHeight = 35,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
            };
            frequenciesTab.Controls.Add(frequenciesGridView);

            // جدول کدها
            var codesGridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.None,
                EnableHeadersVisualStyles = false,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
                ColumnHeadersHeight = 35,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
            };
            codesTab.Controls.Add(codesGridView);

            // پنل درخت
            var treePanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.White
            };
            InitializeTreePanel(treePanel);
            treeTab.Controls.Add(treePanel);

            // نوار ابزار
            var toolStrip = new ToolStrip
            {
                Dock = DockStyle.Top,
                GripStyle = ToolStripGripStyle.Hidden
            };

            var frequenciesButton = new ToolStripButton("Frequencies", null, (s, e) => tabControl.SelectedTab = frequenciesTab)
            {
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            var codesButton = new ToolStripButton("Codes", null, (s, e) => tabControl.SelectedTab = codesTab)
            {
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            var treeButton = new ToolStripButton("Tree Visualization", null, (s, e) => tabControl.SelectedTab = treeTab)
            {
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            toolStrip.Items.Add(frequenciesButton);
            toolStrip.Items.Add(codesButton);
            toolStrip.Items.Add(treeButton);

            resultsPanel.Controls.Add(tabControl);
            resultsPanel.Controls.Add(toolStrip);

            this.Controls.Add(resultsPanel);
            this.Controls.Add(inputPanel);

            // رویداد پردازش
            processButton.Click += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(inputTextBox.Text))
                {
                    MessageBox.Show("Please enter some text to process.", "Input Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    lastHuffmanTree = new HuffmanCoding(inputTextBox.Text);

                    // نمایش فرکانس‌ها
                    frequenciesGridView.Columns.Clear();
                    frequenciesGridView.Columns.Add("Character", "Character");
                    frequenciesGridView.Columns.Add("Frequency", "Frequency");
                    frequenciesGridView.Columns.Add("Percentage", "Percentage");

                    int totalChars = inputTextBox.Text.Length;
                    foreach (var kvp in lastHuffmanTree.Frequencies.OrderByDescending(x => x.Value))
                    {
                        frequenciesGridView.Rows.Add(
                            kvp.Key == ' ' ? "[Space]" :
                            char.IsControl(kvp.Key) ? $"0x{((int)kvp.Key):X2}" :
                            kvp.Key.ToString(),
                            kvp.Value,
                            $"{((float)kvp.Value / totalChars * 100):F2}%");
                    }

                    // نمایش کدها
                    codesGridView.Columns.Clear();
                    codesGridView.Columns.Add("Character", "Character");
                    codesGridView.Columns.Add("Code", "Code");
                    codesGridView.Columns.Add("Length", "Length");

                    foreach (var kvp in lastHuffmanTree.Codes.OrderByDescending(x => x.Value.Length))
                    {
                        codesGridView.Rows.Add(
                            kvp.Key == ' ' ? "[Space]" :
                            char.IsControl(kvp.Key) ? $"0x{((int)kvp.Key):X2}" :
                            kvp.Key.ToString(),
                            kvp.Value,
                            kvp.Value.Length);
                    }

                    // نمایش درخت
                    treePanel.Controls.Clear();
                    zoomFactor = 1.0f;
                    translatePos = new PointF(0, 0);
                    DrawHuffmanTree(lastHuffmanTree.Root, treePanel,
                                   treePanel.Width / 2, 50,
                                   treePanel.Width / 3);

                    tabControl.SelectedTab = frequenciesTab;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            infoButton.Click += (sender, e) =>
            {
                try
                {
                    Information info = new Information();
                    info.Show(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
        }

        private void InitializeTreePanel(Panel treePanel)
        {
            treePanel.MouseWheel += (s, e) =>
            {
                // Zoom با اسکرول ماوس
                float oldZoom = zoomFactor;
                zoomFactor += e.Delta > 0 ? 0.1f : -0.1f;
                zoomFactor = Math.Max(0.3f, Math.Min(zoomFactor, 3.0f));

                // تنظیم موقعیت برای zoom روی نقطه مورد نظر
                var relPos = treePanel.PointToClient(Cursor.Position);
                translatePos.X = relPos.X - (relPos.X - translatePos.X) * (zoomFactor / oldZoom);
                translatePos.Y = relPos.Y - (relPos.Y - translatePos.Y) * (zoomFactor / oldZoom);

                RedrawTree(treePanel);
            };

            treePanel.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                    lastMousePos = e.Location;
            };

            treePanel.MouseMove += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    translatePos.X += e.X - lastMousePos.X;
                    translatePos.Y += e.Y - lastMousePos.Y;
                    lastMousePos = e.Location;
                    RedrawTree(treePanel);
                }
            };

            // دوبار کلیک برای بازنشانی zoom و موقعیت
            treePanel.DoubleClick += (s, e) =>
            {
                zoomFactor = 1.0f;
                translatePos = new PointF(0, 0);
                RedrawTree(treePanel);
            };
        }

        private string GetNodeText(HuffmanNode node)
        {
            if (!node.IsLeaf)
                return node.Frequency.ToString();

            if (node.Character == ' ')
                return "[Space]";

            if (char.IsControl(node.Character))
                return $"0x{(int)node.Character:X2}";

            return node.Character.ToString();
        }

        private float GetFontSize(int depth)
        {
            return Math.Max(6, 8 - depth / 2);
        }

        private void DrawHuffmanTree(HuffmanNode node, Panel panel, float x, float y, float xOffset, int depth = 0)
        {
            if (node == null) return;

            // محاسبه اندازه گره بر اساس عمق درخت
            int nodeSize = Math.Max(20, 40 - depth * 2);
            int verticalSpacing = Math.Max(60, 100 - depth * 5);

            // تنظیم فاصله افقی بر اساس عمق
            xOffset = xOffset * 0.6f;

            // انتخاب رنگ بر اساس تم
            Color nodeColor, textColor;
            if (node.IsLeaf)
            {
                nodeColor = currentTheme == Theme.Dark ? Color.FromArgb(70, 100, 150) :
                            currentTheme == Theme.Blue ? Color.FromArgb(200, 220, 255) :
                            currentTheme == Theme.Green ? Color.FromArgb(200, 240, 200) :
                            Color.FromArgb(220, 235, 252);
            }
            else
            {
                nodeColor = currentTheme == Theme.Dark ? Color.FromArgb(80, 80, 80) :
                           currentTheme == Theme.Blue ? Color.FromArgb(180, 200, 240) :
                           currentTheme == Theme.Green ? Color.FromArgb(180, 220, 180) :
                           Color.FromArgb(200, 230, 201);
            }
            textColor = currentTheme == Theme.Dark ? Color.White : Color.Black;

            // رسم گره با در نظر گرفتن zoom و انتقال
            var nodeCircle = new Label
            {
                Width = Math.Max(10, (int)(40 * zoomFactor)),
                Height = Math.Max(10, (int)(40 * zoomFactor)),
                Left = (int)(x * zoomFactor + translatePos.X - 20 * zoomFactor),
                Top = (int)(y * zoomFactor + translatePos.Y),
                Text = GetNodeText(node),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = nodeColor,
                ForeColor = textColor,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", GetFontSize(depth), node.IsLeaf ? FontStyle.Bold : FontStyle.Regular),
                Tag = new PointF(x, y)
            };
            panel.Controls.Add(nodeCircle);

            // رسم خطوط اتصال
            if (node.Left != null)
            {
                var leftX = x - xOffset;
                var leftY = y + verticalSpacing;

                var line = new PictureBox
                {
                    BackColor = Color.Transparent,
                    Size = new Size(1, 1),
                    Location = new Point(0, 0),
                    Tag = new Tuple<PointF, PointF>(
                        new PointF(x, y + nodeSize / 2),
                        new PointF(leftX, leftY - nodeSize / 2))
                };
                line.Paint += (s, e) =>
                {
                    var points = (Tuple<PointF, PointF>)line.Tag;
                    var start = new PointF(
                        (points.Item1.X * zoomFactor + translatePos.X),
                        (points.Item1.Y * zoomFactor + translatePos.Y));
                    var end = new PointF(
                        (points.Item2.X * zoomFactor + translatePos.X),
                        (points.Item2.Y * zoomFactor + translatePos.Y));

                    Color lineColor = currentTheme == Theme.Dark ? Color.LightGray :
                                    currentTheme == Theme.Blue ? Color.DarkBlue :
                                    currentTheme == Theme.Green ? Color.DarkGreen :
                                    Color.Gray;

                    using (var pen = new Pen(lineColor, 1.5f * zoomFactor))
                    {
                        e.Graphics.DrawLine(pen, start, end);
                    }

                    // رسم برچسب 0
                    var midPoint = new PointF(
                        (start.X + end.X) / 2,
                        (start.Y + end.Y) / 2);
                    var textSize = e.Graphics.MeasureString("0", line.Font);
                    e.Graphics.DrawString("0", line.Font, new SolidBrush(textColor),
                        midPoint.X - textSize.Width / 2,
                        midPoint.Y - textSize.Height / 2);
                };
                panel.Controls.Add(line);
                line.BringToFront();

                DrawHuffmanTree(node.Left, panel, leftX, leftY, xOffset, depth + 1);
            }

            if (node.Right != null)
            {
                var rightX = x + xOffset;
                var rightY = y + verticalSpacing;

                var line = new PictureBox
                {
                    BackColor = Color.Transparent,
                    Size = new Size(1, 1),
                    Location = new Point(0, 0),
                    Tag = new Tuple<PointF, PointF>(
                        new PointF(x, y + nodeSize / 2),
                        new PointF(rightX, rightY - nodeSize / 2))
                };
                line.Paint += (s, e) =>
                {
                    var points = (Tuple<PointF, PointF>)line.Tag;
                    var start = new PointF(
                        (points.Item1.X * zoomFactor + translatePos.X),
                        (points.Item1.Y * zoomFactor + translatePos.Y));
                    var end = new PointF(
                        (points.Item2.X * zoomFactor + translatePos.X),
                        (points.Item2.Y * zoomFactor + translatePos.Y));

                    Color lineColor = currentTheme == Theme.Dark ? Color.LightGray :
                                    currentTheme == Theme.Blue ? Color.DarkBlue :
                                    currentTheme == Theme.Green ? Color.DarkGreen :
                                    Color.Gray;

                    using (var pen = new Pen(lineColor, 1.5f * zoomFactor))
                    {
                        e.Graphics.DrawLine(pen, start, end);
                    }

                    // رسم برچسب 1
                    var midPoint = new PointF(
                        (start.X + end.X) / 2,
                        (start.Y + end.Y) / 2);
                    var textSize = e.Graphics.MeasureString("1", line.Font);
                    e.Graphics.DrawString("1", line.Font, new SolidBrush(textColor),
                        midPoint.X - textSize.Width / 2,
                        midPoint.Y - textSize.Height / 2);
                };
                panel.Controls.Add(line);
                line.BringToFront();

                DrawHuffmanTree(node.Right, panel, rightX, rightY, xOffset, depth + 1);
            }
        }

        private void RedrawTree(Panel treePanel)
        {
            treePanel.Controls.Clear();
            if (lastHuffmanTree != null)
            {
                DrawHuffmanTree(lastHuffmanTree.Root, treePanel,
                              treePanel.Width / (2 * zoomFactor),
                              50 / zoomFactor,
                              treePanel.Width / (3 * zoomFactor));
            }
        }

        private void ApplyTheme(Theme theme)
        {
            currentTheme = theme;

            Color backColor, foreColor, controlBack, controlFore, headerColor;
            Color gridBack, gridLine, gridHeaderBack, gridHeaderFore, gridAltBack;

            switch (theme)
            {
                case Theme.Dark:
                    backColor = Color.FromArgb(45, 45, 48);
                    foreColor = Color.WhiteSmoke;
                    controlBack = Color.FromArgb(63, 63, 70);
                    controlFore = Color.White;
                    headerColor = Color.FromArgb(0, 122, 204);

                    gridBack = Color.FromArgb(45, 45, 48);
                    gridLine = Color.FromArgb(80, 80, 80);
                    gridHeaderBack = Color.FromArgb(30, 30, 30);
                    gridHeaderFore = Color.White;
                    gridAltBack = Color.FromArgb(60, 60, 60);
                    break;

                case Theme.Blue:
                    backColor = Color.FromArgb(240, 245, 255);
                    foreColor = Color.FromArgb(30, 30, 30);
                    controlBack = Color.FromArgb(220, 230, 250);
                    controlFore = Color.FromArgb(30, 30, 30);
                    headerColor = Color.FromArgb(0, 78, 138);

                    gridBack = Color.White;
                    gridLine = Color.FromArgb(200, 210, 230);
                    gridHeaderBack = Color.FromArgb(0, 78, 138);
                    gridHeaderFore = Color.White;
                    gridAltBack = Color.FromArgb(240, 245, 255);
                    break;

                case Theme.Green:
                    backColor = Color.FromArgb(240, 250, 240);
                    foreColor = Color.FromArgb(30, 30, 30);
                    controlBack = Color.FromArgb(220, 240, 220);
                    controlFore = Color.FromArgb(30, 30, 30);
                    headerColor = Color.FromArgb(60, 120, 60);

                    gridBack = Color.White;
                    gridLine = Color.FromArgb(200, 220, 200);
                    gridHeaderBack = Color.FromArgb(60, 120, 60);
                    gridHeaderFore = Color.White;
                    gridAltBack = Color.FromArgb(240, 250, 240);
                    break;

                default: // Light
                    backColor = Color.FromArgb(240, 240, 240);
                    foreColor = Color.FromArgb(30, 30, 30);
                    controlBack = Color.White;
                    controlFore = Color.FromArgb(30, 30, 30);
                    headerColor = Color.FromArgb(0, 122, 204);

                    gridBack = Color.White;
                    gridLine = Color.FromArgb(220, 220, 220);
                    gridHeaderBack = Color.FromArgb(0, 122, 204);
                    gridHeaderFore = Color.White;
                    gridAltBack = Color.FromArgb(240, 240, 240);
                    break;
            }

            // اعمال تم به فرم و کنترل‌ها
            this.BackColor = backColor;
            this.ForeColor = foreColor;

            foreach (Control control in this.Controls)
            {
                ApplyThemeToControl(control, backColor, foreColor, controlBack, controlFore, headerColor);
            }



            // اعمال تم به DataGridViewها
            TabControl tabControl = null;
            
            foreach (Control control in this.Controls)
            {
                if (control is TabControl tc)
                {
                    tabControl = tc;
                    break;
                }
                foreach (Control child in control.Controls)
                {
                    if (child is TabControl childTabControl)
                    {
                        tabControl = childTabControl;
                        break;
                    }
                }
                if (tabControl != null) break;
            }

            if (tabControl == null)
                throw new InvalidOperationException("No TabControl found in the form's controls.");

            foreach (TabPage tab in tabControl.TabPages)
            {
                if (tab.Controls.Count == 0)
                    continue;

                if (tab.Controls[0] is DataGridView grid)
                {
                    grid.BackgroundColor = gridBack;
                    grid.GridColor = gridLine;
                    grid.ColumnHeadersDefaultCellStyle.BackColor = gridHeaderBack;
                    grid.ColumnHeadersDefaultCellStyle.ForeColor = gridHeaderFore;
                    grid.DefaultCellStyle.BackColor = gridBack;
                    grid.DefaultCellStyle.ForeColor = foreColor;
                    grid.AlternatingRowsDefaultCellStyle.BackColor = gridAltBack;
                    grid.AlternatingRowsDefaultCellStyle.ForeColor = foreColor;
                }
                else if (tab.Controls[0] is Panel panel)
                {
                    panel.BackColor = gridBack;
                }
            }


        }

        private void ApplyThemeToControl(Control control, Color backColor, Color foreColor,
                                       Color controlBack, Color controlFore, Color headerColor)
        {
            if (control is Panel panel)
            {
                if (panel.Controls.Count > 0 && panel.Controls[0] is DataGridView)
                {
                    panel.BackColor = currentTheme == Theme.Dark ?
                        Color.FromArgb(45, 45, 48) : Color.White;
                }
                else
                {
                    panel.BackColor = controlBack;
                }
                panel.ForeColor = foreColor;
            }
            else if (control is TextBox textBox)
            {
                textBox.BackColor = controlBack;
                textBox.ForeColor = controlFore;
                textBox.BorderStyle = BorderStyle.FixedSingle;
            }
            else if (control is Button button)
            {
                button.BackColor = headerColor;
                button.ForeColor = Color.White;
                button.FlatAppearance.BorderColor = headerColor;
            }
            else if (control is Label label)
            {
                label.ForeColor = foreColor;
            }
            else if (control is ToolStrip toolStrip)
            {
                toolStrip.BackColor = backColor;
                foreach (ToolStripItem item in toolStrip.Items)
                {
                    item.ForeColor = foreColor;
                }
            }
            else if (control is ComboBox comboBox)
            {
                comboBox.BackColor = controlBack;
                comboBox.ForeColor = controlFore;
            }

            foreach (Control childControl in control.Controls)
            {
                ApplyThemeToControl(childControl, backColor, foreColor, controlBack, controlFore, headerColor);
            }
        }
    }

    public class HuffmanNode : IComparable<HuffmanNode>
    {
        public char Character { get; set; }
        public int Frequency { get; set; }
        public HuffmanNode Left { get; set; }
        public HuffmanNode Right { get; set; }
        public bool IsLeaf => Left == null && Right == null;

        public HuffmanNode(char character, int frequency)
        {
            Character = character;
            Frequency = frequency;
        }

        public HuffmanNode(int frequency, HuffmanNode left, HuffmanNode right)
        {
            Frequency = frequency;
            Left = left;
            Right = right;
        }

        public int CompareTo(HuffmanNode other)
        {
            return Frequency.CompareTo(other.Frequency);
        }
    }

    public class HuffmanCoding
    {
        public Dictionary<char, int> Frequencies { get; }
        public Dictionary<char, string> Codes { get; }
        public HuffmanNode Root { get; }

        public HuffmanCoding(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentException("Input text cannot be empty");

            Frequencies = CalculateFrequencies(text);
            Root = BuildHuffmanTree(Frequencies);
            Codes = new Dictionary<char, string>();
            BuildCodes(Root, "");
        }

        private Dictionary<char, int> CalculateFrequencies(string text)
        {
            var frequencies = new Dictionary<char, int>();
            foreach (char c in text)
            {
                if (frequencies.ContainsKey(c))
                    frequencies[c]++;
                else
                    frequencies[c] = 1;
            }
            return frequencies;
        }

        private HuffmanNode BuildHuffmanTree(Dictionary<char, int> frequencies)
        {
            var priorityQueue = new PriorityQueue<HuffmanNode>();

            foreach (var kvp in frequencies)
            {
                priorityQueue.Enqueue(new HuffmanNode(kvp.Key, kvp.Value));
            }

            while (priorityQueue.Count > 1)
            {
                var left = priorityQueue.Dequeue();
                var right = priorityQueue.Dequeue();
                var parent = new HuffmanNode(left.Frequency + right.Frequency, left, right);
                priorityQueue.Enqueue(parent);
            }

            return priorityQueue.Dequeue();
        }

        private void BuildCodes(HuffmanNode node, string code)
        {
            if (node.IsLeaf)
            {
                Codes[node.Character] = code;
                return;
            }

            BuildCodes(node.Left, code + "0");
            BuildCodes(node.Right, code + "1");
        }
    }

    public class PriorityQueue<T> where T : IComparable<T>
    {
        private readonly List<T> _elements = new List<T>();

        public int Count => _elements.Count;

        public void Enqueue(T item)
        {
            _elements.Add(item);
            int childIndex = _elements.Count - 1;

            while (childIndex > 0)
            {
                int parentIndex = (childIndex - 1) / 2;
                if (_elements[childIndex].CompareTo(_elements[parentIndex]) >= 0)
                    break;

                T tmp = _elements[childIndex];
                _elements[childIndex] = _elements[parentIndex];
                _elements[parentIndex] = tmp;
                childIndex = parentIndex;
            }
        }

        public T Dequeue()
        {
            if (_elements.Count == 0)
                throw new InvalidOperationException("Queue is empty");

            int lastIndex = _elements.Count - 1;
            T frontItem = _elements[0];
            _elements[0] = _elements[lastIndex];
            _elements.RemoveAt(lastIndex);

            lastIndex--;
            int parentIndex = 0;

            while (true)
            {
                int leftChildIndex = parentIndex * 2 + 1;
                if (leftChildIndex > lastIndex)
                    break;

                int rightChildIndex = leftChildIndex + 1;
                if (rightChildIndex <= lastIndex && _elements[rightChildIndex].CompareTo(_elements[leftChildIndex]) < 0)
                    leftChildIndex = rightChildIndex;

                if (_elements[parentIndex].CompareTo(_elements[leftChildIndex]) <= 0)
                    break;

                T tmp = _elements[parentIndex];
                _elements[parentIndex] = _elements[leftChildIndex];
                _elements[leftChildIndex] = tmp;
                parentIndex = leftChildIndex;
            }

            return frontItem;
        }
    }
}
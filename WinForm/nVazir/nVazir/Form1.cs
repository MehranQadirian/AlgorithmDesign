using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace nVazir
{
    public partial class Form1 : Form
    {
        private int boardSize = 8;
        private List<int[]> solutions = new List<int[]>();
        private int currentSolutionIndex = 0;
        private Rectangle previousWindowState;
        private FormWindowState previousWindowStateType = FormWindowState.Normal;
        private bool isRestoring = false;

        public Form1()
        {
            InitializeComponent();
            InitializeComponents();
        }

        

        private void InitializeComponents()
        {
            this.Text = "Algorithm n-minister (Mehran Ghadirian - Rasool Taghipoor)";
            this.Size = new Size(600, 650);

            // کنترل‌های فرم
            Label sizeLabel = new Label
            {
                Text = "اندازه صفحه:",
                Location = new Point(20, 20),
                AutoSize = true
            };

            NumericUpDown sizeInput = new NumericUpDown
            {
                Minimum = 4,
                Maximum = 20,
                Value = 8,
                Location = new Point(120, 18),
                Width = 50
            };

            Button solveButton = new Button
            {
                Text = "حل مسئله",
                Location = new Point(200, 18),
                Width = 100
            };

            Button prevButton = new Button
            {
                Text = "حل قبلی",
                Location = new Point(390, 18),
                Width = 80,
                Enabled = false
            };

            Button nextButton = new Button
            {
                Text = "حل بعدی",
                Location = new Point(480, 18),
                Width = 80,
                Enabled = false
            };
            
            Button RestoreButton = new Button
            {
                Text = "بازگشت به اندازه قبلی",
                Location = new Point(520, 18),
                Width = 120,
                Enabled = false,
                Visible = false
            };
            


            Panel chessBoard = new Panel
            {
                Location = new Point(20, 60),
                Size = new Size(540, 540),
                BorderStyle = BorderStyle.FixedSingle
            };

            // اضافه کردن کنترل‌ها به فرم
            this.Controls.Add(sizeLabel);
            this.Controls.Add(sizeInput);
            this.Controls.Add(solveButton);
            this.Controls.Add(prevButton);
            this.Controls.Add(nextButton);
            this.Controls.Add(RestoreButton);
            this.Controls.Add(chessBoard);

            // رویدادها
            sizeInput.ValueChanged += (sender, e) =>
            {
                boardSize = (int)sizeInput.Value;
            };

            solveButton.Click += (sender, e) =>
            {
                solutions.Clear();
                SolveNQueens();
                currentSolutionIndex = 0;

                if (solutions.Count > 0)
                {
                    prevButton.Enabled = false;
                    nextButton.Enabled = solutions.Count > 1;
                    DrawChessBoard(chessBoard, solutions[currentSolutionIndex]);
                }
                else
                {
                    MessageBox.Show("هیچ راه حلی یافت نشد!", "توجه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    chessBoard.CreateGraphics().Clear(chessBoard.BackColor);
                }
            };



            prevButton.Click += (sender, e) =>
            {
                if (currentSolutionIndex > 0)
                {
                    currentSolutionIndex--;
                    nextButton.Enabled = true;
                    if (currentSolutionIndex == 0)
                        prevButton.Enabled = false;
                    DrawChessBoard(chessBoard, solutions[currentSolutionIndex]);
                }
            };

            nextButton.Click += (sender, e) =>
            {
                if (currentSolutionIndex < solutions.Count - 1)
                {
                    currentSolutionIndex++;
                    prevButton.Enabled = true;
                    if (currentSolutionIndex == solutions.Count - 1)
                        nextButton.Enabled = false;
                    DrawChessBoard(chessBoard, solutions[currentSolutionIndex]);
                }
            };
        }

        private void SolveNQueens()
        {
            int[] queens = new int[boardSize];
            PlaceQueen(queens, 0);
        }

        private void PlaceQueen(int[] queens, int row)
        {
            if (row == boardSize)
            {
                int[] solution = new int[boardSize];
                Array.Copy(queens, solution, boardSize);
                solutions.Add(solution);
                return;
            }

            for (int col = 0; col < boardSize; col++)
            {
                if (IsSafe(queens, row, col))
                {
                    queens[row] = col;
                    PlaceQueen(queens, row + 1);
                }
            }
        }

        private bool IsSafe(int[] queens, int row, int col)
        {
            for (int i = 0; i < row; i++)
            {
                // بررسی ستون و قطرها
                if (queens[i] == col ||
                    queens[i] - i == col - row ||
                    queens[i] + i == col + row)
                    return false;
            }
            return true;
        }

        private void DrawChessBoard(Panel panel, int[] solution)
        {
            Graphics g = panel.CreateGraphics();
            g.Clear(panel.BackColor);

            int cellSize = Math.Min(panel.Width, panel.Height) / boardSize;
            int offsetX = (panel.Width - cellSize * boardSize) / 2;
            int offsetY = (panel.Height - cellSize * boardSize) / 2;

            // رسم صفحه شطرنجی
            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    Brush brush = (row + col) % 2 == 0 ? Brushes.White : Brushes.DimGray;
                    g.FillRectangle(brush, offsetX + col * cellSize, offsetY + row * cellSize, cellSize, cellSize);
                    g.DrawRectangle(Pens.Black, offsetX + col * cellSize, offsetY + row * cellSize, cellSize, cellSize);

                    // رسم وزیر اگر در این خانه باشد
                    if (solution[row] == col)
                    {
                        Font font = new Font("Arial", cellSize / 2, FontStyle.Bold);
                        string queenSymbol = "♕";
                        SizeF textSize = g.MeasureString(queenSymbol, font);
                        g.DrawString(queenSymbol, font, Brushes.Goldenrod,
                            offsetX + col * cellSize + (cellSize - textSize.Width) / 2,
                            offsetY + row * cellSize + (cellSize - textSize.Height) / 2);
                    }
                }
            }

            // نمایش شماره راه حل
            Label solutionLabel = new Label
            {
                Text = $"راه حل {currentSolutionIndex + 1} از {solutions.Count}",
                Location = new Point(20, 10),
                AutoSize = true,
                BackColor = Color.Transparent
            };
            panel.Controls.Clear();
            panel.Controls.Add(solutionLabel);
        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            // ذخیره وضعیت فعلی قبل از تغییر اندازه
            if (!isRestoring && this.WindowState == FormWindowState.Normal)
            {
                previousWindowState = this.DesktopBounds;
                previousWindowStateType = this.WindowState;
            }
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            if (isRestoring)
            {
                isRestoring = false;
                return;
            }

            // اگر به حالت Maximized رفتیم، دکمه را فعال کنیم
            if (this.WindowState == FormWindowState.Maximized)
            {
                var restoreButton = this.Controls.Find("restoreButton", true);
                if (restoreButton.Length > 0)
                {
                    ((Button)restoreButton[0]).Enabled = true;
                }
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            // اگر در حال بازگردانی هستیم، کاری نکنیم
            if (isRestoring) return;

            // اگر به حالت Maximized رفتیم، وضعیت قبلی را ذخیره کنیم
            if (this.WindowState == FormWindowState.Maximized &&
                previousWindowStateType != FormWindowState.Maximized)
            {
                previousWindowStateType = FormWindowState.Maximized;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}

using System;
using System.Diagnostics;

namespace AllExercises
{
    public class NQueensSolver
    {
        private int _solutionsCount;
        private bool[] _rows;
        private bool[] _diagonals1;
        private bool[] _diagonals2;
        private int[] _positions;
        private Stopwatch _stopwatch;
        private readonly int _maxN = 20;

        public void Solve(int n, bool findAllSolutions = true, bool printBoards = true)
        {
            if (n <= 0 || n > _maxN)
            {
                Console.WriteLine($"N must be between 1 and {_maxN}.");
                return;
            }

            Initialize(n);
            Console.WriteLine($"\nSolving {n}-Queens Problem...");

            _stopwatch = Stopwatch.StartNew();
            Solve(0, n, findAllSolutions, printBoards);
            _stopwatch.Stop();

            PrintResults(n, findAllSolutions, printBoards);
        }

        private void Initialize(int n)
        {
            _solutionsCount = 0;
            _rows = new bool[n];
            _diagonals1 = new bool[2 * n - 1];
            _diagonals2 = new bool[2 * n - 1];
            _positions = new int[n];
        }

        private void Solve(int col, int n, bool findAllSolutions, bool printBoards)
        {
            if (col == n)
            {
                _solutionsCount++;
                if (printBoards && (n <= 10 || !findAllSolutions))
                {
                    PrintBoard(n);
                }
                return;
            }

            for (int row = 0; row < n; row++)
            {
                int diag1 = row + col;
                int diag2 = row - col + n - 1;

                if (!_rows[row] && !_diagonals1[diag1] && !_diagonals2[diag2])
                {
                    _positions[col] = row;
                    _rows[row] = _diagonals1[diag1] = _diagonals2[diag2] = true;

                    Solve(col + 1, n, findAllSolutions, printBoards);

                    _rows[row] = _diagonals1[diag1] = _diagonals2[diag2] = false;

                    if (_solutionsCount > 0 && !findAllSolutions)
                        return;
                }
            }
        }

        private void PrintBoard(int n)
        {
            Console.WriteLine($"\nSolution #{_solutionsCount}:");

            // Print column headers
            Console.Write("   ");
            for (int j = 0; j < n; j++)
                Console.Write($" {j + 1} ");
            Console.WriteLine("\n  " + new string('═', n * 3 + 1));

            for (int i = 0; i < n; i++)
            {
                Console.Write($"{i + 1,2} ║");
                for (int j = 0; j < n; j++)
                {
                    if (_positions[j] == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" Q ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write((i + j) % 2 == 0 ? "   " : "███");
                    }
                }
                Console.WriteLine("║");
            }
            Console.WriteLine("  " + new string('═', n * 3 + 1));
        }

        private void PrintResults(int n, bool findAllSolutions, bool printBoards)
        {
            Console.WriteLine($"\nCompleted in {_stopwatch.Elapsed.TotalSeconds:0.000} seconds");
            Console.WriteLine($"Total solutions found: {_solutionsCount}");

            if (n > 10 && printBoards && findAllSolutions)
            {
                Console.WriteLine("\nNote: Board printing was auto-disabled for N > 10 to improve performance.");
                Console.WriteLine("Set printBoards=false to suppress this message.");
            }
        }
        /// <summary>
        /// نمایش تعداد راه‌حل‌ها برای مقادیر مختلف n
        /// </summary>
        /// <param name="maxN">حداکثر تعداد وزیران</param>
        public void DisplaySolutionCountsUpTo(int maxN)
        {
            if (maxN <= 0 || maxN > _maxN)
            {
                Console.WriteLine($"Max N must be between 1 and {_maxN}.");
                return;
            }

            Console.WriteLine("\nNumber of solutions for different board sizes:");
            Console.WriteLine(" N | Solutions");
            Console.WriteLine("---+----------");

            for (int n = 1; n <= maxN; n++)
            {
                Initialize(n);
                Solve(0, n, true, false); // پیدا کردن همه راه‌حل‌ها بدون نمایش
                Console.WriteLine($"{n,2} | {_solutionsCount,9}");
            }
        }
        public void Benchmark()
        {
            Console.WriteLine("\nN-Queens Benchmark (up to 20):");
            Console.WriteLine(" N | Solutions | Time (ms)");
            Console.WriteLine("---+-----------+----------");

            for (int n = 1; n <= _maxN; n++)
            {
                Initialize(n);
                var sw = Stopwatch.StartNew();
                Solve(0, n, true, false);
                sw.Stop();
                Console.WriteLine($"{n,2} | {_solutionsCount,9} | {sw.ElapsedMilliseconds,8}");
            }
        }
    }
}
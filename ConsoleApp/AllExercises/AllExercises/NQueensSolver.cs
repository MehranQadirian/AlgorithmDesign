using System;
using System.Collections.Generic;

namespace AllExercises
{
    public class NQueensSolver
    {
        private List<int[,]> solutions = new List<int[,]>();
        private int currentSolutionIndex = 0;

        public void Solve(int n)
        {
            solutions.Clear();
            currentSolutionIndex = 0;

            int[,] board = new int[n, n];
            PlaceQueens(board, 0, n);

            if (solutions.Count == 0)
            {
                Console.WriteLine("There is no solution for this value of N.");
                return;
            }

            ShowSolution(currentSolutionIndex);

            

            while (true)
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.RightArrow)
                {
                    currentSolutionIndex = (currentSolutionIndex + 1) % solutions.Count;
                    ShowSolution(currentSolutionIndex);
                }
                else if (key == ConsoleKey.LeftArrow)
                {
                    currentSolutionIndex = (currentSolutionIndex - 1 + solutions.Count) % solutions.Count;
                    ShowSolution(currentSolutionIndex);
                }
                else if (key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }

        private bool PlaceQueens(int[,] board, int col, int n)
        {
            if (col == n)
            {
                // ذخیره کپی از صفحه شطرنج به لیست راه‌حل‌ها
                int[,] solution = new int[n, n];
                Array.Copy(board, solution, board.Length);
                solutions.Add(solution);
                return false; // ادامه جستجو برای سایر راه‌حل‌ها
            }

            bool foundAny = false;

            for (int row = 0; row < n; row++)
            {
                if (IsSafe(board, row, col, n))
                {
                    board[row, col] = 1;
                    foundAny |= PlaceQueens(board, col + 1, n);
                    board[row, col] = 0; // بازگشت به عقب (Backtrack)
                }
            }

            return foundAny;
        }

        private bool IsSafe(int[,] board, int row, int col, int n)
        {
            for (int i = 0; i < col; i++)
                if (board[row, i] == 1)
                    return false;

            for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--)
                if (board[i, j] == 1)
                    return false;

            for (int i = row + 1, j = col - 1; i < n && j >= 0; i++, j--)
                if (board[i, j] == 1)
                    return false;

            return true;
        }

        private void ShowSolution(int index)
        {
            Console.Clear();
            int[,] board = solutions[index];
            int n = board.GetLength(0);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Solution number {index + 1} of {solutions.Count} for problem {n}-Minister:");
            Console.ResetColor();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.ForegroundColor = (board[i, j] == 1) ? ConsoleColor.Yellow : ConsoleColor.Gray;
                    Console.Write(board[i, j] == 1 ? "Q " : ". ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\nPrevious[←] | Next[→] | Esc to exit");
        }
    }
}

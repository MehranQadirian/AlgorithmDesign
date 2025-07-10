using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllExercises
{
    public class NQueensSolver
    {
        public void Solve(int n)
        {
            int[,] board = new int[n, n];
            if (SolveNQUtil(board, 0))
            {
                PrintSolution(board);
            }
            else
            {
                Console.WriteLine("هیچ راه حلی وجود ندارد");
            }
        }

        private bool SolveNQUtil(int[,] board, int col)
        {
            int N = board.GetLength(0);

            if (col >= N)
                return true;

            for (int i = 0; i < N; i++)
            {
                if (IsSafe(board, i, col))
                {
                    board[i, col] = 1;

                    if (SolveNQUtil(board, col + 1))
                        return true;

                    board[i, col] = 0;
                }
            }

            return false;
        }

        private bool IsSafe(int[,] board, int row, int col)
        {
            int N = board.GetLength(0);

            for (int i = 0; i < col; i++)
                if (board[row, i] == 1)
                    return false;

            for (int i = row, j = col; i >= 0 && j >= 0; i--, j--)
                if (board[i, j] == 1)
                    return false;

            for (int i = row, j = col; i < N && j >= 0; i++, j--)
                if (board[i, j] == 1)
                    return false;

            return true;
        }

        private void PrintSolution(int[,] board)
        {
            int N = board.GetLength(0);
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(board[i, j] == 1 ? "Q " : ". ");
                }
                Console.WriteLine();
            }
        }
    }
}

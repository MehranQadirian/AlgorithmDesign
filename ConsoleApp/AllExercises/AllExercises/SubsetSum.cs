using System;

namespace AllExercises
{
    /// <summary>
    /// Determines whether there exists a subset of a given set that sums to a target value.
    /// Implements the Subset Sum problem using dynamic programming in a structured way.
    /// </summary>
    public class SubsetSum
    {
        /// <summary>
        /// Determines whether a subset with the given sum exists in the set.
        /// </summary>
        /// <param name="set">An array of positive integers</param>
        /// <param name="target">The target sum to achieve</param>
        /// <returns>True if such a subset exists, otherwise false</returns>
        public bool IsSubsetSum(int[] set, int target)
        {
            int n = set.Length;
            bool[,] dp = new bool[n + 1, target + 1];

            // Base Case: Zero sum is always achievable (with empty subset)
            for (int i = 0; i <= n; i++)
                dp[i, 0] = true;

            // Fill the DP table
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= target; j++)
                {
                    if (set[i - 1] > j)
                    {
                        // Current element is too large to be included
                        dp[i, j] = dp[i - 1, j];
                    }
                    else
                    {
                        // Decision: include or exclude the current element
                        dp[i, j] = dp[i - 1, j] || dp[i - 1, j - set[i - 1]];
                    }
                }
            }

            // Display the decision table
            PrintDecisionTable(dp, set, target);

            // Final answer: Can we make the sum using all elements?
            return dp[n, target];
        }

        /// <summary>
        /// Prints the decision table used during the dynamic programming computation.
        /// </summary>
        private void PrintDecisionTable(bool[,] dp, int[] set, int target)
        {
            Console.WriteLine("\nDynamic Programming Decision Table:");
            Console.Write("     ");
            for (int j = 0; j <= target; j++)
                Console.Write($"{j,4}");
            Console.WriteLine();

            for (int i = 0; i <= set.Length; i++)
            {
                Console.Write(i == 0 ? "Ø   " : $"{set[i - 1],-4}");
                for (int j = 0; j <= target; j++)
                {
                    Console.Write(dp[i, j] ? " T  " : " F  ");
                }
                Console.WriteLine();
            }
        }
    }
}

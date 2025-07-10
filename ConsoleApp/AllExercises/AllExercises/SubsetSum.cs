using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllExercises
{
    public class SubsetSum
    {
        public bool IsSubsetSum(int[] set, int sum)
        {
            int n = set.Length;
            bool[,] dp = new bool[n + 1, sum + 1];

            for (int i = 0; i <= n; i++)
                dp[i, 0] = true;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= sum; j++)
                {
                    if (set[i - 1] > j)
                        dp[i, j] = dp[i - 1, j];
                    else
                        dp[i, j] = dp[i - 1, j] || dp[i - 1, j - set[i - 1]];
                }
            }

            return dp[n, sum];
        }
    }
}

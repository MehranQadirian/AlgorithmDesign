using System;
using System.Collections.Generic;
using System.Linq;

namespace AllExercises
{
    /// <summary>
    /// کلاس حل مسئله زیرمجموعه با جمع مشخص (Subset Sum Problem)
    /// با استفاده از برنامه‌نویسی پویا
    /// </summary>
    public class SubsetSum
    {
        /// <summary>
        /// بررسی وجود زیرمجموعه‌ای با جمع برابر مقدار هدف
        /// </summary>
        /// <param name="set">آرایه اعداد ورودی</param>
        /// <param name="targetSum">جمع هدف</param>
        /// <returns>
        /// true اگر زیرمجموعه‌ای با جمع برابر هدف وجود داشته باشد،
        /// در غیر این صورت false
        /// </returns>
        public bool IsSubsetSum(int[] set, int targetSum)
        {
            // اعتبارسنجی ورودی‌ها
            if (set == null || set.Length == 0)
            {
                throw new ArgumentException("Set cannot be null or empty", nameof(set));
            }

            if (targetSum < 0)
            {
                throw new ArgumentException("Target sum cannot be negative", nameof(targetSum));
            }

            int n = set.Length;

            // ماتریس برنامه‌نویسی پویا
            // dp[i,j] = true اگر زیرمجموعه‌ای از i عنصر اول با جمع j وجود داشته باشد
            bool[,] dp = new bool[n + 1, targetSum + 1];

            // حالت پایه: جمع صفر همیشه با زیرمجموعه خالی قابل دستیابی است
            for (int i = 0; i <= n; i++)
                dp[i, 0] = true;

            // پر کردن ماتریس dp
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= targetSum; j++)
                {
                    // اگر عنصر فعلی بزرگتر از جمع هدف باشد، نمی‌توانیم آن را شامل شویم
                    if (set[i - 1] > j)
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                    else
                    {
                        // دو حالت:
                        // 1. شامل عنصر فعلی نشویم (dp[i-1, j])
                        // 2. شامل عنصر فعلی شویم (dp[i-1, j-set[i-1]])
                        dp[i, j] = dp[i - 1, j] || dp[i - 1, j - set[i - 1]];
                    }
                }
            }

            return dp[n, targetSum];
        }

        /// <summary>
        /// پیدا کردن همه زیرمجموعه‌های ممکن با جمع برابر هدف
        /// </summary>
        /// <param name="set">آرایه اعداد ورودی</param>
        /// <param name="targetSum">جمع هدف</param>
        /// <returns>لیستی از همه زیرمجموعه‌های معتبر</returns>
        public List<int[]> FindAllSubsets(int[] set, int targetSum)
        {
            var result = new List<int[]>();
            FindSubsets(set, targetSum, 0, new List<int>(), result);
            return result;
        }

        /// <summary>
        /// تابع بازگشتی برای پیدا کردن همه زیرمجموعه‌ها
        /// </summary>
        private void FindSubsets(int[] set, int remainingSum, int index,
                               List<int> current, List<int[]> result)
        {
            // اگر جمع هدف رسیده باشد
            if (remainingSum == 0)
            {
                result.Add(current.ToArray());
                return;
            }

            // اگر به انتهای آرایه رسیده‌ایم یا جمع هدف منفی شده
            if (index >= set.Length || remainingSum < 0)
                return;

            // حالت ۱: شامل عنصر فعلی می‌شویم
            current.Add(set[index]);
            FindSubsets(set, remainingSum - set[index], index + 1, current, result);
            current.RemoveAt(current.Count - 1); // Backtrack

            // حالت ۲: شامل عنصر فعلی نمی‌شویم
            FindSubsets(set, remainingSum, index + 1, current, result);
        }
    }
}
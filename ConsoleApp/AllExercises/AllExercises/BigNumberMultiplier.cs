using System;
using System.Text;

namespace AllExercises
{
    /// <summary>
    /// Implements multiplication of two arbitrarily large non-negative integers represented as strings,
    /// based on a digit-by-digit simulation of elementary school multiplication.
    /// </summary>
    public class BigNumberMultiplier
    {
        /// <summary>
        /// Multiplies two large integers represented as strings.
        /// </summary>
        /// <param name="num1">First non-negative integer as string</param>
        /// <param name="num2">Second non-negative integer as string</param>
        /// <returns>Product of the two numbers as string</returns>
        public string Multiply(string num1, string num2)
        {
            // Step 1: Handle edge case when one of the numbers is "0"
            if (num1 == "0" || num2 == "0")
                return "0";

            int n = num1.Length;
            int m = num2.Length;

            // Step 2: Create an array to store intermediate results
            int[] result = new int[n + m];

            // Step 3: Multiply each digit from right to left (like manual multiplication)
            for (int i = n - 1; i >= 0; i--)
            {
                int digit1 = num1[i] - '0';

                for (int j = m - 1; j >= 0; j--)
                {
                    int digit2 = num2[j] - '0';

                    int position1 = i + j;
                    int position2 = i + j + 1;

                    int product = digit1 * digit2;
                    int sum = product + result[position2];

                    result[position2] = sum % 10;           // Assign digit
                    result[position1] += sum / 10;          // Carry to previous digit
                }
            }

            // Step 4: Convert result array to string (skipping leading zeros)
            StringBuilder sb = new StringBuilder();

            foreach (int digit in result)
            {
                if (sb.Length == 0 && digit == 0)
                    continue;

                sb.Append(digit);
            }

            return sb.ToString();
        }
    }
}

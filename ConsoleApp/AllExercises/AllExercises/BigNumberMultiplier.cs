using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllExercises
{
    public class BigNumberMultiplier
    {
        public string Multiply(string num1, string num2)
        {
            int[] result = new int[num1.Length + num2.Length];

            for (int i = num1.Length - 1; i >= 0; i--)
            {
                for (int j = num2.Length - 1; j >= 0; j--)
                {
                    int product = (num1[i] - '0') * (num2[j] - '0');
                    int sum = product + result[i + j + 1];

                    result[i + j + 1] = sum % 10;
                    result[i + j] += sum / 10;
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (int num in result)
            {
                if (sb.Length == 0 && num == 0) continue;
                sb.Append(num);
            }

            return sb.Length == 0 ? "0" : sb.ToString();
        }
    }
}

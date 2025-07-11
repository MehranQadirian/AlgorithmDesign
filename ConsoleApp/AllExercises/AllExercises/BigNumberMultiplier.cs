using System;
using System.Linq;
using System.Text;

namespace AllExercises
{
    public class BigNumberMultiplier
    {
        public string Multiply(string num1, string num2)
        {
            // اعتبارسنجی ورودی‌ها
            if (string.IsNullOrWhiteSpace(num1)) num1 = "0";
            if (string.IsNullOrWhiteSpace(num2)) num2 = "0";

            if (!num1.All(char.IsDigit) || !num2.All(char.IsDigit))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Input must contain only digits");
                Console.ResetColor();
                return "Invalid Input";
            }

            // حذف صفرهای غیرضروری از ابتدا
            num1 = num1.TrimStart('0');
            num2 = num2.TrimStart('0');

            if (num1.Length == 0) num1 = "0";
            if (num2.Length == 0) num2 = "0";

            // نمایش ورودی‌ها به صورت زیبا
            Console.WriteLine("\nInputs :");
            Console.WriteLine($"First Number: {FormatNumber(num1)}");
            Console.WriteLine($"Second Number: {FormatNumber(num2)}");
            Console.WriteLine(new string('-', 30));

            // عملیات ضرب
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

            // ساخت نتیجه نهایی
            StringBuilder sb = new StringBuilder();
            foreach (int num in result)
            {
                if (sb.Length == 0 && num == 0) continue;
                sb.Append(num);
            }

            string finalResult = sb.Length == 0 ? "0" : sb.ToString();

            // نمایش نتیجه به صورت زیبا
            Console.WriteLine("\nMultiplication Result:");
            Console.WriteLine($"\t  {FormatNumber(num1)}");
            Console.WriteLine($"\t×" +
                $"\n\t  {FormatNumber(num2)}");
            Console.WriteLine(new string('=', finalResult.Length + 2));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(FormatNumber(finalResult));
            Console.ResetColor();

            return finalResult;
        }

        // تابع کمکی برای فرمت کردن اعداد با جداکننده هزارگان
        private string FormatNumber(string number)
        {
            if (string.IsNullOrEmpty(number)) return "0";

            var formatted = new StringBuilder();
            int count = 0;

            for (int i = number.Length - 1; i >= 0; i--)
            {
                formatted.Insert(0, number[i]);
                count++;

                if (count % 3 == 0 && i != 0)
                {
                    formatted.Insert(0, ",");
                }
            }

            return formatted.ToString();
        }

        // روش جایگزین برای نمایش مراحل ضرب (اختیاری)
        public void PrettyMultiply(string num1, string num2)
        {
            string result = Multiply(num1, num2);

            Console.WriteLine("\nCalculation Steps:");
            for (int i = num2.Length - 1, pad = 0; i >= 0; i--, pad++)
            {
                int digit = num2[i] - '0';
                string partial = Multiply(num1, digit.ToString());
                Console.WriteLine($"{partial}{new string(' ', pad)}");
            }

            Console.WriteLine(new string('-', result.Length));
            Console.WriteLine(result);
        }
    }
}
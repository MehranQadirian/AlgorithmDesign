using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Sum_of_Subsets
{
    public partial class MainForm : Form
    {
        private List<MultiplicationRecord> history = new List<MultiplicationRecord>();
        private readonly string historyFilePath = "multiplication_history.json";

        public MainForm()
        {
            InitializeComponent();
            LoadHistory();
            UpdateHistoryList();
            this.BackColor = Color.FromArgb(29, 32, 42);
            this.resultLabel.ForeColor = Color.FromArgb(193,208,255);
            this.historyLabel.ForeColor = Color.FromArgb(193, 208, 255);
            number2TextBox.Text = "عدد دوم";
            number2TextBox.ForeColor = Color.Gray;
        }

        private void btnOpenTelegram_Click(object sender, EventArgs e)
        {
            string url = "https://t.me/bi_buk";

            try
            {
                System.Diagnostics.Process.Start(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطا در باز کردن لینک:\n{ex.Message}", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOpenLinkedin_Click(object sender, EventArgs e)
        {
            string url = "https://www.linkedin.com/in/mehran-ghadirian-37b421333?lipi=urn%3Ali%3Apage%3Ad_flagship3_profile_view_base_contact_details%3BKJw7u7FCTSyVO9UeuvqsOg%3D%3D";

            try
            {
                System.Diagnostics.Process.Start(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطا در باز کردن لینک:\n{ex.Message}", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // تنظیمات ظاهری فرم
            this.Text = "ضرب اعداد بزرگ";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Tahoma", 10, FontStyle.Regular);
        }

        private void LoadHistory()
        {
            if (File.Exists(historyFilePath))
            {
                try
                {
                    string json = File.ReadAllText(historyFilePath);
                    history = JsonConvert.DeserializeObject<List<MultiplicationRecord>>(json) ?? new List<MultiplicationRecord>();
                }
                catch
                {
                    history = new List<MultiplicationRecord>();
                }
            }
        }

        private void SaveHistory()
        {
            string json = JsonConvert.SerializeObject(history, Formatting.Indented);
            File.WriteAllText(historyFilePath, json);
        }

        private void UpdateHistoryList()
        {
            int index = 1;
            historyListBox.Items.Clear();
            foreach (var record in history)
            {
                historyListBox.Items.Add($"({index})Multiplication : {record.Number1} × {record.Number2}");
                historyListBox.Items.Add($"({index})Result : {record.Result}");
                //historyListBox.Items.Add($"{record.Number1} × {record.Number2} = {record.Result}");
                index++;
            }
        }

        //private string MultiplyBigNumbers(string num1, string num2)
        //{
        //    if (string.IsNullOrEmpty(num1) || string.IsNullOrEmpty(num2))
        //        return "0";

        //    int len1 = num1.Length;
        //    int len2 = num2.Length;
        //    int[] result = new int[len1 + len2];

        //    // ضرب هر رقم از num1 در هر رقم از num2
        //    for (int i = len1 - 1; i >= 0; i--)
        //    {
        //        for (int j = len2 - 1; j >= 0; j--)
        //        {
        //            int digit1 = num1[i] - '0';
        //            int digit2 = num2[j] - '0';
        //            int product = digit1 * digit2;

        //            int sum = product + result[i + j + 1];
        //            result[i + j + 1] = sum % 10;
        //            result[i + j] += sum / 10;
        //        }
        //    }

        //    // تبدیل آرایه نتیجه به رشته
        //    string finalResult = string.Join("", result).TrimStart('0');
        //    return finalResult == "" ? "0" : finalResult;
        //}

        private string MultiplyBigNumbersRecursive(string num1, string num2)
        {
            // حالت پایه: اگر یکی از اعداد صفر باشد
            if (num1 == "0" || num2 == "0") return "0";

            // حالت پایه: اگر هر دو اعداد تک رقمی باشند
            if (num1.Length == 1 && num2.Length == 1)
            {
                return (int.Parse(num1) * int.Parse(num2)).ToString();
            }

            // طول اعداد را برابر می‌کنیم با اضافه کردن صفر به ابتدای عدد کوتاهتر
            int maxLength = Math.Max(num1.Length, num2.Length);
            num1 = num1.PadLeft(maxLength, '0');
            num2 = num2.PadLeft(maxLength, '0');

            // تقسیم اعداد به دو نیمه
            int mid = maxLength / 2;
            string a = num1.Substring(0, mid);
            string b = num1.Substring(mid);
            string c = num2.Substring(0, mid);
            string d = num2.Substring(mid);

            // محاسبه ضرایب کاراتسوبا به صورت بازگشتی
            string ac = MultiplyBigNumbersRecursive(a, c);    // ضرب نیمه اول اعداد
            string bd = MultiplyBigNumbersRecursive(b, d);    // ضرب نیمه دوم اعداد

            // محاسبه (a+b)(c+d) - ac - bd = ad + bc
            string aPlusB = AddStrings(a, b);
            string cPlusD = AddStrings(c, d);
            string adPlusBc = SubtractStrings(
                SubtractStrings(MultiplyBigNumbersRecursive(aPlusB, cPlusD), ac),
                bd
            );

            // ترکیب نتایج با شیفت مناسب
            string acShifted = ShiftLeft(ac, 2 * (maxLength - mid));
            string adPlusBcShifted = ShiftLeft(adPlusBc, maxLength - mid);

            // جمع نهایی تمام بخش‌ها
            string result = AddStrings(AddStrings(acShifted, adPlusBcShifted), bd);

            return result.TrimStart('0');
        }

        // تابع کمکی برای جمع دو عدد بزرگ به صورت رشته
        private string AddStrings(string num1, string num2)
        {
            int i = num1.Length - 1;
            int j = num2.Length - 1;
            int carry = 0;
            StringBuilder result = new StringBuilder();

            while (i >= 0 || j >= 0 || carry > 0)
            {
                int digit1 = i >= 0 ? num1[i--] - '0' : 0;
                int digit2 = j >= 0 ? num2[j--] - '0' : 0;
                int sum = digit1 + digit2 + carry;
                result.Insert(0, sum % 10);
                carry = sum / 10;
            }

            return result.ToString();
        }

        // تابع کمکی برای تفریق دو عدد بزرگ (num1 باید بزرگتر یا مساوی num2 باشد)
        private string SubtractStrings(string num1, string num2)
        {
            int i = num1.Length - 1;
            int j = num2.Length - 1;
            int borrow = 0;
            StringBuilder result = new StringBuilder();

            while (i >= 0)
            {
                int digit1 = num1[i--] - '0' - borrow;
                int digit2 = j >= 0 ? num2[j--] - '0' : 0;

                borrow = 0;
                if (digit1 < digit2)
                {
                    digit1 += 10;
                    borrow = 1;
                }
                result.Insert(0, digit1 - digit2);
            }

            return result.ToString().TrimStart('0');
        }

        // تابع کمکی برای جابجایی ارقام (معادل ضرب در 10^n)
        private string ShiftLeft(string num, int n)
        {
            if (num == "0") return "0";
            return num + new string('0', n);
        }

        private void multiplyButton_Click(object sender, EventArgs e)
        {
            string num1 = number1TextBox.Text.Trim();
            string num2 = number2TextBox.Text.Trim();

            if (string.IsNullOrEmpty(num1) || string.IsNullOrEmpty(num2))
            {
                MessageBox.Show("لطفاً هر دو عدد را وارد کنید.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // اعتبارسنجی اعداد
            foreach (char c in num1)
            {
                if (!char.IsDigit(c))
                {
                    MessageBox.Show("عدد اول فقط باید شامل ارقام باشد.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            foreach (char c in num2)
            {
                if (!char.IsDigit(c))
                {
                    MessageBox.Show("عدد دوم فقط باید شامل ارقام باشد.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            string result = MultiplyBigNumbersRecursive(num1, num2);
            resultLabel.Text = $"نتیجه: {result}";

            // ذخیره در تاریخچه
            var record = new MultiplicationRecord
            {
                Number1 = num1,
                Number2 = num2,
                Result = result,
                Timestamp = DateTime.Now
            };

            history.Insert(0, record);
            SaveHistory();
            UpdateHistoryList();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            number1TextBox.Text = "";
            number2TextBox.Text = "";
            resultLabel.Text = "نتیجه: ";
        }

        private void clearHistoryButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("آیا از پاک کردن تمام تاریخچه عملیات اطمینان دارید؟",
                "تأیید پاک کردن",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                history.Clear();
                SaveHistory();
                UpdateHistoryList();
            }
        }

        private void number1TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void HandleTextBoxEnter(object sender, EventArgs e)
        {
            TextBox currentTextBox = sender as TextBox;
            //TextBox otherTextBox = (currentTextBox == number1TextBox) ? number2TextBox : number1TextBox;
            if (currentTextBox.Text == "عدد اول")
            {
                currentTextBox.Text = "";
                currentTextBox.ForeColor = Color.Black;
            }
            else if (currentTextBox.Text == "عدد دوم")
            {
                currentTextBox.Text = "";
                currentTextBox.ForeColor = Color.Black;
            }
        }
        private void HandleTextBoxLeave(object sender, EventArgs e)
        {
            TextBox currentTextBox = sender as TextBox;
            //TextBox otherTextBox = (currentTextBox == number1TextBox) ? number2TextBox : number1TextBox;
            if (currentTextBox == number1TextBox & currentTextBox.Text == "")
            {
                currentTextBox.Text = "عدد اول";
                currentTextBox.ForeColor = Color.Gray;
            }
            else if (currentTextBox == number2TextBox & currentTextBox.Text == "")
            {
                currentTextBox.Text = "عدد دوم";
                currentTextBox.ForeColor = Color.Gray;
            }
        }

        private void btnOpenGitHub_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/MehranQadirian";

            try
            {
                System.Diagnostics.Process.Start(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطا در باز کردن لینک:\n{ex.Message}", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class MultiplicationRecord
    {
        public string Number1 { get; set; }
        public string Number2 { get; set; }
        public string Result { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
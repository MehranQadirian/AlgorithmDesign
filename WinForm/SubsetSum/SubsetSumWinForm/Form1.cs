using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SubsetSumWinForm
{
    public partial class Form1 : Form
    {
        private enum Language { English, Persian }
        private enum Theme { Light, Dark,Blue,Red,Green }

        private Language currentLanguage = Language.English;
        private Theme currentTheme = Theme.Light;

        public Form1()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.icon;
            // مقداردهی اولیه combo ها
            comboLanguage.Items.AddRange(new string[] { "English", "فارسی" });
            comboTheme.Items.AddRange(new string[] { "Light", "Dark" , "Blue" , "Red" , "Green"});

            comboLanguage.SelectedIndex = 0; // English پیش‌فرض
            comboTheme.SelectedIndex = 0;    // Light پیش‌فرض

            comboLanguage.SelectedIndexChanged += comboLanguage_SelectedIndexChanged;
            comboTheme.SelectedIndexChanged += comboTheme_SelectedIndexChanged;

            UpdateLanguage();
            UpdateTheme();
        }

        private void comboLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentLanguage = comboLanguage.SelectedIndex == 0 ? Language.English : Language.Persian;
            UpdateLanguage();
        }

        private void comboTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentTheme = comboTheme.SelectedIndex == 0 ? Theme.Light : comboTheme.SelectedIndex == 1 ? Theme.Dark :
                comboTheme.SelectedIndex == 2 ? Theme.Blue : comboTheme.SelectedIndex == 3 ? Theme.Red : Theme.Green;
            UpdateTheme();
        }

        private void UpdateLanguage()
        {
            if (currentLanguage == Language.English)
            {
                lblInput.Text = "Enter numbers separated by commas:";
                lblTarget.Text = "Enter target sum:";
                lblLang.Text = "Language :";
                lblTheme.Text = "Theme :";
                btnFindSubsets.Text = "Find Subsets";
                btnClear.Text = "Clear All";
                btnSaveResults.Text = "Save Results...";
                btnHelp.Text = "Help";

                toolTip1.SetToolTip(txtNumbers, "Enter numbers separated by commas, e.g. 1, 2, 3, 4");
                toolTip1.SetToolTip(txtTarget, "Enter the target sum (non-negative integer)");
                toolTip1.SetToolTip(btnFindSubsets, "Click to find all subsets that sum to the target");
                toolTip1.SetToolTip(btnSaveResults, "Save the found subsets to a text file");
                toolTip1.SetToolTip(btnClear, "Clear all input fields and results");
                comboTheme.Items.Clear();
                comboTheme.Items.AddRange(new string[] { "Light", "Dark", "Blue", "Red", "Green" });

                this.Text = "Subset Sum Finder";

                this.RightToLeft = RightToLeft.No;
            }
            else
            {
                lblInput.Text = "اعداد را با کاما جدا کنید:";
                lblTarget.Text = "مجموع هدف را وارد کنید:";
                lblLang.Text = "زبان :";
                lblTheme.Text = "پوسته :";
                btnFindSubsets.Text = "یافتن زیرمجموعه‌ها";
                btnClear.Text = "پاک کردن همه";
                btnSaveResults.Text = "ذخیره نتایج...";
                btnHelp.Text = "راهنما";

                toolTip1.SetToolTip(txtNumbers, "اعداد را با کاما جدا کنید، مثال: ۱، ۲، ۳، ۴");
                toolTip1.SetToolTip(txtTarget, "مجموع هدف (عدد صحیح صفر یا مثبت) را وارد کنید");
                toolTip1.SetToolTip(btnFindSubsets, "برای یافتن همه زیرمجموعه‌هایی که به مجموع هدف می‌رسند کلیک کنید");
                toolTip1.SetToolTip(btnSaveResults, "ذخیره زیرمجموعه‌های پیدا شده در فایل متنی");
                toolTip1.SetToolTip(btnClear, "پاک کردن همه ورودی‌ها و نتایج");
                comboTheme.Items.Clear();
                comboTheme.Items.AddRange(new string[] { "روشن", "تیره", "آبی", "قرمز", "سبز" });

                this.Text = "یافتن زیرمجموعه‌ها";
                this.RightToLeft = RightToLeft.Yes;
            }
        }

        private void UpdateTheme()
        {
            if (currentTheme == Theme.Light)
            {
                this.BackColor = System.Drawing.Color.WhiteSmoke;
                ForeColor = System.Drawing.Color.Black;
                foreach (Control ctl in this.Controls)
                {
                    ctl.ForeColor = System.Drawing.Color.Black;

                    if (ctl is TextBox || ctl is ListBox)
                        ctl.BackColor = System.Drawing.Color.White;
                    else if (ctl is Button)
                        ctl.BackColor = System.Drawing.Color.LightGray;
                    else if (ctl is ComboBox)
                        ctl.BackColor = System.Drawing.Color.White;
                }
            }
            else if(currentTheme == Theme.Dark) // Dark
            {
                this.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                ForeColor = System.Drawing.Color.White;
                foreach (Control ctl in this.Controls)
                {
                    ctl.ForeColor = System.Drawing.Color.White;

                    if (ctl is TextBox || ctl is ListBox)
                        ctl.BackColor = System.Drawing.Color.FromArgb(50, 50, 50);
                    else if (ctl is Button)
                        ctl.BackColor = System.Drawing.Color.DimGray;
                    else if (ctl is ComboBox)
                        ctl.BackColor = System.Drawing.Color.FromArgb(50, 50, 50);
                }
            }
            else if (currentTheme == Theme.Blue) // Blue
            {
                this.BackColor = System.Drawing.Color.Navy;
                ForeColor = System.Drawing.Color.Yellow;
                foreach (Control ctl in this.Controls)
                {
                    ctl.ForeColor = System.Drawing.Color.Yellow;

                    if (ctl is TextBox || ctl is ListBox)
                        ctl.BackColor = System.Drawing.Color.RoyalBlue;
                    else if (ctl is Button)
                        ctl.BackColor = System.Drawing.Color.RoyalBlue;
                    else if (ctl is ComboBox)
                        ctl.BackColor = System.Drawing.Color.RoyalBlue;
                }
            }
            else if (currentTheme == Theme.Red) // Red
            {
                this.BackColor = System.Drawing.Color.Maroon;
                ForeColor = System.Drawing.Color.Snow;
                foreach (Control ctl in this.Controls)
                {
                    ctl.ForeColor = System.Drawing.Color.Snow;

                    if (ctl is TextBox || ctl is ListBox)
                        ctl.BackColor = System.Drawing.Color.Red;
                    else if (ctl is Button)
                        ctl.BackColor = System.Drawing.Color.Red;
                    else if (ctl is ComboBox)
                        ctl.BackColor = System.Drawing.Color.Red;
                }
            }
            else // Green
            {
                this.BackColor = System.Drawing.Color.DarkGreen;
                ForeColor = System.Drawing.Color.Snow;
                foreach (Control ctl in this.Controls)
                {
                    ctl.ForeColor = System.Drawing.Color.Snow;

                    if (ctl is TextBox || ctl is ListBox)
                        ctl.BackColor = System.Drawing.Color.ForestGreen;
                    else if (ctl is Button)
                        ctl.BackColor = System.Drawing.Color.ForestGreen;
                    else if (ctl is ComboBox)
                        ctl.BackColor = System.Drawing.Color.ForestGreen;
                }
            }
        }

        private void FindSubsets(int[] nums, int target, List<int> currentSubset, int index, List<List<int>> results)
        {
            if (target == 0)
            {
                results.Add(new List<int>(currentSubset));
                return;
            }

            if (target < 0 || index == nums.Length)
                return;

            currentSubset.Add(nums[index]);
            FindSubsets(nums, target - nums[index], currentSubset, index + 1, results);

            currentSubset.RemoveAt(currentSubset.Count - 1);
            FindSubsets(nums, target, currentSubset, index + 1, results);
        }

        private void btnFindSubsets_Click(object sender, EventArgs e)
        {
            lstResults.Items.Clear();
            lblStatus.Text = "";
            lblStatus.ForeColor = System.Drawing.Color.Black;

            string input = txtNumbers.Text.Trim();
            if (string.IsNullOrEmpty(input))
            {
                lblStatus.Text = currentLanguage == Language.English ? "Please enter numbers separated by commas." : "لطفاً اعداد را با کاما جدا وارد کنید.";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                return;
            }

            string[] parts = input.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            int[] numbers = new int[parts.Length];

            for (int i = 0; i < parts.Length; i++)
            {
                if (!int.TryParse(parts[i].Trim(), out numbers[i]))
                {
                    lblStatus.Text = currentLanguage == Language.English ?
                        $"Invalid number: '{parts[i].Trim()}'" :
                        $"عدد نامعتبر: '{parts[i].Trim()}'";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }

            if (!int.TryParse(txtTarget.Text.Trim(), out int target))
            {
                lblStatus.Text = currentLanguage == Language.English ? "Invalid target number." : "عدد هدف نامعتبر است.";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (target < 0)
            {
                lblStatus.Text = currentLanguage == Language.English ? "Target number must be zero or positive." : "عدد هدف باید صفر یا مثبت باشد.";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                return;
            }

            List<List<int>> results = new List<List<int>>();
            FindSubsets(numbers, target, new List<int>(), 0, results);

            if (results.Count == 0)
            {
                lblStatus.Text = currentLanguage == Language.English ? "No subsets found." : "زیرمجموعه‌ای پیدا نشد.";
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                foreach (var subset in results)
                {
                    lstResults.Items.Add(string.Join(", ", subset));
                }
                lblStatus.Text = currentLanguage == Language.English ?
                    $"Found {results.Count} subset(s)." :
                    $"تعداد {results.Count} زیرمجموعه یافت شد.";
                lblStatus.ForeColor = System.Drawing.Color.Green;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNumbers.Clear();
            txtTarget.Clear();
            lstResults.Items.Clear();
            lblStatus.Text = "";
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string helpMessageEnglish = "Subset Sum Finder Help:\n\n" +
                "1. Enter a list of integers separated by commas (e.g. 1, 2, 3, 4).\n" +
                "2. Enter a target sum (must be zero or a positive integer).\n" +
                "3. Click 'Find Subsets' to see all subsets that add up to the target.\n" +
                "4. Results will be shown in the list box.\n" +
                "5. Use 'Save Results' to save the subsets to a text file.\n" +
                "6. Use 'Clear All' to reset inputs and results.\n\n" +
                "Tips:\n- Ensure numbers are valid integers.\n- The program finds all unique subsets.\n" +
                "- For large inputs, processing may take some time.";

            string helpMessagePersian = "راهنمای یافتن زیرمجموعه‌ها:\n\n" +
                "۱. یک لیست از اعداد صحیح را با کاما جدا کنید (مثال: ۱، ۲، ۳، ۴).\n" +
                "۲. مجموع هدف را وارد کنید (باید صفر یا عدد مثبت باشد).\n" +
                "۳. برای دیدن زیرمجموعه‌هایی که به مجموع هدف می‌رسند، روی 'یافتن زیرمجموعه‌ها' کلیک کنید.\n" +
                "۴. نتایج در جعبه لیست نمایش داده می‌شود.\n" +
                "۵. از گزینه 'ذخیره نتایج' برای ذخیره زیرمجموعه‌ها در فایل متنی استفاده کنید.\n" +
                "۶. برای پاک کردن ورودی‌ها و نتایج، از گزینه 'پاک کردن همه' استفاده کنید.\n\n" +
                "نکات:\n- مطمئن شوید اعداد صحیح معتبر وارد شده‌اند.\n- برنامه همه زیرمجموعه‌های منحصر به فرد را پیدا می‌کند.\n" +
                "- برای ورودی‌های بزرگ، پردازش ممکن است زمان‌بر باشد.";

            MessageBox.Show(currentLanguage == Language.English ? helpMessageEnglish : helpMessagePersian,
                currentLanguage == Language.English ? "Help - Subset Sum Finder" : "راهنما - یافتن زیرمجموعه‌ها",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSaveResults_Click(object sender, EventArgs e)
        {
            if (lstResults.Items.Count == 0)
            {
                MessageBox.Show(currentLanguage == Language.English ? "No results to save." : "نتیجه‌ای برای ذخیره وجود ندارد.",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                sfd.Title = currentLanguage == Language.English ? "Save Results" : "ذخیره نتایج";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(sfd.FileName))
                        {
                            foreach (var item in lstResults.Items)
                            {
                                sw.WriteLine(item.ToString());
                            }
                        }

                        MessageBox.Show(currentLanguage == Language.English ? "Results saved successfully." : "نتایج با موفقیت ذخیره شدند.",
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show((currentLanguage == Language.English ? "Error saving file: " : "خطا در ذخیره فایل: ") + ex.Message,
                            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}

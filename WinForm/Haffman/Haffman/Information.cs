using System;
using System.Drawing;
using System.Windows.Forms;

namespace Huffman
{
    public partial class Information : Form
    {
        private bool isEnglish = true;
        private Label lblInfo;
        private TableLayoutPanel tableLayout;
        private Button languageBtn;
        private Panel contentPanel;
        private PictureBox headerPicture;

        public Information()
        {
            InitializeComponent();
            InitializeUI();
            LoadEnglishText();
            this.MinimumSize = new Size(400, 300);
        }

        private void InitializeUI()
        {
            // تنظیمات اصلی فرم
            this.Text = "Information | اطلاعات";
            this.Size = new Size(600, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            // پنل اصلی با قابلیت اسکرول
            var mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(0),
                AutoScroll = true
            };

            // پنل محتوا (برای محاسبه اندازه صحیح)
            contentPanel = new Panel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(20),
                BackColor = Color.White
            };

            // تصویر هدر
            headerPicture = new PictureBox
            {
                Image = SystemIcons.Information.ToBitmap(),
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(64, 64),
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Margin = new Padding(0, 0, 0, 20)
            };

            // دکمه تغییر زبان
            languageBtn = new Button
            {
                Text = "فارسی / English",
                Anchor = AnchorStyles.Top & /*AnchorStyles.Right &*/ AnchorStyles.Left,
                Size = new Size(120, 40),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(0, 122, 204),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            languageBtn.FlatAppearance.BorderSize = 0;
            languageBtn.Click += (s, e) => ToggleLanguage();

            // جدول اطلاعات پروژه
            tableLayout = new TableLayoutPanel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                ColumnCount = 2,
                RowCount = 3,
                Margin = new Padding(0, 0, 0, 20),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            // ردیف‌های جدول
            AddTableRow("Project Name:", "Huffman Algorithm", 0);
            AddTableRow("Course:", "Algorithm Design", 1);
            AddTableRow("Instructor:", "Rasoul Taghipour", 2);

            // برچسب اطلاعات
            lblInfo = new Label
            {
                AutoSize = true,
                MaximumSize = new Size(0, 0),
                TextAlign = ContentAlignment.TopLeft,
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                Margin = new Padding(0, 0, 0, 20)
            };

            // چینش کنترل‌ها
            contentPanel.Controls.Add(lblInfo);
            contentPanel.Controls.Add(tableLayout);
            contentPanel.Controls.Add(languageBtn);
            contentPanel.Controls.Add(headerPicture);

            // موقعیت‌دهی کنترل‌ها
            PositionControls();

            mainPanel.Controls.Add(contentPanel);
            this.Controls.Add(mainPanel);

            // رویداد تغییر اندازه فرم
            this.Resize += (s, e) => PositionControls();
        }

        private void AddTableRow(string label, string value, int row)
        {
            var lbl = new Label
            {
                Text = label,
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(70, 70, 70),
                Margin = new Padding(0, 5, 0, 5)
            };

            var val = new Label
            {
                Text = value,
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                Margin = new Padding(0, 5, 0, 5)
            };

            tableLayout.Controls.Add(lbl, 0, row);
            tableLayout.Controls.Add(val, 1, row);
        }

        private void PositionControls()
        {
            // محاسبه عرض قابل استفاده
            int usableWidth = this.ClientSize.Width - 40; // 20px padding در هر طرف

            // تنظیم موقعیت و اندازه کنترل‌ها
            headerPicture.Location = new Point(20, 20);

            languageBtn.Location = new Point(
                usableWidth - languageBtn.Width + 20,
                20);

            tableLayout.Location = new Point(20, headerPicture.Bottom + 20);
            tableLayout.Width = usableWidth;

            lblInfo.Location = new Point(20, tableLayout.Bottom + 20);
            lblInfo.Width = usableWidth;

            // محاسبه ارتفاع کل محتوا
            int totalHeight = lblInfo.Bottom + 20;
            contentPanel.Size = new Size(this.ClientSize.Width, totalHeight);
        }

        private void ToggleLanguage()
        {
            isEnglish = !isEnglish;

            if (isEnglish)
                LoadEnglishText();
            else
                LoadPersianText();

            PositionControls();
        }

        private void LoadEnglishText()
        {
            this.RightToLeft = RightToLeft.No;
            this.RightToLeftLayout = false;
            lblInfo.Text = 
@"Huffman coding is a lossless data compression algorithm that assigns variable-length codes to input
characters based on their frequencies. 

Key Features:
i   - Creates optimal prefix codes
ii  - Builds a binary tree structure
iii - More frequent characters get shorter codes
iv  - Works with any type of data

How to use:
1. Enter your text in the input box
2. Click 'Generate Huffman Codes'
3. View character frequencies, codes and the tree visualization
4. Use zoom and pan to explore large trees";

            UpdateTableText(
                "Project Name:", "Huffman Algorithm",
                "Course:", "Algorithm Design",
                "Instructor:", "Rasoul Taghipour");
        }

        private void LoadPersianText()
        {
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            lblInfo.Text = @"کدینگ هافمن یک الگوریتم فشرده‌سازی داده بدون اتلاف است که کدهای با طول متغیر به کاراکترهای 
ورودی بر اساس فراوانی آنها اختصاص می‌دهد.

ویژگی‌های کلیدی:
- ایجاد کدهای پیشوندی بهینه
- ساخت یک درخت دودویی
- کاراکترهای پرتکرار کدهای کوتاه‌تر می‌گیرند
- کار با هر نوع داده‌ای امکان‌پذیر است

راهنمای استفاده:
1. متن خود را در کادر ورودی وارد کنید
2. روی دکمه 'تولید کدهای هافمن' کلیک کنید
3. فرکانس کاراکترها، کدها و نمایش درخت را مشاهده کنید
4. از بزرگنمایی و جابجایی برای بررسی درخت‌های بزرگ استفاده کنید";

            UpdateTableText(
                "نام پروژه:", "الگوریتم هافمن",
                "نام درس:", "طراحی الگوریتم",
                "نام مدرس:", "رسول تقی پور");
        }

        private void UpdateTableText(params string[] texts)
        {
            for (int i = 0; i < texts.Length && i < tableLayout.Controls.Count; i++)
            {
                tableLayout.Controls[i].Text = texts[i];
            }
        }
    }
}
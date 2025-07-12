using System;
using System.Drawing;
using System.Windows.Forms;

namespace KruskalPrimAlgorithms
{
    public partial class InfoForm : Form
    {
        private Panel panelMain;
        private Panel panelInfo;
        private Label lblTitle;
        private Label lblProjectNameTitle;
        private Label lblProjectName;
        private Label lblCourseTitle;
        private Label lblCourse;
        private Label lblInstructorTitle;
        private Label lblInstructor;
        private Label lblDeveloperTitle;
        private Label lblDeveloper;
        private Label lblDescriptionTitle;
        private Label lblDescription;
        private Button btnClose;

        public InfoForm(Color themeColor, int radius, bool isEnglish)
        {
            InitializeComponents(themeColor, radius);
            UpdateLanguage(isEnglish);
        }

        private void InitializeComponents(Color themeColor, int radius)
        {
            // تنظیمات اصلی فرم
            this.Text = "Project Information";
            this.Size = new Size(700, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Icon = SystemIcons.Information;

            // پنل اصلی
            panelMain = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(20)
            };
            this.Controls.Add(panelMain);

            // پنل اطلاعات
            panelInfo = new Panel
            {
                Size = new Size(600, 500),
                Location = new Point(35, 35),
                BackColor = Color.FromArgb(176, 225, 246),
                
            };
            panelMain.Controls.Add(panelInfo);

            // عنوان فرم
            lblTitle = new Label
            {
                Text = "Project Details",
                Location = new Point(20, 20),
                AutoSize = true,
                ForeColor = Color.FromArgb(0,145,255),
                Font = new Font("Segoe UI", 16, FontStyle.Bold)
            };
            panelInfo.Controls.Add(lblTitle);

            // نام پروژه
            lblProjectNameTitle = new Label
            {
                Text = "Project Name:",
                Location = new Point(20, 60),
                AutoSize = true,
                ForeColor = Color.FromArgb(10, 10, 10),
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };
            panelInfo.Controls.Add(lblProjectNameTitle);

            lblProjectName = new Label
            {
                Text = "Kruskal & Prim Algorithms Visualizer",
                Location = new Point(150, 60),
                AutoSize = true,
                ForeColor = Color.FromArgb(10, 10, 10),
                Font = new Font("Segoe UI", 12)
            };
            panelInfo.Controls.Add(lblProjectName);

            // نام درس
            lblCourseTitle = new Label
            {
                Text = "Course:",
                Location = new Point(20, 90),
                AutoSize = true,
                ForeColor = Color.FromArgb(10, 10, 10),
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };
            panelInfo.Controls.Add(lblCourseTitle);

            lblCourse = new Label
            {
                Text = "Algorithm Design",
                Location = new Point(150, 90),
                AutoSize = true,
                ForeColor = Color.FromArgb(10, 10, 10),
                Font = new Font("Segoe UI", 12)
            };
            panelInfo.Controls.Add(lblCourse);

            // نام مدرس
            lblInstructorTitle = new Label
            {
                Text = "Instructor:",
                Location = new Point(20, 120),
                AutoSize = true,
                ForeColor = Color.FromArgb(10, 10, 10),
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };
            panelInfo.Controls.Add(lblInstructorTitle);

            lblInstructor = new Label
            {
                Text = "Rasoul Taghipour",
                Location = new Point(150, 120),
                AutoSize = true,
                ForeColor = Color.FromArgb(10, 10, 10),
                Font = new Font("Segoe UI", 12)
            };
            panelInfo.Controls.Add(lblInstructor);

            // توسعه دهنده
            lblDeveloperTitle = new Label
            {
                Text = "Developer:",
                Location = new Point(20, 150),
                AutoSize = true,
                ForeColor = Color.FromArgb(10, 10, 10),
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };
            panelInfo.Controls.Add(lblDeveloperTitle);

            lblDeveloper = new Label
            {
                Text = "Mehran Ghadirian",
                Location = new Point(150, 150),
                AutoSize = true,
                ForeColor = Color.FromArgb(10, 10, 10),
                Font = new Font("Segoe UI", 12)
            };
            panelInfo.Controls.Add(lblDeveloper);

            // توضیحات
            lblDescriptionTitle = new Label
            {
                Text = "Description:",
                Location = new Point(20, 180),
                AutoSize = true,
                ForeColor = Color.FromArgb(10, 10, 10),
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };
            panelInfo.Controls.Add(lblDescriptionTitle);

            lblDescription = new Label
            {
                Text = "This application demonstrates two important algorithms...",
                Location = new Point(20, 210),
                Size = new Size(550, 200),
                ForeColor = Color.FromArgb(10, 10, 10),
                Font = new Font("Segoe UI", 12)
            };
            panelInfo.Controls.Add(lblDescription);

            // دکمه بستن
            btnClose = new Button
            {
                Text = "Close",
                Location = new Point(250, 430),
                Size = new Size(100, 40),
                BackColor = themeColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnClose.Click += btnClose_Click;
            panelInfo.Controls.Add(btnClose);

            // گرد کردن گوشه ها
            RoundCorners(panelInfo, radius);
            RoundCorners(btnClose, radius);
        }

        private void RoundCorners(Control control, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            if (control is Panel panel)
            {
                panel.Region = new Region(path);
            }
            else if (control is Button button)
            {
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.Region = new Region(path);
            }
        }

        private void UpdateLanguage(bool isEnglish)
        {
            // همان محتوای قبلی برای تغییر زبان
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
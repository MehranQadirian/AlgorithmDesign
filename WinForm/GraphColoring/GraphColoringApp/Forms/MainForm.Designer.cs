using System.Windows.Forms;

namespace GraphColoringApp.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Button btnColor, btnReset, btnSave, btnLoad, btnTheme, btnDeveloper;
        private System.Windows.Forms.CheckBox checkDirected;

        private void InitializeComponent()
        {
            this.btnColor = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnTheme = new System.Windows.Forms.Button();
            this.btnDeveloper = new System.Windows.Forms.Button();
            this.checkDirected = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(76)))), ((int)(((byte)(153)))));
            this.btnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor.Font = new System.Drawing.Font("Sultan Koufi High", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnColor.ForeColor = System.Drawing.Color.Snow;
            this.btnColor.Location = new System.Drawing.Point(21, 12);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(82, 35);
            this.btnColor.TabIndex = 0;
            this.btnColor.Text = "رنگ‌آمیزی";
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.BtnColor_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(76)))), ((int)(((byte)(153)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Sultan Koufi High", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnReset.ForeColor = System.Drawing.Color.Snow;
            this.btnReset.Location = new System.Drawing.Point(121, 12);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(82, 35);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "ریست";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(76)))), ((int)(((byte)(153)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Sultan Koufi High", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSave.ForeColor = System.Drawing.Color.Snow;
            this.btnSave.Location = new System.Drawing.Point(221, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 35);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "ذخیره";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(76)))), ((int)(((byte)(153)))));
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Font = new System.Drawing.Font("Sultan Koufi High", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnLoad.ForeColor = System.Drawing.Color.Snow;
            this.btnLoad.Location = new System.Drawing.Point(321, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(82, 35);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "بارگذاری";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // btnTheme
            // 
            this.btnTheme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(76)))), ((int)(((byte)(153)))));
            this.btnTheme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTheme.Font = new System.Drawing.Font("Sultan Koufi High", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnTheme.ForeColor = System.Drawing.Color.Snow;
            this.btnTheme.Location = new System.Drawing.Point(421, 12);
            this.btnTheme.Name = "btnTheme";
            this.btnTheme.Size = new System.Drawing.Size(82, 35);
            this.btnTheme.TabIndex = 4;
            this.btnTheme.Text = "تغییر تم";
            this.btnTheme.UseVisualStyleBackColor = false;
            this.btnTheme.Click += new System.EventHandler(this.BtnTheme_Click);
            // 
            // btnDeveloper
            // 
            this.btnDeveloper.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(76)))), ((int)(((byte)(153)))));
            this.btnDeveloper.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeveloper.Font = new System.Drawing.Font("Sultan Koufi High", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnDeveloper.ForeColor = System.Drawing.Color.Snow;
            this.btnDeveloper.Location = new System.Drawing.Point(521, 12);
            this.btnDeveloper.Name = "btnDeveloper";
            this.btnDeveloper.Size = new System.Drawing.Size(82, 35);
            this.btnDeveloper.TabIndex = 5;
            this.btnDeveloper.Text = "درباره";
            this.btnDeveloper.UseVisualStyleBackColor = false;
            this.btnDeveloper.Click += new System.EventHandler(this.BtnDeveloper_Click);
            // 
            // checkDirected
            // 
            this.checkDirected.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkDirected.Font = new System.Drawing.Font("Sultan Koufi High", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.checkDirected.Location = new System.Drawing.Point(609, 18);
            this.checkDirected.Name = "checkDirected";
            this.checkDirected.Size = new System.Drawing.Size(104, 24);
            this.checkDirected.TabIndex = 6;
            this.checkDirected.Text = "جهت‌دار";
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("B Nazanin", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.textBox1.HideSelection = false;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBox1.Size = new System.Drawing.Size(224, 632);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "ایجاد راس : کلیک چپ\r\n\r\nایجاد یال بین دو راس : با نگه داشتن شیفت از یک راس به راس " +
    "دیگر کلیک کنید و بکشید\r\n\r\nحذف راس : راست کلیک\r\n\r\nجابجایی : یک راس را گرفته و جاب" +
    "جا کنید\r\n";
            this.textBox1.WordWrap = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(893, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(226, 634);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnColor);
            this.panel2.Controls.Add(this.checkDirected);
            this.panel2.Controls.Add(this.btnDeveloper);
            this.panel2.Controls.Add(this.btnReset);
            this.panel2.Controls.Add(this.btnTheme);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnLoad);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1119, 55);
            this.panel2.TabIndex = 10;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1119, 689);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "رنگ‌آمیزی گراف";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private TextBox textBox1;
        private Panel panel1;
        private Panel panel2;
    }
}

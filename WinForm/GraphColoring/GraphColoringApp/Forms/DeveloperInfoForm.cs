using System;
using System.Windows.Forms;
using GraphColoringApp.Utils;

namespace GraphColoringApp.Forms
{
    public partial class DeveloperInfoForm : Form
    {
        public DeveloperInfoForm()
        {
            InitializeComponent();
            ApplyTheme();
            this.Icon = Properties.Resources.info_icon;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ApplyTheme()
        {
            this.BackColor = ThemeManager.BackgroundColor;
            foreach (Control c in this.Controls)
            {
                c.ForeColor = ThemeManager.TextColor;
                if (c is Button b)
                    b.BackColor = ThemeManager.NodeColor;
            }
        }
    }
}

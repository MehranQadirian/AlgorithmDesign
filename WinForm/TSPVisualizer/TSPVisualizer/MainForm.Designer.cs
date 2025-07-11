using System.Drawing;
using System.Windows.Forms;

namespace TSPVisualizer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.titleLabel = new System.Windows.Forms.Label();
            this.btnRunTSP = new System.Windows.Forms.Button();
            this.btnStartAnimation = new System.Windows.Forms.Button();
            this.btnStopAnimation = new System.Windows.Forms.Button();
            this.cmbAlgorithm = new System.Windows.Forms.ComboBox();
            this.lblPathLength = new System.Windows.Forms.Label();
            this.lblCityCount = new System.Windows.Forms.Label();
            this.lblTotalDistance = new System.Windows.Forms.Label();
            this.lstPath = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.White;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.titleLabel.Location = new System.Drawing.Point(7, 7);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(215, 41);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "TSP Visualizer";
            // 
            // btnRunTSP
            // 
            this.btnRunTSP.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnRunTSP.FlatAppearance.BorderSize = 0;
            this.btnRunTSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunTSP.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnRunTSP.ForeColor = System.Drawing.Color.White;
            this.btnRunTSP.Location = new System.Drawing.Point(20, 101);
            this.btnRunTSP.Name = "btnRunTSP";
            this.btnRunTSP.Size = new System.Drawing.Size(130, 35);
            this.btnRunTSP.TabIndex = 1;
            this.btnRunTSP.Text = "▶️ اجرا الگوریتم";
            this.btnRunTSP.UseVisualStyleBackColor = false;
            // 
            // btnStartAnimation
            // 
            this.btnStartAnimation.BackColor = System.Drawing.Color.SteelBlue;
            this.btnStartAnimation.FlatAppearance.BorderSize = 0;
            this.btnStartAnimation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartAnimation.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnStartAnimation.ForeColor = System.Drawing.Color.White;
            this.btnStartAnimation.Location = new System.Drawing.Point(160, 101);
            this.btnStartAnimation.Name = "btnStartAnimation";
            this.btnStartAnimation.Size = new System.Drawing.Size(140, 35);
            this.btnStartAnimation.TabIndex = 2;
            this.btnStartAnimation.Text = "🎬 شروع انیمیشن";
            this.btnStartAnimation.UseVisualStyleBackColor = false;
            // 
            // btnStopAnimation
            // 
            this.btnStopAnimation.BackColor = System.Drawing.Color.IndianRed;
            this.btnStopAnimation.FlatAppearance.BorderSize = 0;
            this.btnStopAnimation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopAnimation.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnStopAnimation.ForeColor = System.Drawing.Color.White;
            this.btnStopAnimation.Location = new System.Drawing.Point(310, 101);
            this.btnStopAnimation.Name = "btnStopAnimation";
            this.btnStopAnimation.Size = new System.Drawing.Size(140, 35);
            this.btnStopAnimation.TabIndex = 3;
            this.btnStopAnimation.Text = "⏹️ توقف انیمیشن";
            this.btnStopAnimation.UseVisualStyleBackColor = false;
            // 
            // cmbAlgorithm
            // 
            this.cmbAlgorithm.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbAlgorithm.Location = new System.Drawing.Point(470, 106);
            this.cmbAlgorithm.Name = "cmbAlgorithm";
            this.cmbAlgorithm.Size = new System.Drawing.Size(200, 31);
            this.cmbAlgorithm.TabIndex = 4;
            // 
            // lblPathLength
            // 
            this.lblPathLength.AutoSize = true;
            this.lblPathLength.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPathLength.ForeColor = System.Drawing.Color.DimGray;
            this.lblPathLength.Location = new System.Drawing.Point(817, 451);
            this.lblPathLength.Name = "lblPathLength";
            this.lblPathLength.Size = new System.Drawing.Size(103, 23);
            this.lblPathLength.TabIndex = 5;
            this.lblPathLength.Text = "طول مسیر: 0";
            // 
            // lblCityCount
            // 
            this.lblCityCount.AutoSize = true;
            this.lblCityCount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCityCount.ForeColor = System.Drawing.Color.DarkGray;
            this.lblCityCount.Location = new System.Drawing.Point(807, 476);
            this.lblCityCount.Name = "lblCityCount";
            this.lblCityCount.Size = new System.Drawing.Size(113, 23);
            this.lblCityCount.TabIndex = 6;
            this.lblCityCount.Text = "تعداد شهرها: 0";
            // 
            // lblTotalDistance
            // 
            this.lblTotalDistance.AutoSize = true;
            this.lblTotalDistance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTotalDistance.ForeColor = System.Drawing.Color.DarkGray;
            this.lblTotalDistance.Location = new System.Drawing.Point(824, 501);
            this.lblTotalDistance.Name = "lblTotalDistance";
            this.lblTotalDistance.Size = new System.Drawing.Size(96, 23);
            this.lblTotalDistance.TabIndex = 7;
            this.lblTotalDistance.Text = "فاصله کل: 0";
            // 
            // lstPath
            // 
            this.lstPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstPath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstPath.ItemHeight = 20;
            this.lstPath.Location = new System.Drawing.Point(700, 106);
            this.lstPath.Name = "lstPath";
            this.lstPath.Size = new System.Drawing.Size(220, 342);
            this.lstPath.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.panel1.Location = new System.Drawing.Point(3, 140);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 470);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.panel2.Location = new System.Drawing.Point(3, 140);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(691, 5);
            this.panel2.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.panel3.Location = new System.Drawing.Point(689, 140);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(5, 470);
            this.panel3.TabIndex = 11;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.panel4.Location = new System.Drawing.Point(3, 605);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(691, 5);
            this.panel4.TabIndex = 12;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.titleLabel);
            this.panel5.Location = new System.Drawing.Point(0, 51);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(928, 49);
            this.panel5.TabIndex = 13;
            // 
            // MainForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(928, 613);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnRunTSP);
            this.Controls.Add(this.btnStartAnimation);
            this.Controls.Add(this.btnStopAnimation);
            this.Controls.Add(this.cmbAlgorithm);
            this.Controls.Add(this.lblCityCount);
            this.Controls.Add(this.lblTotalDistance);
            this.Controls.Add(this.lblPathLength);
            this.Controls.Add(this.lstPath);
            this.Controls.Add(this.panel5);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "TSP Visualizer";
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRunTSP;
        private System.Windows.Forms.Button btnStartAnimation;
        private System.Windows.Forms.Button btnStopAnimation;
        private System.Windows.Forms.ComboBox cmbAlgorithm;
        private System.Windows.Forms.Label lblCityCount;
        private System.Windows.Forms.Label lblTotalDistance;
        private System.Windows.Forms.Label lblPathLength;
        private System.Windows.Forms.ListBox lstPath;
        private System.Windows.Forms.Label titleLabel;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
    }
}

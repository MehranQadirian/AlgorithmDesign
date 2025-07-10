namespace SubsetSumWinForm
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblInput = new System.Windows.Forms.Label();
            this.txtNumbers = new System.Windows.Forms.TextBox();
            this.lblTarget = new System.Windows.Forms.Label();
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.btnFindSubsets = new System.Windows.Forms.Button();
            this.lstResults = new System.Windows.Forms.ListBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnSaveResults = new System.Windows.Forms.Button();
            this.comboLanguage = new System.Windows.Forms.ComboBox();
            this.comboTheme = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblLang = new System.Windows.Forms.Label();
            this.lblTheme = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInput.ForeColor = System.Drawing.Color.Snow;
            this.lblInput.Location = new System.Drawing.Point(12, 91);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(282, 17);
            this.lblInput.TabIndex = 2;
            this.lblInput.Text = "Enter numbers separated by commas:";
            // 
            // txtNumbers
            // 
            this.txtNumbers.BackColor = System.Drawing.Color.ForestGreen;
            this.txtNumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumbers.ForeColor = System.Drawing.Color.Snow;
            this.txtNumbers.Location = new System.Drawing.Point(12, 111);
            this.txtNumbers.Name = "txtNumbers";
            this.txtNumbers.Size = new System.Drawing.Size(381, 27);
            this.txtNumbers.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtNumbers, "Enter numbers separated by commas, e.g. 1, 2, 3, 4");
            // 
            // lblTarget
            // 
            this.lblTarget.AutoSize = true;
            this.lblTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTarget.ForeColor = System.Drawing.Color.Snow;
            this.lblTarget.Location = new System.Drawing.Point(12, 151);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(134, 17);
            this.lblTarget.TabIndex = 4;
            this.lblTarget.Text = "Enter target sum:";
            // 
            // txtTarget
            // 
            this.txtTarget.BackColor = System.Drawing.Color.ForestGreen;
            this.txtTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTarget.ForeColor = System.Drawing.Color.Snow;
            this.txtTarget.Location = new System.Drawing.Point(12, 171);
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(150, 27);
            this.txtTarget.TabIndex = 5;
            this.toolTip1.SetToolTip(this.txtTarget, "Enter the target sum (non-negative integer)");
            // 
            // btnFindSubsets
            // 
            this.btnFindSubsets.BackColor = System.Drawing.Color.ForestGreen;
            this.btnFindSubsets.FlatAppearance.BorderSize = 0;
            this.btnFindSubsets.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFindSubsets.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindSubsets.ForeColor = System.Drawing.Color.White;
            this.btnFindSubsets.Location = new System.Drawing.Point(12, 211);
            this.btnFindSubsets.Name = "btnFindSubsets";
            this.btnFindSubsets.Size = new System.Drawing.Size(170, 30);
            this.btnFindSubsets.TabIndex = 6;
            this.btnFindSubsets.Text = "Find Subsets";
            this.toolTip1.SetToolTip(this.btnFindSubsets, "Click to find all subsets that sum to the target");
            this.btnFindSubsets.UseVisualStyleBackColor = false;
            this.btnFindSubsets.Click += new System.EventHandler(this.btnFindSubsets_Click);
            // 
            // lstResults
            // 
            this.lstResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstResults.FormattingEnabled = true;
            this.lstResults.ItemHeight = 18;
            this.lstResults.Location = new System.Drawing.Point(12, 311);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(381, 166);
            this.lstResults.TabIndex = 10;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 501);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            this.lblStatus.TabIndex = 11;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.ForestGreen;
            this.btnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(223, 211);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(170, 30);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear All";
            this.toolTip1.SetToolTip(this.btnClear, "Clear all input fields and results");
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.ForestGreen;
            this.btnHelp.FlatAppearance.BorderSize = 0;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.ForeColor = System.Drawing.Color.White;
            this.btnHelp.Location = new System.Drawing.Point(12, 261);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(170, 30);
            this.btnHelp.TabIndex = 9;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnSaveResults
            // 
            this.btnSaveResults.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSaveResults.FlatAppearance.BorderSize = 0;
            this.btnSaveResults.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveResults.ForeColor = System.Drawing.Color.White;
            this.btnSaveResults.Location = new System.Drawing.Point(223, 261);
            this.btnSaveResults.Name = "btnSaveResults";
            this.btnSaveResults.Size = new System.Drawing.Size(170, 30);
            this.btnSaveResults.TabIndex = 8;
            this.btnSaveResults.Text = "Save Results...";
            this.toolTip1.SetToolTip(this.btnSaveResults, "Save the found subsets to a text file");
            this.btnSaveResults.UseVisualStyleBackColor = false;
            this.btnSaveResults.Click += new System.EventHandler(this.btnSaveResults_Click);
            // 
            // comboLanguage
            // 
            this.comboLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboLanguage.FormattingEnabled = true;
            this.comboLanguage.Location = new System.Drawing.Point(117, 13);
            this.comboLanguage.Name = "comboLanguage";
            this.comboLanguage.Size = new System.Drawing.Size(100, 28);
            this.comboLanguage.TabIndex = 0;
            // 
            // comboTheme
            // 
            this.comboTheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTheme.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboTheme.FormattingEnabled = true;
            this.comboTheme.Location = new System.Drawing.Point(117, 52);
            this.comboTheme.Name = "comboTheme";
            this.comboTheme.Size = new System.Drawing.Size(100, 28);
            this.comboTheme.TabIndex = 1;
            this.comboTheme.SelectedIndexChanged += new System.EventHandler(this.comboTheme_SelectedIndexChanged);
            // 
            // lblLang
            // 
            this.lblLang.AutoSize = true;
            this.lblLang.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLang.ForeColor = System.Drawing.Color.Snow;
            this.lblLang.Location = new System.Drawing.Point(12, 19);
            this.lblLang.Name = "lblLang";
            this.lblLang.Size = new System.Drawing.Size(90, 17);
            this.lblLang.TabIndex = 12;
            this.lblLang.Text = "Language :";
            // 
            // lblTheme
            // 
            this.lblTheme.AutoSize = true;
            this.lblTheme.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTheme.ForeColor = System.Drawing.Color.Snow;
            this.lblTheme.Location = new System.Drawing.Point(12, 58);
            this.lblTheme.Name = "lblTheme";
            this.lblTheme.Size = new System.Drawing.Size(67, 17);
            this.lblTheme.TabIndex = 13;
            this.lblTheme.Text = "Theme :";
            // 
            // Form1
            // 
            this.AcceptButton = this.btnFindSubsets;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.CancelButton = this.btnClear;
            this.ClientSize = new System.Drawing.Size(405, 540);
            this.Controls.Add(this.lblLang);
            this.Controls.Add(this.lblTheme);
            this.Controls.Add(this.comboLanguage);
            this.Controls.Add(this.comboTheme);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.txtNumbers);
            this.Controls.Add(this.lblTarget);
            this.Controls.Add(this.txtTarget);
            this.Controls.Add(this.btnFindSubsets);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSaveResults);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.lstResults);
            this.Controls.Add(this.lblStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Subset Sum Finder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.TextBox txtNumbers;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.TextBox txtTarget;
        private System.Windows.Forms.Button btnFindSubsets;
        private System.Windows.Forms.ListBox lstResults;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnSaveResults;
        private System.Windows.Forms.ComboBox comboLanguage;
        private System.Windows.Forms.ComboBox comboTheme;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblLang;
        private System.Windows.Forms.Label lblTheme;
    }
}

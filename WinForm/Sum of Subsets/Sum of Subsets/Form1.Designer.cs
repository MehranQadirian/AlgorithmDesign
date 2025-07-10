namespace Sum_of_Subsets
{
    partial class MainForm
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.number1TextBox = new System.Windows.Forms.TextBox();
            this.number2TextBox = new System.Windows.Forms.TextBox();
            this.multiplyButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.historyLabel = new System.Windows.Forms.Label();
            this.historyListBox = new System.Windows.Forms.ListBox();
            this.clearHistoryButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.btnOpenLinkedin = new System.Windows.Forms.Button();
            this.btnOpenTelegram = new System.Windows.Forms.Button();
            this.btnOpenGitHub = new System.Windows.Forms.Button();
            this.roundedPictureBox1 = new Sum_of_Subsets.RoundedPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.roundedPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // number1TextBox
            // 
            this.number1TextBox.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.number1TextBox.Location = new System.Drawing.Point(33, 100);
            this.number1TextBox.Multiline = true;
            this.number1TextBox.Name = "number1TextBox";
            this.number1TextBox.Size = new System.Drawing.Size(376, 40);
            this.number1TextBox.TabIndex = 0;
            this.number1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.number1TextBox.Enter += new System.EventHandler(this.HandleTextBoxEnter);
            this.number1TextBox.Leave += new System.EventHandler(this.HandleTextBoxLeave);
            // 
            // number2TextBox
            // 
            this.number2TextBox.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.number2TextBox.Location = new System.Drawing.Point(33, 160);
            this.number2TextBox.Multiline = true;
            this.number2TextBox.Name = "number2TextBox";
            this.number2TextBox.Size = new System.Drawing.Size(376, 40);
            this.number2TextBox.TabIndex = 1;
            this.number2TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.number2TextBox.Enter += new System.EventHandler(this.HandleTextBoxEnter);
            this.number2TextBox.Leave += new System.EventHandler(this.HandleTextBoxLeave);
            // 
            // multiplyButton
            // 
            this.multiplyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.multiplyButton.FlatAppearance.BorderSize = 0;
            this.multiplyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.multiplyButton.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.multiplyButton.ForeColor = System.Drawing.Color.White;
            this.multiplyButton.Location = new System.Drawing.Point(33, 220);
            this.multiplyButton.Name = "multiplyButton";
            this.multiplyButton.Size = new System.Drawing.Size(150, 50);
            this.multiplyButton.TabIndex = 2;
            this.multiplyButton.Text = "ضرب";
            this.multiplyButton.UseVisualStyleBackColor = false;
            this.multiplyButton.Click += new System.EventHandler(this.multiplyButton_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultLabel.Location = new System.Drawing.Point(29, 291);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(74, 24);
            this.resultLabel.TabIndex = 3;
            this.resultLabel.Text = "نتیجه: ";
            // 
            // clearButton
            // 
            this.clearButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.clearButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.clearButton.FlatAppearance.BorderSize = 0;
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearButton.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.ForeColor = System.Drawing.Color.White;
            this.clearButton.Location = new System.Drawing.Point(279, 220);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(130, 50);
            this.clearButton.TabIndex = 4;
            this.clearButton.Text = "پاک کردن";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // historyLabel
            // 
            this.historyLabel.AutoSize = true;
            this.historyLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.historyLabel.Location = new System.Drawing.Point(450, 70);
            this.historyLabel.Name = "historyLabel";
            this.historyLabel.Size = new System.Drawing.Size(187, 24);
            this.historyLabel.TabIndex = 5;
            this.historyLabel.Text = "تاریخچه عملیات ها";
            // 
            // historyListBox
            // 
            this.historyListBox.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.historyListBox.FormattingEnabled = true;
            this.historyListBox.ItemHeight = 21;
            this.historyListBox.Location = new System.Drawing.Point(450, 100);
            this.historyListBox.Name = "historyListBox";
            this.historyListBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.historyListBox.Size = new System.Drawing.Size(497, 466);
            this.historyListBox.TabIndex = 6;
            // 
            // clearHistoryButton
            // 
            this.clearHistoryButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.clearHistoryButton.FlatAppearance.BorderSize = 0;
            this.clearHistoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearHistoryButton.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearHistoryButton.ForeColor = System.Drawing.Color.White;
            this.clearHistoryButton.Location = new System.Drawing.Point(450, 584);
            this.clearHistoryButton.Name = "clearHistoryButton";
            this.clearHistoryButton.Size = new System.Drawing.Size(497, 40);
            this.clearHistoryButton.TabIndex = 7;
            this.clearHistoryButton.Text = "پاک کردن تاریخچه";
            this.clearHistoryButton.UseVisualStyleBackColor = false;
            this.clearHistoryButton.Click += new System.EventHandler(this.clearHistoryButton_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.titleLabel.Location = new System.Drawing.Point(27, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(327, 36);
            this.titleLabel.TabIndex = 8;
            this.titleLabel.Text = "ضرب کننده اعداد بزرگ";
            // 
            // btnOpenLinkedin
            // 
            this.btnOpenLinkedin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(119)))), ((int)(((byte)(181)))));
            this.btnOpenLinkedin.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOpenLinkedin.FlatAppearance.BorderSize = 0;
            this.btnOpenLinkedin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenLinkedin.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenLinkedin.ForeColor = System.Drawing.Color.White;
            this.btnOpenLinkedin.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOpenLinkedin.ImageKey = "(none)";
            this.btnOpenLinkedin.Location = new System.Drawing.Point(12, 560);
            this.btnOpenLinkedin.Name = "btnOpenLinkedin";
            this.btnOpenLinkedin.Size = new System.Drawing.Size(191, 62);
            this.btnOpenLinkedin.TabIndex = 4;
            this.btnOpenLinkedin.Text = "Linkedin";
            this.btnOpenLinkedin.UseVisualStyleBackColor = false;
            this.btnOpenLinkedin.Click += new System.EventHandler(this.btnOpenLinkedin_Click);
            // 
            // btnOpenTelegram
            // 
            this.btnOpenTelegram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(164)))), ((int)(((byte)(226)))));
            this.btnOpenTelegram.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOpenTelegram.FlatAppearance.BorderSize = 0;
            this.btnOpenTelegram.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenTelegram.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenTelegram.ForeColor = System.Drawing.Color.White;
            this.btnOpenTelegram.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOpenTelegram.ImageKey = "(none)";
            this.btnOpenTelegram.Location = new System.Drawing.Point(12, 492);
            this.btnOpenTelegram.Name = "btnOpenTelegram";
            this.btnOpenTelegram.Size = new System.Drawing.Size(191, 62);
            this.btnOpenTelegram.TabIndex = 4;
            this.btnOpenTelegram.Text = "Telegram";
            this.btnOpenTelegram.UseVisualStyleBackColor = false;
            this.btnOpenTelegram.Click += new System.EventHandler(this.btnOpenTelegram_Click);
            // 
            // btnOpenGitHub
            // 
            this.btnOpenGitHub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnOpenGitHub.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOpenGitHub.FlatAppearance.BorderSize = 0;
            this.btnOpenGitHub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenGitHub.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenGitHub.ForeColor = System.Drawing.Color.White;
            this.btnOpenGitHub.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOpenGitHub.ImageKey = "(none)";
            this.btnOpenGitHub.Location = new System.Drawing.Point(12, 424);
            this.btnOpenGitHub.Name = "btnOpenGitHub";
            this.btnOpenGitHub.Size = new System.Drawing.Size(191, 62);
            this.btnOpenGitHub.TabIndex = 4;
            this.btnOpenGitHub.Text = "GitHub";
            this.btnOpenGitHub.UseVisualStyleBackColor = false;
            this.btnOpenGitHub.Click += new System.EventHandler(this.btnOpenGitHub_Click);
            // 
            // roundedPictureBox1
            // 
            this.roundedPictureBox1.CornerRadius = 90;
            this.roundedPictureBox1.Image = global::Sum_of_Subsets.Properties.Resources._158446870;
            this.roundedPictureBox1.Location = new System.Drawing.Point(228, 422);
            this.roundedPictureBox1.Name = "roundedPictureBox1";
            this.roundedPictureBox1.Size = new System.Drawing.Size(200, 200);
            this.roundedPictureBox1.TabIndex = 9;
            this.roundedPictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AcceptButton = this.multiplyButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.clearButton;
            this.ClientSize = new System.Drawing.Size(992, 665);
            this.Controls.Add(this.roundedPictureBox1);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.clearHistoryButton);
            this.Controls.Add(this.historyListBox);
            this.Controls.Add(this.historyLabel);
            this.Controls.Add(this.btnOpenLinkedin);
            this.Controls.Add(this.btnOpenTelegram);
            this.Controls.Add(this.btnOpenGitHub);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.multiplyButton);
            this.Controls.Add(this.number2TextBox);
            this.Controls.Add(this.number1TextBox);
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ضرب اعداد بزرگ";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.roundedPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.TextBox number1TextBox;
        private System.Windows.Forms.TextBox number2TextBox;
        private System.Windows.Forms.Button multiplyButton;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label historyLabel;
        private System.Windows.Forms.ListBox historyListBox;
        private System.Windows.Forms.Button clearHistoryButton;
        private System.Windows.Forms.Label titleLabel;
        #endregion

        private RoundedPictureBox roundedPictureBox1;
        private System.Windows.Forms.Button btnOpenGitHub;
        private System.Windows.Forms.Button btnOpenTelegram;
        private System.Windows.Forms.Button btnOpenLinkedin;
    }
}


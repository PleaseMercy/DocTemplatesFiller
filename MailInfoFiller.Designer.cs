namespace DocTemplatesFiller
{
    partial class MailInfoFiller
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
            this.mailToTextBox = new System.Windows.Forms.TextBox();
            this.subjectTextBox = new System.Windows.Forms.TextBox();
            this.mailTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.OkBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mailToTextBox
            // 
            this.mailToTextBox.Location = new System.Drawing.Point(161, 50);
            this.mailToTextBox.Name = "mailToTextBox";
            this.mailToTextBox.Size = new System.Drawing.Size(509, 20);
            this.mailToTextBox.TabIndex = 0;
            // 
            // subjectTextBox
            // 
            this.subjectTextBox.Location = new System.Drawing.Point(161, 85);
            this.subjectTextBox.Name = "subjectTextBox";
            this.subjectTextBox.Size = new System.Drawing.Size(509, 20);
            this.subjectTextBox.TabIndex = 1;
            // 
            // mailTextBox
            // 
            this.mailTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mailTextBox.Location = new System.Drawing.Point(161, 126);
            this.mailTextBox.Multiline = true;
            this.mailTextBox.Name = "mailTextBox";
            this.mailTextBox.Size = new System.Drawing.Size(509, 193);
            this.mailTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15F);
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 48);
            this.label1.TabIndex = 3;
            this.label1.Text = "Кому \r\n(адрес почты)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Тема письма";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Текст";
            // 
            // OkBtn
            // 
            this.OkBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OkBtn.Location = new System.Drawing.Point(171, 332);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(150, 25);
            this.OkBtn.TabIndex = 6;
            this.OkBtn.Text = "Отправить";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CancelBtn.Location = new System.Drawing.Point(504, 332);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(150, 25);
            this.CancelBtn.TabIndex = 7;
            this.CancelBtn.Text = "Отмена";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // MailInfoFiller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 381);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OkBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mailTextBox);
            this.Controls.Add(this.subjectTextBox);
            this.Controls.Add(this.mailToTextBox);
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "MailInfoFiller";
            this.Text = "MailInfoFiller";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.Button CancelBtn;
        internal System.Windows.Forms.TextBox mailToTextBox;
        internal System.Windows.Forms.TextBox subjectTextBox;
        internal System.Windows.Forms.TextBox mailTextBox;
    }
}
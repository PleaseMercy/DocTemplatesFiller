namespace DocTemplatesFiller
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
            this.filePickerBtn = new System.Windows.Forms.Button();
            this.dgvTemplates = new System.Windows.Forms.DataGridView();
            this.TemplateNames = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TemplateValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveBtn = new System.Windows.Forms.Button();
            this.mailSendBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTemplates)).BeginInit();
            this.SuspendLayout();
            // 
            // filePickerBtn
            // 
            this.filePickerBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.filePickerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.filePickerBtn.Location = new System.Drawing.Point(65, 424);
            this.filePickerBtn.Name = "filePickerBtn";
            this.filePickerBtn.Size = new System.Drawing.Size(150, 25);
            this.filePickerBtn.TabIndex = 0;
            this.filePickerBtn.Text = "Выбрать шаблон";
            this.filePickerBtn.UseVisualStyleBackColor = true;
            this.filePickerBtn.Click += new System.EventHandler(this.filePicker_Click);
            // 
            // dgvTemplates
            // 
            this.dgvTemplates.AllowUserToAddRows = false;
            this.dgvTemplates.AllowUserToDeleteRows = false;
            this.dgvTemplates.AllowUserToOrderColumns = true;
            this.dgvTemplates.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTemplates.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvTemplates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTemplates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TemplateNames,
            this.TemplateValue});
            this.dgvTemplates.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvTemplates.Location = new System.Drawing.Point(0, 0);
            this.dgvTemplates.Name = "dgvTemplates";
            this.dgvTemplates.Size = new System.Drawing.Size(800, 418);
            this.dgvTemplates.TabIndex = 1;
            this.dgvTemplates.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvTemplates_RowsAdded);
            this.dgvTemplates.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvTemplates_RowsRemoved);
            // 
            // TemplateNames
            // 
            this.TemplateNames.HeaderText = "Поле шаблона";
            this.TemplateNames.Name = "TemplateNames";
            this.TemplateNames.ReadOnly = true;
            // 
            // TemplateValue
            // 
            this.TemplateValue.HeaderText = "Значение для заполнения";
            this.TemplateValue.Name = "TemplateValue";
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.saveBtn.Enabled = false;
            this.saveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveBtn.Location = new System.Drawing.Point(315, 424);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(150, 25);
            this.saveBtn.TabIndex = 2;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // mailSendBtn
            // 
            this.mailSendBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mailSendBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mailSendBtn.Location = new System.Drawing.Point(549, 424);
            this.mailSendBtn.Name = "mailSendBtn";
            this.mailSendBtn.Size = new System.Drawing.Size(150, 25);
            this.mailSendBtn.TabIndex = 3;
            this.mailSendBtn.Text = "Отправить по почте";
            this.mailSendBtn.UseVisualStyleBackColor = true;
            this.mailSendBtn.Click += new System.EventHandler(this.mailSendBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 461);
            this.Controls.Add(this.mailSendBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.dgvTemplates);
            this.Controls.Add(this.filePickerBtn);
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "MainForm";
            this.Text = "Шаблоны";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTemplates)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button filePickerBtn;
        internal System.Windows.Forms.DataGridView dgvTemplates;
        private System.Windows.Forms.DataGridViewTextBoxColumn TemplateNames;
        private System.Windows.Forms.DataGridViewTextBoxColumn TemplateValue;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button mailSendBtn;
    }
}


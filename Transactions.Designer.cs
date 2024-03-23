namespace CourseWork
{
    partial class Transactions
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Transactions));
            this.transactionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bankDataSet = new CourseWork.BankDataSet();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SenderIdTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Amount1TextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ClearFiltersButton = new System.Windows.Forms.Button();
            this.TransactionIdTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.RecipientIdTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Amount2TextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.GenerateReport = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionsTableAdapter = new CourseWork.BankDataSetTableAdapters.TransactionsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // transactionsBindingSource
            // 
            this.transactionsBindingSource.DataMember = "Transactions";
            this.transactionsBindingSource.DataSource = this.bankDataSet;
            // 
            // bankDataSet
            // 
            this.bankDataSet.DataSetName = "BankDataSet";
            this.bankDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(817, 281);
            this.dataGridView1.TabIndex = 52;
            // 
            // SenderIdTextBox
            // 
            this.SenderIdTextBox.Location = new System.Drawing.Point(188, 395);
            this.SenderIdTextBox.Name = "SenderIdTextBox";
            this.SenderIdTextBox.Size = new System.Drawing.Size(100, 20);
            this.SenderIdTextBox.TabIndex = 55;
            this.SenderIdTextBox.TextChanged += new System.EventHandler(this.SenderIdTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 379);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 56;
            this.label2.Text = "ID Відправника";
            // 
            // Amount1TextBox
            // 
            this.Amount1TextBox.Location = new System.Drawing.Point(436, 395);
            this.Amount1TextBox.Name = "Amount1TextBox";
            this.Amount1TextBox.Size = new System.Drawing.Size(40, 20);
            this.Amount1TextBox.TabIndex = 62;
            this.Amount1TextBox.TextChanged += new System.EventHandler(this.Amount1TextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(470, 379);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 63;
            this.label5.Text = "Сума";
            // 
            // ClearFiltersButton
            // 
            this.ClearFiltersButton.Image = ((System.Drawing.Image)(resources.GetObject("ClearFiltersButton.Image")));
            this.ClearFiltersButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ClearFiltersButton.Location = new System.Drawing.Point(363, 440);
            this.ClearFiltersButton.Name = "ClearFiltersButton";
            this.ClearFiltersButton.Size = new System.Drawing.Size(129, 32);
            this.ClearFiltersButton.TabIndex = 65;
            this.ClearFiltersButton.Text = "Скинути фільтри";
            this.ClearFiltersButton.UseVisualStyleBackColor = true;
            this.ClearFiltersButton.Click += new System.EventHandler(this.ClearFiltersButton_Click);
            // 
            // TransactionIdTextBox
            // 
            this.TransactionIdTextBox.Location = new System.Drawing.Point(188, 329);
            this.TransactionIdTextBox.Name = "TransactionIdTextBox";
            this.TransactionIdTextBox.Size = new System.Drawing.Size(100, 20);
            this.TransactionIdTextBox.TabIndex = 53;
            this.TransactionIdTextBox.TextChanged += new System.EventHandler(this.TransactionIdTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(185, 313);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "ID";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(435, 329);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(101, 20);
            this.dateTimePicker2.TabIndex = 70;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(432, 314);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 69;
            this.label6.Text = "Кінц. Дата";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(308, 314);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 68;
            this.label3.Text = "Поч. Дата";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(312, 329);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(101, 20);
            this.dateTimePicker1.TabIndex = 67;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(309, 379);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 72;
            this.label4.Text = "ID Отримувача";
            // 
            // RecipientIdTextBox
            // 
            this.RecipientIdTextBox.Location = new System.Drawing.Point(312, 395);
            this.RecipientIdTextBox.Name = "RecipientIdTextBox";
            this.RecipientIdTextBox.Size = new System.Drawing.Size(101, 20);
            this.RecipientIdTextBox.TabIndex = 71;
            this.RecipientIdTextBox.TextChanged += new System.EventHandler(this.RecipientIdTextBox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(419, 332);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(10, 13);
            this.label8.TabIndex = 73;
            this.label8.Text = "-";
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Location = new System.Drawing.Point(557, 329);
            this.DescriptionTextBox.Multiline = true;
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(101, 20);
            this.DescriptionTextBox.TabIndex = 60;
            this.DescriptionTextBox.TextChanged += new System.EventHandler(this.DescriptionTextBox_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(557, 313);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 61;
            this.label9.Text = "Опис";
            // 
            // Amount2TextBox
            // 
            this.Amount2TextBox.Location = new System.Drawing.Point(495, 395);
            this.Amount2TextBox.Name = "Amount2TextBox";
            this.Amount2TextBox.Size = new System.Drawing.Size(41, 20);
            this.Amount2TextBox.TabIndex = 74;
            this.Amount2TextBox.TextChanged += new System.EventHandler(this.Amount2TextBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(483, 398);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(10, 13);
            this.label7.TabIndex = 75;
            this.label7.Text = "-";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GenerateReport});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(841, 24);
            this.menuStrip1.TabIndex = 76;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // GenerateReport
            // 
            this.GenerateReport.Name = "GenerateReport";
            this.GenerateReport.Size = new System.Drawing.Size(109, 20);
            this.GenerateReport.Text = "Згенерувати звіт";
            this.GenerateReport.Click += new System.EventHandler(this.GenerateReport_Click);
            // 
            // transactionsTableAdapter
            // 
            this.transactionsTableAdapter.ClearBeforeFill = true;
            // 
            // Transactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 477);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Amount2TextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.RecipientIdTextBox);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.ClearFiltersButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Amount1TextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SenderIdTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TransactionIdTextBox);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Transactions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Транзакції";
            this.Load += new System.EventHandler(this.Transactions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.transactionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem GenerateReport;

        private System.Windows.Forms.TextBox DescriptionTextBox;

        private System.Windows.Forms.TextBox RecipientIdTextBox;

        private System.Windows.Forms.TextBox SenderIdTextBox;

        private System.Windows.Forms.TextBox TransactionIdTextBox;

        private System.Windows.Forms.Label label8;

        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox Amount1TextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button ClearFiltersButton;
        private System.Windows.Forms.TextBox Amount2TextBox;
        private System.Windows.Forms.Label label1;
        private BankDataSet bankDataSet;
        private System.Windows.Forms.BindingSource transactionsBindingSource;
        private BankDataSetTableAdapters.TransactionsTableAdapter transactionsTableAdapter;
    }
}
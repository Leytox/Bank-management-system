namespace CourseWork
{
    partial class CreateTransaction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateTransaction));
            this.sourceAccountComboBox = new System.Windows.Forms.ComboBox();
            this.recipientAccountNumberTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.transferButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.AccountExistsLabel = new System.Windows.Forms.Label();
            this.EnoughMoneyLabel = new System.Windows.Forms.Label();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.SelectRecipientButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sourceAccountComboBox
            // 
            this.sourceAccountComboBox.FormattingEnabled = true;
            this.sourceAccountComboBox.Location = new System.Drawing.Point(121, 74);
            this.sourceAccountComboBox.Name = "sourceAccountComboBox";
            this.sourceAccountComboBox.Size = new System.Drawing.Size(100, 21);
            this.sourceAccountComboBox.TabIndex = 0;
            this.sourceAccountComboBox.SelectedIndexChanged += new System.EventHandler(this.sourceAccountComboBox_SelectedIndexChanged);
            // 
            // recipientAccountNumberTextBox
            // 
            this.recipientAccountNumberTextBox.Location = new System.Drawing.Point(121, 144);
            this.recipientAccountNumberTextBox.Name = "recipientAccountNumberTextBox";
            this.recipientAccountNumberTextBox.Size = new System.Drawing.Size(100, 20);
            this.recipientAccountNumberTextBox.TabIndex = 1;
            this.recipientAccountNumberTextBox.TextChanged += new System.EventHandler(this.recipientAccountNumberTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Створення Платежу";
            // 
            // transferButton
            // 
            this.transferButton.Image = ((System.Drawing.Image)(resources.GetObject("transferButton.Image")));
            this.transferButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.transferButton.Location = new System.Drawing.Point(121, 262);
            this.transferButton.Name = "transferButton";
            this.transferButton.Size = new System.Drawing.Size(98, 27);
            this.transferButton.TabIndex = 4;
            this.transferButton.Text = "Відправити";
            this.transferButton.UseVisualStyleBackColor = true;
            this.transferButton.Click += new System.EventHandler(this.transferButton_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(145, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Рахунок";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(137, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Отримувач";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(148, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Сума";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(121, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "Баланс:";
            this.label5.Visible = false;
            // 
            // AccountExistsLabel
            // 
            this.AccountExistsLabel.Location = new System.Drawing.Point(121, 167);
            this.AccountExistsLabel.Name = "AccountExistsLabel";
            this.AccountExistsLabel.Size = new System.Drawing.Size(100, 16);
            this.AccountExistsLabel.TabIndex = 9;
            // 
            // EnoughMoneyLabel
            // 
            this.EnoughMoneyLabel.Location = new System.Drawing.Point(121, 239);
            this.EnoughMoneyLabel.Name = "EnoughMoneyLabel";
            this.EnoughMoneyLabel.Size = new System.Drawing.Size(100, 20);
            this.EnoughMoneyLabel.TabIndex = 10;
            // 
            // amountTextBox
            // 
            this.amountTextBox.Enabled = false;
            this.amountTextBox.Location = new System.Drawing.Point(121, 216);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(100, 20);
            this.amountTextBox.TabIndex = 2;
            this.amountTextBox.TextChanged += new System.EventHandler(this.amountTextBox_TextChanged);
            // 
            // SelectRecipientButton
            // 
            this.SelectRecipientButton.Location = new System.Drawing.Point(227, 144);
            this.SelectRecipientButton.Name = "SelectRecipientButton";
            this.SelectRecipientButton.Size = new System.Drawing.Size(25, 20);
            this.SelectRecipientButton.TabIndex = 11;
            this.SelectRecipientButton.Text = "...";
            this.SelectRecipientButton.UseVisualStyleBackColor = true;
            this.SelectRecipientButton.Click += new System.EventHandler(this.SelectRecipientButton_Click);
            // 
            // CreateTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(337, 327);
            this.Controls.Add(this.SelectRecipientButton);
            this.Controls.Add(this.EnoughMoneyLabel);
            this.Controls.Add(this.AccountExistsLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.transferButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(this.recipientAccountNumberTextBox);
            this.Controls.Add(this.sourceAccountComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(15, 15);
            this.MaximizeBox = false;
            this.Name = "CreateTransaction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Створення Платежу";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button SelectRecipientButton;

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.TextBox amountTextBox;

        private System.Windows.Forms.Label EnoughMoneyLabel;

        private System.Windows.Forms.Label AccountExistsLabel;

        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.Button transferButton;

        private System.Windows.Forms.TextBox recipientAccountNumberTextBox;
        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.ComboBox sourceAccountComboBox;

        #endregion
    }
}
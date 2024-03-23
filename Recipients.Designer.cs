namespace CourseWork
{
    partial class Recipients
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Recipients));
            this.accountsComboBox = new System.Windows.Forms.ComboBox();
            this.accountHolderLabel = new System.Windows.Forms.Label();
            this.TransferButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // accountsComboBox
            // 
            this.accountsComboBox.FormattingEnabled = true;
            this.accountsComboBox.Location = new System.Drawing.Point(132, 123);
            this.accountsComboBox.Name = "accountsComboBox";
            this.accountsComboBox.Size = new System.Drawing.Size(121, 21);
            this.accountsComboBox.TabIndex = 0;
            this.accountsComboBox.SelectedIndexChanged += new System.EventHandler(this.accountsComboBox_SelectedIndexChanged);
            // 
            // accountHolderLabel
            // 
            this.accountHolderLabel.Location = new System.Drawing.Point(120, 193);
            this.accountHolderLabel.Name = "accountHolderLabel";
            this.accountHolderLabel.Size = new System.Drawing.Size(204, 23);
            this.accountHolderLabel.TabIndex = 1;
            // 
            // TransferButton
            // 
            this.TransferButton.Enabled = false;
            this.TransferButton.Location = new System.Drawing.Point(155, 150);
            this.TransferButton.Name = "TransferButton";
            this.TransferButton.Size = new System.Drawing.Size(75, 21);
            this.TransferButton.TabIndex = 2;
            this.TransferButton.Text = "Вибрати";
            this.TransferButton.UseVisualStyleBackColor = true;
            this.TransferButton.Click += new System.EventHandler(this.TransferButton_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(79, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Недавні отримувачі";
            // 
            // Recipients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 345);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TransferButton);
            this.Controls.Add(this.accountHolderLabel);
            this.Controls.Add(this.accountsComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Recipients";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отримувачі";
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Button TransferButton;

        private System.Windows.Forms.Label accountHolderLabel;

        private System.Windows.Forms.ComboBox accountsComboBox;

        #endregion
    }
}
namespace CourseWork
{
    partial class MainUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainUser));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.SendMoney = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateTransation = new System.Windows.Forms.ToolStripMenuItem();
            this.Recipients = new System.Windows.Forms.ToolStripMenuItem();
            this.Transactions = new System.Windows.Forms.ToolStripMenuItem();
            this.моїРахункиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.CheckAccounts = new System.Windows.Forms.ToolStripMenuItem();
            this.Help = new System.Windows.Forms.ToolStripMenuItem();
            this.About = new System.Windows.Forms.ToolStripMenuItem();
            this.OnlineHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.LastTransaction = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.SendMoney, this.моїРахункиToolStripMenuItem, this.Help, this.Exit });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // SendMoney
            // 
            this.SendMoney.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.CreateTransation, this.Recipients, this.Transactions });
            this.SendMoney.Image = ((System.Drawing.Image)(resources.GetObject("SendMoney.Image")));
            this.SendMoney.Name = "SendMoney";
            this.SendMoney.Size = new System.Drawing.Size(148, 20);
            this.SendMoney.Text = "Переведення коштів";
            // 
            // CreateTransation
            // 
            this.CreateTransation.Image = ((System.Drawing.Image)(resources.GetObject("CreateTransation.Image")));
            this.CreateTransation.Name = "CreateTransation";
            this.CreateTransation.Size = new System.Drawing.Size(194, 22);
            this.CreateTransation.Text = "Перевести по номеру";
            this.CreateTransation.Click += new System.EventHandler(this.CreateTransaction_Click);
            // 
            // Recipients
            // 
            this.Recipients.Image = ((System.Drawing.Image)(resources.GetObject("Recipients.Image")));
            this.Recipients.Name = "Recipients";
            this.Recipients.Size = new System.Drawing.Size(194, 22);
            this.Recipients.Text = "Отримувачі";
            this.Recipients.Click += new System.EventHandler(this.Recipients_Click);
            // 
            // Transactions
            // 
            this.Transactions.Image = ((System.Drawing.Image)(resources.GetObject("Transactions.Image")));
            this.Transactions.Name = "Transactions";
            this.Transactions.Size = new System.Drawing.Size(194, 22);
            this.Transactions.Text = "Історія переведень";
            this.Transactions.Click += new System.EventHandler(this.Transactions_Click);
            // 
            // моїРахункиToolStripMenuItem
            // 
            this.моїРахункиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.CreateAccount, this.CheckAccounts });
            this.моїРахункиToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("моїРахункиToolStripMenuItem.Image")));
            this.моїРахункиToolStripMenuItem.Name = "моїРахункиToolStripMenuItem";
            this.моїРахункиToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.моїРахункиToolStripMenuItem.Text = "Мої рахунки";
            // 
            // CreateAccount
            // 
            this.CreateAccount.Image = ((System.Drawing.Image)(resources.GetObject("CreateAccount.Image")));
            this.CreateAccount.Name = "CreateAccount";
            this.CreateAccount.Size = new System.Drawing.Size(193, 22);
            this.CreateAccount.Text = "Створити рахунок";
            this.CreateAccount.Click += new System.EventHandler(this.CreateAccount_Click);
            // 
            // CheckAccounts
            // 
            this.CheckAccounts.Image = ((System.Drawing.Image)(resources.GetObject("CheckAccounts.Image")));
            this.CheckAccounts.Name = "CheckAccounts";
            this.CheckAccounts.Size = new System.Drawing.Size(193, 22);
            this.CheckAccounts.Text = "Переглянути рахунки";
            this.CheckAccounts.Click += new System.EventHandler(this.CheckAccounts_Click);
            // 
            // Help
            // 
            this.Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.About, this.OnlineHelp });
            this.Help.Image = ((System.Drawing.Image)(resources.GetObject("Help.Image")));
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(91, 20);
            this.Help.Text = "Допомога";
            // 
            // About
            // 
            this.About.Image = ((System.Drawing.Image)(resources.GetObject("About.Image")));
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(160, 22);
            this.About.Text = "Про програму";
            this.About.Click += new System.EventHandler(this.About_Click);
            // 
            // OnlineHelp
            // 
            this.OnlineHelp.Image = ((System.Drawing.Image)(resources.GetObject("OnlineHelp.Image")));
            this.OnlineHelp.Name = "OnlineHelp";
            this.OnlineHelp.Size = new System.Drawing.Size(160, 22);
            this.OnlineHelp.Text = "Онлайн довідка";
            this.OnlineHelp.Click += new System.EventHandler(this.OnlineHelp_Click);
            // 
            // Exit
            // 
            this.Exit.Image = ((System.Drawing.Image)(resources.GetObject("Exit.Image")));
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(64, 20);
            this.Exit.Text = "Вихід";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.toolStripStatusLabel1, this.toolStripStatusLabel2, this.toolStripStatusLabel3, this.LastTransaction });
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel1.Image")));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(50, 17);
            this.toolStripStatusLabel1.Text = "USER";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel2.Image")));
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(49, 17);
            this.toolStripStatusLabel2.Text = "TIME";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel3.Image")));
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(83, 17);
            this.toolStripStatusLabel3.Text = "CURRENCY";
            // 
            // LastTransaction
            // 
            this.LastTransaction.Image = ((System.Drawing.Image)(resources.GetObject("LastTransaction.Image")));
            this.LastTransaction.Name = "LastTransaction";
            this.LastTransaction.Size = new System.Drawing.Size(133, 17);
            this.LastTransaction.Text = "Остання транзакція:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(164, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 39);
            this.label1.TabIndex = 2;
            // 
            // MainUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Банк";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_User_FormClosed);
            this.Load += new System.EventHandler(this.Main_User_Load);
            this.Shown += new System.EventHandler(this.Main_User_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ToolStripStatusLabel LastTransaction;

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem SendMoney;
        private System.Windows.Forms.ToolStripMenuItem CreateTransation;
        private System.Windows.Forms.ToolStripMenuItem Recipients;
        private System.Windows.Forms.ToolStripMenuItem Help;
        private System.Windows.Forms.ToolStripMenuItem Exit;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem моїРахункиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateAccount;
        private System.Windows.Forms.ToolStripMenuItem CheckAccounts;
        private System.Windows.Forms.ToolStripMenuItem About;
        private System.Windows.Forms.ToolStripMenuItem OnlineHelp;
        private System.Windows.Forms.ToolStripMenuItem Transactions;
    }
}
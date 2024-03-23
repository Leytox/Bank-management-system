namespace CourseWork
{
    partial class MainAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainAdmin));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Users = new System.Windows.Forms.ToolStripMenuItem();
            this.Transactions = new System.Windows.Forms.ToolStripMenuItem();
            this.Logs = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ActiveAdmin = new System.Windows.Forms.ToolStripStatusLabel();
            this.CurrentTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.Users, this.Transactions, this.Logs, this.Exit });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(589, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Users
            // 
            this.Users.Image = ((System.Drawing.Image)(resources.GetObject("Users.Image")));
            this.Users.Name = "Users";
            this.Users.Size = new System.Drawing.Size(102, 20);
            this.Users.Text = "Користувачі";
            this.Users.Click += new System.EventHandler(this.UsersClick);
            // 
            // Transactions
            // 
            this.Transactions.Image = ((System.Drawing.Image)(resources.GetObject("Transactions.Image")));
            this.Transactions.Name = "Transactions";
            this.Transactions.Size = new System.Drawing.Size(91, 20);
            this.Transactions.Text = "Транзакції";
            this.Transactions.Click += new System.EventHandler(this.Transactions_Click);
            // 
            // Logs
            // 
            this.Logs.Image = ((System.Drawing.Image)(resources.GetObject("Logs.Image")));
            this.Logs.Name = "Logs";
            this.Logs.Size = new System.Drawing.Size(96, 20);
            this.Logs.Text = "Логи входу";
            this.Logs.Click += new System.EventHandler(this.Logs_Click);
            // 
            // Exit
            // 
            this.Exit.Image = ((System.Drawing.Image)(resources.GetObject("Exit.Image")));
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(64, 20);
            this.Exit.Text = "Вихід";
            this.Exit.Click += new System.EventHandler(this.ExitClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.ActiveAdmin, this.CurrentTime });
            this.statusStrip1.Location = new System.Drawing.Point(0, 344);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(589, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ActiveAdmin
            // 
            this.ActiveAdmin.Image = ((System.Drawing.Image)(resources.GetObject("ActiveAdmin.Image")));
            this.ActiveAdmin.Name = "ActiveAdmin";
            this.ActiveAdmin.Size = new System.Drawing.Size(92, 17);
            this.ActiveAdmin.Text = "ActiveAdmin";
            // 
            // CurrentTime
            // 
            this.CurrentTime.Image = ((System.Drawing.Image)(resources.GetObject("CurrentTime.Image")));
            this.CurrentTime.Name = "CurrentTime";
            this.CurrentTime.Size = new System.Drawing.Size(89, 17);
            this.CurrentTime.Text = "CurrentTime";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(169, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(354, 34);
            this.label1.TabIndex = 2;
            this.label1.Text = "WELCOME";
            // 
            // MainAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 366);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainAdmin";
            this.Text = "Панель адміністратора";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainAdmin_FormClosed);
            this.Load += new System.EventHandler(this.MainAdmin_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ToolStripStatusLabel CurrentTime;

        private System.Windows.Forms.ToolStripStatusLabel ActiveAdmin;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem Users;
        private System.Windows.Forms.ToolStripMenuItem Transactions;
        private System.Windows.Forms.ToolStripMenuItem Logs;
        private System.Windows.Forms.ToolStripMenuItem Exit;

        #endregion
    }
}
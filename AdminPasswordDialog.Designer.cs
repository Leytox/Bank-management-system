using System.ComponentModel;

namespace CourseWork;

partial class AdminPasswordDialog
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminPasswordDialog));
        this.passwordTextBox = new System.Windows.Forms.TextBox();
        this.button1 = new System.Windows.Forms.Button();
        this.label1 = new System.Windows.Forms.Label();
        this.button2 = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // passwordTextBox
        // 
        this.passwordTextBox.Location = new System.Drawing.Point(86, 35);
        this.passwordTextBox.Name = "passwordTextBox";
        this.passwordTextBox.Size = new System.Drawing.Size(136, 20);
        this.passwordTextBox.TabIndex = 0;
        // 
        // button1
        // 
        this.button1.Location = new System.Drawing.Point(86, 100);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(66, 23);
        this.button1.TabIndex = 1;
        this.button1.Text = "OK";
        this.button1.UseVisualStyleBackColor = true;
        this.button1.Click += new System.EventHandler(this.button1_Click);
        // 
        // label1
        // 
        this.label1.Location = new System.Drawing.Point(86, 9);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(136, 23);
        this.label1.TabIndex = 2;
        this.label1.Text = "Введіть майстер-пароль";
        // 
        // button2
        // 
        this.button2.Location = new System.Drawing.Point(158, 100);
        this.button2.Name = "button2";
        this.button2.Size = new System.Drawing.Size(65, 23);
        this.button2.TabIndex = 3;
        this.button2.Text = "Відміна";
        this.button2.UseVisualStyleBackColor = true;
        this.button2.Click += new System.EventHandler(this.button2_Click);
        // 
        // AdminPasswordDialog
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(308, 135);
        this.Controls.Add(this.button2);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.button1);
        this.Controls.Add(this.passwordTextBox);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "AdminPasswordDialog";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Підтвердження";
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.Button button2;

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.TextBox passwordTextBox;

    #endregion
}
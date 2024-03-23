using System;
using System.Windows.Forms;

namespace CourseWork;

public partial class AdminPasswordDialog : Form
{
    public AdminPasswordDialog()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        const string specialPassword = "88005553535"; // Replace with your special password

        if (passwordTextBox.Text == specialPassword)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
        else
        {
            MessageBox.Show(@"Неправильний пароль", @"Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void button2_Click(object sender, EventArgs e)
    {
        Close();
    }
}
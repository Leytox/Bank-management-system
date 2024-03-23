using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CourseWork;

public partial class AdminLogin : Form
{
    public AdminLogin()
    {
        InitializeComponent();
    }

    private void Auth()
    {
        if (string.IsNullOrEmpty(textBox1.Text))
        {
            MessageBox.Show(@"Введіть логін!", @"Попередженння", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            textBox1.Focus();
            return;
        }

        if (string.IsNullOrEmpty(textBox2.Text))
        {
            MessageBox.Show(@"Введіть пароль!", @"Попередженння", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            textBox2.Focus();
            return;
        }

        var username = textBox1.Text;
        var password = textBox2.Text;

        if (AuthenticateUser(username, password))
        {
            MessageBox.Show(@"Ви були успішно авторизовані!", @"Успіх", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            var mainAdmin = new MainAdmin(username);
            mainAdmin.Show();
            Hide();
        }
        else
        {
            textBox2.Text = "";
            MessageBox.Show(@"Неправильний логін, або пароль.", @"Помилка", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
    }

    private static bool AuthenticateUser(string username, string password)
    {
        try
        {
            var connection = new DbConnect();
            connection.Open();

            var hashedPassword = HashPassword.ComputeHash(password);
            const string query = "SELECT * FROM Admins WHERE username = @Username AND password = @Password";
            var command = new SqlCommand(query, connection.GetConnection());
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", hashedPassword);

            var reader = command.ExecuteReader();
            var isAuthenticated = reader.HasRows;

            reader.Close();

            connection.Close();
            return isAuthenticated;
        }
        catch (SqlException)
        {
            MessageBox.Show(@"Виникла помилка сервера при аутентифікації: ", @"Помилка", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return false;
        }
    }

    private void button2_MouseDown(object sender, MouseEventArgs e)
    {
        button2.Image = Image.FromFile("..\\..\\icons\\visible.ico");
        textBox2.PasswordChar = textBox2.PasswordChar == '*' ? '\0' : '*';
    }

    private void button2_MouseUp(object sender, MouseEventArgs e)
    {
        button2.Image = Image.FromFile("..\\..\\icons\\hide.ico");
        textBox2.PasswordChar = textBox2.PasswordChar == '*' ? '\0' : '*';
    }

    private void AdminLogin_FormClosed(object sender, FormClosedEventArgs e)
    {
        Application.Exit();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        Auth();
    }

    private void textBox1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
            Auth();
    }

    private void textBox2_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
            Auth();
    }
}
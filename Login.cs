using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CourseWork;

public partial class Login : Form
{
    public Login()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        Auth();
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
            var mainUserForm = new MainUser(username);
            mainUserForm.Show();
            Hide();
        }
        else
        {
            textBox2.Text = "";
            MessageBox.Show(@"Неправильний логін, або пароль.", @"Помилка", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
    }

    private bool AuthenticateUser(string username, string password)
    {
        try
        {
            var connection = new DbConnect();
            connection.Open();

            var hashedPassword = HashPassword.ComputeHash(password);
            const string query = "SELECT * FROM Users WHERE username = @Username AND password = @Password";
            var command = new SqlCommand(query, connection.GetConnection());
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", hashedPassword);

            var reader = command.ExecuteReader();
            var isAuthenticated = reader.HasRows;

            reader.Close();

            TrackLoginHistory(isAuthenticated, connection);

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

    private void TrackLoginHistory(bool isAuthenticated, DbConnect connection)
    {
        try
        {
            const string query = "INSERT INTO LoginHistory (login_time, result) VALUES (@LoginTime, @Result)";
            var command = new SqlCommand(query, connection.GetConnection());
            command.Parameters.AddWithValue("@LoginTime", DateTime.Now);
            command.Parameters.AddWithValue("@Result", isAuthenticated ? "Success" : "Failed");
            command.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            MessageBox.Show(ex.ToString(), @"Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
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

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        var registration = new Registration();
        registration.Show();
        Hide();
    }

    private void Login_FormClosed(object sender, FormClosedEventArgs e)
    {
        Application.Exit();
    }

    private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        AdminLogin adminLogin = new();
        adminLogin.Show();
        Hide();
    }
}
using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CourseWork;

public partial class Registration : Form
{
    public Registration()
    {
        InitializeComponent();
    }

    private void RegisterUser(string username, string password, string email, string phoneNumber, string firstName,
        string lname, string middleName, string ipn)
    {
        try
        {
            var connection = new DbConnect();
            connection.Open();
            var hashedPassword = HashPassword.ComputeHash(password);
            var command = new SqlCommand(
                "INSERT INTO Users (first_name, last_name, email, password, phone_number, middle_name, username, ipn) VALUES (@FirstName, @LastName, @Email, @Password, @PhoneNumber, @MiddleName, @Username, @IPN)",
                connection.GetConnection());
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", hashedPassword);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
            command.Parameters.AddWithValue("@FirstName", firstName);
            command.Parameters.AddWithValue("@LastName", lname);
            command.Parameters.AddWithValue("@MiddleName", middleName);
            command.Parameters.AddWithValue("@IPN", ipn);
            if (command.ExecuteNonQuery() > 0) // Перевіряє, чи змінилась кількість записів у таблиці 
            {
                MessageBox.Show(@"Ви успішно зареєстровані в банку!", @"Успіх", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                var login = new Login();
                login.Show();
                Hide();
            }
            else
            {
                MessageBox.Show(@"Помилка реєстрації.", @"Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            connection.Close();
        }
        catch (SqlException ex)
        {
            MessageBox.Show(@"Виникла помилка при реєстрації користувача: " + ex.Message, @"Помилка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private static bool IsUserAlreadyExists(string username, string email, string ipn, DbConnect connection)
    {
        var command =
            new SqlCommand("SELECT * FROM Users WHERE Username = @Username OR Ipn = @Ipn OR Email = @Email",
                connection.GetConnection());
        command.Parameters.AddWithValue("@Username", username);
        command.Parameters.AddWithValue("@Email", email);
        command.Parameters.AddWithValue("@Ipn", ipn);
        var reader = command.ExecuteReader();
        var exists = reader.HasRows;
        reader.Close();
        connection.Close();
        return exists;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var connection = new DbConnect();
        connection.Open();
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

        if (string.IsNullOrEmpty(textBox3.Text))
        {
            MessageBox.Show(@"Введіть email!", @"Попередженння", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            textBox3.Focus();
            return;
        }

        if (!maskedTextBox1.MaskCompleted)
        {
            MessageBox.Show(@"Введіть номер!", @"Попередженння", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            maskedTextBox1.Focus();
            return;
        }

        if (string.IsNullOrEmpty(textBox4.Text))
        {
            MessageBox.Show(@"Введіть Ім'я!", @"Попередженння", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            textBox4.Focus();
            return;
        }

        if (string.IsNullOrEmpty(textBox5.Text))
        {
            MessageBox.Show(@"Введіть Прізвище!", @"Попередженння", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            textBox5.Focus();
            return;
        }

        if (string.IsNullOrEmpty(textBox6.Text))
        {
            MessageBox.Show(@"Введіть по батькові!", @"Попередженння", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            textBox6.Focus();
            return;
        }

        if (!maskedTextBox3.MaskCompleted)
        {
            MessageBox.Show(@"Введіть ІПН!", @"Попередженння", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            maskedTextBox1.Focus();
            return;
        }

        if (!checkBox1.Checked)
        {
            MessageBox.Show(@"Погодьтесь з умовами використання!", @"Попередженння", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            checkBox1.Focus();
            return;
        }

        if (!IsValidEmail(textBox3.Text))
        {
            MessageBox.Show(@"Введіть корректний email!", @"Попередженння", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            textBox3.Focus();
            return;
        }

        var username = textBox1.Text;
        var password = textBox2.Text;
        var email = textBox3.Text;
        var phoneNumber = maskedTextBox1.Text;
        var firstName = textBox4.Text;
        var lname = textBox5.Text;
        var middleName = textBox6.Text;
        var ipn = maskedTextBox3.Text;
        if (IsUserAlreadyExists(username, email, ipn, connection))
        {
            MessageBox.Show(@"Користувач з таким логіном або електронною поштою вже існує!", @"Попередження",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        RegisterUser(username, password, email, phoneNumber, firstName, lname, middleName, ipn);
    }

    private static bool IsValidEmail(string email)
    {
        const string pattern = @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)*(\.[a-zA-Z]{2,})$";
        var regex = new Regex(pattern);
        return regex.IsMatch(email);
    }

    private void Registration_FormClosed(object sender, FormClosedEventArgs e)
    {
        var login = new Login();
        login.Show();
        Hide();
    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        MessageBox.Show(@"Поводьтесь гарно, любіть батьків і мийте руки перед їжею", @"Правила користування",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        var passwordDialog = new AdminPasswordDialog();
        if (passwordDialog.ShowDialog() != DialogResult.OK) return;
        var registerAdmin = new RegisterAdmin();
        registerAdmin.Show();
        Hide();
    }
}
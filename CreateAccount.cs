using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CourseWork;

public partial class CreateAccount : Form
{
    private readonly string _username;

    public CreateAccount(string username)
    {
        InitializeComponent();
        _username = username;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var connection = new DbConnect();
        connection.Open();
        var command = new SqlCommand("SELECT user_id FROM Users WHERE username = @Username",
            connection.GetConnection());
        command.Parameters.AddWithValue("@Username", _username);
        var userId = (int)command.ExecuteScalar();
        var accountType = radioButton1.Checked switch
        {
            true when !radioButton2.Checked && !radioButton3.Checked => "Заробітній",
            false when radioButton2.Checked && !radioButton3.Checked => "Бонусний",
            _ => "Кредитний"
        };
        command = new SqlCommand(
            "INSERT INTO Accounts (user_id, account_type, balance, creation_date, status) VALUES (@user_id, @account_type, @balance, @creation_date, @status)",
            connection.GetConnection());
        command.Parameters.AddWithValue("@user_id", userId);
        command.Parameters.AddWithValue("@account_type", accountType);
        command.Parameters.AddWithValue("@balance", 0);
        command.Parameters.AddWithValue("@creation_date", DateTime.Now);
        command.Parameters.AddWithValue("@status", "Active");
        if (command.ExecuteNonQuery() > 0)
            MessageBox.Show(@"Рахунок був успішно створений!", @"Успіх", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        else
            MessageBox.Show(@"Виникла помилка під час створення рахунку!", @"Помилка", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        CheckAccounts();
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        button1.Enabled = checkBox1.Checked;
    }

    private void CheckAccounts()
    {
        var connection = new DbConnect();
        connection.Open();
        var command =
            new SqlCommand(
                "SELECT DISTINCT account_type FROM Accounts WHERE user_id = (SELECT user_id FROM Users WHERE username = @Username)",
                connection.GetConnection());
        command.Parameters.AddWithValue("@Username", _username);
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                var account = reader.GetString(0);
                switch (account)
                {
                    case "Заробітній":
                        radioButton1.Enabled = false;
                        break;
                    case "Бонусний":
                        radioButton2.Enabled = false;
                        break;
                    case "Кредитний":
                        radioButton3.Enabled = false;
                        break;
                }
            }

            if (!radioButton1.Enabled && !radioButton2.Enabled && !radioButton3.Enabled)
            {
                MessageBox.Show(
                    @"Ви більше не можете створювати рахунки! Всі типи рахунків вже були створені",
                    @"Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        connection.Close();
    }

    private void CreateAccount_Load(object sender, EventArgs e)
    {
        CheckAccounts();
    }
}
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CourseWork;

public partial class Accounts : Form
{
    private readonly string _username;

    public Accounts(string username)
    {
        InitializeComponent();
        _username = username;
    }

    private void Accounts_Load(object sender, EventArgs e)
    {
        CheckAccounts();

        salaryAccountButton.Enabled = CheckAccountExistence("Заробітній");
        bonusAccountButton.Enabled = CheckAccountExistence("Бонусний");
        creditAccountButton.Enabled = CheckAccountExistence("Кредитний");
    }


    private void CheckAccounts()
    {
        var connection = new DbConnect();
        connection.Open();

        var command = new SqlCommand(
            "SELECT account_type, account_id, balance, status FROM Accounts WHERE user_id = (SELECT user_id FROM Users WHERE username = @Username)",
            connection.GetConnection());
        command.Parameters.AddWithValue("@Username", _username);

        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                var accountType = reader.GetString(0);
                var accountId = reader.GetInt32(1);
                var balance = reader.GetDecimal(2);
                var status = reader.GetString(3);

                switch (accountType)
                {
                    case "Заробітній":
                        salaryAccountButton.Text = status == "Active"
                            ? "Закрити рахунок"
                            : "Відкрити рахунок";
                        if (status == "Active")
                        {
                            salaryAccountBalance.Text = @"Баланс: " + balance.ToString("F2");
                            salaryAccountBalance.Enabled = true;
                            salaryAccountLabel.Text = @"ID: " + accountId;
                        }
                        else
                        {
                            salaryAccountBalance.Enabled = false;
                            salaryAccountLabel.Text = "";
                        }

                        break;
                    case "Бонусний":
                        bonusAccountButton.Text =
                            status == "Active" ? "Закрити рахунок" : "Відкрити рахунок";
                        if (status == "Active")
                        {
                            bonusAccountBalance.Text = @"Баланс: " + balance.ToString("F2");
                            bonusAccountBalance.Enabled = true;
                            bonusAccountLabel.Text = @"ID: " + accountId;
                        }
                        else
                        {
                            bonusAccountBalance.Enabled = false;
                            bonusAccountLabel.Text = "";
                        }

                        break;
                    case "Кредитний":
                        creditAccountButton.Text = status == "Active"
                            ? "Закрити рахунок"
                            : "Відкрити рахунок";
                        if (status == "Active")
                        {
                            creditAccountBalance.Text = @"Баланс: " + balance.ToString("F2");
                            creditAccountBalance.Enabled = true;
                            creditAccountLabel.Text = @"ID: " + accountId;
                        }
                        else
                        {
                            creditAccountBalance.Enabled = false;
                            creditAccountLabel.Text = "";
                        }

                        break;
                }
            }
        }

        connection.Close();
    }


    private void UpdateAccountStatus(string accountType, string newStatus)
    {
        var connection = new DbConnect();
        connection.Open();
        var command =
            new SqlCommand(
                "UPDATE Accounts SET status = @NewStatus WHERE account_type = @AccountType AND user_id = (SELECT user_id FROM Users WHERE username = @Username)",
                connection.GetConnection());
        command.Parameters.AddWithValue("@AccountType", accountType);
        command.Parameters.AddWithValue("@Username", _username);
        command.Parameters.AddWithValue("@NewStatus", newStatus);

        if (command.ExecuteNonQuery() > 0)
            MessageBox.Show($@"{accountType} рахунок був успішно {(newStatus == "Active" ? "відкритий" : "закритий")}.",
                @"Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
        else
            MessageBox.Show($@"Не вдалось {(newStatus == "Active" ? "відкрити" : "закрити")} {accountType} рахунок.",
                @"Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);

        connection.Close();
        CheckAccounts();
    }

    private void salaryAccountButton_Click(object sender, EventArgs e)
    {
        var currentStatus = salaryAccountButton.Text.Contains("Закрити рахунок") ? "Active" : "Closed";
        var newStatus = currentStatus == "Active" ? "Closed" : "Active";
        UpdateAccountStatus("Заробітній", newStatus);
    }

    private void bonusAccountButton_Click(object sender, EventArgs e)
    {
        var currentStatus = bonusAccountButton.Text.Contains("Закрити рахунок") ? "Active" : "Closed";
        var newStatus = currentStatus == "Active" ? "Closed" : "Active";
        UpdateAccountStatus("Бонусний", newStatus);
    }

    private void creditAccountButton_Click(object sender, EventArgs e)
    {
        var currentStatus = creditAccountButton.Text.Contains("Закрити рахунок") ? "Active" : "Closed";
        var newStatus = currentStatus == "Active" ? "Closed" : "Active";
        UpdateAccountStatus("Кредитний", newStatus);
    }

    private bool CheckAccountExistence(string accountType)
    {
        var connection = new DbConnect();
        connection.Open();

        var command = new SqlCommand(
            "SELECT COUNT(*) FROM Accounts WHERE account_type = @AccountType AND user_id = (SELECT user_id FROM Users WHERE username = @Username)",
            connection.GetConnection());
        command.Parameters.AddWithValue("@AccountType", accountType);
        command.Parameters.AddWithValue("@Username", _username);

        var count = (int)command.ExecuteScalar();
        connection.Close();

        return count > 0;
    }
}
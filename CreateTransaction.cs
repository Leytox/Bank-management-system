using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CourseWork;

public partial class CreateTransaction : Form
{
    private readonly string _username;

    public CreateTransaction(string username)
    {
        InitializeComponent();
        _username = username;
        PopulateSourceAccountComboBox();
    }

    private void PopulateSourceAccountComboBox()
    {
        var accounts = GetActiveAccountTypes(_username);
        foreach (var accountType in accounts) sourceAccountComboBox.Items.Add(accountType);
    }

    private static List<string> GetActiveAccountTypes(string username)
    {
        var connection = new DbConnect();
        connection.Open();

        var command = new SqlCommand(
            "SELECT account_type FROM Accounts WHERE user_id = (SELECT user_id FROM Users WHERE username = @Username) AND status != 'Closed'",
            connection.GetConnection());
        command.Parameters.AddWithValue("@Username", username);

        var reader = command.ExecuteReader();
        var accounts = new List<string>();
        while (reader.Read()) accounts.Add(reader.GetString(0));

        connection.Close();

        return accounts;
    }

    private void TransferFunds(string sourceAccountType, string recipientAccountNumber, decimal amount)
    {
        if (amount <= 0)
        {
            MessageBox.Show(@"Неможливо переказати від'ємну або нульову суму.", @"Помилка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return;
        }

        var connection = new DbConnect();
        connection.Open();
        int sourceAccountId;
        var command =
            new SqlCommand(
                "SELECT account_id, balance FROM Accounts WHERE account_type = @AccountType AND user_id = (SELECT user_id FROM Users WHERE username = @Username)",
                connection.GetConnection());
        command.Parameters.AddWithValue("@AccountType", sourceAccountType);
        command.Parameters.AddWithValue("@Username", _username);
        using (var reader = command.ExecuteReader())
        {
            if (!reader.Read())
            {
                MessageBox.Show(@"Рахунок не знайдено.", @"Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
                return;
            }

            sourceAccountId = reader.GetInt32(0);
            var sourceBalance = reader.GetDecimal(1);
            if (sourceBalance < amount)
            {
                MessageBox.Show(@"Недостатньо коштів на рахунку.", @"Помилка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                connection.Close();
                return;
            }
        }

        if (sourceAccountId.ToString() == recipientAccountNumber)
        {
            MessageBox.Show(@"Транзакції між однаковими рахунками користувача заборонені.", @"Помилка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            connection.Close();
            return;
        }

        command = new SqlCommand("SELECT COUNT(*) FROM Accounts WHERE account_id = @RecipientAccountNumber",
            connection.GetConnection());
        command.Parameters.AddWithValue("@RecipientAccountNumber", recipientAccountNumber);
        var recipientAccountCount = (int)command.ExecuteScalar();

        if (recipientAccountCount == 0)
        {
            MessageBox.Show(@"Рахунок не знайдено.", @"Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            connection.Close();
            return;
        }


        decimal commission = 0;
        if (sourceAccountType.Equals("Кредитний"))
        {
            commission = amount * 0.05m;
            var result = MessageBox.Show(
                $@"З вашого кредитного рахунку буде стягнуто комісію 5% ({commission}) за переказ.",
                @"Увага", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Cancel)
                return;
        }

        // Debit the source account with commission
        command = new SqlCommand(
            "UPDATE Accounts SET balance = balance - @Amount - @Commission WHERE account_id = @SourceAccountId",
            connection.GetConnection());
        command.Parameters.AddWithValue("@Amount", amount);
        command.Parameters.AddWithValue("@Commission", commission);
        command.Parameters.AddWithValue("@SourceAccountId", sourceAccountId);
        command.ExecuteNonQuery();


        // Credit the recipient account
        command = new SqlCommand(
            "UPDATE Accounts SET balance = balance + @Amount WHERE account_id = @RecipientAccountNumber",
            connection.GetConnection());
        command.Parameters.AddWithValue("@Amount", amount);
        command.Parameters.AddWithValue("@RecipientAccountNumber", recipientAccountNumber);
        command.ExecuteNonQuery();

        // Insert a transaction record
        command = new SqlCommand(
            "INSERT INTO Transactions (sender_account_id, recipient_account_number, transaction_type, amount, transaction_date, description) VALUES (@SenderAccountId, @RecipientAccountNumber, 'Transfer', @Amount, @TransactionDate, 'Funds transfer')",
            connection.GetConnection());
        command.Parameters.AddWithValue("@SenderAccountId", sourceAccountId);
        command.Parameters.AddWithValue("@RecipientAccountNumber", recipientAccountNumber);
        command.Parameters.AddWithValue("@Amount", amount);
        command.Parameters.AddWithValue("@TransactionDate", DateTime.Now);
        command.ExecuteNonQuery();

        connection.Close();
        MessageBox.Show(@"Транзакція успішна!", @"Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void transferButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(sourceAccountComboBox.Text))
        {
            MessageBox.Show(@"Необхідно вибрати тип рахунку.", @"Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (string.IsNullOrEmpty(recipientAccountNumberTextBox.Text))
        {
            MessageBox.Show(@"Необхідно ввести номер рахунку одержувача.", @"Помилка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return;
        }

        if (string.IsNullOrEmpty(amountTextBox.Text))
        {
            MessageBox.Show(@"Необхідно ввести суму.", @"Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // Check if amount is a valid decimal number
        if (!decimal.TryParse(amountTextBox.Text, out var parsedAmount))
        {
            MessageBox.Show(@"Неправильний формат суми. Будь ласка, введіть число.", @"Помилка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return;
        }

        var sourceAccountType = sourceAccountComboBox.SelectedItem.ToString();
        var recipientAccountNumber = recipientAccountNumberTextBox.Text;

        TransferFunds(sourceAccountType, recipientAccountNumber, parsedAmount);
    }

    private void sourceAccountComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (sourceAccountComboBox.SelectedIndex == -1)
        {
            amountTextBox.Enabled = false;
            label5.Visible = false;
            return;
        } // Check if an item is selected

        amountTextBox.Enabled = true;
        label5.Visible = true;
        var selectedAccountType = sourceAccountComboBox.SelectedItem.ToString();
        var connection = new DbConnect();
        connection.Open();

        var command = new SqlCommand(
            "SELECT balance FROM Accounts WHERE account_type = @AccountType AND user_id = (SELECT user_id FROM Users WHERE username = @Username)",
            connection.GetConnection());
        command.Parameters.AddWithValue("@AccountType", selectedAccountType);
        command.Parameters.AddWithValue("@Username", _username);

        decimal balance = 0;
        using (var reader = command.ExecuteReader())
        {
            if (reader.Read()) balance = reader.GetDecimal(0);
        }

        connection.Close();

        label5.Text = $@"Баланс: {balance}";
    }

    private void recipientAccountNumberTextBox_TextChanged(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(recipientAccountNumberTextBox.Text))
        {
            AccountExistsLabel.Text = "";
            return;
        }

        var connection = new DbConnect();
        connection.Open();

        var command = new SqlCommand(
            "SELECT COUNT(*) FROM Accounts WHERE account_id = @RecipientAccountNumber",
            connection.GetConnection());
        command.Parameters.AddWithValue("@RecipientAccountNumber", recipientAccountNumberTextBox.Text);
        command.Parameters.AddWithValue("@Username", _username);

        var recipientAccountCount = (int)command.ExecuteScalar();

        connection.Close();

        if (recipientAccountCount > 0)
        {
            connection.Open();

            command = new SqlCommand(
                "SELECT status FROM Accounts WHERE account_id = @RecipientAccountNumber",
                connection.GetConnection());
            command.Parameters.AddWithValue("@RecipientAccountNumber", recipientAccountNumberTextBox.Text);

            var status = command.ExecuteScalar() as string;

            connection.Close();

            if (status == "Closed")
            {
                AccountExistsLabel.Text = @"Рахунок закритий";
                AccountExistsLabel.ForeColor = Color.Red;
                transferButton.Enabled = false; // Disable the transfer button
            }

            if (IsSameAccount(_username, recipientAccountNumberTextBox.Text))
            {
                AccountExistsLabel.Text = @"Ваш рахунок";
                AccountExistsLabel.ForeColor = Color.DarkGoldenrod;
            }
            else
            {
                AccountExistsLabel.Text = @"Рахунок існує";
                AccountExistsLabel.ForeColor = Color.Green;
            }
        }
        else
        {
            AccountExistsLabel.Text = @"Рахунок не існує";
            AccountExistsLabel.ForeColor = Color.Red;
        }
    }

    private static bool IsSameAccount(string username, string recipientAccountNumber)
    {
        var connection = new DbConnect();
        connection.Open();

        var command = new SqlCommand(
            "SELECT COUNT(*) FROM Accounts WHERE account_id = @RecipientAccountNumber AND user_id = (SELECT user_id FROM Users WHERE username = @Username)",
            connection.GetConnection());
        command.Parameters.AddWithValue("@RecipientAccountNumber", recipientAccountNumber);
        command.Parameters.AddWithValue("@Username", username);

        var count = (int)command.ExecuteScalar();

        connection.Close();

        return count > 0;
    }

    private void amountTextBox_TextChanged(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(amountTextBox.Text))
        {
            EnoughMoneyLabel.Text = "";
            return;
        }

        // Check if amount is a valid decimal number
        if (!decimal.TryParse(amountTextBox.Text, out var parsedAmount))
        {
            EnoughMoneyLabel.Text = @"Неправильний формат суми. Будь ласка, введіть число.";
            EnoughMoneyLabel.ForeColor = Color.Red;
            transferButton.Enabled = false; // Disable transfer button
            return;
        }

        var selectedAccountType = sourceAccountComboBox.SelectedItem.ToString();

        EnoughMoneyLabel.Text = ""; // Clear previous message

        var connection = new DbConnect();
        connection.Open();

        var command = new SqlCommand(
            "SELECT balance FROM Accounts WHERE account_type = @AccountType AND user_id = (SELECT user_id FROM Users WHERE username = @Username)",
            connection.GetConnection());
        command.Parameters.AddWithValue("@AccountType", selectedAccountType);
        command.Parameters.AddWithValue("@Username", _username);

        decimal balance = 0;
        using (var reader = command.ExecuteReader())
        {
            if (reader.Read()) balance = reader.GetDecimal(0);
        }

        connection.Close();

        if (balance < parsedAmount)
        {
            EnoughMoneyLabel.Text =
                @$"Недостатньо коштів на рахунку. Необхідно: {parsedAmount} грн, наявний баланс: {balance} грн.";
            EnoughMoneyLabel.ForeColor = Color.Red;
            transferButton.Enabled = false; // Disable transfer button
        }
        else
        {
            EnoughMoneyLabel.Text = "";
            transferButton.Enabled = true; // Enable transfer button
        }
    }

    public void SetRecipientAccountNumber(string accountNumber)
    {
        recipientAccountNumberTextBox.Text = accountNumber;
    }

    private void SelectRecipientButton_Click(object sender, EventArgs e)
    {
        var recipients = new Recipients(_username);
        recipients.Show();
        Hide();
    }
}
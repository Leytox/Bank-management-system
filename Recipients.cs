using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CourseWork;

public partial class Recipients : Form
{
    private readonly string _username;

    public Recipients(string username)
    {
        InitializeComponent();
        _username = username;
        PopulateAccountsComboBox();
    }
    private void PopulateAccountsComboBox()
    {
        var connection = new DbConnect();
        connection.Open();

        var command = new SqlCommand(
            "SELECT DISTINCT recipient_account_number FROM Transactions WHERE sender_account_id IN (SELECT account_id FROM Accounts WHERE user_id = (SELECT user_id FROM Users WHERE username = @Username))",
            connection.GetConnection());
        command.Parameters.AddWithValue("@Username", _username);

        using (var reader = command.ExecuteReader())
        {
            while (reader.Read()) accountsComboBox.Items.Add(reader["recipient_account_number"].ToString());
        }

        connection.Close();
    }

    private void accountsComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Check if the selected item is null or empty
        if (string.IsNullOrEmpty(accountsComboBox.SelectedItem?.ToString()))
        {
            TransferButton.Enabled = false; // Disable the TransferButton
            accountHolderLabel.Text = "";
            return;
        }

        TransferButton.Enabled = true; // Enable the TransferButton

        try
        {
            var connection = new DbConnect();
            connection.Open();

            var command = new SqlCommand(
                "SELECT last_name, first_name, middle_name FROM Users WHERE user_id = (SELECT user_id FROM Accounts WHERE account_id = @AccountId)",
                connection.GetConnection());
            command.Parameters.AddWithValue("@AccountId", accountsComboBox.SelectedItem?.ToString());

            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    var lastName = reader["last_name"].ToString();
                    var firstName = reader["first_name"].ToString();
                    var middleName = reader["middle_name"].ToString();

                    accountHolderLabel.Text = @$"{lastName} {firstName} {middleName}";
                }
            }

            connection.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(@$"An error occurred while connecting to the database: {ex.Message}",
                @"Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void TransferButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(accountsComboBox.SelectedItem?.ToString())) return;

        // Save the selected account
        var selectedAccount = accountsComboBox.SelectedItem?.ToString();

        try
        {
            // Create an instance of the CreateTransaction form
            var createTransactionForm = new CreateTransaction(_username);

            // Set the Text property of the recipientTextBox to the selected account
            createTransactionForm.SetRecipientAccountNumber(selectedAccount ?? throw new InvalidOperationException());

            // Show the CreateTransaction form
            createTransactionForm.Show();
            createTransactionForm.Focus();

            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(@$"Виникла помилка при підключені до бази даних: {ex.Message}",
                @"Помилка підключення до бази даних", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
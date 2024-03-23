using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace CourseWork;

public partial class MainUser : Form
{
    private readonly Dictionary<string, decimal> _previousBalances;
    private readonly string _username;
    private Timer? _balanceTimer;
    private DateTime? _lastTransactionDate;

    public MainUser(string username)
    {
        InitializeComponent();
        _username = username;
        _previousBalances = new Dictionary<string, decimal>();
    }

    private void Main_User_Load(object sender, EventArgs e)
    {
        var connection = new DbConnect();
        var query = "SELECT first_name, user_id FROM Users WHERE username = @Username";
        var command = new SqlCommand(query, connection.GetConnection());
        command.Parameters.AddWithValue("@Username", _username);
        connection.Open();
        var reader = command.ExecuteReader();
        reader.Read();
        toolStripStatusLabel1.Text = @"Користувач: " + _username;
        toolStripStatusLabel2.Text = @"Поточний час: " + DateTime.Now.ToShortTimeString();
        toolStripStatusLabel3.Text = @"Курс: 1$ = 8₴, 1€ = 10₴";
        label1.Text = @"Вітаємо вас у системі, " + reader.GetString(0) + @"!";
        query = "SELECT COUNT(*) FROM Accounts WHERE user_id = @UserID";
        command = new SqlCommand(query, connection.GetConnection());
        command.Parameters.AddWithValue("@UserID", reader.GetValue(1));
        reader.Close();
        if ((int)command.ExecuteScalar() == 0)
        {
            SendMoney.Enabled = false;
            CheckAccounts.Enabled = false;
        }

        connection.Close();

        _balanceTimer = new Timer { Interval = 5000 }; // Update balances every 5 seconds
        _balanceTimer.Tick += BalanceTimer_Tick;
        _balanceTimer.Start();
    }

    private void BalanceTimer_Tick(object sender, EventArgs e)
    {
        var currentBalances = GetAccountBalances();

        // Check for increased balances
        foreach (var accountType in currentBalances.Keys)
        {
            if (!_previousBalances.TryGetValue(accountType, out var previousBalance))
            {
                _previousBalances[accountType] = currentBalances[accountType];
                continue; // Skip initial balance retrieval
            }

            var amountReceived = currentBalances[accountType] - previousBalance;
            if (amountReceived > 0)
                MessageBox.Show(
                    $@"На ваш {accountType} рахунок надійшли кошти! Сума надходження: {amountReceived:F2}Поточний баланс: {currentBalances[accountType]:F2}",
                    @"Повідомлення",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            _previousBalances[accountType] = currentBalances[accountType];
        }

        var connection = new DbConnect();
        var query =
            "SELECT COUNT(*) FROM Accounts WHERE user_id = (SELECT user_id FROM Users WHERE username = @Username)";
        var command = new SqlCommand(query, connection.GetConnection());
        command.Parameters.AddWithValue("@Username", _username);
        connection.Open();
        var accountCount = (int)command.ExecuteScalar();

        if (accountCount > 0)
        {
            // If there are accounts, enable the disabled elements
            SendMoney.Enabled = true;
            CheckAccounts.Enabled = true;
        }

        query =
            "SELECT COUNT(*) FROM Transactions WHERE sender_account_id IN (SELECT account_id FROM Accounts WHERE user_id = (SELECT user_id FROM Users WHERE username = @Username)) OR recipient_account_number IN (SELECT account_id FROM Accounts WHERE user_id = (SELECT user_id FROM Users WHERE username = @Username))";
        command = new SqlCommand(query, connection.GetConnection());
        command.Parameters.AddWithValue("@Username", _username);
        var transactionCount = (int)command.ExecuteScalar();

        if (transactionCount > 0)
        {
            // If there are transactions, get the date of the last transaction
            query =
                "SELECT MAX(transaction_date) FROM Transactions WHERE sender_account_id IN (SELECT account_id FROM Accounts WHERE user_id = (SELECT user_id FROM Users WHERE username = @Username)) OR recipient_account_number IN (SELECT account_id FROM Accounts WHERE user_id = (SELECT user_id FROM Users WHERE username = @Username))";
            command = new SqlCommand(query, connection.GetConnection());
            command.Parameters.AddWithValue("@Username", _username);
            var reader = command.ExecuteReader();
            if (reader.Read())
                _lastTransactionDate = reader.GetDateTime(0);
            else
                _lastTransactionDate = null;
        }
        else
        {
            // If there are no transactions, set _lastTransactionDate to null
            _lastTransactionDate = null;
        }

        LastTransaction.Text = _lastTransactionDate != null
            ? $"Остання транзакція: {_lastTransactionDate.Value}"
            : "Немає транзакцій";

        connection.Close();
        toolStripStatusLabel2.Text = @"Поточний час: " + DateTime.Now.ToShortTimeString();
    }

    private Dictionary<string, decimal> GetAccountBalances()
    {
        var connection = new DbConnect();
        var balances = new Dictionary<string, decimal>();

        const string query =
            "SELECT account_type, balance FROM Accounts WHERE user_id = (SELECT user_id FROM Users WHERE username = @Username)";
        var command = new SqlCommand(query, connection.GetConnection());
        command.Parameters.AddWithValue("@Username", _username);

        connection.Open();
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read()) balances.Add(reader.GetString(0), reader.GetDecimal(1));
        }

        connection.Close();
        return balances;
    }

    private void Main_User_FormClosed(object sender, FormClosedEventArgs e)
    {
        Application.Exit();
    }


    private void Exit_Click(object sender, EventArgs e)
    {
        var result = MessageBox.Show(@"Ви дійсно бажаєте вийти з акаунту?", @"Підтвердження", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
        if (result != DialogResult.Yes) return;
        var login = new Login();
        login.Show();
        Hide();
    }

    private void Main_User_Shown(object sender, EventArgs e)
    {
        var connection = new DbConnect();
        var query = "SELECT user_id FROM Users WHERE username = @Username";
        var command = new SqlCommand(query, connection.GetConnection());
        command.Parameters.AddWithValue("@Username", _username);
        connection.Open();
        var reader = command.ExecuteReader();
        reader.Read();
        query = "SELECT COUNT(*) FROM Accounts WHERE user_id = @UserID";
        command = new SqlCommand(query, connection.GetConnection());
        command.Parameters.AddWithValue("@UserID", reader.GetValue(0));
        reader.Close();
        if ((int)command.ExecuteScalar() == 0)
            MessageBox.Show(
                """У вас досі не створений рахунок, натисність "Мої рахунки"->"Створити рахунок", щоб створити його""",
                @"Відстутній рахунок", MessageBoxButtons.OK, MessageBoxIcon.Information);
        connection.Close();
    }

    private void Transactions_Click(object sender, EventArgs e)
    {
        var transactions = new Transactions(_username, false);
        transactions.ShowDialog();
    }

    private void About_Click(object sender, EventArgs e)
    {
        var about = new About();
        about.ShowDialog();
    }

    private void CreateAccount_Click(object sender, EventArgs e)
    {
        var createAccount = new CreateAccount(_username);
        createAccount.ShowDialog();
    }

    private void CheckAccounts_Click(object sender, EventArgs e)
    {
        var accounts = new Accounts(_username);
        accounts.ShowDialog();
    }

    private void OnlineHelp_Click(object sender, EventArgs e)
    {
        const string htmlFilePath = @"..\..\about\index.html";
        try
        {
            Process.Start(new ProcessStartInfo(htmlFilePath) { UseShellExecute = true });
        }
        catch (Win32Exception noBrowser)
        {
            if (noBrowser.ErrorCode == -2147467259)
                Console.WriteLine(noBrowser.Message);
        }
        catch (Exception other)
        {
            Console.WriteLine(other.Message);
        }
    }

    private void Recipients_Click(object sender, EventArgs e)
    {
        var recipients = new Recipients(_username);
        recipients.ShowDialog();
    }

    private void CreateTransaction_Click(object sender, EventArgs e)
    {
        var createTransaction = new CreateTransaction(_username);
        createTransaction.ShowDialog();
    }
}
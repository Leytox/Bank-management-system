using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace CourseWork;

public partial class Transactions : Form
{
    private readonly bool _isAdmin;
    private readonly string _username;

    public Transactions(string username, bool isAdmin)
    {
        InitializeComponent();
        _username = username;
        _isAdmin = isAdmin;
    }

    private void Transactions_Load(object sender, EventArgs e)
    {
        // TODO: This line of code loads data into the 'bankDataSet.Transactions' table. You can move, or remove it, as needed.
        transactionsTableAdapter.Fill(bankDataSet.Transactions);
        if (!_isAdmin)
        {
            SenderIdTextBox.Visible = false;
            label2.Visible = false;
        }

        var connection = new DbConnect();
        var command = new SqlCommand(
            _isAdmin
                ? "SELECT * FROM Transactions"
                : "SELECT * FROM Transactions WHERE sender_account_id IN (SELECT account_id FROM Accounts WHERE user_id = (SELECT user_id FROM Users WHERE username = @Username))",
            connection.GetConnection());
        command.Parameters.AddWithValue("@Username", _username);
        connection.Open();
        var reader = command.ExecuteReader();
        var dataTable = new DataTable();
        dataTable.Load(reader);
        dataGridView1.DataSource = dataTable;
        reader.Close();
        connection.Close();
    }

    private void FindTransactionsAdmin()
    {
        var connection = new DbConnect();
        connection.Open();
        var transactionId = TransactionIdTextBox.Text;
        var senderId = SenderIdTextBox.Text;
        var recipientId = RecipientIdTextBox.Text;
        var description = DescriptionTextBox.Text;

        decimal? amount1 = null;
        if (decimal.TryParse(Amount1TextBox.Text, out var tempAmount1)) amount1 = tempAmount1;

        decimal? amount2 = null;
        if (decimal.TryParse(Amount2TextBox.Text, out var tempAmount2)) amount2 = tempAmount2;

        DateTime? date1 = dateTimePicker1.Value;
        DateTime? date2 = dateTimePicker2.Value;

        const string query = "SELECT * FROM Transactions WHERE " +
                             "(transaction_id LIKE '%' + @transactionId + '%' OR @transactionId = '') " +
                             "AND (sender_account_id LIKE '%' + @senderId + '%' OR @senderId = '') " +
                             "AND (recipient_account_number LIKE '%' + @recipientId + '%' OR @recipientId = '') " +
                             "AND (@amount1 IS NULL OR @amount2 IS NULL OR amount BETWEEN @amount1 AND @amount2) " +
                             "AND (description LIKE '%' + @description + '%' OR @description = '') " +
                             "AND (@date1 IS NULL OR @date2 IS NULL OR transaction_date BETWEEN @date1 AND @date2)";

        var command = new SqlCommand(query, connection.GetConnection());
        command.Parameters.AddWithValue("@transactionId", transactionId);
        command.Parameters.AddWithValue("@senderId", senderId);
        command.Parameters.AddWithValue("@recipientId", recipientId);
        command.Parameters.AddWithValue("@description", description);

        command.Parameters.AddWithValue("@amount1", amount1.HasValue ? amount1.Value : DBNull.Value);
        command.Parameters.AddWithValue("@amount2", amount2.HasValue ? amount2.Value : DBNull.Value);
        command.Parameters.AddWithValue("@date1", date1.Value);
        command.Parameters.AddWithValue("@date2", date2.Value);

        var reader = command.ExecuteReader();
        var dataTable = new DataTable();
        dataTable.Load(reader);
        dataGridView1.DataSource = dataTable;
        reader.Close();
        connection.Close();
    }

    private void FindTransactionsUser()
    {
        var connection = new DbConnect();
        connection.Open();
        var transactionId = TransactionIdTextBox.Text;
        var recipientId = RecipientIdTextBox.Text;
        var description = DescriptionTextBox.Text;

        decimal? amount1 = null;
        if (decimal.TryParse(Amount1TextBox.Text, out var tempAmount1)) amount1 = tempAmount1;

        decimal? amount2 = null;
        if (decimal.TryParse(Amount2TextBox.Text, out var tempAmount2)) amount2 = tempAmount2;

        DateTime? date1 = dateTimePicker1.Value;
        DateTime? date2 = dateTimePicker2.Value;

        const string query = "SELECT * FROM Transactions WHERE " +
                             "(transaction_id LIKE '%' + @transactionId + '%' OR @transactionId = '') " +
                             "AND (sender_account_id IN (SELECT account_id FROM Accounts WHERE user_id = (SELECT user_id FROM Users WHERE username = @Username))) " +
                             "AND (recipient_account_number LIKE '%' + @recipientId + '%' OR @recipientId = '') " +
                             "AND (@amount1 IS NULL OR @amount2 IS NULL OR amount BETWEEN @amount1 AND @amount2) " +
                             "AND (description LIKE '%' + @description + '%' OR @description = '') " +
                             "AND (@date1 IS NULL OR @date2 IS NULL OR transaction_date BETWEEN @date1 AND @date2)";

        var command = new SqlCommand(query, connection.GetConnection());
        command.Parameters.AddWithValue("@transactionId", transactionId);
        command.Parameters.AddWithValue("@Username", _username);
        command.Parameters.AddWithValue("@recipientId", recipientId);
        command.Parameters.AddWithValue("@description", description);

        command.Parameters.AddWithValue("@amount1", amount1.HasValue ? amount1.Value : DBNull.Value);
        command.Parameters.AddWithValue("@amount2", amount2.HasValue ? amount2.Value : DBNull.Value);
        command.Parameters.AddWithValue("@date1", date1.Value);
        command.Parameters.AddWithValue("@date2", date2.Value);

        var reader = command.ExecuteReader();
        var dataTable = new DataTable();
        dataTable.Load(reader);
        dataGridView1.DataSource = dataTable;
        reader.Close();
        connection.Close();
    }

    private void TransactionIdTextBox_TextChanged(object sender, EventArgs e)
    {
        if (_isAdmin)
            FindTransactionsAdmin();
        else
            FindTransactionsUser();
    }

    private void SenderIdTextBox_TextChanged(object sender, EventArgs e)
    {
        if (_isAdmin)
            FindTransactionsAdmin();
        else
            FindTransactionsUser();
    }

    private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
    {
        if (_isAdmin)
            FindTransactionsAdmin();
        else
            FindTransactionsUser();
    }

    private void RecipientIdTextBox_TextChanged(object sender, EventArgs e)
    {
        if (_isAdmin)
            FindTransactionsAdmin();
        else
            FindTransactionsUser();
    }

    private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
    {
        if (_isAdmin)
            FindTransactionsAdmin();
        else
            FindTransactionsUser();
    }

    private void DescriptionTextBox_TextChanged(object sender, EventArgs e)
    {
        if (_isAdmin)
            FindTransactionsAdmin();
        else
            FindTransactionsUser();
    }

    private void Amount1TextBox_TextChanged(object sender, EventArgs e)
    {
        if (_isAdmin)
            FindTransactionsAdmin();
        else
            FindTransactionsUser();
    }

    private void Amount2TextBox_TextChanged(object sender, EventArgs e)
    {
        if (_isAdmin)
            FindTransactionsAdmin();
        else
            FindTransactionsUser();
    }

    private void ClearFiltersButton_Click(object sender, EventArgs e)
    {
        TransactionIdTextBox.Text = "";
        SenderIdTextBox.Text = "";
        RecipientIdTextBox.Text = "";
        DescriptionTextBox.Text = "";
        Amount1TextBox.Text = "";
        Amount2TextBox.Text = "";
        dateTimePicker1.Value = DateTime.Now;
        dateTimePicker2.Value = DateTime.Now;
        if (_isAdmin)
            FindTransactionsAdmin();
        else
            FindTransactionsUser();
    }


    private void CreatePdfReport()
    {
        try
        {
            var reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.LocalReport.ReportPath = "../../Transactions.rdlc";
            var connection = new DbConnect();
            var command = new SqlCommand(_isAdmin
                    ? "SELECT * FROM Transactions"
                    : "SELECT * FROM Transactions WHERE sender_account_id IN (SELECT account_id FROM Accounts WHERE user_id = (SELECT user_id FROM Users WHERE username = @Username))",
                connection.GetConnection());
            command.Parameters.AddWithValue("@Username", _username);
            connection.Open();
            var reader = command.ExecuteReader();
            var dataTable = new DataTable();
            dataTable.Load(reader);
            var reportDataSource = new ReportDataSource("DataSet1", dataTable);
            reportViewer.LocalReport.DataSources.Add(reportDataSource);
            reportViewer.LocalReport.Refresh();
            var bytes = reportViewer.LocalReport.Render("PDF");
            connection.Close();
            File.WriteAllBytes("TransactionsReport.pdf", bytes);
            MessageBox.Show(@"Звіт створено", @"Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

            const string filePath = "TransactionsReport.pdf";
            if (File.Exists(filePath))
                try
                {
                    Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(@$"Неможливо відкрити звіт у браузері, помилка: {ex.Message}");
                }
            else
                MessageBox.Show(@"Звіт не існує");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void GenerateReport_Click(object sender, EventArgs e)
    {
        CreatePdfReport();
    }
}
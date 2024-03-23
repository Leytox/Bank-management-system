using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CourseWork;

public partial class MainAdmin : Form
{
    private readonly string _username;
    private Timer? _timer;

    public MainAdmin(string username)
    {
        InitializeComponent();
        _username = username;
    }

    private void MainAdmin_FormClosed(object sender, FormClosedEventArgs e)
    {
        Application.Exit();
    }

    private void ExitClick(object sender, EventArgs e)
    {
        var dialogResult = MessageBox.Show(@"Ви впевнені, що хочете вийти?", @"Вихід", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
        if (dialogResult == DialogResult.Yes)
            Application.Exit();
    }

    private void UsersClick(object sender, EventArgs e)
    {
        Users users = new();
        users.ShowDialog();
    }

    private void Transactions_Click(object sender, EventArgs e)
    {
        Transactions transactions = new("", true);
        transactions.ShowDialog();
    }

    private void Logs_Click(object sender, EventArgs e)
    {
        Logs logs = new();
        logs.ShowDialog();
    }

    private void MainAdmin_Load(object sender, EventArgs e)
    {
        var connection = new DbConnect();
        connection.Open();
        SqlCommand command = new("SELECT first_name FROM Admins WHERE username = @Username",
            connection.GetConnection());
        command.Parameters.AddWithValue("@Username", _username);
        var reader = command.ExecuteReader();
        reader.Read();
        label1.Text = @"Вітаємо, " + reader.GetString(0) + @"!";
        ActiveAdmin.Text = @"Ви увійшли як: " + _username;
        CurrentTime.Text = @"Поточний час: " + DateTime.Now.ToShortTimeString();

        _timer = new Timer { Interval = 5000 };
        _timer.Tick += BalanceTimer_Tick;
        _timer.Start();
    }

    private void BalanceTimer_Tick(object sender, EventArgs e)
    {
        CurrentTime.Text = @"Поточний час: " + DateTime.Now.ToShortTimeString();
    }
}
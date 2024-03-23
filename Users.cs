using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace CourseWork;

public partial class Users : Form
{
    public Users()
    {
        InitializeComponent();
    }

    private void Users_Load(object sender, EventArgs e)
    {
        var connection = new DbConnect();
        var command = new SqlCommand("SELECT * FROM Users", connection.GetConnection());
        connection.Open();
        var reader = command.ExecuteReader();
        var dataTable = new DataTable();
        dataTable.Load(reader);
        dataTable.Columns.Remove("password");
        dataTable.Columns.Remove("ipn");
        dataGridView1.DataSource = dataTable;
        reader.Close();
        connection.Close();
    }

    private void FindUsers()
    {
        var connection = new DbConnect();
        connection.Open();
        var userId = textBox1.Text;
        var username = textBox2.Text;
        var email = textBox3.Text;
        var name = textBox4.Text;
        var lName = textBox5.Text;
        var number = textBox6.Text;
        const string query = "SELECT * FROM Users WHERE " +
                             "(user_id LIKE '%' + @userId + '%' OR @userId = '') " +
                             "AND (username LIKE '%' + @username + '%' OR @username = '') " +
                             "AND (email LIKE '%' + @email + '%' OR @email = '') " +
                             "AND (first_name LIKE '%' + @name + '%' OR @name = '') " +
                             "AND (last_name LIKE '%' + @lName + '%' OR @lName = '') " +
                             "AND (phone_number LIKE '%' + @number + '%' OR @number = '')";

        var command = new SqlCommand(query, connection.GetConnection());
        command.Parameters.AddWithValue("@userId", userId);
        command.Parameters.AddWithValue("@username", username);
        command.Parameters.AddWithValue("@email", email);
        command.Parameters.AddWithValue("@name", name);
        command.Parameters.AddWithValue("@lName", lName);
        command.Parameters.AddWithValue("@number", number);
        var reader = command.ExecuteReader();
        var dataTable = new DataTable();
        dataTable.Load(reader);
        dataTable.Columns.Remove("password");
        dataTable.Columns.Remove("ipn");
        dataGridView1.DataSource = dataTable;
        reader.Close();
        connection.Close();
    }


    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        FindUsers();
    }

    private void textBox2_TextChanged(object sender, EventArgs e)
    {
        FindUsers();
    }

    private void textBox3_TextChanged(object sender, EventArgs e)
    {
        FindUsers();
    }

    private void textBox4_TextChanged(object sender, EventArgs e)
    {
        FindUsers();
    }

    private void textBox5_TextChanged(object sender, EventArgs e)
    {
        FindUsers();
    }

    private void textBox6_TextChanged(object sender, EventArgs e)
    {
        FindUsers();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        textBox1.Text = "";
        textBox2.Text = "";
        textBox3.Text = "";
        textBox4.Text = "";
        textBox5.Text = "";
        textBox6.Text = "";
        FindUsers();
    }

    private void CreatePdfReport()
    {
        try
        {
            var reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.LocalReport.ReportPath = "../../Users.rdlc";
            var connection = new DbConnect();
            var command = new SqlCommand("SELECT * FROM Users", connection.GetConnection());
            connection.Open();
            var reader = command.ExecuteReader();
            var dataTable = new DataTable();
            dataTable.Load(reader);
            var reportDataSource = new ReportDataSource("DataSet1", dataTable);
            reportViewer.LocalReport.DataSources.Add(reportDataSource);
            reportViewer.LocalReport.Refresh();
            var bytes = reportViewer.LocalReport.Render("PDF");
            connection.Close();
            File.WriteAllBytes("UsersReport.pdf", bytes);
            MessageBox.Show(@"Звіт створено", @"Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

            const string filePath = "UsersReport.pdf";
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
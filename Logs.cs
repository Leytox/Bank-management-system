using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace CourseWork;

public partial class Logs : Form
{
    public Logs()
    {
        InitializeComponent();
    }

    private void Logs_Load(object sender, EventArgs e)
    {
        var connection = new DbConnect();
        connection.Open();
        var command = new SqlCommand("SELECT * FROM LoginHistory", connection.GetConnection());
        var reader = command.ExecuteReader();
        var dataTable = new DataTable();
        dataTable.Load(reader);
        dataGridView1.DataSource = dataTable;
        reader.Close();
        connection.Close();
    }

    private void FindLogs()
    {
        var connection = new DbConnect();
        connection.Open();
        var dateFrom = dateTimePicker1.Value.ToString("yyyy-MM-dd");
        var dateTo = dateTimePicker2.Value.ToString("yyyy-MM-dd");
        var query =
            "SELECT * FROM LoginHistory WHERE (@log_id IS NULL OR log_id LIKE @log_id) AND (@result IS NULL OR result = @result) AND (login_time BETWEEN @dateFrom AND @dateTo)";
        var command = new SqlCommand(query, connection.GetConnection());
        command.Parameters.AddWithValue("@log_id",
            string.IsNullOrEmpty(textBox1.Text) ? DBNull.Value : textBox1.Text);
        command.Parameters.AddWithValue("@result", checkBox1.Checked ? "Success" : DBNull.Value);
        command.Parameters.AddWithValue("@dateFrom", dateFrom);
        command.Parameters.AddWithValue("@dateTo", dateTo);
        var reader = command.ExecuteReader();
        var dataTable = new DataTable();
        dataTable.Load(reader);
        dataGridView1.DataSource = dataTable;
        reader.Close();
        connection.Close();
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        FindLogs();
    }

    private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
    {
        FindLogs();
    }

    private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
    {
        FindLogs();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        textBox1.Text = "";
        checkBox1.Checked = false;
        dateTimePicker1.Value = DateTime.Now;
        dateTimePicker2.Value = DateTime.Now;
        var connection = new DbConnect();
        connection.Open();
        var command = new SqlCommand("SELECT * FROM LoginHistory", connection.GetConnection());
        var reader = command.ExecuteReader();
        var dataTable = new DataTable();
        dataTable.Load(reader);
        dataGridView1.DataSource = dataTable;
        reader.Close();
        connection.Close();
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        FindLogs();
    }

    private void CreatePdfReport()
    {
        try
        {
            var reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.LocalReport.ReportPath = "../../Logs.rdlc";
            var connection = new DbConnect();
            var command = new SqlCommand("SELECT * FROM LoginHistory", connection.GetConnection());
            connection.Open();
            var reader = command.ExecuteReader();
            var dataTable = new DataTable();
            dataTable.Load(reader);
            var reportDataSource = new ReportDataSource("DataSet1", dataTable);
            reportViewer.LocalReport.DataSources.Add(reportDataSource);
            reportViewer.LocalReport.Refresh();
            var bytes = reportViewer.LocalReport.Render("PDF");
            connection.Close();
            File.WriteAllBytes("LogsReport.pdf", bytes);
            MessageBox.Show(@"Звіт створено", @"Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

            const string filePath = "LogsReport.pdf";
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
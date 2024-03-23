using System;
using System.Data;
using System.Data.SqlClient;

namespace CourseWork;

internal class DbConnect : IDisposable
{
    private const string ConnectionString =
        @"Data Source=DESKTOP-Q6AK4P6\SQLEXPRESS;Initial Catalog=Bank;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

    private readonly SqlConnection _connection = new(ConnectionString);

    public void Dispose()
    {
        _connection.Dispose();
    }

    public void Open()
    {
        try
        {
            _connection.Open();
        }
        catch (SqlException ex)
        {
            Console.WriteLine($@"Error opening database connection: {ex.Message}");
        }
    }

    public void Close()
    {
        _connection.Close();
    }

    public SqlConnection GetConnection()
    {
        return _connection;
    }

    public bool IsOpened()
    {
        return _connection.State == ConnectionState.Open;
    }
}
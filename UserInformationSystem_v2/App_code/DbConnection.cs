using System;
using System.Data.SqlClient;

public class DbConnection
{
    public SqlConnection conn;

    public void Open()
    {
        try
        {
            conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UserInfoDB;Integrated Security=True;Encrypt=True");
            conn.Open();
        }
        catch (Exception ex)
        {
            throw new Exception("Database connection error: " + ex.Message);
        }
    }

    public void Close()
    {
        if (conn != null && conn.State == System.Data.ConnectionState.Open)
        {
            conn.Close();
        }
    }
}

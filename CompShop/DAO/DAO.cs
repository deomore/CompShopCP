using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace CompShop.DAO
{
    public class DAO
    { 
    public string ConnectionString = @"Data Source =(localdb)\MSSQLLocalDB;Initial Catalog=CS;Integrated Security=True";
    public SqlConnection Connection { get; set; }
    public void Connect()
    {
        Connection = new SqlConnection(ConnectionString);
        Connection.Open();
    }
    public void Disconnect()
    {
        Connection.Close();
    }
}
}
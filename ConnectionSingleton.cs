using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
public static class ConnectionSingleton
{
    static SqlConnection conn;
    public static SqlConnection GetConnection()
    {
        if (conn == null)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder["Data Source"] = "CUC-CUC-CUTE\\SQLEXPRESS";
            builder["integrated Security"] = true;
            builder["Initial Catalog"] = "data";
            builder.UserID = "";
            conn = new SqlConnection(builder.ConnectionString);
            conn.Open();
            return conn;
        }
        else
            return conn;
    }
}
    
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de BaseRepository
/// </summary>
public abstract class BaseRepository
{
    private string ConnStr = ConfigurationManager.ConnectionStrings["LocalSQLServer"].ConnectionString;

    protected SqlConnection GetConnection()
    {
        SqlConnection conn = new SqlConnection(connectionString: ConnStr);
        return conn;
    }

    protected void CloseAll(SqlConnection conn, SqlDataReader reader)
    {
        if (conn != null)
        {
            conn.Close();
        }

        if (reader != null)
        {
            reader.Close();
        }
    }

    protected string GetString(SqlDataReader reader, int position)
    {
        if (!reader.IsDBNull(position))
        {
            return reader.GetString(position);
        }
        else
        {
            return null;
        }
    }
}
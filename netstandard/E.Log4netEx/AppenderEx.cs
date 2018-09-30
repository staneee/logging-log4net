using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Pomelo.Data.MySql;
using Npgsql;

namespace E.Log4netEx
{
    /// <summary>
    /// Log4net Appender extension
    /// </summary>
    public static class AppenderEx
    {
        /// <summary>
        /// Create database connection
        /// </summary>
        /// <param name="connectionString">Database connectionString</param>
        /// <param name="connectionType">Database connectionType(sqlserver,pgsql,sqlite,mysql;default value 'sqlserver')</param>
        /// <returns>Database connection instance</returns>
        public static IDbConnection CreateConnection(string connectionString, string connectionType = "sqlserver")
        {
            IDbConnection connection = null;
            switch (connectionType.ToLower())
            {
                case "mysql":
                    connection = new MySqlConnection();
                    break;
                case "pgsql":
                    connection = new NpgsqlConnection();
                    break;
                case "sqlite":
                    connection = new SqliteConnection();
                    break;
                case "sqlserver":
                default:
                    connection = new SqlConnection();
                    break;
            }
            connection.ConnectionString = connectionString;
            return connection;
        }
    }
}

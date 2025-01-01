using System;
using Microsoft.Data.SqlClient;

namespace Memory_Game.Database
{
    public static class DatabaseConnection
    {
        public static SqlConnection GetConnection()
        {
            string host = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "1433";
            string database = Environment.GetEnvironmentVariable("DATABASE_NAME") ?? "MemoryGameDB";
            string username = Environment.GetEnvironmentVariable("DATABASE_USER") ?? "sa";
            string password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? "root";

            string connectionString = $"Server={host},{port};Database={database};User Id={username};Password={password};Encrypt=false;";
            return new SqlConnection(connectionString);
        }
    }
}

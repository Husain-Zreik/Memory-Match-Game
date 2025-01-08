using System.Text;
using Memory_Game.Database;
using Memory_Game.Models;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;

namespace Memory_Game.Controllers
{
    public class UserController
    {
        public static bool AddUser(string username, string password, int age)
        {
            string hashedPassword = HashPassword(password);

            using var connection = DatabaseConnection.GetConnection();
            string query = "INSERT INTO Users (Username, Password, Age, CreatedAt) VALUES (@Username, @Password, @Age, @CreatedAt)";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", hashedPassword);
            command.Parameters.AddWithValue("@Age", age);
            command.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
            connection.Open();
            return command.ExecuteNonQuery() > 0;
        }

        private static string HashPassword(string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = SHA256.HashData(passwordBytes);
            return Convert.ToBase64String(hashBytes);
        }

        public static bool IsUsernameTaken(string username)
        {
            using var connection = DatabaseConnection.GetConnection();
            string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", username);
            connection.Open();
            return (int)command.ExecuteScalar() > 0;
        }

        public static User? GetUser(string username, string password)
        {
            using var connection = DatabaseConnection.GetConnection();
            string query = "SELECT * FROM Users WHERE Username = @Username";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", username);
            connection.Open();
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                var storedHashedPassword = reader["Password"].ToString();

                if (HashPassword(password) == storedHashedPassword)
                {
                    return new User
                    {
                        Id = (int)reader["Id"],
                        Username = reader["Username"].ToString(),
                        Password = storedHashedPassword,
                        CreatedAt = (DateTime)reader["CreatedAt"],
                        Age = (int)reader["Age"]
                    };
                }
            }
            return null;
        }
        public static bool ValidateLogin(string username, string password)
        {
            User? user = GetUser(username, password);
            return user != null;
        }
    }
}

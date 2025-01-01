using Memory_Game.Models;
using Memory_Game.Database;
using Microsoft.Data.SqlClient;

namespace Memory_Game.Controllers
{
    public class UserController
    {
        public static bool AddUser(string username, string password)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = "INSERT INTO Users (Username, Password) VALUES (@Username, @Password)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public static User GetUser(string username, string password)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                Id = (int)reader["Id"],
                                Username = reader["Username"].ToString(),
                                Password = reader["Password"].ToString(),
                                CreatedAt = (DateTime)reader["CreatedAt"]
                            };
                        }
                        return null;
                    }
                }
            }
        }
    }
}

using Microsoft.Data.SqlClient;
using Memory_Game.Models;
using Memory_Game.Database;

namespace Memory_Game.Controllers
{
    public class RateController
    {
        public static bool AddRate(int userId, int rating)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = "INSERT INTO Rate (UserId, Rating) VALUES (@UserId, @Rating)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@Rating", rating);
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public static double GetAverageRating()
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT AVG(Rating) AS AverageRating FROM Rate";
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    return Convert.ToDouble(command.ExecuteScalar() ?? 0);
                }
            }
        }
    }
}

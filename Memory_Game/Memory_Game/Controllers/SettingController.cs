using Microsoft.Data.SqlClient;
using Memory_Game.Models;
using Memory_Game.Database;

namespace Memory_Game.Controllers
{
    public class SettingController
    {
        public static bool AddOrUpdateSetting(int userId, int maxLevels, int timeLimitSeconds, string difficulty)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = @"
                IF EXISTS (SELECT 1 FROM Settings WHERE UserId = @UserId)
                BEGIN
                    UPDATE Settings 
                    SET MaxLevels = @MaxLevels, TimeLimitSeconds = @TimeLimitSeconds, Difficulty = @Difficulty 
                    WHERE UserId = @UserId
                END
                ELSE
                BEGIN
                    INSERT INTO Settings (UserId, MaxLevels, TimeLimitSeconds, Difficulty) 
                    VALUES (@UserId, @MaxLevels, @TimeLimitSeconds, @Difficulty)
                END";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@MaxLevels", maxLevels);
                    command.Parameters.AddWithValue("@TimeLimitSeconds", timeLimitSeconds);
                    command.Parameters.AddWithValue("@Difficulty", difficulty);
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public static Setting GetSetting(int userId)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM Settings WHERE UserId = @UserId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Setting
                            {
                                Id = (int)reader["Id"],
                                UserId = (int)reader["UserId"],
                                MaxLevels = (int)reader["MaxLevels"],
                                TimeLimitSeconds = (int)reader["TimeLimitSeconds"],
                                Difficulty = reader["Difficulty"].ToString()
                            };
                        }
                        return null;
                    }
                }
            }
        }
    }
}

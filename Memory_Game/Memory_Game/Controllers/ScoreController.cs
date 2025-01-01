using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Memory_Game.Models;
using Memory_Game.Database;

namespace Memory_Game.Controllers
{
    public class ScoreController
    {
        public static bool AddScore(int userId, int scoreValue, int level)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = "INSERT INTO Scores (UserId, Score, Level) VALUES (@UserId, @Score, @Level)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@Score", scoreValue);
                    command.Parameters.AddWithValue("@Level", level);
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public static List<Score> GetScoresByUser(int userId)
        {
            var scores = new List<Score>();
            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM Scores WHERE UserId = @UserId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            scores.Add(new Score
                            {
                                Id = (int)reader["Id"],
                                UserId = (int)reader["UserId"],
                                ScoreValue = (int)reader["Score"],
                                Level = (int)reader["Level"],
                                AchievedAt = (DateTime)reader["AchievedAt"]
                            });
                        }
                    }
                }
            }
            return scores;
        }

        public static bool DeleteScore(int scoreId)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = "DELETE FROM Scores WHERE Id = @ScoreId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ScoreId", scoreId);
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}

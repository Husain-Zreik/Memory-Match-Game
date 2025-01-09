using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Memory_Game.Models;
using Memory_Game.Database;

namespace Memory_Game.Controllers
{
    public class ScoreController
    {
        // Add a score for a user
        public static bool AddScore(int userId, int scoreValue, int level)
        {
            using var connection = DatabaseConnection.GetConnection();
            string query = "INSERT INTO Scores (UserId, Score, Level) VALUES (@UserId, @Score, @Level)";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserId", userId);
            command.Parameters.AddWithValue("@Score", scoreValue);
            command.Parameters.AddWithValue("@Level", level);
            connection.Open();
            return command.ExecuteNonQuery() > 0;
        }

        // Get all scores of a user, sorted by date
        public static List<Score> GetAllScoresByUser(int userId)
        {
            var scores = new List<Score>();
            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM Scores WHERE UserId = @UserId ORDER BY AchievedAt DESC";
                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", userId);
                connection.Open();
                using var reader = command.ExecuteReader();
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
            return scores;
        }

        // Get the high score for each user, sorted by score
        public static List<Score> GetHighScoresForAllUsers()
        {
            var highScores = new List<Score>();
            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = @"
            WITH RankedScores AS (
                SELECT 
                    s.UserId,
                    s.Score AS HighScore,
                    s.Level,
                    s.AchievedAt,
                    ROW_NUMBER() OVER (
                        PARTITION BY s.UserId 
                        ORDER BY s.Level DESC, s.Score DESC, s.AchievedAt DESC
                    ) AS Rank
                FROM Scores s
            )
            SELECT UserId, HighScore, Level, AchievedAt
            FROM RankedScores
            WHERE Rank = 1
            ORDER BY HighScore DESC, Level DESC;";

                using var command = new SqlCommand(query, connection);
                connection.Open();
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    highScores.Add(new Score
                    {
                        UserId = (int)reader["UserId"],
                        ScoreValue = (int)reader["HighScore"],
                        Level = (int)reader["Level"],
                        AchievedAt = (DateTime)reader["AchievedAt"]
                    });
                }
            }
            return highScores;
        }


        // Delete a specific score by its ID
        public static bool DeleteScore(int scoreId)
        {
            using var connection = DatabaseConnection.GetConnection();
            string query = "DELETE FROM Scores WHERE Id = @ScoreId";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ScoreId", scoreId);
            connection.Open();
            return command.ExecuteNonQuery() > 0;
        }

        // Method to reset all scores (clear all entries from the Scores table)
        public static bool ResetAllScores()
        {
            using var connection = DatabaseConnection.GetConnection();
            string query = "DELETE FROM Scores"; // Delete all scores in the Scores table
            using var command = new SqlCommand(query, connection);
            connection.Open();
            return command.ExecuteNonQuery() > 0;
        }

    }
}

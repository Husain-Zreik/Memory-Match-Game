using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Memory_Game.Models;
using Memory_Game.Database;
using Image = Memory_Game.Models.Image;

namespace Memory_Game.Controllers
{
    public class ImageController
    {
        public static bool AddImage(int userId, string imagePath)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = "INSERT INTO Images (UserId, ImagePath) VALUES (@UserId, @ImagePath)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@ImagePath", imagePath);
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public static List<Image> GetImagesByUser(int userId)
        {
            var images = new List<Image>();
            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM Images WHERE UserId = @UserId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            images.Add(new Image
                            {
                                Id = (int)reader["Id"],
                                UserId = (int)reader["UserId"],
                                ImagePath = reader["ImagePath"].ToString(),
                                UploadedAt = (DateTime)reader["UploadedAt"]
                            });
                        }
                    }
                }
            }
            return images;
        }

        public static bool DeleteImage(int imageId)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                string query = "DELETE FROM Images WHERE Id = @ImageId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ImageId", imageId);
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}

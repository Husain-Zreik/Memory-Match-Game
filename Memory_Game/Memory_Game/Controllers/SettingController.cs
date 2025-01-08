using Microsoft.Data.SqlClient;
using Memory_Game.Models;
using Memory_Game.Database;
using System;
using System.Collections.Generic;

namespace Memory_Game.Controllers
{
    public class SettingController
    {
        public static List<Setting> GetSettings()
        {
            var settings = new List<Setting>();

            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                var query = "SELECT SettingName, SettingValue FROM Settings";

                using var command = new SqlCommand(query, connection);
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var setting = new Setting
                    {
                        SettingName = reader.GetString(0),
                        SettingValue = reader.GetString(1)
                    };
                    settings.Add(setting);
                }
            }

            return settings;
        }
    }
}

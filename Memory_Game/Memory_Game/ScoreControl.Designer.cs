using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Memory_Game
{
    public partial class ScoreControl : UserControl
    {
        public string CurrentPlayer { get; set; }
        public int CurrentPlayerScore { get; set; }
        public Dictionary<string, PlayerScore> PlayerScores { get; private set; }

        private readonly string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MemoryGame");
        private readonly string scoreFilePath;

        private Label lblTitle;
        private ListBox lstScores;
        private Button btnResetScores;
        private Label lblCurrentPlayerScore;

        public ScoreControl(string currentPlayer)
        {
            InitializeComponent();
            scoreFilePath = Path.Combine(directoryPath, "scores.json");

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            PlayerScores = LoadScores();
            CurrentPlayer = currentPlayer;

            if (PlayerScores.TryGetValue(currentPlayer, out PlayerScore playerScore))
                CurrentPlayerScore = playerScore.Score;
            else
                CurrentPlayerScore = 0;

            UpdateCurrentPlayerDisplay();
            LoadScoresDisplay();
        }

        private void InitializeComponent()
        {
            lblTitle = new Label
            {
                Text = "Score Board:",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                Location = new Point(30, 20),
                AutoSize = true,
                ForeColor = Color.Black
            };

            lstScores = new ListBox
            {
                FormattingEnabled = true,
                ItemHeight = 20,
                Location = new Point(30, 80),
                Size = new Size(720, 400),
                Font = new Font("Consolas", 12F, FontStyle.Regular)
            };

            btnResetScores = new Button
            {
                Text = "Reset Scores",
                Location = new Point(600, 500),
                Size = new Size(150, 40),
                BackColor = Color.FromArgb(45, 45, 48),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnResetScores.Click += BtnResetScores_Click;

            lblCurrentPlayerScore = new Label
            {
                Location = new Point(30, 500),
                Size = new Size(500, 30),
                Font = new Font("Segoe UI", 12F),
                Text = "Current Player: Not Set | Score: 0",
                ForeColor = Color.Black
            };

            Controls.Add(lblTitle);
            Controls.Add(lstScores);
            Controls.Add(lblCurrentPlayerScore);
            Controls.Add(btnResetScores);

            Name = "ScoreControl";
            Size = new Size(800, 550);
            BackColor = Color.FromArgb(240, 240, 240);
        }

        private Dictionary<string, PlayerScore> LoadScores()
        {
            if (File.Exists(scoreFilePath))
            {
                try
                {
                    var json = File.ReadAllText(scoreFilePath);
                    var scores = JsonConvert.DeserializeObject<Dictionary<string, PlayerScore>>(json);
                    return scores ?? new Dictionary<string, PlayerScore>();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error loading scores: {ex.Message}");
                }
            }
            return new Dictionary<string, PlayerScore>();
        }

        private void LoadScoresDisplay()
        {
            lstScores.Items.Clear();
            foreach (var playerScore in PlayerScores)
            {
                string displayText = $"{playerScore.Key.PadRight(20)}{playerScore.Value.Score.ToString().PadLeft(10)} points";
                lstScores.Items.Add(displayText);
            }
        }

        private void UpdateCurrentPlayerDisplay()
        {
            lblCurrentPlayerScore.Text = $"Current Player: {CurrentPlayer} | Score: {CurrentPlayerScore}";
        }

        private void BtnResetScores_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to reset all scores? This action cannot be undone.",
                "Reset Scores",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (File.Exists(scoreFilePath))
                        File.Delete(scoreFilePath);

                    PlayerScores.Clear();
                    CurrentPlayerScore = 0;
                    UpdateCurrentPlayerDisplay();
                    LoadScoresDisplay();
                    MessageBox.Show("Scores have been reset successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error deleting scores file: {ex.Message}");
                    MessageBox.Show($"An error occurred while resetting scores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void SaveScore(string playerName, int score, int level)
        {
            PlayerScores = LoadScores();

            if (PlayerScores.ContainsKey(playerName))
            {
                PlayerScores[playerName].Score = score;
                PlayerScores[playerName].Level = level;
            }
            else
            {
                PlayerScores.Add(playerName, new PlayerScore { PlayerName = playerName, Score = score, Level = level });
            }

            SaveScoresToFile();
        }

        private void SaveScoresToFile()
        {
            try
            {
                string json = JsonConvert.SerializeObject(PlayerScores, Formatting.Indented);
                File.WriteAllText(scoreFilePath, json);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error saving scores: {ex.Message}");
            }
        }
    }

    public class PlayerScore
    {
        public string PlayerName { get; set; }
        public int Score { get; set; }
        public int Level { get; set; }
    }
}

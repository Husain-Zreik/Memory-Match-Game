using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Memory_Game.Controllers;
using Memory_Game.Models;

namespace Memory_Game.Views
{
    public partial class ScoreControl : UserControl
    {
        private Label lblTitle;
        private Button btnResetScores;
        private Button btnToggleScores;
        private Label lblCurrentPlayerScore;
        private ListView lvwScores;

        public int CurrentPlayerId { get; set; }
        private bool showingHighScores = false;

        public string CurrentPlayer { get; set; }

        public ScoreControl(string currentPlayer)
        {
            CurrentPlayer = currentPlayer;
            InitializeComponent();
            LoadPersonalScoreHistory();
        }

        private void InitializeComponent()
        {
            lblTitle = new Label
            {
                Text = "Score Board: My Scores",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                Location = new Point(30, 20),
                AutoSize = true,
                ForeColor = Color.Black
            };

            lvwScores = new ListView
            {
                Location = new Point(30, 80),
                Size = new Size(720, 390),
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                Font = new Font("Consolas", 12F, FontStyle.Regular),
                OwnerDraw = true
            };

            lvwScores.Columns.Add("Username");
            lvwScores.Columns.Add("Level");
            lvwScores.Columns.Add("Score");
            lvwScores.Columns.Add("Date");

            lvwScores.DrawColumnHeader += LvwScores_DrawColumnHeader;
            lvwScores.DrawSubItem += LvwScores_DrawSubItem;

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
                Size = new Size(300, 30),
                Font = new Font("Segoe UI", 12F),
                Text = $"Current Player : {CurrentPlayer}",
                ForeColor = Color.Black
            };

            btnToggleScores = new Button
            {
                Text = "High Scores",
                Location = new Point(400, 500),
                Size = new Size(150, 40),
                BackColor = Color.FromArgb(70, 130, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnToggleScores.Click += BtnToggleScores_Click;

            Controls.Add(lblTitle);
            Controls.Add(lvwScores);
            Controls.Add(lblCurrentPlayerScore);
            Controls.Add(btnResetScores);
            Controls.Add(btnToggleScores);

            Name = "ScoreControl";
            Size = new Size(800, 550);
            BackColor = Color.FromArgb(240, 240, 240);

            AdjustColumnWidths();
        }

        private void AdjustColumnWidths()
        {
            int totalWidth = lvwScores.ClientSize.Width;
            int columnCount = lvwScores.Columns.Count;
            int columnWidth = totalWidth / columnCount;

            foreach (ColumnHeader column in lvwScores.Columns)
            {
                column.Width = columnWidth;
            }
        }

        private void LvwScores_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (var brush = new SolidBrush(Color.Black))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }

            using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                e.Graphics.DrawString(e.Header.Text, e.Font, Brushes.White, e.Bounds, sf);
            }

            e.DrawDefault = false;
        }

        private void LvwScores_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                e.Graphics.DrawString(e.SubItem.Text, lvwScores.Font, Brushes.Black, e.Bounds, sf);
            }

            e.DrawDefault = false;
        }

        private void LoadPersonalScoreHistory()
        {
            lvwScores.Items.Clear();
            CurrentPlayerId = UserController.GetUserId(CurrentPlayer);
            List<Score> personalScores = ScoreController.GetAllScoresByUser(CurrentPlayerId);

            if (personalScores.Count == 0)
            {
                var emptyItem = new ListViewItem(new[] { "No scores available.", "", "", "" });
                lvwScores.Items.Add(emptyItem);
                return;
            }

            foreach (var score in personalScores)
            {
                var item = new ListViewItem(new[]
                {
                    CurrentPlayer,
                    $"{score.Level}",
                    $"{score.ScoreValue} points",
                    score.AchievedAt.ToString("yyyy-MM-dd")
                });
                lvwScores.Items.Add(item);
            }
        }

        private void LoadHighScores()
        {
            lvwScores.Items.Clear();
            List<Score> highScores = ScoreController.GetHighScoresForAllUsers();

            if (highScores.Count == 0)
            {
                var emptyItem = new ListViewItem(new[] { "No high scores available.", "", "", "" });
                lvwScores.Items.Add(emptyItem);
                return;
            }

            foreach (var score in highScores)
            {
                string username = UserController.GetUsernameById(score.UserId) ?? "Unknown";

                var item = new ListViewItem(new[]
                {
                    username,
                    $"{score.Level}",
                    $"{score.ScoreValue} points",
                    score.AchievedAt.ToString("yyyy-MM-dd")
                });
                lvwScores.Items.Add(item);
            }
        }

        private void BtnToggleScores_Click(object sender, EventArgs e)
        {
            if (showingHighScores)
            {
                btnToggleScores.Text = "High Scores";
                lblTitle.Text = "Score Board: My Scores";
                LoadPersonalScoreHistory();
            }
            else
            {
                btnToggleScores.Text = "My Scores";
                lblTitle.Text = "Score Board: High Scores";
                LoadHighScores();
            }
            showingHighScores = !showingHighScores;
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
                if (ScoreController.ResetAllScores())
                {
                    MessageBox.Show("Scores have been reset successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lvwScores.Items.Clear();
                }
                else
                {
                    MessageBox.Show("Failed to reset scores.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

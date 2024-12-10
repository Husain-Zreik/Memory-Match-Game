using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace Memory_Game
{
    public partial class PlayControl : UserControl
    {

        private int mistakes = 0;
        private int correctMatches = 0;
        private int elapsedTime = 0;
        private int currentLevel = 1;
        private int liveScore = 0;
        private string playerName;
        private int totalCardPairs;
        private int totalCards;
        private string[] cardValues;
        private string[] customImages;
        private string[] shuffledCardValues;
        private Button firstClicked, secondClicked;
        private Dictionary<Button, string> cardButtonToImage = new Dictionary<Button, string>();

        public PlayControl(string playerName)
        {
            InitializeComponent();
            this.playerName = playerName;
        }

        public void SaveScore(int score, int level)
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MemoryGame", "scores.json");

            // Load the existing scores
            Dictionary<string, PlayerScore> playerScores = LoadScores(filePath);

            // Check if the player already exists and update their score
            if (playerScores.ContainsKey(playerName))
            {
                // Update the existing player's score and level
                playerScores[playerName].Score = score;
                playerScores[playerName].Level = level;
            }
            else
            {
                // If the player does not exist, create a new record
                PlayerScore playerScore = new PlayerScore
                {
                    PlayerName = playerName,
                    Score = score,
                    Level = level
                };
                playerScores.Add(playerName, playerScore);
            }

            // Save the updated scores back to the file
            SaveScoresToFile(filePath, playerScores);
        }

        private Dictionary<string, PlayerScore> LoadScores(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    string json = File.ReadAllText(filePath);
                    var playerScores = JsonConvert.DeserializeObject<Dictionary<string, PlayerScore>>(json) ?? new Dictionary<string, PlayerScore>();
                    return playerScores;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error loading scores: {ex.Message}");
                    return new Dictionary<string, PlayerScore>(); // Return empty dictionary if there's an error
                }
            }
            else
            {
                return new Dictionary<string, PlayerScore>(); // Return empty dictionary if file does not exist
            }
        }

        private void SaveScoresToFile(string filePath, Dictionary<string, PlayerScore> playerScores)
        {
            try
            {
                // Ensure the directory exists
                string directoryPath = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                    Debug.WriteLine($"Created directory: {directoryPath}");
                }

                // Serialize the dictionary to JSON
                string json = JsonConvert.SerializeObject(playerScores, Formatting.Indented);

                // Write JSON to the file
                File.WriteAllText(filePath, json);
                Debug.WriteLine("Scores saved successfully!");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error saving scores: {ex.Message}");
            }
        }



        private void EndLevel(int finalScore)
        {
            int level = currentLevel;

            Debug.WriteLine($"Ending level {level} for player {playerName} with score {finalScore}");

            // Call SaveScore after each level completion
            SaveScore( finalScore, level);

            // Continue with other level completion logic
        }


        public void SetCustomImages(string[] images)
        {
            customImages = images;
        }

        private bool AreCustomImagesAvailable()
        {
            string directoryPath = @"C:\Users\Administrator\source\repos\Memory_Game\Memory_Game\bin\Debug\net8.0-windows\Resources\CustomImages";
            if (System.IO.Directory.Exists(directoryPath))
            {
                var imageFiles = System.IO.Directory.GetFiles(directoryPath, "*.png")
                                    .Concat(System.IO.Directory.GetFiles(directoryPath, "*.jpg"))
                                    .Concat(System.IO.Directory.GetFiles(directoryPath, "*.jpeg"))
                                    .ToArray();
                if (imageFiles.Length > 0)
                {
                    customImages = imageFiles;
                    return true;
                }
            }
            return false;
        }

        private void PlayControl_Load(object sender, EventArgs e)
        {
            lblScore.Text = "Mistakes: 0";
            lblTimer.Text = "Time: 00:00";
            lblLevel.Text = "Level: 1";
            lblLiveScore.Text = "Score: 0";
            btnStart.Enabled = true;
        }

        private void StartNewLevel()
        {
            mistakes = 0;
            correctMatches = 0;
            elapsedTime = 0;
            lblScore.Text = "Mistakes: 0";
            lblTimer.Text = "Time: 00:00";
            lblLevel.Text = "Level: " + currentLevel;
            lblLiveScore.Text = "Score: " + liveScore; // Display live score

            totalCardPairs = currentLevel switch
            {
                1 => 3,
                2 => 6,
                3 => 9,
                _ => 9 // Keep level 3 as the maximum
            };
            totalCards = totalCardPairs * 2;

            if (cardButtons != null)
            {
                foreach (var button in cardButtons)
                {
                    this.Controls.Remove(button);
                }
            }
            SetupLevel();
        }

        private void SetupLevel()
        {
            cardButtons = new Button[totalCards];
            for (int i = 0; i < totalCards; i++)
            {
                cardButtons[i] = new Button
                {
                    Size = new System.Drawing.Size(100, 100),
                    Location = new System.Drawing.Point(50 + (i % 6) * 120, 80 + (i / 6) * 120),
                    Text = "",
                    Enabled = true
                };
                cardButtons[i].Click += cardButton_Click;
                this.Controls.Add(cardButtons[i]);
            }
            SetupCardValues();
            ShuffleCards();
            MemorizationPhase();
        }

        private void SetupCardValues()
        {
            cardValues = new string[totalCards];
            if (AreCustomImagesAvailable())
            {
                int customImageCount = customImages.Length;
                for (int i = 0; i < totalCardPairs; i++)
                {
                    if (i < customImageCount)
                    {
                        cardValues[i] = customImages[i % customImageCount];
                        cardValues[i + totalCardPairs] = customImages[i % customImageCount];
                    }
                    else
                    {
                        int defaultIndex = i - customImageCount + 1;
                        cardValues[i] = "Dinosaur_" + defaultIndex;
                        cardValues[i + totalCardPairs] = "Dinosaur_" + defaultIndex;
                    }
                }
            }
            else
            {
                for (int i = 0; i < totalCardPairs; i++)
                {
                    cardValues[i] = "Dinosaur_" + (i + 1);
                    cardValues[i + totalCardPairs] = "Dinosaur_" + (i + 1);
                }
            }

            for (int i = 0; i < cardValues.Length; i++)
            {
                Debug.WriteLine($"Card {i + 1}: {cardValues[i]}");
            }
        }

        private void ShuffleCards()
        {
            Random rand = new Random();
            shuffledCardValues = cardValues.OrderBy(x => rand.Next()).ToArray();
        }

        private void MemorizationPhase()
        {
            for (int i = 0; i < totalCards; i++)
            {
                var resourceName = shuffledCardValues[i];
                System.Drawing.Image resourceImage = null;

                if (customImages != null && customImages.Contains(resourceName))
                {
                    string imagePath = customImages.FirstOrDefault(image => image.Contains(resourceName));
                    if (System.IO.File.Exists(imagePath))
                    {
                        resourceImage = System.Drawing.Image.FromFile(imagePath);
                    }
                }
                else
                {
                    resourceImage = (System.Drawing.Image)Resources.ResourceManager.GetObject(resourceName);
                }

                if (resourceImage != null)
                {
                    cardButtons[i].BackgroundImage = resourceImage;
                    cardButtons[i].BackgroundImageLayout = ImageLayout.Stretch;
                    cardButtonToImage[cardButtons[i]] = resourceName;
                }
            }

            var memorizeTimer = new System.Windows.Forms.Timer { Interval = 3000 };
            memorizeTimer.Tick += (s, e) =>
            {
                foreach (var button in cardButtons)
                {
                    button.BackgroundImage = null;
                    button.Enabled = true;
                }
                memorizeTimer.Stop();
                gameTimer.Start();
            };
            memorizeTimer.Start();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            elapsedTime++;
            lblTimer.Text = "Time: " + TimeSpan.FromSeconds(elapsedTime).ToString(@"mm\:ss");
        }

        private void cardButton_Click(object sender, EventArgs e)
        {
            var clickedButton = sender as Button;

            if (clickedButton == null || clickedButton == firstClicked || !clickedButton.Enabled)
            {
                return;
            }

            if (firstClicked == null)
            {
                firstClicked = clickedButton;
                ShowCardImage(clickedButton);
                return;
            }

            if (secondClicked == null)
            {
                secondClicked = clickedButton;
                ShowCardImage(clickedButton);
                CheckForMatch();
            }
        }

        private void ShowCardImage(Button button)
        {
            if (cardButtonToImage.ContainsKey(button))
            {
                string resourceName = cardButtonToImage[button];

                if (customImages != null && customImages.Contains(resourceName))
                {
                    string imagePath = customImages.FirstOrDefault(image => image.Contains(resourceName));
                    if (System.IO.File.Exists(imagePath))
                    {
                        button.BackgroundImage = System.Drawing.Image.FromFile(imagePath);
                    }
                }
                else
                {
                    button.BackgroundImage = (System.Drawing.Image)Resources.ResourceManager.GetObject(resourceName);
                }

                button.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        private void CheckForMatch()
        {
            if (firstClicked == null || secondClicked == null)
                return;

            if (!cardButtonToImage.ContainsKey(firstClicked) || !cardButtonToImage.ContainsKey(secondClicked))
                return;

            firstClicked.Enabled = false;
            secondClicked.Enabled = false;

            string firstImage = cardButtonToImage[firstClicked];
            string secondImage = cardButtonToImage[secondClicked];

            if (firstImage == secondImage)
            {
                correctMatches++;
                liveScore += 100; // Add 100 points for a correct match
                firstClicked = null;
                secondClicked = null;

                lblLiveScore.Text = "Score: " + liveScore; // Update live score

                if (correctMatches == totalCardPairs)
                {
                    // After completing the level, save the score
                    SaveScore( liveScore, currentLevel);  // You can modify the player name dynamically
                    MessageBox.Show("You've completed this level!", "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (currentLevel < 3)
                    {
                        currentLevel++;
                        StartNewLevel();
                    }
                    else
                    {
                        MessageBox.Show("You've completed all levels!", "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetGame(); // If all levels are completed, reset the game
                    }
                }
            }
            else
            {
                // Handle mistakes
                var timer = new System.Windows.Forms.Timer { Interval = 1000 };
                timer.Tick += (s, e) =>
                {
                    if (firstClicked != null && secondClicked != null)
                    {
                        firstClicked.BackgroundImage = null;
                        secondClicked.BackgroundImage = null;
                        firstClicked.Enabled = true;
                        secondClicked.Enabled = true;
                        firstClicked = null;
                        secondClicked = null;
                    }

                    timer.Stop();
                };
                timer.Start();

                mistakes++;
                lblScore.Text = $"Mistakes: {mistakes}";

                // Deduct points for mistakes (optional)
                liveScore -= 10;
                if (liveScore < 0) liveScore = 0; // Ensure score doesn't go negative
                lblLiveScore.Text = "Score: " + liveScore; // Update live score
            }
        }

        private void ResetGame()
        {
            currentLevel = 1;
            mistakes = 0;
            correctMatches = 0;
            elapsedTime = 0;

            lblScore.Text = "Mistakes: 0";
            lblTimer.Text = "Time: 00:00";
            lblLevel.Text = "Level: 1";
            lblLiveScore.Text = "Score: 0";

            if (cardButtons != null)
            {
                foreach (var button in cardButtons)
                {
                    this.Controls.Remove(button);
                }
            }

            btnStart.Enabled = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StartNewLevel();
            btnStart.Enabled = false;
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            ResetGame();
            btnStart.Enabled = true;
        }


        #region Designer Code

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblLiveScore;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Button[] cardButtons;

        private void InitializeComponent()
        {
            this.BackColor = System.Drawing.Color.FromArgb(245, 244, 239);

            this.BackgroundImage = global::Memory_Game.Resources.Background_Image
           ; // Replace with your image name
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // Panel for the statistics bar
            var statsPanel = new Panel
            {
                Location = new System.Drawing.Point(0, 0),
                Size = new System.Drawing.Size(800, 50), // Adjust width and height as needed
                BackColor = System.Drawing.Color.FromArgb(250, 250, 250) // Off-white background
            };
            this.Controls.Add(statsPanel);

            // Score Label
            this.lblScore = new Label
            {
                Text = "Mistakes: 0",
                Location = new System.Drawing.Point(20, 10), // Adjust X, Y position within the statsPanel
                Size = new System.Drawing.Size(150, 30),
                Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular),
                ForeColor = System.Drawing.Color.Black
            };
            statsPanel.Controls.Add(lblScore); // Add to the panel

            // Timer Label
            this.lblTimer = new Label
            {
                Text = "Time: 00:00",
                Location = new System.Drawing.Point(620, 10), // Position it to the right within the statsPanel
                Size = new System.Drawing.Size(150, 30),
                Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular),
                ForeColor = System.Drawing.Color.Black
            };
            statsPanel.Controls.Add(lblTimer);

            // Level Label
            this.lblLevel = new Label
            {
                Text = "Level: 1",
                Location = new System.Drawing.Point(220, 10),
                Size = new System.Drawing.Size(150, 30),
                Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular),
                ForeColor = System.Drawing.Color.Black
            };
            statsPanel.Controls.Add(lblLevel);

            // Live Score Label
            this.lblLiveScore = new Label
            {
                Text = "Score: 0",
                Location = new System.Drawing.Point(420, 10),
                Size = new System.Drawing.Size(150, 30),
                Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular),
                ForeColor = System.Drawing.Color.Black
            };
            statsPanel.Controls.Add(lblLiveScore);

            // Start Button
            this.btnStart = new Button
            {
                Text = "Start Game",
                Size = new System.Drawing.Size(100, 40),
                Location = new System.Drawing.Point(550, 500),
                BackColor = System.Drawing.Color.FromArgb(45, 45, 48),
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular),
                FlatStyle = FlatStyle.Flat
            };
            btnStart.FlatAppearance.BorderSize = 0;
            btnStart.Click += btnStart_Click;
            this.Controls.Add(btnStart);

            // Restart Button
            this.btnRestart = new Button
            {
                Text = "Restart",
                Size = new System.Drawing.Size(100, 40),
                Location = new System.Drawing.Point(670, 500),
                BackColor = System.Drawing.Color.FromArgb(45, 45, 48),
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular),
                FlatStyle = FlatStyle.Flat
            };
            btnRestart.FlatAppearance.BorderSize = 0;
            btnRestart.Click += btnRestart_Click;
            this.Controls.Add(btnRestart);

            // Game Timer
            this.gameTimer = new System.Windows.Forms.Timer { Interval = 1000 };
            this.gameTimer.Tick += gameTimer_Tick;

            this.Name = "PlayControl";
            this.Size = new System.Drawing.Size(800, 600);
            this.Load += PlayControl_Load;
        }


        #endregion
    }
}

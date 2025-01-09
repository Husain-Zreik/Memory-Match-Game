using System;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace Memory_Game.Views
{
    public partial class RatingForm : Form
    {
        private const int StarCount = 5;
        private IconButton[] starButtons;
        private Button btnSubmit;
        private Label lblInstruction;

        public int SelectedRating { get; private set; } = 0;

        private void InitializeComponent()
        {
            this.Text = "Rate the Game";
            this.Size = new Size(500, 300); 
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.BackColor = Color.White;
            this.StartPosition = FormStartPosition.CenterParent;

            lblInstruction = new Label
            {
                Text = "Please rate your experience:",
                Font = new Font("Segoe UI", 14, FontStyle.Regular),
                ForeColor = Color.Black,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = false,
                Size = new Size(450, 30),
                Location = new Point(25, 20) 
            };
            this.Controls.Add(lblInstruction);

            starButtons = new IconButton[StarCount];
            int startX = (this.ClientSize.Width - (StarCount * 50)) / 2;
            for (int i = 0; i < StarCount; i++)
            {
                starButtons[i] = new IconButton
                {
                    IconChar = IconChar.Star,
                    IconColor = Color.Gray,
                    IconSize = 40,
                    Size = new Size(50, 50),
                    Location = new Point(startX + i * 50, 70), 
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.Transparent,
                    Tag = i + 1
                };
                starButtons[i].FlatAppearance.BorderSize = 0;
                starButtons[i].Click += StarButton_Click;
                this.Controls.Add(starButtons[i]);
            }

            btnSubmit = new Button
            {
                Text = "Submit",
                Size = new Size(120, 40),
                Location = new Point((this.ClientSize.Width - 120) / 2, 140), 
                BackColor = Color.FromArgb(45, 45, 48),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12)
            };
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.Click += BtnSubmit_Click;
            this.Controls.Add(btnSubmit);
        }

        private void StarButton_Click(object sender, EventArgs e)
        {
            var clickedButton = sender as IconButton;
            SelectedRating = (int)clickedButton.Tag;

            for (int i = 0; i < StarCount; i++)
            {
                starButtons[i].IconColor = (i < SelectedRating) ? Color.Gold : Color.Gray;
            }
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (SelectedRating == 0)
            {
                MessageBox.Show("Please select a rating before submitting.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show($"You rated the game {SelectedRating} stars. Thank you!", "Rating Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
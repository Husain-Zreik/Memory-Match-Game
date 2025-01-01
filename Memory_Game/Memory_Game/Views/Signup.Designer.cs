using System;
using System.Windows.Forms;

namespace Memory_Game.Views
{
    public partial class Signup : Form
    {
        private void InitializeComponent()
        {
            this.buttonSubmitSignup = new System.Windows.Forms.Button();
            this.labelUsername = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelConfirmPassword = new System.Windows.Forms.Label();
            this.textBoxConfirmPassword = new System.Windows.Forms.TextBox();
            this.labelAge = new System.Windows.Forms.Label();
            this.textBoxAge = new System.Windows.Forms.TextBox();
            this.linkLabelBackToLogin = new System.Windows.Forms.LinkLabel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // buttonSubmitSignup
            this.buttonSubmitSignup.BackColor = System.Drawing.Color.White;
            this.buttonSubmitSignup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSubmitSignup.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.buttonSubmitSignup.ForeColor = System.Drawing.Color.Black;
            this.buttonSubmitSignup.Size = new System.Drawing.Size(100, 30);
            this.buttonSubmitSignup.TabIndex = 5;
            this.buttonSubmitSignup.Text = "Signup";
            this.buttonSubmitSignup.UseVisualStyleBackColor = false;
            this.buttonSubmitSignup.Click += new System.EventHandler(this.buttonSubmitSignup_Click);

            // labelUsername
            this.labelUsername.AutoSize = true;
            this.labelUsername.BackColor = System.Drawing.Color.Transparent;
            this.labelUsername.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold);
            this.labelUsername.ForeColor = System.Drawing.Color.White;
            this.labelUsername.Text = "Username:";

            // textBoxUsername
            this.textBoxUsername.BackColor = System.Drawing.Color.White;
            this.textBoxUsername.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold);
            this.textBoxUsername.Size = new System.Drawing.Size(199, 27);
            this.textBoxUsername.TabIndex = 1;

            // labelPassword
            this.labelPassword.AutoSize = true;
            this.labelPassword.BackColor = System.Drawing.Color.Transparent;
            this.labelPassword.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold);
            this.labelPassword.ForeColor = System.Drawing.Color.White;
            this.labelPassword.Text = "Password:";

            // textBoxPassword
            this.textBoxPassword.BackColor = System.Drawing.Color.White;
            this.textBoxPassword.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold);
            this.textBoxPassword.Size = new System.Drawing.Size(199, 27);
            this.textBoxPassword.TabIndex = 2;
            this.textBoxPassword.PasswordChar = '*';

            // labelConfirmPassword
            this.labelConfirmPassword.AutoSize = true;
            this.labelConfirmPassword.BackColor = System.Drawing.Color.Transparent;
            this.labelConfirmPassword.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold);
            this.labelConfirmPassword.ForeColor = System.Drawing.Color.White;
            this.labelConfirmPassword.Text = "Confirm Password:";

            // textBoxConfirmPassword
            this.textBoxConfirmPassword.BackColor = System.Drawing.Color.White;
            this.textBoxConfirmPassword.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold);
            this.textBoxConfirmPassword.Size = new System.Drawing.Size(199, 27);
            this.textBoxConfirmPassword.TabIndex = 3;
            this.textBoxConfirmPassword.PasswordChar = '*';

            // labelAge
            this.labelAge.AutoSize = true;
            this.labelAge.BackColor = System.Drawing.Color.Transparent;
            this.labelAge.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold);
            this.labelAge.ForeColor = System.Drawing.Color.White;
            this.labelAge.Text = "Age:";

            // textBoxAge
            this.textBoxAge.BackColor = System.Drawing.Color.White;
            this.textBoxAge.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold);
            this.textBoxAge.Size = new System.Drawing.Size(199, 27);
            this.textBoxAge.TabIndex = 4;

            // linkLabelBackToLogin
            this.linkLabelBackToLogin.AutoSize = true;
            this.linkLabelBackToLogin.BackColor = System.Drawing.Color.Transparent;
            this.linkLabelBackToLogin.Font = new System.Drawing.Font("Candara", 10F, System.Drawing.FontStyle.Bold);
            this.linkLabelBackToLogin.ForeColor = System.Drawing.Color.White;
            this.linkLabelBackToLogin.LinkColor = System.Drawing.Color.Blue;
            this.linkLabelBackToLogin.Text = "Already have an account? Login";
            this.linkLabelBackToLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelBackToLogin_LinkClicked);

            // labelTitle
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Font = new System.Drawing.Font("Segoe Script", 14F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Text = "Sign Up to Play !";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Signup Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = global::Memory_Game.Resources.Background_Image;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(400, 420);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.linkLabelBackToLogin);
            this.Controls.Add(this.labelConfirmPassword);
            this.Controls.Add(this.textBoxConfirmPassword);
            this.Controls.Add(this.labelAge);
            this.Controls.Add(this.textBoxAge);
            this.Controls.Add(this.buttonSubmitSignup);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textBoxPassword);
            this.Icon = null;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(416, 420);
            this.Name = "Signup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Memory Game Signup";
            this.Resize += new EventHandler(this.Signup_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

            CenterComponents();
        }

        private void Signup_Resize(object sender, EventArgs e)
        {
            CenterComponents();
        }

        private void CenterComponents()
        {
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            int containerWidth = Math.Max(labelUsername.Width, textBoxUsername.Width);
            int containerHeight = 20 + labelUsername.Height + textBoxUsername.Height +
                                  labelPassword.Height + textBoxPassword.Height +
                                  labelConfirmPassword.Height + textBoxConfirmPassword.Height +
                                  labelAge.Height + textBoxAge.Height + 80;

            int centerX = (formWidth - containerWidth) / 2;
            int centerY = (formHeight - containerHeight) / 2;

            labelTitle.Location = new System.Drawing.Point((formWidth - labelTitle.Width) / 2, 30);

            labelUsername.Location = new System.Drawing.Point(centerX, centerY);
            textBoxUsername.Location = new System.Drawing.Point(centerX, centerY + labelUsername.Height + 5);

            labelPassword.Location = new System.Drawing.Point(centerX, centerY + labelUsername.Height + textBoxUsername.Height + 15);
            textBoxPassword.Location = new System.Drawing.Point(centerX, centerY + labelUsername.Height + textBoxUsername.Height + labelPassword.Height + 15);

            labelConfirmPassword.Location = new System.Drawing.Point(centerX, centerY + labelUsername.Height + textBoxUsername.Height + labelPassword.Height + textBoxPassword.Height + 15);
            textBoxConfirmPassword.Location = new System.Drawing.Point(centerX, centerY + labelUsername.Height + textBoxUsername.Height + labelPassword.Height + textBoxPassword.Height + labelConfirmPassword.Height + 15);

            labelAge.Location = new System.Drawing.Point(centerX, centerY + labelUsername.Height + textBoxUsername.Height + labelPassword.Height + textBoxPassword.Height + labelConfirmPassword.Height + textBoxConfirmPassword.Height + 20);
            textBoxAge.Location = new System.Drawing.Point(centerX, centerY + labelUsername.Height + textBoxUsername.Height + labelPassword.Height + textBoxPassword.Height + labelConfirmPassword.Height + textBoxConfirmPassword.Height + labelAge.Height + 20);

            buttonSubmitSignup.Location = new System.Drawing.Point((formWidth - buttonSubmitSignup.Width) / 2, centerY + containerHeight - 50);
            linkLabelBackToLogin.Location = new System.Drawing.Point((formWidth - linkLabelBackToLogin.Width) / 2, centerY + containerHeight + 20);
        }

        private void buttonSubmitSignup_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text.Trim();
            string password = textBoxPassword.Text.Trim();
            string confirmPassword = textBoxConfirmPassword.Text.Trim();
            string ageText = textBoxAge.Text.Trim();
            int age;

            // Age Validation
            if (!int.TryParse(ageText, out age) || age < 4)
            {
                MessageBox.Show("Please enter a valid age (18 or older).");
                return;
            }

            // Password Validation
            if (string.IsNullOrEmpty(password) || password.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            // Username Validation
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter a username.");
                return;
            }

            // Check if username is already taken
            if (Memory_Game.Controllers.UserController.IsUsernameTaken(username))
            {
                MessageBox.Show("The username is already taken. Please choose another.");
                return;
            }

            // Add user to the database
            if (Memory_Game.Controllers.UserController.AddUser(username, password, age))
            {
                MessageBox.Show("Signup successful! You can now log in.");

                Login loginForm = new Login();
                loginForm.Show();
                this.Close(); 
            }
            else
            {
                MessageBox.Show("An error occurred during signup. Please try again.");
            }
        }

        private void linkLabelBackToLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }

        private System.Windows.Forms.Button buttonSubmitSignup;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelConfirmPassword;
        private System.Windows.Forms.TextBox textBoxConfirmPassword;
        private System.Windows.Forms.Label labelAge;
        private System.Windows.Forms.TextBox textBoxAge;
        private System.Windows.Forms.LinkLabel linkLabelBackToLogin;
        private System.Windows.Forms.Label labelTitle;
    }
}

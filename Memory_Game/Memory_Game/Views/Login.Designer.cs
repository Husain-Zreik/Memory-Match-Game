using System;
using System.Windows.Forms;
using Memory_Game.Controllers;

namespace Memory_Game.Views
{
    public partial class Login : Form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.labelPrompt = new System.Windows.Forms.Label();
            this.textBoxPlayerName = new System.Windows.Forms.TextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.linkLabelSignup = new System.Windows.Forms.LinkLabel();
            this.labelPassword = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // buttonSubmit
            this.buttonSubmit.BackColor = System.Drawing.Color.White;
            this.buttonSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSubmit.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.buttonSubmit.ForeColor = System.Drawing.Color.Black;
            this.buttonSubmit.Size = new System.Drawing.Size(100, 30);
            this.buttonSubmit.TabIndex = 3;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = false;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);

            // labelPrompt
            this.labelPrompt.AutoSize = true;
            this.labelPrompt.BackColor = System.Drawing.Color.Transparent;
            this.labelPrompt.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.labelPrompt.ForeColor = System.Drawing.Color.White;
            this.labelPrompt.Text = "Username:";

            // textBoxPlayerName
            this.textBoxPlayerName.BackColor = System.Drawing.Color.White;
            this.textBoxPlayerName.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.textBoxPlayerName.Size = new System.Drawing.Size(199, 27);
            this.textBoxPlayerName.TabIndex = 1;

            // labelTitle
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Font = new System.Drawing.Font("Segoe Script", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Text = "Welcome to Mind Game!";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // textBoxPassword
            this.textBoxPassword.BackColor = System.Drawing.Color.White;
            this.textBoxPassword.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.textBoxPassword.Size = new System.Drawing.Size(199, 27);
            this.textBoxPassword.TabIndex = 2;
            this.textBoxPassword.UseSystemPasswordChar = true;

            // labelPassword
            this.labelPassword.AutoSize = true;
            this.labelPassword.BackColor = System.Drawing.Color.Transparent;
            this.labelPassword.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.labelPassword.ForeColor = System.Drawing.Color.White;
            this.labelPassword.Text = "Password:";

            // linkLabelSignup
            this.linkLabelSignup.AutoSize = true;
            this.linkLabelSignup.BackColor = System.Drawing.Color.Transparent;
            this.linkLabelSignup.Font = new System.Drawing.Font("Candara", 10F, System.Drawing.FontStyle.Bold);
            this.linkLabelSignup.ForeColor = System.Drawing.Color.White;
            this.linkLabelSignup.LinkColor = System.Drawing.Color.Blue;
            this.linkLabelSignup.Text = "Don't have an account? Signup";
            this.linkLabelSignup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSignup_LinkClicked);

            // Centering form elements
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = global::Memory_Game.Resources.Background_Image;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.linkLabelSignup);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.labelPrompt);
            this.Controls.Add(this.textBoxPlayerName);
            this.Icon = null;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(416, 359);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Memory Game Login";
            this.Resize += new EventHandler(this.Login_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

            CenterComponents();
        }

        private void Login_Resize(object sender, EventArgs e)
        {
            CenterComponents();
        }

        private void CenterComponents()
        {
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            int containerWidth = Math.Max(labelPrompt.Width, textBoxPlayerName.Width);
            int containerHeight = 20 + labelPrompt.Height + textBoxPlayerName.Height +
                                  labelPassword.Height + textBoxPassword.Height + 80;

            int centerX = (formWidth - containerWidth) / 2;
            int centerY = (formHeight - containerHeight) / 2;

            labelTitle.Location = new System.Drawing.Point((formWidth - labelTitle.Width) / 2, 30);

            labelPrompt.Location = new System.Drawing.Point(centerX, centerY);
            textBoxPlayerName.Location = new System.Drawing.Point(centerX, centerY + labelPrompt.Height + 5);

            labelPassword.Location = new System.Drawing.Point(centerX, centerY + labelPrompt.Height + textBoxPlayerName.Height + 15);
            textBoxPassword.Location = new System.Drawing.Point(centerX, centerY + labelPrompt.Height + textBoxPlayerName.Height + labelPassword.Height + 15);

            buttonSubmit.Location = new System.Drawing.Point((formWidth - buttonSubmit.Width) / 2, centerY + containerHeight - 50);
            linkLabelSignup.Location = new System.Drawing.Point((formWidth - linkLabelSignup.Width) / 2, centerY + containerHeight + 20);
        }

        #endregion

        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Label labelPrompt;
        private System.Windows.Forms.TextBox textBoxPlayerName;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.LinkLabel linkLabelSignup;
        private System.Windows.Forms.Label labelPassword;

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            string playerName = textBoxPlayerName.Text.Trim();
            string password = textBoxPassword.Text.Trim();

            if (string.IsNullOrEmpty(playerName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            if (UserController.ValidateLogin(playerName, password))
            {
                MainMenuForm menuForm = new MainMenuForm(playerName);
                menuForm.Show();
                this.Hide();  
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }

        private void linkLabelSignup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Signup signupForm = new Signup();
            signupForm.Show();
            this.Hide();
        }
    }
}

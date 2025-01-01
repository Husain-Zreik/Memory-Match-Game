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

            this.buttonSubmit.BackColor = System.Drawing.Color.White;
            this.buttonSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSubmit.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.buttonSubmit.ForeColor = System.Drawing.Color.Black;
            this.buttonSubmit.Location = new System.Drawing.Point(150, 220);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(72, 26);
            this.buttonSubmit.TabIndex = 3;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = false;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);

            this.labelPrompt.AutoSize = true;
            this.labelPrompt.BackColor = System.Drawing.Color.Transparent;
            this.labelPrompt.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.labelPrompt.ForeColor = System.Drawing.Color.White;
            this.labelPrompt.Location = new System.Drawing.Point(100, 90);
            this.labelPrompt.Name = "labelPrompt";
            this.labelPrompt.Size = new System.Drawing.Size(144, 19);
            this.labelPrompt.TabIndex = 2;
            this.labelPrompt.Text = "Username:";

            this.textBoxPlayerName.BackColor = System.Drawing.Color.White;
            this.textBoxPlayerName.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.textBoxPlayerName.Location = new System.Drawing.Point(100, 110);
            this.textBoxPlayerName.MaxLength = 15;
            this.textBoxPlayerName.Name = "textBoxPlayerName";
            this.textBoxPlayerName.Size = new System.Drawing.Size(199, 27);
            this.textBoxPlayerName.TabIndex = 1;
            this.textBoxPlayerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;

            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Font = new System.Drawing.Font("Segoe Script", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(75, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(222, 44);
            this.labelTitle.TabIndex = 4;
            this.labelTitle.Text = "Welcome to Mind Game!";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.textBoxPassword.BackColor = System.Drawing.Color.White;
            this.textBoxPassword.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.textBoxPassword.Location = new System.Drawing.Point(100, 160);
            this.textBoxPassword.MaxLength = 15;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(199, 27);
            this.textBoxPassword.TabIndex = 2;
            this.textBoxPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBoxPassword.UseSystemPasswordChar = true;

            this.labelPassword.AutoSize = true;
            this.labelPassword.BackColor = System.Drawing.Color.Transparent;
            this.labelPassword.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.labelPassword.ForeColor = System.Drawing.Color.White;
            this.labelPassword.Location = new System.Drawing.Point(100, 140);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(82, 19);
            this.labelPassword.TabIndex = 6;
            this.labelPassword.Text = "Password:";

            this.linkLabelSignup.AutoSize = true;
            this.linkLabelSignup.BackColor = System.Drawing.Color.Transparent;
            this.linkLabelSignup.Font = new System.Drawing.Font("Candara", 10F, System.Drawing.FontStyle.Bold);
            this.linkLabelSignup.ForeColor = System.Drawing.Color.White;
            this.linkLabelSignup.LinkColor = System.Drawing.Color.Blue;
            this.linkLabelSignup.Location = new System.Drawing.Point(100, 270);
            this.linkLabelSignup.Name = "linkLabelSignup";
            this.linkLabelSignup.Size = new System.Drawing.Size(180, 17);
            this.linkLabelSignup.TabIndex = 5;
            this.linkLabelSignup.TabStop = true;
            this.linkLabelSignup.Text = "Don't have an account? Signup";
            this.linkLabelSignup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSignup_LinkClicked);

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
            this.MaximumSize = new System.Drawing.Size(416, 359);
            this.MinimumSize = new System.Drawing.Size(416, 359);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Memory Game Login";
            this.ResumeLayout(false);
            this.PerformLayout();
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

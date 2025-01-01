using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Memory_Game.Views
{
    partial class Login
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
            this.checkBoxRemember = new System.Windows.Forms.CheckBox();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.labelLanguage = new System.Windows.Forms.Label();
            this.radioButtonMale = new System.Windows.Forms.RadioButton();
            this.radioButtonFemale = new System.Windows.Forms.RadioButton();
            this.radioButtonOther = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();

            // buttonSubmit
            this.buttonSubmit.BackColor = System.Drawing.Color.White;
            this.buttonSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSubmit.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.buttonSubmit.ForeColor = System.Drawing.Color.Black;
            this.buttonSubmit.Location = new System.Drawing.Point(150, 350);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(72, 26);
            this.buttonSubmit.TabIndex = 3;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = false;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);

            // labelPrompt
            this.labelPrompt.AutoSize = true;
            this.labelPrompt.BackColor = System.Drawing.Color.Transparent;
            this.labelPrompt.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.labelPrompt.ForeColor = System.Drawing.Color.White;
            this.labelPrompt.Location = new System.Drawing.Point(100, 90);
            this.labelPrompt.Name = "labelPrompt";
            this.labelPrompt.Size = new System.Drawing.Size(144, 19);
            this.labelPrompt.TabIndex = 2;
            this.labelPrompt.Text = "Enter Your Name:";

            // textBoxPlayerName
            this.textBoxPlayerName.BackColor = System.Drawing.Color.White;
            this.textBoxPlayerName.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.textBoxPlayerName.Location = new System.Drawing.Point(100, 110);
            this.textBoxPlayerName.MaxLength = 15;
            this.textBoxPlayerName.Name = "textBoxPlayerName";
            this.textBoxPlayerName.Size = new System.Drawing.Size(199, 27);
            this.textBoxPlayerName.TabIndex = 1;
            this.textBoxPlayerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;

            // labelTitle
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

            // checkBoxRemember
            this.checkBoxRemember.AutoSize = true;
            this.checkBoxRemember.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxRemember.Font = new System.Drawing.Font("Candara", 10F, System.Drawing.FontStyle.Bold);
            this.checkBoxRemember.ForeColor = System.Drawing.Color.White;
            this.checkBoxRemember.Location = new System.Drawing.Point(100, 150);
            this.checkBoxRemember.Name = "checkBoxRemember";
            this.checkBoxRemember.Size = new System.Drawing.Size(125, 21);
            this.checkBoxRemember.TabIndex = 5;
            this.checkBoxRemember.Text = "Remember Me";
            this.checkBoxRemember.UseVisualStyleBackColor = false;

            // comboBoxLanguage
            this.comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguage.Font = new System.Drawing.Font("Candara", 10F, System.Drawing.FontStyle.Bold);
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Items.AddRange(new object[] {
            "English",
            "Spanish",
            "French",
            "German"});
            this.comboBoxLanguage.Location = new System.Drawing.Point(100, 220);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(199, 23);
            this.comboBoxLanguage.TabIndex = 6;

            // labelLanguage
            this.labelLanguage.AutoSize = true;
            this.labelLanguage.BackColor = System.Drawing.Color.Transparent;
            this.labelLanguage.Font = new System.Drawing.Font("Candara", 10F, System.Drawing.FontStyle.Bold);
            this.labelLanguage.ForeColor = System.Drawing.Color.White;
            this.labelLanguage.Location = new System.Drawing.Point(100, 200);
            this.labelLanguage.Name = "labelLanguage";
            this.labelLanguage.Size = new System.Drawing.Size(108, 17);
            this.labelLanguage.TabIndex = 10;
            this.labelLanguage.Text = "Select Language:";

            // radioButtonMale
            this.radioButtonMale.AutoSize = true;
            this.radioButtonMale.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonMale.Font = new System.Drawing.Font("Candara", 10F, System.Drawing.FontStyle.Bold);
            this.radioButtonMale.ForeColor = System.Drawing.Color.White;
            this.radioButtonMale.Location = new System.Drawing.Point(100, 270);
            this.radioButtonMale.Name = "radioButtonMale";
            this.radioButtonMale.Size = new System.Drawing.Size(56, 21);
            this.radioButtonMale.TabIndex = 7;
            this.radioButtonMale.TabStop = true;
            this.radioButtonMale.Text = "Male";
            this.radioButtonMale.UseVisualStyleBackColor = false;

            // radioButtonFemale
            this.radioButtonFemale.AutoSize = true;
            this.radioButtonFemale.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonFemale.Font = new System.Drawing.Font("Candara", 10F, System.Drawing.FontStyle.Bold);
            this.radioButtonFemale.ForeColor = System.Drawing.Color.White;
            this.radioButtonFemale.Location = new System.Drawing.Point(162, 270);
            this.radioButtonFemale.Name = "radioButtonFemale";
            this.radioButtonFemale.Size = new System.Drawing.Size(70, 21);
            this.radioButtonFemale.TabIndex = 8;
            this.radioButtonFemale.TabStop = true;
            this.radioButtonFemale.Text = "Female";
            this.radioButtonFemale.UseVisualStyleBackColor = false;

            // radioButtonOther
            this.radioButtonOther.AutoSize = true;
            this.radioButtonOther.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonOther.Font = new System.Drawing.Font("Candara", 10F, System.Drawing.FontStyle.Bold);
            this.radioButtonOther.ForeColor = System.Drawing.Color.White;
            this.radioButtonOther.Location = new System.Drawing.Point(238, 270);
            this.radioButtonOther.Name = "radioButtonOther";
            this.radioButtonOther.Size = new System.Drawing.Size(61, 21);
            this.radioButtonOther.TabIndex = 9;
            this.radioButtonOther.TabStop = true;
            this.radioButtonOther.Text = "Other";
            this.radioButtonOther.UseVisualStyleBackColor = false;

            // Login
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = global::Memory_Game.Resources.Background_Image;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(400, 450);
            this.Controls.Add(this.labelLanguage);
            this.Controls.Add(this.radioButtonOther);
            this.Controls.Add(this.radioButtonFemale);
            this.Controls.Add(this.radioButtonMale);
            this.Controls.Add(this.comboBoxLanguage);
            this.Controls.Add(this.checkBoxRemember);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.labelPrompt);
            this.Controls.Add(this.textBoxPlayerName);
            this.Icon = null;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(416, 459);
            this.MinimumSize = new System.Drawing.Size(416, 459);
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
        private System.Windows.Forms.CheckBox checkBoxRemember;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.Label labelLanguage;
        private System.Windows.Forms.RadioButton radioButtonMale;
        private System.Windows.Forms.RadioButton radioButtonFemale;
        private System.Windows.Forms.RadioButton radioButtonOther;

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            string playerName = textBoxPlayerName.Text.Trim();
            if (string.IsNullOrEmpty(playerName))
            {
                MessageBox.Show("Please enter a name.");
                return;
            }

            string language = comboBoxLanguage.SelectedItem?.ToString() ?? "Not Selected";
            string gender = radioButtonMale.Checked ? "Male" : radioButtonFemale.Checked ? "Female" : "Other";
            bool remember = checkBoxRemember.Checked;

            string message = $"Name: {playerName}\nLanguage: {language}\nGender: {gender}\nRemember Me: {remember}";
            MessageBox.Show(message, "Login Details");

            MainMenuForm menuForm = new MainMenuForm(playerName);
            menuForm.Show();
            this.Hide();
        }
    }
}

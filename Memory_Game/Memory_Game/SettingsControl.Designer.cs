using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace Memory_Game
{
    public partial class SettingsControl : UserControl
    {
        public string[] SelectedImages { get; private set; }

        #region Designer generated code

        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private ListBox lstSelectedImages;
        private Button btnSelectImages;
        private Label lblStatus;
        private Button btnSave;
        private Button btnReset;

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lstSelectedImages = new ListBox();
            this.btnSelectImages = new Button();
            this.lblStatus = new Label();
            this.btnSave = new Button();
            this.btnReset = new Button();

            this.SuspendLayout();

            // Title Label
            this.lblTitle.Text = "Settings:";
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTitle.Location = new Point(30, 20);
            this.lblTitle.AutoSize = true;
            this.lblTitle.ForeColor = Color.Black;

            // List of Selected Images
            this.lstSelectedImages.FormattingEnabled = true;
            this.lstSelectedImages.ItemHeight = 20;
            this.lstSelectedImages.Location = new Point(30, 80);
            this.lstSelectedImages.Size = new Size(720, 400);
            this.lstSelectedImages.TabIndex = 0;

            // Select Images Button
            this.btnSelectImages.Text = "Select Images";
            this.btnSelectImages.Location = new Point(30, 500);
            this.btnSelectImages.Size = new Size(150, 40);
            this.btnSelectImages.BackColor = Color.FromArgb(45, 45, 48);
            this.btnSelectImages.ForeColor = Color.White;
            this.btnSelectImages.FlatStyle = FlatStyle.Flat;
            this.btnSelectImages.FlatAppearance.BorderSize = 0;
            this.btnSelectImages.Click += new EventHandler(this.btnSelectImages_Click);

            // Status Label
            this.lblStatus.Text = "No images selected.";
            this.lblStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            this.lblStatus.Location = new Point(30, 470);
            this.lblStatus.Size = new Size(720, 30);
            this.lblStatus.ForeColor = Color.Black;

            // Save Button
            this.btnSave.Text = "Save";
            this.btnSave.Location = new Point(200, 500);
            this.btnSave.Size = new Size(150, 40);
            this.btnSave.BackColor = Color.FromArgb(45, 45, 48);
            this.btnSave.ForeColor = Color.White;
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Visible = false; // Initially hidden
            this.btnSave.Click += new EventHandler(this.btnSave_Click);

            // Reset Button
            this.btnReset.Text = "Reset";
            this.btnReset.Location = new Point(600, 500);
            this.btnReset.Size = new Size(150, 40);
            this.btnReset.BackColor = Color.FromArgb(45, 45, 48);
            this.btnReset.ForeColor = Color.White;
            this.btnReset.FlatStyle = FlatStyle.Flat;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.Click += new EventHandler(this.btnReset_Click);

            // SettingsControl Layout
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lstSelectedImages);
            this.Controls.Add(this.btnSelectImages);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnReset);
            this.Name = "SettingsControl";
            this.Size = new Size(800, 450);
            this.BackColor = Color.FromArgb(240, 240, 240); // Light gray background
            this.ResumeLayout(false);
        }

        #endregion

        private void btnSelectImages_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select Images",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;",
                Multiselect = true
            };

            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    lstSelectedImages.Items.Clear();
                    foreach (var file in openFileDialog.FileNames)
                    {
                        lstSelectedImages.Items.Add(file);
                    }

                    SelectedImages = openFileDialog.FileNames;

                    lblStatus.Text = $"{openFileDialog.FileNames.Length} image(s) selected.";
                    btnSave.Visible = true;
                }
                else
                {
                    lblStatus.Text = "No images selected.";
                    btnSave.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while selecting the images: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectedImages == null || SelectedImages.Length == 0)
                {
                    MessageBox.Show("No images to save. Please select images first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "CustomImages");

                // Ensure directory exists
                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);

                foreach (var imagePath in SelectedImages)
                {
                    string destinationPath = Path.Combine(directoryPath, Path.GetFileName(imagePath));
                    // Handling errors during file copy
                    try
                    {
                        File.Copy(imagePath, destinationPath, overwrite: true);
                    }
                    catch (IOException ioEx)
                    {
                        MessageBox.Show($"Error copying file '{imagePath}': {ioEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                lstSelectedImages.Items.Clear();
                MessageBox.Show("Images saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the images: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                SelectedImages = null;
                lstSelectedImages.Items.Clear();
                lblStatus.Text = "No images selected.";
                btnSave.Visible = false;

                string directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "CustomImages");

                if (Directory.Exists(directoryPath))
                {
                    foreach (var file in Directory.GetFiles(directoryPath))
                    {
                        try
                        {
                            GC.Collect();
                            GC.WaitForPendingFinalizers();

                            File.Delete(file);
                        }
                        catch (IOException ioEx)
                        {
                            MessageBox.Show($"Error deleting file '{file}': {ioEx.Message}\nPlease ensure the file is not in use.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                MessageBox.Show("Images have been reset.", "Reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while resetting the images: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

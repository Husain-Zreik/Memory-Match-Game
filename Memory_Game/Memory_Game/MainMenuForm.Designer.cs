namespace Memory_Game
{
    public partial class MainMenuForm : Form
    {
        private string playerName;
        private bool isExitConfirmed = false;

        public MainMenuForm(string name)
        {
            InitializeComponent();
            playerName = name;
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            LoadContentArea(new PlayControl());
        }

        private void DisplayWelcomeMessage()
        {
            lblTitle.Text = $"Welcome, {playerName}!\nMemory Game";
        }

        private void MainMenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isExitConfirmed)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    isExitConfirmed = true;
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = false;
            }
        }

        private Panel pnlSideMenu;
        private Button btnPlay;
        private Button btnScoreBoard;
        private Button btnSettings;
        private Button btnExit;
        private Panel pnlContentArea;
        private Label lblTitle;
        private FlowLayoutPanel flowLayoutPanel;

        private void InitializeComponent()
        {
            pnlSideMenu = new Panel();
            btnPlay = new Button();
            lblTitle = new Label();
            btnScoreBoard = new Button();
            flowLayoutPanel = new FlowLayoutPanel();
            btnSettings = new Button();
            btnExit = new Button();
            pnlContentArea = new Panel();
            pnlSideMenu.SuspendLayout();
            SuspendLayout();

            ClientSize = new Size(982, 553);
            Controls.Add(pnlContentArea);
            Controls.Add(pnlSideMenu);
            Name = "MainMenuForm";
            Text = "Memory Game";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            pnlSideMenu.ResumeLayout(false);
            pnlSideMenu.PerformLayout();
            ResumeLayout(false);
            Load += MainMenuForm_Load;
            this.FormClosing += MainMenuForm_FormClosing;

            pnlSideMenu.BackColor = Color.FromArgb(45, 45, 48);
            pnlSideMenu.Controls.Add(btnPlay);
            pnlSideMenu.Controls.Add(lblTitle);
            pnlSideMenu.Controls.Add(btnScoreBoard);
            pnlSideMenu.Controls.Add(flowLayoutPanel);
            pnlSideMenu.Controls.Add(btnSettings);
            pnlSideMenu.Controls.Add(btnExit);
            pnlSideMenu.Dock = DockStyle.Left;
            pnlSideMenu.Location = new Point(0, 0);
            pnlSideMenu.Name = "pnlSideMenu";
            pnlSideMenu.Size = new Size(200, 553);
            pnlSideMenu.TabIndex = 1;

            btnPlay.FlatStyle = FlatStyle.Flat;
            btnPlay.FlatAppearance.BorderSize = 0;
            btnPlay.ForeColor = Color.White;
            btnPlay.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            btnPlay.Location = new Point(0, 221);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(200, 36);
            btnPlay.TabIndex = 0;
            btnPlay.Text = "Play";
            btnPlay.Click += BtnPlay_Click;

            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Padding = new Padding(10);
            lblTitle.Size = new Size(200, 86);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Memory\nGame";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            btnScoreBoard.FlatStyle = FlatStyle.Flat;
            btnScoreBoard.FlatAppearance.BorderSize = 0;
            btnScoreBoard.ForeColor = Color.White;
            btnScoreBoard.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            btnScoreBoard.Location = new Point(0, 263);
            btnScoreBoard.Name = "btnScoreBoard";
            btnScoreBoard.Size = new Size(200, 38);
            btnScoreBoard.TabIndex = 1;
            btnScoreBoard.Text = "Scoreboard";
            btnScoreBoard.Click += BtnScoreBoard_Click;

            flowLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel.AutoSize = true;
            flowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel.Location = new Point(0, 100);
            flowLayoutPanel.Margin = new Padding(0);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Padding = new Padding(0, 50, 0, 0);
            flowLayoutPanel.Size = new Size(0, 50);
            flowLayoutPanel.TabIndex = 1;
            flowLayoutPanel.WrapContents = false;

            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.ForeColor = Color.White;
            btnSettings.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            btnSettings.Location = new Point(3, 307);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(200, 34);
            btnSettings.TabIndex = 2;
            btnSettings.Text = "Settings";
            btnSettings.Click += BtnSettings_Click;

            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.ForeColor = Color.White;
            btnExit.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            btnExit.Dock = DockStyle.Bottom;
            btnExit.Location = new Point(0, 513);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(200, 40);
            btnExit.TabIndex = 3;
            btnExit.Text = "Exit";
            btnExit.Click += BtnExit_Click;

            pnlContentArea.BackColor = Color.White;
            pnlContentArea.Dock = DockStyle.Fill;
            pnlContentArea.Location = new Point(200, 0);
            pnlContentArea.Name = "pnlContentArea";
            pnlContentArea.Size = new Size(782, 553);
            pnlContentArea.TabIndex = 0;
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            LoadContentArea(new PlayControl(playerName));
        }

        private void BtnScoreBoard_Click(object sender, EventArgs e)
        {
            LoadContentArea(new ScoreControl(playerName));
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            LoadContentArea(new SettingsControl());
        }

        private void LoadContentArea(UserControl content)
        {
            pnlContentArea.Controls.Clear();
            content.Dock = DockStyle.Fill;
            pnlContentArea.Controls.Add(content);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

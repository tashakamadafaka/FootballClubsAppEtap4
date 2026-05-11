namespace FootballClubsApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnTeams;
        private System.Windows.Forms.Button btnPlayers;
        private System.Windows.Forms.Button btnTransfers;
        private System.Windows.Forms.Label lblTitle;

        private void InitializeComponent()
        {
            this.btnTeams = new System.Windows.Forms.Button();
            this.btnPlayers = new System.Windows.Forms.Button();
            this.btnTransfers = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Text = "Football Management";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.AutoSize = false;
            this.lblTitle.Size = new System.Drawing.Size(500, 45);
            this.lblTitle.Location = new System.Drawing.Point(0, 20);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // btnTeams
            this.btnTeams.Text = "Отбори";
            this.btnTeams.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnTeams.Size = new System.Drawing.Size(200, 60);
            this.btnTeams.Location = new System.Drawing.Point(150, 100);
            this.btnTeams.Click += new System.EventHandler(this.btnTeams_Click);

            // btnPlayers
            this.btnPlayers.Text = "Играчите";
            this.btnPlayers.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnPlayers.Size = new System.Drawing.Size(200, 60);
            this.btnPlayers.Location = new System.Drawing.Point(150, 180);
            this.btnPlayers.Click += new System.EventHandler(this.btnPlayers_Click);

            // btnTransfers
            this.btnTransfers.Text = "Трансфери";
            this.btnTransfers.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnTransfers.Size = new System.Drawing.Size(200, 60);
            this.btnTransfers.Location = new System.Drawing.Point(150, 260);
            this.btnTransfers.Click += new System.EventHandler(this.btnTransfers_Click);

            // MainForm
            this.ClientSize = new System.Drawing.Size(500, 360);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnTeams);
            this.Controls.Add(this.btnPlayers);
            this.Controls.Add(this.btnTransfers);
            this.Text = "Football Management";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
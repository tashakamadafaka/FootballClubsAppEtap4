using System;
using System.Windows.Forms;

namespace FootballClubsApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnTeams_Click(object sender, EventArgs e)
        {
            Form1 teamsForm = new Form1();
            teamsForm.ShowDialog();
        }

        private void btnPlayers_Click(object sender, EventArgs e)
        {
            PlayersForm playersForm = new PlayersForm();
            playersForm.ShowDialog();
        }

        private void btnTransfers_Click(object sender, EventArgs e)
        {
            TransfersForm transfersForm = new TransfersForm();
            transfersForm.ShowDialog();
        }
    }
}
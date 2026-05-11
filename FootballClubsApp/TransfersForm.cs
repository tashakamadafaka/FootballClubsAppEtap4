using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FootballClubsApp
{
    public partial class TransfersForm : Form
    {
        private readonly TransfersRepository _transfersRepository = new TransfersRepository();
        private readonly PlayersRepository _playersRepository = new PlayersRepository();
        private readonly ClubsRepository _clubsRepository = new ClubsRepository();

        private List<Player> _players = new List<Player>();
        private List<Club> _clubs = new List<Club>();
        private bool _loading = true;

        public TransfersForm()
        {
            InitializeComponent();
        }

        private void TransfersForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                _loading = true;

                // Load lookup data
                _clubs = _clubsRepository.GetAll();
                
                // Get all players (passing null to load all records)
                _players = _playersRepository.GetPlayers(null);

                // Populate Player ComboBox
                cboPlayer.DataSource = null;
                cboPlayer.DataSource = _players;
                cboPlayer.DisplayMember = "FullName";
                cboPlayer.ValueMember = "PlayerId";

                // Populate Destination Club ComboBox
                cboToClub.DataSource = null;
                cboToClub.DataSource = _clubs;
                cboToClub.DisplayMember = "Name";
                cboToClub.ValueMember = "ClubId";

                // Populate Filters
                PopulateFilterComboBoxes();

                _loading = false;

                // Fire initial selection change safely
                cboPlayer_SelectedIndexChanged(cboPlayer, EventArgs.Empty);

                // Load History
                LoadHistory();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Грешка при зареждане на данните: {ex.Message}", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _loading = false;
            }
        }

        private void PopulateFilterComboBoxes()
        {
            // Player Filter
            var filterPlayers = new List<Player> { new Player { PlayerId = 0, FirstName = "Всички", LastName = "" } };
            filterPlayers.AddRange(_players);
            cboFilterPlayer.DataSource = null;
            cboFilterPlayer.DataSource = filterPlayers;
            cboFilterPlayer.DisplayMember = "FullName";
            cboFilterPlayer.ValueMember = "PlayerId";

            // Club Filter
            var filterClubs = new List<Club> { new Club { ClubId = 0, Name = "Всички" } };
            filterClubs.AddRange(_clubs);
            cboFilterClub.DataSource = null;
            cboFilterClub.DataSource = filterClubs;
            cboFilterClub.DisplayMember = "Name";
            cboFilterClub.ValueMember = "ClubId";
        }

        private void cboPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_loading || cboPlayer.SelectedItem == null) return;

            var player = cboPlayer.SelectedItem as Player;
            if (player != null)
            {
                var club = _clubs.FirstOrDefault(c => c.ClubId == player.ClubId);
                txtFromClub.Text = club != null ? club.Name : "Свободен агент";
            }
        }

        private void LoadHistory()
        {
            try
            {
                int? playerId = null;
                if (cboFilterPlayer.SelectedValue != null && (int)cboFilterPlayer.SelectedValue > 0)
                {
                    playerId = (int)cboFilterPlayer.SelectedValue;
                }

                int? clubId = null;
                if (cboFilterClub.SelectedValue != null && (int)cboFilterClub.SelectedValue > 0)
                {
                    clubId = (int)cboFilterClub.SelectedValue;
                }

                var transfers = _transfersRepository.GetTransfers(playerId, clubId);
                dgvTransfers.DataSource = transfers;

                // Adjust column visibility and headers
                if (dgvTransfers.Columns.Count > 0)
                {
                    dgvTransfers.Columns["TransferId"].Visible = false;
                    dgvTransfers.Columns["PlayerId"].Visible = false;
                    dgvTransfers.Columns["FromClubId"].Visible = false;
                    dgvTransfers.Columns["ToClubId"].Visible = false;

                    dgvTransfers.Columns["PlayerName"].HeaderText = "Играч";
                    dgvTransfers.Columns["FromClubName"].HeaderText = "От клуб";
                    dgvTransfers.Columns["ToClubName"].HeaderText = "Към клуб";
                    dgvTransfers.Columns["TransferDate"].HeaderText = "Дата";
                    dgvTransfers.Columns["Fee"].HeaderText = "Такса (EUR)";
                    dgvTransfers.Columns["Note"].HeaderText = "Бележка";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Грешка при зареждане на историята: {ex.Message}", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnFilterChanged(object sender, EventArgs e)
        {
            if (_loading) return;
            LoadHistory();
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            _loading = true;
            cboFilterPlayer.SelectedIndex = 0;
            cboFilterClub.SelectedIndex = 0;
            _loading = false;
            LoadHistory();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Basic validations
                var player = cboPlayer.SelectedItem as Player;
                if (player == null)
                {
                    MessageBox.Show("Моля, изберете валиден играч.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cboToClub.SelectedValue == null)
                {
                    MessageBox.Show("Моля, изберете валиден целеви клуб.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var toClubId = (int)cboToClub.SelectedValue;

                // 2. "Не към същия клуб" validation
                if (player.ClubId == toClubId)
                {
                    MessageBox.Show("Играчът вече е в този клуб! Трансферът не може да бъде извършен към същия клуб.", 
                        "Грешка при валидация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (numFee.Value < 0)
                {
                    MessageBox.Show("Трансферната такса не може да бъде отрицателна.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 3. Assemble and execute transfer
                var transfer = new Transfer
                {
                    PlayerId = player.PlayerId,
                    FromClubId = player.ClubId,
                    ToClubId = toClubId,
                    TransferDate = dtpTransferDate.Value,
                    Fee = numFee.Value,
                    Note = txtNote.Text.Trim()
                };

                _transfersRepository.AddTransfer(transfer);

                MessageBox.Show("Трансферът беше извършен успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 4. Reset input controls and reload
                txtNote.Text = string.Empty;
                numFee.Value = 0;
                dtpTransferDate.Value = DateTime.Now;

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неуспешен трансфер. Операцията беше отменена (Rollback). Детайли: {ex.Message}", 
                    "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

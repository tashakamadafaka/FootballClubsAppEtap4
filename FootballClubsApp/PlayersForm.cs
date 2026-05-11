using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FootballClubsApp
{
    public partial class PlayersForm : Form
    {
        private PlayersRepository repo = new PlayersRepository();
        private ClubsRepository clubsRepo = new ClubsRepository();

        public PlayersForm()
        {
            InitializeComponent();
        }

        private void PlayersForm_Load(object sender, EventArgs e)
        {
            LoadClubs();
            LoadPositions();
            LoadPlayers();
        }

        private void LoadClubs()
        {
            var clubs = clubsRepo.GetAll();

            cboClub.DataSource = new List<Club>(clubs);
            cboClub.DisplayMember = "Name";
            cboClub.ValueMember = "ClubId";

            var clubsFilter = new List<Club> { new Club { ClubId = 0, Name = "Всички" } };
            clubsFilter.AddRange(clubs);
            cboClubFilter.DataSource = clubsFilter;
            cboClubFilter.DisplayMember = "Name";
            cboClubFilter.ValueMember = "ClubId";
            cboClubFilter.SelectedIndex = 0;
        }

        private void LoadPositions()
        {
            string[] positions = { "GK", "DF", "MF", "FW" };
            cboPosition.Items.AddRange(positions);
            cboPositionFilter.Items.Add("Всички");
            cboPositionFilter.Items.AddRange(positions);
            cboPositionFilter.SelectedIndex = 0;
        }

        private void LoadPlayers()
        {
            int? clubId = cboClubFilter.SelectedIndex > 0 ? (int?)((Club)cboClubFilter.SelectedItem).ClubId : null;
            string pos = cboPositionFilter.SelectedIndex > 0 ? cboPositionFilter.SelectedItem.ToString() : null;
            string name = string.IsNullOrWhiteSpace(txtSearchName.Text) ? null : txtSearchName.Text;

            dgvPlayers.DataSource = repo.GetPlayers(clubId, pos, name);
        }

        private void FiltersChanged(object sender, EventArgs e)
        {
            LoadPlayers();
        }

        private void dgvPlayers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvPlayers.Rows[e.RowIndex];
            txtFirstName.Text = row.Cells["FirstName"].Value.ToString();
            txtLastName.Text = row.Cells["LastName"].Value.ToString();
            dtpBirthDate.Value = Convert.ToDateTime(row.Cells["BirthDate"].Value);
            cboPosition.SelectedItem = row.Cells["Position"].Value.ToString();
            numShirtNumber.Value = row.Cells["ShirtNumber"].Value != DBNull.Value ? Convert.ToInt32(row.Cells["ShirtNumber"].Value) : 1;
            txtStatus.Text = row.Cells["Status"].Value.ToString();

            int clubId = Convert.ToInt32(row.Cells["ClubId"].Value);
            cboClub.SelectedValue = clubId;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Player p = new Player
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                BirthDate = dtpBirthDate.Value,
                ClubId = ((Club)cboClub.SelectedItem).ClubId,
                Position = cboPosition.SelectedItem?.ToString(),
                ShirtNumber = (int?)numShirtNumber.Value,
                Status = string.IsNullOrWhiteSpace(txtStatus.Text) ? "Active" : txtStatus.Text
            };

            if (!ValidationService.ValidatePlayer(p, out string error))
            {
                MessageBox.Show(error);
                return;
            }

            repo.Add(p);
            MessageBox.Show("Играч добавен успешно!");
            LoadPlayers();
            ClearForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvPlayers.CurrentRow == null)
            {
                MessageBox.Show("Изберете играч!");
                return;
            }

            Player p = new Player
            {
                PlayerId = Convert.ToInt32(dgvPlayers.CurrentRow.Cells["PlayerId"].Value),
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                BirthDate = dtpBirthDate.Value,
                ClubId = ((Club)cboClub.SelectedItem).ClubId,
                Position = cboPosition.SelectedItem?.ToString(),
                ShirtNumber = (int?)numShirtNumber.Value,
                Status = string.IsNullOrWhiteSpace(txtStatus.Text) ? "Active" : txtStatus.Text
            };

            if (!ValidationService.ValidatePlayer(p, out string error))
            {
                MessageBox.Show(error);
                return;
            }

            repo.Update(p);
            MessageBox.Show("Играчът е редактиран успешно!");
            LoadPlayers();
            ClearForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPlayers.CurrentRow == null)
            {
                MessageBox.Show("Изберете играч!");
                return;
            }

            var confirm = MessageBox.Show("Сигурни ли сте, че искате да изтриете играча?", "Потвърждение", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            int id = Convert.ToInt32(dgvPlayers.CurrentRow.Cells["PlayerId"].Value);
            repo.Delete(id);
            MessageBox.Show("Играчът е изтрит успешно!");
            LoadPlayers();
            ClearForm();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            dtpBirthDate.Value = DateTime.Now;
            cboPosition.SelectedIndex = -1;
            cboClub.SelectedIndex = -1;
            numShirtNumber.Value = 1;
            txtStatus.Clear();
        }
    }
}
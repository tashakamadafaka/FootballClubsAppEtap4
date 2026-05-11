namespace FootballClubsApp
{
    partial class PlayersForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvPlayers;
        private System.Windows.Forms.ComboBox cboClub;
        private System.Windows.Forms.ComboBox cboPosition;
        private System.Windows.Forms.NumericUpDown numShirtNumber;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.ComboBox cboClubFilter;
        private System.Windows.Forms.ComboBox cboPositionFilter;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;

        private void InitializeComponent()
        {
            this.dgvPlayers = new System.Windows.Forms.DataGridView();
            this.cboClub = new System.Windows.Forms.ComboBox();
            this.cboPosition = new System.Windows.Forms.ComboBox();
            this.numShirtNumber = new System.Windows.Forms.NumericUpDown();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.cboClubFilter = new System.Windows.Forms.ComboBox();
            this.cboPositionFilter = new System.Windows.Forms.ComboBox();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();

            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numShirtNumber)).BeginInit();
            this.SuspendLayout();

            // dgvPlayers
            this.dgvPlayers.Location = new System.Drawing.Point(12, 150);
            this.dgvPlayers.Size = new System.Drawing.Size(760, 300);
            this.dgvPlayers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlayers.MultiSelect = false;
            this.dgvPlayers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlayers_CellClick);

            // txtFirstName
            this.txtFirstName.Location = new System.Drawing.Point(12, 12);
            this.txtFirstName.Size = new System.Drawing.Size(150, 23);
            this.txtFirstName.PlaceholderText = "Име";

            // txtLastName
            this.txtLastName.Location = new System.Drawing.Point(170, 12);
            this.txtLastName.Size = new System.Drawing.Size(150, 23);
            this.txtLastName.PlaceholderText = "Фамилия";

            // dtpBirthDate
            this.dtpBirthDate.Location = new System.Drawing.Point(330, 12);
            this.dtpBirthDate.Size = new System.Drawing.Size(150, 23);

            // cboClub
            this.cboClub.Location = new System.Drawing.Point(12, 45);
            this.cboClub.Size = new System.Drawing.Size(150, 23);

            // cboPosition
            this.cboPosition.Location = new System.Drawing.Point(170, 45);
            this.cboPosition.Size = new System.Drawing.Size(150, 23);

            // numShirtNumber
            this.numShirtNumber.Location = new System.Drawing.Point(330, 45);
            this.numShirtNumber.Minimum = 1;
            this.numShirtNumber.Maximum = 99;
            this.numShirtNumber.Value = 1;
            this.numShirtNumber.Size = new System.Drawing.Size(60, 23);

            // txtStatus
            this.txtStatus.Location = new System.Drawing.Point(400, 45);
            this.txtStatus.Size = new System.Drawing.Size(100, 23);
            this.txtStatus.PlaceholderText = "Status";

            // Filters
            this.cboClubFilter.Location = new System.Drawing.Point(12, 100);
            this.cboClubFilter.Size = new System.Drawing.Size(150, 23);
            this.cboClubFilter.SelectedIndexChanged += new System.EventHandler(this.FiltersChanged);

            this.cboPositionFilter.Location = new System.Drawing.Point(170, 100);
            this.cboPositionFilter.Size = new System.Drawing.Size(150, 23);
            this.cboPositionFilter.SelectedIndexChanged += new System.EventHandler(this.FiltersChanged);

            this.txtSearchName.Location = new System.Drawing.Point(330, 100);
            this.txtSearchName.Size = new System.Drawing.Size(150, 23);
            this.txtSearchName.TextChanged += new System.EventHandler(this.FiltersChanged);

            // Buttons
            this.btnAdd.Location = new System.Drawing.Point(520, 12);
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnUpdate.Location = new System.Drawing.Point(600, 12);
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            this.btnDelete.Location = new System.Drawing.Point(680, 12);
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.btnClear.Location = new System.Drawing.Point(520, 45);
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // PlayersForm
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.dgvPlayers);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.dtpBirthDate);
            this.Controls.Add(this.cboClub);
            this.Controls.Add(this.cboPosition);
            this.Controls.Add(this.numShirtNumber);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.cboClubFilter);
            this.Controls.Add(this.cboPositionFilter);
            this.Controls.Add(this.txtSearchName);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);

            this.Text = "Players CRUD";
            this.Load += new System.EventHandler(this.PlayersForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numShirtNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
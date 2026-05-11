namespace FootballClubsApp
{
    partial class TransfersForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox grpAddTransfer;
        private System.Windows.Forms.Label lblPlayer;
        private System.Windows.Forms.ComboBox cboPlayer;
        private System.Windows.Forms.Label lblFromClub;
        private System.Windows.Forms.TextBox txtFromClub;
        private System.Windows.Forms.Label lblToClub;
        private System.Windows.Forms.ComboBox cboToClub;
        private System.Windows.Forms.Label lblTransferDate;
        private System.Windows.Forms.DateTimePicker dtpTransferDate;
        private System.Windows.Forms.Label lblFee;
        private System.Windows.Forms.NumericUpDown numFee;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Button btnTransfer;
        
        private System.Windows.Forms.GroupBox grpHistory;
        private System.Windows.Forms.DataGridView dgvTransfers;
        private System.Windows.Forms.Label lblFilterPlayer;
        private System.Windows.Forms.ComboBox cboFilterPlayer;
        private System.Windows.Forms.Label lblFilterClub;
        private System.Windows.Forms.ComboBox cboFilterClub;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClearFilters;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.grpAddTransfer = new System.Windows.Forms.GroupBox();
            this.lblPlayer = new System.Windows.Forms.Label();
            this.cboPlayer = new System.Windows.Forms.ComboBox();
            this.lblFromClub = new System.Windows.Forms.Label();
            this.txtFromClub = new System.Windows.Forms.TextBox();
            this.lblToClub = new System.Windows.Forms.Label();
            this.cboToClub = new System.Windows.Forms.ComboBox();
            this.lblTransferDate = new System.Windows.Forms.Label();
            this.dtpTransferDate = new System.Windows.Forms.DateTimePicker();
            this.lblFee = new System.Windows.Forms.Label();
            this.numFee = new System.Windows.Forms.NumericUpDown();
            this.lblNote = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.btnTransfer = new System.Windows.Forms.Button();
            
            this.grpHistory = new System.Windows.Forms.GroupBox();
            this.dgvTransfers = new System.Windows.Forms.DataGridView();
            this.lblFilterPlayer = new System.Windows.Forms.Label();
            this.cboFilterPlayer = new System.Windows.Forms.ComboBox();
            this.lblFilterClub = new System.Windows.Forms.Label();
            this.cboFilterClub = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClearFilters = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.numFee)).BeginInit();
            this.grpAddTransfer.SuspendLayout();
            this.grpHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransfers)).BeginInit();
            this.SuspendLayout();

            // grpAddTransfer
            this.grpAddTransfer.Controls.Add(this.lblPlayer);
            this.grpAddTransfer.Controls.Add(this.cboPlayer);
            this.grpAddTransfer.Controls.Add(this.lblFromClub);
            this.grpAddTransfer.Controls.Add(this.txtFromClub);
            this.grpAddTransfer.Controls.Add(this.lblToClub);
            this.grpAddTransfer.Controls.Add(this.cboToClub);
            this.grpAddTransfer.Controls.Add(this.lblTransferDate);
            this.grpAddTransfer.Controls.Add(this.dtpTransferDate);
            this.grpAddTransfer.Controls.Add(this.lblFee);
            this.grpAddTransfer.Controls.Add(this.numFee);
            this.grpAddTransfer.Controls.Add(this.lblNote);
            this.grpAddTransfer.Controls.Add(this.txtNote);
            this.grpAddTransfer.Controls.Add(this.btnTransfer);
            this.grpAddTransfer.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpAddTransfer.Location = new System.Drawing.Point(12, 12);
            this.grpAddTransfer.Name = "grpAddTransfer";
            this.grpAddTransfer.Size = new System.Drawing.Size(320, 500);
            this.grpAddTransfer.TabIndex = 0;
            this.grpAddTransfer.TabStop = false;
            this.grpAddTransfer.Text = "Нов трансфер";

            // lblPlayer
            this.lblPlayer.AutoSize = true;
            this.lblPlayer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPlayer.Location = new System.Drawing.Point(15, 30);
            this.lblPlayer.Name = "lblPlayer";
            this.lblPlayer.Size = new System.Drawing.Size(43, 15);
            this.lblPlayer.Text = "Играч:";

            // cboPlayer
            this.cboPlayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPlayer.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboPlayer.Location = new System.Drawing.Point(15, 50);
            this.cboPlayer.Name = "cboPlayer";
            this.cboPlayer.Size = new System.Drawing.Size(285, 25);
            this.cboPlayer.TabIndex = 1;
            this.cboPlayer.SelectedIndexChanged += new System.EventHandler(this.cboPlayer_SelectedIndexChanged);

            // lblFromClub
            this.lblFromClub.AutoSize = true;
            this.lblFromClub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFromClub.Location = new System.Drawing.Point(15, 90);
            this.lblFromClub.Name = "lblFromClub";
            this.lblFromClub.Size = new System.Drawing.Size(76, 15);
            this.lblFromClub.Text = "Текущ клуб:";

            // txtFromClub
            this.txtFromClub.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtFromClub.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtFromClub.Location = new System.Drawing.Point(15, 110);
            this.txtFromClub.Name = "txtFromClub";
            this.txtFromClub.ReadOnly = true;
            this.txtFromClub.Size = new System.Drawing.Size(285, 24);
            this.txtFromClub.TabIndex = 2;

            // lblToClub
            this.lblToClub.AutoSize = true;
            this.lblToClub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblToClub.Location = new System.Drawing.Point(15, 150);
            this.lblToClub.Name = "lblToClub";
            this.lblToClub.Size = new System.Drawing.Size(65, 15);
            this.lblToClub.Text = "Нов клуб:";

            // cboToClub
            this.cboToClub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboToClub.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboToClub.Location = new System.Drawing.Point(15, 170);
            this.cboToClub.Name = "cboToClub";
            this.cboToClub.Size = new System.Drawing.Size(285, 25);
            this.cboToClub.TabIndex = 3;

            // lblTransferDate
            this.lblTransferDate.AutoSize = true;
            this.lblTransferDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTransferDate.Location = new System.Drawing.Point(15, 210);
            this.lblTransferDate.Name = "lblTransferDate";
            this.lblTransferDate.Size = new System.Drawing.Size(103, 15);
            this.lblTransferDate.Text = "Дата на трансфер:";

            // dtpTransferDate
            this.dtpTransferDate.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpTransferDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTransferDate.Location = new System.Drawing.Point(15, 230);
            this.dtpTransferDate.Name = "dtpTransferDate";
            this.dtpTransferDate.Size = new System.Drawing.Size(285, 24);
            this.dtpTransferDate.TabIndex = 4;

            // lblFee
            this.lblFee.AutoSize = true;
            this.lblFee.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFee.Location = new System.Drawing.Point(15, 270);
            this.lblFee.Name = "lblFee";
            this.lblFee.Size = new System.Drawing.Size(95, 15);
            this.lblFee.Text = "Сума (Трансферна такса):";

            // numFee
            this.numFee.DecimalPlaces = 2;
            this.numFee.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.numFee.Location = new System.Drawing.Point(15, 290);
            this.numFee.Maximum = new decimal(new int[] { 200000000, 0, 0, 0 });
            this.numFee.Name = "numFee";
            this.numFee.Size = new System.Drawing.Size(285, 24);
            this.numFee.TabIndex = 5;

            // lblNote
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNote.Location = new System.Drawing.Point(15, 330);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(59, 15);
            this.lblNote.Text = "Бележка:";

            // txtNote
            this.txtNote.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNote.Location = new System.Drawing.Point(15, 350);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNote.Size = new System.Drawing.Size(285, 60);
            this.txtNote.TabIndex = 6;

            // btnTransfer
            this.btnTransfer.BackColor = System.Drawing.Color.Crimson;
            this.btnTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransfer.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnTransfer.ForeColor = System.Drawing.Color.White;
            this.btnTransfer.Location = new System.Drawing.Point(15, 430);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(285, 45);
            this.btnTransfer.TabIndex = 7;
            this.btnTransfer.Text = "Извърши трансфер";
            this.btnTransfer.UseVisualStyleBackColor = false;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);

            // grpHistory
            this.grpHistory.Controls.Add(this.dgvTransfers);
            this.grpHistory.Controls.Add(this.lblFilterPlayer);
            this.grpHistory.Controls.Add(this.cboFilterPlayer);
            this.grpHistory.Controls.Add(this.lblFilterClub);
            this.grpHistory.Controls.Add(this.cboFilterClub);
            this.grpHistory.Controls.Add(this.btnRefresh);
            this.grpHistory.Controls.Add(this.btnClearFilters);
            this.grpHistory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpHistory.Location = new System.Drawing.Point(345, 12);
            this.grpHistory.Name = "grpHistory";
            this.grpHistory.Size = new System.Drawing.Size(645, 500);
            this.grpHistory.TabIndex = 8;
            this.grpHistory.TabStop = false;
            this.grpHistory.Text = "История и филтриране";

            // lblFilterPlayer
            this.lblFilterPlayer.AutoSize = true;
            this.lblFilterPlayer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFilterPlayer.Location = new System.Drawing.Point(15, 25);
            this.lblFilterPlayer.Name = "lblFilterPlayer";
            this.lblFilterPlayer.Size = new System.Drawing.Size(104, 15);
            this.lblFilterPlayer.Text = "Филтър по играч:";

            // cboFilterPlayer
            this.cboFilterPlayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterPlayer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboFilterPlayer.Location = new System.Drawing.Point(15, 45);
            this.cboFilterPlayer.Name = "cboFilterPlayer";
            this.cboFilterPlayer.Size = new System.Drawing.Size(180, 23);
            this.cboFilterPlayer.TabIndex = 9;
            this.cboFilterPlayer.SelectedIndexChanged += new System.EventHandler(this.OnFilterChanged);

            // lblFilterClub
            this.lblFilterClub.AutoSize = true;
            this.lblFilterClub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFilterClub.Location = new System.Drawing.Point(210, 25);
            this.lblFilterClub.Name = "lblFilterClub";
            this.lblFilterClub.Size = new System.Drawing.Size(98, 15);
            this.lblFilterClub.Text = "Филтър по клуб:";

            // cboFilterClub
            this.cboFilterClub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterClub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboFilterClub.Location = new System.Drawing.Point(210, 45);
            this.cboFilterClub.Name = "cboFilterClub";
            this.cboFilterClub.Size = new System.Drawing.Size(180, 23);
            this.cboFilterClub.TabIndex = 10;
            this.cboFilterClub.SelectedIndexChanged += new System.EventHandler(this.OnFilterChanged);

            // btnClearFilters
            this.btnClearFilters.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClearFilters.Location = new System.Drawing.Point(405, 41);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(110, 28);
            this.btnClearFilters.TabIndex = 11;
            this.btnClearFilters.Text = "Изчисти филтри";
            this.btnClearFilters.UseVisualStyleBackColor = true;
            this.btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);

            // btnRefresh
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefresh.Location = new System.Drawing.Point(525, 41);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(105, 28);
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.Text = "Обнови";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // dgvTransfers
            this.dgvTransfers.AllowUserToAddRows = false;
            this.dgvTransfers.AllowUserToDeleteRows = false;
            this.dgvTransfers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTransfers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransfers.Location = new System.Drawing.Point(15, 85);
            this.dgvTransfers.Name = "dgvTransfers";
            this.dgvTransfers.ReadOnly = true;
            this.dgvTransfers.RowTemplate.Height = 25;
            this.dgvTransfers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransfers.Size = new System.Drawing.Size(615, 395);
            this.dgvTransfers.TabIndex = 13;

            // TransfersForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 524);
            this.Controls.Add(this.grpHistory);
            this.Controls.Add(this.grpAddTransfer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TransfersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление на трансфери";
            this.Load += new System.EventHandler(this.TransfersForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.numFee)).EndInit();
            this.grpAddTransfer.ResumeLayout(false);
            this.grpAddTransfer.PerformLayout();
            this.grpHistory.ResumeLayout(false);
            this.grpHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransfers)).EndInit();
            this.ResumeLayout(false);
        }
    }
}

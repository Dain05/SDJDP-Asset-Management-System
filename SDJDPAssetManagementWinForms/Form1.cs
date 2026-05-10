using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SDJDPAssetManagementWinForms
{
    public partial class Form1 : Form
    {
        string connectionString = @"Server=Dain\SQLEXPRESS;Database=SDJDPAssetDB;Trusted_Connection=True;TrustServerCertificate=True;";

        private string loggedInUser;

        public Form1() : this("admin")
        {
        }

        public Form1(string username)
        {
            InitializeComponent();

            loggedInUser = username;
            this.Text = "Asset Management - Logged in as: " + loggedInUser;
            this.Size = new Size(1050, 620);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(245, 247, 250);

            ApplyModernStyle();
            SetupRubricControls();
            ArrangeControlsClean();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAssetsFromDatabase();
        }

        private void ApplyModernStyle()
        {
            Font modernFont = new Font("Segoe UI", 10);

            foreach (Control control in this.Controls)
            {
                control.Font = modernFont;
            }

            dgvAssets.BackgroundColor = Color.White;
            dgvAssets.BorderStyle = BorderStyle.None;
            dgvAssets.EnableHeadersVisualStyles = false;
            dgvAssets.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59);
            dgvAssets.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAssets.DefaultCellStyle.SelectionBackColor = Color.FromArgb(59, 130, 246);
            dgvAssets.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvAssets.RowTemplate.Height = 30;

            btnAdd.BackColor = Color.FromArgb(34, 197, 94);
            btnAdd.ForeColor = Color.White;
            btnAdd.FlatStyle = FlatStyle.Flat;

            btnUpdate.BackColor = Color.FromArgb(59, 130, 246);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.FlatStyle = FlatStyle.Flat;

            btnDelete.BackColor = Color.FromArgb(239, 68, 68);
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;

            btnSearch.BackColor = Color.FromArgb(168, 85, 247);
            btnSearch.ForeColor = Color.White;
            btnSearch.FlatStyle = FlatStyle.Flat;

            btnClear.BackColor = Color.Gray;
            btnClear.ForeColor = Color.White;
            btnClear.FlatStyle = FlatStyle.Flat;
        }

        private void LoadAssetsFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT AssetID, AssetType, SerialNumber, Department, Status FROM Assets";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);

                dgvAssets.Columns.Clear();
                dgvAssets.AutoGenerateColumns = true;
                dgvAssets.DataSource = table;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAssetID.Text) ||
                string.IsNullOrWhiteSpace(txtAssetType.Text) ||
                string.IsNullOrWhiteSpace(txtSerialNumber.Text) ||
                string.IsNullOrWhiteSpace(txtDepartment.Text) ||
                string.IsNullOrWhiteSpace(cmbStatus.Text))
            {
                MessageBox.Show("Please fill in all fields before adding the asset.");
                txtAssetID.Focus();
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Assets (AssetID, AssetType, SerialNumber, Department, Status) VALUES (@id, @type, @serial, @department, @status)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", txtAssetID.Text);
                cmd.Parameters.AddWithValue("@type", txtAssetType.Text);
                cmd.Parameters.AddWithValue("@serial", txtSerialNumber.Text);
                cmd.Parameters.AddWithValue("@department", txtDepartment.Text);
                cmd.Parameters.AddWithValue("@status", cmbStatus.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Asset added successfully.");
            ClearFields();
            LoadAssetsFromDatabase();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAssetID.Text) ||
                string.IsNullOrWhiteSpace(txtAssetType.Text) ||
                string.IsNullOrWhiteSpace(txtSerialNumber.Text) ||
                string.IsNullOrWhiteSpace(txtDepartment.Text) ||
                string.IsNullOrWhiteSpace(cmbStatus.Text))
            {
                MessageBox.Show("Please select a row and ensure all fields are filled before updating.");
                txtAssetID.Focus();
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Assets SET AssetType=@type, SerialNumber=@serial, Department=@department, Status=@status WHERE AssetID=@id";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", txtAssetID.Text);
                cmd.Parameters.AddWithValue("@type", txtAssetType.Text);
                cmd.Parameters.AddWithValue("@serial", txtSerialNumber.Text);
                cmd.Parameters.AddWithValue("@department", txtDepartment.Text);
                cmd.Parameters.AddWithValue("@status", cmbStatus.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Asset updated successfully.");
            ClearFields();
            LoadAssetsFromDatabase();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAssetID.Text))
            {
                MessageBox.Show("Please select a row to delete.");
                txtAssetID.Focus();
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this asset?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
            {
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Assets WHERE AssetID=@id";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", txtAssetID.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Asset deleted successfully.");
            ClearFields();
            LoadAssetsFromDatabase();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtAssetID.Text;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                MessageBox.Show("Please enter an Asset ID or Asset Type to search.");
                txtAssetID.Focus();
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT AssetID, AssetType, SerialNumber, Department, Status 
                                 FROM Assets 
                                 WHERE AssetID LIKE @search OR AssetType LIKE @search";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@search", "%" + searchText + "%");

                DataTable table = new DataTable();
                adapter.Fill(table);

                dgvAssets.DataSource = table;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadAssetsFromDatabase();
        }

        private void dgvAssets_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAssets.Rows[e.RowIndex];

                txtAssetID.Text = row.Cells["AssetID"].Value?.ToString();
                txtAssetType.Text = row.Cells["AssetType"].Value?.ToString();
                txtSerialNumber.Text = row.Cells["SerialNumber"].Value?.ToString();
                txtDepartment.Text = row.Cells["Department"].Value?.ToString();
                cmbStatus.Text = row.Cells["Status"].Value?.ToString();
            }
        }

        private void dgvAssets_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvAssets_CellClick(sender, e);
        }

        private void ClearFields()
        {
            txtAssetID.Clear();
            txtAssetType.Clear();
            txtSerialNumber.Clear();
            txtDepartment.Clear();
            cmbStatus.SelectedIndex = -1;
            txtAssetID.Focus();
        }

        private void SetupRubricControls()
        {
            GroupBox inputGroup = new GroupBox();
            inputGroup.Text = "";
            inputGroup.Location = new Point(20, 115);
            inputGroup.Size = new Size(1000, 300);
            inputGroup.SendToBack();
            this.Controls.Add(inputGroup);

            Label lblDateAdded = new Label();
            lblDateAdded.Text = "Date Added:";
            lblDateAdded.Location = new Point(30, 435);
            lblDateAdded.AutoSize = true;

            DateTimePicker dtpDateAdded = new DateTimePicker();
            dtpDateAdded.Location = new Point(120, 430);
            dtpDateAdded.Width = 200;

            Label lblNotes = new Label();
            lblNotes.Text = "Notes:";
            lblNotes.Location = new Point(350, 435);
            lblNotes.AutoSize = true;

            TextBox txtNotes = new TextBox();
            txtNotes.Location = new Point(410, 430);
            txtNotes.Size = new Size(350, 60);
            txtNotes.Multiline = true;

            this.Controls.Add(lblDateAdded);
            this.Controls.Add(dtpDateAdded);
            this.Controls.Add(lblNotes);
            this.Controls.Add(txtNotes);
        }

        private void ArrangeControlsClean()
        {
            label1.Location = new Point(30, 30);
            txtAssetID.Location = new Point(95, 27);
            txtAssetID.Size = new Size(110, 27);

            label2.Location = new Point(230, 30);
            txtAssetType.Location = new Point(320, 27);
            txtAssetType.Size = new Size(130, 27);

            label3.Location = new Point(475, 30);
            txtSerialNumber.Location = new Point(590, 27);
            txtSerialNumber.Size = new Size(130, 27);

            label4.Location = new Point(745, 30);
            txtDepartment.Location = new Point(850, 27);
            txtDepartment.Size = new Size(140, 27);

            label5.Location = new Point(30, 75);
            cmbStatus.Location = new Point(95, 72);
            cmbStatus.Size = new Size(160, 28);

            btnAdd.Location = new Point(30, 125);
            btnClear.Location = new Point(150, 125);
            btnDelete.Location = new Point(270, 125);
            btnUpdate.Location = new Point(390, 125);
            btnSearch.Location = new Point(510, 125);

            dgvAssets.Location = new Point(30, 190);
            dgvAssets.Size = new Size(950, 220);
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
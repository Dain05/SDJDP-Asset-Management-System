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
        private NotifyIcon appNotifyIcon;

        public Form1() : this("admin")
        {
        }

        public Form1(string username)
        {
            InitializeComponent();

            loggedInUser = username;
            this.Text = "SDJDP Asset Management System - Logged in as: " + loggedInUser;
            this.Size = new Size(1250, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(245, 247, 250);

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

            SetupRubricControls();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAssetsFromDatabase();
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
            if (string.IsNullOrWhiteSpace(txtAssetID.Text))
            {
                MessageBox.Show("Please select a row to update.");
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
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this asset?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

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
            string searchID = txtAssetID.Text;

            if (string.IsNullOrWhiteSpace(searchID))
            {
                MessageBox.Show("Please enter an Asset ID to search.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT AssetID, AssetType, SerialNumber, Department, Status FROM Assets WHERE AssetID=@id";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@id", searchID);

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
            MenuStrip menuStrip = new MenuStrip();

            ToolStripMenuItem fileMenu = new ToolStripMenuItem("&File");
            ToolStripMenuItem logoutItem = new ToolStripMenuItem("&Logout");
            ToolStripMenuItem exitItem = new ToolStripMenuItem("E&xit");

            ToolStripMenuItem manageMenu = new ToolStripMenuItem("&Manage");
            ToolStripMenuItem assetsItem = new ToolStripMenuItem("&Assets");

            logoutItem.Click += LogoutItem_Click;
            exitItem.Click += ExitItem_Click;
            assetsItem.Click += AssetsItem_Click;

            fileMenu.DropDownItems.Add(logoutItem);
            fileMenu.DropDownItems.Add(exitItem);
            manageMenu.DropDownItems.Add(assetsItem);

            menuStrip.Items.Add(fileMenu);
            menuStrip.Items.Add(manageMenu);

            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);
            this.MainMenuStrip.Dock = DockStyle.Top;

            GroupBox inputGroup = new GroupBox();
            inputGroup.Text = "Asset Information";
            inputGroup.Location = new Point(20, 100);
            inputGroup.Size = new Size(1180, 120);
            inputGroup.SendToBack();
            this.Controls.Add(inputGroup);

            Label lblDateAdded = new Label();
            lblDateAdded.Text = "Date Added:";
            lblDateAdded.Location = new Point(30, 190);
            lblDateAdded.AutoSize = true;

            DateTimePicker dtpDateAdded = new DateTimePicker();
            dtpDateAdded.Location = new Point(120, 185);
            dtpDateAdded.Width = 200;

            Label lblNotes = new Label();
            lblNotes.Text = "Notes:";
            lblNotes.Location = new Point(350, 190);
            lblNotes.AutoSize = true;

            TextBox txtNotes = new TextBox();
            txtNotes.Location = new Point(410, 185);
            txtNotes.Size = new Size(300, 50);
            txtNotes.Multiline = true;

            this.Controls.Add(lblDateAdded);
            this.Controls.Add(dtpDateAdded);
            this.Controls.Add(lblNotes);
            this.Controls.Add(txtNotes);

            StatusStrip statusStrip = new StatusStrip();

            ToolStripStatusLabel userLabel = new ToolStripStatusLabel("Logged in as: " + loggedInUser);
            ToolStripStatusLabel dateLabel = new ToolStripStatusLabel("Date: " + DateTime.Now.ToShortDateString());

            statusStrip.Items.Add(userLabel);
            statusStrip.Items.Add(dateLabel);

            this.Controls.Add(statusStrip);

            appNotifyIcon = new NotifyIcon();
            appNotifyIcon.Icon = SystemIcons.Information;
            appNotifyIcon.Text = "SDJDP Asset Management System";
            appNotifyIcon.Visible = true;
            appNotifyIcon.BalloonTipTitle = "System Running";
            appNotifyIcon.BalloonTipText = "SDJDP Asset Management System is open.";
            appNotifyIcon.ShowBalloonTip(2000);
        }

        private void LogoutItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("User logged out.", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Hide();

            LoginForm loginForm = new LoginForm();

            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Form1 newForm = new Form1(loginForm.LoggedInUser);
                newForm.Show();
            }

            this.Close();
        }

        private void ExitItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void AssetsItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Asset Management form is already open.", "Assets", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.BringToFront();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
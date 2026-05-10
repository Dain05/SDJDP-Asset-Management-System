namespace SDJDPAssetManagementWinForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtAssetID = new TextBox();
            label2 = new Label();
            txtAssetType = new TextBox();
            label3 = new Label();
            txtSerialNumber = new TextBox();
            label4 = new Label();
            txtDepartment = new TextBox();
            label5 = new Label();
            cmbStatus = new ComboBox();
            btnClear = new Button();
            btnSearch = new Button();
            Column5 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            dgvAssets = new DataGridView();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAssets).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 31);
            label1.Name = "label1";
            label1.Size = new Size(63, 20);
            label1.TabIndex = 0;
            label1.Text = "Asset ID";
            label1.Click += label1_Click;
            // 
            // txtAssetID
            // 
            txtAssetID.Location = new Point(79, 35);
            txtAssetID.Name = "txtAssetID";
            txtAssetID.Size = new Size(79, 27);
            txtAssetID.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(164, 35);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 2;
            label2.Text = "Asset Type";
            // 
            // txtAssetType
            // 
            txtAssetType.Location = new Point(249, 36);
            txtAssetType.Name = "txtAssetType";
            txtAssetType.Size = new Size(85, 27);
            txtAssetType.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(344, 35);
            label3.Name = "label3";
            label3.Size = new Size(104, 20);
            label3.TabIndex = 4;
            label3.Text = "Serial Number";
            // 
            // txtSerialNumber
            // 
            txtSerialNumber.Location = new Point(454, 39);
            txtSerialNumber.Name = "txtSerialNumber";
            txtSerialNumber.Size = new Size(85, 27);
            txtSerialNumber.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(566, 39);
            label4.Name = "label4";
            label4.Size = new Size(89, 20);
            label4.TabIndex = 6;
            label4.Text = "Department";
            label4.Click += label4_Click;
            // 
            // txtDepartment
            // 
            txtDepartment.Location = new Point(661, 39);
            txtDepartment.Name = "txtDepartment";
            txtDepartment.Size = new Size(113, 27);
            txtDepartment.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(792, 42);
            label5.Name = "label5";
            label5.Size = new Size(49, 20);
            label5.TabIndex = 8;
            label5.Text = "Status";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Available", "In Use", "Under Maintenance", "Damaged", "Retired" });
            cmbStatus.Location = new Point(847, 38);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(93, 28);
            cmbStatus.TabIndex = 9;
            cmbStatus.SelectedIndexChanged += cmbStatus_SelectedIndexChanged;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(178, 118);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 11;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(697, 118);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(77, 29);
            btnSearch.TabIndex = 12;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // Column5
            // 
            Column5.HeaderText = "Status";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            // 
            // Column4
            // 
            Column4.HeaderText = "Department";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.HeaderText = "Serial Number";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.HeaderText = "Asset Type";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column1
            // 
            Column1.HeaderText = "Asset ID";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // dgvAssets
            // 
            dgvAssets.AllowUserToAddRows = false;
            dgvAssets.AllowUserToOrderColumns = true;
            dgvAssets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAssets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAssets.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5 });
            dgvAssets.Location = new Point(10, 184);
            dgvAssets.MultiSelect = false;
            dgvAssets.Name = "dgvAssets";
            dgvAssets.ReadOnly = true;
            dgvAssets.RowHeadersWidth = 51;
            dgvAssets.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAssets.Size = new Size(943, 208);
            dgvAssets.TabIndex = 13;
            dgvAssets.CellClick += dgvAssets_CellClick;
            dgvAssets.CellContentClick += dgvAssets_CellContentClick;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(10, 118);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "Add Asset";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(566, 118);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 14;
            btnUpdate.Text = "Update Asset";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(354, 118);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 15;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(965, 450);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(dgvAssets);
            Controls.Add(btnSearch);
            Controls.Add(btnClear);
            Controls.Add(btnAdd);
            Controls.Add(cmbStatus);
            Controls.Add(label5);
            Controls.Add(txtDepartment);
            Controls.Add(label4);
            Controls.Add(txtSerialNumber);
            Controls.Add(label3);
            Controls.Add(txtAssetType);
            Controls.Add(label2);
            Controls.Add(txtAssetID);
            Controls.Add(label1);
            Name = "Form1";
            Text = "SDJDP Asset Management System";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAssets).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtAssetID;
        private Label label2;
        private TextBox txtAssetType;
        private Label label3;
        private TextBox txtSerialNumber;
        private Label label4;
        private TextBox txtDepartment;
        private Label label5;
        private ComboBox cmbStatus;
        private Button btnClear;
        private Button btnSearch;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column1;
        private DataGridView dgvAssets;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
    }
}

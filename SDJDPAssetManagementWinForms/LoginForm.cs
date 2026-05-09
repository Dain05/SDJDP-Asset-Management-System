using System;
using System.Drawing;
using System.Windows.Forms;

namespace SDJDPAssetManagementWinForms
{
    public class LoginForm : Form
    {
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnExit;

        public string LoggedInUser { get; private set; } = "";

        public LoginForm()
        {
            this.Text = "SDJDP Asset Management Login";
            this.Size = new Size(700, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.WhiteSmoke;

            Label lblTitle = new Label();
            lblTitle.Text = "SDJDP Asset Management System";
            lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(100, 45);

            Label lblSubtitle = new Label();
            lblSubtitle.Text = "Please login to continue";
            lblSubtitle.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            lblSubtitle.AutoSize = true;
            lblSubtitle.Location = new Point(260, 85);

            Label lblUsername = new Label();
            lblUsername.Text = "Username:";
            lblUsername.Font = new Font("Segoe UI", 11);
            lblUsername.Location = new Point(120, 145);
            lblUsername.AutoSize = true;

            txtUsername = new TextBox();
            txtUsername.Location = new Point(260, 140);
            txtUsername.Width = 280;
            txtUsername.Font = new Font("Segoe UI", 11);

            Label lblPassword = new Label();
            lblPassword.Text = "Password:";
            lblPassword.Font = new Font("Segoe UI", 11);
            lblPassword.Location = new Point(120, 205);
            lblPassword.AutoSize = true;

            txtPassword = new TextBox();
            txtPassword.Location = new Point(260, 200);
            txtPassword.Width = 280;
            txtPassword.Font = new Font("Segoe UI", 11);
            txtPassword.UseSystemPasswordChar = true;

            btnLogin = new Button();
            btnLogin.Text = "&Login";
            btnLogin.Location = new Point(260, 275);
            btnLogin.Size = new Size(130, 45);
            btnLogin.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnLogin.Click += btnLogin_Click;

            btnExit = new Button();
            btnExit.Text = "E&xit";
            btnExit.Location = new Point(410, 275);
            btnExit.Size = new Size(130, 45);
            btnExit.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnExit.Click += btnExit_Click;

            this.Controls.Add(lblTitle);
            this.Controls.Add(lblSubtitle);
            this.Controls.Add(lblUsername);
            this.Controls.Add(txtUsername);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtPassword);
            this.Controls.Add(btnLogin);
            this.Controls.Add(btnExit);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "admin" && txtPassword.Text == "admin123")
            {
                LoggedInUser = txtUsername.Text;

                MessageBox.Show(
                    "Login successful.",
                    "Login",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "Invalid username or password.",
                    "Login Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        private void InitializeComponent()
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
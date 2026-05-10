using System;
using System.Drawing;
using System.Windows.Forms;

namespace SDJDPAssetManagementWinForms
{
    public class MainForm : Form
    {
        private string loggedInUser;
        private NotifyIcon notifyIcon;

        public MainForm(string username)
        {
            loggedInUser = username;

            this.Text = "SDJDP Asset Management System - MDI Main Window";
            this.WindowState = FormWindowState.Maximized;
            this.IsMdiContainer = true;
            this.BackColor = Color.FromArgb(190, 190, 190);

            SetupMenuStrip();
            SetupStatusStrip();
            SetupNotifyIcon();

            OpenAssetForm();
        }

        private void SetupMenuStrip()
        {
            MenuStrip menuStrip = new MenuStrip();

            ToolStripMenuItem fileMenu = new ToolStripMenuItem("&File");
            ToolStripMenuItem logoutItem = new ToolStripMenuItem("&Logout");
            ToolStripMenuItem exitItem = new ToolStripMenuItem("E&xit");

            logoutItem.Click += LogoutItem_Click;
            exitItem.Click += ExitItem_Click;

            fileMenu.DropDownItems.Add(logoutItem);
            fileMenu.DropDownItems.Add(exitItem);

            ToolStripMenuItem manageMenu = new ToolStripMenuItem("&Manage");
            ToolStripMenuItem assetsItem = new ToolStripMenuItem("&Assets");
            assetsItem.Click += AssetsItem_Click;
            manageMenu.DropDownItems.Add(assetsItem);

            ToolStripMenuItem windowMenu = new ToolStripMenuItem("&Window");
            ToolStripMenuItem cascadeItem = new ToolStripMenuItem("&Cascade");
            ToolStripMenuItem tileItem = new ToolStripMenuItem("&Tile Horizontal");

            cascadeItem.Click += (s, e) => this.LayoutMdi(MdiLayout.Cascade);
            tileItem.Click += (s, e) => this.LayoutMdi(MdiLayout.TileHorizontal);

            windowMenu.DropDownItems.Add(cascadeItem);
            windowMenu.DropDownItems.Add(tileItem);

            menuStrip.Items.Add(fileMenu);
            menuStrip.Items.Add(manageMenu);
            menuStrip.Items.Add(windowMenu);

            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);
        }

        private void SetupStatusStrip()
        {
            StatusStrip statusStrip = new StatusStrip();

            statusStrip.Items.Add(new ToolStripStatusLabel("Logged in as: " + loggedInUser));
            statusStrip.Items.Add(new ToolStripStatusLabel("Date: " + DateTime.Now.ToShortDateString()));

            this.Controls.Add(statusStrip);
        }

        private void SetupNotifyIcon()
        {
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = SystemIcons.Information;
            notifyIcon.Text = "SDJDP Asset Management System";
            notifyIcon.Visible = true;
            notifyIcon.BalloonTipTitle = "System Running";
            notifyIcon.BalloonTipText = "SDJDP Asset Management System is open.";
            notifyIcon.ShowBalloonTip(2000);
        }

        private void OpenAssetForm()
        {
            foreach (Form child in this.MdiChildren)
            {
                if (child is Form1)
                {
                    child.BringToFront();
                    child.Activate();

                    MessageBox.Show(
                        "Asset Management form is already open.",
                        "Form Already Open",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }
            }

            Form1 assetForm = new Form1(loggedInUser);
            assetForm.MdiParent = this;
            assetForm.WindowState = FormWindowState.Normal;
            assetForm.StartPosition = FormStartPosition.Manual;
            assetForm.Location = new Point(220, 90);
            assetForm.Show();
        }

        private void AssetsItem_Click(object sender, EventArgs e)
        {
            OpenAssetForm();
        }

        private void LogoutItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();

                LoginForm loginForm = new LoginForm();

                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    MainForm mainForm = new MainForm(loginForm.LoggedInUser);
                    mainForm.Show();
                }

                this.Close();
            }
        }

        private void ExitItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit?",
                "Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                notifyIcon.Visible = false;
                Application.Exit();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (notifyIcon != null)
            {
                notifyIcon.Visible = false;
                notifyIcon.Dispose();
            }

            base.OnFormClosing(e);
        }
    }
}
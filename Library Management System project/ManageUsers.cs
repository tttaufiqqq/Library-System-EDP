using System;
using System.ComponentModel;
using System.Windows.Forms;
using Library_Management_System_project.Services;

namespace Library_Management_System_project
{
    public partial class ManageUsers : UserControl
    {
        private readonly UserService _userService = new UserService();
        private int _selectedUserId;

        public ManageUsers()
        {
            InitializeComponent();
            comboBoxRole.Items.AddRange(new object[] { "Admin", "Staff", "Borrower" });
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            DisplayUsers();
        }

        public void RefreshData()
        {
            if (InvokeRequired) { Invoke((MethodInvoker)RefreshData); return; }
            DisplayUsers();
        }

        private void DisplayUsers()
        {
            try
            {
                dataGridView1.DataSource = _userService.GetRegisteredUsers();
            }
            catch (Exception ex)
            {
                ErrorPresenter.Show("Error loading users", ex);
            }
        }

        private void ClearSelection()
        {
            _selectedUserId = 0;
            textBoxUsername.Text = "";
            textBoxEmail.Text = "";
            comboBoxRole.SelectedIndex = -1;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            try
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                _selectedUserId = (int)row.Cells["userId"].Value;
                textBoxUsername.Text = row.Cells["username"].Value?.ToString();
                textBoxEmail.Text = row.Cells["email"].Value?.ToString();
                comboBoxRole.Text = row.Cells["role"].Value?.ToString();
            }
            catch (Exception ex)
            {
                ErrorPresenter.Show("Error selecting user", ex);
            }
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            if (_selectedUserId == 0)
            {
                MessageBox.Show("Please select a user first.",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxRole.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a role.",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _userService.UpdateUserRole(_selectedUserId, comboBoxRole.Text);
                MessageBox.Show("Role updated successfully.",
                    "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearSelection();
                DisplayUsers();
            }
            catch (Exception ex)
            {
                ErrorPresenter.Show("Error updating role", ex);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (_selectedUserId == 0)
            {
                MessageBox.Show("Please select a user first.",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete " + textBoxUsername.Text + "?",
                "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                _userService.DeleteUser(_selectedUserId);
                MessageBox.Show("User deleted.",
                    "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearSelection();
                DisplayUsers();
            }
            catch (Exception ex)
            {
                ErrorPresenter.Show("Error deleting user", ex);
            }
        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;
using Library_Management_System_project.Services;

namespace Library_Management_System_project
{
    public partial class LoginForm : Form
    {
        private readonly UserService _userService = new UserService();

        public LoginForm()
        {
            InitializeComponent();
            Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            FormDragHelper.EnableDrag(panel1, this);
        }

        private void signupBtn_Click(object sender, EventArgs e)
        {
            new RegisterForm().Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.White;
        }

        private void login_ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            login_password.PasswordChar = login_ShowPassword.Checked ? '\0' : '*';
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (login_username.Text == "" || login_password.Text == "")
            {
                MessageBox.Show("Please fill all required information.",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var user = _userService.Authenticate(
                    login_username.Text.Trim(),
                    login_password.Text);

                if (user != null)
                {
                    MessageBox.Show("Login Successful!",
                        "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    switch (user.role)
                    {
                        case "Admin":
                            MainForm adminForm = new AdminMainForm();
                            adminForm.SetUserLabel(user.username);
                            adminForm.Show();
                            break;
                        case "Staff":
                            MainForm staffForm = new MainForm();
                            staffForm.SetUserLabel(user.username);
                            staffForm.Show();
                            break;
                        case "Borrower":
                            new BorrowerForm(user).Show();
                            break;
                        default:
                            MessageBox.Show($"Unrecognized role '{user.role}' for this account. Contact an administrator.",
                                "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                    }

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Incorrect Password/Username",
                        "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                ErrorPresenter.Show("Error connecting to database", ex);
            }
        }

        private void login_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                loginBtn_Click(sender, e);
        }
    }
}

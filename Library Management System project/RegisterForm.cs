using System;
using System.Drawing;
using System.Windows.Forms;
using Library_Management_System_project.Services;

namespace Library_Management_System_project
{
    public partial class RegisterForm : Form
    {
        private readonly UserService _userService = new UserService();

        public RegisterForm()
        {
            InitializeComponent();
            Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            FormDragHelper.EnableDrag(panel1, this);
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void register_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(register_email.Text) ||
                string.IsNullOrWhiteSpace(register_username.Text) ||
                string.IsNullOrWhiteSpace(register_password.Text))
            {
                MessageBox.Show("Please fill all required information.",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!InputValidator.IsValidEmail(register_email.Text))
            {
                MessageBox.Show("Please enter a valid email address.",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var user = _userService.Register(
                    register_email.Text.Trim(),
                    register_username.Text.Trim(),
                    register_password.Text.Trim());

                if (user == null)
                {
                    MessageBox.Show(register_username.Text.Trim() + " is already taken",
                        "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Successfully Registered",
                    "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                new LoginForm().Show();
                this.Close();
            }
            catch (Exception ex)
            {
                ErrorPresenter.Show("Error connecting to database", ex);
            }
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.White;
        }

        private void register_showpassword_CheckedChanged(object sender, EventArgs e)
        {
            register_password.PasswordChar = register_showpassword.Checked ? '\0' : '*';
        }
    }
}

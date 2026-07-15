using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System;

namespace Library_Management_System_project
{
    public partial class LoginForm : Form
    {
        private LibraryDataContext db = new LibraryDataContext
        (@"Server=CHANGE_ME;Initial Catalog=Library;User Id=CHANGE_ME;Password=CHANGE_ME;Connect Timeout=30");

        public LoginForm()
        {
            InitializeComponent();
        }

        // delegate to open register form
        public delegate void OpenRegForm();
        private void signupBtn_Click(object sender, EventArgs e)
        {
            OpenRegForm OpenForm = () =>
            {
                RegisterForm rForm = new RegisterForm();
                rForm.Show();
                this.Close();
            };
            OpenForm(); // lambda expression to open register form
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit(); // X on the form used as exit button
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.White;
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
        }

        // delegate to show password
        public delegate void ShowPass();
        public void showPass()
        {
            login_password.PasswordChar = login_ShowPassword.Checked ? '\0' : '*';
        }
        private void login_ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            ShowPass show = showPass;
            show(); // call the delegate to show password
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (login_username.Text == "" || login_password.Text == "")
            {
                MessageBox.Show("Please fill all required information.",
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    var user = db.Users.SingleOrDefault(u =>
                    u.username == login_username.Text.Trim() && u.password == login_password.Text.Trim());

                    if (user != null)
                    {
                        MessageBox.Show("Login Successful!",
                            "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MainForm mForm = new MainForm();
                        mForm.SetUserLabel(user.username); // Pass the username to MainForm
                        mForm.Show();
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
                    MessageBox.Show("Error connecting Database: " +
                        ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void login_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginBtn_Click(sender, e); // Trigger the login button click event
            }
        }
    }
}

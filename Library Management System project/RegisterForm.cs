using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Entity;

namespace Library_Management_System_project
{
    public partial class RegisterForm : Form
    {
        SqlConnection connect = new SqlConnection
            (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\taufi\Documents\Library.mdf;Integrated Security=True;Connect Timeout=30");
        public RegisterForm()
        {
            InitializeComponent();
        }
        //delegate to open log in form
        public delegate void OpenLogForm();
        private void backBtn_Click(object sender, EventArgs e)
        {
            OpenLogForm OpenForm = () =>
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Hide();
            };
            OpenForm(); //lambda expression to open log in form
        }

        private void label1_Click(object sender, EventArgs e)//label X to close the application
        {
            Application.Exit(); //X on the form used as exit button
        }

        private void register_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(register_email.Text) || string.IsNullOrWhiteSpace(register_username.Text) || string.IsNullOrWhiteSpace(register_password.Text))
            {
                MessageBox.Show("Please fill all required information.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var dbContext = new LibraryDataContext()) 
                {
                    // Check if username already exists
                    var existingUser = dbContext.Users.FirstOrDefault(u => u.username == register_username.Text.Trim());
                    if (existingUser != null)
                    {
                        MessageBox.Show(register_username.Text.Trim() + " is already taken", "Error Message",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Create new user
                    var newUser = new User
                    {
                        email = register_email.Text.Trim(),
                        username = register_username.Text.Trim(),
                        password = register_password.Text.Trim(),
                        date_register = DateTime.Today
                    };

                    // Add the new user to the database
                    dbContext.Users.InsertOnSubmit(newUser);
                    dbContext.SubmitChanges();

                    MessageBox.Show("Successfully Registered", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoginForm IForm = new LoginForm();
                    IForm.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting Database: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black; //when cursor enter the label the color change
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.White; //when the cursor leave the label the color back to normal
        }

        //delegate to show password
        public delegate void ShowPassword();
        public void showPass()
        {
            register_password.PasswordChar = register_showpassword.Checked ? '\0' : '*';
        }
        private void register_showpassword_CheckedChanged(object sender, EventArgs e)
        {
            ShowPassword show = showPass;
            show(); //call the delegate to show password
        }
    }
}

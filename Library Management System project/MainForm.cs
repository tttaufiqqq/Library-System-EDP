using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System_project
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public void SetUserLabel(string username)
        {
            labelUser.Text = $"{username}!";
        }

        private void label1_Click(object sender, EventArgs e) //label X to close the application
        {
            Application.Exit();
        }

        private void label1_MouseEnter(object sender, EventArgs e) //when cursor enter the label the color change
        {
            label1.ForeColor = Color.Black;
        }

        private void label1_MouseLeave(object sender, EventArgs e) //when the cursor leave the label the color back to normal
        {
            label1.ForeColor = Color.White;
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you sure you want to log out?", 
                "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(check == DialogResult.Yes)
            {
                LoginForm lForm = new LoginForm();
                lForm.Show();
                this.Hide();
            }
        }

        private void buttonDashboard_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = true;
            addBooks1.Visible = false;
            returnBooks1.Visible = false;
            issuedBooks1.Visible = false;
            fine1.Visible = false;
           

            Dashboard dForm = dashboard1 as Dashboard;
            if (dForm != null)
                dForm.refreshData();
        }

        private void buttonAddBooks_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = false;
            addBooks1.Visible = true;
            returnBooks1.Visible = false;
            issuedBooks1.Visible = false;
            fine1.Visible = false;
        

            AddBooks aForm = addBooks1 as AddBooks;
            if(aForm != null)
                aForm.RefreshData();          
        }

        private void buttonIssueBooks_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = false;
            addBooks1.Visible = false;
            returnBooks1.Visible = false;
            issuedBooks1.Visible = true;
            fine1.Visible = false;
           

            IssuedBooks iForm = issuedBooks1 as IssuedBooks;
            if (iForm != null)
                iForm.refreshData();
        }

        private void buttonReturnBooks_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = false;
            addBooks1.Visible = false;
            returnBooks1.Visible = true;
            issuedBooks1.Visible = false;
            fine1.Visible = false;
        

            ReturnBooks rForm =returnBooks1 as ReturnBooks;
            if (rForm != null)
                rForm.refreshData();
        }

        private void BookdetailsBtn_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = false;
            addBooks1.Visible = false;
            returnBooks1.Visible = true;
            issuedBooks1.Visible = false;
            fine1.Visible = false;
          
        }

        private void buttonFine_Click(object sender, EventArgs e)
        {
            dashboard1.Visible = false;
            addBooks1.Visible = false;
            returnBooks1.Visible = true;
            issuedBooks1.Visible = false;
            fine1.Visible = true;
          
        }

        private void fine1_Load(object sender, EventArgs e)
        {
            fine1.Visible = false;
        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Library_Management_System_project
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            FormDragHelper.EnableDrag(panel1, this);
            FormResizeHelper.EnableResize(this);
            FormActiveHighlightHelper.Enable(this);
            addBooks1.SetCanDelete(false);
        }

        public void SetUserLabel(string username)
        {
            labelUser.Text = $"{username}!";
            bookRequests1.SetStaffUsername(username);
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

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out?",
                "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                new LoginForm().Show();
                this.Close();
            }
        }

        protected virtual void ShowPanel(UserControl panel)
        {
            foreach (Control c in panel3.Controls)
                c.Visible = false;
            panel.Visible = true;
        }

        private void buttonDashboard_Click(object sender, EventArgs e)
        {
            ShowPanel(dashboard1);
            dashboard1.RefreshData();
        }

        private void buttonAddBooks_Click(object sender, EventArgs e)
        {
            ShowPanel(addBooks1);
            addBooks1.RefreshData();
        }

        private void buttonIssueBooks_Click(object sender, EventArgs e)
        {
            ShowPanel(issuedBooks1);
            issuedBooks1.refreshData();
        }

        private void buttonReturnBooks_Click(object sender, EventArgs e)
        {
            ShowPanel(returnBooks1);
            returnBooks1.refreshData();
        }

        private void BookdetailsBtn_Click(object sender, EventArgs e)
        {
            ShowPanel(addBooks1);
        }

        private void buttonFine_Click(object sender, EventArgs e)
        {
            ShowPanel(fine1);
            fine1.RefreshData();
        }

        private void buttonBookRequests_Click(object sender, EventArgs e)
        {
            ShowPanel(bookRequests1);
            bookRequests1.RefreshData();
        }

        private void fine1_Load(object sender, EventArgs e)
        {
            fine1.Visible = false;
        }
    }
}

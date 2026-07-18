using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Library_Management_System_project.Services;

namespace Library_Management_System_project
{
    public partial class BorrowerForm : Form
    {
        private readonly IssueService _issueService = new IssueService();
        private readonly string _email;

        public BorrowerForm(User user)
        {
            InitializeComponent();
            Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            FormDragHelper.EnableDrag(panel1, this);

            _email = user.email;
            labelWelcome.Text = $"Welcome, {user.username}!";
            DisplayLoans();
        }

        private void DisplayLoans()
        {
            try
            {
                var loans = _issueService.GetIssuesByEmail(_email)
                    .Select(i => new
                    {
                        i.Book_Title,
                        i.Author,
                        i.Issue_Date,
                        i.Return_Date,
                        i.Return_Status,
                        Fine = FineCalculator.ComputeFine(i)
                    }).ToList();

                dataGridView1.DataSource = loans;
            }
            catch (Exception ex)
            {
                ErrorPresenter.Show("Error loading your loans", ex);
            }
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

        private void ShowPanel(Control panel)
        {
            foreach (Control c in panel3.Controls)
                c.Visible = false;
            panel.Visible = true;
        }

        private void buttonMyLoans_Click(object sender, EventArgs e)
        {
            ShowPanel(dataGridView1);
            DisplayLoans();
        }

        private void buttonBrowseCatalog_Click(object sender, EventArgs e)
        {
            ShowPanel(borrowerCatalog1);
            borrowerCatalog1.RefreshData();
        }

        private void buttonMyFines_Click(object sender, EventArgs e)
        {
            ShowPanel(borrowerFines1);
            borrowerFines1.LoadFines(_email);
        }
    }
}

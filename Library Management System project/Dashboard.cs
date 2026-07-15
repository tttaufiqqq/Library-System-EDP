using System;
using System.Data.Linq;
using System.Drawing; 
using System.Linq;
using System.Windows.Forms;

namespace Library_Management_System_project
{
    public partial class Dashboard : UserControl
    {
        LibraryDataContext context = new LibraryDataContext();

        public Dashboard()
        {
            InitializeComponent();
            displayAvailable();
            displayIssued();
            displayReturned();
            displayUsers();
            toolStripStatusLabel1.Text = "";

            //Draw white border to the panels
            panelAvailable.Paint += new PaintEventHandler(panel_Paint);
            panelBorrowed.Paint += new PaintEventHandler(panel_Paint);
            panelReturned.Paint += new PaintEventHandler(panel_Paint);
            panelUsers.Paint += new PaintEventHandler(panel_Paint);
        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
            displayAvailable();
            displayIssued();
            displayReturned();
            displayUsers();
        }

        public void displayAvailable()
        {
            try
            {
                int availableCount = context.Bookks.Count(book => book.Book_Status == "Available");
                dashboard_Available.Text = availableCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void displayIssued()
        {
            try
            {
                int issuedCount = context.IssuesBooks.Count(issue => issue.Return_Status == "Not Returned");
                dashboard_Issued.Text = issuedCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void displayReturned()
        {
            try
            {
                int returnedCount = context.IssuesBooks.Count(issue => issue.Return_Status == "Returned");
                dashboard_Returned.Text = returnedCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void displayUsers()
        {
            try
            {
                int userCount = context.Users.Count();
                dashboard_Users.Text = userCount.ToString();

                var users = context.Users
                    .OrderBy(user => user.username) // Sorting by registration date
                    .Select(user => new
                    {
                        user.userId,
                        user.username,
                        user.date_register
                    }).ToList();

                dataGridView1.DataSource = users; // Binding the data to DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                // Define the pen for the border
                using (Pen pen = new Pen(Color.White, 2))
                {
                    // Draw the border
                    e.Graphics.DrawRectangle
                        (pen, 0, 0, panel.Width -2, panel.Height -2);
                }
            }
        }

        private void dataGridView1_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Display registered users sorted by alphabets.";
        }

        private void dataGridView1_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void monthCalendar1_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Display today's date.";
        }

        private void monthCalendar1_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void panelReturned_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Display total of books that have been returned to the library";
        }

        private void panelReturned_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void panelAvailable_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Display total of books that are available in the library";
        }

        private void panelAvailable_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void panelBorrowed_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Display total of books that the library lend to people";
        }

        private void panelBorrowed_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void panelUsers_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Display total of users registered in the system";
        }

        private void panelUsers_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }
    }
}

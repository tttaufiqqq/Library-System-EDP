using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Library_Management_System_project.Services;

namespace Library_Management_System_project
{
    public partial class Dashboard : UserControl
    {
        private readonly UserService _userService = new UserService();
        private readonly BookService _bookService = new BookService();
        private readonly IssueService _issueService = new IssueService();

        public Dashboard()
        {
            InitializeComponent();
            RefreshData();
            toolStripStatusLabel1.Text = "";
            panelAvailable.Paint += PanelPaint;
            panelBorrowed.Paint += PanelPaint;
            panelReturned.Paint += PanelPaint;
            panelUsers.Paint += PanelPaint;
        }

        public void RefreshData()
        {
            if (InvokeRequired) { Invoke((MethodInvoker)RefreshData); return; }

            try
            {
                DisplayAvailable();
                DisplayIssued();
                DisplayReturned();
                DisplayUsers();
            }
            catch (Exception ex)
            {
                ErrorPresenter.Show("Error loading dashboard", ex);
            }
        }

        private void DisplayAvailable()
        {
            dashboard_Available.Text = _bookService.GetAvailableBookCount().ToString();
        }

        private void DisplayIssued()
        {
            dashboard_Issued.Text = _issueService.GetIssuedCount().ToString();
        }

        private void DisplayReturned()
        {
            dashboard_Returned.Text = _issueService.GetReturnedCount().ToString();
        }

        private void DisplayUsers()
        {
            dashboard_Users.Text = _userService.GetUserCount().ToString();
            dataGridView1.DataSource = _userService.GetRegisteredUsers();
        }

        private void PanelPaint(object sender, PaintEventArgs e)
        {
            if (sender is Panel panel)
            {
                using (Pen pen = new Pen(Color.White, 2))
                    e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 2, panel.Height - 2);
            }
        }

        private void dataGridView1_MouseEnter(object sender, EventArgs e) => toolStripStatusLabel1.Text = "Display registered users sorted by alphabets.";
        private void dataGridView1_MouseLeave(object sender, EventArgs e) => toolStripStatusLabel1.Text = "";
        private void monthCalendar1_MouseEnter(object sender, EventArgs e) => toolStripStatusLabel1.Text = "Display today's date.";
        private void monthCalendar1_MouseLeave(object sender, EventArgs e) => toolStripStatusLabel1.Text = "";
        private void panelReturned_MouseEnter(object sender, EventArgs e) => toolStripStatusLabel1.Text = "Display total of books that have been returned to the library";
        private void panelReturned_MouseLeave(object sender, EventArgs e) => toolStripStatusLabel1.Text = "";
        private void panelAvailable_MouseEnter(object sender, EventArgs e) => toolStripStatusLabel1.Text = "Display total of books that are available in the library";
        private void panelAvailable_MouseLeave(object sender, EventArgs e) => toolStripStatusLabel1.Text = "";
        private void panelBorrowed_MouseEnter(object sender, EventArgs e) => toolStripStatusLabel1.Text = "Display total of books that the library lend to people";
        private void panelBorrowed_MouseLeave(object sender, EventArgs e) => toolStripStatusLabel1.Text = "";
        private void panelUsers_MouseEnter(object sender, EventArgs e) => toolStripStatusLabel1.Text = "Display total of users registered in the system";
        private void panelUsers_MouseLeave(object sender, EventArgs e) => toolStripStatusLabel1.Text = "";
    }
}

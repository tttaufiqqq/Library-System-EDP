using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Library_Management_System_project.Services;

namespace Library_Management_System_project
{
    public partial class Dashboard : UserControl
    {
        private readonly DashboardService _dashboardService = new DashboardService();

        public Dashboard()
        {
            InitializeComponent();
            GridStyleHelper.Apply(dataGridView1);

            // LicenseManager.UsageMode (not Control.DesignMode) is what reliably
            // reports design time here - Dashboard is loaded as a nested control
            // inside MainForm's designer, where DesignMode is unset in the ctor.
            // Skip live DB calls so opening a parent form's designer never
            // requires a reachable SQL Server.
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

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
                LoadingOverlay.Show(this);
                DisplayAvailable();
                DisplayIssued();
                DisplayReturned();
                DisplayUsers();
                if (chartsPanel.Visible) PopulateCharts();
            }
            catch (Exception ex)
            {
                ErrorPresenter.Show("Error loading dashboard", ex);
            }
            finally
            {
                LoadingOverlay.Hide(this);
            }
        }

        private void DisplayAvailable()
        {
            dashboard_Available.Text = _dashboardService.AvailableBooks.ToString();
        }

        private void DisplayIssued()
        {
            dashboard_Issued.Text = _dashboardService.IssuedBooks.ToString();
        }

        private void DisplayReturned()
        {
            dashboard_Returned.Text = _dashboardService.ReturnedBooks.ToString();
        }

        private void DisplayUsers()
        {
            dashboard_Users.Text = _dashboardService.RegisteredUsers.ToString();
            dataGridView1.DataSource = _dashboardService.GetRegisteredUsers();
            GridStyleHelper.FormatDateColumns(dataGridView1);
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

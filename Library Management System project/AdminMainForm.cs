using System;

namespace Library_Management_System_project
{
    public partial class AdminMainForm : MainForm
    {
        public AdminMainForm()
        {
            InitializeComponent();

            // Admin is management-focused, not a Staff superset: front-desk
            // operations (issue/return/fine) are hidden here.
            buttonIssueBooks.Visible = false;
            buttonReturnBooks.Visible = false;
            buttonFine.Visible = false;
        }

        private void buttonManageUsers_Click(object sender, EventArgs e)
        {
            ShowPanel(manageUsers1);
            manageUsers1.RefreshData();
        }
    }
}

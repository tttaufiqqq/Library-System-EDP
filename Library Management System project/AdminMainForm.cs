using System;

namespace Library_Management_System_project
{
    public partial class AdminMainForm : MainForm
    {
        public AdminMainForm()
        {
            InitializeComponent();
        }

        private void buttonManageUsers_Click(object sender, EventArgs e)
        {
            ShowPanel(manageUsers1);
            manageUsers1.RefreshData();
        }
    }
}

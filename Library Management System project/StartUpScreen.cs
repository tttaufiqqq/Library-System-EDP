using System;
using System.Windows.Forms;

namespace Library_Management_System_project
{
    public partial class StartUpScreen : Form
    {
        public StartUpScreen()
        {
            InitializeComponent();
            InitializeProgressBar();
        }

        private void InitializeProgressBar()
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100; // Adjust this value as needed
            progressBar1.Step = 1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1); // Increment the progress bar by 1

            if (progressBar1.Value >= progressBar1.Maximum)
            {
                timer1.Stop();

                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Hide();
            }
        }
    }
}

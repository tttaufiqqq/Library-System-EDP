using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using AutoUpdaterDotNET;

namespace Library_Management_System_project
{
    public partial class StartUpScreen : Form
    {
        private const int PBM_SETBARCOLOR = 0x0409;

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, int lParam);

        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        private static extern int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList);

        public StartUpScreen()
        {
            InitializeComponent();
            Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            InitializeProgressBar();
            FormDragHelper.EnableDrag(this, this);
            FormDragHelper.EnableDrag(pictureBox1, this);
            FormResizeHelper.EnableResize(this);
            AutoUpdater.Start("https://raw.githubusercontent.com/tttaufiqqq/Library-System-EDP/main/update.xml");
        }

        private void InitializeProgressBar()
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100; // Adjust this value as needed
            progressBar1.Step = 1;
            // PBM_SETBARCOLOR is ignored while the control uses the themed (green)
            // visual style, so drop it to classic rendering first via SetWindowTheme.
            SetWindowTheme(progressBar1.Handle, "", "");
            SendMessage(progressBar1.Handle, PBM_SETBARCOLOR, IntPtr.Zero, ColorTranslator.ToWin32(Color.Yellow));
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

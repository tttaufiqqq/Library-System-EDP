using System;
using System.Net;
using System.Windows.Forms;

namespace Library_Management_System_project
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // .NET Framework 4.7.2 can default to a TLS version the ToyyibPay
            // sandbox rejects outright, well before any app-level error handling
            // sees it - so this is set before anything else runs.
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (sender, e) => ErrorPresenter.Show("Unexpected error", e.Exception);
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                var ex = e.ExceptionObject as Exception ?? new Exception(e.ExceptionObject?.ToString());
                AppLogger.LogError("Fatal error", ex);
                MessageBox.Show("A fatal error occurred and the application must close: " + ex.Message,
                    "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartUpScreen());
        }
    }
}

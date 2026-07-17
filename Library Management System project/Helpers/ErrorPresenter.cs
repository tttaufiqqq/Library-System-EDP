using System;
using System.Windows.Forms;

namespace Library_Management_System_project
{
    public static class ErrorPresenter
    {
        public static void Show(string context, Exception ex)
        {
            AppLogger.LogError(context, ex);
            MessageBox.Show(context + ": " + ex.Message,
                "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

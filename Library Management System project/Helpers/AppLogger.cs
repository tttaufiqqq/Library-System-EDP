using System;
using System.IO;
using System.Windows.Forms;

namespace Library_Management_System_project
{
    public static class AppLogger
    {
        private static readonly string LogFilePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            Application.ProductName, "logs", "app.log");

        public static void LogError(string context, Exception ex)
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(LogFilePath));
                string line = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {context}: {ex}{Environment.NewLine}";
                File.AppendAllText(LogFilePath, line);
            }
            catch
            {
                // Logging must never crash the app it's trying to diagnose.
            }
        }
    }
}

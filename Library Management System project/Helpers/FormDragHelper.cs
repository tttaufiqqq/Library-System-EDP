using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Library_Management_System_project
{
    public static class FormDragHelper
    {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        // Borderless forms (FormBorderStyle.None) have no title bar to drag by default.
        // Hooking MouseDown on a background control and asking Windows to treat it as
        // the caption area gives native, flicker-free window dragging.
        public static void EnableDrag(Control dragHandle, Form form)
        {
            dragHandle.MouseDown += (sender, e) =>
            {
                if (e.Button != MouseButtons.Left) return;
                ReleaseCapture();
                SendMessage(form.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            };
        }
    }
}

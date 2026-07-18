using System.ComponentModel;
using System.Windows.Forms;

namespace Library_Management_System_project
{
    // Borderless forms (FormBorderStyle.None) have no OS-drawn resize border.
    // This adds one by subclassing the form's window handle and answering
    // WM_NCHITTEST near the edges with the matching hit-test code - the same
    // "tell Windows this is a non-client region" trick FormDragHelper uses
    // for dragging (WM_NCLBUTTONDOWN + HTCAPTION), just for the border
    // instead of the caption. Subclassing the handle (rather than attaching
    // to Form.MouseMove/MouseDown) is required here because these forms are
    // fully covered edge-to-edge by docked child panels, so the Form itself
    // never sees mouse events near its own border.
    public static class FormResizeHelper
    {
        private const int WM_NCHITTEST = 0x0084;
        private const int HTCLIENT = 1;
        private const int HTLEFT = 10;
        private const int HTRIGHT = 11;
        private const int HTTOP = 12;
        private const int HTTOPLEFT = 13;
        private const int HTTOPRIGHT = 14;
        private const int HTBOTTOM = 15;
        private const int HTBOTTOMLEFT = 16;
        private const int HTBOTTOMRIGHT = 17;
        private const int BorderThickness = 6;

        public static void EnableResize(Form form)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            if (form.FormBorderStyle != FormBorderStyle.None) return;
            var subclass = new ResizeSubclass(form);
            form.HandleDestroyed += (s, e) => subclass.ReleaseHandle();
        }

        private class ResizeSubclass : NativeWindow
        {
            private readonly Form _form;

            public ResizeSubclass(Form form)
            {
                _form = form;
                AssignHandle(form.Handle);
            }

            protected override void WndProc(ref Message m)
            {
                if (m.Msg == WM_NCHITTEST)
                {
                    int lParam = m.LParam.ToInt32();
                    var screenPoint = new System.Drawing.Point((short)(lParam & 0xFFFF), (short)((lParam >> 16) & 0xFFFF));
                    var p = _form.PointToClient(screenPoint);

                    bool left = p.X <= BorderThickness;
                    bool right = p.X >= _form.ClientSize.Width - BorderThickness;
                    bool top = p.Y <= BorderThickness;
                    bool bottom = p.Y >= _form.ClientSize.Height - BorderThickness;

                    int hit =
                        top && left ? HTTOPLEFT :
                        top && right ? HTTOPRIGHT :
                        bottom && left ? HTBOTTOMLEFT :
                        bottom && right ? HTBOTTOMRIGHT :
                        left ? HTLEFT :
                        right ? HTRIGHT :
                        top ? HTTOP :
                        bottom ? HTBOTTOM :
                        HTCLIENT;

                    m.Result = (System.IntPtr)hit;
                    return;
                }

                base.WndProc(ref m);
            }
        }
    }
}

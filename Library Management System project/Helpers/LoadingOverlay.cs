using System;
using System.Drawing;
using System.Windows.Forms;

namespace Library_Management_System_project
{
    // Show()/Hide() a centered LoadingSpinner over any control while it loads
    // data. Data loads in this app are synchronous, so the spinner won't
    // visibly rotate during the blocking call - it still confirms to the user
    // that something is happening right before and right after the call.
    public static class LoadingOverlay
    {
        private const string SpinnerName = "__loadingSpinner";

        public static void Show(Control parent)
        {
            var spinner = parent.Controls[SpinnerName] as LoadingSpinner;
            if (spinner == null)
            {
                spinner = new LoadingSpinner { Name = SpinnerName };
                parent.Controls.Add(spinner);
            }

            spinner.Location = new Point(
                (parent.ClientSize.Width - spinner.Width) / 2,
                (parent.ClientSize.Height - spinner.Height) / 2);
            spinner.Visible = true;
            spinner.BringToFront();
            parent.Refresh();
        }

        public static void Hide(Control parent)
        {
            if (parent.Controls[SpinnerName] is LoadingSpinner spinner)
                spinner.Visible = false;
        }
    }
}

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Library_Management_System_project
{
    // Small spinning-arc control shown over a parent while a DB call or other
    // work is in progress. Animates via a Timer when the UI thread is free to
    // pump messages; otherwise it still paints once as a "busy" cue.
    public class LoadingSpinner : Control
    {
        private readonly Timer _timer = new Timer { Interval = 40 };
        private float _angle;

        public LoadingSpinner()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint |
                      ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            BackColor = Color.Transparent;
            Size = new Size(36, 36);
            _timer.Tick += (s, e) => { _angle = (_angle + 24) % 360; Invalidate(); };
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            _timer.Enabled = Visible;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var pen = new Pen(Color.SteelBlue, 4) { StartCap = LineCap.Round, EndCap = LineCap.Round })
            {
                var rect = new RectangleF(4, 4, Width - 8, Height - 8);
                e.Graphics.DrawArc(pen, rect, _angle, 270);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) _timer.Dispose();
            base.Dispose(disposing);
        }
    }
}

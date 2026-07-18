using System.Drawing;
using System.Windows.Forms;

namespace Library_Management_System_project
{
    // Draws a SteelBlue glow border around a borderless form's edges while it
    // is the active window, so users can tell at a glance which open form
    // currently has focus. Four thin edge panels sit on top of the form's
    // edge-to-edge docked content (BringToFront) rather than being drawn in
    // the form's own OnPaint, which the content would otherwise fully cover.
    public static class FormActiveHighlightHelper
    {
        private const int Thickness = 3;
        private static readonly Color GlowColor = Color.SteelBlue;

        public static void Enable(Form form)
        {
            var top = MakeEdge();
            var bottom = MakeEdge();
            var left = MakeEdge();
            var right = MakeEdge();

            top.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            bottom.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            left.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            right.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;

            form.Controls.Add(top);
            form.Controls.Add(bottom);
            form.Controls.Add(left);
            form.Controls.Add(right);

            void Layout()
            {
                top.Bounds = new Rectangle(0, 0, form.ClientSize.Width, Thickness);
                bottom.Bounds = new Rectangle(0, form.ClientSize.Height - Thickness, form.ClientSize.Width, Thickness);
                left.Bounds = new Rectangle(0, 0, Thickness, form.ClientSize.Height);
                right.Bounds = new Rectangle(form.ClientSize.Width - Thickness, 0, Thickness, form.ClientSize.Height);
            }

            void SetVisible(bool visible)
            {
                top.Visible = bottom.Visible = left.Visible = right.Visible = visible;
                if (visible)
                {
                    top.BringToFront();
                    bottom.BringToFront();
                    left.BringToFront();
                    right.BringToFront();
                }
            }

            Layout();
            form.Resize += (s, e) => Layout();
            form.Activated += (s, e) => SetVisible(true);
            form.Deactivate += (s, e) => SetVisible(false);
        }

        private static Panel MakeEdge() => new Panel { BackColor = GlowColor, Visible = false };
    }
}

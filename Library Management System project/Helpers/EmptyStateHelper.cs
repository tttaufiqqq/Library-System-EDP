using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Library_Management_System_project
{
    public static class EmptyStateHelper
    {
        public static void Toggle(DataGridView grid, bool isEmpty, string message, Color textColor)
        {
            string tag = "EmptyState:" + grid.Name;
            var label = grid.Parent.Controls.OfType<Label>().FirstOrDefault(l => l.Tag as string == tag);

            if (isEmpty)
            {
                if (label == null)
                {
                    label = new Label
                    {
                        Tag = tag,
                        TextAlign = ContentAlignment.MiddleCenter,
                        BackColor = Color.Transparent
                    };
                    grid.Parent.Controls.Add(label);
                }

                label.Font = grid.Font;
                label.ForeColor = textColor;
                label.Text = message;
                label.Bounds = grid.Bounds;
                label.Visible = true;
                label.BringToFront();
            }
            else if (label != null)
            {
                label.Visible = false;
            }

            grid.Visible = !isEmpty;
        }
    }
}

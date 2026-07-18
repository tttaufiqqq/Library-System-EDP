using System.Collections.Generic;
using System.Windows.Forms;

namespace Library_Management_System_project
{
    public static class ArrowKeyNavigationHelper
    {
        // Up/Down do nothing in a single-line TextBox/MaskedTextBox, so repurposing
        // them to walk the tab order (like Tab/Shift+Tab) lets users fill a form
        // without leaving the keyboard's arrow cluster. Controls that already use
        // Up/Down natively (ComboBox, DateTimePicker, NumericUpDown, multiline
        // TextBox) are left alone.
        public static void Enable(Control container)
        {
            foreach (Control control in AllControls(container))
            {
                if (!IsSingleLineTextInput(control)) continue;

                control.KeyDown += (sender, e) =>
                {
                    if (e.KeyCode != Keys.Up && e.KeyCode != Keys.Down) return;
                    e.Handled = true;
                    container.SelectNextControl((Control)sender, e.KeyCode == Keys.Down, true, true, true);
                };
            }
        }

        private static bool IsSingleLineTextInput(Control control) =>
            (control is TextBox textBox && !textBox.Multiline) || control is MaskedTextBox;

        private static IEnumerable<Control> AllControls(Control root)
        {
            foreach (Control child in root.Controls)
            {
                yield return child;
                foreach (Control grandchild in AllControls(child))
                    yield return grandchild;
            }
        }
    }
}

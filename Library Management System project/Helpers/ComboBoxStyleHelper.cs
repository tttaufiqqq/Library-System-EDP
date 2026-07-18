using System.Drawing;
using System.Windows.Forms;

namespace Library_Management_System_project
{
    // One consistent, clean look for every ComboBox in the app - call once,
    // right after InitializeComponent(), from each Form/UserControl that
    // hosts a dropdown. Deliberately leaves DropDownStyle untouched - some
    // combos in this app are populated purely for display (their .Text is
    // set programmatically without a matching Item), and forcing
    // DropDownList on those would silently blank them out.
    public static class ComboBoxStyleHelper
    {
        public static void Apply(ComboBox combo)
        {
            combo.FlatStyle = FlatStyle.Flat;
            combo.BackColor = Color.White;
            combo.ForeColor = Color.Black;
            combo.Font = new Font("Arial", 9.5F);
        }
    }
}

using System.Drawing;
using System.Windows.Forms;

namespace Library_Management_System_project
{
    // One consistent, clean look for every DateTimePicker's popup calendar
    // in the app - call once, right after InitializeComponent(), from each
    // Form/UserControl that hosts a date picker. Matches the SteelBlue/White
    // theme already used by grids and dropdowns.
    public static class DateTimePickerStyleHelper
    {
        public static void Apply(DateTimePicker picker)
        {
            picker.Format = DateTimePickerFormat.Custom;
            picker.CustomFormat = "dd/MM/yyyy";
            picker.Font = new Font("Arial", 9.5F);
            picker.CalendarForeColor = Color.Black;
            picker.CalendarMonthBackground = Color.White;
            picker.CalendarTitleBackColor = Color.SteelBlue;
            picker.CalendarTitleForeColor = Color.White;
            picker.CalendarTrailingForeColor = Color.Gainsboro;
        }
    }
}

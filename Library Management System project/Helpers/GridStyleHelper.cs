using System.Drawing;
using System.Windows.Forms;

namespace Library_Management_System_project
{
    // One consistent, clean look for every DataGridView in the app - call
    // once, right after InitializeComponent(), from each Form/UserControl
    // that hosts a grid. Matches the SteelBlue/White theme already used by
    // buttons and panels throughout the app.
    public static class GridStyleHelper
    {
        public static void Apply(DataGridView grid)
        {
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.GridColor = Color.Gainsboro;
            grid.BackgroundColor = Color.White;
            grid.RowHeadersVisible = false;
            grid.EnableHeadersVisualStyles = false;
            grid.AllowUserToResizeRows = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.ColumnHeadersHeight = 34;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8.5F, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(6, 0, 0, 0);

            grid.RowTemplate.Height = 28;
            grid.DefaultCellStyle.Font = new Font("Arial", 9.5F);
            grid.DefaultCellStyle.BackColor = Color.White;
            grid.DefaultCellStyle.ForeColor = Color.Black;
            grid.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            grid.DefaultCellStyle.SelectionForeColor = Color.Navy;
            grid.DefaultCellStyle.Padding = new Padding(4, 2, 4, 2);
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
        }
    }
}

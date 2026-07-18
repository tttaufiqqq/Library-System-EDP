using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Library_Management_System_project
{
    // One consistent, clean look for every DataGridView in the app - call
    // once, right after InitializeComponent(), from each Form/UserControl
    // that hosts a grid. Matches the SteelBlue/White theme already used by
    // buttons and panels throughout the app. Also wires Shift+MouseWheel to
    // scroll the grid horizontally instead of vertically.
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

            // Skip handle-subclassing in the Designer - it hosts controls in
            // ways that don't play well with manual NativeWindow subclassing.
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
                new ShiftWheelHorizontalScroll(grid);
        }

        // DataGridView has no public "scroll horizontally on Shift+wheel"
        // option, and its own MouseWheel handling always scrolls vertically
        // regardless of modifier keys. Subclassing the grid's window handle
        // to intercept WM_MOUSEWHEEL lets us redirect it to
        // HorizontalScrollingOffset when Shift is held, without needing a
        // custom DataGridView subclass in every Designer.cs.
        private class ShiftWheelHorizontalScroll : NativeWindow
        {
            private const int WM_MOUSEWHEEL = 0x020A;
            private const int ScrollStep = 30;

            private readonly DataGridView _grid;

            public ShiftWheelHorizontalScroll(DataGridView grid)
            {
                _grid = grid;
                if (grid.IsHandleCreated) AssignHandle(grid.Handle);
                grid.HandleCreated += (s, e) => AssignHandle(grid.Handle);
                grid.HandleDestroyed += (s, e) => ReleaseHandle();
            }

            protected override void WndProc(ref Message m)
            {
                if (m.Msg == WM_MOUSEWHEEL && (Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                {
                    int wheelDelta = (short)((m.WParam.ToInt64() >> 16) & 0xFFFF);
                    int totalWidth = _grid.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);
                    int maxOffset = System.Math.Max(0, totalWidth - _grid.ClientSize.Width);
                    int newOffset = _grid.HorizontalScrollingOffset - System.Math.Sign(wheelDelta) * ScrollStep;
                    _grid.HorizontalScrollingOffset = System.Math.Max(0, System.Math.Min(newOffset, maxOffset));
                    return;
                }

                base.WndProc(ref m);
            }
        }
    }
}

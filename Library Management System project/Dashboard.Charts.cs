using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;

namespace Library_Management_System_project
{
    public partial class Dashboard
    {
        // Charts are Admin-only (see docs/role-permissions-and-dashboards.md);
        // Staff keeps the registered-users grid + calendar in this same slot.
        public void SetChartsVisible(bool visible)
        {
            chartsPanel.Visible = visible;
            flowLayoutPanel2.Visible = !visible;
        }

        private void PopulateCharts()
        {
            FillChart(chartBooksByStatus, _dashboardService.GetBooksByStatus());
            FillChart(chartUsersByRole, _dashboardService.GetUsersByRole());
            FillChart(chartIssuesOverTime, _dashboardService.GetIssuesByMonth());
            FillChart(chartTopBorrowed, _dashboardService.GetTopBorrowedBooks());
        }

        private static void FillChart(Chart chart, List<KeyValuePair<string, int>> data)
        {
            var points = chart.Series[0].Points;
            points.Clear();
            foreach (var kvp in data)
                points.AddXY(kvp.Key, kvp.Value);
        }
    }
}

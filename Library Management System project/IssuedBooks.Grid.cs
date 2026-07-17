using System;
using System.Windows.Forms;

namespace Library_Management_System_project
{
    public partial class IssuedBooks
    {
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            try
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                bookIssue_id.Text = row.Cells[1]?.Value?.ToString() ?? string.Empty;
                bookIssue_name.Text = row.Cells[2]?.Value?.ToString() ?? string.Empty;
                bookIssue_contact.Text = row.Cells[3]?.Value?.ToString() ?? string.Empty;
                bookIssue_email.Text = row.Cells[4]?.Value?.ToString() ?? string.Empty;
                bookIssue_bookTitle.Text = row.Cells[5]?.Value?.ToString() ?? string.Empty;
                bookIssue_author.Text = row.Cells[6]?.Value?.ToString() ?? string.Empty;
                bookIssue_status.Text = row.Cells[10]?.Value?.ToString() ?? string.Empty;
                bookIssue_issueDate.Value = row.Cells[9]?.Value != null ?
                    Convert.ToDateTime(row.Cells[9].Value) : DateTime.Today;
                bookIssue_returnDate.Value = row.Cells[8]?.Value != null ?
                    Convert.ToDateTime(row.Cells[8].Value) : DateTime.Today;
            }
            catch (Exception ex)
            {
                ErrorPresenter.Show("Error selecting issue", ex);
            }
        }

        private void bookIssue_Clear_Click(object sender, EventArgs e)
        {
            clearFields();
        }
    }
}

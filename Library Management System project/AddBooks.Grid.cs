using System;
using System.Windows.Forms;

namespace Library_Management_System_project
{
    public partial class AddBooks
    {
        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            try
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                _selectedBookId = (int)row.Cells[0].Value;
                BookTitle.Text = row.Cells[1].Value?.ToString();
                Author.Text = row.Cells[2].Value?.ToString();
                PublishedDate.Text = row.Cells[3].Value?.ToString();
                Status.Text = row.Cells[4].Value?.ToString();

                string imageKey = row.Cells[7].Value?.ToString();
                Add_PictureBox.Image = _bookService.LoadBookImage(imageKey);
            }
            catch (Exception ex)
            {
                ErrorPresenter.Show("Error selecting book", ex);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Library_Management_System_project
{
    public class AddBooksRepository : AbstractDataAddBooks
    {
        public List<DataAddBooks> FetchAllBooks()
        {
            var result = new List<DataAddBooks>();
            try
            {
                using (var db = new LibraryDataContext())
                {
                    result = db.Bookks
                        .Where(b => b.Date_Delete == null)
                        .OrderBy(b => b.Book_Title)
                        .Select(b => new DataAddBooks
                        {
                            Id = b.BookID,
                            Title = b.Book_Title,
                            AuthorName = b.Author,
                            PublishedDate = b.Published_Date.HasValue
                                ? b.Published_Date.Value.ToString("yyyy-MM-dd") : null,
                            ImagePath = b.Image,
                            Status = b.Book_Status
                        })
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error fetching books: " + ex.Message,
                    "Error Message", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
            }
            return result;
        }
    }
}

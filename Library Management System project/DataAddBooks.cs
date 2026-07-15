using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Library_Management_System_project
{
    public class DataAddBooks : AbstractDataAddBooks
    {
        public override List<DataAddBooks> AddBooksData()
        {
            List<DataAddBooks> listData = new List<DataAddBooks>();

            try
            {
                using (var db = new LibraryDataContext())
                {
                    var books = from book in db.Bookks
                                where book.Date_Delete == null
                                select new DataAddBooks
                                {
                                    Id = book.BookID,
                                    Title = book.Book_Title,
                                    AuthorName = book.Author,
                                    PublishedDate = book.Published_Date.HasValue
                                    ? book.Published_Date.Value.ToString("yyyy-MM-dd") : null,
                                    ImagePath = book.Image,
                                    Status = book.Book_Status
                                };

                    listData = books.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to database: " + ex.Message,
                   "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return listData;
        }
    }
}

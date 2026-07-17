using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Library_Management_System_project.Services
{
    public class BookService
    {
        public List<Bookk> GetAllBooks()
        {
            using (var db = new LibraryDataContext())
            {
                return db.Bookks.OrderBy(b => b.Book_Title).ToList();
            }
        }

        public List<Bookk> GetAvailableBooks()
        {
            using (var db = new LibraryDataContext())
            {
                return db.Bookks.Where(b => b.Book_Status == "Available").ToList();
            }
        }

        public Bookk GetBookById(int bookId)
        {
            using (var db = new LibraryDataContext())
            {
                return db.Bookks.SingleOrDefault(b => b.BookID == bookId);
            }
        }

        public string SaveBookImage(string imageLocation, string bookTitle, string author)
        {
            string objectKey = $"{bookTitle}_{author}_{DateTime.Today:yyyyMMdd}.jpg";
            new ImageStorageService().UploadImage(imageLocation, objectKey);
            return objectKey;
        }

        public Image LoadBookImage(string objectKey)
        {
            if (string.IsNullOrEmpty(objectKey)) return null;

            try
            {
                using (var stream = new ImageStorageService().DownloadImage(objectKey))
                using (var decoded = Image.FromStream(stream))
                    return new Bitmap(decoded);
            }
            catch
            {
                return null;
            }
        }

        public void AddBook(Bookk book)
        {
            using (var db = new LibraryDataContext())
            {
                db.Bookks.InsertOnSubmit(book);
                db.SubmitChanges();
            }
        }

        public void UpdateBook(int bookId, string title, string author, DateTime? publishedDate,
            string status, string imagePath)
        {
            using (var db = new LibraryDataContext())
            {
                var book = db.Bookks.SingleOrDefault(b => b.BookID == bookId);
                if (book == null) return;

                book.Book_Title = title;
                book.Author = author;
                book.Published_Date = publishedDate;
                book.Book_Status = status;
                book.Date_Update = DateTime.Today;
                if (!string.IsNullOrEmpty(imagePath))
                    book.Image = imagePath;

                db.SubmitChanges();
            }
        }

        public void SoftDeleteBook(int bookId)
        {
            using (var db = new LibraryDataContext())
            {
                var book = db.Bookks.SingleOrDefault(b => b.BookID == bookId);
                if (book == null) return;

                book.Date_Delete = DateTime.Today;
                db.SubmitChanges();
            }
        }

        public string GetBookImagePath(string bookTitle)
        {
            using (var db = new LibraryDataContext())
            {
                return db.Bookks.Where(b => b.Book_Title == bookTitle)
                    .Select(b => b.Image).SingleOrDefault();
            }
        }

        public int GetAvailableBookCount()
        {
            using (var db = new LibraryDataContext())
            {
                return db.Bookks.Count(b => b.Book_Status == "Available");
            }
        }
    }
}

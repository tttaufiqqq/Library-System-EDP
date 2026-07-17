using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Library_Management_System_project.Services
{
    public class BookService : DataService
    {
        private readonly IImageStorageService _imageStorage;

        public BookService() : this(new ImageStorageService()) { }

        public BookService(IImageStorageService imageStorage)
        {
            _imageStorage = imageStorage;
        }

        public List<Bookk> GetAllBooks() =>
            WithContext(db => db.Bookks.OrderBy(b => b.Book_Title).ToList());

        public List<Bookk> GetAvailableBooks() =>
            WithContext(db => db.Bookks.Where(b => b.Book_Status == "Available").ToList());

        public Bookk GetBookById(int bookId) =>
            WithContext(db => db.Bookks.SingleOrDefault(b => b.BookID == bookId));

        public string SaveBookImage(string imageLocation, string bookTitle, string author)
        {
            string objectKey = $"{bookTitle}_{author}_{DateTime.Today:yyyyMMdd}.jpg";
            _imageStorage.UploadImage(imageLocation, objectKey);
            return objectKey;
        }

        public Image LoadBookImage(string objectKey)
        {
            if (string.IsNullOrEmpty(objectKey)) return null;

            try
            {
                using (var stream = _imageStorage.DownloadImage(objectKey))
                using (var decoded = Image.FromStream(stream))
                    return new Bitmap(decoded);
            }
            catch (Exception ex)
            {
                AppLogger.LogError("Failed to load book image '" + objectKey + "'", ex);
                return null;
            }
        }

        public void AddBook(Bookk book) =>
            WithContext(db =>
            {
                db.Bookks.InsertOnSubmit(book);
                db.SubmitChanges();
            });

        public void UpdateBook(int bookId, string title, string author, DateTime? publishedDate,
            string status, string imageKey) =>
            WithContext(db =>
            {
                var book = db.Bookks.SingleOrDefault(b => b.BookID == bookId);
                if (book == null) return;

                book.Book_Title = title;
                book.Author = author;
                book.Published_Date = publishedDate;
                book.Book_Status = status;
                book.Date_Update = DateTime.Today;
                if (!string.IsNullOrEmpty(imageKey))
                    book.Image = imageKey;

                db.SubmitChanges();
            });

        public void SoftDeleteBook(int bookId) =>
            WithContext(db =>
            {
                var book = db.Bookks.SingleOrDefault(b => b.BookID == bookId);
                if (book == null) return;

                book.Date_Delete = DateTime.Today;
                db.SubmitChanges();
            });

        public string GetBookImageKey(string bookTitle) =>
            WithContext(db => db.Bookks.Where(b => b.Book_Title == bookTitle)
                .Select(b => b.Image).SingleOrDefault());

        public int GetAvailableBookCount() =>
            WithContext(db => db.Bookks.Count(b => b.Book_Status == "Available"));
    }
}

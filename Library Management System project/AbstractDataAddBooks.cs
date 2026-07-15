using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System_project
{
    public abstract class AbstractDataAddBooks : IDataAddBooks
    {
        protected string connectionString = 
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\taufi\Documents\Library.mdf;Integrated Security=True;Connect Timeout=30";

        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string PublishedDate { get; set; }
        public string ImagePath { get; set; }
        public string Status { get; set; }

        public abstract List<DataAddBooks> AddBooksData();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System_project
{
    public interface IDataAddBooks
    {
        int Id { get; set; }
        string Title { get; set; }
        string AuthorName { get; set; }
        string PublishedDate { get; set; }
        string ImagePath { get; set; }
        string Status { get; set; }

        List<DataAddBooks> AddBooksData();
    }
}

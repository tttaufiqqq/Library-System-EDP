using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System_project
{
    public abstract class AbstractIssueBooks : IDataIssueBooks
    {
        protected string connectionString = @"Server=CHANGE_ME;Initial Catalog=Library;User Id=CHANGE_ME;Password=CHANGE_ME;Connect Timeout=30";

        public int ID { get; set; }
        public string IssueID { get; set; }
        public string Full_Name { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Book_Title { get; set; }
        public string Author { get; set; }
        public string Issue_Date { get; set; }
        public string Return_Date { get; set; }
        public string Insert_Date { get; set; }
        public string Return_Status { get; set; }

        public abstract List<DataIssueBooks> IssueBooksData();
        public abstract List<DataIssueBooks> ReturnIssueBooksData();
    }
}


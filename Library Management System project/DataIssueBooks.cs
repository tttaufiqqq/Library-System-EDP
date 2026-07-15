using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Library_Management_System_project
{
    public class DataIssueBooks : AbstractIssueBooks
    {
        public override List<DataIssueBooks> IssueBooksData()
        {
            List<DataIssueBooks> listData = new List<DataIssueBooks>();

            try
            {
                using (var db = new LibraryDataContext())
                {
                    var issueBooks = from book in db.IssuesBooks
                                     select new DataIssueBooks
                                     {
                                         ID = book.ID,
                                         IssueID = book.IssueID,
                                         Full_Name = book.Full_Name,
                                         Contact = book.Contact,
                                         Email = book.Email,
                                         Book_Title = book.Book_Title,
                                         Author = book.Author,
                                         Issue_Date = book.Issue_Date,
                                         Return_Date = book.Return_Date,
                                         Insert_Date = book.Insert_Date,
                                         Return_Status = book.Return_Status
                                     };

                    listData = issueBooks.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to database: " + ex.Message,
                    "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return listData;
        }

        public override List<DataIssueBooks> ReturnIssueBooksData()
        {
            List<DataIssueBooks> listData = new List<DataIssueBooks>();

            try
            {
                using (var db = new LibraryDataContext())
                {
                    var issueBooks = from book in db.IssuesBooks
                                     where book.Return_Status == "Not Returned"
                                     select new DataIssueBooks
                                     {
                                         ID = book.ID,
                                         IssueID = book.IssueID,
                                         Full_Name = book.Full_Name,
                                         Contact = book.Contact,
                                         Email = book.Email,
                                         Book_Title = book.Book_Title,
                                         Author = book.Author,
                                         Issue_Date = book.Issue_Date,
                                         Return_Date = book.Return_Date,
                                         Insert_Date = book.Insert_Date,
                                         Return_Status = book.Return_Status
                                     };

                    listData = issueBooks.ToList();
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


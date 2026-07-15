using System;
using System.Collections.Generic;
using System.Linq;

namespace Library_Management_System_project
{
    public class IssueBooksRepository : AbstractIssueBooks
    {
        public List<DataIssueBooks> FetchAllIssues()
        {
            var result = new List<DataIssueBooks>();
            try
            {
                using (var db = new LibraryDataContext())
                {
                    result = db.IssuesBooks
                        .Select(i => new DataIssueBooks
                        {
                            ID = i.ID,
                            IssueID = i.IssueID,
                            Full_Name = i.Full_Name,
                            Contact = i.Contact,
                            Email = i.Email,
                            Book_Title = i.Book_Title,
                            Author = i.Author,
                            Issue_Date = i.Issue_Date,
                            Return_Date = i.Return_Date,
                            Insert_Date = i.Insert_Date,
                            Return_Status = i.Return_Status
                        })
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error fetching issues: " + ex.Message,
                    "Error Message", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
            }
            return result;
        }

        public List<DataIssueBooks> FetchNotReturnedIssues()
        {
            var result = new List<DataIssueBooks>();
            try
            {
                using (var db = new LibraryDataContext())
                {
                    result = db.IssuesBooks
                        .Where(i => i.Return_Status == "Not Returned")
                        .Select(i => new DataIssueBooks
                        {
                            ID = i.ID,
                            IssueID = i.IssueID,
                            Full_Name = i.Full_Name,
                            Contact = i.Contact,
                            Email = i.Email,
                            Book_Title = i.Book_Title,
                            Author = i.Author,
                            Issue_Date = i.Issue_Date,
                            Return_Date = i.Return_Date,
                            Insert_Date = i.Insert_Date,
                            Return_Status = i.Return_Status
                        })
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error fetching issues: " + ex.Message,
                    "Error Message", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
            }
            return result;
        }
    }
}

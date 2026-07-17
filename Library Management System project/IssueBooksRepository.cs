using System.Collections.Generic;
using System.Linq;

namespace Library_Management_System_project
{
    public class IssueBooksRepository
    {
        public List<IssueGridRow> FetchAllIssues()
        {
            using (var db = new LibraryDataContext())
            {
                return db.IssuesBooks
                    .Select(i => new IssueGridRow
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
    }
}

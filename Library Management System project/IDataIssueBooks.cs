using System.Collections.Generic;

namespace Library_Management_System_project
{
    public interface IDataIssueBooks
    {
        int ID { get; set; }
        string IssueID { get; set; }
        string Full_Name { get; set; }
        string Contact { get; set; }
        string Email { get; set; }
        string Book_Title { get; set; }
        string Author { get; set; }
        string Issue_Date { get; set; }
        string Return_Date { get; set; }
        string Insert_Date { get; set; }
        string Return_Status { get; set; }
    }
}

namespace Library_Management_System_project
{
    // Row shape for the Issued Books DataGridView (IssuedBooks.cs), populated by IssueBooksRepository.
    public class IssueGridRow
    {
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
    }
}

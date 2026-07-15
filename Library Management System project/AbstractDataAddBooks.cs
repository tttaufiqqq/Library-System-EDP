namespace Library_Management_System_project
{
    public abstract class AbstractDataAddBooks : IDataAddBooks
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string PublishedDate { get; set; }
        public string ImagePath { get; set; }
        public string Status { get; set; }
    }
}

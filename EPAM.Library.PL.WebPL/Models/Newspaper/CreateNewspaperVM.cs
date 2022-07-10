namespace EPAM.Library.PL.WebPL.Models.Newspaper
{
    public class CreateNewspaperVM
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Publisher { get; set; }
        public int Pages { get; set; }
        public int PublicationYear { get; set; }
        public string ISSN { get; set; }
        public string IssueNumber { get; set; }
        public DateOnly IssueDate { get; set; }
        public string Description { get; set; }
        
    }
}

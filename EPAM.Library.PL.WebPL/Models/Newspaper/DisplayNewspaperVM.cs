using EPAM.Library.Entities;

namespace EPAM.Library.PL.WebPL.Models.Newspaper
{
    public class DisplayNewspaperVM
    {
        public string Name { get; set; }
        public string IssueNumber { get; set; }

        public DateOnly IssueDate { get; set; }
    }
}

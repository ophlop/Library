using EPAM.Library.Entities;

namespace EPAM.Library.PL.WebPL.ViewModels.Book
{
    public class CreateBookVM
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int Pages { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Publisher { get; set; }
        public int PublicationYear { get; set; }
        public string ISBN { get; set; }
        public List<string> Authors { get; set; }
    }
}

namespace EPAM.Library.PL.WebPL.ViewModels.Book
{
    public class DisplayBookVM
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int PublicationYear { get; set; }
        public List<Entities.Author> Authors {get; set;}
    }
}

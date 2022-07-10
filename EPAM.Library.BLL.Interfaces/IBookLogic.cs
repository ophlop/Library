using EPAM.Library.Entities;

namespace EPAM.Library.BLL.Interfaces
{
    public interface IBookLogic
    {
        Guid Add(Book book);
        void Delete(Guid id);
        IEnumerable<Book> FindByAuthor(string author);
        List<IGrouping<string, Book>> FindBookByPublisher(string publisher);
        bool FindByName(string name, out List<Book> books);
        IEnumerable<Book> GetAll();
        List<IGrouping<int, Book>> GroupByPublicationYear();
        IEnumerable<Book> OrderByPublicationYear(IEnumerable<Book> books);
        IEnumerable<Book> OrderByPublicationYearDesc(IEnumerable<Book> books);
    }
}

using EPAM.Library.Entities;

namespace EPAM.Library.DAL.Interfaces
{
    public interface IBookDAO
    {
        Guid Add(Book book);
        void DeleteByID(Guid id);
        void MarkAsDeleted(Guid id);
        IEnumerable<Book> GetAll();
    }
}

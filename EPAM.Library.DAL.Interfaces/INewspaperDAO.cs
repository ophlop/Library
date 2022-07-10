using EPAM.Library.Entities;

namespace EPAM.Library.DAL.Interfaces
{
    public interface INewspaperDAO
    {
        Guid Add(Newspaper book);
        void DeleteByID(Guid id);
        void MarkAsDeleted(Guid id);
        IEnumerable<Newspaper> GetAll();
    }
}

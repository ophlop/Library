using EPAM.Library.Entities;

namespace EPAM.Library.DAL.Interfaces
{
    public interface IPatentDAO
    {
        Guid Add(Patent book);
        void DeleteByID(Guid id);
        void MarkAsDeleted(Guid id);
        IEnumerable<Patent> GetAll();
    }
}

using EPAM.Library.Entities;

namespace EPAM.Library.BLL.Interfaces
{
    public interface IPatentLogic
    {
        Guid Add(Patent patent);
        void Delete(Guid id);
        bool FindByName(string name, out List<Patent> patents);
        IEnumerable<Patent> FindByAuthor(string author);
        IEnumerable<Patent> GetAll();
        List<IGrouping<int, Patent>> GroupByPublicationYear();
        IEnumerable<Patent> OrderByPublicationYear(IEnumerable<Patent> patents);
        IEnumerable<Patent> OrderByPublicationYearDesc(IEnumerable<Patent> patents);
    }
}

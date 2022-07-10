using EPAM.Library.BLL.Interfaces;
using EPAM.Library.DAL.Interfaces;
using EPAM.Library.Entities;

namespace EPAM.Library.BLL
{
    public class NewspaperLogic : INewspaperLogic
    {
        private readonly INewspaperDAO _newspaperDAO;

        public NewspaperLogic(INewspaperDAO newspaperDAO)
        {
            _newspaperDAO = newspaperDAO;
        }

        public Guid Add(Newspaper newspaper)
        {
            return _newspaperDAO.Add(newspaper);
        }

        public void Delete(Guid id)
        {
            _newspaperDAO.DeleteByID(id);
        }

        public IEnumerable<Newspaper> GetAll()
        {
            return _newspaperDAO.GetAll();
        }

        public bool FindByName(string name, out List<Newspaper> newspapers)
        {
            newspapers = _newspaperDAO.GetAll().Where(i => i.Name.ToUpper() == name.ToUpper()).ToList();
            return newspapers.Any();
        }

        public IEnumerable<Newspaper> OrderByPublicationYear(IEnumerable<Newspaper> newspapers)
        {
            return newspapers.OrderBy(i => i.PublicationYear).ToList();
        }

        public IEnumerable<Newspaper> OrderByPublicationYearDesc(IEnumerable<Newspaper> newspapers)
        {
            return newspapers.OrderByDescending(i => i.PublicationYear).ToList();
        }

        public List<IGrouping<int, Newspaper>> GroupByPublicationYear()
        {
            return _newspaperDAO.GetAll().GroupBy(i => i.PublicationYear).ToList();
        }
    }
}

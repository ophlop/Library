using EPAM.Library.BLL.Interfaces;
using EPAM.Library.DAL.Interfaces;
using EPAM.Library.Entities;

namespace EPAM.Library.BLL
{
    public class PatentLogic : IPatentLogic
    {
        private readonly IPatentDAO _patentDAO;

        public PatentLogic(IPatentDAO patentDAO)
        {
            _patentDAO = patentDAO;
        }

        public Guid Add(Patent patent)
        {
            return _patentDAO.Add(patent);
        }

        public void Delete(Guid id)
        {
            _patentDAO.DeleteByID(id);
        }

        public IEnumerable<Patent> GetAll()
        {
            return _patentDAO.GetAll();
        }

        public bool FindByName(string name, out List<Patent> patents)
        {
            patents = _patentDAO.GetAll().Where(i => i.Name.ToUpper() == name.ToUpper()).ToList();
            return patents.Any();
        }

        public IEnumerable<Patent> OrderByPublicationYear(IEnumerable<Patent> patents)
        {
            return patents.OrderBy(i => i.PublicationDate).ToList();
        }

        public IEnumerable<Patent> OrderByPublicationYearDesc(IEnumerable<Patent> patents)
        {
            return patents.OrderByDescending(i => i.PublicationDate).ToList();
        }

        public IEnumerable<Patent> FindByAuthor(string author)
        {
            List<Patent> selectedPatents = new List<Patent>();

            foreach (Patent p in GetAll())
            {
                if (p.Authors.Any(i => i.ToString().Contains(author, StringComparison.CurrentCultureIgnoreCase)))
                {
                    selectedPatents.Add(p);
                }
            }

            return selectedPatents;
        }

        public List<IGrouping<int, Patent>> GroupByPublicationYear()
        {
            return _patentDAO.GetAll().GroupBy(i => i.PublicationDate.Year).ToList();
        }
    }
}

using EPAM.Library.BLL.Interfaces;
using EPAM.Library.DAL.Interfaces;
using EPAM.Library.Entities;

namespace EPAM.Library.BLL
{
    public class AuthorLogic : IAuthorLogic
    {
        private readonly IAuthorDAO _authorDAO;
        public AuthorLogic(IAuthorDAO authorDAO)
        {
            _authorDAO = authorDAO;
        }

        public Guid Add(Author author)
        {
            return _authorDAO.Add(author); //check
        }

        public IEnumerable<Author> GetAll()
        {
            return _authorDAO.GetAll();
        }
    }
}

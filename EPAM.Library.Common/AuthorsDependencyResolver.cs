using EPAM.Library.BLL;
using EPAM.Library.BLL.Interfaces;
using EPAM.Library.DAL;
using EPAM.Library.DAL.Interfaces;

namespace EPAM.Library.Common
{
    public static class AuthorsDependencyResolver
    {
        private static IAuthorLogic _authorLogic;
        private static IAuthorDAO _authorDAO;
        static AuthorsDependencyResolver()
        {
            _authorDAO = new AuthorDAO();
            _authorLogic = new AuthorLogic(_authorDAO);
        }

        public static IAuthorLogic AuthorLogic => _authorLogic;
        public static IAuthorDAO AuthorDAO => _authorDAO;
    }
}

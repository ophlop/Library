using EPAM.Library.BLL;
using EPAM.Library.BLL.Interfaces;
using EPAM.Library.DAL;
using EPAM.Library.DAL.Interfaces;

namespace EPAM.Library.Common
{
    public static class BookDependencyResolver
    {
        private static IBookLogic _bookLogic;
        private static IBookDAO _bookDAO;

        static BookDependencyResolver()
        {
            _bookDAO = new BookDAO();
            _bookLogic = new BookLogic(_bookDAO);
        }

        public static IBookLogic BookLogic => _bookLogic;
        public static IBookDAO BookDAO => _bookDAO;
    }
}

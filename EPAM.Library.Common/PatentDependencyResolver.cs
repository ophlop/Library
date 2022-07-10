using EPAM.Library.BLL;
using EPAM.Library.BLL.Interfaces;
using EPAM.Library.DAL;
using EPAM.Library.DAL.Interfaces;

namespace EPAM.Library.Common
{
    public static class PatentDependencyResolver
    {
        private static readonly IPatentDAO _patentDAO;
        private static readonly IPatentLogic _patentLogic;

        static PatentDependencyResolver()
        {
            _patentDAO = new PatentDAO();
            _patentLogic = new PatentLogic(_patentDAO);
        }

        public static IPatentLogic PatentLogic => _patentLogic;
        public static IPatentDAO PatentDAO => _patentDAO;
    }
}

using EPAM.Library.BLL.Interfaces;
using EPAM.Library.Common;
using EPAM.Library.PL.WebPL.ViewModels.AuthorVM;
using Microsoft.AspNetCore.Mvc;

namespace EPAM.Library.PL.WebPL.Components
{
    public class AuthorsList : ViewComponent
    {
        private IAuthorLogic _authorLogic;
        private DisplayAuthorVM _authorVM;

        public AuthorsList()
        {
            _authorLogic = AuthorsDependencyResolver.AuthorLogic;
            _authorVM = new DisplayAuthorVM(_authorLogic.GetAll());
        }

        public IViewComponentResult Invoke()
        {
            return View("_AuthorsList", _authorVM);
        }
    }
}

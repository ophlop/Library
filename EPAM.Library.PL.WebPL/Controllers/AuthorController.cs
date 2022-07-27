using AutoMapper;
using EPAM.Library.BLL.Interfaces;
using EPAM.Library.Common;
using EPAM.Library.Entities;
using EPAM.Library.PL.WebPL.ViewModels.AuthorVM;
using Microsoft.AspNetCore.Mvc;

namespace EPAM.Library.PL.WebPL.Controllers
{
    public class AuthorController : Controller
    {
        // constructor
        IAuthorLogic _authorLogic = AuthorsDependencyResolver.AuthorLogic;

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateAuthorViewModel createAuthorVM)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/" + createAuthorVM.ControllerName + "/Create.cshtml");
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<CreateAuthorViewModel, Author>());
            IMapper mapper = new Mapper(config);
            var author = mapper.Map<Author>(createAuthorVM);

            _authorLogic.Add(author);
            try
            {
                return RedirectToAction("Create", createAuthorVM.ControllerName);
            }
            catch
            {
                return View("~/Views/" + createAuthorVM.ControllerName + "/Create.cshtml");
            }
        }
    }
}

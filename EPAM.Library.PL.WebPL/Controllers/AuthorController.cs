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
        public IActionResult CreateFromBook(CreateAuthorViewModel createAuthorVM)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Book/Create.cshtml");
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<CreateAuthorViewModel, Author>());
            IMapper mapper = new Mapper(config);
            var author = mapper.Map<Author>(createAuthorVM);

            _authorLogic.Add(author);
            try
            {
                return RedirectToAction("Create", "Book");
            }
            catch
            {
                return View("~/Views/Book/Create.cshtml");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateFromPatent(CreateAuthorViewModel createAuthorVM)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Patent/Create.cshtml");
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<CreateAuthorViewModel, Author>());
            IMapper mapper = new Mapper(config);
            var author = mapper.Map<Author>(createAuthorVM);

            _authorLogic.Add(author);
            try
            {
                return RedirectToAction("Create", "Patent");
            }
            catch
            {
                return View("~/Views/Patent/Create.cshtml");
            }
        }
    }
}

using AutoMapper;
using EPAM.Library.BLL.Interfaces;
using EPAM.Library.Common;
using EPAM.Library.Entities;
using EPAM.Library.PL.WebPL.Models.Newspaper;
using Microsoft.AspNetCore.Mvc;

namespace EPAM.Library.PL.WebPL.Controllers
{
    public class NewspaperController : Controller
    {
        private INewspaperLogic _newspaperLogic;
        public NewspaperController()
        {
           _newspaperLogic = NewspaperDependencyResolver.NewspaperLogic;
        }
         
        public IActionResult Index()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Newspaper, DisplayNewspaperVM>());
            IMapper mapper = new Mapper(config);

            var newspapers = mapper.Map<IEnumerable<DisplayNewspaperVM>>(_newspaperLogic.GetAll());
            return View(newspapers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] CreateNewspaperVM bookVM)
        {
            if(bookVM.IssueDate.Year != bookVM.PublicationYear)
            {
                ModelState.AddModelError("IssueDate", "Wrong date: year of publishing is not the same as year of issue");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }
            
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CreateNewspaperVM, Newspaper>());

            IMapper mapper = new Mapper(config);
            var book = mapper.Map<Newspaper>(bookVM);

            _newspaperLogic.Add(book);

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

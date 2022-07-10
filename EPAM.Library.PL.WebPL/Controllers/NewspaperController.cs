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
        private INewspaperLogic _newspaperLogic = NewspaperDependencyResolver.NewspaperLogic;
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
    }
}

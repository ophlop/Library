using AutoMapper;
using EPAM.Library.BLL.Interfaces;
using EPAM.Library.Common;
using EPAM.Library.Entities;
using EPAM.Library.PL.WebPL.Models.Patents;
using Microsoft.AspNetCore.Mvc;

namespace EPAM.Library.PL.WebPL.Controllers
{
    public class PatentController : Controller
    {
        IPatentLogic _patentLogic;
        public PatentController()
        {
            _patentLogic = PatentDependencyResolver.PatentLogic;
        }

        public IActionResult Index()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Patent, DisplayPatentVM>());

            IMapper mapper = new Mapper(config);
            var patents = mapper.Map<IEnumerable<DisplayPatentVM>>(_patentLogic.GetAll());

            return View(patents);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreatePatentVM patentVM)
        {
            if(patentVM.ApplicationDate > patentVM.PublicationDate)
            {
                ModelState.AddModelError("ApplicationDate", "Application date cannot be later than the publication date");
            }
            
            if (!ModelState.IsValid)
            {
                return View();
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<CreatePatentVM, Patent>());

            IMapper mapper = new Mapper(config);
            var patent = mapper.Map<Patent>(patentVM);

            _patentLogic.Add(patent);

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

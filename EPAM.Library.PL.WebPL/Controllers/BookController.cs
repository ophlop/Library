using AutoMapper;
using EPAM.Library.BLL.Interfaces;
using EPAM.Library.Common;
using EPAM.Library.Entities;
using EPAM.Library.PL.WebPL.ViewModels.Book;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPAM.Library.PL.WebPL.Controllers
{
    public class BookController : Controller
    {
        private IBookLogic bookLogic = BookDependencyResolver.BookLogic;

        // GET: BookController
        public ActionResult Index()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Book, DisplayBookVM>());
            IMapper mapper = new Mapper(config);

            var books = mapper.Map<IEnumerable<DisplayBookVM>>(bookLogic.GetAll());
            return View(books);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] CreateBookVM bookVM)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CreateBookVM, Book>());
            IMapper mapper = new Mapper(config);
            var book = mapper.Map<Book>(bookVM);
            
            bookLogic.Add(book);
            
            try 
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
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

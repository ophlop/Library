using EPAM.Library.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EPAM.Library.PL.WebPL.ViewModels.AuthorVM
{
    public class DisplayAuthorVM
    {
        private List<SelectListItem> _authors;

        public DisplayAuthorVM(IEnumerable<Author> authors)
        {
            _authors = new List<SelectListItem>();

            foreach(Author author in authors)
            {
                _authors.Add( new SelectListItem{Text = author.ToString()});
            }
        }

        public List<SelectListItem> Authors => _authors;
    }
}

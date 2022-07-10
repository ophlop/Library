using EPAM.Library.Entities;

namespace EPAM.Library.PL.WebPL.ViewModels.AuthorVM
{
    public class DisplayAuthorVM
    {
        private List<string> _authors;

        public DisplayAuthorVM(IEnumerable<Author> authors)
        {
            _authors = new List<string>();

            foreach(Author author in authors)
            {
                _authors.Add(author.ToString());
            }
        }

        public List<string> Authors => _authors;
    }
}

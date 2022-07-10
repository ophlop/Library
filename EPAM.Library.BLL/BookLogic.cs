using EPAM.Library.BLL.Interfaces;
using EPAM.Library.DAL.Interfaces;
using EPAM.Library.Entities;

namespace EPAM.Library.BLL
{
    public class BookLogic : IBookLogic
    {
        private readonly IBookDAO _bookDAO;
        public BookLogic(IBookDAO bookDAO)
        {
            _bookDAO = bookDAO;
        }

        public Guid Add(Book book)
        {
            return _bookDAO.Add(book);
        }

        public void Delete(Guid id)
        {
            _bookDAO.DeleteByID(id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _bookDAO.GetAll();
        }

        public bool FindByName(string name, out List<Book> books)
        {
            books = _bookDAO.GetAll().Where(i => i.Name.ToUpper() == name.ToUpper()).ToList();
            return books.Any();
        }

        public IEnumerable<Book> OrderByPublicationYear(IEnumerable<Book> books)
        {
            return books.OrderBy(i => i.PublicationYear).ToList();
        }

        public IEnumerable<Book> OrderByPublicationYearDesc(IEnumerable<Book> books)
        {
            return books.OrderByDescending(i => i.PublicationYear).ToList();
        }

        public IEnumerable<Book> FindByAuthor(string author)
        {
            List<Book> selectedBooks = new List<Book>();

            foreach (Book b in GetAll())
            {
                if (b.Authors.Any(i => i.ToString().Contains(author, StringComparison.CurrentCultureIgnoreCase)))
                {
                    selectedBooks.Add(b);
                }
            }
            return selectedBooks;
        }

        public List<IGrouping<string, Book>> FindBookByPublisher(string publisher)
        {
            List<Book> selectedBooks = new List<Book>();

            foreach (Book b in GetAll())
            {
                if (b.Publisher.StartsWith(publisher))
                {
                    selectedBooks.Add(b);
                }
            }
            return selectedBooks.GroupBy(i => i.Publisher).ToList();
        }

        public List<IGrouping<int, Book>> GroupByPublicationYear()
        {
            return _bookDAO.GetAll().GroupBy(i => i.PublicationYear).ToList();
        }
    }
}

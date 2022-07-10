namespace EPAM.Library.Entities
{
    public class Book
    {
        private Guid _id;
        private string _name;
        private int _pages;
        private string _description;
        private string _city;
        private string _publisher;
        private int _publicationYear;
        private string _isbn;
        private List<Author> _authors;

        public Book(string name, string city, string publisher, int pages, int publicationYear)
        {
            Name = name;
            Pages = pages;
            PublicationYear = publicationYear;
            City = city;
            Publisher = publisher;
            _authors = new List<Author>();
        }

        public Book(string name, string city, string publisher, int pages, int publicationDate, string ISBN
            , List<Author> authors, string description)
            : this(name, city, publisher, pages, publicationDate)
        {
            if(ISBN is null)
            {
                this.ISBN = string.Empty;
            }
            else
            {
                this.ISBN = ISBN;
            }

            if (description is null)
            {
                Description = string.Empty;
            }
            else
            {
                Description = description;
            }

            if (authors != null)
            {
                Authors.AddRange(authors);
            }
        }

        public Guid ID { get => _id; set => _id = value; }

        public virtual string Name
        {
            get => _name;
            set
            {
                if (ValidationHelper.IsValidName(value, out string message))
                {

                    _name = value;
                }
                else
                {
                    throw new ArgumentException(message);
                }
            }
        }

        public int Pages
        {
            get => _pages;
            set
            {
                if (ValidationHelper.IsValidPages(value, out string message))
                {
                    _pages = value;
                }
                else
                {
                    throw new ArgumentException(message);
                }
            }
        }
        public string Description
        {
            get => _description;
            set
            {
                if(value is null)
                {
                    _description = string.Empty;
                }
                else if (ValidationHelper.IsValidDescription(value, out string message))
                {
                    _description = value;

                }
                else
                {
                    throw new ArgumentException(message);
                }
            }
        }

        public List<Author> Authors { get => _authors; }
        public string City
        {
            get => _city;
            set
            {
                if (ValidationHelper.IsValidCity(value, out string message))
                {
                    _city = value;
                }
                else
                {
                    throw new ArgumentException(message);
                }
            }
        }
        public string Publisher
        {
            get => _publisher;
            set
            {
                if(ValidationHelper.IsValidPublisher(value, out string message))
                {
                    _publisher = value;
                }
                else
                {
                    throw new ArgumentException(message);
                }
            }
        }

        public int PublicationYear
        {
            get => _publicationYear;
            set
            {
                if (ValidationHelper.IsValidPublicationYear(value, out string message))
                {
                    _publicationYear = value;
                }
                else
                {
                    throw new ArgumentException(message);
                }
            }
        }

        public string ISBN
        {
            get => _isbn;
            set
            {
                if(value is null)
                {
                    _isbn = string.Empty;
                }
                else if (ValidationHelper.IsValidISBN(value, out string message))
                {
                    _isbn = value;
                }
                else
                {
                    throw new ArgumentException(message);
                }
            }
        }

        public override string ToString()
        {
            try
            {
                return $"Book: {Name}. Author - {Authors[0]}, publication date - {PublicationYear}";
            }
            catch (ArgumentOutOfRangeException)
            {
                return $"Book: {Name}. Author - none, publication date - {PublicationYear}";
            }
        }
    }
}

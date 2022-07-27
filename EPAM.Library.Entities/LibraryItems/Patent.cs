namespace EPAM.Library.Entities
{
    public class Patent
    {
        private Guid _id;
        private string _name;
        private int _pages;
        private string _description;
        private string _country;
        private string _registrationNumber;
        private DateTime _applicationDate;
        private DateTime _publicationDate;
        private List<Author> _authors;

        public Patent(string name, string country, string registrationNumber, int pages, DateTime publicationDate)
        {
            Name = name;
            Pages = pages;
            PublicationDate = publicationDate;
            Country = country;
            RegistrationNumber = registrationNumber;
            _authors = new List<Author>();
        }

        public Patent(string name, string country, string registrationNumber, int pages, DateTime publicationDate, DateTime applicationDate
            , List<Author> authors)
            : this(name, country, registrationNumber, pages, publicationDate)
        {
            Authors.AddRange(authors);
            ApplicationDate = applicationDate;
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
                if (ValidationHelper.IsValidDescription(value, out string message))
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
        public string Country
        {
            get => _country;
            set
            {
                if (ValidationHelper.IsValidCountry(value, out string message))
                {
                    _country = value;
                }

                else 
                { 
                    throw new ArgumentException(message);
                }
            }
        }

        public string RegistrationNumber
        {
            get => _registrationNumber;
            set
            {
                if (ValidationHelper.IsValidRegistrationNumber(value, out string message))
                {
                    _registrationNumber = value;
                }
                else
                {
                    throw new ArgumentException(message);
                }
            }
        }

        public DateTime ApplicationDate
        {
            get => _applicationDate;
            set
            {
                if(ValidationHelper.IsValidApplicationDate(value, out string message))
                {
                    _applicationDate = value;
                }
                else
                {
                    throw new ArgumentException(message);
                }
            }
        }

        public DateTime PublicationDate
        {
            get => _publicationDate;
            set
            {
                if(ValidationHelper.IsValidPublicationYear(value.Year, ApplicationDate, out string message))
                {
                    _publicationDate = value;
                }
                else
                {
                    throw new ArgumentException(message);
                }
            }
        }

        public override string ToString()
        {
            return $"Patent: {Name}. Registration number - {RegistrationNumber}, country - {Country}";
        }
    }
}

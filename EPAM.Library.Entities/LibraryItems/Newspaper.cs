namespace EPAM.Library.Entities
{
    public class Newspaper
    {
        private Guid _id;
        private string _name;
        private int _pages;
        private string _description;
        private string _city;
        private string _publisher;
        private int _publicationYear;
        private DateTime _issueDate;
        private string _issn;

        public Newspaper(string name, string city, string publisher, int pages, int publicationYear, DateTime issueDate)
        {
            Name = name;
            Pages = pages;
            PublicationYear = publicationYear;
            City = city;
            Publisher = publisher;
            IssueDate = issueDate;
        }

        public Newspaper(string name, string city, string publisher, int pages, int publicationDate
            , DateTime issueDate, string issueNumber, string issn, string description)
            : this(name, city, publisher, pages, publicationDate, issueDate)
        {
            ISSN = issn;
            IssueNumber = issueNumber;
            Description = description;
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
                if (ValidationHelper.IsValidPublisher(value, out string message))
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

        public string IssueNumber { get; set; }

        public DateTime IssueDate
        {
            get => _issueDate;
            set
            {
                if (ValidationHelper.IsValidIssueDate(value, PublicationYear, out string message))
                {
                    _issueDate = value;
                }
                else
                {
                    throw new ArgumentException(message);
                }
            }
        }

        public string ISSN
        {
            get => _issn;
            set
            {
                if(ValidationHelper.IsValidISSN(value, out string message))
                {
                    _issn = value;
                }
                else
                {
                    throw new ArgumentException(message);
                }
            }
        }

        public override string ToString()
        {
            return $"Newspaper: {Name}. Publisher - {Publisher}, issue date - {IssueDate.ToString("mm/dd/yyyy")}";
        }
    }
}

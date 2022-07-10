using System.Text.RegularExpressions;

namespace EPAM.Library.Entities
{
    public static class ValidationHelper
    {
        public static bool IsValidName(string name, out string message)
        {
            if (name == null)
            {
                message = "Null refference";
                return false;
            }
            else if (!name.Any())
            {
                message = "Name can't be empty";
                return false;
            }
            else if (name.Length > 300)
            {
                message = "Name can't be longer than 300 simbols";
                return false;
            }
            else
            {
                message = string.Empty;
                return true;
            }
        }

        public static bool IsValidPages(int pages, out string message)
        {
            if (pages <= 0)
            {
                message = "Number of pages should be greater than zero";
                return false;
            }
            else
            {
                message = string.Empty;
                return true;
            }
        }

        public static bool IsValidDescription(string description, out string message)
        {
            if (description.Length > 2000)
            {
                message = "Description can't be longer than 2000 symbols";
                return false;
            }
            else
            {
                message = string.Empty;
                return true;
            }
        }

        public static bool IsValidCity(string city, out string message)
        {
            if (string.IsNullOrEmpty(city))
            {
                message = "City name can't be null or empty";
                return false;
            }
            else if (city.Length > 200)
            {
                message = "City name can't be longer than 200 symbols";
                return false;
            }
            else if (!Regex.IsMatch(city, "(^[A-Z][a-z]*(|(-[A-Z]| [A-Z])|( [a-z]+|-[a-z]+)( |-)[A-Z])([a-z]*)*)$")
                && !Regex.IsMatch(city, "(^[А-ЯЁ][а-яё]*(|(-[А-ЯЁ]| [А-ЯЁ])|( [а-яё]+|-[а-яё]+)( |-)[А-ЯЁ])([а-яё]*)*)$"))
            {
                message = "Invalid city name format";
                return false;
            }
            else
            {
                message = string.Empty;
                return true;
            }
        }

        public static bool IsValidPublisher(string publisher, out string message)
        {
            if (string.IsNullOrEmpty(publisher))
            {
                message = "Null or empty";
                return false;
            }
            else if (publisher.Length > 200)
            {
                message = "Publisher name can't be longer than 200 symbols";
                return false;
            }
            else
            {
                message= string.Empty;
                return true;
            }
        }

        public static bool IsValidPublicationYear(int year, out string message)
        {

            if (year < 1400 || year > DateTime.Now.Year)
            {
                message = "Publication date should be no earlier than 1400 and no later than this year";
                return false;
            }
            else
            {
                message = string.Empty;
                return true;
            }
        }

        public static bool IsValidPublicationYear(int year, DateTime applicationDate, out string message)
        {

            if (applicationDate != default && (year < applicationDate.Year || year > DateTime.Now.Year))
            {
                message = "Publication date should be no earlier than the filing date of the patent application and no later than this year";
                return false;
            }
            else if (year < 1474 || year > DateTime.Now.Year)
            {
                message = "Publication date should be no earlier than 1474 and no later than this year";
                return false;
            }
            else
            {
                message = string.Empty;
                return true;
            }
        }

        public static bool IsValidApplicationDate(DateTime applicationDate, out string message)
        {
            if(applicationDate == default)
            {
                message = string.Empty;
                return true;
            }
            else if (applicationDate.Year < 1474 || applicationDate > DateTime.Now)
            {
                message = "Publication date should be no earlier than 1400 and no later than this year";
                return false;
            }
            else
            {
                message = string.Empty;
                return true;
            }
        }

        public static bool IsValidIssueDate(DateOnly issueDate, int publicationYear, out string message)
        {
            if (issueDate.Year != publicationYear)
            {
                message = "Wrong date: year of publishing is not the same as year of issue";
                return false;
            }
            else
            {
                message = string.Empty;
                return true;
            }
        }

        public static bool IsValidISBN(string isbn, out string message)
        {
            if (isbn.Length == 0)
            {
                message = string.Empty;
                return true;
            }
            else if (isbn.Length != 17)
            {
                message = "Invalid ISBN format: wrong length";
                return false;
            }
            else if (!Regex.IsMatch(isbn, "^ISBN ([0-7]|8[0-9]|9[0-4]|9([5-8][0-9]|9[0-3])|99[4-8][0-9]|999[0-9][0-9])-([0-9]{1,7})-([0-9]{1,7}([0-9]|X))$"))
            {
                message = "Invalid ISBN format";
                return false;
            }
            else
            {
                message = string.Empty;
                return true;
            }
        }

        public static bool IsValidISSN(string issn, out string message)
        {
            if (issn.Length == 0)
            {
                message = string.Empty;
                return true;
            }
            else if (!Regex.IsMatch(issn, "^ISSN [0-9]{4}-[0-9]{4}$"))
            {
                message = "Invalid ISSN format";
                return false;
            }
            else
            {
                message = string.Empty;
                return true;
            }
        }

        public static bool IsValidCountry(string country, out string message)
        {
            if (string.IsNullOrEmpty(country))
            {
                message = "Null or empty";
                return false;
            }
            else if (!Regex.IsMatch(country, "^[A-Z]([a-z]+|[A-Z]+)$|^[А-ЯЁ]([а-яё]+|[А-ЯЁ]+)$"))
            {
                message = "Invalid country format";
                return false;
            }
            else
            {
                message = string.Empty;
                return true;
            }
        }

        public static bool IsValidRegistrationNumber(string regNumber, out string message)
        {
            if (string.IsNullOrEmpty(regNumber))
            {
                message = "Null or empty";
                return false;
            }
            else if (regNumber.Length > 9)
            {
                message = "Can't be longer than 9 digits";
                return false;
            }
            else if (!Regex.IsMatch(regNumber, "^[0-9]{1,9}$"))
            {
                message = "Invalid registration number format";
                return false;
            }
            else
            {
                message = string.Empty;
                return true;
            }
        }
    }
}
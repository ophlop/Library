using System.Text.RegularExpressions;

namespace EPAM.Library.Entities
{
    public class Author  // LastName insted of SecondName
    {
        private string _firstName;
        private string _secondName;

        public Author(string fullName)
        {
            var temp = fullName.Split(' ');
            this.FirstName = temp[0];
            this.SecondName = temp[1];
        }

        public Author(string firstName, string secondName)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (value.Length == 0)
                {
                    _firstName = value;
                    return;
                }

                if (value.Length > 50)
                {
                    throw new ArgumentException("Can't be longer than 50 symbols");
                }

                if (Regex.IsMatch(value, "(^[A-Z][a-z]*(|-[A-Z][a-z]*)$)|(^[А-ЯЁ][а-яё]*(|-[А-ЯЁ][а-яё]*)$)"))
                {
                    _firstName = value;
                }
                else
                {
                    throw new ArgumentException("Invalid name format");
                }
            }
        }
        public string SecondName
        {
            get => _secondName;
            set
            {
                if (value.Length == 0)
                {
                    _firstName = value;
                    return;
                }

                if (value.Length > 200)
                {
                    throw new ArgumentException("Can't be longer than 200 symbols");
                }

                if (Regex.IsMatch(value, "(^[A-Z]([a-z]*('[A-Z])?)*(|-[A-Z]|( [a-z]+|-[a-z]+)( |-)[A-Z])([a-z]*('[A-Z])?)*)$")
                    || Regex.IsMatch(value, "(^[А-ЯЁ]([а-яё]*('[А-ЯЁ])?)*(|-[А-ЯЁ]|( [а-яё]+|-[а-яё]+)( |-)[А-ЯЁ])([а-яё]*('[А-ЯЁ])?)*)$"))
                {
                    _secondName = value;
                }
                else
                {
                    throw new ArgumentException("Invalid second name format");
                }
            }
        }
        public override string ToString()
        {
            if(this is null)
            {
                return "none";
            }
            return FirstName + " " + SecondName;
        }

        public static bool operator ==(Author author1, Author author2)
        {
            return author1.ToString() == author2.ToString();
        }

        public static bool operator !=(Author author1, Author author2)
        {
            return !(author1 == author2);
        }

        public override bool Equals(object? obj)
        {
            if(obj is null)
            {
                return false;
            }
            else if(obj is Author author2)
            {
                return this.ToString() == author2.ToString();
            }
            else
            {
                return false;
            }
        }
    }
}
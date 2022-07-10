using EPAM.Library.Entities;
using System.Data;
using System.Data.SqlClient;
using EPAM.Library.Common.ExtentionMethods;
using EPAM.Library.DAL.Interfaces;

namespace EPAM.Library.DAL
{
    public class BookDAO : IBookDAO
    {
        private readonly string _connectionString = "Data Source=.;Initial Catalog = LibraryDB; Integrated Security = True;";
        private readonly AuthorDAO _authorDAO = new AuthorDAO();

        public Guid Add(Book book)
        {

            if (IsNotUnique(book))
            {
                return Guid.Empty;
            }

            var id = AddToDB(book);

            var authors = book.Authors;

            _authorDAO.AddAuthorsToItem(authors, id);

            return id;
        }

        public void DeleteByID(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "DeleteBookByID";

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@ID",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Direction = ParameterDirection.Input,
                    Value = id
                });

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch
                {
                    throw new Exception("Book deletion failed");
                }
            }
        }

        public void MarkAsDeleted(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "MarkBookAsDeletedByID";

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@ID",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Direction = ParameterDirection.Input,
                    Value = id
                });

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch
                {
                    throw new Exception("Book deletion failed");
                }
            }
        }

        public IEnumerable<Book> GetAll()
        {
            List<Book> books = new List<Book>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetAllBooks";

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var book = new Book((string)reader["Name"], (string)reader["City"]
                        , (string)reader["Publisher"], (int)reader["Pages"], (int)reader["PublicationYear"]
                        , (string)reader["ISBN"], new List<Author>(), (string)reader["Description"]);
                    book.ID = (Guid)reader["ID"];

                    var authors = _authorDAO.GetAuthorsByItemID(book.ID);
                    book.Authors.AddRange(authors);

                    books.Add(book);
                }
            }
            return books;
        }

        private Guid AddToDB(Book book)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;

                command.CommandText = "AddBook";

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Name",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = book.Name,
                    Direction = ParameterDirection.Input
                });

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Pages",
                    SqlDbType = SqlDbType.Int,
                    Value = book.Pages,
                    Direction = ParameterDirection.Input
                });

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@PublicationYear",
                    SqlDbType = SqlDbType.Int,
                    Value = book.PublicationYear,
                    Direction = ParameterDirection.Input
                });

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Description",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = book.Description,
                    Direction = ParameterDirection.Input
                });

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@City",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = book.City,
                    Direction = ParameterDirection.Input
                });

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Publisher",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = book.Publisher,
                    Direction = ParameterDirection.Input
                });

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@ISBN",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = book.ISBN,
                    Direction = ParameterDirection.Input
                });

                var id = new SqlParameter
                {
                    ParameterName = "@ID",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Direction = ParameterDirection.Output
                };

                command.Parameters.Add(id);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch
                {
                    throw new Exception("Adding book to database failed");
                }
                return (Guid)id.Value;
            }
        }

        private bool IsNotUnique(Book book)
        {
            var allBooks = GetAll();
            if (allBooks.Any(i => i.ISBN != string.Empty && i.ISBN == book.ISBN))
            {
                return true;
            }
            else if (book.ISBN != string.Empty)
            {
                return false;
            }
            else if (allBooks.Any(i => i.Name == book.Name && i.PublicationYear == book.PublicationYear
                 && allBooks.Any(i => i.Authors.Compare(book.Authors))))
            {
                return true;
            }
            return false;
        }
    }
}

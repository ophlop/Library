using EPAM.Library.DAL.Interfaces;
using EPAM.Library.Entities;
using System.Data;
using System.Data.SqlClient;

namespace EPAM.Library.DAL
{
    public class AuthorDAO : IAuthorDAO
    {
        private readonly string _connectionString = "Data Source=.;Initial Catalog = LibraryDB; Integrated Security = True;";
        public Guid Add(Author author)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "AddAuthor";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@FirstName",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = author.Name,
                    Direction = ParameterDirection.Input
                });

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@SecondName",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = author.SecondName,
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
                    throw new Exception("Adding author to database failed");
                }

                return (Guid)id.Value;
            }
        }

        private void DeleteByID(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Author> GetAll()
        {
            var authors = new List<Author>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetAllAuthors";

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    authors.Add(new Author((string)reader["FirstName"], (string)reader["SecondName"]));
                }
            }
            return authors;
        }

        public Guid? FindAuthor(Author author)
        {
            Guid? id = Guid.Empty;

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "FindAuthor";

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@FirstName",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = author.Name,
                    Direction = ParameterDirection.Input
                });

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@SecondName",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = author.SecondName,
                    Direction = ParameterDirection.Input
                });

                try
                {
                    connection.Open();
                    id = (Guid?)command.ExecuteScalar();
                }
                catch
                {
                    throw new Exception("");
                }
            }

            return id;
        }

        public IEnumerable<Author> GetAuthorsByItemID(Guid itemID)
        {
            List<Author> authors = new List<Author>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetAuthorsByItemID";

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@ID",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = itemID,
                    Direction = ParameterDirection.Input
                });

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    authors.Add(new Author((string)reader["FirstName"], (string)reader["SecondName"]));
                }
            }

            return authors;
        }

        public void AddAuthorsToItem(IEnumerable<Author> authors, Guid id)
        {
            if (authors.Any())
            {
                foreach (Author author in authors)
                {
                    var authorID = FindAuthor(author);
                    if (authorID is null)
                    {
                        authorID = Add(author);
                    }

                    AddAuthorToItem(id, authorID.Value);
                }
            }
        }

        public void AddAuthorToItem(Guid itemID, Guid AuthorID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "AddAuthorToItem";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@ItemID",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = itemID,
                    Direction = ParameterDirection.Input
                });

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@AuthorID",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = AuthorID,
                    Direction = ParameterDirection.Input
                });

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch
                {
                    throw new Exception("Author wasn't added to book");
                }
            }
        }
    }
}

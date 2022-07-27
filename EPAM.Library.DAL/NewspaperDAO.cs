using EPAM.Library.DAL.Interfaces;
using EPAM.Library.Entities;
using System.Data;
using System.Data.SqlClient;

namespace EPAM.Library.DAL
{
    public class NewspaperDAO : INewspaperDAO
    {
        private readonly string _connectionString = "Data Source=.;Initial Catalog = LibraryDB; Integrated Security = True;";

        public Guid Add(Newspaper newspaper)
        {
            if (IsNotUnique(newspaper))
            {
                return Guid.Empty;
            }

            return AddToDB(newspaper);
        }

        public void DeleteByID(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "DeleteNewspaperByID";

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
                    throw new Exception("Newspaper deletion failed");
                }
            }
        }

        public void MarkAsDeleted(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "MarkNewspaperAsDeletedByID";

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
                    throw new Exception("Newspaper deletion failed");
                }
            }
        }
        public IEnumerable<Newspaper> GetAll()
        {
            List<Newspaper> newspapers = new List<Newspaper>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetAllNewspapers";

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var newspaper = new Newspaper((string)reader["Name"], (string)reader["City"], (string)reader["Publisher"]
                        , (int)reader["Pages"], (int)reader["PublicationYear"], (DateTime)reader["IssueDate"]
                        , (string)reader["IssueNumber"], (string)reader["ISSN"], (string)reader["Description"]);
                    newspaper.ID = (Guid)reader["ID"];

                    newspapers.Add(newspaper);
                }
            }
            return newspapers;
        }

        private Guid AddToDB(Newspaper newspaper)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;

                command.CommandText = "AddNewspaper";

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Name",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = newspaper.Name,
                    Direction = ParameterDirection.Input
                });

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Pages",
                    SqlDbType = SqlDbType.Int,
                    Value = newspaper.Pages,
                    Direction = ParameterDirection.Input
                });

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@PublicationYear",
                    SqlDbType = SqlDbType.Int,
                    Value = newspaper.PublicationYear,
                    Direction = ParameterDirection.Input
                });

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Description",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = newspaper.Description,
                    Direction = ParameterDirection.Input
                });

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@City",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = newspaper.City,
                    Direction = ParameterDirection.Input
                });

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Publisher",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = newspaper.Publisher,
                    Direction = ParameterDirection.Input
                });

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@IssueDate",
                    SqlDbType = SqlDbType.Date,
                    Value = newspaper.IssueDate,
                    Direction = ParameterDirection.Input
                });

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@IssueNumber",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = newspaper.IssueNumber,
                    Direction = ParameterDirection.Input
                });

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@ISSN",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = newspaper.ISSN,
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
                    throw new Exception("Adding newspaper to database failed");
                }

                return (Guid)id.Value;
            }
        }

        private bool IsNotUnique(Newspaper newspaper)
        {
            var allNewspapers = GetAll();
            if (allNewspapers.Any(i => i.ISSN != string.Empty && i.ISSN == newspaper.ISSN))
            {
                return true;
            }
            else if (newspaper.ISSN != string.Empty)
            {
                return false;
            }
            else if (allNewspapers.Any(i => i.Name == newspaper.Name && i.Publisher == newspaper.Publisher
                 && i.PublicationYear == newspaper.PublicationYear))
            {
                return true;
            }
            return false;
        }
    }
}
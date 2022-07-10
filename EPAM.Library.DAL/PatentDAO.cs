using EPAM.Library.DAL.Interfaces;
using EPAM.Library.Entities;
using System.Data;
using System.Data.SqlClient;

namespace EPAM.Library.DAL
{
    public class PatentDAO : IPatentDAO
    {
        private readonly string _connectionString = "Data Source=.;Initial Catalog = LibraryDB; Integrated Security = True;";
        private readonly AuthorDAO _authorDAO = new AuthorDAO();

        public Guid Add(Patent patent)
        {
            if (IsNotUnique(patent))
            {
                return Guid.Empty;
            }

            var id = AddToDB(patent);

            var authors = patent.Authors;

            _authorDAO.AddAuthorsToItem(authors, id);

            return id;
        }

        public void DeleteByID(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "DeletePatentByID";

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
                    throw new Exception("Patent deletion failed");
                }
            }
        }

        public void MarkAsDeleted(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "MarkPatentAsDeletedByID";

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

        public IEnumerable<Patent> GetAll()
        {
            List<Patent> patents = new List<Patent>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetAllPatents";

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var patent = new Patent((string)reader["Name"], (string)reader["Country"], (string)reader["RegistrationNumber"]
                        , (int)reader["Pages"], (int)reader["PublicationYear"], (DateTime)reader["ApplicationDate"]
                        , new List<Author>());
                    patent.ID = (Guid)reader["ID"];

                    var authors = _authorDAO.GetAuthorsByItemID(patent.ID);
                    patent.Authors.AddRange(authors);

                    patents.Add(patent);
                }
            }
            return patents;
        }

        private Guid AddToDB(Patent patent)
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
                    Value = patent.Name,
                    Direction = ParameterDirection.Input
                });

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Pages",
                    SqlDbType = SqlDbType.Int,
                    Value = patent.Pages,
                    Direction = ParameterDirection.Input
                });

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@PublicationYear",
                    SqlDbType = SqlDbType.Int,
                    Value = patent.PublicationYear,
                    Direction = ParameterDirection.Input
                });

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Description",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = patent.Description,
                    Direction = ParameterDirection.Input
                });

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Country",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = patent.Country,
                    Direction = ParameterDirection.Input
                });

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@RegistrationNumber",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = patent.RegistrationNumber,
                    Direction = ParameterDirection.Input
                });

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@ApplicationDate",
                    SqlDbType = SqlDbType.Date,
                    Value = patent.ApplicationDate,
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
                    throw new Exception("Adding patent to database failed");
                }

                return (Guid)id.Value;
            }

        }

        private bool IsNotUnique(Patent patent)
        {
            var allPatents = GetAll();
            if (allPatents.Any(i => i.RegistrationNumber == patent.RegistrationNumber && i.Country == patent.Country))
            {
                return true;
            }
            return false;
        }
    }
}

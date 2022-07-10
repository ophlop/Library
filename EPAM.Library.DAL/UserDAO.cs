using System.Data;
using System.Data.SqlClient;

namespace EPAM.Library.DAL
{
    public class UserDAO
    {
        private readonly string _connectionString = "Data Source=.;Initial Catalog = LibraryDB; Integrated Security = True;";
        public bool IsAllowed(Action actionName, string userName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "MarkPatentAsDeletedByID";

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@ActionName",
                    SqlDbType = SqlDbType.NVarChar,
                    Direction = ParameterDirection.Input,
                    Value = actionName.ToString()
                });

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@UserName",
                    SqlDbType = SqlDbType.NVarChar,
                    Direction = ParameterDirection.Input,
                    Value = userName
                });

                var isAllowed = new SqlParameter
                {
                    ParameterName = "@IsAllowed",
                    SqlDbType = SqlDbType.Bit,
                    Direction = ParameterDirection.Output,
                };

                command.Parameters.Add(isAllowed);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch
                {
                    throw new Exception("Book deletion failed");
                }

                return (bool)isAllowed.Value;
            }
        }
    }

    public enum Action
    {
        GetAll,
        Add,
        Delete
    }
}

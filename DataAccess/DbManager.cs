using System.Configuration;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DbManager
    {
        private readonly string _connectionString;
        public DbManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}

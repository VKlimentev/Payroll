using System;
using System.Collections.Generic;
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

        public SqlCommand CreateCommand(SqlConnection conn, string query, Dictionary<string, object> parameters = null)
        {
            var cmd = new SqlCommand(query, conn);
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                }
            }
            return cmd;
        }
    }
}

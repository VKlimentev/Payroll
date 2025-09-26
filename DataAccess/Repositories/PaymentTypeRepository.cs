using DataAccess.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Repositories
{
    public class PaymentTypeRepository
    {
        private readonly DbManager _db;

        public PaymentTypeRepository(DbManager db)
        {
            _db = db;
        }

        public List<PaymentType> GetAll()
        {
            var paymentTypes = new List<PaymentType>();
            using (var conn = _db.GetConnection())
            {
                conn.Open();

                var query = @"
                    SELECT 
                        Id, 
                        PaymentTypeName, 
                        PaymentCategory 
                    FROM 
                        PaymentTypes
                ";
                var cmd = new SqlCommand(query, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    paymentTypes.Add(new PaymentType
                    {
                        Id = (int)reader["Id"],
                        PaymentTypeName = reader["PaymentTypeName"].ToString(),
                        PaymentCategory = reader["PaymentCategory"].ToString()
                    });
                }
            }
            return paymentTypes;
        }
        public PaymentType GetById(int id)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();

                var query = @"
                    SELECT 
                        Id, 
                        PaymentTypeName, 
                        PaymentCategory 
                    FROM 
                        PaymentTypes 
                    WHERE 
                        Id = @id
                ";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new PaymentType
                    {
                        Id = (int)reader["Id"],
                        PaymentTypeName = reader["PaymentTypeName"].ToString(),
                        PaymentCategory = reader["PaymentCategory"].ToString()
                    };
                }
            }
            return null;
        }


        public void Add(PaymentType pt)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();

                var query = @"
                    INSERT INTO PaymentTypes (
                        PaymentTypeName, 
                        PaymentCategory) 
                    VALUES (
                        @name, 
                        @cat
                )";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", pt.PaymentTypeName);
                cmd.Parameters.AddWithValue("@cat", pt.PaymentCategory);
                cmd.ExecuteNonQuery();
            }
        }
        public void Update(PaymentType pt)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();

                var query = @"
                    UPDATE 
                        PaymentTypes 
                    SET 
                        PaymentTypeName = @name, 
                        PaymentCategory = @cat 
                    WHERE 
                        Id = @id
                ";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", pt.PaymentTypeName);
                cmd.Parameters.AddWithValue("@cat", pt.PaymentCategory);
                cmd.Parameters.AddWithValue("@id", pt.Id);
                cmd.ExecuteNonQuery();
            }
        }
        public void Delete(int id)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();

                var query = @"
                    DELETE FROM PaymentTypes 
                    WHERE Id = @id
                ";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

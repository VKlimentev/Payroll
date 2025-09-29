using DataAccess.Models;
using System;
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
            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    var query = "SELECT Id, PaymentTypeName, PaymentCategory FROM PaymentTypes";

                    using (var cmd = _db.CreateCommand(conn, query))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            paymentTypes.Add(MapPaymentType(reader));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при получении списка типов выплат", ex);
            }
            return paymentTypes;
        }
        public PaymentType GetById(int id)
        {
            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    var query = "SELECT Id, PaymentTypeName, PaymentCategory FROM PaymentTypes WHERE Id = @id";
                    var parameters = new Dictionary<string, object> { { "@id", id } };

                    using (var cmd = _db.CreateCommand(conn, query, parameters))
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapPaymentType(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при получении типа выплаты с Id={id}", ex);
            }
            return null;
        }

        public int GetIdByName(string name)
        {
            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    var query = "SELECT Id FROM PaymentTypes WHERE PaymentTypeName = @name";
                    var parameters = new Dictionary<string, object> { { "@name", name } };

                    using (var cmd = _db.CreateCommand(conn, query, parameters))
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return (int)reader["Id"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при получении типа выплаты с PaymentTypeName={name}", ex);
            }
            return 0;
        }
        public string GetCategoryByName(string name)
        {
            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    var query = "SELECT PaymentCategory FROM PaymentTypes WHERE PaymentTypeName = @name";
                    var parameters = new Dictionary<string, object> { { "@name", name } };

                    using (var cmd = _db.CreateCommand(conn, query, parameters))
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader["PaymentCategory"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при получении типа выплаты с PaymentTypeName={name}", ex);
            }
            return null;
        }


        public void Add(PaymentType pt)
        {
            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    var query = @"
                        INSERT INTO PaymentTypes (PaymentTypeName, PaymentCategory)
                        VALUES (@name, @cat)";
                    var parameters = new Dictionary<string, object>
                    {
                        { "@name", pt.PaymentTypeName },
                        { "@cat", pt.PaymentCategory }
                    };

                    using (var cmd = _db.CreateCommand(conn, query, parameters))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при добавлении типа выплаты", ex);
            }
        }
        public void Update(PaymentType pt)
        {
            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    var query = @"
                        UPDATE PaymentTypes
                        SET PaymentTypeName = @name, PaymentCategory = @cat
                        WHERE Id = @id";
                    var parameters = new Dictionary<string, object>
                    {
                        { "@name", pt.PaymentTypeName },
                        { "@cat", pt.PaymentCategory },
                        { "@id", pt.Id }
                    };

                    using (var cmd = _db.CreateCommand(conn, query, parameters))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при обновлении типа выплаты с Id={pt.Id}", ex);
            }
        }
        public void Delete(int id)
        {
            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    var query = "DELETE FROM PaymentTypes WHERE Id = @id";
                    var parameters = new Dictionary<string, object> { { "@id", id } };

                    using (var cmd = _db.CreateCommand(conn, query, parameters))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при удалении типа выплаты с Id={id}", ex);
            }
        }


        private PaymentType MapPaymentType(SqlDataReader reader)
        {
            return new PaymentType
            {
                Id = (int)reader["Id"],
                PaymentTypeName = reader["PaymentTypeName"].ToString(),
                PaymentCategory = reader["PaymentCategory"].ToString()
            };
        }
    }
}

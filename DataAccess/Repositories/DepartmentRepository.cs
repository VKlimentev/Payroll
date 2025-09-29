using DataAccess.Models;
using System;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public class DepartmentRepository
    {
        private readonly DbManager _db;

        public DepartmentRepository(DbManager db)
        {
            _db = db;
        }

        public List<Department> GetAll()
        {
            var departments = new List<Department>();
            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    var query = "SELECT Id, DepartmentName FROM Departments";
                    using (var cmd = _db.CreateCommand(conn, query))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            departments.Add(new Department
                            {
                                Id = (int)reader["Id"],
                                DepartmentName = reader["DepartmentName"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при получении списка отделов", ex);
            }
            return departments;
        }
        public Department GetById(int id)
        {
            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    var query = "SELECT Id, DepartmentName FROM Departments WHERE Id = @id";
                    var parameters = new Dictionary<string, object> { { "@id", id } };

                    using (var cmd = _db.CreateCommand(conn, query, parameters))
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Department
                            {
                                Id = (int)reader["Id"],
                                DepartmentName = reader["DepartmentName"].ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при получении отдела с Id={id}", ex);
            }
            return null;
        }
        public string GetNameById(int id)
        {
            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    var query = "SELECT DepartmentName FROM Departments WHERE Id = @id";
                    var parameters = new Dictionary<string, object> { { "@id", id } };

                    using (var cmd = _db.CreateCommand(conn, query, parameters))
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader["DepartmentName"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при получении названия отдела с Id={id}", ex);
            }
            return null;
        }


        public void Add(Department dept)
        {
            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    var query = "INSERT INTO Departments (DepartmentName) VALUES (@name)";
                    var parameters = new Dictionary<string, object> { { "@name", dept.DepartmentName } };

                    using (var cmd = _db.CreateCommand(conn, query, parameters))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при добавлении отдела", ex);
            }
        }
        public void Update(Department dept)
        {
            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    var query = "UPDATE Departments SET DepartmentName = @name WHERE Id = @id";
                    var parameters = new Dictionary<string, object>
                    {
                        { "@name", dept.DepartmentName },
                        { "@id", dept.Id }
                    };

                    using (var cmd = _db.CreateCommand(conn, query, parameters))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при обновлении отдела с Id={dept.Id}", ex);
            }
        }
        public void Delete(int id)
        {
            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    var query = "DELETE FROM Departments WHERE Id = @id";
                    var parameters = new Dictionary<string, object> { { "@id", id } };

                    using (var cmd = _db.CreateCommand(conn, query, parameters))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при удалении отдела с Id={id}", ex);
            }
        }
    }
}

using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Repositories
{
    public class EmployeeRepository
    {
        private readonly DbManager _db;

        public EmployeeRepository(DbManager db)
        {
            _db = db;
        }

        public List<Employee> GetAll()
        {
            var employees = new List<Employee>();
            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    var query = @"
                        SELECT 
                            e.Id, 
                            e.FullName, 
                            e.Department_Id, 
                            d.DepartmentName, 
                            e.Gender, 
                            e.BaseSalary 
                        FROM 
                            Employees e
                        JOIN 
                            Departments d ON e.Department_Id = d.Id";

                    using (var cmd = _db.CreateCommand(conn, query))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employees.Add(MapEmployee(reader));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при получении списка сотрудников", ex);
            }
            return employees;
        }
        public Employee GetById(int id)
        {
            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    var query = @"
                        SELECT 
                            e.Id, 
                            e.FullName, 
                            e.Department_Id, 
                            d.DepartmentName, 
                            e.Gender, 
                            e.BaseSalary 
                        FROM 
                            Employees e
                        JOIN 
                            Departments d ON e.Department_Id = d.Id
                        WHERE
                            e.Id = @id";

                    var parameters = new Dictionary<string, object> { { "@id", id } };

                    using (var cmd = _db.CreateCommand(conn, query, parameters))
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapEmployee(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при получении сотрудника с Id={id}", ex);
            }
            return null;
        }


        public void Add(Employee emp)
        {
            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    var query = @"
                        INSERT INTO Employees (
                            FullName, 
                            Department_Id, 
                            Gender, 
                            BaseSalary) 
                        VALUES (
                            @name, 
                            @dept, 
                            @gender, 
                            @salary)";

                    var parameters = new Dictionary<string, object>
                    {
                        { "@name", emp.FullName },
                        { "@dept", emp.DepartmentId },
                        { "@gender", emp.Gender },
                        { "@salary", emp.BaseSalary }
                    };

                    using (var cmd = _db.CreateCommand(conn, query, parameters))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при добавлении сотрудника", ex);
            }
        }
        public void Update(Employee emp)
        {
            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    var query = @"
                        UPDATE Employees 
                        SET 
                            FullName = @name, 
                            Department_Id = @dept, 
                            Gender = @gender, 
                            BaseSalary = @salary 
                        WHERE 
                            Id = @id";

                    var parameters = new Dictionary<string, object>
                    {
                        { "@name", emp.FullName },
                        { "@dept", emp.DepartmentId },
                        { "@gender", emp.Gender },
                        { "@salary", emp.BaseSalary },
                        { "@id", emp.Id }
                    };

                    using (var cmd = _db.CreateCommand(conn, query, parameters))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при обновлении сотрудника с Id={emp.Id}", ex);
            }
        }
        public void Delete(int id)
        {
            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    var query = "DELETE FROM Employees WHERE Id = @id";
                    var parameters = new Dictionary<string, object> { { "@id", id } };

                    using (var cmd = _db.CreateCommand(conn, query, parameters))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при удалении сотрудника с Id={id}", ex);
            }
        }


        private Employee MapEmployee(SqlDataReader reader)
        {
            return new Employee
            {
                Id = (int)reader["Id"],
                FullName = reader["FullName"].ToString(),
                DepartmentId = (int)reader["Department_Id"],
                DepartmentName = reader["DepartmentName"].ToString(),
                Gender = reader["Gender"].ToString(),
                BaseSalary = (decimal)reader["BaseSalary"]
            };
        }
    }
}

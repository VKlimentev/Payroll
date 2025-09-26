using DataAccess.Models;
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
            var list = new List<Employee>();
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
                ";
                var cmd = new SqlCommand(query, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Employee
                    {
                        Id = (int)reader["Id"],
                        FullName = reader["FullName"].ToString(),
                        DepartmentId = (int)reader["Department_Id"],
                        DepartmentName = reader["DepartmentName"].ToString(),
                        Gender = reader["Gender"].ToString(),
                        BaseSalary = (decimal)reader["BaseSalary"]
                    });
                }
            }
            return list;
        }
        public Employee GetById(int id)
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
                        e.Id = @id
                ";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
                if (reader.Read())
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
            return null;
        }


        public void Add(Employee emp)
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
                        @salary
                )";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", emp.FullName);
                cmd.Parameters.AddWithValue("@dept", emp.DepartmentId);
                cmd.Parameters.AddWithValue("@gender", emp.Gender);
                cmd.Parameters.AddWithValue("@salary", emp.BaseSalary);
                cmd.ExecuteNonQuery();
            }
        }
        public void Update(Employee emp)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();

                var query = @"
                    UPDATE 
                        Employees 
                    SET 
                        FullName = @name, 
                        Department_Id = @dept, 
                        Gender = @gender, 
                        BaseSalary = @salary 
                    WHERE 
                        Id = @id
                ";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", emp.FullName);
                cmd.Parameters.AddWithValue("@dept", emp.DepartmentId);
                cmd.Parameters.AddWithValue("@gender", emp.Gender);
                cmd.Parameters.AddWithValue("@salary", emp.BaseSalary);
                cmd.Parameters.AddWithValue("@id", emp.Id);
                cmd.ExecuteNonQuery();
            }
        }
        public void Delete(int id)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();

                var query = @"
                    DELETE FROM Employees 
                    WHERE Id = @id
                ";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
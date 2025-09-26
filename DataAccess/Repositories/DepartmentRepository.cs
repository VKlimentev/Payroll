using DataAccess.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

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
            using (var conn = _db.GetConnection())
            {
                conn.Open();

                var query = @"
                    SELECT 
                        Id, 
                        DepartmentName 
                    FROM 
                        Departments
                ";
                var cmd = new SqlCommand(query, conn);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    departments.Add(new Department
                    {
                        Id = (int)reader["Id"],
                        DepartmentName = reader["DepartmentName"].ToString()
                    });
                }
            }
            return departments;
        }
        public Department GetById(int id)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();

                var query = @"
                    SELECT 
                        Id, 
                        DepartmentName 
                    FROM 
                        Departments 
                    WHERE 
                        Id = @id
                ";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Department
                    {
                        Id = (int)reader["Id"],
                        DepartmentName = reader["DepartmentName"].ToString()
                    };
                }
            }
            return null;
        }
        public string GetNameById(int id)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();

                var query = @"
                    SELECT 
                        Id, 
                        DepartmentName 
                    FROM 
                        Departments 
                    WHERE 
                        Id = @id
                ";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return reader["DepartmentName"].ToString();
                }
            }
            return null;
        }


        public void Add(Department dept)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();

                var query = @"
                    INSERT INTO Departments (DepartmentName)
                    VALUES (@name)
                ";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", dept.DepartmentName);
                cmd.ExecuteNonQuery();
            }
        }
        public void Update(Department dept)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();

                var query = @"
                    UPDATE Departments 
                    SET DepartmentName = @name 
                    WHERE Id = @id
                ";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", dept.DepartmentName);
                cmd.Parameters.AddWithValue("@id", dept.Id);
                cmd.ExecuteNonQuery();
            }
        }
        public void Delete(int id)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                var query = @"
                    DELETE FROM Departments
                    WHERE Id = @id
                ";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

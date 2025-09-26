using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Repositories
{
    public class WorkTimeLogRepository
    {
        private readonly DbManager _db;

        public WorkTimeLogRepository(DbManager db)
        {
            _db = db;
        }

        public List<WorkTimeLog> GetByEmployee(int employeeId)
        {
            var list = new List<WorkTimeLog>();
            using (var conn = _db.GetConnection())
            {
                conn.Open();

                var query = @"
                    SELECT 
                        Id, 
                        Employee_Id, 
                        WorkDate, 
                        HoursWorked 
                    FROM 
                        WorkTimeLog 
                    WHERE 
                        Employee_Id = @emp_id
                ";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@emp_id", employeeId);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new WorkTimeLog
                    {
                        Id = (int)reader["Id"],
                        EmployeeId = (int)reader["Employee_Id"],
                        WorkDate = (DateTime)reader["WorkDate"],
                        HoursWorked = (decimal)reader["HoursWorked"]
                    });
                }
            }
            return list;
        }
        public List<WorkTimeLog> GetByMonth(int year, int month)
        {
            var list = new List<WorkTimeLog>();
            using (var conn = _db.GetConnection())
            {
                conn.Open();

                var query = @"
                    SELECT 
                        Id, 
                        Employee_Id, 
                        WorkDate, 
                        HoursWorked 
                    FROM 
                        WorkTimeLog 
                    WHERE 
                        WorkDate BETWEEN @start AND @end
                ";

                var cmd = new SqlCommand(query, conn);
                var start = new DateTime(year, month, 1);
                var end = new DateTime(year, month, DateTime.DaysInMonth(year, month));
                cmd.Parameters.AddWithValue("@start", start);
                cmd.Parameters.AddWithValue("@end", end);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new WorkTimeLog
                    {
                        Id = (int)reader["Id"],
                        EmployeeId = (int)reader["Employee_Id"],
                        WorkDate = (DateTime)reader["WorkDate"],
                        HoursWorked = (decimal)reader["HoursWorked"]
                    });
                }
            }
            return list;
        }
        public decimal GetTotalHoursWorked(int employeeId, int year, int month)
        {
            decimal totalHours = 0;

            using (var conn = _db.GetConnection())
            {
                conn.Open();
                var query = @"
            SELECT 
                HoursWorked
            FROM 
                WorkTimeLog
            WHERE 
                Employee_Id = @emp 
              AND 
                MONTH(WorkDate) = @month 
              AND 
                YEAR(WorkDate) = @year
        ";

                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@emp", employeeId);
                cmd.Parameters.AddWithValue("@month", month);
                cmd.Parameters.AddWithValue("@year", year);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["HoursWorked"] != DBNull.Value)
                    {
                        totalHours += Convert.ToDecimal(reader["HoursWorked"]);
                    }
                }
            }

            return totalHours;
        }


        public void Upsert(int employeeId, DateTime workDate, decimal hours)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                               
                var checkCmd = new SqlCommand("SELECT COUNT(*) FROM WorkTimeLog WHERE Employee_Id = @emp AND WorkDate = @date", conn);
                checkCmd.Parameters.AddWithValue("@emp", employeeId);
                checkCmd.Parameters.AddWithValue("@date", workDate);
                int exists = (int)checkCmd.ExecuteScalar();

                if (exists > 0)
                {
                    var updateCmd = new SqlCommand("UPDATE WorkTimeLog SET HoursWorked = @hours WHERE Employee_Id = @emp AND WorkDate = @date", conn);
                    updateCmd.Parameters.AddWithValue("@hours", hours);
                    updateCmd.Parameters.AddWithValue("@emp", employeeId);
                    updateCmd.Parameters.AddWithValue("@date", workDate);
                    updateCmd.ExecuteNonQuery();
                }
                else
                {

                    var insertCmd = new SqlCommand("INSERT INTO WorkTimeLog (Employee_Id, WorkDate, HoursWorked) VALUES (@emp, @date, @hours)", conn);
                    insertCmd.Parameters.AddWithValue("@emp", employeeId);
                    insertCmd.Parameters.AddWithValue("@date", workDate);
                    insertCmd.Parameters.AddWithValue("@hours", hours);
                    insertCmd.ExecuteNonQuery();
                }
            }
        }

        public void RecalculateSalary(int employeeId, int month, int year)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("CalculateSalary", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
                cmd.Parameters.AddWithValue("@Month", month);
                cmd.Parameters.AddWithValue("@Year", year);
                cmd.ExecuteNonQuery();
            }
        }

        public void Add(WorkTimeLog log)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();

                var query = @"
                    INSERT INTO WorkTimeLog (
                        Employee_Id, 
                        WorkDate, 
                        HoursWorked) 
                    VALUES (
                        @emp, 
                        @date, 
                        @hours
                )";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@emp", log.EmployeeId);
                cmd.Parameters.AddWithValue("@date", log.WorkDate);
                cmd.Parameters.AddWithValue("@hours", log.HoursWorked);
                cmd.ExecuteNonQuery();
            }
        }
        public void Update(WorkTimeLog log)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();

                var query = @"
                    UPDATE 
                        WorkTimeLog 
                    SET 
                        Employee_Id = @emp, 
                        WorkDate = @date, 
                        HoursWorked = @hours 
                    WHERE 
                        Id = @id
                ";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@emp", log.EmployeeId);
                cmd.Parameters.AddWithValue("@date", log.WorkDate);
                cmd.Parameters.AddWithValue("@hours", log.HoursWorked);
                cmd.Parameters.AddWithValue("@id", log.Id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

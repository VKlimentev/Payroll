using DataAccess.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Repositories
{
    public class SalaryDetailsRepository
    {
        private readonly DbManager _db;

        public SalaryDetailsRepository(DbManager db)
        {
            _db = db;
        }

        public List<SalaryDetail> GetAll()
        {
            var list = new List<SalaryDetail>();
            using (var conn = _db.GetConnection())
            {
                conn.Open();

                var query = @"
                    SELECT 
                        sd.Id,
                        ws.Month,
                        ws.Year,
                        e.Id AS EmployeeId,
                        e.FullName,
                        sd.Schedule_Id AS ScheduleId,
                        ISNULL(SUM(wtl.HoursWorked), 0) AS TotalWorkedHours,
                        pt.Id AS PaymentTypeId,
                        pt.PaymentTypeName,
                        sd.Amount
                    FROM 
                        SalaryDetails sd
                    INNER JOIN Employees e ON sd.Employee_Id = e.Id
                    INNER JOIN WorkSchedule ws ON sd.Schedule_Id = ws.Id
                    INNER JOIN PaymentTypes pt ON sd.PaymentType_Id = pt.Id
                    LEFT JOIN WorkTimeLog wtl ON wtl.Employee_Id = e.Id AND wtl.WorkDate BETWEEN 
                        DATEFROMPARTS(ws.Year, ws.Month, 1) AND 
                        EOMONTH(DATEFROMPARTS(ws.Year, ws.Month, 1))
                    GROUP BY 
                        sd.Id,
                        ws.Month,
                        ws.Year,
                        e.Id,
                        e.FullName,
                        sd.Schedule_Id,
                        pt.Id,
                        pt.PaymentTypeName,
                        sd.Amount
                    ";
                var cmd = new SqlCommand(query, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new SalaryDetail
                    {
                        Id = (int)reader["Id"],
                        Month = (int)reader["Month"],
                        Year = (int)reader["Year"],
                        EmployeeId = (int)reader["Employee_Id"],
                        FullName = reader["FullName"].ToString(),
                        ScheduleId = (int)reader["Schedule_Id"],
                        TotalWorkedHours = (decimal)reader["TotalWorkedHours"],
                        PaymentTypeId = (int)reader["PaymentType_Id"],
                        PaymentTypeName = reader["PaymentTypeName"].ToString(),
                        Amount = (decimal)reader["Amount"]
                    });
                }
            }
            return list;
        }
        public List<SalaryDetail> GetByEmployee(int employeeId)
        {
            var list = new List<SalaryDetail>();
            using (var conn = _db.GetConnection())
            {
                conn.Open();

                var query = @"
                    SELECT 
                        Id, 
                        Employee_Id, 
                        Schedule_Id, 
                        PaymentType_Id, 
                        Amount 
                    FROM 
                        SalaryDetails 
                    WHERE 
                        Employee_Id = @id";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", employeeId);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new SalaryDetail
                    {
                        Id = (int)reader["Id"],
                        EmployeeId = (int)reader["Employee_Id"],
                        ScheduleId = (int)reader["Schedule_Id"],
                        PaymentTypeId = (int)reader["PaymentType_Id"],
                        Amount = (decimal)reader["Amount"]
                    });
                }
            }
            return list;
        }
        public List<SalaryDetail> GetByEmployeeAndSchedule(int employeeId, int scheduleId)
        {
            var list = new List<SalaryDetail>();
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                var query = @"
                    SELECT 
                        sd.Id, 
                        sd.Employee_Id, 
                        sd.Schedule_Id, 
                        sd.PaymentType_Id, 
                        sd.Amount,
                        pt.PaymentTypeName
                    FROM 
                        SalaryDetails sd
                    INNER JOIN 
                        PaymentTypes pt 
                      ON 
                        sd.PaymentType_Id = pt.Id
                    WHERE 
                        sd.Employee_Id = @emp 
                      AND 
                        sd.Schedule_Id = @sched
                ";

                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@emp", employeeId);
                cmd.Parameters.AddWithValue("@sched", scheduleId);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new SalaryDetail
                    {
                        Id = (int)reader["Id"],
                        EmployeeId = (int)reader["Employee_Id"],
                        ScheduleId = (int)reader["Schedule_Id"],
                        PaymentTypeId = (int)reader["PaymentType_Id"],
                        PaymentTypeName = reader["PaymentTypeName"].ToString(),
                        Amount = (decimal)reader["Amount"]
                    });
                }
            }
            return list;
        }


        public void Add(SalaryDetail detail)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();

                var query = @"
                    INSERT INTO SalaryDetails (
                        Employee_Id, 
                        Schedule_Id, 
                        PaymentType_Id, 
                        Amount)
                    VALUES (
                        @emp, 
                        @sched, 
                        @type, 
                        @amount
                )";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@emp", detail.EmployeeId);
                cmd.Parameters.AddWithValue("@sched", detail.ScheduleId);
                cmd.Parameters.AddWithValue("@type", detail.PaymentTypeId);
                cmd.Parameters.AddWithValue("@amount", detail.Amount);
                cmd.ExecuteNonQuery();
            }
        }
        public void Delete(int id)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();

                var query = @"
                    DELETE FROM SalaryDetails 
                    WHERE Id = @id
                ";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }

}

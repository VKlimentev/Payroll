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

        public List<WorkTimeLog> GetByMonth(int year, int month)
        {
            var logs = new List<WorkTimeLog>();
            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    var query = @"
                        SELECT Id, Employee_Id, WorkDate, HoursWorked
                        FROM WorkTimeLog
                        WHERE WorkDate BETWEEN @start AND @end";

                    var start = new DateTime(year, month, 1);
                    var end = new DateTime(year, month, DateTime.DaysInMonth(year, month));
                    var parameters = new Dictionary<string, object>
                    {
                        { "@start", start },
                        { "@end", end }
                    };

                    using (var cmd = _db.CreateCommand(conn, query, parameters))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            logs.Add(MapLog(reader));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при получении табеля за {month}/{year}", ex);
            }
            return logs;
        }
        public decimal GetTotalHoursWorked(int employeeId, int year, int month)
        {
            decimal totalHours = 0;
            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    var query = @"
                        SELECT HoursWorked
                        FROM WorkTimeLog
                        WHERE Employee_Id = @emp AND MONTH(WorkDate) = @month AND YEAR(WorkDate) = @year";

                    var parameters = new Dictionary<string, object>
                    {
                        { "@emp", employeeId },
                        { "@month", month },
                        { "@year", year }
                    };

                    using (var cmd = _db.CreateCommand(conn, query, parameters))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader["HoursWorked"] != DBNull.Value)
                            {
                                totalHours += Convert.ToDecimal(reader["HoursWorked"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при подсчёте часов сотрудника Id={employeeId} за {month}/{year}", ex);
            }
            return totalHours;
        }


        public void Upsert(int employeeId, DateTime workDate, decimal hours)
        {
            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    var checkQuery = "SELECT COUNT(*) FROM WorkTimeLog WHERE Employee_Id = @emp AND WorkDate = @date";
                    var checkParams = new Dictionary<string, object>
                    {
                        { "@emp", employeeId },
                        { "@date", workDate }
                    };

                    using (var checkCmd = _db.CreateCommand(conn, checkQuery, checkParams))
                    {
                        int exists = (int)checkCmd.ExecuteScalar();
                        if (exists > 0)
                        {
                            Update(new WorkTimeLog { EmployeeId = employeeId, WorkDate = workDate, HoursWorked = hours });
                        }
                        else
                        {
                            Add(new WorkTimeLog { EmployeeId = employeeId, WorkDate = workDate, HoursWorked = hours });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при сохранении табеля сотрудника Id={employeeId} за {workDate:dd.MM.yyyy}", ex);
            }
        }


        public void Add(WorkTimeLog log)
        {
            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    var query = @"
                        INSERT INTO WorkTimeLog (Employee_Id, WorkDate, HoursWorked)
                        VALUES (@emp, @date, @hours)";

                    var parameters = new Dictionary<string, object>
                    {
                        { "@emp", log.EmployeeId },
                        { "@date", log.WorkDate },
                        { "@hours", log.HoursWorked }
                    };

                    using (var cmd = _db.CreateCommand(conn, query, parameters))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при добавлении записи табеля", ex);
            }
        }
        public void Update(WorkTimeLog log)
        {
            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    var query = @"
                        UPDATE WorkTimeLog
                        SET Employee_Id = @emp, WorkDate = @date, HoursWorked = @hours
                        WHERE Id = @id";

                    var parameters = new Dictionary<string, object>
                    {
                        { "@emp", log.EmployeeId },
                        { "@date", log.WorkDate },
                        { "@hours", log.HoursWorked },
                        { "@id", log.Id }
                    };

                    using (var cmd = _db.CreateCommand(conn, query, parameters))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при обновлении записи табеля Id={log.Id}", ex);
            }
        }


        private WorkTimeLog MapLog(SqlDataReader reader)
        {
            return new WorkTimeLog
            {
                Id = (int)reader["Id"],
                EmployeeId = (int)reader["Employee_Id"],
                WorkDate = (DateTime)reader["WorkDate"],
                HoursWorked = (decimal)reader["HoursWorked"]
            };
        }


        public void RecalculateSalary(int employeeId, int month, int year)
        {
            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("CalculateSalary", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
                        cmd.Parameters.AddWithValue("@Month", month);
                        cmd.Parameters.AddWithValue("@Year", year);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при пересчёте зарплаты сотрудника Id={employeeId} за {month}/{year}", ex);
            }
        }
    }
}

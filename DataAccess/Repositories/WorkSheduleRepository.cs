using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Repositories
{
    public class WorkScheduleRepository
    {
        private readonly DbManager _db;

        public WorkScheduleRepository(DbManager db)
        {
            _db = db;
        }

        public List<WorkSchedule> GetAll()
        {
            var schedules = new List<WorkSchedule>();
            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    var query = @"
                        SELECT Id, Month, Year, StandardHours, BonusPercent, TaxPercent
                        FROM WorkSchedule";

                    using (var cmd = _db.CreateCommand(conn, query))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            schedules.Add(MapSchedule(reader));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при получении графиков работы", ex);
            }
            return schedules;
        }
        public WorkSchedule GetByMonthYear(int month, int year)
        {
            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    var query = @"
                        SELECT Id, Month, Year, StandardHours, BonusPercent, TaxPercent
                        FROM WorkSchedule
                        WHERE Month = @month AND Year = @year";

                    var parameters = new Dictionary<string, object>
                    {
                        { "@month", month },
                        { "@year", year }
                    };

                    using (var cmd = _db.CreateCommand(conn, query, parameters))
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapSchedule(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при получении графика за {month}/{year}", ex);
            }
            return null;
        }
        public WorkSchedule GetByEmployeeMonth(int employeeId, int year, int month)
        {
            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    var query = @"
                        SELECT ws.Id, ws.Month, ws.Year
                        FROM WorkSchedule ws
                        INNER JOIN SalaryDetails sd ON sd.Schedule_Id = ws.Id
                        WHERE sd.Employee_Id = @emp AND ws.Month = @month AND ws.Year = @year";

                    var parameters = new Dictionary<string, object>
                    {
                        { "@emp", employeeId },
                        { "@month", month },
                        { "@year", year }
                    };

                    using (var cmd = _db.CreateCommand(conn, query, parameters))
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new WorkSchedule
                            {
                                Id = (int)reader["Id"],
                                Month = (int)reader["Month"],
                                Year = (int)reader["Year"]
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при получении графика сотрудника {employeeId} за {month}/{year}", ex);
            }
            return null;
        }
        public List<int> GetDistinctYears()
        {
            var years = new List<int>();
            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    var query = "SELECT DISTINCT Year FROM WorkSchedule ORDER BY Year";

                    using (var cmd = _db.CreateCommand(conn, query))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            years.Add((int)reader["Year"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при получении списка годов из графика", ex);
            }
            return years;
        }
        public List<int> GetDistinctMonthsForYear(int year)
        {
            var months = new List<int>();
            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    var query = @"
                        SELECT DISTINCT Month
                        FROM WorkSchedule
                        WHERE Year = @year
                        ORDER BY Month";

                    var parameters = new Dictionary<string, object>
                    {
                        { "@year", year }
                    };

                    using (var cmd = _db.CreateCommand(conn, query, parameters))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            months.Add((int)reader["Month"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при получении месяцев за {year} год", ex);
            }
            return months;
        }


        public void Add(WorkSchedule schedule)
        {
            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    var query = @"
                        INSERT INTO WorkSchedule (Month, Year, StandardHours, BonusPercent, TaxPercent)
                        VALUES (@month, @year, @hours, @bonus, @tax)";

                    var parameters = new Dictionary<string, object>
                    {
                        { "@month", schedule.Month },
                        { "@year", schedule.Year },
                        { "@hours", schedule.StandardHours },
                        { "@bonus", schedule.BonusPercent },
                        { "@tax", schedule.TaxPercent }
                    };

                    using (var cmd = _db.CreateCommand(conn, query, parameters))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при добавлении графика работы", ex);
            }
        }
        public void Update(WorkSchedule schedule)
        {
            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    var query = @"
                        UPDATE WorkSchedule
                        SET StandardHours = @hours, BonusPercent = @bonus, TaxPercent = @tax
                        WHERE Id = @id";

                    var parameters = new Dictionary<string, object>
                    {
                        { "@hours", schedule.StandardHours },
                        { "@bonus", schedule.BonusPercent },
                        { "@tax", schedule.TaxPercent },
                        { "@id", schedule.Id }
                    };

                    using (var cmd = _db.CreateCommand(conn, query, parameters))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при обновлении графика Id={schedule.Id}", ex);
            }
        }
        public void Delete(int id)
        {
            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    var query = @"
                        DELETE WorkSchedule
                        WHERE Id = @Id";

                    var parameters = new Dictionary<string, object> { { "@Id", id } };

                    using (var cmd = _db.CreateCommand(conn, query, parameters))
                    {
                        cmd.ExecuteReader();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при удалении графика с Id={id}", ex);
            }
        }

        
        private WorkSchedule MapSchedule(SqlDataReader reader)
        {
            return new WorkSchedule
            {
                Id = (int)reader["Id"],
                Month = (int)reader["Month"],
                Year = (int)reader["Year"],
                StandardHours = (decimal)reader["StandardHours"],
                BonusPercent = (decimal)reader["BonusPercent"],
                TaxPercent = (decimal)reader["TaxPercent"]
            };
        }
    }
}

using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
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

        public List<SalaryDetail> GetByEmployeeAndSchedule(int employeeId, int scheduleId)
        {
            var list = new List<SalaryDetail>();
            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    var query = @"
                        SELECT sd.Id, sd.Employee_Id, sd.Schedule_Id, sd.PaymentType_Id, sd.Amount, pt.PaymentTypeName
                        FROM SalaryDetails sd
                        INNER JOIN PaymentTypes pt ON sd.PaymentType_Id = pt.Id
                        WHERE sd.Employee_Id = @emp AND sd.Schedule_Id = @sched";

                    var parameters = new Dictionary<string, object>
                    {
                        { "@emp", employeeId },
                        { "@sched", scheduleId }
                    };

                    using (var cmd = _db.CreateCommand(conn, query, parameters))
                    using (var reader = cmd.ExecuteReader())
                    {
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
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при получении SalaryDetails для сотрудника Id={employeeId} и графика Id={scheduleId}", ex);
            }
            return list;
        }


        public void Upsert(int employeeId, int scheduleId, int paymentTypeId, decimal amount)
        {
            if (amount == 0)
            {
                return;
            }

            var detail = new SalaryDetail
            {
                EmployeeId = employeeId,
                ScheduleId = scheduleId,
                PaymentTypeId = paymentTypeId,
                Amount = amount
            };

            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    var query = @"
                        SELECT COUNT(*) 
                        FROM SalaryDetails 
                        WHERE Employee_Id = @emp AND Schedule_Id = @sched AND PaymentType_Id = @type";

                    var parameters = new Dictionary<string, object>
                    {
                        { "@emp", employeeId },
                        { "@sched", scheduleId },
                        { "@type", paymentTypeId }
                    };

                    using (var cmd = _db.CreateCommand(conn, query, parameters))
                    {
                        int exists = (int)cmd.ExecuteScalar();
                        if (exists > 0)
                        {
                            Update(detail);
                        }
                        else
                        {
                            Add(detail);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при выполнении Upsert SalaryDetail", ex);
            }
        }


        public void Add(SalaryDetail detail)
        {
            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    var query = @"
                        INSERT INTO SalaryDetails (Employee_Id, Schedule_Id, PaymentType_Id, Amount)
                        VALUES (@emp, @sched, @type, @amount)";

                    var parameters = new Dictionary<string, object>
                    {
                        { "@emp", detail.EmployeeId },
                        { "@sched", detail.ScheduleId },
                        { "@type", detail.PaymentTypeId },
                        { "@amount", detail.Amount }
                    };

                    using (var cmd = _db.CreateCommand(conn, query, parameters))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при добавлении SalaryDetail", ex);
            }
        }
        public void Update(SalaryDetail detail)
        {
            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    var query = @"
                        UPDATE SalaryDetails 
                        SET Amount = @amount 
                        WHERE Employee_Id = @emp AND Schedule_Id = @sched AND PaymentType_Id = @type";

                    var parameters = new Dictionary<string, object>
                    {
                        { "@emp", detail.EmployeeId },
                        { "@sched", detail.ScheduleId },
                        { "@type", detail.PaymentTypeId },
                        { "@amount", detail.Amount }
                    };

                    using (var cmd = _db.CreateCommand(conn, query, parameters))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при обновлении SalaryDetail", ex);
            }
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

using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var workShedules = new List<WorkSchedule>();
            using (var conn = _db.GetConnection())
            {
                conn.Open();

                var query = @"
                    SELECT
                        Id, 
                        Month, 
                        Year, 
                        StandardHours, 
                        BonusPercent, 
                        TaxPercent
                    FROM 
                        WorkSchedule
                ";

                var cmd = new SqlCommand(query, conn);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    workShedules.Add(new WorkSchedule
                    {
                        Id = (int)reader["Id"],
                        Month = (int)reader["Month"],
                        Year = (int)reader["Year"],
                        StandardHours = (decimal)reader["StandardHours"],
                        BonusPercent = (decimal)reader["BonusPercent"],
                        TaxPercent = (decimal)reader["TaxPercent"]
                    });
                }
            }
            return workShedules;
        }
        public WorkSchedule GetByMonthYear(int month, int year)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();

                var query = @"
                    SELECT
                        Id, 
                        Month, 
                        Year, 
                        StandardHours, 
                        BonusPercent, 
                        TaxPercent
                    FROM 
                        WorkSchedule 
                    WHERE 
                        Month = @month 
                      AND 
                        Year = @year";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@month", month);
                cmd.Parameters.AddWithValue("@year", year);
                var reader = cmd.ExecuteReader();
                if (reader.Read())
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
            return null;
        }


        public void Add(WorkSchedule schedule)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();

                var query = @"
                    INSERT INTO WorkSchedule (
                        Month, 
                        Year, 
                        StandardHours, 
                        BonusPercent, 
                        TaxPercent) 
                    VALUES (
                        @month, 
                        @year, 
                        @hours, 
                        @bonus, 
                        @tax
                )";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@month", schedule.Month);
                cmd.Parameters.AddWithValue("@year", schedule.Year);
                cmd.Parameters.AddWithValue("@hours", schedule.StandardHours);
                cmd.Parameters.AddWithValue("@bonus", schedule.BonusPercent);
                cmd.Parameters.AddWithValue("@tax", schedule.TaxPercent);
                cmd.ExecuteNonQuery();
            }
        }
        public void Update(WorkSchedule schedule)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();

                var query = @"
                    UPDATE 
                        WorkSchedule 
                    SET 
                        StandardHours = @hours, 
                        BonusPercent = @bonus, 
                        TaxPercent = @tax 
                    WHERE 
                        Id = @id";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@hours", schedule.StandardHours);
                cmd.Parameters.AddWithValue("@bonus", schedule.BonusPercent);
                cmd.Parameters.AddWithValue("@tax", schedule.TaxPercent);
                cmd.Parameters.AddWithValue("@id", schedule.Id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

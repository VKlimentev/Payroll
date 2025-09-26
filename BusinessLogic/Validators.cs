using DataAccess.Models;
using System;
namespace BusinessLogic
{


    public static class Validators
    {
        public static bool IsValidEmployee(Employee emp)
        {
            return !string.IsNullOrWhiteSpace(emp.FullName)
                && (emp.Gender == "М" || emp.Gender == "Ж")
                && emp.BaseSalary >= 0;
        }

        public static bool IsValidWorkTimeLog(WorkTimeLog log)
        {
            return log.HoursWorked >= 0 && log.WorkDate <= DateTime.Today;
        }

        public static bool IsValidSchedule(WorkSchedule schedule)
        {
            return schedule.Month >= 1 && schedule.Month <= 12
                && schedule.Year >= 2000
                && schedule.StandardHours >= 0
                && schedule.BonusPercent >= 0
                && schedule.TaxPercent >= 0;
        }

        public static bool IsValidSalaryDetail(SalaryDetail detail)
        {
            return detail.Amount >= 0;
        }
    }

}

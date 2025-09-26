using DataAccess.Models;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BusinessLogic
{
    public class WorkTimeLogService
    {
        private readonly EmployeeRepository _employeeRepo;
        private readonly WorkTimeLogRepository _workLogRepo;

        public WorkTimeLogService(EmployeeRepository employeeRepo, WorkTimeLogRepository workLogRepo)
        {
            _employeeRepo = employeeRepo;
            _workLogRepo = workLogRepo;
        }


        public void UpsertWorkTime(int employeeId, DateTime workDate, decimal hours)
        {
            _workLogRepo.Upsert(employeeId, workDate, hours);
        }


        public DataTable BuildMonthlyWorkTimeTable(int year, int month)
        {
            var table = CreateTableStructure(year, month);
            var employees = _employeeRepo.GetAll();
            var workLogs = _workLogRepo.GetByMonth(year, month);

            foreach (var employee in employees)
            {
                var row = CreateEmployeeRow(table, employee, workLogs, year, month);
                table.Rows.Add(row);
            }

            return table;
        }
        private DataTable CreateTableStructure(int year, int month)
        {
            var table = new DataTable();
            table.Columns.Add("Employee_Id", typeof(int));
            table.Columns.Add("ФИО", typeof(string));
            table.Columns.Add("Подразделение", typeof(string));

            int daysInMonth = DateTime.DaysInMonth(year, month);
            for (int day = 1; day <= daysInMonth; day++)
            {
                table.Columns.Add(day.ToString(), typeof(decimal));
            }

            table.Columns.Add("Итого", typeof(decimal));
            return table;
        }
        private DataRow CreateEmployeeRow(DataTable table, Employee employee, List<WorkTimeLog> workLogs, int year, int month)
        {
            var row = table.NewRow();
            row["Employee_Id"] = employee.Id;
            row["ФИО"] = employee.FullName;
            row["Подразделение"] = employee.DepartmentName ?? "Неизвестно";

            decimal totalHours = 0;

            for (int day = 1; day <= DateTime.DaysInMonth(year, month); day++)
            {
                DateTime date = new DateTime(year, month, day);
                decimal hours = workLogs
                    .Where(w => w.EmployeeId == employee.Id && w.WorkDate.Date == date.Date)
                    .Sum(w => w.HoursWorked);

                row[day.ToString()] = hours;
                totalHours += hours;
            }

            row["Итого"] = totalHours;
            return row;
        }
    }

}

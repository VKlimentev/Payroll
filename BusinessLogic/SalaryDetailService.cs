using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BusinessLogic
{
    public class SalaryDetailService
    {
        private readonly EmployeeRepository _employeeRepo;
        private readonly DepartmentRepository _departmentRepo;
        private readonly WorkTimeLogRepository _workLogRepo;
        private readonly WorkScheduleRepository _scheduleRepo;
        private readonly PaymentTypeRepository _paymentTypeRepo;
        private readonly SalaryDetailsRepository _salaryRepo;

        public SalaryDetailService(
            EmployeeRepository employeeRepo,
            DepartmentRepository departmentRepo,
            WorkTimeLogRepository workLogRepo,
            WorkScheduleRepository scheduleRepo,
            PaymentTypeRepository paymentTypeRepo,
            SalaryDetailsRepository salaryRepo)
        {
            _employeeRepo = employeeRepo;
            _departmentRepo = departmentRepo;
            _workLogRepo = workLogRepo;
            _scheduleRepo = scheduleRepo;
            _paymentTypeRepo = paymentTypeRepo;
            _salaryRepo = salaryRepo;
        }

        public void UpsertSalaryDetail(int employeeId, int scheduleId, int paymentTypeId, decimal amount)
        {
            _salaryRepo.Upsert(employeeId, scheduleId, paymentTypeId, amount);
        }

        public int GetPaymentTypeIdByName(string name) => _paymentTypeRepo.GetIdByName(name);
        public string GetPaymentCategoryByName(string name) => _paymentTypeRepo.GetCategoryByName(name);

        public int GetScheduleIdForEmployee(int employeeId, int year, int month)
        {
            return _scheduleRepo.GetByEmployeeMonth(employeeId, year, month)?.Id ?? 0;
        }

        private DataTable CreateTableStructure()
        {
            var table = new DataTable();
            table.Columns.Add("Employee_Id", typeof(int));
            table.Columns.Add("ФИО", typeof(string));
            table.Columns.Add("Подразделение", typeof(string));
            table.Columns.Add("Отработанные часы", typeof(decimal));

            foreach (var pt in _paymentTypeRepo.GetAll())
            {
                table.Columns.Add(pt.PaymentTypeName, typeof(decimal));

                if (pt.PaymentTypeName == "Понижение премии за нарушение трудовой дисциплины")
                {
                    table.Columns.Add("Процент", typeof(decimal));
                    table.Columns.Add("Сумма", typeof(decimal));
                }
            }

            table.Columns.Add("Итого", typeof(decimal));
            return table;
        }

        public DataTable BuildSalaryReport(int year, int month)
        {
            var table = CreateTableStructure();
            var employees = _employeeRepo.GetAll();
            var paymentTypes = _paymentTypeRepo.GetAll();
            var schedule = _scheduleRepo.GetByMonthYear(month, year);

            foreach (var emp in employees)
            {
                var row = table.NewRow();
                row["Employee_Id"] = emp.Id;
                row["ФИО"] = emp.FullName;
                row["Подразделение"] = _departmentRepo.GetNameById(emp.DepartmentId) ?? "Неизвестно";
                row["Отработанные часы"] = _workLogRepo.GetTotalHoursWorked(emp.Id, year, month);

                var salaryDetails = _salaryRepo.GetByEmployeeAndSchedule(emp.Id, schedule?.Id ?? 0);
                var payments = new Dictionary<string, decimal>();

                foreach (var detail in salaryDetails)
                {
                    var type = _paymentTypeRepo.GetById(detail.PaymentTypeId);
                    if (type == null)
                    {
                        continue;
                    }

                    var name = type.PaymentTypeName;

                    if (name == "Понижение премии за нарушение трудовой дисциплины")
                    {
                        var bonus = salaryDetails.FirstOrDefault(d => paymentTypes
                            .FirstOrDefault(pt => pt.Id == d.PaymentTypeId)?.PaymentTypeName == "Начисление премии");

                        if (bonus != null)
                        {
                            var reduction = Math.Round(detail.Amount * 100 / bonus.Amount, 2);
                            payments["Процент"] = reduction;
                            payments["Сумма"] = detail.Amount;
                        }
                    }

                    payments[name] = detail.Amount;
                }

                decimal accruals = 0, deductions = 0;

                foreach (var pt in paymentTypes)
                {
                    var name = pt.PaymentTypeName;
                    var amount = payments.ContainsKey(name) ? payments[name] : 0;
                    row[name] = amount;

                    if (pt.PaymentCategory == "Начисление")
                    {
                        accruals += amount;
                    }
                    else if (pt.PaymentCategory == "Удержание")
                    {
                        deductions += amount;
                    }


                    if (name == "Понижение премии за нарушение трудовой дисциплины")
                    {
                        name = "Процент";
                        amount = payments.ContainsKey(name) ? payments[name] : 0;
                        row[name] = amount;

                        name = "Сумма";
                        amount = payments.ContainsKey(name) ? payments[name] : 0;
                        row[name] = amount;
                    }

                }

                row["Итого"] = accruals - deductions;
                table.Rows.Add(row);
            }

            return table;
        }

        public void RecalculateForMonth(int year, int month)
        {
            foreach (var emp in _employeeRepo.GetAll())
            {
                _workLogRepo.RecalculateSalary(emp.Id, month, year);
            }
        }
    }
}

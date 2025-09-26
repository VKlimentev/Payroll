using DataAccess.Repositories;
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

        public int GetPaymentTypeIdByName(string name)
        {
            var types = _paymentTypeRepo.GetAll();
            foreach (var pt in types)
            {
                if (pt.PaymentTypeName == name)
                    return pt.Id;
            }
            return 0;
        }

        public string GetPaymentCategoryByName(string name)
        {
            var types = _paymentTypeRepo.GetAll();
            foreach (var pt in types)
            {
                if (pt.PaymentTypeName == name)
                    return pt.PaymentCategory;
            }
            return "Неизвестно";
        }

        public int GetScheduleIdForEmployee(int employeeId, int year, int month)
        {
            var schedule = _scheduleRepo.GetByEmployeeMonth(employeeId, year, month);
            return schedule?.Id ?? 0;
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

                decimal totalHours = _workLogRepo.GetTotalHoursWorked(emp.Id, year, month);

                row["Отработанные часы"] = totalHours;

                var salaryDetails = _salaryRepo.GetByEmployeeAndSchedule(emp.Id, schedule?.Id ?? 0);
                var groupedPayments = salaryDetails
                    .GroupJoin(paymentTypes,
                        sd => sd.PaymentTypeId,
                        pt => pt.Id,
                        (sd, ptGroup) => new
                        {
                            TypeName = ptGroup.FirstOrDefault()?.PaymentTypeName ?? "Unknown",
                            Category = ptGroup.FirstOrDefault()?.PaymentCategory ?? "Неизвестно",
                            Amount = sd.Amount
                        })
                    .GroupBy(x => x.TypeName)
                    .ToDictionary(g => g.Key, g => new
                    {
                        Total = g.Sum(x => x.Amount),
                        Category = g.First().Category
                    });

                decimal accruals = 0;
                decimal deductions = 0;

                foreach (var pt in paymentTypes)
                {
                    decimal amount = groupedPayments.ContainsKey(pt.PaymentTypeName) ? groupedPayments[pt.PaymentTypeName].Total : 0;
                    row[pt.PaymentTypeName] = amount;

                    if (pt.PaymentCategory == "Начисление")
                    {
                        accruals += amount;
                    }
                    else if (pt.PaymentCategory == "Удержание")
                    {
                        deductions += amount;
                    }
                }

                row["Итого"] = accruals - deductions;
                table.Rows.Add(row);
            }

            return table;
        }

        private DataTable CreateTableStructure()
        {
            var table = new DataTable();
            table.Columns.Add("Employee_Id", typeof(int));
            table.Columns.Add("ФИО", typeof(string));
            table.Columns.Add("Подразделение", typeof(string));
            table.Columns.Add("Отработанные часы", typeof(decimal));

            var paymentTypes = _paymentTypeRepo.GetAll();
            foreach (var pt in paymentTypes)
            {
                table.Columns.Add(pt.PaymentTypeName, typeof(decimal));
            }

            table.Columns.Add("Итого", typeof(decimal));
            return table;
        }
    }

}

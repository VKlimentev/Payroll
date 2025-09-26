using DataAccess.Repositories;

namespace BusinessLogic
{
    public class SalaryCalculationService
    {
        private readonly EmployeeRepository _employeeRepo;
        private readonly WorkTimeLogRepository _workLogRepo;

        public SalaryCalculationService(
            EmployeeRepository employeeRepo,
            WorkTimeLogRepository workLogRepo)
        {
            _employeeRepo = employeeRepo;
            _workLogRepo = workLogRepo;
        }

        public void RecalculateForMonth(int year, int month)
        {
            var employees = _employeeRepo.GetAll();
            foreach (var emp in employees)
            {
                _workLogRepo.RecalculateSalary(emp.Id, month, year);
            }
        }

        public void RecalculateForEmployee(int employeeId, int year, int month)
        {
            _workLogRepo.RecalculateSalary(employeeId, month, year);
        }
    }

}

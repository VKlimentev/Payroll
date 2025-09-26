using DataAccess.Models;
using DataAccess.Repositories;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class EmployeeService
    {
        private readonly EmployeeRepository _repo;

        public EmployeeService(EmployeeRepository repo)
        {
            _repo = repo;
        }

        public List<Employee> GetAll() => _repo.GetAll();
        public Employee GetById(int id) => _repo.GetById(id);


        public bool Add(Employee emp)
        {
            if (!Validators.IsValidEmployee(emp))
            {
                return false;
            }

            _repo.Add(emp);
            return true;
        }
        public bool Update(Employee emp)
        {
            if (!Validators.IsValidEmployee(emp))
            {
                return false;
            }

            _repo.Update(emp);
            return true;
        }
        public void Delete(int id) => _repo.Delete(id);
    }

}

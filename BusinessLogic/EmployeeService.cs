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


        public void  Add(Employee emp) => _repo.Add(emp);
        public void Update(Employee emp) => _repo.Update(emp);
        public void Delete(int id) => _repo.Delete(id);
    }

}

using DataAccess.Models;
using DataAccess.Repositories;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class DepartmentService
    {
        private readonly DepartmentRepository _repo;

        public DepartmentService(DepartmentRepository repo)
        {
            _repo = repo;
        }

        public List<Department> GetAll() => _repo.GetAll();
        public Department GetById(int id) => _repo.GetById(id);
        public string GetNameById(int id) => _repo.GetNameById(id);


        public void Add(Department dept) => _repo.Add(dept);
        public void Update(Department dept) => _repo.Update(dept);
        public void Delete(int id) => _repo.Delete(id);
    }
}

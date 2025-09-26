using DataAccess.Models;
using DataAccess.Repositories;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class PaymentTypeService
    {
        private readonly PaymentTypeRepository _repo;

        public PaymentTypeService(PaymentTypeRepository repo)
        {
            _repo = repo;
        }

        public List<PaymentType> GetAll() => _repo.GetAll();
        public PaymentType GetById(int id) => _repo.GetById(id);


        public void Add(PaymentType ptype) => _repo.Add(ptype);
        public void Update(PaymentType ptype) => _repo.Update(ptype);
        public void Delete(int id) => _repo.Delete(id);
    }
}

using DataAccess.Models;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class WorkScheduleService
    {
        private readonly WorkScheduleRepository _repo;

        public WorkScheduleService(WorkScheduleRepository repo)
        {
            _repo = repo;
        }

        public List<WorkSchedule> GetAll() => _repo.GetAll();
        

        public void Add(WorkSchedule sched) => _repo.Add(sched);
        public void Update(WorkSchedule sched) => _repo.Update(sched);
    }
}

using DataAccess.Models;
using DataAccess.Repositories;
using System.Collections.Generic;

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
        public List<int> GetDistinctYears() => _repo.GetDistinctYears();
        public List<int> GetDistinctMonthsForYear(int year) => _repo.GetDistinctMonthsForYear(year);


        public void Add(WorkSchedule sched) => _repo.Add(sched);
        public void Update(WorkSchedule sched) => _repo.Update(sched);
        public void Delete(int id) => _repo.Delete(id);
    }
}

using System;

namespace DataAccess.Models
{
    public class WorkTimeLog
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime WorkDate { get; set; }
        public decimal HoursWorked { get; set; }
    }
}

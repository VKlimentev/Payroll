namespace DataAccess.Models
{
    public class SalaryDetail
    {
        public int Id { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public int ScheduleId { get; set; }
        public decimal TotalWorkedHours { get; set; }
        public int PaymentTypeId { get; set; }
        public string PaymentTypeName { get; set; }
        public decimal Amount { get; set; }
    }
}

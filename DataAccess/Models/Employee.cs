namespace DataAccess.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } 
        public string Gender { get; set; }
        public decimal BaseSalary { get; set; }
    }
}

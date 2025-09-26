namespace DataAccess.Models
{
    public class WorkSchedule
    {
        public int Id { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal StandardHours { get; set; }
        public decimal BonusPercent { get; set; }
        public decimal TaxPercent { get; set; }
    }
}

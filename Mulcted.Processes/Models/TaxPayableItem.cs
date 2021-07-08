namespace Mulcted.Processes.Models
{
    public class TaxPayableItem
    {
        public decimal BaseRate { get; internal set; }
        public decimal DeductionAmount { get; set; }
        public decimal DeductionRate { get; set; }
        public decimal ReliefAmount { get; set; }
        public decimal ReliefRate { get; set; }
    }
}
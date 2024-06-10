namespace VCMS.Core.Models
{
    public class Medication
    {
        public int Id { get; set; }
        public string TradeName { get; set; }
        public string GenericName { get; set; }
        public string Category { get; set; }
        public string Unit { get; set; }
        public int UnitInStock { get; set; }
        public decimal CostPricePerItem { get; set; }
        public decimal SalePricePerItem { get; set; }
        public DateOnly ExpirationDate { get; set; }

        public virtual List<PrescribedMeds> PrescribedMeds { get; set; } = new List<PrescribedMeds>();
        public virtual List<Prescription> Prescriptions { get; set; } = new List<Prescription>();
    }
}

namespace VCMS.Core.Models
{
    public class Receipt
    {
        public int Id { get; set; }
        public int PrescriptionId { get; set; }
        public virtual Prescription Prescription { get; set; }
        public DateOnly Date { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

namespace VCMS.Core.Models
{
    public class PrescribedMeds
    {
        public int MedicationId { get; set; }
        public virtual Medication Medication { get; set; }
        public int PrescriptionId { get; set; }
        public virtual Prescription Prescription { get; set; }
        public int Quantity { get; set; }
        public string Frequency { get; set; }
    }
}

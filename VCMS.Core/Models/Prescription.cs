namespace VCMS.Core.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public int CaseId { get; set; }
        public virtual Case Case { get; set; }
        public DateOnly Date { get; set; }


        public virtual Receipt Receipt { get; set; }
        public virtual List<PrescribedMeds> PrescribedMeds { get; set; } = new List<PrescribedMeds>();
        public virtual List<Medication> Medications { get; set; } = new List<Medication>();
    }
}

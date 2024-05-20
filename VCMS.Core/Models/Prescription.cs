namespace VCMS.Core.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public int CaseId { get; set; }

        [JsonIgnore]
        public virtual Case Case { get; set; }
        public DateOnly Date { get; set; }


        [JsonIgnore]
        public virtual Receipt Receipt { get; set; }

        [JsonIgnore]
        public virtual List<PrescribedMeds> PrescribedMeds { get; set; } = new List<PrescribedMeds>();

        [JsonIgnore]
        public virtual List<Medication> Medications { get; set; } = new List<Medication>();
    }
}

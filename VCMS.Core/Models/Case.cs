namespace VCMS.Core.Models
{
    public class Case
    {
        public int Id { get; set; }
        public int PatientId { get; set; }

        [JsonIgnore]
        public virtual Patient Patient { get; set; }
        public int DoctorId { get; set; }

        [JsonIgnore]
        public virtual Doctor Doctor { get; set; }
        public int DiagnosisId { get; set; }

        [JsonIgnore]
        public virtual Diagnosis Diagnosis { get; set; }

        /// <summary>
        /// Represents Case Status. 0 for NewCase and 1 for UpdatedCase
        /// </summary>
        [Range(0, 1)]
        public EStatus Status { get; set; }

        /// <summary>
        /// Represents CaseType. 0 for Medical and 1 for Surgical
        /// </summary>
        [Range(0, 1)]
        public ECaseType CaseType { get; set; }
        public DateOnly Date { get; set; }
        public string Notes { get; set; }


        [JsonIgnore]
        public virtual Prescription Prescription { get; set; }
    }
}

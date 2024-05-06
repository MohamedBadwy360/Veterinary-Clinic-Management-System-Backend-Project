using VCMS.Core.Enums;

namespace VCMS.Core.Models
{
    public class Case
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public int DiagnosisId { get; set; }
        public virtual Diagnosis Diagnosis { get; set; }

        /// <summary>
        /// Represents Case Status. 0 for NewCase and 1 for UpdatedCase
        /// </summary>
        public EStatus Status { get; set; }

        /// <summary>
        /// Represents CaseType. 0 for Medical and 1 for Surgical
        /// </summary>
        public ECaseType CaseType { get; set; }
        public DateOnly Date { get; set; }
        public string Notes { get; set; }


        public virtual Prescription Prescription { get; set; }
    }
}

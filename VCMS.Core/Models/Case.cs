namespace VCMS.Core.Models
{
    /// <summary>
    /// Represents a case in Veterinary clinic system.
    /// </summary>
    public class Case
    {
        /// <summary>
        /// Get or set the unique identifier for the doctor.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Get or set the foreign key for patient.
        /// </summary>
        public int PatientId { get; set; }

        /// <summary>
        /// Get or set case's patient.
        /// </summary>
        public virtual Patient Patient { get; set; }

        /// <summary>
        /// Get or set the foreign key for doctor.
        /// </summary>
        public int DoctorId { get; set; }

        /// <summary>
        /// Get or set case's doctor.
        /// </summary>
        public virtual Doctor Doctor { get; set; }

        /// <summary>
        /// Get or set the foreign key for diagnosis.
        /// </summary>
        public int DiagnosisId { get; set; }

        /// <summary>
        /// Get or set case's diagnosis.
        /// </summary>
        public virtual Diagnosis Diagnosis { get; set; }

        /// <summary>
        /// Get or set Case Status. 0 for NewCase and 1 for UpdatedCase
        /// </summary>
        public EStatus Status { get; set; }

        /// <summary>
        /// Get or set CaseType. 0 for Medical and 1 for Surgical
        /// </summary>
        public ECaseType CaseType { get; set; }

        /// <summary>
        /// Get or set case's date.
        /// </summary>
        public DateOnly Date { get; set; }

        /// <summary>
        /// Get or set case's notes.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Get or set case's Prescription
        /// </summary>
        public virtual Prescription Prescription { get; set; }
    }
}

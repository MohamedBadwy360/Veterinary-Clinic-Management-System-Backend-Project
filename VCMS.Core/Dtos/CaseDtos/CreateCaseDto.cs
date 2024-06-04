namespace VCMS.Core.Dtos.CaseDtos
{
    /// <summary>
    /// Data transfer object for creating case entity.
    /// </summary>
    public  class CreateCaseDto : CaseDto
    {
        // <summary>
        /// Get or set the foreign key for patient.
        /// </summary>
        [Required(ErrorMessage = "PatientId is required.")]
        public int PatientId { get; set; }

        /// <summary>
        /// Get or set the foreign key for doctor.
        /// </summary>
        [Required(ErrorMessage = "DoctorId is required.")]
        public int DoctorId { get; set; }

        /// <summary>
        /// Get or set the foreign key for diagnosis.
        /// </summary>
        [Required(ErrorMessage = "DiagnosisId is required.")]
        public int DiagnosisId { get; set; }

        /// <summary>
        /// Get or set Case Status. 0 for NewCase and 1 for UpdatedCase
        /// </summary>
        [Required(ErrorMessage = "Status is required.")]
        [Range(0, 1, ErrorMessage = "Case Status should be 0 or 1. 0 for NewCase and 1 for UpdatedCase.")]
        public EStatus Status { get; set; }

        /// <summary>
        /// Get or set CaseType. 0 for Medical and 1 for Surgical
        /// </summary>
        [Required(ErrorMessage = "v is required.")]
        [Range(0, 1, ErrorMessage = "Case Type should be 0 or 1. 0 for Medical and 1 for Surgical.")]
        public ECaseType CaseType { get; set; }
    }
}

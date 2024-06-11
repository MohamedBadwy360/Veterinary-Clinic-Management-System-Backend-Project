namespace VCMS.Core.Dtos.PrescriptionDtos
{
    /// <summary>
    /// Abstract data transfer object for prescription
    /// </summary>
    public abstract class PrescriptionDto
    {
        /// <summary>
        /// Get or set the foreign key for case entity.
        /// </summary>
        [Required(ErrorMessage = "CaseId is required.")]
        public int CaseId { get; set; }

        /// <summary>
        /// Get or set the date of the prescription.
        /// </summary>
        [Required(ErrorMessage = "Date is required.")]
        public DateOnly Date { get; set; }
    }
}

namespace VCMS.Core.Dtos.CaseDtos
{
    /// <summary>
    /// Data transfer object for case entity.
    /// </summary>
    public class CaseDto
    {
        /// <summary>
        /// Get or set case's date.
        /// </summary>
        [Required(ErrorMessage = "Date is required.")]
        public DateOnly Date { get; set; }

        /// <summary>
        /// Get or set case's notes.
        /// </summary>
        [MaxLength(1000, ErrorMessage = "Notes cant't be longer than 1000 character.")]
        public string Notes { get; set; }
    }
}

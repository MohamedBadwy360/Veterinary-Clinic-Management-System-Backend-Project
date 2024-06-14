namespace VCMS.Core.Dtos.CaseDtos
{
    /// <summary>
    /// Data transfer object for updating a case.
    /// </summary>
    public class UpdateCaseDto
    {
        /// <summary>
        /// Get or set case's notes.
        /// </summary>
        [Required(ErrorMessage = "Notes is required.")]
        [MaxLength(1000, ErrorMessage = "Notes cant't be longer than 1000 character.")]
        public string Notes { get; set; }
    }
}

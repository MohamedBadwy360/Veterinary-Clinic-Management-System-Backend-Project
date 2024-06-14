namespace VCMS.Core.Dtos.PatientDtos
{
    /// <summary>
    /// Data transfer object for deleting a patient.
    /// </summary>
    public class DeletePatientDto : PatientDto
    {
        /// <summary>
        /// Gets or sets the client identifier.
        /// </summary>
        [Required(ErrorMessage = "ClientId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "ClientId should be greater than 0.")]
        public int ClientId { get; set; }

        /// <summary>
        /// Gets or sets the species identifier.
        /// </summary>
        [Required(ErrorMessage = "SpeciesId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "SpeciesId should be greater than 0.")]
        public int SpeciesId { get; set; }
    }
}

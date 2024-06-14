namespace VCMS.Core.Dtos.PatientDtos
{
    /// <summary>
    /// Data transfer object for updating a patient.
    /// </summary>
    public class UpdatePatientDto : PatientDto
    {
        /// <summary>
        /// Gets or sets the species id.
        /// </summary>
        [Required(ErrorMessage = "SpeciesId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "SpeciesId should be greater than 0.")]
        public int SpeciesId { get; set; }
    }
}

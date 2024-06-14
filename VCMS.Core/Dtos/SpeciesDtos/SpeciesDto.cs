namespace VCMS.Core.Dtos.SpeciesDtos
{
    /// <summary>
    /// Data transfer object for species
    /// </summary>
    public class SpeciesDto
    {
        /// <summary>
        /// Name of species
        /// </summary>
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(50, ErrorMessage = "Name can't be longer than 50 characters.")]
        public string Name { get; set; }
    }
}

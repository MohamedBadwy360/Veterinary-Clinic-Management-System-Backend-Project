namespace VCMS.Core.Dtos.PatientDtos
{
    public class UpdatePatientDto : PatientDto
    {
        [Required(ErrorMessage = "SpeciesId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "SpeciesId should be greater than 0.")]
        public int SpeciesId { get; set; }
    }
}

namespace VCMS.Core.Dtos.PatientDtos
{
    public class DeletePatientDto : PatientDto
    {
        [Required(ErrorMessage = "ClientId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "ClientId should be greater than 0.")]
        public int ClientId { get; set; }

        [Required(ErrorMessage = "SpeciesId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "SpeciesId should be greater than 0.")]
        public int SpeciesId { get; set; }
    }
}

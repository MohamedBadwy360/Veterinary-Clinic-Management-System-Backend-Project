namespace VCMS.Core.Dtos.DiagnosisDtos
{
    public class DiagnosisDto
    {
        /// <summary>
        /// Name of Diagnosis
        /// </summary>
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(50, ErrorMessage = "Name can't be longer than 50 characters.")]
        public string Name { get; set; }
    }
}

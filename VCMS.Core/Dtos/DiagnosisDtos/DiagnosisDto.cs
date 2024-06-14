namespace VCMS.Core.Dtos.DiagnosisDtos
{
    /// <summary>
    /// Data Transfer Object for Diagnosis
    /// </summary>
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

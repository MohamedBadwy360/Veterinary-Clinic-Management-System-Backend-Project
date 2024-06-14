namespace VCMS.Core.Dtos.PatientDtos
{
    /// <summary>
    /// Data Transfer Object for Patient
    /// </summary>
    public abstract class PatientDto
    {
        /// <summary>
        /// Patient's count
        /// </summary>
        [Required(ErrorMessage = "Count is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Count should be greater than 0.")]
        public int Count { get; set; }

        /// <summary>
        /// Patient's sex, 0 for Female and 1 for Male.
        /// </summary>
        [Required(ErrorMessage = "Sex is required.")]
        [Range(0, 1, ErrorMessage = "Sex should be 0 or 1 => 0 for Female and 1 for Male.")]
        public ESex Sex { get; set; }

        /// <summary>
        /// Patient's Age
        /// </summary>
        [Required(ErrorMessage = "Age is required.")]
        [MaxLength(25, ErrorMessage = "Age can't be longer than 25 characters.")]
        public string Age { get; set; }
    }
}

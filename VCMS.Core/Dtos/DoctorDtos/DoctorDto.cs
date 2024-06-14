namespace VCMS.Core.Dtos.DoctorDtos
{
    /// <summary>
    /// Data transfer object for Doctor entity
    /// </summary>
    public class DoctorDto
    {
        /// <summary>
        /// Doctor's first name
        /// </summary>
        [Required(ErrorMessage = "FirstName is required.")]
        [MaxLength(50, ErrorMessage = "FirstName can't be longer than 50 characters.")]
        public string FirstName { get; set; }

        /// <summary>
        /// Doctor's last name
        /// </summary>
        [Required(ErrorMessage = "LastName is required.")]
        [MaxLength(50, ErrorMessage = "LastName can't be longer than 50 characters.")]
        public string LastName { get; set; }

        /// <summary>
        /// Doctor's phone number
        /// </summary>
        [Required(ErrorMessage = "PhoneNumber is required.")]
        [MaxLength(15, ErrorMessage = "PhoneNumber can't be longer than 15 characters.")]
        [Phone(ErrorMessage = "Incorrect phone number.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [MaxLength(40, ErrorMessage = "Email can't be longer than 40 characters.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "YearGraduated is required.")]
        [Range(1990, 2023, ErrorMessage = "YearGraduated should be between 1990 and 2023")]
        public int YearGraduated { get; set; }
    }
}

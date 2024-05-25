namespace VCMS.Core.Dtos.ClientDtos
{
    public class ClientDto
    {
        /// <summary>
        /// Client's First Name
        /// </summary>
        [Required(ErrorMessage = "FirstName is required.")]
        [MaxLength(50, ErrorMessage = "FirstName can't be longer than 50 characters.")]
        public string FirstName { get; set; }

        /// <summary>
        /// Client's Last Name
        /// </summary>
        [Required(ErrorMessage = "LastName is required.")]
        [MaxLength(50, ErrorMessage = "LastName can't be longer than 50 characters.")]
        public string LastName { get; set; }

        /// <summary>
        /// Client's Address
        /// </summary>
        [Required(ErrorMessage = "Address is required.")]
        [MaxLength(100, ErrorMessage = "Address can't be longer than 100 characters.")]
        public string Address { get; set; }

        /// <summary>
        /// Client's Phone Number
        /// </summary>
        [Required(ErrorMessage = "PhoneNumber is required.")]
        [MaxLength(15, ErrorMessage = "PhoneNumber can't be longer than 15 characters.")]
        public string PhoneNumber { get; set; }
    }
}

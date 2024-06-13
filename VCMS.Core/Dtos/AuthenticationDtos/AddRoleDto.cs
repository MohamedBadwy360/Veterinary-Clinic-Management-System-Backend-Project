namespace VCMS.Core.Dtos.AuthenticationDtos
{
    /// <summary>
    /// Data transfer for adding role to a user.
    /// </summary>
    public class AddRoleDto
    {
        /// <summary>
        /// Gets or sets the unique identifier of the user.
        /// </summary>
        [Required(ErrorMessage = "UserId is required.")]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the role of the user.
        /// </summary>
        [Required(ErrorMessage = "Role is required.")]
        [StringLength(50, ErrorMessage = "Role can't be longer than 50 characters.")]
        public string Role { get; set; }
    }
}

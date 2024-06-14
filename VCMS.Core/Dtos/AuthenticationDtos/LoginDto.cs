namespace VCMS.Core.Dtos.AuthenticationDtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email is required.")]
        [StringLength(50, ErrorMessage = "Email can't be longer than 50 character.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(50, ErrorMessage = "Password can't be longer than 50 character.")]
        public string Password { get; set; }
    }
}

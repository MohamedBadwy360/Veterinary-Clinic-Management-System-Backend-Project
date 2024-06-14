namespace VCMS.Core.Interfaces.DbInterfaces
{
    public interface IAuthRepository
    {
        Task<AuthenticationDto> RegisterAsync(RegisterDto registerDto);
        Task<AuthenticationDto> LoginAsync(LoginDto loginDto);
        Task<string> AddRoleAsync(AddRoleDto addRoleDto);
    }
}

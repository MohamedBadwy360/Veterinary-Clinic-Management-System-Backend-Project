namespace VCMS.Core.Interfaces.ServicesInterfaces
{
    public interface IAuthService
    {
        Task<Response<AuthenticationDto>> RegisterAsync(RegisterDto registerDto);
        Task<Response<AuthenticationDto>> LoginAsync(LoginDto loginDto);
        Task<Response<AddRoleDto>> AddRoleAsync(AddRoleDto addRoleDto);
    }
}

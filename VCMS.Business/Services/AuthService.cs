namespace VCMS.Business.Services
{
    public class AuthService(IUnitOfWork _unitOfWork) : IAuthService
    {
        public async Task<Response<AuthenticationDto>> RegisterAsync(RegisterDto registerDto)
        {
            var authenticationDto = await _unitOfWork.Authentication.RegisterAsync(registerDto);
            if (!authenticationDto.IsAuthenticated)
            {
                return ResponseFactory.BadRequest(authenticationDto, "Registeration failed.");
            }

            return ResponseFactory.Created(authenticationDto);
        }

        public async Task<Response<AuthenticationDto>> LoginAsync(LoginDto loginDto)
        {
            var authenticationDto = await _unitOfWork.Authentication.LoginAsync(loginDto);
            if (!authenticationDto.IsAuthenticated)
            {
                return ResponseFactory.BadRequest(authenticationDto, "Login failed.");
            }

            return ResponseFactory.Ok(authenticationDto);
        }

        public async Task<Response<AddRoleDto>> AddRoleAsync(AddRoleDto addRoleDto)
        {
            var result = await _unitOfWork.Authentication.AddRoleAsync(addRoleDto);

            return (string.IsNullOrEmpty(result)) ? ResponseFactory.Ok(addRoleDto) :
                ResponseFactory.BadRequest<AddRoleDto>(result);
        }
    }
}

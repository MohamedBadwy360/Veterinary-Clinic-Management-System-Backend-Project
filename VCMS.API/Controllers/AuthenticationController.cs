namespace VCMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController(IAuthService _authService) : ControllerBase
    {
        [SwaggerOperation(Summary = "Register a user")]
        [ProducesResponseType(typeof(Response<AuthenticationDto>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response<AuthenticationDto>), StatusCodes.Status201Created)]
        [ResponseCache(CacheProfileName = "Any-180")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var response = await _authService.RegisterAsync(registerDto);
            return StatusCode((int)response.StatusCode, response);
        }


        [SwaggerOperation(Summary = "Login a user")]
        [ProducesResponseType(typeof(Response<AuthenticationDto>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response<AuthenticationDto>), StatusCodes.Status200OK)]
        [ResponseCache(CacheProfileName = "Any-180")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var response = await _authService.LoginAsync(loginDto);
            return StatusCode((int)response.StatusCode, response);
        }


        [SwaggerOperation(Summary = "Add role to a user")]
        [ProducesResponseType(typeof(Response<AddRoleDto>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response<AddRoleDto>), StatusCodes.Status200OK)]
        [ResponseCache(CacheProfileName = "NoCache")]
        [Authorize(Roles = "Admin")]
        [HttpPost("[action]")]
        public async Task<IActionResult> AddRole(AddRoleDto addRoleDto)
        {
            var response = await _authService.AddRoleAsync(addRoleDto);
            return StatusCode((int)response.StatusCode, response);
        }
    }
}

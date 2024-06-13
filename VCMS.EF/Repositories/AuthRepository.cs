namespace VCMS.EF.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JwtOptions _jwt;

        public AuthRepository(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
            IOptions<JwtOptions> options)
        {
            _userManager = userManager;
            _jwt = options.Value;
            _roleManager = roleManager;
        }

        public async Task<AuthenticationDto> RegisterAsync(RegisterDto registerDto)
        {
            if (await _userManager.FindByEmailAsync(registerDto.Email) is not null)
            {
                return new AuthenticationDto { Message = "Email is already registered." };
            }

            if (await _userManager.FindByEmailAsync(registerDto.Username) is not null)
            {
                return new AuthenticationDto { Message = "Username is already registered." };
            }

            var user = new ApplicationUser
            {
                Email = registerDto.Email,
                UserName = registerDto.Username,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                StringBuilder errors = new StringBuilder();

                foreach (var error in result.Errors)
                {
                    errors.Append($"{error.Description} ");
                }

                return new AuthenticationDto { Message = errors.ToString() };
            }

            await _userManager.AddToRoleAsync(user, Roles.User);

            var jwtSecurityToken = await CreateJwtToken(user);

            return new AuthenticationDto
            {
                IsAuthenticated = true,
                Email = user.Email,
                UserName = user.UserName,
                ExpiresOn = jwtSecurityToken.ValidTo,
                Roles = new List<string> { "User" },
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)
            };
        }

        public async Task<AuthenticationDto> LoginAsync(LoginDto loginDto)
        {
            var authenticationDto = new AuthenticationDto();

            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user is null || ! await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                authenticationDto.Message = "Email or Password is incorrect.";
                return authenticationDto;
            }

            var jwtSecurityToken = await CreateJwtToken(user);
            var roles = await _userManager.GetRolesAsync(user);

            authenticationDto.IsAuthenticated = true;
            authenticationDto.Email = user.Email;
            authenticationDto.UserName = user.UserName;
            authenticationDto.Roles = roles.ToList();
            authenticationDto.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authenticationDto.ExpiresOn = jwtSecurityToken.ValidTo;

            return authenticationDto;
        }

        public async Task<string> AddRoleAsync(AddRoleDto addRoleDto)
        {
            var user = await _userManager.FindByIdAsync(addRoleDto.UserId);
            if (user is null || !await _roleManager.RoleExistsAsync(addRoleDto.Role))
            {
                return "Invalid UserId or Role.";
            }

            if (await _userManager.IsInRoleAsync(user, addRoleDto.Role))
            {
                return "User is already assigned to this role.";
            }
                
            var result = await _userManager.AddToRoleAsync(user, addRoleDto.Role);

            return result.Succeeded ? string.Empty : "Something went wrong while assigning to role.";
        }

        
        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);
            var rolesClaims = new List<Claim>();

            foreach (var role in userRoles)
            {
                rolesClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(rolesClaims);

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.SecretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwt.DuarationInMinutes),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }
}

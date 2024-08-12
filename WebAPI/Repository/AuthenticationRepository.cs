using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace backend.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signinManager;
        private readonly IConfiguration _config;
        public AuthenticationRepository(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager, IConfiguration config)
        {
            _userManager = userManager;
            _signinManager = signInManager;
            _config = config;
        }

        public async Task<IdentityResult> SignupAsync(SignupModel signupModel)
        {
            var user = new ApplicationUser()
            {
                firstname = signupModel.firstname,
                lastname = signupModel.lastname,
                Email = signupModel.email,
                UserName = signupModel.email,
                role = signupModel.role,
            };
            return await _userManager.CreateAsync(user, signupModel.password);
        }

        public async Task<string> LoginAsync(SigninModel signinModel)
        {
            var result = await _signinManager.PasswordSignInAsync(signinModel.email, signinModel.password, false, false);
            if (!result.Succeeded)
            {
                return null;
            }
            var user = await _userManager.FindByEmailAsync(signinModel.email);
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("OnlineMeetingSchedulerwithFullSecurityKey1234567890");
            var identity = new ClaimsIdentity(new Claim[] {
                new Claim(ClaimTypes.Name, user.firstname),
                new Claim(ClaimTypes.Role, user.role)
            });
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            var tokenDesc = new SecurityTokenDescriptor{
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };
            var token = jwtTokenHandler.CreateToken(tokenDesc);
            return jwtTokenHandler.WriteToken(token);
        }
    }
}
using backend.Models;
using backend.Repository;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationRepository _authRepo;
        public AuthenticationController(IAuthenticationRepository authenticationRepository)
        {
            _authRepo = authenticationRepository;
        }


        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromForm] SignupModel signupModel)
        {
            Console.WriteLine(signupModel.firstname);
            var result = await _authRepo.SignupAsync(signupModel);
            if (result.Succeeded)
            {
                return Ok(new { Message = " User Registered Successfully "});
            }
            return Unauthorized();
        }
        [HttpPost("login")]
        public async Task<IActionResult> login([FromForm] SigninModel signinModel)
        {
            Console.WriteLine(signinModel.email);
            Console.WriteLine(signinModel.password);
            var result = await _authRepo.LoginAsync(signinModel);
            if(string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(new { Message = "Login successfull", token = result});
        }

        [HttpGet("hello")]
        public string helloCheck()
        {
            return "hello";
        }
    }
}
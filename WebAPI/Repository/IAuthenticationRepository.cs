using backend.Models;
using Microsoft.AspNetCore.Identity;

namespace backend.Repository
{
    public interface IAuthenticationRepository
    {
        Task<IdentityResult> SignupAsync(SignupModel signupModel);
        Task<string> LoginAsync(SigninModel signinModel);
    }
}
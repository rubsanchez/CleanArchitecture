using CleanArchitecture.Application.Contracts.Identity;
using CleanArchitecture.Application.Models.Identity;

namespace CleanArchitecture.Identity.Services
{
    public class AuthService : IAuthService
    {
        public Task<AuthResponse> Login(AuthRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            throw new NotImplementedException();
        }
    }
}

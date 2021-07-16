using System.Threading.Tasks;
using MediAR.Modules.Membership.Core.Contracts;
using MediAR.Modules.Membership.Core.Dtos;

namespace MediAR.Modules.Membership.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenProvider _tokenProvider;

        public AuthService(IUserService userService, IPasswordHasher passwordHasher, ITokenProvider tokenProvider)
        {
            _userService = userService;
            _passwordHasher = passwordHasher;
            _tokenProvider = tokenProvider;
        }
        
        public async Task<AuthenticationResult> AuthenticateAsync(AuthenticationDto authModel)
        {
            var user = await _userService.GetByNameAsync(authModel.UserName);
            if (user is null)
            {
                return new AuthenticationResult(new[] {"User not found"});
            }

            var isPassCorrect = _passwordHasher.VerifyEncoded(user.PasswordHash, authModel.Password);
            
            if (isPassCorrect)
            {
                var token = _tokenProvider.GenerateToken(user);
                return new AuthenticationResult(token);
            }

            return new AuthenticationResult(new[] {"Password is incorrect"});
        }
    }
}
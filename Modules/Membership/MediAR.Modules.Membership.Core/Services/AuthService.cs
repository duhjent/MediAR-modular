using System.Threading.Tasks;
using MediAR.Modules.Membership.Core.Contracts;
using MediAR.Modules.Membership.Core.Dtos;

namespace MediAR.Modules.Membership.Core.Services
{
    internal class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IAuthTokenProvider _authTokenProvider;

        public AuthService(IUserService userService, IPasswordHasher passwordHasher, IAuthTokenProvider authTokenProvider)
        {
            _userService = userService;
            _passwordHasher = passwordHasher;
            _authTokenProvider = authTokenProvider;
        }
        
        public async Task<AuthenticationResult> AuthenticateAsync(AuthenticationRequestModel authModel)
        {
            var user = await _userService.GetByNameAsync(authModel.UserName);
            if (user is null)
            {
                return new AuthenticationResult(new[] {"User not found"});
            }

            var isPassCorrect = _passwordHasher.VerifyEncoded(user.PasswordHash, authModel.Password);
            
            if (isPassCorrect)
            {
                var token = _authTokenProvider.GenerateToken(user);
                return new AuthenticationResult(token);
            }

            return new AuthenticationResult(new[] {"Password is incorrect"});
        }
    }
}
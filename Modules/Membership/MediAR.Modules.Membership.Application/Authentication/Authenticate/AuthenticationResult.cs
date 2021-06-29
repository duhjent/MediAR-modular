using MediAR.Modules.Membership.Domain.Users;

namespace MediAR.Modules.Membership.Application.Authentication.Authenticate
{
    public class AuthenticationResult
    {

        private AuthenticationResult() { }

        public static AuthenticationResult Failed(string error)
        {
            return new AuthenticationResult
            {
                IsSuccessful = false,
                Error = error
            };
        }
        
        public static AuthenticationResult Successful(string token)
        {
            return new AuthenticationResult
            {
                IsSuccessful = true,
                Token = token
            };
        }

        public bool IsSuccessful { get; private set; }

        public string Error { get; private set; }

        public string Token { get; private set; }
    }
}
using MediAR.Modules.Membership.Domain.Users;

namespace MediAR.Modules.Membership.Application.Authentication.Authenticate
{
    public class AuthenticationResult
    {
        public AuthenticationResult(string error)
        {
            IsSuccessful = false;
            Error = error;
        }

        public AuthenticationResult(ApplicationUser user)
        {
            IsSuccessful = true;
            User = user;
        }
        
        public bool IsSuccessful { get; }

        public string Error { get; }

        public ApplicationUser User { get; }
    }
}
using MediAR.Core.Application.Contracts;

namespace MediAR.Modules.Membership.Application.Authentication.Authenticate
{
    public class AuthenticateCommand: BaseCommand<AuthenticationResult>
    {
        public AuthenticateCommand(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public string UserName { get; }

        public string Password { get; }
    }
}
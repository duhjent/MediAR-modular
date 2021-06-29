using MediAR.Modules.Membership.Domain.Users;

namespace MediAR.Modules.Membership.Application.Users.RegisterUser
{
    public class RegistrationResult
    {
        public RegistrationResult(ApplicationUser user)
        {
            CreatedUser = user;
            IsSuccessful = true;
        }

        public RegistrationResult(string message)
        {
            ErrorMessage = message;
            IsSuccessful = false;
        }

        public bool IsSuccessful { get; }
        
        public ApplicationUser CreatedUser { get; }

        public string ErrorMessage { get; }
    }
}
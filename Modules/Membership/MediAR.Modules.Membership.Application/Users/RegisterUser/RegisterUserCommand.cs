using MediAR.Core.Application.Contracts;

namespace MediAR.Modules.Membership.Application.Users.RegisterUser
{
    public class RegisterUserCommand : BaseCommand<RegistrationResult>
    {
        public RegisterUserCommand(UserRegistrationDto registrationModel)
        {
            RegistrationModel = registrationModel;
        }
        
        public UserRegistrationDto RegistrationModel { get; }
    }
}
using System.Threading;
using System.Threading.Tasks;
using MediAR.Modules.Membership.Application.Configuration.Commands;
using MediAR.Modules.Membership.Domain.Authentication;
using MediAR.Modules.Membership.Domain.Users;

namespace MediAR.Modules.Membership.Application.Users.RegisterUser
{
    public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, RegistrationResult>
    {
        private readonly IUserRepository _repo;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterUserCommandHandler(IUserRepository repo, IPasswordHasher passwordHasher)
        {
            _repo = repo;
            _passwordHasher = passwordHasher;
        }
        
        public async Task<RegistrationResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser
            {
                UserName = request.RegistrationModel.UserName,
                Email = request.RegistrationModel.Email,
                FirstName = request.RegistrationModel.FirstName,
                LastName = request.RegistrationModel.LastName,
                PasswordHash = _passwordHasher.Encode(request.RegistrationModel.Password)
            };

            var registered = await _repo.AddUser(user);

            return new RegistrationResult(registered);
        }
    }
}
using System.Threading;
using System.Threading.Tasks;
using MediAR.Core.Application.Data;
using MediAR.Modules.Membership.Application.Configuration.Commands;
using Dapper;
using MediAR.Modules.Membership.Domain.Authentication;
using MediAR.Modules.Membership.Domain.Users;

namespace MediAR.Modules.Membership.Application.Authentication.Authenticate
{
    public class AuthenticateCommandHandler : ICommandHandler<AuthenticateCommand, AuthenticationResult>
    {
        private readonly ISqlConnectionFactory _connectionFactory;
        private readonly IPasswordHasher _passwordHasher;

        public AuthenticateCommandHandler(ISqlConnectionFactory connectionFactory, IPasswordHasher passwordHasher)
        {
            _connectionFactory = connectionFactory;
            _passwordHasher = passwordHasher;
        }
        
        public async Task<AuthenticationResult> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            var connection = _connectionFactory.GetOpenConnection();

            var query = "SELECT * FROM [ApplicationUsers] WHERE UserName = @UserName";
            var user = await connection.QuerySingleOrDefaultAsync<ApplicationUser>(query, new {request.UserName});

            if (user == null)
            {
                return new AuthenticationResult("User is not found");
            }

            if (!_passwordHasher.VerifyEncoded(user.PasswordHash, request.Password))
            {
                return new AuthenticationResult("Incorrect password");
            }

            return new AuthenticationResult(user);
        }
    }
}
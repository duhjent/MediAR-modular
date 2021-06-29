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
        private readonly ITokenProvider _tokenProvider;

        public AuthenticateCommandHandler(ISqlConnectionFactory connectionFactory, IPasswordHasher passwordHasher, ITokenProvider tokenProvider)
        {
            _connectionFactory = connectionFactory;
            _passwordHasher = passwordHasher;
            _tokenProvider = tokenProvider;
        }
        
        public async Task<AuthenticationResult> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            var connection = _connectionFactory.GetOpenConnection();

            var query = "SELECT * FROM [ApplicationUsers] WHERE UserName = @UserName";
            var user = await connection.QuerySingleOrDefaultAsync<ApplicationUser>(query, new {request.UserName});

            if (user == null)
            {
                return AuthenticationResult.Failed("User is not found");
            }

            if (!_passwordHasher.VerifyEncoded(user.PasswordHash, request.Password))
            {
                return AuthenticationResult.Failed("Incorrect password");
            }

            var token = _tokenProvider.GenerateToken(user);

            return AuthenticationResult.Successful(token);
        }
    }
}
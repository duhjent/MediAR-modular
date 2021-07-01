using Dapper;
using MediAR.Core.Application.Data;
using MediAR.Modules.Membership.Domain.Users;

namespace MediAR.Modules.Membership.Infrastructure.Domain.Users
{
    public class UserCounter : IUserCounter
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public UserCounter(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory
        }

        public int CountUsersWithUserName(string userName)
        {
            var query = "SELECT COUNT(*) FROM [ApplicationUsers] WHERE UserName = @UserName";
            var connection = _connectionFactory.GetOpenConnection();

            var usersCount = connection.QuerySingle<int>(query, new {userName});

            return usersCount;
        }
    }
}
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediAR.Core.Application.Data;
using MediAR.Modules.Membership.Application.Configuration.Queries;
using MediAR.Modules.Membership.Domain.Roles;

namespace MediAR.Modules.Membership.Application.Authorization.GetUserRoles
{
    public class GetUserRolesQueryHandler : IQueryHandler<GetUserRolesQuery, List<Role>>
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public GetUserRolesQueryHandler(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<List<Role>> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
        {
            var connection = _connectionFactory.GetOpenConnection();
            var query =
                "SELECT * FROM [Roles] WHERE [Id] IN (SELECT [RoleId] FROM [ApplicationUserRoles] WHERE [ApplicationUserId] = @UserId)";

            var roles = await connection.QueryAsync<Role>(query, new {request.UserId});

            return roles.AsList();
        }
    }
}
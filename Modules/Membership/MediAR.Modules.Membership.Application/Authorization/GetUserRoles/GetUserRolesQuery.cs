using System;
using System.Collections.Generic;
using MediAR.Core.Application.Contracts;
using MediAR.Modules.Membership.Domain.Roles;

namespace MediAR.Modules.Membership.Application.Authorization.GetUserRoles
{
    public class GetUserRolesQuery : BaseQuery<List<Role>>
    {
        public GetUserRolesQuery(Guid userId)
        {
            UserId = userId;
        }
        
        public Guid UserId { get; }
    }
}
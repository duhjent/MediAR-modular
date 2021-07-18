using System;
using System.Threading.Tasks;
using MediAR.Modules.Membership.Core.Entities;

namespace MediAR.Modules.Membership.Core.Contracts
{
    public interface IRoleService
    {
        public Task<bool> UserHasRole(Guid userId, string roleName);
        public Task<Role> CreateRoleWithName(string roleName);
        public Task AddRoleToUser(Guid userId, string roleName);
        public Task AddRoleToUser(Guid userId, Guid roleId);
    }
}
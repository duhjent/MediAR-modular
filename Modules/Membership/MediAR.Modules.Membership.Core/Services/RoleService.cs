using System;
using System.Linq;
using System.Threading.Tasks;
using MediAR.Modules.Membership.Core.Contracts;
using MediAR.Modules.Membership.Core.Entities;

namespace MediAR.Modules.Membership.Core.Services
{
    internal class RoleService : IRoleService
    {
        private readonly IRoleRepository _repo;

        public RoleService(IRoleRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> UserHasRole(Guid userId, string roleName)
        {
            var userWithIdAndRole = await _repo.GetFirstAsync(role =>
                role.Name == roleName && role.ApplicationUsers.Any(aur => aur.ApplicationUserId == userId));

            return userWithIdAndRole is not null;
        }

        public async Task<Role> CreateRoleWithName(string roleName)
        {
            var roleWithName = await _repo.GetFirstAsync(x => x.Name == roleName);
            if (roleWithName is not null)
            {
                return roleWithName;
            }
            
            var role = new Role
            {
                Name = roleName
            };

            return await _repo.AddAsync(role);
        }

        public async Task AddRoleToUser(Guid userId, string roleName)
        {
            var role = await _repo.GetFirstAsync(x => x.Name == roleName);
            var aur = new ApplicationUserRole
            {
                ApplicationUserId = userId,
                RoleId = role.Id
            };

            await _repo.AddApplicationUserRoleAsync(aur);
        }

        public async Task AddRoleToUser(Guid userId, Guid roleId)
        {
            var aur = new ApplicationUserRole
            {
                ApplicationUserId = userId,
                RoleId = roleId
            };

            await _repo.AddApplicationUserRoleAsync(aur);
        }
    }
}
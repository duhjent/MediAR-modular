using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MediAR.Modules.Membership.Core.Entities;

namespace MediAR.Modules.Membership.Core.Contracts
{
    public interface IRoleRepository
    {
        Task<IReadOnlyList<Role>> GetAsync(Expression<Func<Role, bool>> filter);
        Task<Role> GetFirstAsync(Expression<Func<Role, bool>> filter);
        Task<Role> AddAsync(Role role);
        Task<Role> UpdateAsync(Role role);
        Task DeleteAsync(Role role);
        Task AddApplicationUserRoleAsync(ApplicationUserRole aur);
    }
}
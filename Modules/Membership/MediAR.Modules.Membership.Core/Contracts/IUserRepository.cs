using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MediAR.Modules.Membership.Core.Entities;

namespace MediAR.Modules.Membership.Core.Contracts
{
    public interface IUserRepository
    {
        Task<ApplicationUser> AddAsync(ApplicationUser user);
        Task<IReadOnlyList<ApplicationUser>> GetAllAsync();
        Task<IReadOnlyList<ApplicationUser>> GetAsync(Expression<Func<ApplicationUser, bool>> filter);
        Task<ApplicationUser> GetFirstAsync(Expression<Func<ApplicationUser, bool>> filter);
        Task<ApplicationUser> GetByIdAsync(Guid id);
        Task<ApplicationUser> UpdateAsync(ApplicationUser user);
        Task DeleteAsync(ApplicationUser user);
        Task<UserToken> AddTokenAsync(UserToken token);
        Task<IReadOnlyList<UserToken>> GetTokensForUserAsync(Guid userId);
    }
}
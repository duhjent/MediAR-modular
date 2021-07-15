using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediAR.Modules.Membership.Core.Entities;

namespace MediAR.Modules.Membership.Core.Contracts
{
    public interface IUserRepository
    {
        Task<ApplicationUser> AddAsync(ApplicationUser user);
        Task<IReadOnlyList<ApplicationUser>> GetAllAsync();
        Task<ApplicationUser> GetByIdAsync(Guid id);
        Task<ApplicationUser> UpdateAsync(ApplicationUser user);
        Task DeleteAsync(ApplicationUser user);
    }
}
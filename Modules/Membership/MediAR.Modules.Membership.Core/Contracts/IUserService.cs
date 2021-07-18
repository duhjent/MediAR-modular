using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediAR.Modules.Membership.Core.Dtos;
using MediAR.Modules.Membership.Core.Entities;

namespace MediAR.Modules.Membership.Core.Contracts
{
    public interface IUserService
    {
        Task<ApplicationUser> GetByIdAsync(Guid id);
        Task<ApplicationUser> GetByNameAsync(string userName);
        Task<ApplicationUser> GetByEmailAsync(string email);
        Task<IReadOnlyList<ApplicationUser>> GetAllAsync();
        Task<RegistrationResult> RegisterAsync(UserRegistrationRequestModel model);
        Task<ApplicationUser> UpdateAsync(ApplicationUser user);
        Task DeleteAsync(ApplicationUser user);
        Task DeleteAsync(Guid id);
    }
}
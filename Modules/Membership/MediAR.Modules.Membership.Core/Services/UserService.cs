using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediAR.Core.Contracts.Exceptions;
using MediAR.Modules.Membership.Core.Contracts;
using MediAR.Modules.Membership.Core.Dtos;
using MediAR.Modules.Membership.Core.Entities;

namespace MediAR.Modules.Membership.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        private readonly IPasswordHasher _hasher;
        private readonly ITokenProvider _tokenProvider;

        public UserService(IUserRepository repo, IPasswordHasher hasher, ITokenProvider tokenProvider)
        {
            _repo = repo;
            _hasher = hasher;
            _tokenProvider = tokenProvider;
        }

        public async Task<ApplicationUser> GetByIdAsync(Guid id) => await _repo.GetByIdAsync(id);

        public async Task<ApplicationUser> GetByNameAsync(string userName) =>
            await _repo.GetFirstAsync(x => x.UserName == userName);

        public async Task<ApplicationUser> GetByEmailAsync(string email) =>
            await _repo.GetFirstAsync(x => x.Email == email);

        public async Task<IReadOnlyList<ApplicationUser>> GetAllAsync() => await _repo.GetAllAsync();

        public async Task<RegistrationResult> RegisterAsync(UserRegistrationRequestModel model)
        {
            var userWithSameName = await GetByNameAsync(model.UserName);
            if (userWithSameName is not null)
            {
                return new RegistrationResult(new[] {"UserName is taken"});
            }

            var userWithSameEmail = await GetByEmailAsync(model.Email);
            if (userWithSameEmail is not null)
            {
                return new RegistrationResult(new[] {"Email is taken"});
            }

            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                // TODO: fix when #tenantManagement is ready
                TenantId = Guid.NewGuid(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                PasswordHash = _hasher.Encode(model.Password)
            };

            var registeredUser = await _repo.AddAsync(user);

            return new RegistrationResult(_tokenProvider.GenerateToken(registeredUser));
        }

        public async Task<ApplicationUser> UpdateAsync(ApplicationUser user) => await _repo.UpdateAsync(user);

        public async Task DeleteAsync(ApplicationUser user) => await _repo.DeleteAsync(user);

        public async Task DeleteAsync(Guid id)
        {
            var user = await GetByIdAsync(id);
            if (user is null)
            {
                throw new BaseNotFoundException<ApplicationUser>();
            }

            await DeleteAsync(user);
        }
    }
}
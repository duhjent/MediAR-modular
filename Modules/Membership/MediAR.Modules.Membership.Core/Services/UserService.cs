using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediAR.Core.Contracts.Exceptions;
using MediAR.Modules.Membership.Core.Configurations;
using MediAR.Modules.Membership.Core.Contracts;
using MediAR.Modules.Membership.Core.Dtos;
using MediAR.Modules.Membership.Core.Entities;

namespace MediAR.Modules.Membership.Core.Services
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        private readonly IPasswordHasher _hasher;
        private readonly IAuthTokenProvider _authTokenProvider;
        private readonly ITokenProvider _tokenProvider;
        private readonly TokenConfiguration _tokenConfig;

        public UserService(IUserRepository repo,
            IPasswordHasher hasher,
            IAuthTokenProvider authTokenProvider,
            ITokenProvider tokenProvider, 
            TokenConfiguration tokenConfig)
        {
            _repo = repo;
            _hasher = hasher;
            _authTokenProvider = authTokenProvider;
            _tokenProvider = tokenProvider;
            _tokenConfig = tokenConfig;
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

            return new RegistrationResult(_authTokenProvider.GenerateToken(registeredUser));
        }

        public async Task<ApplicationUser> UpdateAsync(ApplicationUser user) => await _repo.UpdateAsync(user);

        public async Task DeleteAsync(ApplicationUser user) => await _repo.DeleteAsync(user);

        public async Task<string> GeneratePasswordResetTokenAsync(Guid userId)
        {
            var user = await GetByIdAsync(userId);
            var tokenString = _tokenProvider.GenerateToken("changePassword", user);
            var userToken = new UserToken
            {
                Token = tokenString,
                UserId = user.Id,
                ExpTime = DateTimeOffset.Now.Add(new TimeSpan(_tokenConfig.MembershipTokenExpDays, 0, 0, 0))
            };
            await _repo.AddTokenAsync(userToken);
            return tokenString;
        }

        public async Task<PasswordResetResult> ResetPasswordAsync(string userName, string token, string newPassword)
        {
            var user = await GetByNameAsync(userName);
            var userTokens = await _repo.GetTokensForUserAsync(user.Id);
            var foundToken = userTokens.FirstOrDefault(x => x.Token == token);
            if (foundToken is null)
            {
                return new PasswordResetResult(new string[] {"Token not found"});
            }

            if (foundToken.ExpTime < DateTimeOffset.Now)
            {
                return new PasswordResetResult(new string[] {"Token has expired"});
            }
            
            user.PasswordHash = _hasher.Encode(newPassword);
            await _repo.UpdateAsync(user);

            return new PasswordResetResult();
        }
    }
}
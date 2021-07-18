using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MediAR.Modules.Membership.Core.Contracts;
using MediAR.Modules.Membership.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediAR.Modules.Membership.Core.DAL.EF
{
    public class EfCoreUserRepository : IUserRepository
    {
        private readonly MembershipDbContext _ctx;

        public EfCoreUserRepository(MembershipDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<ApplicationUser> AddAsync(ApplicationUser user)
        {
            _ctx.ApplicationUsers.Add(user);
            await _ctx.SaveChangesAsync();
            return user;
        }

        public async Task<IReadOnlyList<ApplicationUser>> GetAllAsync() => await _ctx.ApplicationUsers.ToListAsync();

        public async Task<IReadOnlyList<ApplicationUser>> GetAsync(Expression<Func<ApplicationUser, bool>> filter) =>
            await _ctx.ApplicationUsers
                .Include(au => au.Roles)
                .ThenInclude(aur => aur.Role)
                .AsQueryable().Where(filter).ToListAsync();

        public async Task<ApplicationUser> GetFirstAsync(Expression<Func<ApplicationUser, bool>> filter) =>
            await _ctx.ApplicationUsers
                .Include(au => au.Roles)
                .ThenInclude(aur => aur.Role)
                .FirstOrDefaultAsync(filter);

        public async Task<ApplicationUser> GetByIdAsync(Guid id) =>
            await _ctx.ApplicationUsers
                .Include(au => au.Roles)
                .ThenInclude(aur => aur.Role)
                .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<ApplicationUser> UpdateAsync(ApplicationUser user)
        {
            _ctx.ApplicationUsers.Update(user);
            await _ctx.SaveChangesAsync();
            return user;
        }

        public async Task DeleteAsync(ApplicationUser user)
        {
            _ctx.ApplicationUsers.Remove(user);
            await _ctx.SaveChangesAsync();
        }

        public async Task<UserToken> AddTokenAsync(UserToken token)
        {
            await _ctx.UserTokens.AddAsync(token);
            await _ctx.SaveChangesAsync();
            return token;
        }

        public async Task<IReadOnlyList<UserToken>> GetTokensForUserAsync(Guid userId)
        {
            var tokens = await _ctx.UserTokens.AsQueryable().Where(x => x.UserId == userId).ToListAsync();

            return tokens;
        }
    }
}
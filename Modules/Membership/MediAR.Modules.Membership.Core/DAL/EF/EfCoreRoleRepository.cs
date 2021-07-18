using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MediAR.Modules.Membership.Core.DAL;
using MediAR.Modules.Membership.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediAR.Modules.Membership.Core.Contracts
{
    class EfCoreRoleRepository : IRoleRepository
    {
        private readonly MembershipDbContext _ctx;

        public EfCoreRoleRepository(MembershipDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IReadOnlyList<Role>> GetAsync(Expression<Func<Role, bool>> filter) =>
            await _ctx.Roles.Include(r => r.ApplicationUsers)
                .ThenInclude(aur => aur.ApplicationUser)
                .AsQueryable().Where(filter).ToListAsync();

        public async Task<Role> GetFirstAsync(Expression<Func<Role, bool>> filter) =>
            await _ctx.Roles.Include(r => r.ApplicationUsers)
                .ThenInclude(aur => aur.ApplicationUser)
                .FirstOrDefaultAsync(filter);

        public async Task<Role> AddAsync(Role role)
        {
            _ctx.Roles.Add(role);
            await _ctx.SaveChangesAsync();
            return role;
        }

        public async Task<Role> UpdateAsync(Role role)
        {
            _ctx.Roles.Update(role);
            await _ctx.SaveChangesAsync();
            return role;
        }

        public async Task DeleteAsync(Role role)
        {
            _ctx.Roles.Remove(role);
            await _ctx.SaveChangesAsync();
        }

        public async Task AddApplicationUserRoleAsync(ApplicationUserRole aur)
        {
            await _ctx.ApplicationUserRoles.AddAsync(aur);
            await _ctx.SaveChangesAsync();
        }
    }
}
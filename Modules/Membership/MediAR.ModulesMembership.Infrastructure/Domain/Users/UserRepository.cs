using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MediAR.Modules.Membership.Domain.Users;

namespace MediAR.ModulesMembership.Infrastructure.Domain.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly MembershipContext _ctx;

        public UserRepository(MembershipContext ctx)
        {
            _ctx = ctx;
        }
        
        public async Task<ApplicationUser> AddUser(ApplicationUser user)
        {
            _ctx.Add(user);
            await _ctx.SaveChangesAsync();
            return user;
        }
    }
}
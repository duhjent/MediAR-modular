using MediAR.Modules.Membership.Domain.Roles;
using MediAR.Modules.Membership.Domain.Tokens;
using MediAR.Modules.Membership.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace MediAR.Modules.Membership.Infrastructure
{
    public class MembershipContext : DbContext
    {
        public MembershipContext(DbContextOptions<MembershipContext> options) : base(options) { }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<UserToken> UserTokens { get; set; }

        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}
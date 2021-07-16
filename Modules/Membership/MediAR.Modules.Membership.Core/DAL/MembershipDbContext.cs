using MediAR.Modules.Membership.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediAR.Modules.Membership.Core.DAL
{
    public class MembershipDbContext : DbContext
    {
        public MembershipDbContext(DbContextOptions<MembershipDbContext> options) : base(options) { }
        
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<UserToken> UserTokens { get; set; }

        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

    }
}
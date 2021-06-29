using MediAR.Modules.Membership.Domain.Roles;
using MediAR.Modules.Membership.Domain.Tokens;
using MediAR.Modules.Membership.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace MediAR.ModulesMembership.Infrastructure
{
    public class MembershipContext : DbContext
    {
        public MembershipContext(DbContextOptions<MembershipContext> options) : base(options) { }

        public ApplicationUser ApplicationUsers { get; set; }

        public UserToken UserTokens { get; set; }

        public ApplicationUserRole ApplicationUserRoles { get; set; }

        public Role Roles { get; set; }

        public UserProfile UserProfiles { get; set; }
    }
}
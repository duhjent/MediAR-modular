using MediAR.Modules.Membership.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediAR.Modules.Membership.Core.DAL.Configurations
{
    public class ApplicationUserRoleConfiguration : IEntityTypeConfiguration<ApplicationUserRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
        {
            builder.HasKey(aur => new {aur.RoleId, aur.ApplicationUserId});
            builder.HasOne(aur => aur.Role)
                .WithMany(r => r.ApplicationUsers);
            builder.HasOne(aur => aur.ApplicationUser)
                .WithMany(au => au.Roles);
        }
    }
}
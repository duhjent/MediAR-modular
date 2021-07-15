using MediAR.Modules.Membership.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediAR.Modules.Membership.Core.DAL.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasMany(au => au.Roles)
                .WithOne(aur => aur.ApplicationUser);
            builder.HasMany(au => au.Tokens)
                .WithOne(t => t.User);
            builder.HasOne(au => au.UserProfile)
                .WithOne(up => up.ApplicationUser);
        }
    }
}
using MediAR.Modules.Membership.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediAR.Modules.Membership.Core.DAL.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasMany(r => r.ApplicationUsers)
                .WithOne(aur => aur.Role);
        }
    }
}
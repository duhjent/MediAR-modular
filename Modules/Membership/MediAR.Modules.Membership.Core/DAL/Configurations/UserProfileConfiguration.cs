using MediAR.Modules.Membership.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediAR.Modules.Membership.Core.DAL.Configurations
{
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasKey(up => up.ApplicationUserId);
            builder.HasOne(up => up.ApplicationUser)
                .WithOne(au => au.UserProfile);
        }
    }
}
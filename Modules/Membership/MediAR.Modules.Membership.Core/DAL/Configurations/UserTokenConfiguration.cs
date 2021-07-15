using MediAR.Modules.Membership.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediAR.Modules.Membership.Core.DAL.Configurations
{
    public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            builder.HasOne(ut => ut.User)
                .WithMany(au => au.Tokens);
        }
    }
}
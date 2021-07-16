using MediAR.Core.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MediAR.Modules.Membership.Core.DAL
{
    public class MembershipDbContextFactory : IDesignTimeDbContextFactory<MembershipDbContext>
    {
            public MembershipDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<MembershipDbContext>();
                var sqlConfig = SqlServerConfigFactory.GetConfig();

                optionsBuilder.UseSqlServer(sqlConfig.ConnectionString);

                return new MembershipDbContext(optionsBuilder.Options);
            }
    }
}
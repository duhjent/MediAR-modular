using Autofac;
using MediAR.Core.Infrastructure.DAL;
using MediAR.Modules.Membership.Core.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MediAR.Modules.Membership.Api
{
    public class MembershipModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var sqlConfig = SqlServerConfigFactory.GetConfig();

            builder.RegisterType<MembershipDbContext>()
                .WithParameter("options",
                    new DbContextOptionsBuilder<MembershipDbContext>().UseSqlServer(sqlConfig.ConnectionString));
        }
    }
}
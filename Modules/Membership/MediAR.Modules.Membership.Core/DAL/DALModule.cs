using Autofac;
using MediAR.Core.Infrastructure.DAL;
using MediAR.Modules.Membership.Core.Contracts;
using MediAR.Modules.Membership.Core.DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MediAR.Modules.Membership.Core.DAL
{
    internal class DALModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register<MembershipDbContext>(x =>
                {
                    var configuration = x.Resolve<IConfiguration>();
                    var section = configuration.GetSection("sqlConfig");
                    var sqlConfig = new SqlServerConfig();
                    section.Bind(sqlConfig);
                    var dbContextOptions = new DbContextOptionsBuilder<MembershipDbContext>()
                        .UseSqlServer(sqlConfig.ConnectionString).Options;

                    return new MembershipDbContext(dbContextOptions);
                })
                .InstancePerLifetimeScope();

            builder.RegisterType<EfCoreUserRepository>()
                .As<IUserRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<EfCoreRoleRepository>()
                .As<IRoleRepository>()
                .InstancePerLifetimeScope();

        }
    }
}
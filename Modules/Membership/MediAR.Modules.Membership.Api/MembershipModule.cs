using Autofac;
using MediAR.Core.Infrastructure.DAL;
using MediAR.Modules.Membership.Core.Configurations;
using MediAR.Modules.Membership.Core.Contracts;
using MediAR.Modules.Membership.Core.DAL;
using MediAR.Modules.Membership.Core.DAL.EF;
using MediAR.Modules.Membership.Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MediAR.Modules.Membership.Api
{
    public class MembershipModule : Module
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

            builder.RegisterType<PasswordHasher>()
                .As<IPasswordHasher>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AuthTokenProvider>()
                .As<ITokenProvider>()
                .InstancePerLifetimeScope();

            builder.RegisterType<EfCoreUserRepository>()
                .As<IUserRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UserService>()
                .As<IUserService>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<AuthService>()
                .As<IAuthService>()
                .InstancePerLifetimeScope();

            builder.Register(x =>
            {
                var configuration = x.Resolve<IConfiguration>();
                var section = configuration.GetSection("tokenConfig");
                var tokenConfig = new TokenConfiguration();
                section.Bind(tokenConfig);
                return tokenConfig;
            }).SingleInstance();
        }
    }
}
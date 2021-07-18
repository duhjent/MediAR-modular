using Autofac;
using Microsoft.Extensions.Configuration;

namespace MediAR.Modules.Membership.Core.Configurations
{
    internal class ConfigurationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(x =>
            {
                var configuration = x.Resolve<IConfiguration>();
                var section = configuration.GetSection("tokenConfig");
                var tokenConfig = new TokenConfiguration();
                section.Bind(tokenConfig);
                return tokenConfig;
            }).SingleInstance();
            
            builder.Register(x =>
            {
                var configuration = x.Resolve<IConfiguration>();
                var section = configuration.GetSection("adminConfig");
                var adminConfig = new AdminConfiguration();
                section.Bind(adminConfig);
                return adminConfig;
            }).SingleInstance();

        }
    }
}
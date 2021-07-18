using Autofac;
using MediAR.Modules.Membership.Core.Configurations;
using MediAR.Modules.Membership.Core.DAL;
using MediAR.Modules.Membership.Core.Services;

namespace MediAR.Modules.Membership.Core
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new DALModule());

            builder.RegisterModule(new ServiceModule());

            builder.RegisterModule(new ConfigurationModule());

        }
    }
}
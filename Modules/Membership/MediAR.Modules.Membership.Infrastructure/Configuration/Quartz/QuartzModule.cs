using Autofac;
using Quartz;

namespace MediAR.Modules.Membership.Infrastructure.Configuration.Quartz
{
    public class QuartzModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(x => typeof(IJob).IsAssignableTo(x))
                .InstancePerLifetimeScope();
        }
    }
}
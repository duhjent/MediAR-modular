using Autofac;

namespace MediAR.Modules.Membership.Api
{
    public class MembershipModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = GetType().Assembly;

            // builder.RegisterAssemblyTypes(assembly)
            //     .
        }
    }
}
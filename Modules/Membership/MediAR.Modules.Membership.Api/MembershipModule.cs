using Autofac;
using MediAR.Modules.Membership.Api.Configuration.Authorization;
using MediAR.Modules.Membership.Core;
using Microsoft.AspNetCore.Authorization;

namespace MediAR.Modules.Membership.Api
{
    public class MembershipModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new CoreModule());
        
            builder.RegisterType<HasRoleAttributeAuthorizationHandler>()
                .As<IAuthorizationHandler>()
                .InstancePerLifetimeScope();
        }
    }
}
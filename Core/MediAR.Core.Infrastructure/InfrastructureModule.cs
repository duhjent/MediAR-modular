using Autofac;
using MediAR.Core.Infrastructure.Middleware;

namespace MediAR.Core.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ErrorHandlerMiddleware>()
                .SingleInstance();
        }
    }
}
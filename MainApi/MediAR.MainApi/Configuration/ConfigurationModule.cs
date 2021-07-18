using Autofac;
using MediAR.Core.Contracts.Configuration;
using MediAR.MainApi.Configuration.Exceptions;
using Microsoft.AspNetCore.Http;

namespace MediAR.MainApi.Configuration
{
    public class ConfigurationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ErrorHandlerMiddleware>()
                .SingleInstance();

            builder.RegisterType<HttpContextAccessor>()
                .As<IHttpContextAccessor>()
                .SingleInstance();

            builder.RegisterType<ExecutionContextAccessor>()
                .As<IExecutionContextAccessor>()
                .InstancePerLifetimeScope();
        }
    }
}
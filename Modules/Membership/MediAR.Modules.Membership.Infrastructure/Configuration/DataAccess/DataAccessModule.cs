using Autofac;
using MediAR.Core.Application.Data;
using MediAR.Core.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MediAR.Modules.Membership.Infrastructure.Configuration.DataAccess
{
    internal class DataAccessModule : Module
    {
        private readonly string _connectionString;

        public DataAccessModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SqlConnectionFactory>()
                .As<ISqlConnectionFactory>()
                .WithParameter("connectionString", _connectionString)
                .InstancePerLifetimeScope();

            builder.Register(c =>
            {
                var dbCtxOptionsBuilder = new DbContextOptionsBuilder<MembershipContext>();

                dbCtxOptionsBuilder.UseSqlServer(_connectionString);

                return new MembershipContext(dbCtxOptionsBuilder.Options);
            });
            
            var infrastructureAssembly = ThisAssembly;

            builder.RegisterAssemblyTypes(infrastructureAssembly)
                .Where(type => type.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .FindConstructorsWith(new AllConstructorFinder());

        }
    }
}
using Microsoft.Extensions.Configuration;

namespace MediAR.Core.Infrastructure.DAL
{
    public static class SqlServerConfigFactory
    {
        public static SqlServerConfig GetConfig()
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json");
            var configuration = configurationBuilder.Build();

            var section = configuration.GetSection("sqlConfig");
            var sqlConfig = new SqlServerConfig();
            section.Bind(sqlConfig);

            return sqlConfig;
        }
    }
}
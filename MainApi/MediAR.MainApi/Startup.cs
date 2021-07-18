using System.Text;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MediAR.Core.Infrastructure;
using MediAR.Core.Infrastructure.Authorization;
using MediAR.MainApi.Configuration;
using MediAR.MainApi.Configuration.Exceptions;
using MediAR.Modules.Membership.Api;
using MediAR.Modules.Membership.Core.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace MediAR.MainApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; private set; }
        public ILifetimeScope AutofacContainer { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddControllers().ConfigureApplicationPartManager(setupAction =>
            {
                setupAction.FeatureProviders.Add(new InternalControllerFeatureProvider());
            });

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, config =>
                {
                    var section = Configuration.GetSection("tokenConfig");
                    var jwtConfig = new TokenConfiguration();
                    section.Bind(jwtConfig);
                    config.SaveToken = true;
                    config.MapInboundClaims = false;
                    config.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.JwtSecret)),
                        ValidateIssuer = true,
                        ValidIssuer = jwtConfig.JwtIssuer,
                        ValidateAudience = true,
                        ValidAudience = jwtConfig.JwtAudience,
                    };
                });
            
            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                options.AddPolicy(HasRoleAttribute.HasRolePolicyName, policyBuilder =>
                {
                    policyBuilder.Requirements.Add(new HasRoleAuthorizationRequirement());
                    policyBuilder.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
                });
            });

        }
        
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new InfrastructureModule());
            builder.RegisterModule(new ConfigurationModule());
            builder.RegisterModule(new MembershipModule());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            app.UseMiddleware<ErrorHandlerMiddleware>();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
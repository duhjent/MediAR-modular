using Autofac;
using Autofac.Extensions.DependencyInjection;
using MediAR.Core.Infrastructure.Api;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
        }
        
        public void ConfigureContainer(ContainerBuilder builder)
        {
            // builder.RegisterModule(new MyApplicationModule());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
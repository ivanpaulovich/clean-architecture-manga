using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApi.DependencyInjection;
using WebApi.DependencyInjection.FeatureFlags;

namespace WebApi
{
    public sealed class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            services.AddControllers().AddControllersAsServices();
            services.AddBusinessExceptionFilter();
            services.AddFeatureFlags(Configuration);
            services.AddVersioning();
            services.AddSwagger();
            services.AddUseCases();
            services.AddInMemoryPersistence();
            services.AddPresentersV1();
            services.AddPresentersV2();
            services.AddMediator();
        }

        public void ConfigureProductionServices(IServiceCollection services)
        {
            services.AddControllers().AddControllersAsServices();
            services.AddBusinessExceptionFilter();
            services.AddFeatureFlags(Configuration);
            services.AddVersioning();
            services.AddSwagger();
            services.AddUseCases();
            services.AddSQLServerPersistence(Configuration);
            services.AddPresentersV1();
            services.AddPresentersV2();
            services.AddMediator();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseVersionedSwagger(provider);
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
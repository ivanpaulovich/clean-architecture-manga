using Application.Services;
using Infrastructure.InMemoryDataAccess.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

#region Called for ASPNETCORE_ENVIRONMENT=Development

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
            services.AddSingleton<IUserService, TestUserService>();
        }

        public void ConfigureDevelopment(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            IApiVersionDescriptionProvider provider)
        {
            app.UseDeveloperExceptionPage();
            app.UseRouting();
            app.UseVersionedSwagger(provider);
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints
                    .MapControllers();
            });
        }

#endregion

#region Called for ASPNETCORE_ENVIRONMENT=Production

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
            services.AddHttpContextAccessor();
            services.AddGitHubAuthentication(Configuration);
        }

        public void ConfigureProduction(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            IApiVersionDescriptionProvider provider)
        {
            app.UseRouting();
            app.UseVersionedSwagger(provider);
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCookiePolicy();
            app.UseEndpoints(endpoints =>
            {
                endpoints
                    .MapControllers()
                    .RequireAuthorization();
            });
        }

#endregion

    }
}
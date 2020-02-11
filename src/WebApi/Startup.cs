namespace WebApi
{
    using DependencyInjection;
    using DependencyInjection.FeatureFlags;
    using Domain.Security.Services;
    using Infrastructure.InMemoryDataAccess.Services;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.ApiExplorer;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Prometheus;

    public sealed class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        #region Called for ASPNETCORE_ENVIRONMENT=Development

        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            services.AddControllers().AddControllersAsServices();
            services.AddBusinessExceptionFilter();
            services.AddFeatureFlags(this.Configuration);
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
            app.UseHttpsRedirection();
            app.UseMetricServer();
            app.UseMangaHttpMetrics();
            app.UseDeveloperExceptionPage();
            app.UseRouting();
            app.UseVersionedSwagger(provider);
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
            services.AddFeatureFlags(this.Configuration);
            services.AddVersioning();
            services.AddSwagger();
            services.AddUseCases();
            services.AddSQLServerPersistence(this.Configuration);
            services.AddPresentersV1();
            services.AddPresentersV2();
            services.AddMediator();
            services.AddHttpContextAccessor();
            services.AddGitHubAuthentication(this.Configuration);
        }

        public void ConfigureProduction(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            IApiVersionDescriptionProvider provider)
        {
            app.UseHttpsRedirection();
            app.UseMetricServer();
            app.UseMangaHttpMetrics();
            app.UseRouting();
            app.UseVersionedSwagger(provider);
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

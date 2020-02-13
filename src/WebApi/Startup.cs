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
    using Microsoft.Extensions.Hosting;
    using Prometheus;

    public sealed class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            this.Configuration = configuration;
            this.Env = env;
        }

        private IConfiguration Configuration { get; }
        private IWebHostEnvironment Env { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            if (this.Env.IsDevelopment())
            {
                services.AddInMemoryPersistence();
                services.AddSingleton<IUserService, TestUserService>();
            }

            if (this.Env.IsProduction())
            {
                services.AddSQLServerPersistence(this.Configuration);
                services.AddGitHubAuthentication(this.Configuration);
            }

            services.AddControllers().AddControllersAsServices();
            services.AddBusinessExceptionFilter();
            services.AddFeatureFlags(this.Configuration);
            services.AddVersioning();
            services.AddSwagger();
            services.AddUseCases();
            services.AddPresentersV1();
            services.AddPresentersV2();
            services.AddMediator();
            services.AddHttpContextAccessor();
        }

        public void Configure(
            IApplicationBuilder app,
            IApiVersionDescriptionProvider provider)
        {
            if (this.Env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseMetricServer();
            app.UseMangaHttpMetrics();
            app.UseRouting();
            app.UseVersionedSwagger(provider);
            app.UseStaticFiles();

            if (this.Env.IsProduction())
            {
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

            if (this.Env.IsDevelopment())
            {
                app.UseEndpoints(endpoints =>
                {
                    endpoints
                        .MapControllers();
                });
            }
        }
    }
}

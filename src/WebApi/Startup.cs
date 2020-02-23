namespace WebApi
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.ApiExplorer;
    using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Modules;
    using Modules.FeatureFlags;
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
            services.AddPersistence(this.Configuration);
            services.AddAuthentication(this.Configuration);
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
            services.AddControllersWithViews();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        public void Configure(
            IApplicationBuilder app,
            IApiVersionDescriptionProvider provider)
        {
            if (this.Env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
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

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (this.Env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}

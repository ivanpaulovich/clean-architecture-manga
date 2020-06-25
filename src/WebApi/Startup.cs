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
    using Modules.Common;
    using Modules.Common.FeatureFlags;
    using Modules.Common.Swagger;
    using Prometheus;

    /// <summary>
    ///     Startup.
    /// </summary>
    public sealed class Startup
    {
        /// <summary>
        ///     Startup constructor.
        /// </summary>
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        private IConfiguration Configuration { get; }

        /// <summary>
        ///     Configure dependencies from application.
        /// </summary>
        public void ConfigureServices(IServiceCollection services) => services
            .AddCurrencyExchange(this.Configuration)
            .AddPersistence(this.Configuration)
            .AddAuthentication(this.Configuration)
            .AddFeatureFlags(this.Configuration)
            .AddVersioning()
            .AddSwagger()
            .AddMediator()
            .AddUseCases()
            .AddPresentersV1()
            .AddPresentersV2()
            .AddCustomControllers()
            .AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/build"; });

        /// <summary>
        ///     Configure http request pipeline.
        /// </summary>
        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/api/V1/CustomError")
                    .UseHsts();
            }

            app.UseSpaStaticFiles();

            app.UseHttpsRedirection()
                .UseStaticFiles()
                .UseMetricServer()
                .UseMangaHttpMetrics()
                .UseRouting()
                .UseVersionedSwagger(provider, this.Configuration)
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints => { endpoints.MapControllers(); })
                .UseSpa(spa =>
                {
                    spa.Options.SourcePath = "ClientApp";
                    if (env.IsDevelopment())
                    {
                        spa.UseReactDevelopmentServer("start");
                    }
                });
        }
    }
}

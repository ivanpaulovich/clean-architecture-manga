namespace WebApi
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.ApiExplorer;
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
        public void ConfigureServices(IServiceCollection services) =>
            services
                .AddFeatureFlags(this.Configuration) // should be the first one.
                .AddInvalidRequestLogging()
                .AddCurrencyExchange(this.Configuration)
                .AddSQLServer(this.Configuration)
                .AddHealthChecks(this.Configuration)
                .AddAuthentication(this.Configuration)
                .AddVersioning()
                .AddSwagger()
                .AddUseCases()
                .AddCustomControllers()
                .AddCustomCors()
                .AddProxy()
                .AddCustomDataProtection();

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

            app
                .UseProxy(this.Configuration)
                .UseHealthChecks()
                .UseCustomCors()
                .UseCustomHttpMetrics()
                .UseRouting()
                .UseVersionedSwagger(provider, this.Configuration, env)
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                    endpoints.MapMetrics();
                });
        }
    }
}

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
    using Microsoft.AspNetCore.HttpOverrides;
    using Microsoft.AspNetCore.DataProtection;
    using Microsoft.AspNetCore.Http;

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
        public void ConfigureServices(IServiceCollection services)
        {
            services
            .AddCurrencyExchange(this.Configuration)
            .AddPersistence(this.Configuration)
            .AddHealthChecks(this.Configuration)
            .AddAuthentication(this.Configuration)
            .AddFeatureFlags(this.Configuration)
            .AddVersioning()
            .AddSwagger()
            .AddUseCases()
            .AddCustomControllers()
            .AddCustomCors();

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });

            services.AddDataProtection()
                .SetApplicationName("accounts-api")
                .PersistKeysToFileSystem(new System.IO.DirectoryInfo(@"./"));

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
        }

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

            app.Use((context, next) =>
            {
                context.Request.PathBase = new PathString("/accounts-api");
                return next();
            });

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app
                .UseHealthChecks()
                .UseHttpsRedirection()
                .UseCustomCors()
                .UseCustomHttpMetrics()
                .UseRouting()
                .UseVersionedSwagger(provider, this.Configuration)
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}

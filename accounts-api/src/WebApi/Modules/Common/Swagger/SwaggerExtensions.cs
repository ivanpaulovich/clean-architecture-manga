namespace WebApi.Modules.Common.Swagger
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.ApiExplorer;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Options;
    using Microsoft.Extensions.PlatformAbstractions;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.SwaggerGen;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Reflection;

    /// <summary>
    ///     Swagger Extensions.
    /// </summary>
    public static class SwaggerExtensions
    {
        private static string XmlCommentsFilePath
        {
            get
            {
                string basePath = PlatformServices.Default.Application.ApplicationBasePath;
                string fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
                return Path.Combine(basePath, fileName);
            }
        }


        /// <summary>
        ///     Add Swagger Configuration dependencies.
        /// </summary>
        [SuppressMessage("Minor Code Smell", "S1075:URIs should not be hardcoded", Justification = "<Pending>")]
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            _ = services.AddSwaggerGen(
                c =>
                {
                    c.IncludeXmlComments(XmlCommentsFilePath);
                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description = "Please insert JWT with Bearer into field",
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey
                    });
                    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                        },
                        new string[] { }
                    }
                    });
                });

            return services;
        }

        /// <summary>
        ///     Add Swagger dependencies.
        /// </summary>
        public static IApplicationBuilder UseVersionedSwagger(
            this IApplicationBuilder app,
            IApiVersionDescriptionProvider provider,
            IConfiguration configuration,
            IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    foreach (ApiVersionDescription description in provider.ApiVersionDescriptions)
                    {
                        string swaggerEndpoint;

                        string basePath = configuration["ASPNETCORE_BASEPATH"];

                        if (!string.IsNullOrEmpty(basePath))
                        {
                            swaggerEndpoint = $"{basePath}/swagger/{description.GroupName}/swagger.json";
                        }
                        else
                        {
                            swaggerEndpoint = $"/swagger/{description.GroupName}/swagger.json";
                        }

                        options.SwaggerEndpoint(swaggerEndpoint, description.GroupName.ToUpperInvariant());
                    }
                });

            return app;
        }
    }
}

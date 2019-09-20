namespace Manga.WebApi.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Manga.WebApi.Filters;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Mvc.ApiExplorer;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using Swashbuckle.AspNetCore.SwaggerGen;
    using Microsoft.OpenApi.Models;
    using System;

    public static class VersionedSwaggerExtensions
    {
        public static IServiceCollection AddVersionedSwagger(this IServiceCollection services)
        {
            services.AddApiVersioning(o =>
            {
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });

            services.AddVersionedApiExplorer(o => o.GroupNameFormat = "'V'VVV");

            services.AddSwaggerGen(options =>
            {
                var provider = services.BuildServiceProvider()
                    .GetRequiredService<IApiVersionDescriptionProvider>();

                foreach (var apiVersion in provider.ApiVersionDescriptions)
                {
                    ConfigureVersionedDescription(options, apiVersion);
                }

                var xmlCommentsPath = Assembly.GetExecutingAssembly()
                    .Location.Replace("dll", "xml");
                options.IncludeXmlComments(xmlCommentsPath);

                options.DocumentFilter<SwaggerDocumentFilter>();
            });

            return services;
        }

        private static void ConfigureVersionedDescription(
            SwaggerGenOptions options,
            ApiVersionDescription apiVersion)
        {
            var dictionairy = new Dictionary<string, string>
                { { "1.0", "This API features several endpoints showing different API features for API version V1" },
                    { "2.0", "This API features several endpoints showing different API features for API version V2" }
                };

            var apiVersionName = apiVersion.ApiVersion.ToString();
            options.SwaggerDoc(apiVersion.GroupName,
                new OpenApiInfo()
                {
                    Title = "Clean Architecture Manga",
                        Contact = new OpenApiContact()
                        {
                            Name = "@ivanpaulovich",
                                Email = "ivan@paulovich.net",
                                Url = new Uri("https://github.com/ivanpaulovich")
                        },
                        License = new OpenApiLicense()
                        {
                            Name = "Apache License"
                        },
                        Version = apiVersionName,
                        Description = dictionairy[apiVersionName]
                });
        }

        public static IApplicationBuilder UseVersionedSwagger(
            this IApplicationBuilder app,
            IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger(options =>
            {
                options.PreSerializeFilters.Add((swaggerDoc, httpRequest) =>
                {
                    if (httpRequest.Path.Value.Contains("/swagger"))
                    {
                        swaggerDoc.Servers = new List<OpenApiServer>()
                        {
                            new OpenApiServer
                            {
                                Url = httpRequest.Path.Value.Split("/").FirstOrDefault() ?? ""
                            }
                        };
                    }

                    if (httpRequest.Headers.TryGetValue("X-Forwarded-Prefix", out var xForwardedPrefix))
                    {
                        swaggerDoc.Servers = new List<OpenApiServer>()
                        {
                            new OpenApiServer
                            {
                                Url = xForwardedPrefix[0]
                            }
                        };
                    }
                });
            });

            app.UseSwaggerUI(options =>
            {
                // build a swagger endpoint for each discovered API version
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }
            });

            return app;
        }
    }
}
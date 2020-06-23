namespace WebApi.Modules.Common.Swagger
{
    using System;
    using System.IO;
    using System.Reflection;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Mvc.ApiExplorer;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using Microsoft.Extensions.PlatformAbstractions;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.SwaggerGen;

    /// <summary>
    ///     Swagger Extenions.
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
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(
                c =>
                {
                    c.IncludeXmlComments(XmlCommentsFilePath);
                    c.OperationFilter<SecurityRequirementsOperationFilter>();

                    c.AddSecurityDefinition("oauth2",
                        new OpenApiSecurityScheme
                        {
                            Type = SecuritySchemeType.OAuth2,
                            Flows = new OpenApiOAuthFlows
                            {
                                Implicit = new OpenApiOAuthFlow
                                {
                                    TokenUrl = new Uri("https://www.googleapis.com/oauth2/v4/token"),
                                    AuthorizationUrl =
                                        new Uri("https://accounts.google.com/o/oauth2/v2/auth"),
                                    Scopes = {{"openid", "OpenID"}, {"profile", "Profile"}, {"email", "E-mail"}}
                                }
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
            IConfiguration configuration)
        {
            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    foreach (ApiVersionDescription description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                            description.GroupName.ToUpperInvariant());
                    }

                    options.OAuthClientId(configuration["AuthenticationModule:Google:ClientId"]);
                    options.OAuthClientSecret(configuration["AuthenticationModule:Google:ClientSecret"]);
                });

            return app;
        }
    }
}

namespace WebApi.Modules.Common.Swagger
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.SwaggerGen;

    /// <summary>
    ///     The Security Requirements Operation Filter class.
    /// </summary>
    public sealed class SecurityRequirementsOperationFilter : IOperationFilter
    {
        /// <summary>
        ///     Apply filters.
        /// </summary>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            // Policy names map to scopes
            IEnumerable<string> requiredScopes = context.MethodInfo
                .GetCustomAttributes(true)
                .OfType<AuthorizeAttribute>()
                .Select(attr => attr.Policy)
                .Distinct();

            if (!requiredScopes.Any())
            {
                return;
            }

            operation.Responses.Add("401", new OpenApiResponse {Description = "Unauthorized"});
            operation.Responses.Add("403", new OpenApiResponse {Description = "Forbidden"});

            var oAuthScheme = new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id = "oauth2"}
            };

            operation.Security = new List<OpenApiSecurityRequirement>
            {
                new OpenApiSecurityRequirement {[oAuthScheme] = requiredScopes.ToList()}
            };
        }
    }
}

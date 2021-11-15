using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer.Modules.Common;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
///     CORS Extensions.
/// </summary>
public static class CustomCorsExtensions
{
    private const string AllowsAny = "_allowsAny";

    /// <summary>
    ///     Add CORS.
    /// </summary>
    public static IServiceCollection AddCustomCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(AllowsAny,
                builder =>
                {
                    // Not a permanent solution, but just trying to isolate the problem
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
        });


        return services;
    }

    /// <summary>
    ///     Use CORS.
    /// </summary>
    public static IApplicationBuilder UseCustomCors(this IApplicationBuilder app)
    {
        app.UseCors(AllowsAny);
        return app;
    }
}

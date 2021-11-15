using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer.Modules.Common;

using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
///     Reverse Proxy Extensions.
/// </summary>
public static class ReverseProxyExtensions
{
    /// <summary>
    ///     Add Proxy.
    /// </summary>
    public static IServiceCollection AddProxy(this IServiceCollection services)
    {
        services.Configure<ForwardedHeadersOptions>(options =>
        {
            options.ForwardedHeaders =
                ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
        });

        return services;
    }

    /// <summary>
    ///     Use Proxy.
    /// </summary>
    public static IApplicationBuilder UseProxy(this IApplicationBuilder app, IConfiguration configuration)
    {
        var identityServerOrigin = configuration["IDENTITY_SERVER_ORIGIN"];
        var basePath = configuration["ASPNETCORE_BASEPATH"];

        if (!string.IsNullOrEmpty(identityServerOrigin))
            app.Use(async (context, next) =>
            {
                context.SetIdentityServerOrigin(identityServerOrigin);
                context.Request.PathBase = basePath;

                await next.Invoke()
                    .ConfigureAwait(false);
            });

        app.UseForwardedHeaders(new ForwardedHeadersOptions { ForwardedHeaders = ForwardedHeaders.All });

        return app;
    }
}

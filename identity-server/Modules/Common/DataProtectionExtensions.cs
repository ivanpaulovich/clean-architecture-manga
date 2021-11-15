using System.IO;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer.Modules.Common;

using System.IO;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
///     Data Protection Extensions.
/// </summary>
public static class DataProtectionExtensions
{
    /// <summary>
    ///     Add Data Protection.
    /// </summary>
    public static IServiceCollection AddCustomDataProtection(this IServiceCollection services)
    {
        services.AddDataProtection()
            .SetApplicationName("identity-server")
            .PersistKeysToFileSystem(new DirectoryInfo(@"./"));

        return services;
    }
}

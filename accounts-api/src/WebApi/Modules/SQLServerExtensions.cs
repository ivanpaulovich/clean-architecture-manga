namespace WebApi.Modules;

using Application.Services;
using Common.FeatureFlags;
using Domain;
using Infrastructure.DataAccess;
using Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;

/// <summary>
///     Persistence Extensions.
/// </summary>
#pragma warning disable S101 // Types should be named in PascalCase
public static class SQLServerExtensions
#pragma warning restore S101 // Types should be named in PascalCase
{
    /// <summary>
    ///     Add Persistence dependencies varying on configuration.
    /// </summary>
    public static IServiceCollection AddSQLServer(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        IFeatureManager featureManager = services
            .BuildServiceProvider()
            .GetRequiredService<IFeatureManager>();

        bool isEnabled = featureManager
            .IsEnabledAsync(nameof(CustomFeature.SQLServer))
            .ConfigureAwait(false)
            .GetAwaiter()
            .GetResult();

        if (isEnabled)
        {
            services.AddDbContext<MangaContext>(
                options => options.UseSqlServer(
                    configuration.GetValue<string>("PersistenceModule:DefaultConnection")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IAccountRepository, AccountRepository>();
        }
        else
        {
            services.AddSingleton<MangaContextFake, MangaContextFake>();
            services.AddScoped<IUnitOfWork, UnitOfWorkFake>();
            services.AddScoped<IAccountRepository, AccountRepositoryFake>();
        }

        services.AddScoped<IAccountFactory, EntityFactory>();

        return services;
    }
}

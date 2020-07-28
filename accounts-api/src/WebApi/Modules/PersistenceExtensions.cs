namespace WebApi.Modules
{
    using Application.Services;
    using Domain;
    using Infrastructure.DataAccess;
    using Infrastructure.DataAccess.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    ///     Persistence Extensions.
    /// </summary>
    public static class PersistenceExtensions
    {
        /// <summary>
        ///     Add Persistence dependencies varying on configuration.
        /// </summary>
        public static IServiceCollection AddPersistence(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            bool useFake = configuration.GetValue<bool>("PersistenceModule:UseFake");
            if (useFake)
            {
                services.AddSingleton<MangaContextFake, MangaContextFake>();
                services.AddScoped<IUnitOfWork, UnitOfWorkFake>();
                services.AddScoped<IAccountRepository, AccountRepositoryFake>();
            }
            else
            {
                services.AddDbContext<MangaContext>(
                    options => options.UseSqlServer(
                        configuration.GetValue<string>("PersistenceModule:DefaultConnection")));
                services.AddScoped<IUnitOfWork, UnitOfWork>();

                services.AddScoped<IAccountRepository, AccountRepository>();
            }

            services.AddScoped<IAccountFactory, EntityFactory>();

            return services;
        }
    }
}

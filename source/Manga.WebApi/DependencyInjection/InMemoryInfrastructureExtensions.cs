namespace Manga.WebApi.DependencyInjection
{
    using Manga.Application.Repositories;
    using Manga.Application.Services;
    using Manga.Domain;
    using Manga.Infrastructure.InMemoryDataAccess.Repositories;
    using Manga.Infrastructure.InMemoryDataAccess;
    using Microsoft.Extensions.DependencyInjection;

    public static class InMemoryInfrastructureExtensions
    {
        public static IServiceCollection AddInMemoryPersistence(this IServiceCollection services)
        {
            services.AddScoped<IEntityFactory, EntityFactory>();

            services.AddSingleton<MangaContext, MangaContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}
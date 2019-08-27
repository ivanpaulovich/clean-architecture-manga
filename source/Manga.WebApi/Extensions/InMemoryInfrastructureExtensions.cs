namespace Manga.WebApi.Extensions
{
    using Manga.Application.Repositories;
    using Manga.Application.Services;
    using Manga.Domain;
    using Manga.Infrastructure.InMemoryGateway.Repositories;
    using Manga.Infrastructure.InMemoryGateway;
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
namespace WebApi.DependencyInjection
{
    using Application.Repositories;
    using Application.Services;
    using Infrastructure.InMemoryDataAccess.Repositories;
    using Infrastructure.InMemoryDataAccess;
    using Microsoft.Extensions.DependencyInjection;
    using Domain;

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
namespace WebApi.DependencyInjection
{
    using Application.Services;
    using Domain.Accounts;
    using Domain.Customers;
    using Domain.Security;
    using Infrastructure.InMemoryDataAccess;
    using Infrastructure.InMemoryDataAccess.Repositories;
    using Microsoft.Extensions.DependencyInjection;

    public static class InMemoryInfrastructureExtensions
    {
        public static IServiceCollection AddInMemoryPersistence(this IServiceCollection services)
        {
            services.AddScoped<IUserFactory, EntityFactory>();
            services.AddScoped<ICustomerFactory, EntityFactory>();
            services.AddScoped<IAccountFactory, EntityFactory>();

            services.AddSingleton<MangaContext, MangaContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}

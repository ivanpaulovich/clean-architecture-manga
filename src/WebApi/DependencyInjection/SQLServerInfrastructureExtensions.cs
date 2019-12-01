namespace WebApi.DependencyInjection
{
    using Application.Services;
    using Domain.Accounts;
    using Domain.Customers;
    using Domain.Security;
    using Infrastructure.EntityFrameworkDataAccess;
    using Infrastructure.EntityFrameworkDataAccess.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class SQLServerInfrastructureExtensions
    {
        public static IServiceCollection AddSQLServerPersistence(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<IUserFactory, EntityFactory>();
            services.AddScoped<ICustomerFactory, EntityFactory>();
            services.AddScoped<IAccountFactory, EntityFactory>();

            services.AddDbContext<MangaContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}

namespace WebApi.Modules
{
    using Application.Services;
    using Domain.Accounts;
    using Domain.Customers;
    using Domain.Security;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class PersistenceExtensions
    {
        public static IServiceCollection AddPersistence(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            bool useFake = configuration.GetValue<bool>("PersistenceModule:UseFake");
            if (useFake)
            {
                services.AddScoped<IUserFactory, Infrastructure.InMemoryDataAccess.EntityFactory>();
                services.AddScoped<ICustomerFactory, Infrastructure.InMemoryDataAccess.EntityFactory>();
                services.AddScoped<IAccountFactory, Infrastructure.InMemoryDataAccess.EntityFactory>();

                services.AddSingleton<Infrastructure.InMemoryDataAccess.MangaContext, Infrastructure.InMemoryDataAccess.MangaContext>();
                services.AddScoped<IUnitOfWork, Infrastructure.InMemoryDataAccess.UnitOfWork>();

                services.AddScoped<IAccountRepository, Infrastructure.InMemoryDataAccess.Repositories.AccountRepository>();
                services.AddScoped<ICustomerRepository, Infrastructure.InMemoryDataAccess.Repositories.CustomerRepository>();
                services.AddScoped<IUserRepository, Infrastructure.InMemoryDataAccess.Repositories.UserRepository>();
            }
            else
            {
                services.AddScoped<IUserFactory, Infrastructure.EntityFrameworkDataAccess.EntityFactory>();
                services.AddScoped<ICustomerFactory, Infrastructure.EntityFrameworkDataAccess.EntityFactory>();
                services.AddScoped<IAccountFactory, Infrastructure.EntityFrameworkDataAccess.EntityFactory>();

                services.AddDbContext<Infrastructure.EntityFrameworkDataAccess.MangaContext>(
                    options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
                services.AddScoped<IUnitOfWork, Infrastructure.EntityFrameworkDataAccess.UnitOfWork>();

                services.AddScoped<IAccountRepository, Infrastructure.EntityFrameworkDataAccess.Repositories.AccountRepository>();
                services.AddScoped<ICustomerRepository, Infrastructure.EntityFrameworkDataAccess.Repositories.CustomerRepository>();
            }

            return services;
        }
    }
}

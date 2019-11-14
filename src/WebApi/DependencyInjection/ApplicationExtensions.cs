namespace WebApi.DependencyInjection
{
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<Application.Boundaries.Authenticate.IUseCase, Application.UseCases.Authenticate>();
            services.AddScoped<Application.Boundaries.CloseAccount.IUseCase, Application.UseCases.CloseAccount>();
            services.AddScoped<Application.Boundaries.Deposit.IUseCase, Application.UseCases.Deposit>();
            services.AddScoped<Application.Boundaries.GetAccountDetails.IUseCase, Application.UseCases.GetAccountDetails>();
            services.AddScoped<Application.Boundaries.GetCustomerDetails.IUseCase, Application.UseCases.GetCustomerDetails>();
            services.AddScoped<Application.Boundaries.RegisterCustomer.IUseCase, Application.UseCases.RegisterCustomer>();
            services.AddScoped<Application.Boundaries.RegisterAccount.IUseCase, Application.UseCases.RegisterAccount>();
            services.AddScoped<Application.Boundaries.Withdraw.IUseCase, Application.UseCases.Withdraw>();
            services.AddScoped<Application.Boundaries.Transfer.IUseCase, Application.UseCases.Transfer>();

            return services;
        }
    }
}

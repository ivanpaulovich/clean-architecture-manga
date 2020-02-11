namespace WebApi.DependencyInjection
{
    using Domain.Accounts;
    using Domain.Customers;
    using Domain.Security;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Adds Use Cases classes.
    /// </summary>
    public static class ApplicationExtensions
    {
        /// <summary>
        /// Adds Use Cases to the ServiceCollection.
        /// </summary>
        /// <param name="services">Service Collection.</param>
        /// <returns>The modified instance.</returns>
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<Application.Boundaries.CloseAccount.IUseCase, Application.UseCases.CloseAccountUseCase>();
            services.AddScoped<Application.Boundaries.Deposit.IUseCase, Application.UseCases.DepositUseCase>();
            services.AddScoped<Application.Boundaries.GetAccountDetails.IUseCase, Application.UseCases.GetAccountDetailsUseCase>();
            services.AddScoped<Application.Boundaries.GetCustomerDetails.IUseCase, Application.UseCases.GetCustomerDetailsUseCase>();
            services.AddScoped<Application.Boundaries.Register.IUseCase, Application.UseCases.RegisterUseCase>();
            services.AddScoped<Application.Boundaries.Withdraw.IUseCase, Application.UseCases.WithdrawUseCase>();
            services.AddScoped<Application.Boundaries.Transfer.IUseCase, Application.UseCases.TransferUseCase>();
            services.AddScoped<CustomerService>();
            services.AddScoped<SecurityService>();
            services.AddScoped<AccountService>();

            return services;
        }
    }
}

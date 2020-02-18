namespace WebApi.Modules
{
    using Application.UseCases;
    using Domain.Accounts;
    using Domain.Customers;
    using Domain.Security;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    ///     Adds Use Cases classes.
    /// </summary>
    public static class ApplicationExtensions
    {
        /// <summary>
        ///     Adds Use Cases to the ServiceCollection.
        /// </summary>
        /// <param name="services">Service Collection.</param>
        /// <returns>The modified instance.</returns>
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<Application.Boundaries.CloseAccount.IUseCase, CloseAccountUseCase>();
            services.AddScoped<Application.Boundaries.Deposit.IUseCase, DepositUseCase>();
            services.AddScoped<Application.Boundaries.GetAccountDetails.IUseCase, GetAccountDetailsUseCase>();
            services.AddScoped<Application.Boundaries.GetCustomerDetails.IUseCase, GetCustomerDetailsUseCase>();
            services.AddScoped<Application.Boundaries.Register.IUseCase, RegisterUseCase>();
            services.AddScoped<Application.Boundaries.Withdraw.IUseCase, WithdrawUseCase>();
            services.AddScoped<Application.Boundaries.Transfer.IUseCase, TransferUseCase>();

            services.AddScoped<CustomerService>();
            services.AddScoped<SecurityService>();
            services.AddScoped<AccountService>();

            return services;
        }
    }
}

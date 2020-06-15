namespace WebApi.Modules
{
    using Application.Boundaries.CloseAccount;
    using Application.Boundaries.Deposit;
    using Application.Boundaries.GetAccount;
    using Application.Boundaries.GetAccounts;
    using Application.Boundaries.GetCustomer;
    using Application.Boundaries.Register;
    using Application.Boundaries.Transfer;
    using Application.Boundaries.Withdraw;
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
            services.AddScoped<ICloseAccountUseCase, CloseAccountUseCase>();
            services.AddScoped<IDepositUseCase, DepositUseCase>();
            services.AddScoped<IGetAccountUseCase, GetAccountUseCase>();
            services.AddScoped<IGetAccountsUseCase, GetAccountsUseCase>();
            services.AddScoped<IGetCustomerUseCase, GetCustomerUseCase>();
            services.AddScoped<IRegisterUseCase, RegisterUseCase>();
            services.AddScoped<IWithdrawUseCase, WithdrawUseCase>();
            services.AddScoped<ITransferUseCase, TransferUseCase>();

            services.AddScoped<CustomerService>();
            services.AddScoped<SecurityService>();
            services.AddScoped<AccountService>();

            return services;
        }
    }
}

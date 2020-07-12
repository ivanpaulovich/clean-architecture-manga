namespace WebApi.Modules
{
    using Application.UseCases.CloseAccount;
    using Application.UseCases.Deposit;
    using Application.UseCases.GetAccount;
    using Application.UseCases.GetAccounts;
    using Application.UseCases.GetCustomer;
    using Application.UseCases.OnBoardCustomer;
    using Application.UseCases.OpenAccount;
    using Application.UseCases.SignUp;
    using Application.UseCases.Transfer;
    using Application.UseCases.UpdateCustomer;
    using Application.UseCases.Withdraw;
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
            services.AddScoped<IOnBoardCustomerUseCase, OnBoardCustomerUseCase>();
            services.AddScoped<IOpenAccountUseCase, OpenAccountUseCase>();
            services.AddScoped<ISignUpUseCase, SignUpUseCase>();
            services.AddScoped<ITransferUseCase, TransferUseCase>();
            services.AddScoped<IUpdateCustomerUseCase, UpdateCustomerUseCase>();
            services.AddScoped<IWithdrawUseCase, WithdrawUseCase>();

            return services;
        }
    }
}

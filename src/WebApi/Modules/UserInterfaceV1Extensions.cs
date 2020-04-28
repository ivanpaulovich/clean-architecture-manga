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
    using Microsoft.Extensions.DependencyInjection;
    using UseCases.V1.CloseAccount;
    using UseCases.V1.Deposit;
    using UseCases.V1.GetAccount;
    using UseCases.V1.GetAccounts;
    using UseCases.V1.GetCustomer;
    using UseCases.V1.Register;
    using UseCases.V1.Transfer;
    using UseCases.V1.Withdraw;

    public static class UserInterfaceV1Extensions
    {
        public static IServiceCollection AddPresentersV1(this IServiceCollection services)
        {
            services.AddScoped<CloseAccountGetAccountsPresenter, CloseAccountGetAccountsPresenter>();
            services.AddScoped<ICloseAccountGetAccountsOutputPort>(x => x.GetRequiredService<CloseAccountGetAccountsPresenter>());

            services.AddScoped<DepositGetAccountsPresenter, DepositGetAccountsPresenter>();
            services.AddScoped<IDepositGetAccountsOutputPort>(
                x => x.GetRequiredService<DepositGetAccountsPresenter>());

            services.AddScoped<GetAccountPresenter, GetAccountPresenter>();
            services.AddScoped<IGetAccountOutputPort>(x =>
                x.GetRequiredService<GetAccountPresenter>());

            services.AddScoped<GetAccountsPresenter, GetAccountsPresenter>();
            services.AddScoped<IGetAccountsOutputPort>(x =>
                x.GetRequiredService<GetAccountsPresenter>());

            services.AddScoped<GetCustomerDetailsPresenter, GetCustomerDetailsPresenter>();
            services.AddScoped<IGetCustomerOutputPort>(x =>
                x.GetRequiredService<GetCustomerDetailsPresenter>());

            services.AddScoped<RegisterPresenter, RegisterPresenter>();
            services.AddScoped<IRegisterOutputPort>(x =>
                x.GetRequiredService<RegisterPresenter>());

            services.AddScoped<WithdrawPresenter, WithdrawPresenter>();
            services.AddScoped<IWithdrawOutputPort>(x =>
                x.GetRequiredService<WithdrawPresenter>());

            services.AddScoped<TransferPresenter, TransferPresenter>();
            services.AddScoped<ITransferOutputPort>(x =>
                x.GetRequiredService<TransferPresenter>());

            return services;
        }
    }
}

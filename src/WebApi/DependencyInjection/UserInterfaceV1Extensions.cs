namespace WebApi.DependencyInjection
{
    using Microsoft.Extensions.DependencyInjection;
    using UseCases.V1.Authenticate;
    using UseCases.V1.CloseAccount;
    using UseCases.V1.Deposit;
    using UseCases.V1.GetAccountDetails;
    using UseCases.V1.GetCustomerDetails;
    using UseCases.V1.RegisterAccount;
    using UseCases.V1.RegisterCustomer;
    using UseCases.V1.Transfer;
    using UseCases.V1.Withdraw;

    public static class UserInterfaceV1Extensions
    {
        public static IServiceCollection AddPresentersV1(this IServiceCollection services)
        {
            services.AddScoped<AuthenticatePresenter, AuthenticatePresenter>();
            services.AddScoped<Application.Boundaries.Authenticate.IOutputPort>(x => x.GetRequiredService<AuthenticatePresenter>());

            services.AddScoped<CloseAccountPresenter, CloseAccountPresenter>();
            services.AddScoped<Application.Boundaries.CloseAccount.IOutputPort>(x => x.GetRequiredService<CloseAccountPresenter>());

            services.AddScoped<DepositPresenter, DepositPresenter>();
            services.AddScoped<Application.Boundaries.Deposit.IOutputPort>(x => x.GetRequiredService<DepositPresenter>());

            services.AddScoped<GetAccountDetailsPresenter, GetAccountDetailsPresenter>();
            services.AddScoped<Application.Boundaries.GetAccountDetails.IOutputPort>(x => x.GetRequiredService<GetAccountDetailsPresenter>());

            services.AddScoped<GetCustomerDetailsPresenter, GetCustomerDetailsPresenter>();
            services.AddScoped<Application.Boundaries.GetCustomerDetails.IOutputPort>(x => x.GetRequiredService<GetCustomerDetailsPresenter>());

            services.AddScoped<RegisterAccountPresenter, RegisterAccountPresenter>();
            services.AddScoped<Application.Boundaries.RegisterAccount.IOutputPort>(x => x.GetRequiredService<RegisterAccountPresenter>());

            services.AddScoped<RegisterCustomerPresenter, RegisterCustomerPresenter>();
            services.AddScoped<Application.Boundaries.RegisterCustomer.IOutputPort>(x => x.GetRequiredService<RegisterCustomerPresenter>());

            services.AddScoped<WithdrawPresenter, WithdrawPresenter>();
            services.AddScoped<Application.Boundaries.Withdraw.IOutputPort>(x => x.GetRequiredService<WithdrawPresenter>());

            services.AddScoped<TransferPresenter, TransferPresenter>();
            services.AddScoped<Application.Boundaries.Transfer.IOutputPort>(x => x.GetRequiredService<TransferPresenter>());

            return services;
        }
    }
}

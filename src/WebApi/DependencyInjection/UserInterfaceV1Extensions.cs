namespace WebApi.DependencyInjection
{
    using Microsoft.Extensions.DependencyInjection;
    using WebApi.UseCases.V1.CloseAccount;
    using WebApi.UseCases.V1.Deposit;
    using WebApi.UseCases.V1.GetAccountDetails;
    using WebApi.UseCases.V1.GetCustomerDetails;
    using WebApi.UseCases.V1.Register;
    using WebApi.UseCases.V1.Transfer;
    using WebApi.UseCases.V1.Withdraw;

    public static class UserInterfaceV1Extensions
    {
        public static IServiceCollection AddPresentersV1(this IServiceCollection services)
        {
            services.AddScoped<CloseAccountPresenter, CloseAccountPresenter>();
            services.AddScoped<Application.Boundaries.CloseAccount.IOutputPort>(x => x.GetRequiredService<CloseAccountPresenter>());

            services.AddScoped<DepositPresenter, DepositPresenter>();
            services.AddScoped<Application.Boundaries.Deposit.IOutputPort>(x => x.GetRequiredService<DepositPresenter>());

            services.AddScoped<GetAccountDetailsPresenter, GetAccountDetailsPresenter>();
            services.AddScoped<Application.Boundaries.GetAccountDetails.IOutputPort>(x => x.GetRequiredService<GetAccountDetailsPresenter>());

            services.AddScoped<GetCustomerDetailsPresenter, GetCustomerDetailsPresenter>();
            services.AddScoped<Application.Boundaries.GetCustomerDetails.IOutputPort>(x => x.GetRequiredService<GetCustomerDetailsPresenter>());

            services.AddScoped<RegisterPresenter, RegisterPresenter>();
            services.AddScoped<Application.Boundaries.Register.IOutputPort>(x => x.GetRequiredService<RegisterPresenter>());

            services.AddScoped<WithdrawPresenter, WithdrawPresenter>();
            services.AddScoped<Application.Boundaries.Withdraw.IOutputPort>(x => x.GetRequiredService<WithdrawPresenter>());

            services.AddScoped<TransferPresenter, TransferPresenter>();
            services.AddScoped<Application.Boundaries.Transfer.IOutputPort>(x => x.GetRequiredService<TransferPresenter>());

            return services;
        }
    }
}
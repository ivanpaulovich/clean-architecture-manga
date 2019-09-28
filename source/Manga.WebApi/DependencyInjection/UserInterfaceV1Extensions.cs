namespace Manga.WebApi.DependencyInjection
{
    using Microsoft.Extensions.DependencyInjection;

    public static class UserInterfaceV1Extensions
    {
        public static IServiceCollection AddPresentersV1(this IServiceCollection services)
        {
            services.AddScoped<Manga.WebApi.UseCases.V1.CloseAccount.CloseAccountPresenter, Manga.WebApi.UseCases.V1.CloseAccount.CloseAccountPresenter>();
            services.AddScoped<Manga.Application.Boundaries.CloseAccount.IOutputPort>(x => x.GetRequiredService<Manga.WebApi.UseCases.V1.CloseAccount.CloseAccountPresenter>());

            services.AddScoped<Manga.WebApi.UseCases.V1.Deposit.DepositPresenter, Manga.WebApi.UseCases.V1.Deposit.DepositPresenter>();
            services.AddScoped<Manga.Application.Boundaries.Deposit.IOutputPort>(x => x.GetRequiredService<Manga.WebApi.UseCases.V1.Deposit.DepositPresenter>());

            services.AddScoped<Manga.WebApi.UseCases.V1.GetAccountDetails.GetAccountDetailsPresenter, Manga.WebApi.UseCases.V1.GetAccountDetails.GetAccountDetailsPresenter>();
            services.AddScoped<Manga.Application.Boundaries.GetAccountDetails.IOutputPort>(x => x.GetRequiredService<Manga.WebApi.UseCases.V1.GetAccountDetails.GetAccountDetailsPresenter>());

            services.AddScoped<Manga.WebApi.UseCases.V1.GetCustomerDetails.GetCustomerDetailsPresenter, Manga.WebApi.UseCases.V1.GetCustomerDetails.GetCustomerDetailsPresenter>();
            services.AddScoped<Manga.Application.Boundaries.GetCustomerDetails.IOutputPort>(x => x.GetRequiredService<Manga.WebApi.UseCases.V1.GetCustomerDetails.GetCustomerDetailsPresenter>());

            services.AddScoped<Manga.WebApi.UseCases.V1.Register.RegisterPresenter, Manga.WebApi.UseCases.V1.Register.RegisterPresenter>();
            services.AddScoped<Manga.Application.Boundaries.Register.IOutputPort>(x => x.GetRequiredService<Manga.WebApi.UseCases.V1.Register.RegisterPresenter>());

            services.AddScoped<Manga.WebApi.UseCases.V1.Withdraw.WithdrawPresenter, Manga.WebApi.UseCases.V1.Withdraw.WithdrawPresenter>();
            services.AddScoped<Manga.Application.Boundaries.Withdraw.IOutputPort>(x => x.GetRequiredService<Manga.WebApi.UseCases.V1.Withdraw.WithdrawPresenter>());

            services.AddScoped<Manga.WebApi.UseCases.V1.Transfer.TransferPresenter, Manga.WebApi.UseCases.V1.Transfer.TransferPresenter>();
            services.AddScoped<Manga.Application.Boundaries.Transfer.IOutputPort>(x => x.GetRequiredService<Manga.WebApi.UseCases.V1.Transfer.TransferPresenter>());

            return services;
        }
    }
}
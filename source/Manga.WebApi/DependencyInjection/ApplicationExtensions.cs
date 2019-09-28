namespace Manga.WebApi.DependencyInjection
{
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<Manga.Application.Boundaries.CloseAccount.IUseCase, Manga.Application.UseCases.CloseAccount>();
            services.AddScoped<Manga.Application.Boundaries.Deposit.IUseCase, Manga.Application.UseCases.Deposit>();
            services.AddScoped<Manga.Application.Boundaries.GetAccountDetails.IUseCase, Manga.Application.UseCases.GetAccountDetails>();
            services.AddScoped<Manga.Application.Boundaries.GetCustomerDetails.IUseCase, Manga.Application.UseCases.GetCustomerDetails>();
            services.AddScoped<Manga.Application.Boundaries.Register.IUseCase, Manga.Application.UseCases.Register>();
            services.AddScoped<Manga.Application.Boundaries.Withdraw.IUseCase, Manga.Application.UseCases.Withdraw>();
            services.AddScoped<Manga.Application.Boundaries.Transfer.IUseCase, Manga.Application.UseCases.Transfer>();

            return services;
        }
    }
}
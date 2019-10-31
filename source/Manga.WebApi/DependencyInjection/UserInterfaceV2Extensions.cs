namespace Manga.WebApi.DependencyInjection
{
    using Microsoft.Extensions.DependencyInjection;

    public static class UserInterfaceV2Extensions
    {
        public static IServiceCollection AddPresentersV2(this IServiceCollection services)
        {
            services.AddScoped<Manga.WebApi.UseCases.V2.GetAccountDetails.GetAccountDetailsPresenterV2, Manga.WebApi.UseCases.V2.GetAccountDetails.GetAccountDetailsPresenterV2>();
            services.AddScoped<Manga.Application.Boundaries.GetAccountDetails.IUseCaseV2>(
                    ctx => new Application.UseCases.GetAccountDetails(
                        ctx.GetRequiredService<Manga.WebApi.UseCases.V2.GetAccountDetails.GetAccountDetailsPresenterV2>(),
                        ctx.GetRequiredService<Application.Repositories.IAccountRepository>()
                    ));

            return services;
        }
    }
}

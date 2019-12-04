namespace WebApi.DependencyInjection
{
    using Domain.Accounts;
    using Domain.Security.Services;
    using Microsoft.Extensions.DependencyInjection;
    using WebApi.UseCases.V2.GetAccountDetails;

    public static class UserInterfaceV2Extensions
    {
        public static IServiceCollection AddPresentersV2(this IServiceCollection services)
        {
            services.AddScoped<GetAccountDetailsPresenterV2, GetAccountDetailsPresenterV2>();
            services.AddScoped<Application.Boundaries.GetAccountDetails.IUseCaseV2>(
                ctx => new Application.UseCases.GetAccountDetails(
                    ctx.GetRequiredService<GetAccountDetailsPresenterV2>(),
                    ctx.GetRequiredService<IAccountRepository>()));

            return services;
        }
    }
}

namespace WebApi.Modules
{
    using Application.Boundaries.GetAccountDetails;
    using Application.UseCases;
    using Domain.Accounts;
    using Microsoft.Extensions.DependencyInjection;
    using UseCases.V2.GetAccountDetails;

    public static class UserInterfaceV2Extensions
    {
        public static IServiceCollection AddPresentersV2(this IServiceCollection services)
        {
            services.AddScoped<GetAccountDetailsPresenterV2, GetAccountDetailsPresenterV2>();
            services.AddScoped<IUseCaseV2>(
                ctx => new GetAccountDetailsUseCase(
                    ctx.GetRequiredService<GetAccountDetailsPresenterV2>(),
                    ctx.GetRequiredService<IAccountRepository>()));

            return services;
        }
    }
}

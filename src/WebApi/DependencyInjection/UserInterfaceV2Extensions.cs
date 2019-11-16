namespace WebApi.DependencyInjection
{
    using Application.Repositories;
    using Application.Services;
    using Microsoft.Extensions.DependencyInjection;
    using UseCases.V2.GetAccountDetails;

    public static class UserInterfaceV2Extensions
    {
        public static IServiceCollection AddPresentersV2(this IServiceCollection services)
        {
            services.AddScoped<GetAccountDetailsPresenterV2, GetAccountDetailsPresenterV2>();
            services.AddScoped<Application.Boundaries.GetAccountDetails.IUseCaseV2>(
                ctx => new Application.UseCases.GetAccountDetails(
                    ctx.GetRequiredService<IUserService>(),
                    ctx.GetRequiredService<GetAccountDetailsPresenterV2>(),
                    ctx.GetRequiredService<IAccountRepository>()
                ));

            return services;
        }
    }
}
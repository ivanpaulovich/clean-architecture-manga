namespace WebApi.Modules.Common
{
    using Application.Services;
    using Infrastructure.ExternalAuthentication;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.AspNetCore.Builder;

    /// <summary>
    ///     Authentication Extensions.
    /// </summary>
    public static class AuthenticationExtensions
    {
        /// <summary>
        ///     Add Authentication Extensions.
        /// </summary>
        public static IServiceCollection AddAuthentication(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            bool useFake = configuration.GetValue<bool>("AuthenticationModule:UseFake");

            if (useFake)
            {
                services.AddScoped<IUserService, TestUserService>();
            }
            else
            {
                services.AddScoped<IUserService, ExternalUserService>();
            }

            services
                .AddAuthentication("Bearer")
                .AddIdentityServerAuthentication("Bearer", options =>
                {
                    // set the Identity.API service as the authority on authentication/authorization
                    options.Authority = configuration["AuthenticationModule:AuthorityUrl"];
                    options.ApiName = "api1";

                    options.RequireHttpsMetadata = false;

                    // set the name of the API that's talking to the Identity API
                });


            return services;
        }
    }
}

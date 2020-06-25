namespace WebApi.Modules
{
    using Application.Services;
    using Infrastructure.CurrencyExchange;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    ///     Currency Exchange Extensions.
    /// </summary>
    public static class CurrencyExchangeExtensions
    {
        /// <summary>
        ///     Add Currency Exchange dependencies varying on configuration.
        /// </summary>
        public static IServiceCollection AddCurrencyExchange(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            bool useFake = configuration.GetValue<bool>("CurrencyExchangeModule:UseFake");
            if (useFake)
            {
                services.AddScoped<ICurrencyExchange, CurrencyExchangeServiceFake>();
            }
            else
            {
                services.AddHttpClient(CurrencyExchangeService.HttpClientName);
                services.AddScoped<ICurrencyExchange, CurrencyExchangeService>();
            }

            return services;
        }
    }
}

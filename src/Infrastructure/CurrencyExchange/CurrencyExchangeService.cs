namespace Infrastructure.CurrencyExchange
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Application.Services;
    using Domain.Accounts.ValueObjects;
    using Newtonsoft.Json.Linq;

    /// <summary>
    ///     Fake implementation of the Exchange Service using hardcoded rates
    /// </summary>
    public sealed class CurrencyExchangeService : ICurrencyExchange
    {
        public const string HttpClientName = "Fixer";
        private readonly IHttpClientFactory _httpClientFactory;

        public CurrencyExchangeService(IHttpClientFactory httpClientFactory) =>
            this._httpClientFactory = httpClientFactory;

        /// <summary>
        ///     Converts allowed currencies into USD.
        /// </summary>
        /// <param name="money">Money.</param>
        /// <returns>Money.</returns>
        public async Task<PositiveMoney> ConvertToUSD(PositiveMoney money)
        {
            var httpClient = this._httpClientFactory.CreateClient(HttpClientName);
            var requestUri = new Uri("https://api.exchangeratesapi.io/latest?base=USD");

            var response = await httpClient.GetAsync(requestUri)
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            string responseJson = await response
                .Content
                .ReadAsStringAsync()
                .ConfigureAwait(false);

            PositiveMoney result = ParseCurrencies(money, responseJson);
            return result;
        }

        /// <summary>
        /// </summary>
        /// <param name="money"></param>
        /// <param name="responseJson"></param>
        /// <returns></returns>
        private static PositiveMoney ParseCurrencies(PositiveMoney money, string responseJson)
        {
            var rates = JObject.Parse(responseJson);
            decimal selectedRate = rates["rates"][money.GetCurrency().ToString()].Value<decimal>();
            decimal newValue = money.ToMoney().ToDecimal() / selectedRate;
            return new PositiveMoney(newValue);
        }
    }
}

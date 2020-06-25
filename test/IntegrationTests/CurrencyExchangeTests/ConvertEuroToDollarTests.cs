namespace IntegrationTests.CurrencyExchangeTests
{
    using System.Threading.Tasks;
    using Domain.Accounts.ValueObjects;
    using Infrastructure.CurrencyExchange;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    /// <summary>
    /// 
    /// </summary>
    public sealed class ConvertEuroToDollarTests
    {
        [Fact]
        public async Task Convert()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddHttpClient(CurrencyExchangeService.HttpClientName);
            serviceCollection.AddSingleton<CurrencyExchangeService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var sut = serviceProvider.GetRequiredService<CurrencyExchangeService>();

            var usdMoney = new PositiveMoney(100, "EUR");
            var actual = await sut.ConvertToUSD(usdMoney);

            Assert.True(actual.ToMoney().ToDecimal() > 100);
            Assert.Equal("USD", actual.GetCurrency().ToString());
        }
    }
}

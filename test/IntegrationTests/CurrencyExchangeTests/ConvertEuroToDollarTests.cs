namespace IntegrationTests.CurrencyExchangeTests
{
    using System.Threading.Tasks;
    using Domain.Accounts.ValueObjects;
    using Infrastructure.CurrencyExchange;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    /// <summary>
    /// </summary>
    public sealed class ConvertEuroToDollarTests
    {
        [Fact]
        public async Task Convert()
        {
            ServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddHttpClient(CurrencyExchangeService.HttpClientName);
            serviceCollection.AddSingleton<CurrencyExchangeService>();

            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            CurrencyExchangeService sut = serviceProvider.GetRequiredService<CurrencyExchangeService>();

            PositiveMoney usdMoney = new PositiveMoney(100, Currency.Euro);
            PositiveMoney actual = await sut.Convert(usdMoney, Currency.Dollar);

            Assert.True(actual.Amount > 100);
            Assert.Equal("USD", actual.Currency.Code);
        }
    }
}

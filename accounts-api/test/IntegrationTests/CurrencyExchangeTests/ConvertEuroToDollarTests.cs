namespace IntegrationTests.CurrencyExchangeTests;

using System.Threading.Tasks;
using Domain.ValueObjects;
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
        serviceCollection.AddSingleton<CurrencyExchangeFake>();

        ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
        CurrencyExchangeFake sut = serviceProvider.GetRequiredService<CurrencyExchangeFake>();

        Money usdMoney = new Money(100, Currency.Euro);
        Money actual = await sut.Convert(usdMoney, Currency.Dollar);

        Assert.True(actual.Amount > 100);
        Assert.Equal("USD", actual.Currency.Code);
    }
}

namespace Infrastructure.CurrencyExchange;

using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Services;
using Domain.ValueObjects;

/// <summary>
///     Fake implementation of the Exchange Service using hardcoded rates
/// </summary>
public sealed class CurrencyExchangeFake : ICurrencyExchange
{
    private readonly Dictionary<Currency, decimal> _usdRates = new Dictionary<Currency, decimal>
        {
            {Currency.Dollar, 1m},
            {Currency.Euro, 0.89021m},
            {Currency.Canadian, 1.35737m},
            {Currency.BritishPound, 0.80668m},
            {Currency.Krona, 9.31944m},
            {Currency.Real, 5.46346m}
        };

    public Task<Money> Convert(Money originalAmount, Currency destinationCurrency)
    {
        // hardcoded rates from https://www.xe.com/currency/usd-us-dollar

        decimal usdAmount = this._usdRates[originalAmount.Currency] / originalAmount.Amount;
        decimal destinationAmount = this._usdRates[destinationCurrency] / usdAmount;

        return Task.FromResult(
            new Money(
                destinationAmount,
                destinationCurrency));
    }
}

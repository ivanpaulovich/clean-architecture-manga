namespace Infrastructure.CurrencyExchange
{
    using System.Threading.Tasks;
    using Application.Services;
    using Domain.Accounts.ValueObjects;

    /// <summary>
    ///     Fake implementation of the Exchange Service using hardcoded rates
    /// </summary>
    public sealed class CurrencyExchangeFake : ICurrencyExchange
    {
        /// <summary>
        ///     Converts allowed currencies into USD.
        /// </summary>
        /// <param name="money">Money.</param>
        /// <returns>Money.</returns>
        public Task<PositiveMoney> ConvertToUSD(PositiveMoney money)
        {
            // hardcoded rates from https://www.xe.com/currency/usd-us-dollar

            if (money.GetCurrency() == Currency.Dollar)
            {
                return Task.FromResult(money);
            }

            if (money.GetCurrency() == Currency.Euro)
            {
                return Task.FromResult(
                    new PositiveMoney(
                        money.ToMoney().ToDecimal() * 0.89021m,
                        Currency.Euro.ToString()));
            }

            if (money.GetCurrency() == Currency.Canadian)
            {
                return Task.FromResult(
                    new PositiveMoney(
                        money.ToMoney().ToDecimal() * 1.35737m,
                        Currency.Canadian.ToString()));
            }

            if (money.GetCurrency() == Currency.BritishPound)
            {
                return Task.FromResult(
                    new PositiveMoney(
                        money.ToMoney().ToDecimal() * 0.80668m,
                        Currency.BritishPound.ToString()));
            }

            if (money.GetCurrency() == Currency.Krona)
            {
                return Task.FromResult(
                    new PositiveMoney(
                        money.ToMoney().ToDecimal() * 9.31944m,
                        Currency.Krona.ToString()));
            }

            if (money.GetCurrency() == Currency.Real)
            {
                return Task.FromResult(
                    new PositiveMoney(
                        money.ToMoney().ToDecimal() * 5.46346m,
                        Currency.Krona.ToString()));
            }

            throw new CurrencyNotAllowedException();
        }
    }
}

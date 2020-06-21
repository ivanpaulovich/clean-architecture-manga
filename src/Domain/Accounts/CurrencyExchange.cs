namespace Domain.Accounts
{
    using System;
    using System.Threading.Tasks;
    using Domain.Accounts.ValueObjects;

    /// <summary>
    /// 
    /// </summary>
    public class CurrencyExchange
    {
        private readonly ICurrencyExchangeAPI _exchangeAPI;

        /// <summary>
        /// </summary>
        /// <param name="exchangeAPI"></param>
        public CurrencyExchange(ICurrencyExchangeAPI exchangeAPI)
        {
            _exchangeAPI = exchangeAPI;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="positiveMoney"></param>
        /// <returns></returns>
        public async Task<PositiveMoney> ConvertToDollar(PositiveMoney positiveMoney)
        {
            if (positiveMoney.IsCurrencyEqualsTo("USD")) return positiveMoney;

            // DO CALCULUS HERE
            var valueOfToday = await _exchangeAPI
                .ReturnValueOfCurrencyFromToday(positiveMoney.GetCurrency())
                .ConfigureAwait(false);

            throw new Exception();
        }
    }
}

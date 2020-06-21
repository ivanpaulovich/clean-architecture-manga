namespace Infrastructure.Integrations.HTTP
{
    using System.Threading.Tasks;
    using Domain.Accounts;
    using Domain.Accounts.ValueObjects;

    /// <summary>
    /// 
    /// </summary>
    public class CurrencyExchangeAPI : ICurrencyExchangeAPI
    {
        /// <summary>
        /// </summary>
        /// <param name="currency"></param>
        /// <returns></returns>
        public Task<decimal> ReturnValueOfCurrencyFromToday(Currency currency)
        {
            return Task.FromResult(1.0m);
        }
    }
}

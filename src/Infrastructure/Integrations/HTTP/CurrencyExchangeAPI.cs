namespace Infrastructure.Integrations.HTTP
{
    using System.Threading.Tasks;
    using Application.Services;
    using Domain.Accounts.ValueObjects;

    /// <summary>
    /// 
    /// </summary>
    public class CurrencyExchangeAPI : ICurrencyExchangeAPI
    {
        /// <summary>
        /// </summary>
        /// <param name="money"></param>
        /// <returns></returns>
        public Task<PositiveMoney> ConvertToUSD(PositiveMoney money)
        {
            return Task.FromResult(money);
        }
    }
}

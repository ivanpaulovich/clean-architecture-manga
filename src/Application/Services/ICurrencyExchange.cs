namespace Application.Services
{
    using System.Threading.Tasks;
    using Domain.Accounts.ValueObjects;

    /// <summary>
    /// </summary>
    public interface ICurrencyExchange
    {
        /// <summary>
        /// </summary>
        /// <param name="money"></param>
        /// <returns></returns>
        Task<PositiveMoney> ConvertToUSD(PositiveMoney money);
    }
}

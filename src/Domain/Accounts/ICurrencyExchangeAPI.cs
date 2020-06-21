namespace Domain.Accounts
{
    using System.Threading.Tasks;
    using Domain.Accounts.ValueObjects;

    /// <summary>
    /// </summary>
    public interface ICurrencyExchangeAPI
    {
        /// <summary>
        /// </summary>
        /// <param name="currency"></param>
        /// <returns></returns>
        Task<decimal> ReturnValueOfCurrencyFromToday(Currency currency);
    }
}

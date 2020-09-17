namespace Application.Services
{
    using Domain.ValueObjects;
    using System.Threading.Tasks;

    /// <summary>
    /// </summary>
    public interface ICurrencyExchange
    {
        Task<PositiveMoney> Convert(PositiveMoney originalAmount, Currency destinationCurrency);
    }
}

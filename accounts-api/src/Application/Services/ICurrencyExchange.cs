namespace Application.Services
{
    using System.Threading.Tasks;
    using Domain.ValueObjects;

    /// <summary>
    /// </summary>
    public interface ICurrencyExchange
    {
        Task<PositiveMoney> Convert(PositiveMoney originalAmount, Currency destinationCurrency);
    }
}

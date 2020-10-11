namespace Application.Services
{
    using System.Threading.Tasks;
    using Domain.ValueObjects;

    /// <summary>
    /// </summary>
    public interface ICurrencyExchange
    {
        Task<Money> Convert(Money originalAmount, Currency destinationCurrency);
    }
}

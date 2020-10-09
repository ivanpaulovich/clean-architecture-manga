namespace Application.Services
{
    using Domain.ValueObjects;
    using System.Threading.Tasks;

    /// <summary>
    /// </summary>
    public interface ICurrencyExchange
    {
        Task<Money> Convert(Money originalAmount, Currency destinationCurrency);
    }
}

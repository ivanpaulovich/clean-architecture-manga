namespace Manga.Domain.Customers
{
    using System;
    using System.Threading.Tasks;

    public interface ICustomerReadOnlyRepository
    {
        Task<Customer> Get(Guid id);
        Task<Customer> GetByAccount(Guid id);
    }
}

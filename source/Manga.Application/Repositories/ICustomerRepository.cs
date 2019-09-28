namespace Manga.Application.Repositories
{
    using System.Threading.Tasks;
    using System;
    using Manga.Domain.Customers;

    public interface ICustomerRepository
    {
        Task<ICustomer> TryGet(Guid id);
        Task Add(ICustomer customer);
        Task Update(ICustomer customer);
    }
}
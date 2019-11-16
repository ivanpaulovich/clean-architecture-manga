namespace Application.Repositories
{
    using System.Threading.Tasks;
    using System;
    using Domain.Customers;
    using Domain.ValueObjects;

    public interface ICustomerRepository
    {
        Task<ICustomer> GetBy(ExternalUserId externalUserId);
        Task Add(ICustomer customer);
        Task Update(ICustomer customer);
    }
}
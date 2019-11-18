namespace Application.Repositories
{
    using System;
    using System.Threading.Tasks;
    using Domain.Customers;
    using Domain.ValueObjects;

    public interface ICustomerRepository
    {
        Task<ICustomer> GetBy(ExternalUserId externalUserId);

        Task Add(ICustomer customer);

        Task Update(ICustomer customer);
    }
}
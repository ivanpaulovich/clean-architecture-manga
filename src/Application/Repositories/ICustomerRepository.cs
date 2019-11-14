namespace Application.Repositories
{
    using System.Threading.Tasks;
    using System;
    using Domain.Customers;
    using Domain.ValueObjects;

    public interface ICustomerRepository
    {
        Task<ICustomer> Get(Guid id);
        Task<ICustomer> Get(SSN ssn);
        Task<ICustomer> Get(Username username, Password password);
        Task Add(ICustomer customer);
        Task Update(ICustomer customer);
    }
}

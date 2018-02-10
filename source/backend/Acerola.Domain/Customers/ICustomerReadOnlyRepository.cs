namespace Acerola.Domain.Customers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICustomerReadOnlyRepository
    {
        Task<Customer> Get(Guid id);
        Task<IEnumerable<Customer>> GetAll();
    }
}

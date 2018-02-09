namespace Acerola.Application.Queries
{
    using Acerola.Application.DTO;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICustomersQueries
    {
        Task<CustomerData> GetCustomer(Guid id);
        Task<IEnumerable<CustomerData>> GetAll();
    }
}

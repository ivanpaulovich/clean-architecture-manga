namespace Manga.Infrastructure.Dapper
{
    using Manga.Application.Repositories;
    using Manga.Domain.Customers;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class CustomerReadOnlyRepository : ICustomerReadOnlyRepository
    {
        public Task<Customer> Get(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

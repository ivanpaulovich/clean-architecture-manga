namespace Manga.Infrastructure.Dapper
{
    using Manga.Application.Repositories;
    using Manga.Domain.Accounts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class AccountReadOnlyRepository : IAccountReadOnlyRepository
    {
        public Task<Account> Get(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

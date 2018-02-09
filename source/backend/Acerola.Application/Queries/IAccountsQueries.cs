namespace Acerola.Application.Queries
{
    using Acerola.Application.Accounts.Details;
    using Acerola.Application.DTO;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAccountsQueries
    {
        Task<AccountData> GetAccount(Guid id);
        Task<IEnumerable<AccountData>> GetAll();
        Task<IEnumerable<AccountData>> Get(Guid customerId);
    }
}

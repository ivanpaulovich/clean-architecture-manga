namespace Manga.Domain.Accounts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAccountReadOnlyRepository
    {
        Task<Account> Get(Guid id);
        Task<IEnumerable<Account>> ListAll();
    }
}
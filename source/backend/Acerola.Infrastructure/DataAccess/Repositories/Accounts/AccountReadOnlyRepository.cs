namespace Acerola.Infrastructure.DataAccess.Repositories.Accounts
{
    using Acerola.Domain.Accounts;
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class AccountReadOnlyRepository : IAccountReadOnlyRepository
    {
        private readonly AccountBalanceContext _mongoContext;

        public AccountReadOnlyRepository(AccountBalanceContext mongoContext)
        {
            _mongoContext = mongoContext;
        }

        public async Task<Account> Get(Guid id)
        {
            return await _mongoContext.Accounts.Find(e => e.Id == id).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Account>> ListAll()
        {
            IEnumerable<Account> data = await this._mongoContext.Accounts
                .Find(e => true)
                .ToListAsync();

            return data;
        }
    }
}

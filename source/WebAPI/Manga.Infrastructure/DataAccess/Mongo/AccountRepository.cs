namespace Manga.Infrastructure.DataAccess.Mongo
{
    using Manga.Application.Repositories;
    using Manga.Domain.Accounts;
    using MongoDB.Driver;
    using System;
    using System.Threading.Tasks;

    public class AccountRepository : IAccountReadOnlyRepository, IAccountWriteOnlyRepository
    {
        private readonly AccountBalanceContext mongoContext;

        public AccountRepository(AccountBalanceContext mongoContext)
        {
            this.mongoContext = mongoContext;
        }

        public async Task Add(Account account)
        {
            await mongoContext.Accounts.InsertOneAsync(account);
        }

        public async Task Delete(Account account)
        {
            await mongoContext.Accounts.DeleteOneAsync(e => e.Id == account.Id);
        }

        public async Task<Account> Get(Guid id)
        {
            return await mongoContext
                .Accounts
                .Find(e => e.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task Update(Account account)
        {
            await mongoContext.Accounts.ReplaceOneAsync(e => e.Id == account.Id, account);
        }
    }
}

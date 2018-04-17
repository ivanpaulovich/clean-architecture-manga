namespace MyProject.Infrastructure.MongoDataAccess
{
    using MyProject.Application.Repositories;
    using MyProject.Domain.Accounts;
    using MongoDB.Driver;
    using System;
    using System.Threading.Tasks;

    public class AccountRepository : IAccountReadOnlyRepository, IAccountWriteOnlyRepository
    {
        private readonly Context mongoContext;

        public AccountRepository(Context mongoContext)
        {
            this.mongoContext = mongoContext;
        }

        public async Task Add(Account account, Credit credit)
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

        public async Task Update(Account account, Transaction transaction)
        {
            await mongoContext.Accounts.ReplaceOneAsync(e => e.Id == account.Id, account);
        }
    }
}

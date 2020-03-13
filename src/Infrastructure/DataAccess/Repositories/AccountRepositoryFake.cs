namespace Infrastructure.DataAccess.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Accounts;
    using Domain.Accounts.Credits;
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;
    using Domain.Customers.ValueObjects;
    using Account = Entities.Account;
    using Credit = Entities.Credit;

    public sealed class AccountRepositoryFake : IAccountRepository
    {
        private readonly MangaContextFake _context;

        public AccountRepositoryFake(MangaContextFake context)
        {
            this._context = context;
        }

        public async Task<IList<IAccount>> GetBy(CustomerId customerId)
        {
            var accounts = this._context.Accounts
                .Where(e => e.CustomerId.Equals(customerId))
                .Select(e => (IAccount)e)
                .ToList();

            return await Task.FromResult(accounts)
                .ConfigureAwait(false);
        }

        public async Task Add(IAccount account, ICredit credit)
        {
            this._context
                .Accounts
                .Add((Account)account);

            this._context
                .Credits
                .Add((Credit)credit);

            await Task.CompletedTask
                .ConfigureAwait(false);
        }

        public async Task Delete(IAccount account)
        {
            var accountOld = this._context.Accounts
                .SingleOrDefault(e => e.Id.Equals(account.Id));

            this._context.Accounts.Remove(accountOld);

            await Task.CompletedTask
                .ConfigureAwait(false);
        }

        public async Task<IAccount> GetAccount(AccountId accountId)
        {
            var account = this._context.Accounts
                .SingleOrDefault(e => e.Id.Equals(accountId));

            if (account is null)
            {
                throw new AccountNotFoundException($"The account {accountId} does not exist or is not processed yet.");
            }

            return await Task.FromResult<Domain.Accounts.Account>(account)
                .ConfigureAwait(false);
        }

        public async Task Update(IAccount account, ICredit credit)
        {
            Domain.Accounts.Account accountOld = this._context
                .Accounts
                .SingleOrDefault(e => e.Id.Equals(account.Id));

            accountOld = (Domain.Accounts.Account)account;
            await Task.CompletedTask
                .ConfigureAwait(false);
        }

        public async Task Update(IAccount account, IDebit debit)
        {
            Domain.Accounts.Account accountOld = this._context.Accounts
                .SingleOrDefault(e => e.Id.Equals(account.Id));

            accountOld = (Domain.Accounts.Account)account;
            await Task.CompletedTask
                .ConfigureAwait(false);
        }
    }
}

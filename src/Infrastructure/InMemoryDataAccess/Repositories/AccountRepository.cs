namespace Infrastructure.InMemoryDataAccess.Repositories
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Repositories;
    using Domain.Accounts;
    using Domain.Customers;
    using Domain.ValueObjects;

    public sealed class AccountRepository : IAccountRepository
    {
        private readonly MangaContext _context;

        public AccountRepository(MangaContext context)
        {
            _context = context;
        }

        public async Task Add(IAccount account, ICredit credit)
        {
            _context.Accounts.Add((InMemoryDataAccess.Account)account);
            _context.Credits.Add((InMemoryDataAccess.Credit)credit);
            await Task.CompletedTask;
        }

        public async Task Delete(IAccount account)
        {
            var accountOld = _context.Accounts
                .Where(e => e.Id == account.Id)
                .SingleOrDefault();

            _context.Accounts.Remove(accountOld);

            await Task.CompletedTask;
        }

        public async Task<IAccount> Get(Guid id)
        {
            var account = _context.Accounts
                .Where(e => e.Id == id)
                .SingleOrDefault();

            if (account is null)
            {
                throw new AccountNotFoundException($"The account {id} does not exist or is not processed yet.");
            }

            return await Task.FromResult<Account>(account);
        }

        public async Task<IAccount> Get(ExternalUserId externalUserId, Guid id)
        {
            var customer = _context.Customers
                .Where(e => e.ExternalUserId.Equals(externalUserId))
                .SingleOrDefault();

            if (customer is null)
            {
                throw new CustomerNotFoundException($"The customer {externalUserId} does not exist or is not processed yet.");
            }

            var account = _context.Accounts
                .Where(e => e.Id == id && e.CustomerId == customer.Id)
                .SingleOrDefault();

            if (account is null)
            {
                throw new AccountNotFoundException($"The account {id} does not exist or is not processed yet.");
            }

            return await Task.FromResult<Account>(account);
        }

        public async Task Update(IAccount account, ICredit credit)
        {
            Account accountOld = _context.Accounts
                .Where(e => e.Id == account.Id)
                .SingleOrDefault();

            accountOld = (Account)account;
            await Task.CompletedTask;
        }

        public async Task Update(IAccount account, IDebit debit)
        {
            Account accountOld = _context.Accounts
                .Where(e => e.Id == account.Id)
                .SingleOrDefault();

            accountOld = (Account)account;
            await Task.CompletedTask;
        }
    }
}

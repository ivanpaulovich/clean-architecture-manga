namespace Manga.Infrastructure.MongoDataAccess.Repositories
{
    using Manga.Application.Repositories;
    using Manga.Domain.Accounts;
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AccountRepository : IAccountReadOnlyRepository, IAccountWriteOnlyRepository
    {
        private readonly Context _context;

        public AccountRepository(Context context)
        {
            _context = context;
        }

        public async Task Add(Account account, Credit credit)
        {
            Entities.Account accountEntity = new Entities.Account()
            {
                CustomerId = account.CustomerId,
                Id = account.Id
            };

            Entities.Credit creditEntity = new Entities.Credit()
            {
                AccountId = credit.AccountId,
                Amount = credit.Amount,
                Description = credit.Description,
                Id = credit.Id,
                TransactionDate = credit.TransactionDate
            };

            await _context.Accounts.InsertOneAsync(accountEntity);
            await _context.Credits.InsertOneAsync(creditEntity);
        }

        public async Task Delete(Account account)
        {
            await _context.Credits.DeleteOneAsync(e => e.AccountId == account.Id);
            await _context.Debits.DeleteOneAsync(e => e.AccountId == account.Id);
            await _context.Accounts.DeleteOneAsync(e => e.Id == account.Id);
        }

        public async Task<Account> Get(Guid id)
        {
            Entities.Account account = await _context
                .Accounts
                .Find(e => e.Id == id)
                .SingleOrDefaultAsync();

            List<Entities.Credit> credits = await _context
                .Credits
                .Find(e => e.AccountId == id)
                .ToListAsync();

            List<Entities.Debit> debits = await _context
                .Debits
                .Find(e => e.AccountId == id)
                .ToListAsync();

            List<ITransaction> transactions = new List<ITransaction>();

            foreach (Entities.Credit transactionData in credits)
            {
                Credit transaction = Credit.Load(
                    transactionData.Id,
                    transactionData.AccountId,
                    transactionData.Amount,
                    transactionData.TransactionDate);

                transactions.Add(transaction);
            }

            foreach (Entities.Debit transactionData in debits)
            {
                Debit transaction = Debit.Load(
                    transactionData.Id,
                    transactionData.AccountId,
                    transactionData.Amount,
                    transactionData.TransactionDate);

                transactions.Add(transaction);
            }

            var orderedTransactions = transactions.OrderBy(o => o.TransactionDate).ToList();

            TransactionCollection transactionCollection = new TransactionCollection();
            transactionCollection.Add(orderedTransactions);

            Account result = Account.Load(
                account.Id,
                account.CustomerId,
                transactionCollection);

            return result;
        }

        public async Task Update(Account account, Credit credit)
        {
            Entities.Credit creditEntity = new Entities.Credit
            {
                AccountId = credit.AccountId,
                Amount = credit.Amount,
                Description = credit.Description,
                Id = credit.Id,
                TransactionDate = credit.TransactionDate
            };

            await _context.Credits.InsertOneAsync(creditEntity);
        }

        public async Task Update(Account account, Debit debit)
        {
            Entities.Debit debitEntity = new Entities.Debit
            {
                AccountId = debit.AccountId,
                Amount = debit.Amount,
                Description = debit.Description,
                Id = debit.Id,
                TransactionDate = debit.TransactionDate
            };

            await _context.Debits.InsertOneAsync(debitEntity);
        }
    }
}

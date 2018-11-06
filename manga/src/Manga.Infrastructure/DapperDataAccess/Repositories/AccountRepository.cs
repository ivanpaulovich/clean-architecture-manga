namespace Manga.Infrastructure.DapperDataAccess.Repositories
{
    using Dapper;
    using Manga.Application.Repositories;
    using Manga.Domain.Accounts;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;

    public class AccountRepository : IAccountReadOnlyRepository, IAccountWriteOnlyRepository
    {
        private readonly string connectionString;

        public AccountRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task Add(Account account, Credit credit)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string insertAccountSQL = "INSERT INTO Account (Id, CustomerId) VALUES (@Id, @CustomerId)";

                DynamicParameters accountParameters = new DynamicParameters();
                accountParameters.Add("@id", account.Id);
                accountParameters.Add("@customerId", account.CustomerId);

                int accountRows = await db.ExecuteAsync(insertAccountSQL, accountParameters);
                
                string insertCreditSQL = "INSERT INTO [Credit] (Id, Amount, TransactionDate, AccountId) " +
                    "VALUES (@Id, @Amount, @TransactionDate, @AccountId)";

                DynamicParameters transactionParameters = new DynamicParameters();
                transactionParameters.Add("@id", credit.Id);
                transactionParameters.Add("@amount", (double)credit.Amount);
                transactionParameters.Add("@transactionDate", credit.TransactionDate);
                transactionParameters.Add("@accountId", credit.AccountId);

                int creditRows = await db.ExecuteAsync(insertCreditSQL, transactionParameters);
            }
        }

        public async Task Delete(Account account)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string deleteSQL =
                    @"DELETE FROM [Credit] WHERE AccountId = @Id;
                      DELETE FROM [Debit] WHERE AccountId = @Id;
                      DELETE FROM Account WHERE Id = @Id;";
                int rowsAffected = await db.ExecuteAsync(deleteSQL, account);
            }
        }

        public async Task<Account> Get(Guid id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string accountSQL = @"SELECT * FROM Account WHERE Id = @Id";
                Entities.Account account = await db
                    .QueryFirstOrDefaultAsync<Entities.Account>(accountSQL, new { id });

                if (account == null)
                    return null;

                string credits =
                    @"SELECT * FROM [Credit]
                      WHERE AccountId = @Id";

                List<ITransaction> transactionsList = new List<ITransaction>();

                using (var reader = db.ExecuteReader(credits, new { id }))
                {
                    var parser = reader.GetRowParser<Credit>();

                    while (reader.Read())
                    {
                        ITransaction transaction = parser(reader);
                        transactionsList.Add(transaction);
                    }
                }

                string debits =
                    @"SELECT * FROM [Debit]
                      WHERE AccountId = @Id";

                using (var reader = db.ExecuteReader(debits, new { id }))
                {
                    var parser = reader.GetRowParser<Debit>();

                    while (reader.Read())
                    {
                        ITransaction transaction = parser(reader);
                        transactionsList.Add(transaction);
                    }
                }

                TransactionCollection transactionCollection = new TransactionCollection();

                foreach (var item in transactionsList.OrderBy(e => e.TransactionDate))
                {
                    transactionCollection.Add(item);
                }

                Account result = Account.Load(account.Id, account.CustomerId, transactionCollection);
                return result;
            }
        }

        public async Task Update(Account account, Credit credit)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string insertCreditSQL = "INSERT INTO [Credit] (Id, Amount, TransactionDate, AccountId) " +
                    "VALUES (@Id, @Amount, @TransactionDate, @AccountId)";

                DynamicParameters transactionParameters = new DynamicParameters();
                transactionParameters.Add("@id", credit.Id);
                transactionParameters.Add("@amount", (double)credit.Amount);
                transactionParameters.Add("@transactionDate", credit.TransactionDate);
                transactionParameters.Add("@accountId", credit.AccountId);

                int creditRows = await db.ExecuteAsync(insertCreditSQL, transactionParameters);
            }
        }

        public async Task Update(Account account, Debit debit)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string insertDebitSQL = "INSERT INTO [Debit] (Id, Amount, TransactionDate, AccountId) " +
                    "VALUES (@Id, @Amount, @TransactionDate, @AccountId)";

                DynamicParameters transactionParameters = new DynamicParameters();
                transactionParameters.Add("@id", debit.Id);
                transactionParameters.Add("@amount", (double)debit.Amount);
                transactionParameters.Add("@transactionDate", debit.TransactionDate);
                transactionParameters.Add("@accountId", debit.AccountId);

                int debitRows = await db.ExecuteAsync(insertDebitSQL, transactionParameters);
            }
        }
    }
}

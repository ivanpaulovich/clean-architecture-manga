namespace MyProject.Infrastructure.DapperDataAccess
{
    using Dapper;
    using MyProject.Application.Repositories;
    using MyProject.Domain.Accounts;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using System.Collections.Generic;

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
                string insertAccountSQL = "INSERT INTO Account (Id, CustomerId, Version) VALUES (@Id, @CustomerId, @Version)";

                DynamicParameters accountParameters = new DynamicParameters();
                accountParameters.Add("@id", account.Id);
                accountParameters.Add("@customerId", account.CustomerId);
                accountParameters.Add("@version", account.Version);

                int accountRows = await db.ExecuteAsync(insertAccountSQL, accountParameters);
                
                string insertCreditSQL = "INSERT INTO [Transaction] (Id, Amount, TransactionDate, AccountId, TransactionType) " +
                    "VALUES (@Id, @Amount, @TransactionDate, @AccountId, @TransactionType)";

                DynamicParameters transactionParameters = new DynamicParameters();
                transactionParameters.Add("@id", credit.Id);
                transactionParameters.Add("@amount", credit.Amount.Value);
                transactionParameters.Add("@transactionDate", credit.TransactionDate);
                transactionParameters.Add("@accountId", credit.AccountId);
                transactionParameters.Add("@transactionType", 1);

                int creditRows = await db.ExecuteAsync(insertCreditSQL, transactionParameters);
            }
        }

        public async Task Delete(Account account)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string deleteSQL =
                    @"DELETE FROM [Transaction] WHERE AccountId = @Id;
                      DELETE FROM Account WHERE Id = @Id;";
                int rowsAffected = await db.ExecuteAsync(deleteSQL, account);
            }
        }

        public async Task<Account> Get(Guid id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {

                string accountSQL = @"SELECT * FROM Account WHERE Id = @Id";
                Proxies.Account account = await db
                    .QueryFirstOrDefaultAsync<Proxies.Account>(accountSQL, new { id });

                if (account == null)
                    return null;

                var transactions = new List<Transaction>();

                string accountTransactionsOrdered =
                    @"SELECT * FROM [Transaction]
                      WHERE AccountId = @Id 
                      ORDER BY TransactionDate";

                using (var reader = db.ExecuteReader(accountTransactionsOrdered, new { id }))
                {
                    var debitParser = reader.GetRowParser<Debit>();
                    var creditParser = reader.GetRowParser<Credit>();

                    while (reader.Read())
                    {
                        Transaction transaction = null;

                        switch ((int)reader["TransactionType"])
                        {
                            case 0:
                                transaction = debitParser(reader);
                                break;
                            case 1:
                                transaction = creditParser(reader);
                                break;
                        }

                        transactions.Add(transaction);
                    }
                }

                account.SetTransactions(transactions);
                return account;
            }
        }

        public async Task Update(Account account, Transaction transaction)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string updateAccountSQL = "UPDATE Account SET Version = @Version WHERE Id = @Id";
                int rowsAffected = await db.ExecuteAsync(updateAccountSQL, account);

                Debit debit = transaction as Debit;
                if (debit != null)
                {
                    string insertDebitSQL = "INSERT INTO [Transaction] (Id, Amount, TransactionDate, AccountId, TransactionType) " +
                        "VALUES (@Id, @Amount, @TransactionDate, @AccountId, @TransactionType)";

                    DynamicParameters transactionParameters = new DynamicParameters();
                    transactionParameters.Add("@id", debit.Id);
                    transactionParameters.Add("@amount", debit.Amount.Value);
                    transactionParameters.Add("@transactionDate", debit.TransactionDate);
                    transactionParameters.Add("@accountId", debit.AccountId);
                    transactionParameters.Add("@transactionType", 0);

                    int debitRows = await db.ExecuteAsync(insertDebitSQL, transactionParameters);
                }

                Credit credit = transaction as Credit;
                if (credit != null)
                {
                    string insertCreditSQL = "INSERT INTO [Transaction] (Id, Amount, TransactionDate, AccountId, TransactionType) " +
                        "VALUES (@Id, @Amount, @TransactionDate, @AccountId, @TransactionType)";

                    DynamicParameters transactionParameters = new DynamicParameters();
                    transactionParameters.Add("@id", credit.Id);
                    transactionParameters.Add("@amount", credit.Amount.Value);
                    transactionParameters.Add("@transactionDate", credit.TransactionDate);
                    transactionParameters.Add("@accountId", credit.AccountId);
                    transactionParameters.Add("@transactionType", 1);

                    int creditRows = await db.ExecuteAsync(insertCreditSQL, transactionParameters);
                }
            }
        }
    }
}

namespace Manga.Application.UseCases
{
    using Manga.Domain.Accounts;
    using System;
    using System.Collections.Generic;

    public sealed class AccountOutput
    {
        public Guid AccountId { get; }
        public double CurrentBalance { get; }
        public List<TransactionOutput> Transactions { get; }

        public AccountOutput(
            Guid accountId,
            double currentBalance,
            List<TransactionOutput> transactions)
        {
            AccountId = accountId;
            CurrentBalance = currentBalance;
            Transactions = transactions;
        }

        public AccountOutput(Account account)
        {
            AccountId = account.Id;
            CurrentBalance = account.GetCurrentBalance();

            List<TransactionOutput> transactionResults = new List<TransactionOutput>();
            foreach (ITransaction transaction in account.GetTransactions())
            {
                TransactionOutput transactionOutput = new TransactionOutput(
                    transaction.Description, transaction.Amount, transaction.TransactionDate);
                transactionResults.Add(transactionOutput);
            }

            Transactions = transactionResults;
        }
    }
}

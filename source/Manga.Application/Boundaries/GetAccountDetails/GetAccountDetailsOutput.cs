namespace Manga.Application.Boundaries.GetAccountDetails
{
    using System.Collections.Generic;
    using System;
    using Manga.Domain.Accounts;

    public sealed class GetAccountDetailsOutput
    {
        public Guid AccountId { get; }
        public decimal CurrentBalance { get; }
        public List<Transaction> Transactions { get; }

        public GetAccountDetailsOutput(
            Guid accountId,
            decimal currentBalance,
            List<Transaction> transactions)
        {
            AccountId = accountId;
            CurrentBalance = currentBalance;
            Transactions = transactions;
        }

        public GetAccountDetailsOutput(IAccount account)
        {
            var accountEntity = (Manga.Domain.Accounts.Account) account;

            AccountId = accountEntity.Id;
            CurrentBalance = accountEntity
                .GetCurrentBalance()
                .ToDecimal();

            List<Transaction> transactionResults = new List<Transaction>();
            foreach (var credit in accountEntity.Credits
                    .GetTransactions())
            {
                Credit creditEntity = (Credit) credit;

                Transaction transactionOutput = new Transaction(
                    creditEntity.Description,
                    creditEntity
                    .Amount
                    .ToMoney()
                    .ToDecimal(),
                    creditEntity.TransactionDate);

                transactionResults.Add(transactionOutput);
            }

            foreach (var debit in accountEntity.Debits
                    .GetTransactions())
            {
                Debit debitEntity = (Debit) debit;

                Transaction transactionOutput = new Transaction(
                    debitEntity.Description,
                    debitEntity
                    .Amount
                    .ToMoney()
                    .ToDecimal(),
                    debitEntity.TransactionDate);

                transactionResults.Add(transactionOutput);
            }

            Transactions = transactionResults;
        }
    }
}

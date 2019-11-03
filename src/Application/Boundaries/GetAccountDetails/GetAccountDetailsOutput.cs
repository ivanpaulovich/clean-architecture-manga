namespace Application.Boundaries.GetAccountDetails
{
    using System.Collections.Generic;
    using System;
    using Domain.Accounts;
    using Domain.ValueObjects;

    public sealed class GetAccountDetailsOutput
    {
        public Guid AccountId { get; }
        public Money CurrentBalance { get; }
        public List<Transaction> Transactions { get; }

        public GetAccountDetailsOutput(
            Guid accountId,
            Money currentBalance,
            List<Transaction> transactions)
        {
            AccountId = accountId;
            CurrentBalance = currentBalance;
            Transactions = transactions;
        }

        public GetAccountDetailsOutput(IAccount account)
        {
            var accountEntity = (Domain.Accounts.Account) account;

            AccountId = accountEntity.Id;
            CurrentBalance = accountEntity
                .GetCurrentBalance();

            List<Transaction> transactionResults = new List<Transaction>();
            foreach (var credit in accountEntity.Credits
                    .GetTransactions())
            {
                Credit creditEntity = (Credit) credit;

                Transaction transactionOutput = new Transaction(
                    creditEntity.Description,
                    creditEntity
                    .Amount
                    .ToMoney(),
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
                    .ToMoney(),
                    debitEntity.TransactionDate);

                transactionResults.Add(transactionOutput);
            }

            Transactions = transactionResults;
        }
    }
}
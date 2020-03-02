// <copyright file="Debit.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.InMemoryDataAccess
{
    using System;
    using Domain.Accounts;
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;

    public sealed class Debit : Domain.Accounts.Debits.Debit
    {
        public Debit(
            DebitId debitId,
            AccountId accountId,
            PositiveMoney amountToWithdraw,
            DateTime transactionDate)
        {
            this.Id = debitId;
            this.AccountId = accountId;
            this.Amount = amountToWithdraw;
            this.TransactionDate = transactionDate;
        }

        public AccountId AccountId { get; }
    }
}

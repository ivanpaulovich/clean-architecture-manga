// <copyright file="Debit.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.InMemoryDataAccess
{
    using System;
    using Domain.Accounts;
    using Domain.Accounts.ValueObjects;

    public class Debit : Domain.Accounts.Debits.Debit
    {
        public Debit(
            IAccount account,
            PositiveMoney amountToWithdraw,
            DateTime transactionDate)
        {
            this.AccountId = account.Id;
            this.Amount = amountToWithdraw;
            this.TransactionDate = transactionDate;
        }

        protected Debit()
        {
        }

        public AccountId AccountId { get; protected set; }
    }
}

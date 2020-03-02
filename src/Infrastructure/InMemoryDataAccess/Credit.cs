// <copyright file="Credit.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.InMemoryDataAccess
{
    using System;
    using Domain.Accounts;
    using Domain.Accounts.Credits;
    using Domain.Accounts.ValueObjects;

    public sealed class Credit : Domain.Accounts.Credits.Credit
    {
        public Credit(
            CreditId creditId,
            AccountId accountId,
            PositiveMoney amountToDeposit,
            DateTime transactionDate)
        {
            this.Id = creditId;
            this.AccountId = accountId;
            this.Amount = amountToDeposit;
            this.TransactionDate = transactionDate;
        }

        public AccountId AccountId { get; }
    }
}

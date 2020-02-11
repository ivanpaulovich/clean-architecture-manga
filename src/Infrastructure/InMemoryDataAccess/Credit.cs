// <copyright file="Credit.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.InMemoryDataAccess
{
    using System;
    using Domain.Accounts;
    using Domain.Accounts.ValueObjects;

    public class Credit : Domain.Accounts.Credits.Credit
    {
        public Credit(
            IAccount account,
            PositiveMoney amountToDeposit,
            DateTime transactionDate)
        {
            this.AccountId = account.Id;
            this.Amount = amountToDeposit;
            this.TransactionDate = transactionDate;
        }

        protected Credit()
        {
        }

        public AccountId AccountId { get; protected set; }
    }
}

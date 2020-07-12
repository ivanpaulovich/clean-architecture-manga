// <copyright file="Debit.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.DataAccess.Entities
{
    using System;
    using Domain.Accounts.ValueObjects;

    /// <summary>
    ///     Debit.
    /// </summary>
    public sealed class Debit : Domain.Accounts.Debits.Debit
    {
        public Debit(DebitId debitId, AccountId accountId, DateTime transactionDate, decimal value, string currency)
        {
            this.DebitId = debitId;
            this.AccountId = accountId;
            this.TransactionDate = transactionDate;
            this.Amount = new PositiveMoney(value, new Currency(currency));
        }

        public override DebitId DebitId { get; }

        /// <summary>
        ///     Gets or sets AccountId.
        /// </summary>
        public AccountId AccountId { get; }

        public override PositiveMoney Amount { get; }

        public decimal Value => this.Amount.Amount;

        public string Currency => this.Amount.Currency.Code;

        public override DateTime TransactionDate { get; }

        public Account? Account { get; set; }
    }
}

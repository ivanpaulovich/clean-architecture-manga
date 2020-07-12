// <copyright file="Account.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Accounts
{
    using Credits;
    using Debits;
    using ValueObjects;

    /// <inheritdoc />
    public abstract class Account : IAccount
    {
        /// <summary>
        ///     Gets or sets Credits List.
        /// </summary>
        public abstract CreditsCollection Credits { get; }

        /// <summary>
        ///     Gets or sets Debits List.
        /// </summary>
        public abstract DebitsCollection Debits { get; }

        public abstract Currency Currency { get; }

        /// <inheritdoc />
        public abstract AccountId AccountId { get; }

        /// <inheritdoc />
        public void Deposit(Credit credit) => this.Credits.Add(credit);

        /// <inheritdoc />
        public void Withdraw(Debit debit) => this.Debits.Add(debit);

        /// <inheritdoc />
        public bool IsClosingAllowed() => this.GetCurrentBalance()
            .IsZero();

        /// <inheritdoc />
        public Money GetCurrentBalance()
        {
            PositiveMoney totalCredits = this.Credits
                .GetTotal();

            PositiveMoney totalDebits = this.Debits
                .GetTotal();

            Money totalAmount = totalCredits
                .Subtract(totalDebits);

            return totalAmount;
        }
    }
}

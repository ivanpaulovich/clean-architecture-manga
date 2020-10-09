// <copyright file="Account.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain
{
    using Credits;
    using Debits;
    using ValueObjects;

    /// <inheritdoc />
    public class Account : IAccount
    {
        public Account(AccountId accountId, string externalUserId, Currency currency)
        {
            this.AccountId = accountId;
            this.Currency = currency;
            this.ExternalUserId = externalUserId;
        }

        /// <summary>
        ///     Gets the ExternalUserId.
        /// </summary>
        public string ExternalUserId { get; }

        /// <summary>
        ///     Gets the Credits List.
        /// </summary>
        public CreditsCollection CreditsCollection { get; } = new CreditsCollection();

        /// <summary>
        ///     Gets the Debits List.
        /// </summary>
        public DebitsCollection DebitsCollection { get; } = new DebitsCollection();

        /// <summary>
        ///     Gets the Currency.
        /// </summary>
        public Currency Currency { get; }

        /// <inheritdoc />
        public AccountId AccountId { get; }

        /// <inheritdoc />
        public void Deposit(Credit credit) => this.CreditsCollection.Add(credit);

        /// <inheritdoc />
        public void Withdraw(Debit debit) => this.DebitsCollection.Add(debit);

        /// <inheritdoc />
        public bool IsClosingAllowed() => this.GetCurrentBalance()
            .IsZero();

        /// <inheritdoc />
        public Money GetCurrentBalance()
        {
            Money totalCredits = this.CreditsCollection
                .GetTotal();

            Money totalDebits = this.DebitsCollection
                .GetTotal();

            Money totalAmount = totalCredits
                .Subtract(totalDebits);

            return totalAmount;
        }
    }
}

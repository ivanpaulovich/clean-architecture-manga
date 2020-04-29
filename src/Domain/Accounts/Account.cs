// <copyright file="Account.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Accounts
{
    using System;
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

        /// <inheritdoc />
        public abstract AccountId Id { get; }

        /// <inheritdoc />
        public ICredit Deposit(IAccountFactory entityFactory, PositiveMoney amountToDeposit)
        {
            if (entityFactory is null)
            {
                throw new ArgumentNullException(nameof(entityFactory));
            }

            ICredit credit = entityFactory.NewCredit(this, amountToDeposit, DateTime.UtcNow);
            this.Credits.Add(credit);
            return credit;
        }

        /// <inheritdoc />
        public IDebit Withdraw(IAccountFactory entityFactory, PositiveMoney amountToWithdraw)
        {
            if (entityFactory is null)
            {
                throw new ArgumentNullException(nameof(entityFactory));
            }

            if (this.GetCurrentBalance().LessThan(amountToWithdraw))
            {
                throw new MoneyShouldBePositiveException(Messages.AccountHasNotEnoughFunds);
            }

            IDebit debit = entityFactory.NewDebit(this, amountToWithdraw, DateTime.UtcNow);
            this.Debits.Add(debit);
            return debit;
        }

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

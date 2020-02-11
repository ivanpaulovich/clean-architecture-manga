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
        ///     Initializes a new instance of the <see cref="Account" /> class.
        /// </summary>
        protected Account()
        {
            this.Credits = new CreditsCollection();
            this.Debits = new DebitsCollection();
        }

        /// <summary>
        ///     Gets or sets Credits List.
        /// </summary>
        public CreditsCollection Credits { get; protected set; }

        /// <summary>
        ///     Gets or sets Debits List.
        /// </summary>
        public DebitsCollection Debits { get; protected set; }

        /// <inheritdoc />
        public AccountId Id { get; protected set; }

        /// <inheritdoc />
        public ICredit Deposit(IAccountFactory entityFactory, PositiveMoney amountToDeposit)
        {
            if (entityFactory is null)
                throw new ArgumentNullException(nameof(entityFactory));

            var credit = entityFactory.NewCredit(this, amountToDeposit, DateTime.UtcNow);
            this.Credits.Add(credit);
            return credit;
        }

        /// <inheritdoc />
        public IDebit Withdraw(IAccountFactory entityFactory, PositiveMoney amountToWithdraw)
        {
            if (entityFactory is null)
                throw new ArgumentNullException(nameof(entityFactory));

            if (this.GetCurrentBalance().LessThan(amountToWithdraw))
            {
                throw new MoneyShouldBePositiveException(Messages.AccountHasNotEnoughFunds);
            }

            var debit = entityFactory.NewDebit(this, amountToWithdraw, DateTime.UtcNow);
            this.Debits.Add(debit);
            return debit;
        }

        /// <inheritdoc />
        public bool IsClosingAllowed()
        {
            return this.GetCurrentBalance().IsZero();
        }

        /// <inheritdoc />
        public Money GetCurrentBalance()
        {
            var totalCredits = this.Credits
                .GetTotal();

            var totalDebits = this.Debits
                .GetTotal();

            var totalAmount = totalCredits
                .Subtract(totalDebits);

            return totalAmount;
        }
    }
}

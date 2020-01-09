namespace Domain.Accounts
{
    using System;
    using Domain.Accounts.Credits;
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;

    /// <inheritdoc/>
    public abstract class Account : IAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class.
        /// </summary>
        protected Account()
        {
            this.Credits = new CreditsCollection();
            this.Debits = new DebitsCollection();
        }

        /// <inheritdoc/>
        public AccountId Id { get; protected set; }

        /// <summary>
        /// Gets or sets Credits List.
        /// </summary>
        public CreditsCollection Credits { get; protected set; }

        /// <summary>
        /// Gets or sets Debits List.
        /// </summary>
        public DebitsCollection Debits { get; protected set; }

        /// <inheritdoc/>
        public ICredit Deposit(IAccountFactory entityFactory, PositiveMoney amountToDeposit)
        {
            var credit = entityFactory.NewCredit(this, amountToDeposit, DateTime.UtcNow);
            this.Credits.Add(credit);
            return credit;
        }

        /// <inheritdoc/>
        public IDebit Withdraw(IAccountFactory entityFactory, PositiveMoney amountToWithdraw)
        {
            if (this.GetCurrentBalance().LessThan(amountToWithdraw))
            {
                throw new MoneyShouldBePositiveException("Account has not enough funds.");
            }

            var debit = entityFactory.NewDebit(this, amountToWithdraw, DateTime.UtcNow);
            this.Debits.Add(debit);
            return debit;
        }

        /// <inheritdoc/>
        public bool IsClosingAllowed()
        {
            return this.GetCurrentBalance().IsZero();
        }

        /// <inheritdoc/>
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

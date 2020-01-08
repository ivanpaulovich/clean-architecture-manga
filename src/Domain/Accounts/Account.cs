namespace Domain.Accounts
{
    using System;
    using Domain.Accounts.Credits;
    using Domain.Accounts.Debits;
    using Domain.Accounts.ValueObjects;

    /// <summary>
    /// Account Aggregate.
    /// </summary>
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

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public AccountId Id { get; protected set; }

        /// <summary>
        /// Gets or sets Credits List.
        /// </summary>
        public CreditsCollection Credits { get; protected set; }

        /// <summary>
        /// Gets or sets Debits List.
        /// </summary>
        public DebitsCollection Debits { get; protected set; }

        /// <summary>
        /// Deposits.
        /// </summary>
        /// <param name="entityFactory">Entity Factory Service.</param>
        /// <param name="amountToDeposit">Amount to Deposit.</param>
        /// <returns>The Credit Transaction.</returns>
        public ICredit Deposit(IAccountFactory entityFactory, PositiveMoney amountToDeposit)
        {
            var credit = entityFactory.NewCredit(this, amountToDeposit, DateTime.UtcNow);
            this.Credits.Add(credit);
            return credit;
        }

        /// <summary>
        /// Withdrawls.
        /// </summary>
        /// <param name="entityFactory">Entity Factory Service.</param>
        /// <param name="amountToWithdraw">Amount to Withdrawl.</param>
        /// <returns>The Debit Transaction.</returns>
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

        /// <summary>
        /// Returns true if closing account is allowed.
        /// </summary>
        /// <returns>True if can be closed.</returns>
        public bool IsClosingAllowed()
        {
            return this.GetCurrentBalance().IsZero();
        }

        /// <summary>
        /// Gets the Current Balance.
        /// </summary>
        /// <returns>Money.</returns>
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

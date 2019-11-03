namespace Domain.Accounts
{
    using System;
    using Domain.ValueObjects;

    public class Account : IAccount
    {
        public Guid Id { get; protected set; }
        public CreditsCollection Credits { get; protected set; }
        public DebitsCollection Debits { get; protected set; }

        protected Account()
        {
            Credits = new CreditsCollection();
            Debits = new DebitsCollection();
        }

        public ICredit Deposit(IEntityFactory entityFactory, PositiveMoney amountToDeposit)
        {
            var credit = entityFactory.NewCredit(this, amountToDeposit, DateTime.UtcNow);
            Credits.Add(credit);
            return credit;
        }

        public IDebit Withdraw(IEntityFactory entityFactory, PositiveMoney amountToWithdraw)
        {
            if (GetCurrentBalance().LessThan(amountToWithdraw))
                throw new MoneyShouldBePositiveException("Account has not enough funds.");

            var debit = entityFactory.NewDebit(this, amountToWithdraw, DateTime.UtcNow);
            Debits.Add(debit);
            return debit;
        }

        public bool IsClosingAllowed()
        {
            return GetCurrentBalance().IsZero();
        }

        public Money GetCurrentBalance()
        {
            var totalCredits = Credits
                .GetTotal();

            var totalDebits = Debits
                .GetTotal();

            var totalAmount = totalCredits
                .Subtract(totalDebits);

            return totalAmount;
        }
    }
}
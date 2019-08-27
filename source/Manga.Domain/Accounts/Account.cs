namespace Manga.Domain.Accounts
{
    using System;
    using Manga.Domain.ValueObjects;

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

        public ICredit Deposit(IEntityFactory entityFactory, PositiveAmount amountToDeposit)
        {
            var credit = entityFactory.NewCredit(this, amountToDeposit);
            Credits.Add(credit);
            return credit;
        }

        public IDebit Withdraw(IEntityFactory entityFactory, PositiveAmount amountToWithdraw)
        {
            if (GetCurrentBalance().LessThan(amountToWithdraw))
                return null;

            var debit = entityFactory.NewDebit(this, amountToWithdraw);
            Debits.Add(debit);
            return debit;
        }

        public bool IsClosingAllowed()
        {
            return GetCurrentBalance().IsZero();
        }

        public Amount GetCurrentBalance()
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
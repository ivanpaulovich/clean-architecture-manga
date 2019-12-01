namespace Domain.Accounts.Credits
{
    using System;
    using Domain.Accounts.ValueObjects;

    public class Credit : ICredit
    {
        public CreditId Id { get; protected set; }

        public PositiveMoney Amount { get; protected set; }

        public string Description
        {
            get { return "Credit"; }
        }

        public DateTime TransactionDate { get; protected set; }

        public PositiveMoney Sum(PositiveMoney amount)
        {
            return Amount.Add(amount);
        }
    }
}

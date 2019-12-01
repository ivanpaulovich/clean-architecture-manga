namespace Domain.Accounts.Debits
{
    using System;
    using Domain.Accounts.ValueObjects;

    public class Debit : IDebit
    {
        public DebitId Id { get; protected set; }

        public PositiveMoney Amount { get; protected set; }

        public string Description { get => "Debit"; }

        public DateTime TransactionDate { get; protected set; }

        public PositiveMoney Sum(PositiveMoney amount) => Amount.Add(amount);
    }
}

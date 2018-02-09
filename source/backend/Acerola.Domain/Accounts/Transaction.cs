namespace Acerola.Domain.Accounts
{
    using Acerola.Domain.ValueObjects;
    using System;

    public abstract class Transaction : Entity
    {
        public Amount Amount { get; protected set; }
        public abstract string Description { get; }
        public DateTime TransactionDate { get; set; }

        protected Transaction()
        {
            TransactionDate = DateTime.Now;
        }
    }
}

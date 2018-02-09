namespace Acerola.Domain.Accounts
{
    using Acerola.Domain.ValueObjects;
    using System;

    public class Debit : Transaction
    {
        private Debit()
        {

        }

        public override string Description
        {
            get
            {
                return "Debit";
            }
        }

        public static Debit Create(Amount amount)
        {
            if (amount == null)
                throw new ArgumentNullException(nameof(amount));

            Debit debit = new Debit();
            debit.Amount = amount;
            return debit;
        }
    }
}

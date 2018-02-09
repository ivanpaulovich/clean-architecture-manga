namespace Acerola.Domain.Accounts
{
    using Acerola.Domain.ValueObjects;
    using System;

    public class Credit : Transaction
    {
        private Credit()
        {

        }

        public override string Description
        {
            get
            {
                return "Credit";
            }
        }

        public static Credit Create(Amount amount)
        {
            if (amount == null)
                throw new ArgumentNullException(nameof(amount));

            Credit credit = new Credit();
            credit.Amount = amount;
            return credit;
        }
    }
}

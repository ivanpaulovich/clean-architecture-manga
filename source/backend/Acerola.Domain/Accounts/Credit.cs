namespace Acerola.Domain.Accounts
{
    using Acerola.Domain.ValueObjects;

    public class Credit : Transaction
    {
        public Credit()
        {

        }

        public Credit(Amount amount)
            : base(amount)
        {

        }

        public override string Description
        {
            get
            {
                return "Credit";
            }
        }
    }
}

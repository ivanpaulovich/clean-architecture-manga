namespace Domain.Accounts.ValueObjects
{
    public readonly struct PositiveMoney
    {
        private readonly Money _value;

        public PositiveMoney(decimal value)
        {
            if (value < 0)
            {
                throw new MoneyShouldBePositiveException("The 'Amount' should be positive.");
            }

            this._value = new Money(value);
        }

        public Money ToMoney() => this._value;

        internal PositiveMoney Add(PositiveMoney positiveAmount)
        {
            return this._value.Add(positiveAmount._value);
        }

        internal Money Subtract(PositiveMoney positiveAmount)
        {
            return this._value.Subtract(positiveAmount._value);
        }
    }
}

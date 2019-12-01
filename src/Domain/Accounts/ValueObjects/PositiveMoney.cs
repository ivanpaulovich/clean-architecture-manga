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

            _value = new Money(value);
        }

        public Money ToMoney() => _value;

        internal PositiveMoney Add(PositiveMoney positiveAmount)
        {
            return _value.Add(positiveAmount._value);
        }

        internal Money Subtract(PositiveMoney positiveAmount)
        {
            return _value.Subtract(positiveAmount._value);
        }
    }
}

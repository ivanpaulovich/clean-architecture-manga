namespace Domain.ValueObjects
{
    using System;

    public readonly struct PositiveMoney : IEquatable<PositiveMoney>
    {
        private readonly Money _value;

        public PositiveMoney(decimal value)
        {
            if (value < 0)
                throw new MoneyShouldBePositiveException("The 'Amount' should be positive.");

            _value = new Money(value);
        }

        public Money ToMoney()
            => _value;

        public bool Equals(PositiveMoney other)
            => _value.Equals(other._value);

        public override bool Equals(object obj)
            => obj is PositiveMoney other && Equals(other);

        public override int GetHashCode()
            => _value.GetHashCode();

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

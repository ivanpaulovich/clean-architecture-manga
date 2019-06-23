namespace Manga.Domain.ValueObjects
{
    using System;

    public sealed class PositiveAmount : IEquatable<PositiveAmount>
    {
        private readonly Amount _value;

        private PositiveAmount() { }

        public PositiveAmount(double value)
        {
            if (value < 0)
                throw new AmountShouldBePositiveException("The 'Amount' should be positive.");

            _value = new Amount(value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is double)
            {
                return (double) obj == _value.ToDouble();
            }

            return ((PositiveAmount) obj)._value == _value;
        }

        public Amount ToAmount()
        {
            return _value;
        }

        internal PositiveAmount Add(PositiveAmount positiveAmount)
        {
            return _value.Add(positiveAmount._value);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + _value.GetHashCode();
                return hash;
            }
        }

        internal Amount Subtract(PositiveAmount positiveAmount)
        {
            return _value.Subtract(positiveAmount._value);
        }

        public bool Equals(PositiveAmount other)
        {
            return this._value == other._value;
        }
    }
}
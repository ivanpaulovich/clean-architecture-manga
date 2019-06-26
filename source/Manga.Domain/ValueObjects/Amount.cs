namespace Manga.Domain.ValueObjects
{
    using System;

    public sealed class Amount : IEquatable<Amount>
    {
        private double _value;

        private Amount() { }

        public Amount(double value)
        {
            _value = value;
        }

        public double ToDouble()
        {
            return _value;
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
                return (double)obj == _value;
            }

            return ((Amount)obj)._value == _value;
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

        internal bool LessThan(PositiveAmount amount)
        {
            return _value < amount.ToAmount()._value;
        }

        internal bool IsZero()
        {
            return _value == 0;
        }

        public bool Equals(Amount other)
        {
            return _value == other._value;
        }

        internal PositiveAmount Add(Amount value)
        {
            return new PositiveAmount(_value + value.ToDouble());
        }

        internal Amount Subtract(Amount value)
        {
            return new Amount(_value - value.ToDouble());
        }
    }
}
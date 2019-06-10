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

        public override string ToString()
        {
            return _value.ToString();
        }

        public static implicit operator double(Amount value)
        {
            return value._value;
        }

        public static implicit operator Amount(double value)
        {
            return new Amount(value);
        }

        public static Amount operator +(Amount amount1, Amount amount2)
        {
            return new Amount(amount1._value + amount2._value);
        }

        public static Amount operator -(Amount amount1, Amount amount2)
        {
            return new Amount(amount1._value - amount2._value);
        }

        public static bool operator <(Amount amount1, Amount amount2)
        {
            return amount1._value < amount2._value;
        }

        public static bool operator >(Amount amount1, Amount amount2)
        {
            return amount1._value > amount2._value;
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
                return (double) obj == _value;
            }

            return ((Amount) obj)._value == _value;
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

        public bool Equals(Amount other)
        {
            return this._value == other._value;
        }
    }
}
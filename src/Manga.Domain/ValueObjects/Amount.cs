namespace Manga.Domain.ValueObjects
{
    public sealed class Amount
    {
        private double _value;

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

        public static bool operator <=(Amount amount1, Amount amount2)
        {
            return amount1._value <= amount2._value;
        }

        public static bool operator >=(Amount amount1, Amount amount2)
        {
            return amount1._value >= amount2._value;
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
    }
}

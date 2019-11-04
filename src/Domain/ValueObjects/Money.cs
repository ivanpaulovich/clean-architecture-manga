namespace Domain.ValueObjects
{
    using System;

    public struct Money : IEquatable<Money>
    {
        private readonly decimal _money;

        public Money(decimal value)
        {
            _money = value;
        }

        public decimal ToDecimal()
        {
            return _money;
        }

        public override bool Equals(object obj)
        {
            if (obj is decimal)
            {
                return (decimal) obj == _money;
            }

            return ((Money) obj)._money == _money;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + _money.GetHashCode();
                return hash;
            }
        }

        internal bool LessThan(PositiveMoney amount)
        {
            return _money < amount.ToMoney()._money;
        }

        internal bool IsZero()
        {
            return _money == 0;
        }

        internal readonly PositiveMoney Add(Money value)
        {
            return _money == other._money;
        }

        internal PositiveMoney Add(Money value)
        {
            return new PositiveMoney(_money + value.ToDecimal());
        }

        internal readonly Money Subtract(Money value)
        {
            return new Money(_money - value.ToDecimal());
        }
    }
}
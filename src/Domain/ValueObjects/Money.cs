namespace Domain.ValueObjects
{
    using System;

    public readonly struct Money : IEquatable<Money>
    {
        private readonly decimal _money;

        public Money(decimal value)
        {
            _money = value;
        }

        public decimal ToDecimal()
            => _money;

        public bool Equals(Money other)
            => _money == other._money;

        public override bool Equals(object obj)
            => obj is Money other && Equals(other);

        public override int GetHashCode()
            => _money.GetHashCode();

        internal bool LessThan(PositiveMoney amount)
        {
            return _money < amount.ToMoney()._money;
        }

        internal bool IsZero()
        {
            return _money == 0;
        }

        internal PositiveMoney Add(Money value)
        {
            return new PositiveMoney(_money + value.ToDecimal());
        }

        internal Money Subtract(Money value)
        {
            return new Money(_money - value.ToDecimal());
        }
    }
}

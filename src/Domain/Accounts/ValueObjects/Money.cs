namespace Domain.Accounts.ValueObjects
{
    public readonly struct Money
    {
        private readonly decimal _money;

        public Money(decimal value)
        {
            _money = value;
        }

        public decimal ToDecimal() => _money;

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

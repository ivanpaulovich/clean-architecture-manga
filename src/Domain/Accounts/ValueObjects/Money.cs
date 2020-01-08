namespace Domain.Accounts.ValueObjects
{
    public readonly struct Money
    {
        private readonly decimal _money;

        public Money(decimal value)
        {
            this._money = value;
        }

        public decimal ToDecimal() => this._money;

        internal bool LessThan(PositiveMoney amount)
        {
            return this._money < amount.ToMoney()._money;
        }

        internal bool IsZero()
        {
            return this._money == 0;
        }

        internal PositiveMoney Add(Money value)
        {
            return new PositiveMoney(this._money + value.ToDecimal());
        }

        internal Money Subtract(Money value)
        {
            return new Money(this._money - value.ToDecimal());
        }
    }
}

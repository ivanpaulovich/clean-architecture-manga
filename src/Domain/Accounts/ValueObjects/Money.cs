namespace Domain.Accounts.ValueObjects
{
    /// <summary>
    /// Money <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#entity">Entity Design Pattern</see>.
    /// </summary>
    public readonly struct Money
    {
        private readonly decimal _money;

        /// <summary>
        /// Initializes a new instance of the <see cref="Money"/> struct.
        /// </summary>
        /// <param name="value">Decimal amount.</param>
        public Money(decimal value)
        {
            this._money = value;
        }

        /// <summary>
        /// Converts into decimal.
        /// </summary>
        /// <returns>decimal amount.</returns>
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

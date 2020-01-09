namespace Domain.Accounts.ValueObjects
{
    /// <summary>
    /// PositiveMoney <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#entity">Entity Design Pattern</see>.
    /// </summary>
    public readonly struct PositiveMoney
    {
        private readonly Money _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="PositiveMoney"/> struct.
        /// </summary>
        /// <param name="value">Decimal amount.</param>
        public PositiveMoney(decimal value)
        {
            if (value < 0)
            {
                throw new MoneyShouldBePositiveException("The 'Amount' should be positive.");
            }

            this._value = new Money(value);
        }

        /// <summary>
        /// Converts into Money Value Object.
        /// </summary>
        /// <returns>Money.</returns>
        public Money ToMoney() => this._value;

        internal PositiveMoney Add(PositiveMoney positiveAmount)
        {
            return this._value.Add(positiveAmount._value);
        }

        internal Money Subtract(PositiveMoney positiveAmount)
        {
            return this._value.Subtract(positiveAmount._value);
        }
    }
}

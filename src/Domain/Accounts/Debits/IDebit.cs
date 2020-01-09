namespace Domain.Accounts.Debits
{
    using Domain.Accounts.ValueObjects;

    /// <summary>
    /// Debit.
    /// </summary>
    public interface IDebit
    {
        /// <summary>
        /// Calculates the sum of two positive amounts.
        /// </summary>
        /// <param name="amount">Positive amount.</param>
        /// <returns>The sum.</returns>
        PositiveMoney Sum(PositiveMoney amount);
    }
}

namespace Domain.Accounts.Debits
{
    using Domain.Accounts.ValueObjects;

    /// <summary>
    /// Debit.
    /// </summary>
    public interface IDebit
    {
        PositiveMoney Sum(PositiveMoney amount);
    }
}

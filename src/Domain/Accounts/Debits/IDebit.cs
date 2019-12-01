namespace Domain.Accounts.Debits
{
    using Domain.Accounts.ValueObjects;

    public interface IDebit
    {
        PositiveMoney Sum(PositiveMoney amount);
    }
}

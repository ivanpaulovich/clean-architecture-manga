namespace Domain.Accounts
{
    using Domain.ValueObjects;

    public interface IDebit
    {
        PositiveMoney Sum(PositiveMoney amount);
    }
}
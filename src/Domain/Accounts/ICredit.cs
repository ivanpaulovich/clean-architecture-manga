namespace Domain.Accounts
{
    using Domain.ValueObjects;

    public interface ICredit
    {
        PositiveMoney Sum(PositiveMoney amount);
    }
}
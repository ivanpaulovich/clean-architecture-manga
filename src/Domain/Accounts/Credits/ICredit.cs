namespace Domain.Accounts.Credits
{
    using Domain.Accounts.ValueObjects;

    public interface ICredit
    {
        PositiveMoney Sum(PositiveMoney amount);
    }
}

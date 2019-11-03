namespace Domain.Accounts
{
    using Domain.ValueObjects;

    public interface ICredit : IEntity
    {
        PositiveMoney Sum(PositiveMoney amount);
    }
}
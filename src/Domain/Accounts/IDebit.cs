namespace Domain.Accounts
{
    using Domain.ValueObjects;

    public interface IDebit : IEntity
    {
        PositiveMoney Sum(PositiveMoney amount);
    }
}
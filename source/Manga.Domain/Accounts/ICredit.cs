namespace Manga.Domain.Accounts
{
    using Manga.Domain.ValueObjects;

    public interface ICredit : IEntity
    {
        PositiveMoney Sum(PositiveMoney amount);
    }
}

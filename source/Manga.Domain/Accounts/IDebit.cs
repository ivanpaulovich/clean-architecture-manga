namespace Manga.Domain.Accounts
{
    using Manga.Domain.ValueObjects;

    public interface IDebit : IEntity
    {
        PositiveMoney Sum(PositiveMoney amount);
    }
}

namespace Manga.Domain.Accounts
{
    using Manga.Domain.ValueObjects;

    public interface ICredit : IEntity
    {
        PositiveAmount Sum(PositiveAmount amount);
    }
}
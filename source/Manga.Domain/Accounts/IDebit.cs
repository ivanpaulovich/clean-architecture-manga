namespace Manga.Domain.Accounts
{
    using Manga.Domain.ValueObjects;

    public interface IDebit : IEntity
    {
        PositiveAmount Sum(PositiveAmount amount);
    }
}
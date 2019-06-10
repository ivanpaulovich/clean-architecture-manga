namespace Manga.Domain.Accounts
{
    using Manga.Domain.ValueObjects;

    public interface IDebit : IEntity
    {
        Amount Add(Amount amount);
    }
}
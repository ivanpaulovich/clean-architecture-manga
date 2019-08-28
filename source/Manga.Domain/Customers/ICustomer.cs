namespace Manga.Domain.Customers
{
    using Manga.Domain.Accounts;

    public interface ICustomer : IAggregateRoot
    {
        AccountCollection Accounts { get; }
        void Register(IAccount account);
    }
}
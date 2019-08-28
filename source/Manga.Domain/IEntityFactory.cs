namespace Manga.Domain
{
    using Manga.Domain.Accounts;
    using Manga.Domain.Customers;
    using Manga.Domain.ValueObjects;

    public interface IEntityFactory
    {
        ICustomer NewCustomer(SSN ssn, Name name);
        IAccount NewAccount(ICustomer customer);
        ICredit NewCredit(IAccount account, PositiveAmount amountToDeposit);
        IDebit NewDebit(IAccount account, PositiveAmount amountToWithdraw);
    }
}